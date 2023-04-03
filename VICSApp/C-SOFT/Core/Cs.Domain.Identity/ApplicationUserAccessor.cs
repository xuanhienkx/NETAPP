using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CS.Domain.Identity
{
    public class ApplicationUserAccessor : IApplicationUserAccessor
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor context;
        public ApplicationUserAccessor(UserManager<ApplicationUser> userManager, IHttpContextAccessor context)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IApplicationUser> GetUser()
        {
            return await userManager.GetUserAsync(context.HttpContext.User);
        }

        public Guid? GetUserId()
        {
            return context.HttpContext.User.GetUserId();
        }
    }
                                               
}
