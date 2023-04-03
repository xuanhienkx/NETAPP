using CS.Common;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.SwiftParser;
using CS.SwiftParser.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;

namespace VSDGateway
{
    public interface IGatewayService
    {
        Task<bool> Process(SwiftBag bag);
        Task<bool> ProcessRequest(string command, string data);
    }

    public class GatewayService : IGatewayService
    {
        private readonly IFileService fileService;
        private readonly IWritableOptions<SessionConfigurationSection> configWriter;
        private readonly SwiftSetting swiftSetting;
        private readonly IConfigurationRoot configuration;
        private readonly IMessageBuilder messageBuilder;
        private readonly ILogger<GatewayService> logger;

        private readonly string bicCode;
        private readonly string tempPath;
        private readonly string sendPath;
        private readonly string pendingPath;

        private DateTime currentDate;
        private long sessionNumber;
        private long inputSequenceNumber;
        private const string DateFormatString = "yyyyMMdd";

        private static readonly object LockObj = new object();

        public GatewayService(
            IFileService fileService,
            IMessageBuilder messageBuilder,
            IConfigurationRoot configuration,
            SwiftSetting swiftSetting,
            ILogger<GatewayService> logger,
            IWritableOptions<SessionConfigurationSection> configWriter)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.configWriter = configWriter ?? throw new ArgumentNullException(nameof(configWriter));
            this.swiftSetting = swiftSetting ?? throw new ArgumentNullException(nameof(swiftSetting));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.messageBuilder = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            bicCode = configuration["gateway:bicCode"].Trim('/', '\\');
            sendPath = configuration["vsd:sendPath"].Trim('/', '\\');
            tempPath = configuration["gateway:tempPath"].Trim('/', '\\');
            pendingPath = configuration["gateway:pendingPath"].Trim('/', '\\');

            // ensure path created
            fileService.EnsurePath(tempPath);
            fileService.EnsurePath(pendingPath);

            // read all sequence number from config file
            ParseCurrentSequenceNumbers();
        }

        public async Task<bool> Process(SwiftBag swiftBag)
        {
            ValidateTransactionDate();

            // filter by message type to get the ACK NAK
            // if NAK & NAK
            // use api PUT to inform 
            if (swiftBag.MessageType == MessageType.ACKNAK)
            {
                var requestRefId = swiftBag[BusinessIdProviderConstant.TransactionReferenceNumber];
                logger.LogInformation($"Process ACKNAK with TransactionReferenceNumber: {requestRefId} - MessageID : {swiftBag.MessageId}");
                // inform api to update the state  																									 
                swiftBag[BusinessIdProviderConstant.RequestStatus] = (long)swiftBag[BusinessIdProviderConstant.AcceptReject] == 0
                        ? CustodyRequestStatus.PendingProcess
                        : CustodyRequestStatus.FailureRejected;

                // else PUT to inform the failure
                var putPath = $"vsd/gateway/{requestRefId}";
                var result = await ApiProvider.Instance.GetAsync(async api => await api.PutAsync<IList<CsBagItem>, bool>(putPath, swiftBag.Items),
                    e => logger.LogError(e, "Request to inform failed"));

                logger.LogInformation("PUT to {0}: {1}", putPath, result.IsSuccess);
                return result.HasResult && result.Value;
            }
            else
            {
                var businessId = swiftBag[BusinessIdProviderConstant.BusinessId];
                logger.LogInformation($"Process with MessageID : {swiftBag.MessageId}");
                // else POST to process the bag
                var postPath = $"vsd/gateway/{businessId}";
                var result = await ApiProvider.Instance.GetAsync(
                    api => api.PostAsync<IList<CsBagItem>, bool>(postPath, swiftBag.Items),
                    e => logger.LogError(e, "Request to vsd api failure"));

                logger.LogInformation("POST to {0}: {1}", postPath, result.IsSuccess);

                if (result.HasResult && result.Value)
                {
                    // delete the pending message file
                    if (swiftBag.TryGet(BusinessIdProviderConstant.TransactionReferenceNumber, out string requestRefId))
                       await fileService.Delete($"{pendingPath}/{requestRefId}.dat");

                    return true;
                }
                return false;
            }
        }

        public async Task<bool> ProcessRequest(string command, string data)
        {
            try
            {
                ValidateTransactionDate();

                var bagItems = JsonConvert.DeserializeObject<IList<CsBagItem>>(data);
                var content = new CsBag(bagItems);
                //var content = JsonConvert.DeserializeObject<CsBag>(data);

                switch (command)
                {
                    case BusinessIdProviderConstant.MessageRequestCommandPublished:
                        // build message 
                        var errorMessage = await BuildRequestMessage(content);
                        // inform the request
                        return await InformRequest(errorMessage, content);
                    case BusinessIdProviderConstant.MessageRequestCommandCancel:
                        // resend to cancel the request message that is pending
                        return await CancelRequestMessage(content);
                    default:
                        logger.LogError("Invalid command {0}", command);
                        return false;
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "ProcessRequest failure");
                return false;
            }
        }

        private async Task<bool> InformRequest(string errorMessage, CsBag content)
        {
            var requestRefId = content[BusinessIdProviderConstant.TransactionReferenceNumber];

            // inform api to update the state
            var infomData = new CsBag
            {
                [BusinessIdProviderConstant.BusinessId] = content[BusinessIdProviderConstant.BusinessId],
                [BusinessIdProviderConstant.SessionInteger] = sessionNumber,
                [BusinessIdProviderConstant.InputSequenceInteger] = inputSequenceNumber,
                [BusinessIdProviderConstant.TransactionReferenceNumber] = content[BusinessIdProviderConstant.TransactionReferenceNumber],
                [BusinessIdProviderConstant.RequestStatus] = string.IsNullOrEmpty(errorMessage)? CustodyRequestStatus.Published : CustodyRequestStatus.PublishedFailed,
                [BusinessIdProviderConstant.RejectionMessage] = errorMessage
            };

            var result = await ApiProvider.Instance.GetAsync(async api => await api.PutAsync<IList<CsBagItem>, bool>($"vsd/gateway/{requestRefId}", infomData.Items),
                e => logger.LogError(e, "Request to inform failed"));
            logger.LogInformation($"InformRequest requestRef:{requestRefId} is {result.IsSuccess}" );
            return result.IsSuccess;
        }

        private async Task<bool> CancelRequestMessage(CsBag content)
        {
            var referenceId = content[BusinessIdProviderConstant.TransactionReferenceNumber];
            var pendingFile = $"{pendingPath}/{referenceId:D16}.dat";
            using (var stream = await fileService.Read(pendingFile))
            using (var reader = new System.IO.StreamReader(stream))
            {
                var contentData = reader.ReadToEnd();
                var itmes = JsonConvert.DeserializeObject<IDictionary<string, object>>(contentData);
                content = new CsBag(itmes);
            }

            // build message 
            var errorMessage = await BuildRequestMessage(content);
            // inform the request
            return await InformRequest(errorMessage, content);
        }

        private async Task<string> BuildRequestMessage(CsBag content)
        {
            var businessId = content[BusinessIdProviderConstant.BusinessId].ToString();
            var requestRefId = content[BusinessIdProviderConstant.TransactionReferenceNumber];
            var messageConfig = GetRequestMessageConfig(businessId);
            if (messageConfig == null)
            {
                var errorMessage = $"Cannot find the configuration file for bussiness id {businessId}";
                logger.LogError(errorMessage);
                return errorMessage;
            }

            // find the swiftsetting request
            var bag = new SwiftBag(messageConfig.Type)
            {
                ["VicsBiccode"] = bicCode,  //12 char
                ["SessionInteger"] = sessionNumber,
                ["InputSequenceInteger"] = inputSequenceNumber,
                [BusinessIdProviderConstant.MessageId] = messageConfig.Id
            };

            bag.AddRange(content);

            // write to file
            var fileName = BuildRequestMessageFilePath($"{businessId}_{requestRefId:D16}", messageConfig);
            var tempFilePath = $"{tempPath}/{fileName}";
            try
            {
                // write fin message
                using (var fileStream = await fileService.Open(tempFilePath))
                    messageBuilder.Write(fileStream, bag);

                UpdateSystemSequenceNumber();
                await fileService.Move(tempFilePath, sendPath);
                logger.LogInformation($"Built message from file {fileName} successfull and sent to {sendPath}");

                // write the bag content to pending folder
                var pendingFile = $"{pendingPath}/{requestRefId:D16}.dat";
                using (var stream = await fileService.Open(pendingFile))
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(JsonConvert.SerializeObject(bag.GetDictionary()));
                }

                logger.LogInformation($"Created pending data after request message with file: {pendingFile}");
                return null;
            }
            catch (Exception ex)
            {
                if (File.Exists(tempFilePath))
                    File.Delete(tempFilePath);
                var errorMessage = ex.Message;
                logger.LogError(ex, $"Build message {businessId} with ref {requestRefId} error");
                return errorMessage;
            }
        }

        private void ParseCurrentSequenceNumbers()
        {
            var session = configuration.GetSection("vsd:session");
            var currentDateString = session["currentDate"];
            if (string.IsNullOrEmpty(currentDateString))
            {
                currentDate = DateTime.Today;
                sessionNumber = 1;
                inputSequenceNumber = 1;
            }
            else
            {
                if (!DateTime.TryParseExact(currentDateString, DateFormatString, CultureInfo.CurrentUICulture, DateTimeStyles.None, out currentDate)
                    || currentDate.DayOfYear != DateTime.Today.DayOfYear)
                {
                    currentDate = DateTime.Today;
                    sessionNumber = 1;
                    inputSequenceNumber = 1;
                }
                else
                {
                    if (!long.TryParse(session["sessionNumber"], out sessionNumber))
                        sessionNumber = 1;
                    if (!long.TryParse(session["inputSequenceNumber"], out inputSequenceNumber))
                        inputSequenceNumber = 1;
                }
            }
        }

        private void ValidateTransactionDate()
        {
            if (currentDate.DayOfYear == DateTime.Today.DayOfYear)
                return;

            lock (LockObj)
            {
                currentDate = DateTime.Today;
                sessionNumber = 1;
                inputSequenceNumber = 1;
            }
        }

        private void UpdateSystemSequenceNumber()
        {
            lock (LockObj)
            {
                inputSequenceNumber += 1;
            }

            // write the new sequence to setting file
            Task.Factory.StartNew(() =>
                configWriter.Update(section =>
                {
                    section.CurrentDate = currentDate.ToString(DateFormatString);
                    section.InputSequenceNumber = inputSequenceNumber;
                    section.SessionNumber = sessionNumber;
                }));
        }

        private string BuildRequestMessageFilePath(string businessId, Message messageConfig)
        {
            var fileExt = messageConfig.Type == MessageType.FileACT ? ".par" : ".fin";
            return $"{businessId.Replace(".", "_")}{fileExt}";
        }

        private Message GetRequestMessageConfig(string businessId)
        {
            var business = swiftSetting.BusinessUnits.FirstOrDefault(x => x.Id == businessId);
            return business.Messages?.FirstOrDefault(x => x.RequestType == RequestType.Request);
        }
    }
}
