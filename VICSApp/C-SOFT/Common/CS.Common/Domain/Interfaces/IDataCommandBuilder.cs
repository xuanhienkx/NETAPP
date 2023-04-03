using System;
using CS.Common.Contract;
using MediatR;

namespace CS.Common.Domain.Interfaces
{
    public interface IDataCommandBuilder<in TKey, T> where T : IResource<TKey>
    {
        IRequest<T> BuildInsert(T model);
        IRequest<T> BuildUpdate(T model);       
        IRequest<bool> BuildDelete(TKey id);
        IRequest<TResult> BuildCommand<TResult>(Func<ICSoftDataContext, IRequest<TResult>> command);
    }
}
