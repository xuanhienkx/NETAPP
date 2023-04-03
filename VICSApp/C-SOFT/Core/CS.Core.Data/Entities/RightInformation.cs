using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("RightInformations")]
    public class RightInformation : IdentityEntityBase, ICommonEntity<long>
    {
        public long PageNumber { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string PageCodeInfo { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string RightCode { get; set; }
        [Column(TypeName = "varchar(16)")]
        public string ReferenceNumber { get; set; } 
        public TypeOfRightInfo TypeOfRight { get; set; }
        public DateTime? NoticeDate { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string Status { get; set; }
        [Column(TypeName = "varchar(35)")]
        public string StockCode { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string CountryCode { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string IsinCode { get; set; }       
        public AssetSubType SecurityType { get; set; }       
        public ActivityType ActivityType { get; set; }       
        public DateTime? ExecutionDate { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string OwnerPartyBicode { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string AccountType { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string MedialIsinCode { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string MedialCountryCode { get; set; }
        [Column(TypeName = "varchar(35)")]
        public string MedialStockCode { get; set; }
        public UnitType UnitType { get; set; }       
        public long Quantity { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string BalanceUnit { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string BalanceElig { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string BalanceOptionFlag { get; set; }       
        public long Amount { get; set; }       
        public RoundType MedialRoundType { get; set; }       
        public RightBuyType MedialRightBuyType { get; set; }       
        public long IntermediateSecurities { get; set; }       
        public long Underlying { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string Market { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string CurrencyCode { get; set; }       
        public long MarketPrice { get; set; }       
        public DateTime? ExpirationDateSubscription { get; set; }       
        public DateTime? ClosingBalanceDate { get; set; }       
        public DateTime? TradingPriodFrom { get; set; }       
        public DateTime? TradingPriodTo { get; set; }       
        public DateTime? LastDateRegister { get; set; }       
        public DateTime? MeetingDate { get; set; }       
        public DateTime? EffectiveDate { get; set; }       
        public DateTime? PaymentDate { get; set; }       
        public DateTime? CompulsoryPurchaseFrom { get; set; }       
        public DateTime? CompulsoryPurchaseTo { get; set; }  
        [MaxLength(100)]
        public string MeetingPlace { get; set; }
        [MaxLength(350)]
        public string Narrative { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string IdentificationNumber { get; set; }
        public RoundType OptionRoundType { get; set; }
        public RightBuyType OptionRightBuyType { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string DefaultProcessingFlag { get; set; }
        public DateTime? DeadlinePassOwnershipList { get; set; }
        public DateTime? DeadlinePayment { get; set; }     
        public RateOption RateOptionType { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string RateOptionTypeFlag { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string RateValue { get; set; }
       // [Column(TypeName = "varchar(4)")]
        public PriceRateType PriceRateType { get; set; }
        public decimal Denominations { get; set; }
        public UnitType OptionUnitType { get; set; }
        public long OptionQuantity { get; set; }
        [MaxLength(100)]
        public string OptionNarrative { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }


    }     

}