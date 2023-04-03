using api.common.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using api.common;

#pragma warning disable 1591

namespace api.Utils
{
    public class IdentityUserReadyMiddleware
    {
        private readonly RequestDelegate next;

        public IdentityUserReadyMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context, ICurrentUser currentUser)
        {
            if (context.User.Identity.IsAuthenticated 
                && currentUser.User == null 
                && !context.WebSockets.IsWebSocketRequest 
                && !context.Request.Path.StartsWithSegments(new PathString(ProviderConstants.WebSocketSegment)))
            {
                await currentUser.EnsureIdentityUser();
                if (currentUser.User == null)
                    throw new AuthenticationException();
            }

            await next(context);
        }
    }
}
