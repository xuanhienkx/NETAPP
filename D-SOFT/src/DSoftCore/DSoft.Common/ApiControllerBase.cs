using DSoft.Common.Events;
using DSoft.Common.Shared;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DSoft.Common;

[Authorize]

public abstract class ApiControllerBase : ControllerBase
{
    protected readonly ILocalizer Localizer;
    protected readonly IHttpContextAccessor HttpAccessor;
    protected readonly IMediator Mediator;
    protected readonly ILogger<ApiControllerBase> Logger;

    protected ApiControllerBase(ILocalizer localizer,
        IHttpContextAccessor httpAccessor,
        IMediator mediator,
        ILogger<ApiControllerBase> logger)
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

}

