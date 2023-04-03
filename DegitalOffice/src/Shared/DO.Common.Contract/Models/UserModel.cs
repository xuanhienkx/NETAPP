using DO.Common.Contract.Enums;
using ProtoBuf;
using System;
using System.Text.RegularExpressions;

namespace DO.Common.Contract.Models
{
    [ProtoContract]
    public class UserModel : DataContract, IUserLogin, IPersonModel
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(3)]
        public UserType UserType { get; set; }
        [ProtoMember(5)]
        public string Email { get; set; }
        [ProtoMember(6)]
        public string PhoneNumber { get; set; }
        [ProtoMember(8)]
        public string FullName { get; set; }
        [ProtoMember(11)]
        public bool IsActive { get; set; }
        [ProtoMember(12)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(13)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(14)]
        public UserModel CreatedBy { get; set; }
        [ProtoMember(15)]
        public UserModel ModifiedBy { get; set; }
        [ProtoMember(16)]
        public int Version { get; set; }
        [ProtoMember(17)]
        public string LanguageCode { get; set; }
        [ProtoMember(19)]
        public string AccountLogin { get; set; }


        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(FullName), "BrokerModel_FullName_Validation", () => !string.IsNullOrEmpty(FullName));
            rules.Add(nameof(AccountLogin), "UserModel_AccountLogin_Validation", () => !string.IsNullOrEmpty(AccountLogin));
            rules.Add(nameof(Email), "BrokerModel_Email_Validation", () => !string.IsNullOrEmpty(Email) && Regex.IsMatch(Email, Helper.EmailRegex));
        }
    }
}