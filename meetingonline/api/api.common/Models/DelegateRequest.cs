using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using System.Collections.Generic;

namespace api.common.Models
{
    public class DelegateRequest : BaseModel, IPersistentEntity
    {
        public DelegateRequest()
        {
            CreatedDate = new Occurrence();
            AdminActivities = new List<Activity>();
        }
        public Holder Mandator { get; set; }
        public Delegation Delegation { get; set; }
        public string MeetingId { get; set; }
        public bool IsOnline { get; set; }
        public Occurrence CreatedDate { get; set; }
        public Occurrence ConfirmedDate { get; set; }
        public List<Activity> AdminActivities { get; set; }
    }

    public class Activity
    {
        public Activity(ICurrentUser user, string note)
        {
            PerformedId = user.User.Id;
            PerformedName = $"{user.User.DisplayName} ({user.User.Email.Value})";
            Note = note;
            CreatedDate = new Occurrence();
        }
        public string Note { get; set; }
        public Occurrence CreatedDate { get; set; }
        public string PerformedId { get; set; }
        public string PerformedName { get; set; }
    }

    public class DelegateRequestGroup
    {
        public Holder Mandator { get; }
        public List<DelegateRequest> Requests { get; }

        public DelegateRequestGroup(Holder mandator, List<DelegateRequest> requests)
        {
            Mandator = mandator;
            Requests = requests;
        }

    }
}