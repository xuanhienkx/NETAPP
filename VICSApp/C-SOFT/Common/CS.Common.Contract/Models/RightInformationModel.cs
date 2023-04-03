using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class RightInformationModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        public long PageNumber { get; set; }
        [ProtoMember(2)]
        public string PageCodeInfo { get; set; }
        [ProtoMember(3)]
        public string RightCode { get; set; }
        [ProtoMember(4)]
        public string ReferenceNumber { get; set; }
        [ProtoMember(5)]
        public string FunctionMessage { get; set; }
        [ProtoMember(6)]
        public TypeOfRightInfo TypeOfRight { get; set; }
        [ProtoMember(7)]
        public DateTime? NoticeDate { get; set; }
        [ProtoMember(8)]
        public string Status { get; set; }
        [ProtoMember(9)]
        public string StockCode { get; set; }
        [ProtoMember(10)]
        public string CountryCode { get; set; }
        [ProtoMember(11)]
        public string IsinCode { get; set; }
        [ProtoMember(12)]
        public AssetSubType SecurityType { get; set; }
        [ProtoMember(13)]
        public ActivityType ActivityType { get; set; }
        [ProtoMember(14)]
        public DateTime? ExecutionDate { get; set; }
        [ProtoMember(15)]
        public string OwnerPartyBicode { get; set; }
        [ProtoMember(16)]
        public string AccountType { get; set; }
        [ProtoMember(17)]
        public string MedialIsinCode { get; set; }
        [ProtoMember(18)]
        public string MedialCountryCode { get; set; }
        [ProtoMember(19)]
        public string MedialStockCode { get; set; }
        [ProtoMember(20)]
        public UnitType UnitType { get; set; }
        [ProtoMember(21)]
        public long Quantity { get; set; }
        [ProtoMember(22)]
        public string BalanceUnit { get; set; }
        [ProtoMember(23)]
        public string BalanceElig { get; set; }
        [ProtoMember(24)]
        public string BalanceOptionFlag { get; set; }
        [ProtoMember(25)]
        public long Amount { get; set; }
        [ProtoMember(26)]
        public RoundType MedialRoundType { get; set; }
        [ProtoMember(27)]
        public RightBuyType MedialRightBuyType { get; set; }
        [ProtoMember(28)]
        public long IntermediateSecurities { get; set; }
        [ProtoMember(29)]
        public long Underlying { get; set; }
        [ProtoMember(30)]
        public string Market { get; set; }
        [ProtoMember(31)]
        public string CurrencyCode { get; set; }
        [ProtoMember(32)]
        public long MarketPrice { get; set; }
        [ProtoMember(33)]
        public DateTime? ExpirationDateSubscription { get; set; }
        [ProtoMember(34)]
        public DateTime? ClosingBalanceDate { get; set; }
        [ProtoMember(35)]
        public DateTime? TradingPriodFrom { get; set; }
        [ProtoMember(36)]
        public DateTime? TradingPriodTo { get; set; }
        [ProtoMember(37)]
        public DateTime? LastDateRegister { get; set; }
        [ProtoMember(38)]
        public DateTime? MeetingDate { get; set; }
        [ProtoMember(39)]
        public DateTime? EffectiveDate { get; set; }
        [ProtoMember(40)]
        public DateTime? PaymentDate { get; set; }
        [ProtoMember(41)]
        public DateTime? CompulsoryPurchaseFrom { get; set; }
        [ProtoMember(42)]
        public DateTime? CompulsoryPurchaseTo { get; set; }
        [ProtoMember(43)]
        public string MeetingPlace { get; set; }
        [ProtoMember(44)]
        public string Narrative { get; set; }
        [ProtoMember(45)]
        public string IdentificationNumber { get; set; }
        [ProtoMember(46)]
        public RoundType OptionRoundType { get; set; }
        [ProtoMember(47)]
        public RightBuyType OptionRightBuyType { get; set; }
        [ProtoMember(48)]
        public string DefaultProcessingFlag { get; set; }
        [ProtoMember(49)]
        public DateTime? DeadlinePassOwnershipList { get; set; }
        [ProtoMember(50)]
        public DateTime? DeadlinePayment { get; set; }
        [ProtoMember(51)] 
        public RateOption RateOptionType { get; set; }
        [ProtoMember(52)] 
        public string RateOptionTypeFlag { get; set; }
        [ProtoMember(53)] 
        public string RateValue { get; set; }
        [ProtoMember(54)] 
        public PriceRateType PriceRateType { get; set; }
        [ProtoMember(55)] 
        public decimal Denominations { get; set; }
        [ProtoMember(56)] 
        public UnitType OptionUnitType { get; set; }
        [ProtoMember(57)] 
        public long OptionQuantity { get; set; }
        [ProtoMember(58)] 
        public string OptionNarrative { get; set; }
        [ProtoMember(59)] 
        public string Description { get; set; }
    }
}
