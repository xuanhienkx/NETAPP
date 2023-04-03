using System;
using api.common.Shared;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace api.common.Models
{
    public class MeetingAccess
    {
        public string MeetingId { get; set; }
        public List<string> MeetingRoles { get; set; }
        public MeetingType MeetingType { get; set; }
        public bool IsOwner { get; set; }
        public bool IsViewer { get; set; }
        public Occurrence LockedDate { get; set; }

        [BsonIgnore]
        public bool IsLocked => LockedDate != null;
        [BsonIgnore]
        public List<MeetingRoleLite> UserRoles { get; set; }
    }
}
