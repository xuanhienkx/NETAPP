using BO.Core.DataCommon.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BO.Core.DataCommon.Shared
{
    public class ApplicationStateHub : Hub
    {
        private readonly ICurrentUser currentUser;
        private readonly IPersistentDataProvider dataProvider;
        private readonly ILogger<ApplicationStateHub> logger;

        public ApplicationStateHub(IPersistentDataProvider dataProvider, ILogger<ApplicationStateHub> logger)
        {
            currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            logger.LogDebug($"HUB: connected >>>>>>>>{connectionId}<<<<<<<<");

            if (currentUser.IsAuthenticated)
            {
                if (!dataProvider.TryGet(currentUser.UserId, out Message message))
                    message = new Message(connectionId);
                else
                    message.Id = connectionId;
                dataProvider.Set(currentUser.UserId, message);
            }
            else
            {
                logger.LogDebug("[{connectionId}] <-- user does not login", connectionId);
                await Clients.Client(connectionId).SendAsync("login", new Message(connectionId, ProviderConstants.ForceLogOut));
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            logger.LogDebug(">>>>>>>>HUB: disconnected");
            dataProvider.TryUpdate<Message>(currentUser.UserId, (x) =>
            {
                x.Id = string.Empty;
                return x;
            });
            return Task.CompletedTask;
        }
    }
}
