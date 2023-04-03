using DSoft.Common.Shared.Interfaces;
using DSoft.InforGateway.Services;
using Microsoft.Extensions.Logging;

namespace DSoft.InforGateway;

public class GatewayFactory
{
    private readonly ITargetTask task;
    private readonly ILogger<GatewayFactory> logger;     
    private CancellationTokenSource cancellationTokenSource;

    public GatewayFactory(
       ITargetTask task,
        ILogger<GatewayFactory> logger )
    {
        this.task = task ?? throw new ArgumentNullException(nameof(task));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));                     
    }
    public async Task Start()
    {
        logger.LogInformation("Start application...");    
        // start up api provider      
        cancellationTokenSource = new CancellationTokenSource();
        var token = cancellationTokenSource.Token;
        logger.LogInformation($"STARTING {task.Name}");
        await task.Start(token);
        logger.LogInformation($"{task.Name} STARTED");
    }
    public void Stop(Action stopComplete)
    {
        logger.LogInformation($"Stopping application...");

        cancellationTokenSource.Cancel();

        if (task.Stop())
            logger.LogInformation($"{task.Name} STOPPED{Environment.NewLine}");

        // cleanup the api token
        //  ApiProvider.Instance.SetToken(null);

        cancellationTokenSource.Dispose();
        cancellationTokenSource = null;
        stopComplete?.Invoke();
    }
}

