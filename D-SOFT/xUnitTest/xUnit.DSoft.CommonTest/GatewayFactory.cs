using DSoft.Common.Shared.Interfaces;
using Microsoft.Extensions.Logging;

namespace xUnit.DSoft.CommonTest;

public class GatewayFactory
{
    private readonly IEnumerable<ITargetTask> tasks;
    private readonly ILogger<GatewayFactory> logger;
    private CancellationTokenSource cancellationTokenSource;

    public GatewayFactory(
        IEnumerable<ITargetTask> tasks,
        ILogger<GatewayFactory> logger)
    {
        this.tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task Start()
    {
        logger.LogInformation("Start application...");

        // start up api provider      
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
        //  ApiProvider.Instance.SetToken(null);

        cancellationTokenSource.Dispose();
        cancellationTokenSource = null;
        stopComplete?.Invoke();
    }
}

