using System;
using System.Threading.Tasks;
using CS.Common.Contract;
using Microsoft.AspNetCore.SignalR;

namespace CS.Common.Domain.Interfaces
{
    public interface INotificationPublisher
    {
        Task Register(Action<NotificationContext> config);
        Task Register(Guid userId, Action<NotificationContext> config);

        Task Broadcast(NotificationMessage message);
        Task Unicast(string clientId, NotificationMessage message);
        Task Unicast(Guid userId, NotificationMessage message);
        Task Send(NotificationMessage message, Func<NotificationContext, bool> condition = null);

        Task ClientConnected(HubCallerContext context);
        Task ClientDisconnected(HubCallerContext context);
    }
}