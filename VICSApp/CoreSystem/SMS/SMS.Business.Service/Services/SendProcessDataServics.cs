using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using SMS.Common;
using SMS.Common.Action;
using SMS.Common.Configuration;
using SMS.Common.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Business.Service.Services
{
    public interface ISendProcessDataService
    {
        void ProcessSend(SmsType type);
        void TestSend();
    }
    public class SendProcessDataService : BaseDataService, ISendProcessDataService
    {
        private readonly ILogger _logger;

        public SendProcessDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork, ILogger logger)
            : base(smsUnitOfWork, sbsUnitOfWork)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        private IDictionary<Guid, int> _hashErrorCount = new Dictionary<Guid, int>();
        private int _totalMessage;

        public void ProcessSend(SmsType type)
        {
            try
            {
                var listSend = SmsUnitOfWork.RequestRepository.GetAllNeedSend();
                var smsRequests = listSend as IList<SmsRequest> ?? listSend.ToList();
                if (listSend != null && smsRequests.Any())
                {
                    _logger.Log("Begin Process Send Message");

                    int countErr = 0;
                    SmsClient smsClient = ApiEmsConfiguration.Current.SmsClient;
                    foreach (var request in smsRequests)
                    {

                        var contacs = new List<Contact>();

                        smsClient.MessageContent = request.Message;
#if DEBUG
                    contacs.Add(new Contact { Phone = "0936739089" });
                    contacs.Add(new Contact { Phone = "01297631749" });

#else
                        contacs = request.Customers.Select(x => new Contact { Phone = x.Mobile }).ToList();
#endif

                        smsClient.IsBrandname = request.IsBrandName;
                        smsClient.RequestId = request.Id;
                        smsClient.Contacts = contacs;
                        _logger.Log("Send Message: {0}", request.Message);

                        if (!SmsConfiguration.Current.AllowSendSMS)
                            continue;

                        /* var result = ESmsServices.SendMessage(
                             request.IsBrandName ? ESmsServices.OnPostSendBrandName : ESmsServices.OnPostSendNormal,
                             (object)smsClient);*/
                        var result = ESmsServices.SendMessage( ESmsServices.OnPostSendBrandName,(object)smsClient);
                        if (result == null) continue;
                        var log = new SmsLogOut
                        {
                            Id = Guid.NewGuid(),
                            ErrorMessage = result.ErrorMessage,
                            SmsRequest = request,
                            CodeResultResponse = result.CodeResult,
                            ReceiverTime = DateTime.Now,
                            SendTime = request.CreatedTime,
                            SmsIdResponse = result.SMSID
                        };
                        SmsUnitOfWork.LogOutRepository.Insert(log);
                        if (result.CodeResult == "100" || result.CodeResult == "124")
                        {
                            request.IsSent = true;
                            request.SmsIdResponse = result.SMSID;
                            SmsUnitOfWork.RequestRepository.Update(request);
                            _logger.Log("Send Successfully: {0}",
                                JsonConvert.SerializeObject(new { result.CodeResult, Smsid = result.SMSID, Message = string.IsNullOrEmpty(result.ErrorMessage) ? "" : result.ErrorMessage }));
                        }
                        else
                        {
                            if (_hashErrorCount.ContainsKey(request.Id))
                            {
                                int count = _hashErrorCount[request.Id];
                                if (count == 3)
                                {
                                    request.IsSent = true;
                                    request.SmsIdResponse = result.SMSID;
                                    SmsUnitOfWork.RequestRepository.Update(request);
                                    _logger.Log("Try send resend not success: {0}",
                                        new object[] { result.CodeResult, result.ErrorMessage });
                                }
                                count++;
                                _hashErrorCount[request.Id] = count;
                            }
                            else
                                _hashErrorCount.Add(request.Id, 1);
                            _logger.Log("Send Error: {0}", new object[] { result.CodeResult, result.ErrorMessage });
                        }
                    }
                    SmsUnitOfWork.SaveChanges();
                    if (countErr > 0)
                    {
                        _logger.LogError("Sending Process  Err -->{0} ", countErr);
                    }

                    _logger.Log("Total message have Send {0}", TotalMessage);
                    _logger.LogDebug("Hoan thanh send messsage moi lan chay");
                }
            }
            catch (InvalidOperationException iex)
            {
                _logger.LogError(iex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }

        }

        public void TestSend()
        {
            try
            {
                const string mes =
                       "Vics Test SMS";

                SmsClient smsClient = ApiEmsConfiguration.Current.SmsClient;
                var contacs = new List<Contact>();
                contacs.Add(new Contact { Phone = "0936739089" });
                smsClient.Contacts = contacs;
                smsClient.IsBrandname = false;
                smsClient.RequestId = Guid.NewGuid();
                smsClient.MessageContent = mes;
                smsClient.SanbBox = 1;
                var result =
                           ESmsServices.GetStausMessage(ESmsServices.OnGetStatus, new
                           {
                               SmsId = "14760594",
                               Apikey = smsClient.Apikey,
                               Secretkey = smsClient.Secretkey
                           });
                if (result != null && result.CodeResult == "100")
                {
                    _logger.Log("Sen thanh cong ==>{0}", JsonConvert.SerializeObject(result));
                }
                else
                {
                    if (result != null)
                    {
                        _logger.Log("Send loi  ==>{0}", JsonConvert.SerializeObject(result));
                    }
                    else
                    {
                        _logger.Log("Send loi  ==>xem chi tiet lo log");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }

        public override int TotalMessage
        {
            get { return SmsUnitOfWork.RequestRepository.Count(x => x.IsSent); }
        }
    }
}