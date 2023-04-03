using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Enums;

namespace CS.Common.MessageQueue
{
    public interface IMessagePublisher
    {
        bool CanPublish(MessageQueueType messageType);

        Task<bool> Publish<T>(Message<T> message, Action<Message<T>> onPublished, Action<Message<T>, Exception> onFailed);
    }
}
