using DO.Common.Enums;

namespace DO.Common.MessageQueue;

public interface IMessagePublisher
{
    bool CanPublish(MessageQueueType messageType);

    Task<bool> Publish<T>(Message<T> message, Action<Message<T>> onPublished, Action<Message<T>, Exception> onFailed);
}