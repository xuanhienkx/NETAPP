using AutoMapper;
using DO.Common.Contract;
using DO.Common.Domain.Interfaces;
using DO.Common.Std;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace DO.Common;

[Authorize]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMapper Mapper;
    protected readonly IStringLocalizer Localizer;
    protected readonly IDomainDataHandler DomainDataHandler;
    protected readonly ILogger<ApiControllerBase> Logger;

    protected ApiControllerBase(IDomainDataHandler domainDataHandler, ILogger<ApiControllerBase> logger, IStringLocalizer localizer, IMapper mapper)
    {
        this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        this.DomainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
        this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected bool CheckModelStateValidation()
    {
        if (ModelState.IsValid)
            return true;

        var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
            .Select(x => x.Exception == null ? x.ErrorMessage : x.Exception.Message)
            .ToList();

        errorMessages.ForEach(NotifyError);

        return !errorMessages.Any();
    }

    protected bool CheckModelStateValidation<T>(T contract) where T : DataContract
    {
        if (contract == null)
        {
            NotifyError(Localizer["DataContractIsNull"]);
            return false;
        }

        List<string> errorMessages;
        if (!ModelState.IsValid)
        {
            errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                .Select(x => x.Exception == null ? x.ErrorMessage : x.Exception.Message)
                .ToList();
            errorMessages.ForEach(NotifyError);

            // log all content for debugging
            using (var r = new StreamReader(Request.Body))
                Logger.LogError(r.ReadToEnd());

            return false;
        }

        errorMessages = contract.Validate();
        errorMessages.ForEach(NotifyError);

        return !errorMessages.Any();
    }

    protected IActionResult Result<T>(T model = default(T))
    {
        Logger.LogDebug($"Return result: {model} - {typeof(T)}");

        if (DomainDataHandler.HasError(out var errorMessages))
        {
            return BadRequest(new RequestResult<T>(model, false)
            {
                ErrorMessages = errorMessages
            });
        }
        return Ok(new RequestResult<T>(model, true));
    }

    protected IActionResult Result<T>(Func<T> action, bool strartDbTransaction = true)
    {
        var requestPath = ControllerContext.HttpContext.Request.GetDisplayUrl();
        if (strartDbTransaction)
            DomainDataHandler.StartTransaction(requestPath).Wait();
        try
        {
            var result = action();

            // commit transaction
            DomainDataHandler.Commit(requestPath);

            return result == null ? Result<T>() : Result(result);
        }
        catch (Exception ex)
        {
            DomainDataHandler.Rollback(requestPath);
            NotifyError(ex.Message);
            Logger.LogError($"{ex}");

            return Result<T>();
        }
    }

    protected async Task<IActionResult> ResultAsync<T>(Func<Task<T>> action, bool strartDbTransaction = true)
    {
        var requestPath = ControllerContext.HttpContext.Request.GetDisplayUrl();
        if (strartDbTransaction)
            await DomainDataHandler.StartTransaction(requestPath);

        try
        {
            var result = await action();

            // commit transaction
            DomainDataHandler.Commit(requestPath);

            return result == null ? Result<T>() : Result(result);
        }
        catch (Exception ex)
        {
            DomainDataHandler.Rollback(requestPath);
            NotifyError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            Logger.LogError($"{ex}");

            return Result<T>();
        }
    }

    protected void NotifyError(string message)
    {
        DomainDataHandler.RaiseError(message);
    }

    protected void NotifyError(Func<IStringLocalizer, string> message)
    {
        DomainDataHandler.RaiseError(message(Localizer));
    }

    protected async void NotifyAuditEvent(IEventSource eventSource, Guid? loginUserId = null)
    {
        await DomainDataHandler.SendCommand(new AuditEventCommand(eventSource));
    }

    protected async void NotifyAuditEvent<T>(Func<bool> auditCondition, object model, Action<T> eventSource, Guid? loginUserId = null)
        where T : IEventSource
    {
        if (auditCondition() == false)
            return;

        var auditEntity = Mapper.Map<T>(model);
        eventSource.Invoke(auditEntity);

        await DomainDataHandler.SendCommand(new AuditEventCommand(auditEntity));
    }
}