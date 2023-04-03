using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace api.common.Models
{
    public class MeetingRole : MeetingRoleLite, IPersistentEntity
    {
        public MeetingRole()
        {
            CreatedDate = new Occurrence();
        }
        public List<string> Permissions { get; set; }
    }

    public class MeetingRoleLite : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Occurrence CreatedDate { get; set; }
        public Occurrence DisabledDate { get; set; }
        [Required]
        public MeetingType MeetingType { get; set; }

        [JsonIgnore]
        public string NormalizedName { get; private set; }
        public void SetNormalizedName(string normalizedName)
        {
            NormalizedName = normalizedName ?? throw new ArgumentNullException(nameof(normalizedName));
        }

        /// <summary>
        /// Bson ingore
        /// </summary>
        [BsonIgnore]
        public bool IsDisabled => DisabledDate != null;
    }
}