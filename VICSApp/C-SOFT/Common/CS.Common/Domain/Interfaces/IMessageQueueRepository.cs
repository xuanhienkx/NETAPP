using System;
using CS.Common.MessageQueue;

namespace CS.Common.Domain.Interfaces
{
    public interface IMessageQueueRepository
    {
        Guid Insert<T>(Message<T> message);
        void Delete(Guid messageQueueId);
    }
}
