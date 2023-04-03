using DO.Common.Enums;
using DO.Common.MessageQueue;

namespace DO.Core.Service;
public interface IMessagePublisherFactory
{
    Task<bool> Publish<T>(Message<T> message, IList<MessageQueueType> messageInformTypes);
}
public class MessagePublisherFactory : IMessagePublisherFactory
{
    public Task<bool> Publish<T>(Message<T> message, IList<MessageQueueType> messageInformTypes)
    {
        throw new NotImplementedException();
    }
}