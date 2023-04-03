using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Domain.Audit.Entities;

namespace CS.Domain.Audit.Repositories
{
    public interface IAuditEventRepository
    {
        Task AuditEventSource(EventSource eventSource, IEventSource commandEventSource);
        Task AuditHistory(IHistorySource commandHistorySource);
    }
}
