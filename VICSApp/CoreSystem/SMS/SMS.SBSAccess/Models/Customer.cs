using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    public class Customer
    {
        [Required]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [StringLength(15)]
        public string ContractNumber { get; set; }

        [StringLength(10)]
        public string CustomerId { get; set; }

        public int BrokerId { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(100)]
        public string CustomerNameViet { get; set; }

        [StringLength(1)]
        public string CustomerType { get; set; }

        [StringLength(1)]
        public string DomesticForeign { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Dob { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [Column(TypeName = "image")]
        public byte[] SignatureImage1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] SignatureImage2 { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OpenDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CloseDate { get; set; }

        public int CardType { get; set; }

        [Required]
        [StringLength(20)]
        public string CardIdentity { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CardDate { get; set; }

        [StringLength(200)]
        public string CardIssuer { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string AddressViet { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string Mobile2 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? UserCreate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateCreate { get; set; }

        public int? UserModify { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateModify { get; set; }

        public bool ProxyStatus { get; set; }

        [StringLength(1)]
        public string AccountStatus { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        [StringLength(200)]
        public string WorkingAddress { get; set; }

        public int? UserIntroduce { get; set; }

        public int AttitudePoint { get; set; }

        public int DepositPoint { get; set; }

        public int ActionPoint { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        [StringLength(2)]
        public string AccountType { get; set; }

        [StringLength(3)]
        public string OrderType { get; set; }

        [StringLength(2)]
        public string ReceiveReport { get; set; }

        [StringLength(2)]
        public string ReceiveReportBy { get; set; }

        [StringLength(1)]
        public string MarriageStatus { get; set; }

        [StringLength(1)]
        public string KnowledgeLevel { get; set; }

        [StringLength(1)]
        public string Job { get; set; }

        [StringLength(50)]
        public string OfficeFunction { get; set; }

        [StringLength(20)]
        public string OfficeTel { get; set; }

        [StringLength(20)]
        public string OfficeFax { get; set; }

        [StringLength(100)]
        public string HusbandWifeName { get; set; }

        [StringLength(20)]
        public string HusbandWifeCardNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? HusbandWifeCardDate { get; set; }

        [StringLength(150)]
        public string HusbandWifeCardLocation { get; set; }

        [StringLength(50)]
        public string HusbandWifeTel { get; set; }

        [StringLength(50)]
        public string HusbandWifeEmail { get; set; }

        [StringLength(4)]
        public string JoinStockMarket { get; set; }

        [StringLength(1)]
        public string InvestKnowledge { get; set; }

        [StringLength(5)]
        public string InvestedIn { get; set; }

        [StringLength(1)]
        public string InvestTarget { get; set; }

        [StringLength(1)]
        public string RiskAccepted { get; set; }

        [StringLength(1)]
        public string InvestFund { get; set; }

        [StringLength(100)]
        public string DelegatePersonName { get; set; }

        [StringLength(50)]
        public string DelegatePersonFunction { get; set; }

        [StringLength(20)]
        public string DelegatePersonCardNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DelegateCardDate { get; set; }

        [StringLength(50)]
        public string DelegateCardLocation { get; set; }

        [StringLength(20)]
        public string DelegatePersonTel { get; set; }

        [StringLength(100)]
        public string DelegatePersonEmail { get; set; }

        [StringLength(100)]
        public string ChiefAccountancyName { get; set; }

        [StringLength(20)]
        public string ChiefAccountancyCI { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ChiefAccountancyCD { get; set; }

        [StringLength(20)]
        public string ChiefAccountancyIssuer { get; set; }

        [Column(TypeName = "image")]
        public byte[] ChiefAccountancySign1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] ChiefAccountancySign2 { get; set; }

        [StringLength(100)]
        public string CaProxyName { get; set; }

        [StringLength(20)]
        public string CaProxyCI { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CaProxyCD { get; set; }

        [StringLength(20)]
        public string CaProxyIssuer { get; set; }

        [Column(TypeName = "image")]
        public byte[] CaProxySign1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CaProxySign2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CompanySign1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CompanySign2 { get; set; }

        [StringLength(30)]
        public string TradeCode { get; set; }

        public int CustomerAccount { get; set; }

        [StringLength(20)]
        public string MobileSms { get; set; }

        public bool IsHere { get; set; }

        [StringLength(50)]
        public string MoneyDepositeNumber { get; set; }

        [StringLength(200)]
        public string MoneyDepositeLocation { get; set; }

        public int? DepartmentId { get; set; }

        [Column(TypeName = "ntext")]
        public string PublicCompanyManage { get; set; }

        [Column(TypeName = "ntext")]
        public string PublicCompanyHolder { get; set; }

        [StringLength(50)]
        public string ParentCompanyName { get; set; }

        [StringLength(100)]
        public string ParentCompanyAddress { get; set; }

        [StringLength(50)]
        public string ParentCompanyEmail { get; set; }

        [StringLength(20)]
        public string ParentCompanyTel { get; set; }

        public short PostType { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ReOpenDate { get; set; }

        public int? UserTakeCared { get; set; }
    }
}