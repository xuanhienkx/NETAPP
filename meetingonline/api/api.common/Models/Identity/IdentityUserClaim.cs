using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace api.common.Models.Identity
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public class IdentityUserClaim : IEquatable<IdentityUserClaim>, IEquatable<Claim>
    {
        public IdentityUserClaim(Claim claim)
        {
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }

        public IdentityUserClaim(string claimType, string claimValue)
        {
            if (string.IsNullOrEmpty(claimType))
            {
                throw new ArgumentException("message", nameof(claimType));
            }

            if (string.IsNullOrEmpty(claimValue))
            {
                throw new ArgumentException("message", nameof(claimValue));
            }

            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }

        public bool Equals(IdentityUserClaim other)
        {
            return other.ClaimType.Equals(ClaimType)
                && other.ClaimValue.Equals(ClaimValue);
        }

        public bool Equals(Claim other)
        {
            return other.Type.Equals(ClaimType)
                && other.Value.Equals(ClaimValue);
        }
    }
}
