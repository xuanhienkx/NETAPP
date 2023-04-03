using System;
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using MediatR;

namespace api.domain.Events
{
    public class MeetingLockHolderBackgroundEvent : INotification
    {
        public MeetingLite Meeting;

        public MeetingLockHolderBackgroundEvent(MeetingLite meeting)
        {
            this.Meeting = meeting;
        }
    }
}
