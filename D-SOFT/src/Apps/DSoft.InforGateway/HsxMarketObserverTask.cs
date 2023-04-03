using DSoft.Common.Extensions;
using DSoft.Common.Shared.Interfaces;
using DSoft.InforGateway.Services;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace DSoft.InforGateway
{
    public class HsxMarketObserverTask : ObserverTaskBase, ITargetTask
    {
        private readonly IDirectoryObservationService observationService;
        private DateTime lastDate = DateTime.Today;
        private string receivePathBackup;
        private string prsReceivePath;
        private string indexReceivePath;
        public HsxMarketObserverTask(
            IFileService fileService,
            IDirectoryObservationService observationService,
            IGatewayService gatewayService,
            IConfigurationRoot settings,
              IEnumerable<IHoseMessageConverter> msgConverters,
            ILogger<HsxMarketObserverTask> logger
            ) : base(msgConverters, fileService, logger, gatewayService, settings)
        {
            this.observationService = observationService ?? throw new ArgumentNullException(nameof(observationService));
            prsReceivePath = settings["Gateway:dataPath"].ToLowerInvariant();
            indexReceivePath = settings["Gateway:indexPath"].ToLowerInvariant();
        }

        public int Priority => 10;
        public string Name => "Observing file PRS/Index ....";

        private bool CanStart()
        {
            bool canStart = true;
            if (IsDebug)
            {
                Executor.Try(
                   () => lastDate = DateTime.ParseExact(settings["Gateway:dateDebug"].ToLowerInvariant(), "dd/MM/yyyy", CultureInfo.CurrentUICulture),
                   e => logger.LogError("Do not convert trading date"));
            }
            receivePathBackup = $"BACKUP{lastDate:dd}";
            return canStart;
            // observe on received folder

            //var mapPath = Path.Combine(prsReceivePath, "Datapath.MAP");
            //Stream stream = await fileService.Read(mapPath, true);
            //stream.Seek(stream.Length - 18, SeekOrigin.Begin);
            //var reader = new StreamReader(stream);
            //var buffer = new char[18];
            //reader.Read(buffer, 0, 10);
            //var receiveDateTrading = new string(buffer, 0, 10);
            //reader.Read(buffer, 0, 8);
            //receivePathBackup = new string(buffer, 0, 8);
            //stream.Close();
            //Executor.Try(
            //       () => lastDate = DateTime.ParseExact(receiveDateTrading, "dd/MM/yyyy", CultureInfo.CurrentUICulture),
            //       e => logger.LogError("Do not convert trading date"));

            //if (lastDate.DayOfYear != DateTime.Today.DayOfYear && !IsDebug)
            //{
            //    logger.LogError("Do not data for day: [{0:dd/MM/yyyy}]!", DateTime.Today);
            //    logger.LogInformation("If you want to test, please change [is Debug] = true appsetting and run again!!!");
            //    canStart = false;
            //}
            // return canStart;
        }

        public override DateTime ProcessDate => lastDate;

        public async Task Start(CancellationToken token)
        {
            if (!CanStart())
            {
                logger.LogWarning("Wait to process day!!!");
                return;
            }


            //Run Prs
            fileService.EnsurePath("../message/PRS");
            var backupPath = Path.Combine(prsReceivePath, receivePathBackup);
            await observationService.Start(backupPath, ProcessFile, token, true, lastDate);
            logger.LogInformation("Finished lookup to {0} AND KEEP OBSERVING on this.", backupPath);

            //Run Index
            fileService.EnsurePath("../message/Index");
            await observationService.Start(indexReceivePath, ProcessFile, token, true, lastDate);
            logger.LogInformation("Finished lookup to {0} AND KEEP OBSERVING on this.", indexReceivePath);
        }

        public bool Stop()
        {
            logger.LogInformation("Stop observering ...");
            return observationService.Stop();
        }

        public async Task<bool> ProcessFile(string fileFullName, byte[] stream)
        {
            return await Executor.TryAsync(async
                        () => await ProcessMessage(stream, fileFullName),
                        e => logger.LogError("Convert message [{0}] - Error [{1}]", fileFullName, e.Message));

        }
    }
}
