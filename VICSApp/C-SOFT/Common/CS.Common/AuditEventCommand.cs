using System;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CS.Common
{
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
}