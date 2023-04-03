using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Permissions")]
    public class Permission : IdentityEntityBase, ICommonEntity<long>
    {
        public Guid GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }
        public Guid? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } 
        public AccessRight Name { get; set; } 
        public AccessType Type { get; set; }  
    }
}