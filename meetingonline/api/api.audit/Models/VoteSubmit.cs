using api.common.Models;
using api.common.Models.Identity;
using Microsoft.AspNetCore.Http;

namespace api.audit.Models
{
    internal class VoteSubmit : BaseAudit
    {
        public VoteSubmit(IdentityUser user, HttpContext httpContext) : base(user, httpContext)
        {
        }

        public string MeetingId { get; set; }
        public Attendee Attendee { get; set; }
    }
}
