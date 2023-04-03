using api.common.Models;
using api.common.Shared.Base;

namespace api.domain.Commands
{

    public class DelegateRequestUpdateCommand : BaseCommand<DelegateRequest>
    {
        public string MeetingId { get; }
        public Holder Mandator { get; }
        public Delegation Delegation { get; }
        public Activity Activity { get; }
        public bool IsOnline { get; } 

        public DelegateRequestUpdateCommand(string meetingId, Holder mandator, Delegation delegation, Activity activity, bool isOnline = false)
        {
            MeetingId = meetingId;
            Mandator = mandator;
            Delegation = delegation;
            Activity = activity;
            IsOnline = isOnline;
        }
    }

    public class DelegateRequestCommand : BaseCommand<DelegateRequest>
    {
        public string Id { get; }

        public DelegateRequestCommand(string id)
        {
            Id = id;
        }
    }

    public class DelegateRequestResponseCommand : DelegateRequestCommand
    {
        public string Message { get; }
        public bool IsApprove { get; }
        public DelegateRequestResponseCommand(string id, bool isApprove, string message)
         : base(id)
        {
            IsApprove = isApprove;
            Message = message;
        }
    }
}
