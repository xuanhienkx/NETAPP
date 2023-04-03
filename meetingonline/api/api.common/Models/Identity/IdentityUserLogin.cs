﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace api.common.Models.Identity
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public class IdentityUserLogin : IEquatable<IdentityUserLogin>, IEquatable<UserLoginInfo>
    {
        public IdentityUserLogin(UserLoginInfo loginInfo)
        {
            if (loginInfo == null)
            {
                throw new ArgumentNullException(nameof(loginInfo));
            }

            LoginProvider = loginInfo.LoginProvider;
            ProviderKey = loginInfo.ProviderKey;
            ProviderDisplayName = loginInfo.ProviderDisplayName;
        }

        public string LoginProvider { get; private set; }
        public string ProviderKey { get; private set; }
        public string ProviderDisplayName { get; private set; }

        public bool Equals(IdentityUserLogin other)
        {
            return other.LoginProvider.Equals(LoginProvider)
                && other.ProviderKey.Equals(ProviderKey);
        }

        public bool Equals(UserLoginInfo other)
        {
            return other.LoginProvider.Equals(LoginProvider)
                && other.ProviderKey.Equals(ProviderKey);
        }
    }
}
