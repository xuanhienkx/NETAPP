using System;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CS.Domain.Identity.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
    {
    }
}
