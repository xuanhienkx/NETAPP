using DSoft.Common.Shared;
using DSoft.Common.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace DSoft.Common.Models.Identity
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public class IdentityUser : Account, IPersistentEntity
    {
        private List<IdentityUserToken> tokens;
        private List<IdentityUserClaim> claims;
        private List<IdentityUserLogin> logins;

        public IdentityUser(string email, string displayName) : base(email)
        {
            EnsureClaimsIsSet();
            EnsureLoginsIsSet();
            EnsureTokensIsSet();

            if (email != null)
            {
                Email = new IdentityUserEmail(email);
            }

            DisplayName = displayName;
        }

        [JsonIgnore]
        public string NormalizedUserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }
        public bool IsTwoFactorEnabled { get; private set; }
        public bool IsLockoutEnabled { get; protected set; }
        public Occurrence LockoutEndDate { get; protected set; }

        public Occurrence LockedDate { get; protected set; }
        public Occurrence DeletedDate { get; protected set; }

        public IEnumerable<IdentityUserClaim> Claims
        {
            get
            {
                EnsureClaimsIsSet();
                return claims;
            }

            // ReSharper disable once UnusedMember.Local, MongoDB serialization needs private setters
            private set
            {
                EnsureClaimsIsSet();
                if (value != null)
                {
                    claims.AddRange(value);
                }
            }
        }
        public IEnumerable<IdentityUserToken> Tokens
        {
            get
            {
                EnsureTokensIsSet();
                return tokens;
            }

            // ReSharper disable once UnusedMember.Local, MongoDB serialization needs private setters
            private set
            {
                EnsureTokensIsSet();
                if (value != null)
                {
                    tokens.AddRange(value);
                }
            }
        }
        public IEnumerable<IdentityUserLogin> Logins
        {
            get
            {
                EnsureLoginsIsSet();
                return logins;
            }

            // ReSharper disable once UnusedMember.Local, MongoDB serialization needs private setters
            private set
            {
                EnsureLoginsIsSet();
                if (value != null)
                {
                    logins.AddRange(value);
                }
            }
        }

        public int AccessFailedCount { get; private set; }


        public virtual void EnableTwoFactorAuthentication()
        {
            IsTwoFactorEnabled = true;
        }

        public virtual void DisableTwoFactorAuthentication()
        {
            IsTwoFactorEnabled = false;
        }

        public virtual void EnableLockout()
        {
            IsLockoutEnabled = true;
        }

        public virtual void DisableLockout()
        {
            IsLockoutEnabled = false;
        }

        public virtual void SetEmail(string email)
        {
            var mongoUserEmail = new IdentityUserEmail(email);
            SetEmail(mongoUserEmail);
        }

        public virtual void SetEmail(IdentityUserEmail mongoUserEmail)
        {
            Email = mongoUserEmail;
        }

        public virtual void SetNormalizedUserName(string normalizedUserName)
        {
            if (string.IsNullOrWhiteSpace(normalizedUserName))
            {
                throw new ArgumentException("message", nameof(normalizedUserName));
            }

            NormalizedUserName = normalizedUserName;
        }

        public virtual void SetPhoneNumber(string phoneNumber)
        {
            var mongoUserPhoneNumber = new IdentityUserPhoneNumber(phoneNumber);
            SetPhoneNumber(mongoUserPhoneNumber);
        }

        public virtual void SetPhoneNumber(IdentityUserPhoneNumber mongoUserPhoneNumber)
        {
            PhoneNumber = mongoUserPhoneNumber;
        }

        public virtual void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public virtual void SetSecurityStamp(string securityStamp)
        {
            SecurityStamp = securityStamp;
        }

        public virtual void SetAccessFailedCount(int accessFailedCount)
        {
            AccessFailedCount = accessFailedCount;
        }

        public virtual void ResetAccessFailedCount()
        {
            AccessFailedCount = 0;
        }

        public virtual void LockUntil(DateTime lockoutEndDate)
        {
            LockoutEndDate = Occurrence.FromLocal(lockoutEndDate);
        }
        public virtual void AddToken(IdentityUserToken mongoUserToken)
        {
            if (mongoUserToken == null)
            {
                throw new ArgumentNullException(nameof(mongoUserToken));
            }

            tokens.Add(mongoUserToken);
        }

        public virtual void RemoveToken(IdentityUserToken mongoUserToken)
        {
            if (mongoUserToken == null)
            {
                throw new ArgumentNullException(nameof(mongoUserToken));
            }

            tokens.Remove(mongoUserToken);
        }
        public virtual void AddClaim(Claim claim)
        {
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            AddClaim(new IdentityUserClaim(claim));
        }

        public virtual void AddClaim(IdentityUserClaim mongoUserClaim)
        {
            if (mongoUserClaim == null)
            {
                throw new ArgumentNullException(nameof(mongoUserClaim));
            }

            claims.Add(mongoUserClaim);
        }

        public virtual void RemoveClaim(IdentityUserClaim mongoUserClaim)
        {
            if (mongoUserClaim == null)
            {
                throw new ArgumentNullException(nameof(mongoUserClaim));
            }

            claims.Remove(mongoUserClaim);
        }

        public virtual void AddLogin(IdentityUserLogin mongoUserLogin)
        {
            if (mongoUserLogin == null)
            {
                throw new ArgumentNullException(nameof(mongoUserLogin));
            }

            logins.Add(mongoUserLogin);
        }

        public virtual void RemoveLogin(IdentityUserLogin mongoUserLogin)
        {
            if (mongoUserLogin == null)
            {
                throw new ArgumentNullException(nameof(mongoUserLogin));
            }

            logins.Remove(mongoUserLogin);
        }

        public void Delete()
        {
            if (DeletedDate != null)
            {
                throw new InvalidOperationException($"User '{Id}' has already been deleted.");
            }

            DeletedDate = new Occurrence();
        }

        private void EnsureClaimsIsSet()
        {
            if (claims == null)
            {
                claims = new List<IdentityUserClaim>();
            }
        }
        private void EnsureTokensIsSet()
        {
            if (tokens == null)
            {
                tokens = new List<IdentityUserToken>();
            }
        }
        private void EnsureLoginsIsSet()
        {
            if (logins == null)
            {
                logins = new List<IdentityUserLogin>();
            }
        }
    }
}