using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Sources")]
    public class Source : IdentityEntityBase, ICommonEntity<long>
    {
        [MaxLength(512)]
        public string Description { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public SourceType Type { get; set; }

        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
