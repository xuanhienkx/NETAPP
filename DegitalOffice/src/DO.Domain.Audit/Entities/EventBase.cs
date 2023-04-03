using DO.Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO.Domain.Audit.Entities
{
    public abstract class EventBase : IEventSource
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey(nameof(Id))]
        public EventSource EventSource { get; set; }
    }
}
