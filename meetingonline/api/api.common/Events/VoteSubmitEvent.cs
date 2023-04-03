using System;
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared.Interfaces;
using MediatR;

namespace api.common.Events
{
    public class VoteSubmitEvent : INotification
    {
        public Attendee Attendee { get; }
        public string MeetingId { get; }
        public IdentityUser User;

        public VoteSubmitEvent(Attendee attendee, string meetingId, IdentityUser currentUser)
        {
            Attendee = attendee;
            MeetingId = meetingId;
            this.User = currentUser;
        }
    }
}
