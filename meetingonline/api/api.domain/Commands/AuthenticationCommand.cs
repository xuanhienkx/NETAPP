using api.common.Shared;
using System.ComponentModel.DataAnnotations;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared.Base;

namespace api.domain.Commands
{
    public class AccountAuthenticateCommand : BaseCommand<IdentityPrincipal>
    {
        public AccountAuthenticateCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class AccountChangePasswordCommand : BaseCommand<bool>
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }

    public class AccountRegisterCommand : BaseCommand<bool>
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class AccountResetPasswordCommand : BaseCommand<bool>
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
    }

    public enum IdentityRequestType
    {
        LOGOUT,
        RESET_PASSWORD,
        RESET_LOGINCODE
    }

    public class IdentityRequestCommand : BaseCommand<bool>
    {
        public IdentityRequestType Type { get; }

        public IdentityRequestCommand(IdentityRequestType type)
        {
            Type = type;
        }

        public string IdentityID { get; set; }
    }

    public enum VerifyType
    {
        EMAIL,
        MOBILE
    }

    public class AccountVerifyCommand : BaseCommand<bool>
    {
        public AccountVerifyCommand(string userId, string token, VerifyType verifyType)
        {
            UserId = userId;
            Token = token;
            Type = verifyType;
        }

        [Required]
        public VerifyType Type { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
    }

    public class AccountCreateCommand<T> : BaseCommand<T>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string IdentityType { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string IdentityDate { get; set; }
        [Required]
        public string IdentityIssuer { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class OAuthAuthenticationCommand : BaseCommand<IdentityPrincipal>
    {
        [Required]
        public string Provider { get; set; }
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthToken { get; set; }
        public string IdToken { get; set; }
        public string AuthorizationCode { get; set; }
    }
}
