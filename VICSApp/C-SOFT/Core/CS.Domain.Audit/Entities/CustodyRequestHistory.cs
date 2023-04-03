using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Audit.Entities
{
    [Table("CustodyRequestHistory")]
    public class CustodyRequestHistory : IHistorySource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(125)]
        public string BusinessId { get; set; }
        public CustodyRequestStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Content { get; set; }
        public string ContentClrType { get; set; }
        public string Notes { get; set; }
        public byte Priority { get; set; }
        public CustodyRequestType RequestType { get; set; } 
        public string Description { get; set; }

    }
}
