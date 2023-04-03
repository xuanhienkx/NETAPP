using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Groups")]
    public class Group : UniqueIdentityEntityBase, ICommonEntity<Guid>, IBranchBaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Group Parent { get; set; }

        public long BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

        public ICollection<UserGroup> Users { get; set; }
    }
}
