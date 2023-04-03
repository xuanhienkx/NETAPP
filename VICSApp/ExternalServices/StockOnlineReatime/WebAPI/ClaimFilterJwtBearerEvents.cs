using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Api.Data.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class ClaimFilterJwtBearerEvents : JwtBearerEvents
    {
        public ClaimFilterJwtBearerEvents(string tokenKey, IConfigurationSection configuration)
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Query.TryGetValue("jwtToken", out var token)
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

