using DO.Common.Interfaces;
using DO.Common.Std;
using DSoft.InforGateway.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DSoft.InforGateway;

public class GatewayFactory
{
    private readonly IEnumerable<ITargetTask> tasks;
    private readonly IConfigurationRoot configuration;
    private readonly ILogger<GatewayFactory> logger;
    private readonly ITokenService tokenService;
    private CancellationTokenSource cancellationTokenSource;

    public GatewayFactory(IEnumerable<ITargetTask> tasks, IConfigurationRoot configuration, ILogger<GatewayFactory> logger, ITokenService tokenService)
    {
        this.tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }
    public async Task Start()
    {
        logger.LogInformation("Start application...");

        // start up api provider

        var baseUrl = configuration["CoreApi:baseUri"].TrimEnd('/');
        var version = configuration["CoreApi:version"].Trim('/');
        version = string.IsNullOrEmpty(version) ? version : $"/{version}";

        ApiProvider.Initialize(
            $"{baseUrl}/api{version}/",
            long.Parse(configuration["CoreApi:bufferSize"]),
            double.Parse(configuration["CoreApi:timeoutInSecond"]),
            configuration["CoreApi:contentType"],
            null);

        // setup the api token for service
        var apiToken = await tokenService.GetToken("DSoftAPI.write");
        if (apiToken.IsError)
        {
            logger.LogError($"Not get token: {apiToken.Error}- {apiToken.ErrorDescription}");
        }
        logger.LogDebug("Service token created: {0}", apiToken.AccessToken);
        ApiProvider.Instance.SetToken(apiToken.AccessToken);

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

