using System;
using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.UI.Common.Interfaces
{
    public interface INotificator
    {
        event Action<NotificationMessage> RecievedMessageEvent;
        event Action<Exception> ConnectionClosedEvent;
        Task Start();
        Task Stop();
    }
}
