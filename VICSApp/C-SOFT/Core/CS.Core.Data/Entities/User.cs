using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Users")]
    public class User : UniqueIdentityEntityBase, IReversionEntity<Guid>, IBranchBaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
        public byte Level { get; set; }
        public long? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
        
        public long BranchId { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Version { get; set; }
        [MaxLength(2)]
        public string LanguageCode { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(ModifiedByUserId))]
        public virtual User ModifiedBy { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string AccountLogin { get; set; }
        public UserType UserType { get; set; }

        public ICollection<UserGroup> Groups { get; set; }
    }
}
