using DO.Common;
using DO.Common.FileTransfer;
using DO.Common.Interfaces;
using DO.Common.Std.Extensions;
using DO.MarketParser;
using DO.MarketParser.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BO.MarketInfoGateway
{
    public class DirectoryObserverTask : ITargetTask
    {
        private readonly IFileService fileService;
        private readonly IDirectoryObservationService observationService;
        private readonly IGatewayService gatewayService;
        private readonly IConfigurationRoot settings;
        private readonly IMarketMessageConverter messageConverter;
        private readonly ILogger<DirectoryObserverTask> logger;
        private readonly PrsSetting prsSetting;

        private string receivePath;
        private string receivePathBackup;
        private string receiveDateTrading;

        public DirectoryObserverTask(
            IFileService fileService,
            IDirectoryObservationService observationService,
            IGatewayService gatewayService,
            IConfigurationRoot settings,
            IMarketMessageConverter messageConverter,
            ILogger<DirectoryObserverTask> logger,
            PrsSetting prsSetting)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.observationService = observationService ?? throw new ArgumentNullException(nameof(observationService));
            this.gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.messageConverter = messageConverter ?? throw new ArgumentNullException(nameof(messageConverter));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.prsSetting = prsSetting ?? throw new ArgumentNullException(nameof(prsSetting));
        }

        public int Priority => 10;
        public string Name => "Observing file ....";

        public async Task Start(CancellationToken token)
        {
            receivePath = settings["Gateway:dataPath"].ToLowerInvariant();
            // observe on received folder
            fileService.EnsurePath(receivePath);
            var mapPath = Path.Combine(receivePath, prsSetting.FileMapName);
            var mapdata = ObjectLoader.LoadFromFile(mapPath);
            receivePathBackup = mapdata.Substring(mapdata.Length - prsSetting.NameLength, prsSetting.NameLength);
            receiveDateTrading = mapdata.Substring(mapdata.Length - prsSetting.MapSize, prsSetting.DateFormatLength);
            var backupPath = Path.Combine(receivePath, receivePathBackup);
            fileService.EnsurePath(backupPath);
            await observationService.Start(backupPath, ProcessFile, token, true);
            logger.LogInformation($"Finished lookup to {backupPath} AND KEEP OBSERVING on this.");
        }

        public bool Stop()
        {
            logger.LogInformation("Stop observering ...");
            return observationService.Stop();
        }
        private async Task<bool> ProcessFile(string fileName, Stream fileStream)
        {
            logger.LogInformation("------- START TO READ FILE: [{0}] -------", fileName);
            var messageName = fileService.GetFileName(fileName).Replace(".DAT", "");
            var bag = await messageConverter.Read<PrsBag>(fileStream, messageName);

            var result = bag != null;
            if (result)
            {
                // process the bag
                logger.LogInformation("Processing the message {0}, id: {1}", bag.MessageName, receiveDateTrading);
                result = await gatewayService.Process(bag);
            }
            logger.LogInformation("------- FINISH PROCESS FILE [{0}]: {1} ------- ", fileName, result);
            return result;
        }
    }
}
