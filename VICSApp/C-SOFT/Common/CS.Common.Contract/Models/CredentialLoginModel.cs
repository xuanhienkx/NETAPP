using System;
using System.Collections.Generic;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CredentialLoginModel : DataContract
    {
        [ProtoMember(1)]
        public string Username { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }
        [ProtoMember(3)]
        public IList<UserRoleType> ExpectedRoles { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Username), "CredentialLoginModel_Username_Required", () => !string.IsNullOrEmpty(Username));
            rules.Add(nameof(Password), "CredentialLoginModel_Password_Required", () => !string.IsNullOrEmpty(Password));
        }
    }

    [ProtoContract]
    public class CredentialRegisterModel : DataContract
    {
        [ProtoMember(1)]
        public string Username { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
        [ProtoMember(3)]
        public string Email { get; set; }
        [ProtoMember(4)]
        public string PhoneNumber { get; set; }
        [ProtoMember(5)]
        public UserRoleType Role { get; set; }
        [ProtoMember(6)]
        public Guid UserId { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Username), "CredentialLoginModel_Username_Required", () => !string.IsNullOrEmpty(Username));
            rules.Add(nameof(Password), "CredentialLoginModel_Password_Required", () => !string.IsNullOrEmpty(Password));
            rules.Add(nameof(Email), "CredentialLoginModel_Email_Required", () => !string.IsNullOrEmpty(Email));
        }
    }
    [ProtoContract]
    public class ChangePasswordModel : DataContract
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(3)]
        public string ConfirmPassword { get; set; }
        [ProtoMember(4)]
        public bool IsLockout { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Password), "ChangePasswordModel_Password_Validation", () => !string.IsNullOrEmpty(Password));
            rules.Add(nameof(ConfirmPassword), "ChangePasswordModel_ConfirmPassword_Validation", () => !string.IsNullOrEmpty(ConfirmPassword) && ConfirmPassword.Equals(Password));
        }
    }
}
