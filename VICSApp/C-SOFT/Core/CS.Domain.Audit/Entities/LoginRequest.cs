using CS.Common.Std.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Audit.Entities
{
    public enum LoginType
    {
        LoginRequest,
        LoginFailed,
        LoginSuccess,
        Logout
    }

    [Table("LoginRequests")]
    public class LoginRequest : EventBase
    {
        [NotMapped]
        public LoginType Type { get; set; }

        [MaxLength(20)]
        public string LoginType
        {
            get => Type.ToString();
            set => Type = value.AsEnum<LoginType>();
        }

        public string Content { get; set; }
    }   
}
