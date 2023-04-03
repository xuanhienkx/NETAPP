using System;
using Microsoft.AspNetCore.Identity;

namespace CS.Domain.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid();
        }

        public ApplicationRole(string roleName) 
            : base(roleName)
        {
            Id = Guid.NewGuid();
        }

        //public virtual ICollection<IdentityRoleClaim<Guid>> Claims { get; set; }
    }
}
