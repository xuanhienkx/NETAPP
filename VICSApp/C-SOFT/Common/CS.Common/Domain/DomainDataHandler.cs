using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace CS.Common.Domain
{
    public class DomainDataHandler : IDomainDataHandler, IDisposable
    {
        private readonly ILogger<DomainDataHandler> logger;
        private readonly IHttpContextAccessor httpContext;
        private readonly ICacheService cacheService;
        private readonly IMediator mediator;
        private readonly IDomainEventHandler<NotificationMessage> domainEventNotificator;
        private readonly ICSoftDataContext dataContext;

        private IDbContextTransaction transaction;

        public DomainDataHandler(
            ICSoftDataContext dataContext,
            IMediator mediator,
            IDomainEventHandler<NotificationMessage> domainEventNotificator,
            ICacheService cacheService,
            IHttpContextAccessor httpContext,
            ILogger<DomainDataHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.domainEventNotificator = domainEventNotificator ?? throw new ArgumentNullException(nameof(domainEventNotificator));
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task StartTransaction(string requestPath)
        {
            await Executor.TryAsync(
                async () => transaction = await dataContext.StartTransaction(),
                exception => logger.LogError(exception, "START TRANSACTION"), 
                true);
            logger.LogInformation($"START TRANSACTION [{transaction.TransactionId}] - {requestPath}");
        }

        public void Commit(string requestPath)
        {
            if (transaction == null)
                return;

            logger.LogInformation($"COMMIT TRANSACTION [{transaction.TransactionId}] - {requestPath}");
            Executor.Try(() =>
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }, e =>
            {
                logger.LogError(e, "Error");
            });
            
        }

        public void Rollback(string requestPath)
        {
            if (transaction == null)
                return;

            logger.LogInformation($"ROLLBACK TRANSACTION [{transaction.TransactionId}] - {requestPath}");
            
            Executor.Try(() =>
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }, e =>
            {
                logger.LogError(e, "Error");
            });
        }

        public void RaiseError(string errorMessage, string notifierKey = null)
        {
            domainEventNotificator.Raise(new NotificationMessage
            {
                Type = NotificationType.Error,
                Content = errorMessage
            }, notifierKey);
        }

        public bool HasError(out IList<string> errorMessages)
        {
            errorMessages = domainEventNotificator.GetAll()
                .Where(x => x.Type == NotificationType.Error)
                .Select(x => x.Content).ToList();
            return errorMessages.Any();
        }

        public async Task<T> SendCommand<T>(IRequest<T> command)
        {
            return await mediator.Send(command);
        }

        public async Task SendCommand(IRequest command)
        {
            await mediator.Send(command);
        }

        public async Task PublishCommand(INotification command)
        {
            await mediator.Publish(command);
        }

        public UserModel GetUserLogin()
        {
            var userId = httpContext.HttpContext.User.GetUserId();
            if (userId == null)
                return null;
            return cacheService.Get<Guid, UserModel>(userId.Value);
        }

        public void SendNotification(string message)
        {
            domainEventNotificator.Raise(new NotificationMessage
            {
                Type = NotificationType.Inform,
                Content = message
            });
        }

        public void Broadcast(string message)
        {
            domainEventNotificator.Raise(new NotificationMessage
            {
                Type = NotificationType.Inform,
                Content = message
            });
        }

        public void Dispose()
        {
            transaction?.Dispose();
            dataContext?.Dispose();
        }
    }
}
