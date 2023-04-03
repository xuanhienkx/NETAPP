using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract;
using CS.Common.Enums;

namespace CS.Domain.Data.Entities
{
    [Table("MessageQueues")]
    public class MessageQueue : UniqueIdentityEntityBase, IResource<Guid>
    { 
        public MessageQueueType Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string MessageBody { get; set; }
    }
}
