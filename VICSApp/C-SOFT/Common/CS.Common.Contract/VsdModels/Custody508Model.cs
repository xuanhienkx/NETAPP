using System;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class Custody508Model 
    {
        [ProtoMember(1)]
        public long? PledgReferenceNumber { get; set; }
        [ProtoMember(2)]
        public string CustomerNumber { get; set; }
        [ProtoMember(3)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(4)]
        public string StockCountryCode { get; set; }
        [ProtoMember(5)]
        public string Code { get; set; }
        [ProtoMember(6)]
        public string IsinCode { get; set; }
        [ProtoMember(7)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitType UnitType { get; set; }
        [ProtoMember(8)]
        public long Quantity { get; set; }
        [ProtoMember(9)]
        public string BankCode { get; set; }
        [ProtoMember(10)]
        public string ContractNumber { get; set; }
        [ProtoMember(11)]
        public DateTime? ContractDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(12)]
        public AssetSubType SubType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(13)]
        public PledgeReleasingType FromBalance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(14)]
        public PledgeReleasingType ToBalance { get; set; }
        [ProtoMember(15)]
        public string Notes { get; set; }  
    }
}