using api.common.Models;
using api.common.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.common.Shared.Base;
using MediatR;

namespace api.domain.Commands
{
    public abstract class MeetingCommandBase : BaseCommand<Meeting>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupId { get; set; }
        [Required]
        [MinLength(10)]
        public string Address { get; set; }
        public DateTime OpenedDate { get; set; }
        public MediaResource Logo { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
    }

    public class MeetingCreateCommand : MeetingCommandBase
    {
        public MeetingType Type { get; set; }
    }

    public class MeetingUpdateCommand : MeetingCommandBase
    {
        [Required]
        public string Id { get; set; }
        public MeetingStatus Status { get; set; }
        public Occurrence ClosedDate { get; set; }
    }

    public class MeetingUpdateContentCommand<T> : BaseCommand<T> where T : BaseModel
    {
        public MeetingUpdateContentCommand(string meetingId, T value, bool isOnline = false)
        {
            MeetingId = meetingId;
            Value = value;
            IsOnline = isOnline;
        }
        public string MeetingId { get; set; }
        public T Value { get; set; }
        public bool IsOnline { get; }
    }

    public class MeetingElectionMatterIndexedCommand : BaseCommand<bool>
    {
        public string MeetingId { get; }
        public string MatterId { get; }
        public int Index { get; }

        public MeetingElectionMatterIndexedCommand(string meetingId, string matterId, int index)
        {
            MeetingId = meetingId;
            MatterId = matterId;
            Index = index;
        }
    }

    public class AttendeeMeetingElectionVoteCommand : BaseCommand<bool>
    {
        public string MeetingId { get; }
        public string AttendeeId { get; }
        public List<ElectionVote> Votes { get; }
        public bool IsForceUpdated { get; }


        public AttendeeMeetingElectionVoteCommand(string meetingId, string attendeeId, List<ElectionVote> votes, bool isForceUpdated = false)
        {
            MeetingId = meetingId;
            AttendeeId = attendeeId;
            Votes = votes;
            IsForceUpdated = isForceUpdated;
        }

        public AttendeeMeetingElectionVoteCommand(string meetingId, List<ElectionVote> votes)
        {
            MeetingId = meetingId;
            Votes = votes;
        }
    }

    public class MeetingElectionVoteUpdateCommand : BaseCommand<bool>
    {
        public string MeetingId { get; }
        public ElectionVote OldVote { get; }
        public ElectionVote NewVote { get; }


        public MeetingElectionVoteUpdateCommand(string meetingId, ElectionVote oldVote, ElectionVote newVote)
        {
            MeetingId = meetingId;
            OldVote = oldVote;
            NewVote = newVote;
        }
    }

    public enum RequestType
    {
        Create,
        Submit,
        Approve,
        Reject,
        Delete
    }

    public class MeetingDelegationRequestCommand<T> : BaseCommand<bool> where T : class
    {
        public string MeetingId { get; }
        public string HolderId { get; }
        public Delegation Delegation { get; }
        public bool IsOnline { get; }
        public RequestType Type { get; }

        public MeetingDelegationRequestCommand(string meetingId, string holderId, RequestType type, Delegation delegation, bool isOnline = true)
        {
            MeetingId = meetingId;
            HolderId = holderId;
            Delegation = delegation;
            IsOnline = isOnline;
            Type = type;
        }
    }
    public class MeetingHolderUploadCommand : BaseCommand<MeetingSummary>
    {
        public string MeetingId { get; }
        public MediaResource Media { get; }


        public MeetingHolderUploadCommand(string meetingId, MediaResource media)
        {
            MeetingId = meetingId;
            Media = media;
        }
    }

    public class MeetingStatusChangedCommand : BaseCommand<string>
    {
        public MeetingStatus Status { get; }
        public string Id { get; }

        public MeetingStatusChangedCommand(string id, MeetingStatus status)
        {
            Id = id;
            Status = status;
        }
    }

    public class MeetingMapHolderToIdentityUserEvent : INotification
    {
        public string HfId { get; }
        public MeetingLite Meeting { get; }
        public string UserId { get; }

        public MeetingMapHolderToIdentityUserEvent(string hfId, MeetingLite meeting, string userId)
        {
            HfId = hfId;
            Meeting = meeting;
            UserId = userId;
        }
    }

    public class MeetingHolderCreateCommand : AccountCreateCommand<Holder>
    {
        public int Shares { get; set; }
        public int VoteRights { get; set; }
    }

    public class MeetingAttendeeCheckInCommand : BaseCommand<Attendee>
    {
        public string MeetingId { get; }
        //public IEnumerable<MediaResource> Attachments { get; set; }

        public MeetingAttendeeCheckInCommand(string meetingId)
        {
            MeetingId = meetingId;
        }
    }
    public class MeetingAttendeeCheckOutCommand : BaseCommand<Holder>
    {
        public string MeetingId { get; }
        //public IEnumerable<MediaResource> Attachments { get; set; }

        public MeetingAttendeeCheckOutCommand(string meetingId)
        {
            MeetingId = meetingId;
        }
    }
    public class MeetingAttendConfirmCommand : BaseCommand<Holder>
    {
        public string MeetingId { get; }
        public string HolderId { get; }
        public bool IsConfirmed { get; }
        public bool IsForUserCheckIn { get; }
        public bool IsOnline { get; }

        public MeetingAttendConfirmCommand(string meetingId, string holderId = null, bool isConfirmed = true, bool isForUserCheckIn = false, bool isOnline = true)
        {
            MeetingId = meetingId;
            HolderId = holderId;
            IsConfirmed = isConfirmed;
            IsForUserCheckIn = isForUserCheckIn;
            IsOnline = isOnline;
        }
    }

    public class AttendeeMeetingCheckInReportCommand : BaseCommand<List<MediaResource>>
    {
        public string MeetingId { get; }
        public string AttendId { get; }

        public AttendeeMeetingCheckInReportCommand(string meetingId, string attendId)
        {
            MeetingId = meetingId;
            AttendId = attendId;
        }
    }

}
