using DSoft.Common.Domain.Services;
using DSoft.Common.Events;
using DSoft.Common.Settings;
using DSoft.Common.Shared.Interfaces;
using MediatR;

namespace DSoft.Common.Domain.Handlers
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
