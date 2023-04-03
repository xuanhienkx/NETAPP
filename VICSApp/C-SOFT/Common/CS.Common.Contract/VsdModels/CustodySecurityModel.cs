using System;
using System.Text.RegularExpressions;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public class CustodySecurityModel : VsdCustomerStock
    {
        public CustodySecurityModel()
        {
            SettlementDate = DateTime.Now;
            SubType = AssetSubType.CommonStock;
        }
        
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(1)]
        public ActivityType ActivityType { get; set; }
        [ProtoMember(2)]
        public string CountryCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(3)]
        public UnitType UnitType { get; set; }
        [ProtoMember(4)] 
        public DateTime? BirthDay { get; set; }
        [ProtoMember(5)]
        public string NationalityCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(6)]
        public CardType CardType { get; set; }
        [ProtoMember(7)]
        public string CardIdentity { get; set; }
        [ProtoMember(8)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(9)]
        public string CardIssuer { get; set; }
        [ProtoMember(10)]
        public DateTime? SettlementDate { get; set; }  
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Quantity), "CustodyModel_Quantity_Validation", () => Quantity > 0 && Regex.IsMatch(Quantity.ToString(), Helper.NumberOnly));
        }
    }
}