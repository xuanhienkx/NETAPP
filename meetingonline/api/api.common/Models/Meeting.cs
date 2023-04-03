using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace api.common.Models
{
    public class Meeting : MeetingLite
    {
        public Meeting()
        {
            CreatedDate = new Occurrence();
            Contents = new List<MeetingInfo>();
            Holders = new List<Holder>();
            Attendees = new List<Attendee>();
            ElectionMatters = new List<ElectionMatter>();
        }
        public Meeting(string name, string description, string address, DateTime openedDate, MeetingType type)
        : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("message", nameof(Name));
            }

            Name = name;
            Description = description;
            Address = address;
            Type = type;
            OpenedDate = Occurrence.FromLocal(openedDate);
        }
        
        public Occurrence CreatedDate { get; set; }
        public string GroupId { get; set; }
        public Occurrence ClosedDate { get; set; }
        public Occurrence DeletedDate { get; set; }
        public List<MeetingInfo> Contents { get; set; }
        public List<ElectionMatter> ElectionMatters { get; set; }
        public List<Holder> Holders { get; set; }
        public List<Attendee> Attendees { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public MediaResource HolderUploadFile { get; set; }
        public MeetingSummary Summary { get; set; }


        [BsonIgnore]
        public bool IsOwner { get; set; }
        [BsonIgnore]
        public List<MeetingRole> UserRoles { get; set; }
    }

    public class MeetingLite : BaseModel, IPersistentEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Occurrence OpenedDate { get; set; }
        public MeetingType Type { get; set; }
        public MediaResource Logo { get; set; }
        public MeetingStatus Status { get; set; }
    }
}
