using api.common.Events;
using api.common.Shared.Interfaces;
using api.domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using api.common.Settings;

namespace api.domain.Handlers
{

    public class ClientSessionHandler : INotificationHandler<ClientSessionEvent>
    {
        private readonly IPersistentService<DomainPersistentService> persistentService;
        private readonly ApplicationSettings settings;

        public ClientSessionHandler(IPersistentService<DomainPersistentService> persistentService, ApplicationSettings settings)
        {
            this.persistentService = persistentService ?? throw new ArgumentNullException(nameof(persistentService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task Handle(ClientSessionEvent notification, CancellationToken cancellationToken)
        {
            if (!settings.UseMongoReplset)
                return Task.CompletedTask;
            
            switch (notification.State)
            {
                case SessionState.Start:
                    return persistentService.StartSession(notification.RequestPath);
                case SessionState.End:
                    return persistentService.Commit(notification.RequestPath);
                case SessionState.Error:
                    return persistentService.Rollback(notification.RequestPath);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
