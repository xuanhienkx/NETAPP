using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Data.Entities
{
    [Table("AccountBlockTransaction")]
    public class AccountBlockTransaction : IdentityEntityBase
    {
        public long AccountBlanceId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string Note { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ReferenceCode { get; set; }

        [ForeignKey(nameof(AccountBlanceId))]
        public virtual AccountBalance AccountBlance { get; set; }
    }
}
