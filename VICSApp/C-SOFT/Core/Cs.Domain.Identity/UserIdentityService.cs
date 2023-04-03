using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;

namespace CS.Domain.Identity
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly ILogger<UserIdentityService> logger;
        private readonly UserManager<ApplicationUser> identityManager;
        private readonly RoleManager<ApplicationRole> identityrRoleManager;

        public UserIdentityService(UserManager<ApplicationUser> identityManager, RoleManager<ApplicationRole> identityrRoleManager, ILogger<UserIdentityService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.identityManager = identityManager ?? throw new ArgumentNullException(nameof(identityManager));
            this.identityrRoleManager = identityrRoleManager ?? throw new ArgumentNullException(nameof(identityrRoleManager));
        }

        public async Task<IApplicationUser> CreateUser(IUserLogin model, UserRoleType loginRole = UserRoleType.User, string password = null)
        {
            var user = new ApplicationUser()
            {
                Id = model.Id,
                UserName = model.AccountLogin,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                LockoutEnabled = !model.IsActive
            };
            if (string.IsNullOrEmpty(password))
                password = Guid.NewGuid().ToString("N").Substring(0, 6);
            var result = await identityManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var userResult = await identityManager.FindByIdAsync(model.Id.ToString());
                var role = await identityrRoleManager.FindByNameAsync(ClaimTypes.Role);
                if (role == null)
                {
                    role = new ApplicationRole(ClaimTypes.Role);
                    result = await identityrRoleManager.CreateAsync(role);
                    if (result.Succeeded)
                        await identityrRoleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, loginRole.ToString()));
                }
                else
                {
                    var claimRole = await identityrRoleManager.GetClaimsAsync(role);
                    if (!claimRole.Any(x => x.Type == ClaimTypes.Role && x.Value == loginRole.ToString()))
                        await identityrRoleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, loginRole.ToString()));
                }

                if (!await identityManager.IsInRoleAsync(userResult, ClaimTypes.Role))
                {
                    result = await identityManager.AddToRoleAsync(user, ClaimTypes.Role);
                    if (result.Succeeded)
                        result = await identityManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, loginRole.ToString()));
                }
                return userResult;
            }
            logger.LogError($"Create user on identity error: {string.Join("\n", result.Errors)}");
            return null;
        }

        public async Task<IApplicationUser> GetUserNameById(Guid id)
        {
            var user = await identityManager.FindByIdAsync(id.ToString());
            return user;
        }

        public async Task<bool> LockoutUser(Guid id, bool isBlock = true)
        {
            var user = await identityManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                logger.LogError($"Can not found user login with id {id}");
                return false;
            }
            var result = await identityManager.SetLockoutEnabledAsync(user, isBlock);
            if (!result.Succeeded)
            {
                logger.LogError($"Set lockout user on identity error: {string.Join("\n", result.Errors)}");
            }
            return result.Succeeded;
        }

        public async Task<bool> ResetPassword(Guid id, string password = null)
        {
            var user = await identityManager.FindByIdAsync(id.ToString());
            if (string.IsNullOrEmpty(password))
                password = Guid.NewGuid().ToString("N").Substring(0, 6);
            var result = await identityManager.ResetPasswordAsync(user, TokenOptions.DefaultAuthenticatorProvider, password);
            if (!result.Succeeded)
            {
                logger.LogError($"Block orUnBlock user on identity error: {string.Join("\n", result.Errors)}");
            }
            return result.Succeeded;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await identityManager.FindByIdAsync(id.ToString());
            var result = await identityManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}