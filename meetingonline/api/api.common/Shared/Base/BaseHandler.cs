using api.common.Shared.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;

namespace api.common.Shared.Base
{
    public abstract class BaseHandler
    {
        protected readonly IMediator Mediator;
        protected readonly ILocalizer Localizer;
        protected BaseHandler(IMediator mediator, ILocalizer localizer)
        {
            this.Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        protected Result<TResponse> Result<TResponse>(TResponse response)
        {
            return new Result<TResponse>(response);
        }

        protected Result<TResponse> Error<TResponse>(string key = null)
        {
            return new Result<TResponse>(Text(key));
        }

        protected Result<TResponse> Error<TResponse>(IList<string> errors)
        {
            return new Result<TResponse>(errors);
        }

        protected string Text(string key)
        {
            return Localizer.Get(key);
        }
        protected string Text(string key, string[] errors)
        {
            return Localizer.Get(key, string.Join(". ", errors));
        }

        protected string Text(string key, params object[] arguments)
        {
            return Localizer.Get(key, arguments);
        }
    }
}
