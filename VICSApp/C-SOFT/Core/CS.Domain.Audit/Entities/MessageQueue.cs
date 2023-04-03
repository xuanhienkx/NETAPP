using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CS.Common.Domain;
using CS.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CS.Domain.Audit.Entities
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
