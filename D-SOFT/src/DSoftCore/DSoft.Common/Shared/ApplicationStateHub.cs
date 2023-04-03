using DSoft.Common.Extensions;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace DSoft.Common.Shared;

public class ApplicationStateHub : Hub
{
    private readonly IPersistentDataProvider dataProvider;
    private readonly ILogger<ApplicationStateHub> logger;
    private readonly IHttpContextAccessor httpContextAccessor;

    public ApplicationStateHub(IPersistentDataProvider dataProvider, ILogger<ApplicationStateHub> logger, IHttpContextAccessor httpContextAccessor)
    {
        this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public override async Task OnConnectedAsync()
    {
        var connectionId = this.Context.ConnectionId;

        logger.LogDebug($"HUB: connected >>>>>>>>{connectionId}<<<<<<<<");

        if (httpContextAccessor.IsAuthenticated())
        {
            if (!dataProvider.TryGet(httpContextAccessor.GetUserId(), out Message message))
                message = new Message(connectionId);
            else
                message.Id = connectionId;
            dataProvider.Set(httpContextAccessor.GetUserId(), message);
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
        dataProvider.TryUpdate<Message>(httpContextAccessor.GetUserId(), (x) =>
        {
            x.Id = string.Empty;
            return x;
        });
        return Task.CompletedTask;
    }
}