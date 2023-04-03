using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    public abstract class IdentityEntityBase : IIdentityEntity<long>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }

    public abstract class UniqueIdentityEntityBase : IIdentityEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }
}
