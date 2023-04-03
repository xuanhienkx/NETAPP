using api.common.Shared;
using System.Collections.Generic;
using System.Linq;

namespace api.common.Models.Identity
{
    public class IdentityPrincipal : Account
    {
        public IdentityPrincipal(string token, string role, IdentityUser user, string loginTimeStamp)
        {
            Id = user.Id;
            Token = token;
            Role = role;
            LoginTimeStamp = loginTimeStamp;
            UserName = user.UserName;
            DisplayName = user.DisplayName;
            Avatar = user.Avatar;
            Language = user.Language;
            MeetingGroups = IdentityPrincipalMeetingGroup.Transform(user.MeetingGroups).ToList();
            Email = user.Email;
        }

        public string Token { get; }
        public string Role { get; }
        public string LoginTimeStamp { get; }
        public bool IsLockoutEnabled { get; protected set; }
        public Occurrence LockoutEndDate { get; protected set; }
        
        public Occurrence LockedDate { get; protected set; }
        public Occurrence DeletedDate { get; protected set; }
        public new IList<IdentityPrincipalMeetingGroup> MeetingGroups { get; }
    }

    public class IdentityPrincipalMeetingGroup
    {
        public string Id { get; set; }
        public MediaResource Logo { get; set; }
        public string Name { get; set; }
        public Occurrence LockedDate { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        internal static IEnumerable<IdentityPrincipalMeetingGroup> Transform(IEnumerable<MeetingGroup> meetingGroups)
        {
            return meetingGroups.Select(x => new IdentityPrincipalMeetingGroup
            {
                Id = x.Id,
                Name = x.Name,
                Logo = x.Logo,
                Header = x.Header,
                Footer = x.Footer
            });
        }
    }
}