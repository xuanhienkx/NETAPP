using CS.Common;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.SwiftParser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CS.Common.Std.Extensions;

namespace VSDGateway
{
    public class DirectoryObserverTask : ITargetTask
    {
        private readonly IFileService fileService;
        private readonly IDirectoryObservationService observationService;
        private readonly IGatewayService gatewayService;
        private readonly IConfigurationRoot settings;
        private readonly IMessageBuilder messageBuilder;
        private readonly ILogger<DirectoryObserverTask> logger;

        private string failArchivePath;
        private string archivePath;
        private string receivePath;

        public DirectoryObserverTask(
            IConfigurationRoot settings,
            IDirectoryObservationService observationService,
            IGatewayService gatewayService,
            IMessageBuilder messageBuilder,
            IFileService fileService,
            ILogger<DirectoryObserverTask> logger)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.observationService = observationService ?? throw new ArgumentNullException(nameof(observationService));
            this.gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.messageBuilder = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int Priority => 10;
        public string Name => "Observing file ....";

        public async Task Start(CancellationToken token)
        {
            receivePath = settings["vsd:receivePath"].ToLowerInvariant();
            archivePath = settings["gateway:archivePath"].ToLowerInvariant();
            failArchivePath = settings["gateway:errorPath"].ToLowerInvariant();

            // lookup all error file from last process
            fileService.EnsurePath(failArchivePath);
            await observationService.Start(failArchivePath, ProcessFile, token, false);
            logger.LogInformation($"Finished lookup to {failArchivePath} AND NOT OBSERVE on this.");

            // observe on received folder
            fileService.EnsurePath(receivePath);
            await observationService.Start(receivePath, ProcessFile, token, true);
            logger.LogInformation($"Finished lookup to {receivePath} AND KEEP OBSERVING on this.");
        }

        public bool Stop()
        {
            logger.LogInformation("Stop observering ...");
            return observationService.Stop();
        }

        private async Task<bool> ProcessFile(string fileName, Stream fileStream)
        {
            logger.LogInformation("------- START TO READ FILE: [{0}] -------", fileName);
            var bag = await messageBuilder.Read<SwiftBag>(fileName, fileStream);

            var result = bag != null;
            if (result)
            {
                // process the bag
                logger.LogInformation("Processing the message {0}, id: {1}", bag.MessageType, bag.MessageId);
                result = await gatewayService.Process(bag);
            }

            // archive the file
            await Executor.TryAsync(
                () => HandleFileProcess(fileName, result),
                exception =>
                {
                    logger.LogError(exception, $"Archive file {fileName}");
                    if (result) fileService.Delete(fileName);
                });

            logger.LogInformation("------- FINISH PROCESS FILE [{0}]: {1} ------- ", fileName, result);
            return result;
        }

        private async Task HandleFileProcess(string file, bool isArchived)
        {
            if (!isArchived && file.StartsWith(failArchivePath))
                return;

            var archiveFolder = isArchived ? archivePath : failArchivePath;
            // move to archive the message file
            await fileService.Move(file, archiveFolder);

            // if the par file, there is also a csv, move it arccordingly
            if (file.EndsWith(".par"))
            {
                var fileName = file.Replace(".par", ".csv");
                await fileService.Move(fileName, archiveFolder);
            }
        }
    }
}
