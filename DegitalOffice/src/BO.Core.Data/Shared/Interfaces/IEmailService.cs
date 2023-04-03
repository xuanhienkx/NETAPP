using DO.Common.Contract.Enums;

namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface IEmailService
    {
        Task SendMail(string email, string displayName, string subject, string body);
    }
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        string UserId { get; }
        Task<bool> IsInRole(AccountRole role);
        bool IsGroupExisted(string meetingGroupId);
        Task SendLoginState(string userId, string loginTimeStamp, CancellationToken cancellation);
        bool CanAccessToMeeting(string meetingId);
        Task EnsureIdentityUser();
    }
}