using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.common.Shared;
using api.common.Shared.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.common.Models
{
    public class MeetingInfo: BaseModel
    {
        public MeetingInfo()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Attachments = new List<MediaResource>();
        }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MediaResource> Attachments { get; set; }
    }
}