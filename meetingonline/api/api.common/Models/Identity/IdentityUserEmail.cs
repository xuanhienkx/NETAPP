using System;
using Newtonsoft.Json;

namespace api.common.Models.Identity
{
    public class IdentityUserEmail : IdentityUserContactRecord
    {
        public IdentityUserEmail()
        {
        }

        public IdentityUserEmail(string email) : base(email)
        {
        }

        [JsonIgnore]
        public string NormalizedValue { get; private set; }

        public virtual void SetNormalizedEmail(string normalizedEmail)
        {
            NormalizedValue = normalizedEmail ?? throw new ArgumentNullException(nameof(normalizedEmail));
        }
    }
}
