using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using api.common.Models;
using Microsoft.AspNetCore.Identity;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.common.Shared.Interfaces
{
    public interface ICurrentUser
    {
        IdentityUser User { get; }
        ClaimsIdentity ClaimsIdentity { get; }
        bool IsAuthenticated { get; }
        string UserId { get; }

        Task<IdentityResult> Update();
        Task<bool> HasMeetingAccess(string meetingId, params string[] permissions);
        Task<bool> IsInRole(AccountRole role);
        bool IsGroupExisted(string meetingGroupId);
        Task SendLoginState(string userId, string loginTimeStamp, CancellationToken cancellation);
        bool CanAccessToMeeting(string meetingId);
        Task EnsureIdentityUser();
    }
}
