using System.Collections.Generic;
using api.common.Shared;
using api.common.Shared.Base;
using MongoDB.Bson;

namespace api.common.Models
{
    public class MeetingGroup : BaseModel
    {
        public MeetingGroup(string id, string name, MediaResource logo, string header, string footer) 
        {
            Id = id;
            Name = name;
            Logo = logo;
            Header = header;
            Footer = footer;
        }

        public MeetingGroup(string name, MediaResource logo, string header, string footer)
            : this(ObjectId.GenerateNewId().ToString(), name, logo, header, footer)
        {
           
        }

        public string Name { get; set; }
        public MediaResource Logo { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
    }
}
