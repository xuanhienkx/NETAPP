using System;
using System.Collections.Generic;
using System.Text;
using api.common.Models;
using api.common.Shared.Base;

namespace api.domain.Queries
{
    class MeetingRoleQuery
    {
    }

    public class MeetingRoleFilterCommand : BaseQuery<List<string>>
    {
        public MeetingType MeetingType { get; }
        public List<MeetingPermission> Permissions { get; }

        public MeetingRoleFilterCommand(MeetingType meetingType, params MeetingPermission[] permissions)
        {
            MeetingType = meetingType;
            Permissions = new List<MeetingPermission>(permissions);
        }
    }
}
