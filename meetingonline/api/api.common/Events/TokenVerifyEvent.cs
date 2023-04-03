using api.common.Models.Identity;
using MediatR;

namespace api.common.Events
{
    public class TokenVerifyEvent : INotification
    {
        public TokenVerifyEvent(IdentityUser user, string token, string type)
        {
            User = user;
            Token = token;
            Type = type;
        }

        public IdentityUser User { get; }
        public string Token { get; }
        public string Type { get; }
    }
}
