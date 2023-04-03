using api.common.Models.Identity;
using api.common.Shared.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace api.common.Models
{
    public class AccountInfo : AccountInfoBase
    {
        public string UserName { get; set; }
        public MediaResource Avatar { get; set; }
        public string Language { get; set; }
        public IdentityUserEmail Email { get; set; }
        public IdentityUserPhoneNumber PhoneNumber { get; set; }
    }

    public class PersonInfo : AccountInfoBase
    {
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AccountInfoBase : BaseModel
    {
        public string DisplayName { get; set; }
        
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string NormalizeIdentityNumber { get; set; }
        public string IdentityIssuedDate { get; set; }
        public string IdentityIssuer { get; set; }
        public string IdentityType { get; set; }
        public string Nationality { get; set; }
    }
}