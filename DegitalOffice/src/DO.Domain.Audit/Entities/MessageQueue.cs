using DO.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO.Domain.Audit.Entities
{
    [Table("MessageQueues")]
    public class MessageQueue : EventBase
    {
        public MessageQueueType Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string ClrType { get; set; }
        public string Content { get; set; }
    }
}
