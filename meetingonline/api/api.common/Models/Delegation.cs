using System.Collections.Generic;
using api.common.Shared;

namespace api.common.Models
{
    public class Delegation : PersonInfo
    {
        public Delegation()
        {
            Attachments = new List<MediaResource>();
        }
        public Delegation(string id) : this()
        {
            Id = id;
            CreatedDate = new Occurrence();
        }

        public Delegation(string id, int votes) : this(id)
        {
            Votes = votes;
        }

        public int Votes { get; set; }
        public Occurrence CreatedDate { get; }
        public Occurrence RequestedDate { get; set; }
        public Occurrence ApprovedDate { get; set; }
        public Occurrence RejectedDate { get; set; }
        public List<MediaResource> Attachments { get; set; }
    }
}