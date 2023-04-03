using DO.Common.Contract;
using DO.Common.Domain.Interfaces;

namespace DO.Common.Domain;

public class DomainEventNotificationHandler : IDomainEventHandler<NotificationMessage>
{
    private readonly INotificationPublisher publisher;
    private readonly IList<NotificationMessage> notifications = new List<NotificationMessage>();
    private readonly object lockObj = new object();

    public DomainEventNotificationHandler(INotificationPublisher publisher)
    {
        this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public void Raise(NotificationMessage message, string notifierKey = null)
    {

        lock (lockObj)
        {
            notifications.Add(message);

            if (string.IsNullOrEmpty(notifierKey))
                publisher.Send(message);
            else
                publisher.Send(message, context => context.Data.ContainsKey(notifierKey));
        }
    }

    public IEnumerable<NotificationMessage> GetAll()
    {
        lock (lockObj)
        {
            return notifications;
        }
    }
}