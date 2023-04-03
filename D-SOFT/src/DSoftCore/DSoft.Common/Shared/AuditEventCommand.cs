using DSoft.Common.Shared.Interfaces;
using MediatR;

namespace DSoft.Common.Shared;

public class AuditEventCommand : IRequest
{
    public IEventSource EventSource { get; }
    public DateTime CreatedDate { get; }

    public AuditEventCommand(IEventSource eventSource)
    {
        EventSource = eventSource;
        CreatedDate = DateTime.UtcNow;
    }
}
public class AuditHistoryCommand : IRequest
{
    public IHistorySource HistorySource { get; }

    public AuditHistoryCommand(IHistorySource historySource)
    {
        HistorySource = historySource;
    }
}
