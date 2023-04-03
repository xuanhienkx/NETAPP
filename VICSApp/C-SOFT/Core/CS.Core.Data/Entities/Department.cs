using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Departments")]
    public class Department : IdentityEntityBase, ICommonEntity<long>, IBranchBaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public long BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
    }
}
