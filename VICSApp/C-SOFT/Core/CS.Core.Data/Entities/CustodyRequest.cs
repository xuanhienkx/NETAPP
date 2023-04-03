using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("CustodyRequests")]
    public class CustodyRequest : IdentityEntityBase, ICommonEntity<long>
    {
        [MaxLength(125)]
        public string BusinessId { get; set; }
        public CustodyRequestStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Content { get; set; }
        public string ContentClrType { get; set; }
        public string Notes { get; set; }
        public MessagePriority Priority { get; set; }
        [MaxLength(8)]
        public string VsdBicCode { get; set; }
        public CustodyRequestType RequestType { get; set; } 
        public string Description { get; set; }
    }
}
