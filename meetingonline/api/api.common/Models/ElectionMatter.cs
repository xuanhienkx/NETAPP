using System.Collections.Generic;
using api.common.Shared;
using api.common.Shared.Base;
using MongoDB.Bson;

namespace api.common.Models
{
    public class ElectionMatter : MeetingInfo
    {
        public ElectionMatter()
        {
            this.Options = new List<ElectionOption>();
        }

        public Occurrence OpenedDate { get; set; }
        public Occurrence ClosedDate { get; set; }
        public List<ElectionOption> Options { get; set; }
        public int Taken { get; set; }
        public bool Optional { get; set; }
    }

    public class ElectionOption : BaseModel
    {
        public ElectionOption()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
        public string Name { get; set; }

        public int Votes { get; set; }
    }
}