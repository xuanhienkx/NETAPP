using System;
using CS.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace CS.CoreApi.Authorization
{
    public class ClaimFilterJwtBearerEvents : JwtBearerEvents
    {
        public ClaimFilterJwtBearerEvents(string tokenKey, IConfigurationSection configuration)
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Path.Value.StartsWith("/notificationHub")
                    && context.Request.Query.TryGetValue("jwtToken", out var token)
                )
                {
                    context.Token = token;
                }

                return Task.CompletedTask;
            };
            OnTokenValidated = context =>
            {
                var connection = context.HttpContext.Connection;

                if (SecurityHelper.ValidateNonceToken(context.Principal, connection, tokenKey, configuration))
                    return Task.CompletedTask;

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Fail(new AuthenticationException($"Invalid token: {context.SecurityToken} from {connection.RemoteIpAddress}"));

                return Task.CompletedTask;
            };
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            };
        }
    }
}
