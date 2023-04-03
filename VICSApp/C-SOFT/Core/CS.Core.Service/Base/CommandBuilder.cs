using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using MediatR;
using System;

namespace CS.Core.Service.Base
{
    public abstract class CommandBuilder<TKey, T>  : IDataCommandBuilder<TKey, T>
        where T : IResource<TKey>
    {
        private readonly ICSoftDataContext dataContext;

        protected CommandBuilder(ICSoftDataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public abstract IRequest<T> BuildInsert(T model);
        public abstract IRequest<T> BuildUpdate(T model);
        public abstract IRequest<bool> BuildDelete(TKey id);

        public IRequest<TResult> BuildCommand<TResult>(Func<ICSoftDataContext, IRequest<TResult>> command)
        {
            return command?.Invoke(dataContext);
        }
    }
}
