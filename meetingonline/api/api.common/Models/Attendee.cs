using api.common.Shared;
using api.common.Shared.Base;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.common.Models
{
    public class Attendee : PersonInfo
    {
        public Attendee()
        {
            CreatedDate = new Occurrence();
        }
        public string IdentityUserId { get; set; }
        public string RepTitle { get; set; }
        // số cổ phần nếu là cổ đông.
        public int Shares { get; set; }
        // Số quyền
        public int OwnedVotes { get; set; }
        // Đã ủy quyền
        public int DelegatingVotes { get; set; }
        // Quyền được nhậnza
        public int SharedVotes { get; set; }
        // TotalVotes = (OwnedVotes - DelegatingVotes) + SharedVotes
        // Tổng quyền biểu quyết
        public int TotalVotes { get; set; }
        public Occurrence CreatedDate { get; set; }
        public Occurrence CheckedInDate { get; set; }
        public List<ElectionVote> Votes { get; set; }
        public bool IsOnlineCheckIn { get; set; }
        public bool IsRepresentative { get; set; }
        public List<MediaResource> Attachments { get; set; }
        public List<Delegation> Mandators { get; set; }
    }

    public class Mandator : PersonInfo
    {
        public int Votes { get; set; }
        public Occurrence ConfirmedDate { get; }
    }

    public class Vote : BaseModel
    {
        public Vote(string id, int votes)
        {
            Id = id;
            Votes = votes;
        }
        public int Votes { get; set; }
    }

    public class ElectionVote : BaseModel
    {
        public List<Vote> Options { get; set; }
        
    }
}