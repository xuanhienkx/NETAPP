using api.common.Models;
using api.common.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Commands
{
    public class MeetingAccessCommand : BaseCommand<Account>
    {
        public List<string> MeetingRoles { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime ValidatedDate { get; set; }
    }

    public class MeetingAccessActionCommand : BaseCommand<bool>
    {
        public MeetingAccessActionCommand(string meetingId, string userId, bool isViewer, bool isGrantAccessRequest = false, bool requestFlag = false, MeetingAccessCommand content = null)
        {
            MeetingId = meetingId;
            UserId = userId;
            IsViewer = isViewer;
            IsGrantAccessRequest = isGrantAccessRequest;
            RequestFlag = requestFlag;
            Content = content;
        }
        [Required]
        public string MeetingId { get; }
        [Required]
        public string UserId { get; }

        public bool IsViewer { get; }

        public bool IsGrantAccessRequest { get; }
        public bool RequestFlag { get; }
        public MeetingAccessCommand Content { get; }
    }
}