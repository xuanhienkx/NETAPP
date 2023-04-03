using DO.Common.Domain.Interfaces;
using DO.Domain.Audit.Entities;

namespace DO.Domain.Audit.Repositories
{
    public interface IAuditEventRepository
    {
        Task AuditEventSource(EventSource eventSource, IEventSource commandEventSource);
        Task AuditHistory(IHistorySource commandHistorySource);
    }
}
