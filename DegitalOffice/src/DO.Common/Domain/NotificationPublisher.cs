using DO.Common.Contract;
using DO.Common.Domain.Interfaces;
using DO.Common.Interfaces;
using DO.Common.Std.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace DO.Common.Domain
{
    public class NotificationPublisher : INotificationPublisher
    {
        private readonly ICacheService cacheService;
        private readonly ILogger<NotificationPublisher> logger;
        private readonly IHttpContextAccessor httpContext;
        private readonly IHubContext<NotificationHub> hubContext;

        private const string NotificationCacheKey = "notificationPublisher";

        public NotificationPublisher(
            IHubContext<NotificationHub> hubContext,
            IHttpContextAccessor httpContext,
            ILogger<NotificationPublisher> logger,
            ICacheService cacheService)
        {
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task Register(Action<NotificationContext> config)
        {
            var userId = httpContext.HttpContext.User.GetUserId();
            if (userId.HasValue)
                await Register(userId.Value, config);
        }

        public async Task Register(Guid userId, Action<NotificationContext> config)
        {
            var clients = await cacheService.Get<IList<NotificationContext>>(NotificationCacheKey, new List<NotificationContext>());
            var item = clients.SingleOrDefault(x => x.UserId == userId);
            if (item == null)
            {
                logger.LogDebug($"Register does not reach since connection for user {userId} does not exist");
                return;
            }

            config?.Invoke(item);
            await cacheService.Update(NotificationCacheKey, clients);
        }

        public async Task Broadcast(NotificationMessage message)
        {
            await hubContext.Clients.All.SendAsync("Broadcast", message);
            logger.LogDebug($"Broadcast: {message} to all");
        }

        public async Task Unicast(Guid userId, NotificationMessage message)
        {
            await hubContext.Clients.User(userId.ToString()).SendAsync("Unicast", message);
            logger.LogDebug($"Unicast: {message} to user {userId.ToString()}");
        }

        public async Task Unicast(string clientId, NotificationMessage message)
        {
            await hubContext.Clients.Client(clientId).SendAsync("Unicast", message);
            logger.LogDebug($"Unicast: {message} to connection {clientId}");
        }

        public async Task Send(NotificationMessage message, Func<NotificationContext, bool> condition = null)
        {
            var clients = await cacheService.Get<IList<NotificationContext>>(NotificationCacheKey, new List<NotificationContext>());
            if (clients == null)
                return;

            // send to other with condition
            if (condition != null)
            {
                foreach (var ctx in clients.Where(condition))
                {
                    if (message.Type.IsIn(NotificationType.Content, NotificationType.Drilldown))
                        message.RequestId = ctx.RequestedId;
                    await Unicast(ctx.UserId, message);
                }
            }
            else
            {
                // send to current user
                var userId = httpContext.HttpContext.User.GetUserId();
                if (userId.HasValue)
                {
                    var context = clients.SingleOrDefault(x => x.UserId == userId);
                    if (context != null)
                        await Unicast(context.UserId, message);
                }
            }

        }

        public async Task ClientConnected(HubCallerContext context)
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
                return;

            var clients = await cacheService.Get<IList<NotificationContext>>(NotificationCacheKey, new List<NotificationContext>());
            var ctx = clients.SingleOrDefault(x => x.ConnectionId == context.ConnectionId);
            if (ctx != null)
            {
                ctx.UserId = userId.Value;
                logger.LogInformation($"[<->] {ctx.UserId} reconnected at connection {context.ConnectionId}");
            }
            else
            {
                ctx = clients.SingleOrDefault(x => x.UserId == userId);
                if (ctx != null)
                {
                    ctx.ConnectionId = context.ConnectionId;
                    logger.LogInformation($"[<->] {ctx.UserId} reconnected at connection {context.ConnectionId}");
                }
                else
                {
                    clients.Add(new NotificationContext(userId.Value, context.ConnectionId));
                    logger.LogInformation($"[<+>] {userId} connected");
                }
            }

            if (clients.Any())
                await cacheService.Update(NotificationCacheKey, clients);
        }

        public async Task ClientDisconnected(HubCallerContext context)
        {
            var clients = await cacheService.Get<IList<NotificationContext>>(NotificationCacheKey, new List<NotificationContext>());
            var ctx = clients.SingleOrDefault(x => x.ConnectionId == context.ConnectionId);
            if (ctx != null)
            {
                clients.Remove(ctx);
                await cacheService.Update(NotificationCacheKey, clients);
                logger.LogInformation($"[<x>] {ctx.UserId} disconnected from connection {context.ConnectionId}.");
            }

            var userId = context.User.GetUserId();
            if (userId != null)
            {
                ctx = clients.SingleOrDefault(x => x.UserId == userId);
                if (ctx != null)
                {
                    clients.Remove(ctx);
                    await cacheService.Update(NotificationCacheKey, clients);
                    logger.LogInformation($"[<x>] {ctx.UserId} disconnected from connection {context.ConnectionId}.");
                }
            }
        }
    }
}