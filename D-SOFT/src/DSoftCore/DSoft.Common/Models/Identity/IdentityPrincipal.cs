using DSoft.Common.Shared;

namespace DSoft.Common.Models.Identity;

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
        Email = user.Email;
    }

    public string Token { get; }
    public string Role { get; }
    public string LoginTimeStamp { get; }
    public bool IsLockoutEnabled { get; protected set; }
    public Occurrence LockoutEndDate { get; protected set; }

    public Occurrence LockedDate { get; protected set; }
    public Occurrence DeletedDate { get; protected set; }

}