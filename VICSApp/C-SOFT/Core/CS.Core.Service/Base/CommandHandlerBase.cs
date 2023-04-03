using System;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CS.Core.Service.Base
{
    public abstract class CommandHandlerBase
    {
        protected readonly IDomainDataHandler DomainDataHandler;
        protected readonly IHttpContextAccessor ContextAccessor;
        protected readonly IMapper Mapper;

        protected CommandHandlerBase(
            IDomainDataHandler domainDataHandler,
            IHttpContextAccessor context,
            IMapper mapper)
        {
            this.DomainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.ContextAccessor = context ?? throw new ArgumentNullException(nameof(context));
            this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected async void NotifyAuditEvent<T>(Func<bool> auditCondition, object model, Action<T> eventSource)
            where T : IEventSource
        {
            if (auditCondition() == false)
                return;

            var auditEntity = Mapper.Map<T>(model);
            eventSource.Invoke(auditEntity);

            await DomainDataHandler.SendCommand(new AuditEventCommand(auditEntity));
        }

        protected async Task<T> ProcessAsync<T, TAudit>(Func<Task<T>> action, Action<TAudit> audit)
            where TAudit : IEventSource
        {
            var result = await action.Invoke();
            NotifyAuditEvent(() => result != null, result, audit);
            return result == null ? default(T) : result;
        }
    }
}