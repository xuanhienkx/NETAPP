using System;
using System.Text.RegularExpressions;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    public interface IVsdCommon { }
    [ProtoContract]
    [Serializable]
    [ProtoInclude(100, typeof(VsdCustomerStock))]
    [ProtoInclude(600, typeof(Custody598FinalSettAccountModel))]
    public abstract class VsdCustomer : DataContract, IVsdCommon
    {
        [ProtoMember(1)]
        public string CustomerNumber { get => Get<string>(); set => Set(value); }
        [ProtoMember(2)]
        public string CustomerName { get; set; }
        [ProtoMember(3)]
        public Guid Id { get; set; }
        [ProtoMember(4)]
        public int Version { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(CustomerNumber), "CustodyModel_CustomerNumber_Validation",
                () => !string.IsNullOrEmpty(CustomerNumber));
        }
    }
    [ProtoContract]
    [Serializable]
    [ProtoInclude(101, typeof(CustodySecurityModel))]
    [ProtoInclude(102, typeof(Custody524Model))]
    [ProtoInclude(103, typeof(Custody542Model))] 
    [ProtoInclude(300, typeof(BaseVsdCustomerStockRequest))]
    public abstract class VsdCustomerStock : VsdCustomer
    {
        protected VsdCustomerStock()
        {
            SubType = AssetSubType.CommonStock;
        }
        [ProtoMember(1)]
        public string Code { get; set; }
        [ProtoMember(2)]
        public string StockName { get; set; }
        [ProtoMember(3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AssetSubType SubType { get; set; }
        [ProtoMember(4)]
        public string StockCountryCode { get; set; }
        [ProtoMember(5)]
        public long Quantity { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Quantity), "CustodyModel_Quantity_Validation", () => Quantity > 0 && Regex.IsMatch(Quantity.ToString(), Helper.NumberOnly));
            rules.Add(nameof(Code), "CustodyModel_StockCode_Validation", () => !string.IsNullOrEmpty(Code));
            rules.Add(nameof(SubType), "CustodyModel_SubType_Validation", () => SubType != AssetSubType.None); 
        }
    }
    [Serializable]
    [ProtoContract]
    public class Custody524Model : VsdCustomerStock
    {
        public Custody524Model()
        {
            FromBalance = PledgeReleasingType.Pledging;
            SubType = AssetSubType.CommonStock;
            ContractDate = DateTime.Now;
            SettlementDate = DateTime.Now;
        }
        [ProtoMember(1)]
        public string LinkMessageId { get; set; }
        [ProtoMember(2)]
        public long? PledgReferenceNumber { get; set; }
        [ProtoMember(3)]
        public long? OutReferenceNumberBefore { get; set; }
        [ProtoMember(4)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(5)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitType UnitType { get; set; }
        [ProtoMember(6)]
        public string BankCode { get; set; }
        [ProtoMember(7)]
        public string ContractNumber { get; set; }
        [ProtoMember(8)]
        public DateTime? ContractDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(9)]
        public PledgeReleasingType FromBalance { get; set; }
        [ProtoMember(10)]
        public string BankName { get; set; }
        [ProtoIgnore]
        [JsonConverter(typeof(StringEnumConverter))]
        public PledgeReleasingType ToBalance =>
            FromBalance == PledgeReleasingType.Pledging
                ? PledgeReleasingType.Releasing
                : PledgeReleasingType.Pledging;

        protected override void SetupRules(RuleCollection rules)
        {  
            rules.Add(nameof(ContractNumber), $"Custody524Model_ContractNumber_Validation", () => !string.IsNullOrEmpty(ContractNumber));
            base.SetupRules(rules);
        }
    }
}