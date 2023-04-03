using System;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Std;
using CS.UI.Common.Interfaces;
using Serilog;

namespace CS.UI.Common
{
    public class MessageNotificator : INotificator
    {
        private const string ProxyName = "notificationHub";
        private readonly ILogger logger;
        private ProxyClient<NotificationMessage> proxy;

        public MessageNotificator(ILogger logger)
        {
            this.logger = logger?? throw new ArgumentNullException(nameof(logger));
        }

        public event Action<NotificationMessage> RecievedMessageEvent;
        public event Action<Exception> ConnectionClosedEvent;

        public async Task Start()
        {
            logger.Information("Start connection to hub");

            proxy = new ProxyClient<NotificationMessage>();
            proxy.OnReceivedMessageEvent += message => RecievedMessageEvent?.Invoke(message);
            proxy.OnConnectedEvent += () => logger.Information($"Connected to {ProxyName}");
            proxy.OnDisconnectedEvent += e =>
            {
                logger.Information($"Disconnected to {ProxyName}: {e.Message}");
                ConnectionClosedEvent?.Invoke(e);
            };

            await proxy.StartHub(ProxyName);
        }

        public async Task Stop()
        {
            logger.Information("Stop connection to hub");
            if (proxy != null)
            {
                await proxy.StopHub();
                proxy?.Dispose();
                proxy = null;
            }
        }
    }
}