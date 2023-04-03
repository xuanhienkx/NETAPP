using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.Common.Std.Extensions;

namespace CS.UI.Common
{
    public class CurrentPrincipal : CS.Common.Contract.ModelBase, IPrincipal
    {
        #region Singleton mechanism

        public static CurrentPrincipal Instance { get; } = new CurrentPrincipal();

        private CurrentPrincipal() { }

        #endregion

        #region IPrincipal members

        public ClaimsPrincipal Principal { get; set; }  
        public IIdentity Identity => Principal?.Identity;

        public bool IsInRole(string role) { return Principal != null && Principal.IsInRole(role); }

        public void Reset()
        {
            Principal = null;
        }

        public UserRoleType Role => Principal.FindFirst(ClaimTypes.Role).Value.AsEnum<UserRoleType>();

        public bool IsAuthenticated => Principal != null && Principal.Identity.IsAuthenticated;
        
        #endregion
    }
}
