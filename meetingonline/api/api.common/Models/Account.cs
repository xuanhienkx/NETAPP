using api.common.Shared;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading;
using api.common.Shared.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace api.common.Models
{

    public class Account : AccountInfo
    {
        public Account()
        {
            MeetingAccesses = new List<MeetingAccess>();
            MeetingGroups = new List<MeetingGroup>();
        }

        public Account(string userName)
            : this()
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("message", nameof(userName));
            }

            UserName = userName;
            DisplayName = $"{userName}";
            CreatedDate = new Occurrence();
            Language = ProviderConstants.DefaultCulture; // Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        }
        
        public Occurrence CreatedDate { get; protected set; }
        public List<MeetingGroup> MeetingGroups { get; set; }
        public List<MeetingAccess> MeetingAccesses { get; set; }
    }
}