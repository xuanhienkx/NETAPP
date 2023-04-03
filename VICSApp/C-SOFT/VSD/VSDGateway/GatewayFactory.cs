using CS.Common;
using CS.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CS.Common.Std;

namespace VSDGateway
{
    public class GatewayFactory
    {
        private readonly IEnumerable<ITargetTask> tasks;
        private readonly IConfigurationRoot configuration;
        private readonly ILogger<GatewayFactory> logger;

        private CancellationTokenSource cancellationTokenSource;

        public GatewayFactory(IEnumerable<ITargetTask> tasks, IConfigurationRoot configuration, ILogger<GatewayFactory> logger)
        {
            this.tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Start()
        {
            logger.LogInformation("Start application...");

            // start up api provider

            var baseUrl = configuration["api:baseUri"].TrimEnd('/');
            var version = configuration["api:version"].Trim('/');
            version = string.IsNullOrEmpty(version) ? version : $"/{version}";

            ApiProvider.Initialize(
                $"{baseUrl}/api{version}/",
                long.Parse(configuration["api:bufferSize"]),
                double.Parse(configuration["api:timeoutInSecond"]),
                configuration["api:contentType"],
                null);

            // setup the api token for service
            var apiToken = SecurityHelper.GenerateServiceToken(configuration.GetSection("api:security"));
            logger.LogDebug("Service token created: {0}", apiToken);
            ApiProvider.Instance.SetToken(apiToken);

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            foreach (var task in tasks.OrderBy(t => t.Priority))
            {
                logger.LogInformation($"STARTING {task.Name}...{Environment.NewLine}");
                await task.Start(token);
                logger.LogInformation($"{task.Name} STARTED{Environment.NewLine}");
            }
        }

        public void Stop(Action stopComplete)
        {
            logger.LogInformation($"Stopping application...");

            cancellationTokenSource.Cancel();
            
            foreach (var task in tasks)
            {
                if (task.Stop())
                    logger.LogInformation($"{task.Name} STOPPED{Environment.NewLine}");
            }

            // cleanup the api token
            ApiProvider.Instance.SetToken(null);

            cancellationTokenSource.Dispose();
            cancellationTokenSource = null;
            stopComplete?.Invoke();
        }
    }
}
