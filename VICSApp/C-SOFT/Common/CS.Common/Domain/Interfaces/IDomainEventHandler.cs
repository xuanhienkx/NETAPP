using System.Collections.Generic;

namespace CS.Common.Domain.Interfaces
{
    public interface IDomainEventHandler<T>
    {
        void Raise(T message, string notifierKey = null);
        IEnumerable<T> GetAll();
    }
}