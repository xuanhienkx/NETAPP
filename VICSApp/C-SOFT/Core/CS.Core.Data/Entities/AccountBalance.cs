using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Data.Entities
{
    [Table("AccountBalance")]
    public class AccountBalance : IdentityEntityBase
    {
        public long AccountId { get; set; }
        public Guid CustomerAccountId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Available { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Balance { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Block { get; set; }
        public DateTime LastBalancedDate { get; set; }
        public int Version { get; set; }   

        public virtual ICollection<AccountBlockTransaction> AccountBlockTransactions { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(CustomerAccountId))]
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}
