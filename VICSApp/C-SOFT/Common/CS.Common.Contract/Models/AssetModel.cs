using System;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AssetModel : DataContract, IReversionResource<long>, ICommonResource<long>
    {
        public AssetModel() : this(AssetType.Stock)
        { }

        public AssetModel(AssetType type)
        {
            Type = type;
        }
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string Code { get; set; }
        [ProtoMember(3)]
        public string IsinCode { get; set; }
        [ProtoMember(4)]
        public AssetType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(5)]
        public AssetSubType SubType { get; set; }
        [ProtoMember(6)]
        public decimal TotalIssue { get; set; }
        [ProtoMember(7)]
        public decimal ParValue { get; set; }
        [ProtoMember(8)]
        public decimal Rational { get; set; }
        [ProtoMember(9)]
        public decimal Value { get; set; }
        [ProtoMember(10)]
        public string CountryCode { get; set; }
        [ProtoMember(11)]
        public decimal ForginRate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(12)]
        public BoardType BoardType { get; set; }
        [ProtoMember(13)]
        public string BoardName { get; set; }
        [ProtoMember(14)]
        public string Name { get; set; }
        [ProtoMember(15)]
        public string NameLocal { get; set; }
        [ProtoMember(16)]
        public string Phone { get; set; }
        [ProtoMember(17)]
        public string Fax { get; set; }
        [ProtoMember(18)]
        public int Version { get; set; }
        [ProtoMember(19)]
        public bool IsActive { get; set; }
        [ProtoMember(20)]
        public DateTime? TradeDate { get; set; }
    }
}