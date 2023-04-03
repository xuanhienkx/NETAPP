using MediatR;

namespace api.domain.Events
{
    public class DelegateRequestEvent : INotification
    {
        public string MeetingId { get; }
        public string MandatorId { get; }

        public DelegateRequestEvent(string meetingId, string mandatorId)
        {
            MeetingId = meetingId;
            MandatorId = mandatorId;
        }
    }
}
