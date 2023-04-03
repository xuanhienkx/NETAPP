using AutoMapper;
using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Std.Extensions;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using CS.Domain.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Std;

namespace CS.CoreApi.Controllers
{
    [Route("security")]
    public class SecurityController : ApiControllerBase
    {
        private readonly IDataFactory dataFactory;
        private readonly IDistributedCache cache;
        private readonly UserManager<ApplicationUser> identityManager;
        private readonly IConfigurationRoot configuration;
        public SecurityController(
            IDataFactory dataFactory,
            UserManager<ApplicationUser> identityManager,
            IConfigurationRoot configuration,
            ILogger<SecurityController> logger,
            IDomainDataHandler domainDataHandler,
            IStringLocalizer<SecurityController> localizer,
            RoleManager<ApplicationRole> identityrRoleManager,
            IMapper mapper,
            IDistributedCache cache)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.dataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.identityManager = identityManager ?? throw new ArgumentNullException(nameof(identityManager));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> PostLogin([FromBody] CredentialLoginModel credentialLogin)
        {
            if (!CheckModelStateValidation(credentialLogin))
                return Result(string.Empty);

            // audit loggin request
            NotifyAuditEvent(CreateLoginRequest(LoginType.LoginRequest, credentialLogin.Username));

            if (string.IsNullOrEmpty(credentialLogin.Username) || string.IsNullOrEmpty(credentialLogin.Password))
            {
                NotifyError(localizer => localizer["Security_IdentityCannotFind"]);
                return Result(string.Empty);
            }

            return await ResultAsync(async () =>
            {
                var identity = await identityManager.FindByNameAsync(credentialLogin.Username);
                if (identity == null)
                {
                    NotifyError(localizer => localizer["Security_IdentityCannotFind"]);
                }
                else
                {
                    var passwordVerification = identityManager.PasswordHasher.VerifyHashedPassword(identity, identity.PasswordHash, credentialLogin.Password);
                    if (passwordVerification != PasswordVerificationResult.Success)
                    {
                        NotifyError(localizer => localizer["Security_IdentityCannotFind"]);
                    }
                    else
                    {
                        var identityClaims = await identityManager.GetClaimsAsync(identity);

                        identityClaims.Add(new Claim(JwtRegisteredClaimNames.GivenName, identity.UserName));
                        identityClaims.Add(new Claim(JwtRegisteredClaimNames.Sid, identity.Id.ToString()));

                        // generate the claim
                        var token = SecurityHelper.CreateToken(identityClaims, HttpContext.Connection, configuration.GetSection("security"));
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                        // audit login success
                        NotifyAuditEvent(CreateLoginRequest(LoginType.LoginSuccess, tokenString), identity.Id);

                        return tokenString;
                    }
                }
                // audit login failed
                NotifyAuditEvent(CreateLoginRequest(LoginType.LoginFailed, credentialLogin.Username));

                return string.Empty;
            });
        }

        [HttpGet("logout")]
        [AllowAnonymous]
        public async void Logout()
        {
            await cache.RemoveAsync(User.GetUserId().ToString());
            NotifyAuditEvent(CreateLoginRequest(LoginType.Logout, User.Identity.Name));
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostCreateLogin([FromBody] CredentialRegisterModel model)
        {
            if (!CheckModelStateValidation(model))
                return Result(false);
            return await ResultAsync(async () => await CreateOrUpdateLogin(model));
        }

        [HttpPut("reset")]
        public async Task<IActionResult> PutResetLogin([FromBody] ChangePasswordModel model)
        {
            if (!CheckModelStateValidation(model))
                return Result(model);

            var user = await identityManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                NotifyError(localizer => localizer["User_CannotFind"]);
                return Result(model);
            }

            var code = await identityManager.GeneratePasswordResetTokenAsync(user);
            await identityManager.ResetPasswordAsync(user, code, model.Password);
            await identityManager.SetLockoutEnabledAsync(user, model.IsLockout);

            return Result(model);
        }


        [HttpGet("login")]
        public async Task<IActionResult> GetLogin()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                NotifyError(localizer => localizer["Security_IdentityCannotFind"]);
                return Result<UserModel>();
            }

            var userQuery = dataFactory.CreateQuery<Guid, UserModel, User>(x => x.Branch, x => x.Department, x => x.Groups);
            var user = await userQuery.GetAsync(userId.Value);
            if (user == null)
            {
                NotifyError(localizer => localizer["Security_IdentityCannotFind"]);
                return Result(string.Empty);
            }

            if (!User.IsInRole(UserRoleType.Admin) && user.Groups != null)
            {
                var groupIds = user.Groups.Select(x => x.Id).ToList();
                if (groupIds.Any())
                {
                    user.Rights = await DomainDataHandler.SendCommand(new GetPermissionAccessCommand(groupIds));
                    await cache.SetAsync(user.Id.ToString(), user.ProtoBufSerialize());
                }
            }

            return Result(user);
        }

        private static LoginRequest CreateLoginRequest(LoginType loginType, string content)
        {
            return new LoginRequest()
            {
                Type = loginType,
                Content = content
            };
        }

        private async Task<bool> CreateOrUpdateLogin(CredentialRegisterModel model, bool isNew = true)
        {
            var user = new ApplicationUser()
            {
                Id = model.UserId,
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = isNew
                ? await identityManager.CreateAsync(user, model.Password)
                : await identityManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (!isNew)
                    await identityManager.RemoveFromRoleAsync(user, ClaimTypes.Role);
                result = await identityManager.AddToRoleAsync(user, ClaimTypes.Role);
            }

            if (result.Succeeded)
            {
                var claim = new Claim(ClaimTypes.Role, model.Role.ToString());
                if (!isNew)
                    await identityManager.RemoveClaimAsync(user, claim);
                result = await identityManager.AddClaimAsync(user, claim);
            }

            if (result.Succeeded)
            {
                if (!isNew)
                    await identityManager.RemovePasswordAsync(user);
                result = await identityManager.AddPasswordAsync(user, model.Password);
            }

            if (!result.Succeeded)
                NotifyError(string.Join(". ", result.Errors.Select(x => $"{x.Code}: {x.Description}")));

            return result.Succeeded;
        }
    }
}
