using DO.Common.Std.Extensions;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
namespace DO.Common.Std
{
    public class ProxyClient<T> : IDisposable
    {
        public HubConnection HubConnection { get; private set; }
        public event Action OnConnectedEvent;
        public event Action<Exception> OnDisconnectedEvent;
        public event Action<T> OnReceivedMessageEvent;

        public async Task StartHub(string proxyName)
        {
            var baseUri = ApiProvider.Instance.BaseUri;
            var url = new Uri($"{baseUri.Scheme}://{baseUri.Authority}/{proxyName}?jwtToken={ApiProvider.Instance.AuthenticationToken}");

            var builder = new HubConnectionBuilder()

                //  .WithHubProtocol(new MessagePackHubProtocol(SerializationContext.CreateClassicContext()))
                //  .WithConsoleLogger(LogLevel.Trace)  
                .WithUrl(url)
                .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(10) });

            HubConnection = builder.Build();
            HubConnection.On<T>("Broadcast", OnMessageReceived);
            HubConnection.On<T>("Unicast", OnMessageReceived);
            HubConnection.On<T>("Send", OnMessageReceived);
            HubConnection.Closed += HubConnectionOnClosedAsync;

            // HubConnection.State += HubConnectionOnConnected;

            await Executor.TryAsync(
                () => HubConnection.StartAsync(), Console.WriteLine);
        }

        public async Task StopHub()
        {
            if (HubConnection == null)
                return;

            HubConnection.Closed -= HubConnectionOnClosedAsync;
            //  HubConnection. -= HubConnectionOnConnected;
            await HubConnection.DisposeAsync();
        }

        public async void Dispose()
        {
            await StopHub();
        }

        private Task HubConnectionOnConnected()
        {
            OnConnectedEvent?.Invoke();
            return Task.CompletedTask;
        }

        private async Task HubConnectionOnClosedAsync(Exception exception)
        {
            OnDisconnectedEvent?.Invoke(exception);
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await Task.CompletedTask;
        }

        private void OnMessageReceived(T message)
        {
            OnReceivedMessageEvent?.Invoke(message);
        }
    }
}
