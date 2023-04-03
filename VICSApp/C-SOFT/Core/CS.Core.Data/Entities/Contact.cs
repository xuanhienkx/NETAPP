using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Contacts")]
    public class Contact : IdentityEntityBase, ICommonEntity<long>
    {
        public Guid CustomerId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
        public ContactType Type { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
