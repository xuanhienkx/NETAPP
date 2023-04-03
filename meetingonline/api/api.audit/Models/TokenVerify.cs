using api.common.Models.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.audit.Models
{
    internal class TokenVerify : BaseAudit
    {
        public TokenVerify(IdentityUser user, HttpContext httpContext) : base(user, httpContext)
        {
        }

        public string Token { get; internal set; }
        public string VerifyType { get; internal set; }
    }
}
