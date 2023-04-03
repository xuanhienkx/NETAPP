using api.common.Models.Identity;
using api.common.Shared;
using Microsoft.AspNetCore.Http;

namespace api.audit.Models
{
    internal class UserLogin : BaseAudit
    {
        public UserLogin(IdentityUser user, HttpContext httpContext) : base(user, httpContext)
        {
        }

        public string Action { get; set; }
        public string LoginName { get; set; }
        public string Result { get; set; }
        public Occurrence ActionTime { get; set; }
    }
}