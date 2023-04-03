using DO.Common.Domain.Interfaces;
using DO.Common.Extensions;
using DO.Common.Std.Extensions;
using DO.Domain.Audit.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DO.Domain.Audit.Repositories
{
    public class AuditEventRepository : IAuditEventRepository
    {
        private readonly IConfigurationRoot config;
        private readonly ILogger<AuditEventRepository> logger;

        public AuditEventRepository(IConfigurationRoot config, ILogger<AuditEventRepository> logger)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AuditEventSource(EventSource eventSource, IEventSource commandEventSource)
        {
            await Execute(async () =>
            {
                using (var context = new AuditDbContext(config))
                {
                    context.Database.AutoTransactionsEnabled = true;

                    await context.Set<EventSource>().AddAsync(eventSource);
                    await context.SaveChangesAsync();

                    commandEventSource.Id = eventSource.Id;
                    await context.Set<IEventSource>().AddAsync(commandEventSource);
                    await context.SaveChangesAsync();
                }
            });
        }

        public async Task AuditHistory(IHistorySource commandHistorySource)
        {
            await Execute(async () =>
            {
                using (var context = new AuditDbContext(config))
                {
                    await context.Set<IHistorySource>().AddAsync(commandHistorySource);
                    await context.SaveChangesAsync();
                }
            });
        }

        private async Task Execute(Func<Task> action)
        {
            await Executor.TryAsync(action, exception =>
            {
                logger.LogError(exception, "AuditLog");
            });
            await action.CircuitBreakerExecuteAsync(opt =>
            {
                opt.BreakerOpened = e => logger.LogWarning("Attempt: {0}. {1}", opt.Attempt, e.Message);
                opt.BreakerTimeout = e => logger.LogWarning("Attempt: {0}. {1}", opt.Attempt, e.Message);
                opt.UnkownException = e =>
                {
                    logger.LogWarning("Attempt: {0}. {1}", opt.Attempt, e.Message);
                    logger.LogError(e.InnerException, "InnerException");
                };
            });
        }
    }
}
