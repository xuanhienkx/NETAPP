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
    [ProtoInclude(350,typeof(Custody542TranferModel))]
    public class Custody542Model : VsdCustomerStock
    {
        public Custody542Model()
        {
            SettlementDate = DateTime.Now;
            SubType = AssetSubType.CommonStock;
        }
        /// <summary>
        /// RightPandingRefNumber
        /// Sử dụng cho trường hợp lưu ký chứng khoán chờ giao dịch.
        /// Giá trị trường này lưu số hiệu tham chiếu của đợt sự kiện liên quan đến chứng khoán chờ giao dịch  
        /// </summary>
        [ProtoMember(1)]
        public string RightPandingRefNumber { get; set; }
        [ProtoMember(2)]
        public DateTime? SettlementDate { get; set; }  
        [ProtoMember(3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitType UnitType { get; set; }
        [ProtoMember(4)]
        public string VsdBicode { get; set; }
        [ProtoMember(5)]
        public string InfoNotes { get; set; }
        [ProtoMember(6)]
        public string TransactionNotes { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(7)]
        public SettlementType SettlementType { get=>Get<SettlementType>(); set=>Set(value); }

        [ProtoMember(8)]
        public string SettlementCondition { get; set; }
        [ProtoMember(9)]
        public string SettlementNotes { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(10)]
        public CardType CardType { get; set; }
        [ProtoMember(11)]
        public string CardIdentity { get; set; }
        [ProtoMember(12)]
        public DateTime CardIssuedDate { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(13)]
        public ActivityType ActivityType { get; set; } 
        protected override void SetupRules(RuleCollection rules)
        {
            base.SetupRules(rules);
        }
    }
}