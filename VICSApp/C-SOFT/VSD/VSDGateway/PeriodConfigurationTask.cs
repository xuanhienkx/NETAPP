using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CS.Common;
using CS.Common.Interfaces;
using CS.Common.Std;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VSDGateway
{
    //public class PeriodConfigurationTask : ITargetTask
    //{
    //    private readonly IConfigurationRoot configuration;
    //    private readonly ILogger<PeriodConfigurationTask> logger;
    //    private readonly IObservable<DateTime> timeObservable;

    //    public PeriodConfigurationTask(IConfigurationRoot configuration, ILogger<PeriodConfigurationTask> logger)
    //    {
    //        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    //        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

    //        timeObservable = Observable.Timer
    //    }

    //    public int Priority { get; } = 0;
    //    public string Name { get; } = "Setup configuration environment";

    //    public Task Start(CancellationToken token)
    //    {
    //        // setup the api token for service
    //        var apiToken = SecurityHelper.GenerateServiceToken(configuration.GetSection("api:security"));
    //        logger.LogDebug("Service token created: {0}", apiToken);
    //        ApiProvider.Instance.SetToken(apiToken);

    //    }

    //    public bool Stop()
    //    {
    //        // do nothing
    //        return true;
    //    }

        
    //}
}
