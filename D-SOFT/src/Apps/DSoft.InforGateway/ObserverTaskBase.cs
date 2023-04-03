using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using DSoft.InforGateway.Services;
using DSoft.MarketParser;
using DSoft.MarketParser.Common;
using DSoft.MarketParser.Exceptions;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace DSoft.InforGateway
{
    public abstract class ObserverTaskBase
    {
        protected readonly IEnumerable<IHoseMessageConverter> msgConverters;
        protected readonly IFileService fileService;
        protected readonly IGatewayService gatewayService;
        protected readonly ILogger<ObserverTaskBase> logger;
        protected readonly IConfigurationRoot settings;

        protected ObserverTaskBase(
            IEnumerable<IHoseMessageConverter> msgConverters,
            IFileService fileService,
            ILogger<ObserverTaskBase> logger,
            IGatewayService gatewayService,
            IConfigurationRoot settings)
        {
            this.msgConverters = msgConverters ?? throw new ArgumentNullException(nameof(msgConverters));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            if (bool.TryParse(settings["gateway:isDebug"].ToLowerInvariant(), out var isDebug))
                IsDebug = isDebug;
        }
        public abstract DateTime ProcessDate { get; }
        public bool IsDebug { get; private set; }

        public async Task<bool> ProcessMessage(byte[] stream, string fileName)
        {
            var messageName = Path.GetFileNameWithoutExtension(fileName);
            var parser = msgConverters.FirstOrDefault(x => x.CanParse(messageName, ProcessDate));
            if (parser == null)
                throw new InvalidMarketMessageException("Cannot find the parser that is suitable while reading message");

            var timer = new Stopwatch();
            timer.Start();
            logger.LogInformation("------- Begin TO PROCESS Convert FILE {0}, Date: {1:N0}  -------", messageName, DateTime.Now.Ticks);
            var bag = await parser.Read<PrsBag>(stream, messageName);
            var result = bag != null;
            if (result)
            {
                bag[$"{bag.MessageName}[-1].{ProviderConstants.TradingDate}"] = ProcessDate.ToString("dd/MM/yyyy");
                bag[$"{bag.MessageName}[-1].{ProviderConstants.MessageName}"] = messageName;
                var subDir = (messageName.Contains("CS_") || messageName.Contains($"{ProcessDate:yyyyMMdd}_")) ? "Index" : "PRS";

                //TextWriter tsw = new StreamWriter($"../message/{subDir}/{ProcessDate:yyyyMMdd}_{messageName}.json", true);
                //await tsw.WriteAsync(Pars(bag));
                //await tsw.FlushAsync();
                //await tsw.DisposeAsync();
               result = await gatewayService.Process(bag);

            }
            logger.LogInformation("End PROCESS Convert FILE [{0}] in: {1:N0}ms", messageName, timer.ElapsedMilliseconds);
            timer.Stop();
            return result;

        }

        private string Pars(CsBag bag)
        {
            IDictionary<string, object> bagToJson = bag.GetDictionary();
            var data = bagToJson.Where(x => x.Key.IndexOf("[-1]") <= 0).GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
             .Select(group => group.Aggregate(new Dictionary<string, object>(), (obj, item) =>
             {
                 obj[item.Key.Substring(item.Key.IndexOf(".") + 1)] = item.Value;
                 return obj;
             })).ToList();

            var str = JsonSerializer.Serialize(data);
            return str;
        }
        protected void Execute(Action action, string fileName)
        {
            var timer = new Stopwatch();
            timer.Start();
            logger.LogInformation("Begin PROCESS FILE [{0}]", fileName);
            action();
            timer.Stop();
            logger.LogInformation("End PROCESS FILE [{0}] in: {1:N0}ms", fileName, timer.ElapsedMilliseconds);
        }

    }
}
