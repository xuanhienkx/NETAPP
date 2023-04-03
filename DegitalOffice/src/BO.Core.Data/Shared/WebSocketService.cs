using BO.Core.DataCommon.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BO.Core.DataCommon.Shared
{
    public class WebSocketService : IWebSocketService
    {
        private readonly IHubContext<ApplicationStateHub> hubContext;
        private readonly IPersistentDataProvider dataProvider;

        public WebSocketService(IHubContext<ApplicationStateHub> hubContext, IPersistentDataProvider dataProvider)
        {
            this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public Task SendHangfire(string userId, string hfId, string message)
        {
            if (dataProvider.TryGet(userId, out Message m) && !string.IsNullOrEmpty(m.Id))
                return hubContext.Clients.Client(m.Id).SendAsync("hf", new Message(hfId, message));
            return Task.CompletedTask;
        }
    }
}
