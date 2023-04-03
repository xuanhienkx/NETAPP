using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;

namespace CS.Domain.Data.Entities
{
    [Table("AccountTransaction")]
    public class AccountTransaction : UniqueIdentityEntityBase
    {
        public long AcountBalanceId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }
        public Guid? ApproveById { get; set; }
        public Guid? CreatedById { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
        public long? SourceId { get; set; }
        public AccountTransactionStatus Status { get; set; }
        public DateTime TransactionDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string ReferenceCode { get; set; }

        [ForeignKey(nameof(AcountBalanceId))]
        public virtual AccountBalance AcountBalance { get; set; }
        [ForeignKey(nameof(ApproveById))]
        public virtual User ApproveBy { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(SourceId))]
        public virtual Source Source { get; set; }
    }
}
