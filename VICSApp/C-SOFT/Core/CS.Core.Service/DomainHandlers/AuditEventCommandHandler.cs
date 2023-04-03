using System;
using System.Threading;
using System.Threading.Tasks;
using CS.Common;
using CS.Domain.Audit.Entities;
using CS.Domain.Audit.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CS.Core.Service.DomainHandlers
{
    public class AuditEventCommandHandler : IRequestHandler<AuditEventCommand>,
                                            IRequestHandler<AuditHistoryCommand>
    {
        private readonly ILogger<AuditEventCommandHandler> logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuditEventRepository repository;

        public AuditEventCommandHandler(IAuditEventRepository repository, IHttpContextAccessor httpContextAccessor, ILogger<AuditEventCommandHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// This method will take a rarely process to insert the event source using circuit breaker
        /// Then and async/await is used. This is nowhere else similary
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        public async Task Handle(AuditEventCommand command, CancellationToken cancellationToken)
        {
            logger.LogDebug("Handle audit command {0} - {1}", command, command.EventSource);

            var context = httpContextAccessor.HttpContext;              
            var eventSource = new EventSource()
            {
                UserLoginId = context.User.GetUserId(),
                CreatedDate = command.CreatedDate,
                Path = context.Request.Path.Value,
                DeviceId = context.Request.Headers["User-Agent"].ToString(),   
                RequestSource = context.Connection.RemoteIpAddress.ToString()
            };

            await repository.AuditEventSource(eventSource, command.EventSource);
        }


        public async Task Handle(AuditHistoryCommand command, CancellationToken cancellationToken)
        {
            logger.LogDebug("Handle audit command {0} - {1}", command, command.HistorySource);
            await repository.AuditHistory(command.HistorySource);
        }
    }
}
