using api.common;
using api.common.Models;
using api.common.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using api.common.Shared;
using api.common.Shared.Interfaces;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain.Services
{
    public class IdentityService :
        IUserRoleStore<IdentityUser>,
        IUserLoginStore<IdentityUser>,
        IUserClaimStore<IdentityUser>,
        IUserPasswordStore<IdentityUser>,
        IUserSecurityStampStore<IdentityUser>,
        //IUserTwoFactorStore<IdentityUser>,
        IUserEmailStore<IdentityUser>,
        IUserLockoutStore<IdentityUser>,
        IUserPhoneNumberStore<IdentityUser>,
        IQueryableUserStore<IdentityUser>,
        IUserAuthenticatorKeyStore<IdentityUser>,
        IUserTwoFactorRecoveryCodeStore<IdentityUser>,
        IUserAuthenticationTokenStore<IdentityUser>,
        IUserTwoFactorTokenProvider<IdentityUser>
    {
        private readonly IMongoCollection<IdentityUser> usersCollection;

        /// <summary>
        /// Gets a queryable list of users.
        /// </summary>
        public IQueryable<IdentityUser> Users => usersCollection.AsQueryable();

        public IdentityService(IPersistentService<DomainPersistentService> persistentService, ILogger<IdentityService> logger)
        {
            if (persistentService == null) throw new ArgumentNullException(nameof(persistentService));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            usersCollection = persistentService.GetCollection<IdentityUser>();
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await usersCollection.InsertOneAsync(user, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.Delete();

            var query = Builders<IdentityUser>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<IdentityUser>.Update.Set(u => u.DeletedDate, user.DeletedDate);

            await usersCollection.UpdateOneAsync(query, update, cancellationToken: cancellationToken);

            return IdentityResult.Success;
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var query = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(u => u.Id, userId),
                Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null)
            );

            return usersCollection.Find(query).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var query = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(u => u.NormalizedUserName, normalizedUserName),
                Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null)
            );

            return usersCollection.Find(query).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.SetNormalizedUserName(normalizedName);

            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("Changing the username is not supported.");
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var query = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(u => u.Id, user.Id),
                Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null)
            );

            var replaceResult = await usersCollection.ReplaceOneAsync(query, user, new ReplaceOptions {IsUpsert = false}, cancellationToken);

            return replaceResult.IsModifiedCountAvailable && replaceResult.ModifiedCount == 1
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            // ensure login info is unique
            if (!user.Logins.Any(x => x.Equals(login)))
            {
                user.AddLogin(new IdentityUserLogin(login));
            }

            return Task.FromResult(0);
        }

        public Task RemoveLoginAsync(IdentityUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var login = new UserLoginInfo(loginProvider, providerKey, string.Empty);
            var loginToRemove = user.Logins.FirstOrDefault(x => x.Equals(login));

            if (loginToRemove != null)
            {
                user.RemoveLogin(loginToRemove);
            }

            return Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var logins = user.Logins.Select(login =>
                new UserLoginInfo(login.LoginProvider, login.ProviderKey, login.ProviderDisplayName));

            return Task.FromResult<IList<UserLoginInfo>>(logins.ToList());
        }

        public Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var notDeletedQuery = Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null);
            var loginQuery = Builders<IdentityUser>.Filter.ElemMatch(usr => usr.Logins,
                Builders<IdentityUserLogin>.Filter.And(
                    Builders<IdentityUserLogin>.Filter.Eq(lg => lg.LoginProvider, loginProvider),
                    Builders<IdentityUserLogin>.Filter.Eq(lg => lg.ProviderKey, providerKey)
                )
            );

            var query = Builders<IdentityUser>.Filter.And(notDeletedQuery, loginQuery);

            return usersCollection.Find(query).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var claims = user.Claims.Select(clm => new Claim(clm.ClaimType, clm.ClaimValue)).ToList();

            return Task.FromResult<IList<Claim>>(claims);
        }

        public Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (var claim in claims)
            {
                user.AddClaim(claim);
            }

            return Task.FromResult(0);
        }

        public Task ReplaceClaimAsync(IdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            user.RemoveClaim(new IdentityUserClaim(claim));
            user.AddClaim(newClaim);

            return Task.FromResult(0);
        }

        public Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (var claim in claims)
            {
                user.RemoveClaim(new IdentityUserClaim(claim));
            }

            return Task.FromResult(0);
        }

        public async Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            var notDeletedQuery = Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null);
            var claimQuery = Builders<IdentityUser>.Filter.ElemMatch(usr => usr.Claims,
                Builders<IdentityUserClaim>.Filter.And(
                    Builders<IdentityUserClaim>.Filter.Eq(c => c.ClaimType, claim.Type),
                    Builders<IdentityUserClaim>.Filter.Eq(c => c.ClaimValue, claim.Value)
                )
            );

            var query = Builders<IdentityUser>.Filter.And(notDeletedQuery, claimQuery);
            var users = await usersCollection.Find(query).ToListAsync(cancellationToken).ConfigureAwait(false);

            return users;
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.SetPasswordHash(passwordHash);

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetSecurityStampAsync(IdentityUser user, string stamp, CancellationToken cancellationToken)
        {
            user.SetSecurityStamp(stamp);

            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        //public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
        //{
        //    if (enabled)
        //    {
        //        user.EnableTwoFactorAuthentication();
        //    }
        //    else
        //    {
        //        user.DisableTwoFactorAuthentication();
        //    }

        //    return Task.FromResult(0);
        //}

        //public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
        //{
        //    return Task.FromResult(user.IsTwoFactorEnabled);
        //}

        public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            user.SetEmail(email);

            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var email = user.Email?.Value;

            return Task.FromResult(email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user.Email == null)
            {
                throw new InvalidOperationException("Cannot get the confirmation status of the e-mail since the user doesn't have an e-mail.");
            }

            return Task.FromResult(user.Email.IsConfirmed());
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            if (user.Email == null)
            {
                throw new InvalidOperationException("Cannot set the confirmation status of the e-mail because user doesn't have an e-mail.");
            }

            if (confirmed)
            {
                user.Email.SetConfirmed();
            }
            else
            {
                user.Email.SetUnconfirmed();
            }

            return Task.FromResult(0);
        }

        public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var query = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(u => u.Email.NormalizedValue, normalizedEmail),
                Builders<IdentityUser>.Filter.Eq(u => u.DeletedDate, null)
            );

            return usersCollection.Find(query).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var normalizedEmail = user != null && user.Email != null ? user.Email.NormalizedValue : null;

            return Task.FromResult(normalizedEmail);
        }

        public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            // This method can be called even if user doesn't have an e-mail.
            // Act cool in this case and gracefully handle.
            // More info: https://github.com/aspnet/Identity/issues/645

            if (normalizedEmail != null && user.Email != null)
            {
                user.Email.SetNormalizedEmail(normalizedEmail);
            }

            return Task.FromResult(0);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var lockoutEndDate = user.LockoutEndDate != null
                ? new DateTimeOffset(user.LockoutEndDate.Instant)
                : default(DateTimeOffset?);

            return Task.FromResult(lockoutEndDate);
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            if (lockoutEnd != null)
            {
                user.LockUntil(lockoutEnd.Value.UtcDateTime);
            }

            return Task.FromResult(0);
        }

        public async Task<int> IncrementAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var filter = Builders<IdentityUser>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<IdentityUser>.Update.Inc(usr => usr.AccessFailedCount, 1);
            var findOneAndUpdateOptions = new FindOneAndUpdateOptions<IdentityUser, int>
            {
                ReturnDocument = ReturnDocument.After,
                Projection = Builders<IdentityUser>.Projection.Expression(usr => usr.AccessFailedCount)
            };

            var newCount = await usersCollection
                .FindOneAndUpdateAsync(filter, update, findOneAndUpdateOptions)
                .ConfigureAwait(false);

            user.SetAccessFailedCount(newCount);

            return newCount;
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            user.ResetAccessFailedCount();

            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.IsLockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
        {
            if (enabled)
            {
                user.EnableLockout();
            }
            else
            {
                user.DisableLockout();
            }

            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.SetPhoneNumber(phoneNumber);

            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber?.Value);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user.PhoneNumber == null)
            {
                throw new InvalidOperationException("Cannot get the confirmation status of the phone number since the user doesn't have a phone number.");
            }

            return Task.FromResult(user.PhoneNumber.IsConfirmed());
        }

        public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            if (user.PhoneNumber == null)
            {
                throw new InvalidOperationException("Cannot set the confirmation status of the phone number since the user doesn't have a phone number.");
            }

            user.PhoneNumber.SetConfirmed();

            return Task.FromResult(0);
        }

        public void Dispose()
        {
            
        }

        public Task SetAuthenticatorKeyAsync(IdentityUser user, string key, CancellationToken cancellationToken)
        {
            return SetTokenAsync(user, ProviderConstants.LoginProvider, ProviderConstants.AuthenticatorKeyTokenName, key, cancellationToken);
        }

        public Task<string> GetAuthenticatorKeyAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return GetTokenAsync(user, ProviderConstants.LoginProvider, ProviderConstants.AuthenticatorKeyTokenName, cancellationToken);
        }

        public Task ReplaceCodesAsync(IdentityUser user, IEnumerable<string> recoveryCodes, CancellationToken cancellationToken)
        {
            var mergedCodes = string.Join(";", recoveryCodes);
            return SetTokenAsync(user, ProviderConstants.LoginProvider, ProviderConstants.RecoveryCodeTokenName, mergedCodes, cancellationToken);
        }

        public Task<bool> RedeemCodeAsync(IdentityUser user, string code, CancellationToken cancellationToken)
        {
            var mergedCodes = GetTokenAsync(user, ProviderConstants.LoginProvider, ProviderConstants.RecoveryCodeTokenName, cancellationToken).Result;
            var splitCodes = (mergedCodes ?? "").Split(';');
            if (splitCodes.Contains(code))
            {
                var updatedCodes = new List<string>(splitCodes.Where(s => s != code));
                ReplaceCodesAsync(user, updatedCodes, cancellationToken);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<int> CountCodesAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var mergedCodes = GetTokenAsync(user, ProviderConstants.LoginProvider, ProviderConstants.RecoveryCodeTokenName, cancellationToken).Result ?? "";
            if (mergedCodes.Length > 0)
            {
                return Task.FromResult(mergedCodes.Split(';').Length);
            }
            return Task.FromResult(0);
        }

        public Task SetTokenAsync(IdentityUser user, string loginProvider, string name, string value, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var tokenEntity =
                user.Tokens.SingleOrDefault(
                    l =>
                        l.TokenName == name && l.LoginProvider == loginProvider);
            if (tokenEntity != null)
            {
                tokenEntity.TokenValue = value;
            }
            else
            {
                user.AddToken(new IdentityUserToken
                {

                    LoginProvider = loginProvider,
                    TokenName = name,
                    TokenValue = value
                });
            }
            return Task.FromResult(0);
        }

        public Task RemoveTokenAsync(IdentityUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var tokenEntity =
               user.Tokens.SingleOrDefault(
                   l =>
                       l.TokenName == name && l.LoginProvider == loginProvider);
            if (tokenEntity != null)
            {
                user.RemoveToken(tokenEntity);
            }
            return Task.FromResult(0);
        }

        public Task<string> GetTokenAsync(IdentityUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var tokenEntity =
               user.Tokens.SingleOrDefault(
                   l =>
                       l.TokenName == name && l.LoginProvider == loginProvider);
            return Task.FromResult(tokenEntity?.TokenValue);
        }

        public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var claims = new List<Claim> { new Claim(JwtTokenIssuer.UserRoleClaimType, roleName) };
            return AddClaimsAsync(user, claims, cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var claims = user.Claims.Where(x => x.ClaimType == JwtTokenIssuer.UserRoleClaimType).Select(x => x.ClaimValue);
            return Task.FromResult<IList<string>>(claims.ToList());
        }

        public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var roleClaim = new Claim(JwtTokenIssuer.UserRoleClaimType, roleName);
            return GetUsersForClaimAsync(roleClaim, cancellationToken);
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var result = user.Claims.Any(x => x.ClaimType == JwtTokenIssuer.UserRoleClaimType && x.ClaimValue == roleName);
            return Task.FromResult(result);
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var current = new Claim(JwtTokenIssuer.UserRoleClaimType, roleName);
            var newClaim = new Claim(JwtTokenIssuer.UserRoleClaimType, AccountRole.USER.ToString());
            return ReplaceClaimAsync(user, current, newClaim, cancellationToken);
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            return Task.FromResult(true);
        }

        public  Task<string> GenerateAsync(string purpose, UserManager<IdentityUser> manager, IdentityUser user)
        {
            return Task.FromResult("1234");
        }

        public  Task<bool> ValidateAsync(string purpose, string token, UserManager<IdentityUser> manager, IdentityUser user)
        {
            return Task.FromResult(token == "1234");
        }
    }
}
