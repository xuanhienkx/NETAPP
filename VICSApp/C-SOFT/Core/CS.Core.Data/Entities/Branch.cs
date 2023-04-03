using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Branches")]
    public class Branch : IdentityEntityBase, ICommonEntity<long>
    {
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]
        public string BranchCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string BranchName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Fax { get; set; }
        public long? ParentId { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Tel { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Branch> Children { get; set; }
        public virtual ICollection<BranchSetting> Settings { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Branch Parent { get; set; }
    }
}
