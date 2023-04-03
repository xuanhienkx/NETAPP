using System;
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;

namespace api.domain.Queries
{
    public class MeetingAccessQuery : BaseQuery<Meeting>
    {
        public string MeetingId { get; set; }
    }

    public class MeetingAttendeeDelegatedQuery : BaseQuery<List<Attendee>>
    {
        public MeetingAttendeeDelegatedQuery(string meetingId)
        {
            MeetingId = meetingId;
        }

        public string MeetingId { get; set; }
    }
}
