using api.common.Models;
using MediatR;

namespace api.domain.Events
{
    public class MeetingCreatedOrDeleteEvent : INotification
    {
        public MeetingCreatedOrDeleteEvent(string id, MeetingType meetingType = MeetingType.GeneralMeeting, bool isDeleted = false, bool isPermanentDeleted = false)
        {
            Id = id;
            MeetingType = meetingType;
            IsDeleted = isDeleted;
            IsPermanentDeleted = isPermanentDeleted;
        }

        public string Id { get; }
        public bool IsDeleted { get; }
        public bool IsPermanentDeleted { get; }
        public MeetingType MeetingType { get; set; }
    }
}
