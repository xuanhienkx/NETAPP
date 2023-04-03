using DO.Common.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DO.Common.Domain
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class NotificationHub : Hub
    {
        private readonly INotificationPublisher notificationPublisher;
        public const string ProxyName = "notificationHub";

        public NotificationHub(INotificationPublisher notificationPublisher)
        {
            this.notificationPublisher = notificationPublisher ?? throw new ArgumentNullException(nameof(notificationPublisher));
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            notificationPublisher.ClientDisconnected(Context);
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            notificationPublisher.ClientConnected(Context);
            return base.OnConnectedAsync();
        }
    }
}
