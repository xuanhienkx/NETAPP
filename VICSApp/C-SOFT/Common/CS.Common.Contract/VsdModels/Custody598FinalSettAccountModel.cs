using System;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public class Custody598FinalSettAccountModel :VsdCustomer
    {
        public Custody598FinalSettAccountModel()
        {
            AccountProcessInstruction = SettlementType.MoveAllStockAndNotCloseAcount;
        }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(1)]
        public SettlementType AccountProcessInstruction { get; set; }
        [ProtoMember(2)] 
        public string Address { get; set; }
        [ProtoMember(3)]
        public string NationalityCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(4)]
        public CardType CardType { get; set; }
        [ProtoMember(5)]
        public string CardIdentity { get; set; }
        [ProtoMember(6)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(7)]
        public string CardIssuer { get; set; }
        [ProtoMember(8)]
        public string ReceiverBiccode { get; set; }
        [ProtoMember(9)]
        public string ReceiverAccount { get => Get<string>(); set => Set(value); }
        [ProtoMember(10)] 
        public string CountryCode { get; set; }
        [ProtoMember(11)]
        public string ReceiverCompanyName { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
           rules.Add(nameof(ReceiverAccount), "CustodyModel_ReceiverAccount_Validation", () => !string.IsNullOrEmpty(ReceiverAccount));
            rules.Add(nameof(ReceiverAccount), "Custody598FinalSettAccountModel_ReceiverAccount_Dulicate_Validation", () => !string.IsNullOrEmpty(CustomerNumber) && !ReceiverAccount.StartsWith(CustomerNumber.Substring(0,3)));
            rules.Add(nameof(ReceiverAccount), "CustodyModel_ReceverBiccode_Validation", () => !string.IsNullOrEmpty(ReceiverBiccode));
        }
    }
}
