using api.common;
using api.common.Events;
using api.common.Shared;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace api.Utils
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context, IMediator mediator, IWebHostEnvironment env /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (AccessViolationException ave)
            {
                // publish error event
                await mediator.Publish(new ClientSessionEvent(context.Request.Path, SessionState.Error));
                await ErrorHandle(ave, context, HttpStatusCode.Forbidden, env.IsProduction());
            }
            catch (AuthenticationException ae)
            {
                // publish error event
                await mediator.Publish(new ClientSessionEvent(context.Request.Path, SessionState.Error));
                await ErrorHandle(ae, context, HttpStatusCode.Unauthorized, env.IsProduction());
            }
            catch (SecurityTokenValidationException ste)
            {
                // publish error event
                await mediator.Publish(new ClientSessionEvent(context.Request.Path, SessionState.Error));
                await ErrorHandle(ste, context, HttpStatusCode.Unauthorized, env.IsProduction());
            }
            catch (MongoException mongo)
            {
                logger.LogError(mongo.Message);
                await ErrorHandle(mongo.GetBaseException(), context, HttpStatusCode.Unauthorized, env.IsProduction());
            }
            catch (Exception ex)
            {
                // publish error event
                await mediator.Publish(new ClientSessionEvent(context.Request.Path, SessionState.Error));
                await ErrorHandle(ex, context, HttpStatusCode.InternalServerError, env.IsProduction());
            }
        }

        private async Task ErrorHandle(Exception ex, HttpContext context, HttpStatusCode statusCode, bool isProduction)
        {
            logger.LogDebug("ErrorHandle Exception==>{0}", ex.ToString());
            logger.LogDebug($"{Environment.NewLine}ERROR HAPPEND: {context.Request.Path} {Environment.NewLine}");

            
            object returnResult;
            if (context.WebSockets.IsWebSocketRequest)
            {
                returnResult = new Message(string.Empty, ProviderConstants.InvalidToken);
                statusCode = HttpStatusCode.OK;
                logger.LogError(ex, ProviderConstants.InvalidToken);
            }
            else
            {
                var messages = ex.Detail();
                logger.LogError(ex, string.Join(Environment.NewLine, messages));
                returnResult = isProduction
                    ? new Result<ErrorHandlingMiddleware>(messages.First())
                    : new Result<ErrorHandlingMiddleware>(messages);
            }

            var errorDetail = JsonConvert.SerializeObject(returnResult, settings: new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            });

            // always return OK although error happens
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json; charset=utf-8";

            await context.Response.WriteAsync(errorDetail);
            await context.Response.CompleteAsync();
        }
    }
}
