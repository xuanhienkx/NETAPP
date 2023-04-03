using System;
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using MediatR;

namespace api.domain.Queries
{
    public class GetUsersAccessToMeeting : BaseQuery<List<Account>>
    {
        public string MeetingId { get; }
        public bool IsMemberOnly { get; }
        public bool IsRoleDetail { get; }
        public int Top { get; }
        public List<string> Roles { get; set; }

        public GetUsersAccessToMeeting(string meetingId, bool isMemberOnly = false, bool isRoleDetail = true, in int top = 0)
        {
            MeetingId = meetingId;
            IsMemberOnly = isMemberOnly;
            IsRoleDetail = isRoleDetail;
            Top = top;
        }
    }
}
