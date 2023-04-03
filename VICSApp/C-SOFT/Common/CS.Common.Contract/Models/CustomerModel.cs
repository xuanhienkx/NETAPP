using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class CustomerModel : DataContract, IPersonModel
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string CustomerNumber { get; set; }
        [ProtoMember(3)]
        public string FullNameLocal { get; set; }
        [ProtoMember(4)]
        public CustomerType Type { get => Get<CustomerType>(); set => Set(value); }
        [ProtoMember(5)]
        public DateTime? BirthDay { get; set; }
        [ProtoMember(6)]
        public GenereType Genere { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(7)]
        public CardType CardType { get => Get<CardType>(); set => Set(value); }
        [ProtoMember(8)]
        public string CardIdentity { get; set; }
        [ProtoMember(9)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(10)]
        public string CardIssuer { get; set; }
        [ProtoMember(11)]
        public string NationalityCode { get; set; }
        [ProtoMember(12)]
        public string TaxCode { get; set; }
        [ProtoMember(13)]
        public byte Level { get; set; }
        [ProtoMember(14)]
        public CustomerStatus Status { get; set; }
        [ProtoMember(15)]
        public string Address { get; set; }
        [ProtoMember(16)]
        public string City { get; set; }
        [ProtoMember(17)]
        public string CountryCode { get; set; }
        [ProtoMember(18)]
        public string Notes { get; set; }
        [ProtoMember(20)]
        public UserModel Broker { get; set; }
        [ProtoMember(21)]
        public string Email { get; set; }
        [ProtoMember(22)]
        public string PhoneNumber { get; set; }  
        [ProtoMember(23)]
        public string UserName { get; set; }
        [ProtoMember(24)]
        public string Password { get; set; }
        [ProtoMember(25)]
        public string PinCode { get; set; }
        [ProtoMember(26)]
        public string FullName { get; set; }
        [ProtoMember(27)]
        public BranchModel Branch { get; set; }
        [ProtoMember(28)]
        public bool IsActive { get; set; }
        [ProtoMember(29)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(30)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(31)]
        public UserModel CreatedBy { get; set; }
        [ProtoMember(32)]
        public UserModel ModifiedBy { get; set; }
        [ProtoMember(33)]
        public int Version { get; set; }
        [ProtoMember(34)]
        public string LanguageCode { get; set; }      
        [ProtoMember(36)]
        public IList<ContactModel> Contacts { get; set; }
        [ProtoMember(37)]
        public byte[] SignatureImage1 { get => Get<byte[]>(); set => Set(value); }
        [ProtoMember(38)]
        public byte[] SignatureImage2 { get => Get<byte[]>(); set => Set(value); }
        [ProtoMember(39)]
        public IList<CustomerAccountModel> CustomerAccounts { get; set; }
        [ProtoMember(40)]
        public string AccountLogin { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(FullNameLocal), "CustomerModel_FullNameLocal_Validation", () => !string.IsNullOrEmpty(FullNameLocal));
            rules.Add(nameof(CustomerNumber), "CustomerModel_CustomerNumber_Validation", () => !string.IsNullOrEmpty(CustomerNumber));
            rules.Add(nameof(Address), "CustomerModel_Address_Validation", () => !string.IsNullOrEmpty(Address));
            rules.Add(nameof(City), "CustomerModel_City_Validation", () => !string.IsNullOrEmpty(City));
            rules.Add(nameof(Email), "CustomerModel_Email_Validation", () => !string.IsNullOrEmpty(Email) && Regex.IsMatch(Email, Helper.EmailRegex));
            rules.Add(nameof(PhoneNumber), "CustomerModel_PhoneNumber_Validation", () => !string.IsNullOrEmpty(PhoneNumber));
            rules.Add(nameof(CountryCode), "CustomerModel_CountryCode_Validation", () => !string.IsNullOrEmpty(CountryCode));
            rules.Add(nameof(NationalityCode), "CustomerModel_NationalityCode_Validation", () => !string.IsNullOrEmpty(NationalityCode));
            rules.Add(nameof(CardIdentity), "CustomerModel_CardIdentity_Validation", () => !string.IsNullOrEmpty(CardIdentity));
            rules.Add(nameof(CardIssuer), "CustomerModel_CardIssuer_Validation", () => !string.IsNullOrEmpty(CardIssuer));
            rules.Add(nameof(BirthDay), "CustomerModel_BirthDay_Validation", () => BirthDay != null && BirthDay.Value < DateTime.Now.AddYears(-18));
            rules.Add(nameof(CardIssuedDate), "CustomerModel_CardIssuedDate_Validation", () => CardIssuedDate < DateTime.Now.AddDays(-1) && CardIssuedDate > DateTime.Now.AddYears(-15));
        }
    }
}
