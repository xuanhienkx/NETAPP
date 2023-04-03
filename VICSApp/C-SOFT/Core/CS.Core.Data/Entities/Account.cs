using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Accounts")]
    public class Account : IdentityEntityBase, IReversionEntity<long>
    {
        public long AssetId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public AccountStatus Status { get; set; }
        public AccountType Type { get; set; }
        public int Version { get; set; }

        public virtual ICollection<AccountBalance> AccountBalances { get; set; }
        public virtual ICollection<BusinessAccountSetting> Settlements { get; set; }
        [ForeignKey(nameof(AssetId))]
        public virtual Asset Asset { get; set; }
    }
}
