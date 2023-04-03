using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("CustomerAccounts")]
    public class CustomerAccount : UniqueIdentityEntityBase, ICommonEntity<Guid>
    {
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Code { get; set; }
        public Guid CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        public Guid CreatedByBrockerId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ContractNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiredDate { get; set; }
        public bool IsActive { get; set; }
        public BusinessType Type { get; set; }

        [ForeignKey(nameof(CreatedByBrockerId))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
