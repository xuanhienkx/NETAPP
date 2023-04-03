using BO.Core.DataCommon.Events;
using BO.Core.DataCommon.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

#pragma warning disable 1591

namespace BO.Core.DataCommon.Shared.Base
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILocalizer Localizer;
        protected readonly IHttpContextAccessor HttpAccessor;
        protected readonly IMediator Mediator;
        protected readonly ILogger<BaseController> Logger;

        protected BaseController(IMediator mediator, IHttpContextAccessor httpAccessor, ILocalizer localizer, ILogger<BaseController> logger)
        {
            Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            HttpAccessor = httpAccessor ?? throw new ArgumentNullException(nameof(httpAccessor));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected string Text(string key)
        {
            return Localizer.Get(key);
        }

        protected IActionResult Value<T>(T model = default)
        {
            return Ok(new Result<T>(model));
        }

        protected IActionResult Error(string messageKey)
        {
            return Ok(Result.Error(Text(messageKey)));
        }

        protected Task<IActionResult> ErrorAsync(string messageKey)
        {
            return Task.FromResult(Error(messageKey));
        }

        protected async Task<IActionResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        protected async Task<IActionResult> CommandAsync<TResult>(BaseCommand<TResult> command)
        {
            Logger.LogDebug("CommandAsync: {command}", command);

            await Mediator.Publish(new ClientSessionEvent(HttpAccessor.HttpContext.Request.Path, SessionState.Start));

            var result = await Mediator.Send(command);

            await Mediator.Publish(new ClientSessionEvent(HttpAccessor.HttpContext.Request.Path, SessionState.End));

            return Ok(result);
        }

        //protected void EnsureInRole(AccountRole role)
        //{
        //    if (!HttpAccessor.HttpContext.User.IsInRole(role.ToString()))
        //        throw new AccessViolationException($"Required {role}");
        //}

        //protected void EnsureNotInRole(AccountRole role)
        //{
        //    if (HttpAccessor.HttpContext.User.IsInRole(role.ToString()))
        //        throw new AccessViolationException($"Required not in role {role}");
        //}

        //protected bool IsInRole(params AccountRole[] roles)
        //{
        //    if (roles == null || roles.Length == 0)
        //        return true;

        //    return roles.Any(r => HttpAccessor.HttpContext.User.IsInRole(r.ToString()));
        //}
    }
}