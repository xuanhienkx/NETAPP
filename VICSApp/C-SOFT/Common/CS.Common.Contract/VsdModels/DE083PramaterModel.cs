using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    #region Interface Vsd Report paramater define  
    public interface IReportRequest
    {
        string ReportCode { get; set; }
        string ReportName { get; set; }
    }
    public interface IVsdReportRight : IReportRequest
    {
        string RightNumber { get; set; }
    } 
     
    public interface ICleadingReportRquest : IReportRequest
    {
        string MemberCode { get; }
        DateTime ReportDate { get; set; }
        string Period { get; }

    }

    #endregion

    #region Tham số Danh sách báo cáo nghiệp vụ lưu ký

    [ProtoContract]
    [Serializable]
    public class DE013PramaterModel : BaseDEPramaterModel
    {
        public DE013PramaterModel()
        {
            ReportCode = "DE013";
        }
        [ProtoMember(1)]
        public string StockCode { get; set; }
        [ProtoMember(2)]
        public string RefDocNumber { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(StockCode), "Paramater_StockCode_Validation", () => !string.IsNullOrEmpty(StockCode));
            rules.Add(nameof(RefDocNumber), "Paramater_RefDocNumber_Validation", () => !string.IsNullOrEmpty(RefDocNumber));
        }
    }
    [ProtoContract]
    [Serializable]
    public class DE065PramaterModel : BaseDEPramaterModel
    {
        public DE065PramaterModel()
        {
            ReportCode = "DE065";
        }
        [ProtoMember(1)]
        public string RefDocNumber { get; set; }
        [ProtoMember(2)]
        public string StockCodeFrom { get; set; }
        [ProtoMember(3)]
        public string StockCodeTo { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(StockCodeFrom), "Paramater_CodeFrom_Validation", () => !string.IsNullOrEmpty(StockCodeFrom));
            rules.Add(nameof(StockCodeTo), "Paramater_CodeTo_Validation", () => !string.IsNullOrEmpty(StockCodeTo));
        }
    }

    [ProtoContract]
    [Serializable]
    public class DE083PramaterModel : BaseDEPramaterModel
    {
        public DE083PramaterModel()
        {
            ReportCode = "DE083";
        }
        [ProtoMember(1)]
        public string StockCodeFrom { get; set; }
        [ProtoMember(2)]
        public string StockCodeTo { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(StockCodeFrom), "Paramater_CodeFrom_Validation", () => !string.IsNullOrEmpty(StockCodeFrom));
            rules.Add(nameof(StockCodeTo), "Paramater_CodeTo_Validation", () => !string.IsNullOrEmpty(StockCodeTo));
        }
    }
    [ProtoContract]
    [Serializable]
    [ProtoInclude(100, typeof(DE084PramaterModel))]
    [ProtoInclude(200, typeof(DE083PramaterModel))]
    [ProtoInclude(300, typeof(DE013PramaterModel))]
    [ProtoInclude(400, typeof(DE065PramaterModel))]
    public abstract class BaseDEPramaterModel : DataContract, IReportRequest
    {
        protected BaseDEPramaterModel()
        {
            ReportDate = DateTime.Now;
            BoardType = BoardType.Hnx;
        }
        [ProtoMember(1)]
        public string ReportCode { get; set; }
        [ProtoMember(2)]
        public string ReportName { get; set; }
        [ProtoMember(3)]
        public BoardType BoardType { get; set; }
        [ProtoMember(4)]
        public DateTime ReportDate { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(ReportCode), "Paramater_ReportCode_Validation", () => !string.IsNullOrEmpty(ReportCode));
            rules.Add(nameof(BoardType), "Paramater_BoardType_Validation", () => BoardType > 0);
        }
    }
    [ProtoContract]
    [Serializable]
    public class DE084PramaterModel : BaseDEPramaterModel
    {
        public DE084PramaterModel()
        {
            ReportCode = "DE084";
        }
        [ProtoMember(1)]
        public string StockCode { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(StockCode), "Paramater_StockCode_Validation", () => !string.IsNullOrEmpty(StockCode));
        }
    }


    #endregion

    #region Tham Số Danh sách báo cáo nghiệp vụ thực hiện quyền

    [ProtoContract]
    [Serializable]
    public class CA001PramaterModel : BaseRightPramaterModel
    {
        public CA001PramaterModel()
        {
            ReportCode = "CA001";
        }
    }

    [ProtoContract]
    [Serializable]
    public class CA005PramaterModel : BaseRightPramaterModel
    {
        public CA005PramaterModel()
        {
            ReportCode = "CA005";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CA009PramaterModel : BaseRightPramaterModel
    {
        public CA009PramaterModel()
        {
            ReportCode = "CA009";
        }

    }
    [ProtoContract]
    [Serializable]
    public class CA012PramaterModel : BaseRightPramaterModel
    {
        public CA012PramaterModel()
        {
            ReportCode = "CA012";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CA014PramaterModel : BaseRightPramaterModel
    {
        public CA014PramaterModel()
        {
            ReportCode = "CA014";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CA031PramaterModel : BaseRightPramaterModel
    {
        public CA031PramaterModel()
        {
            ReportCode = "CA031";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CA069PramaterModel : BaseRightPramaterModel
    {
        public CA069PramaterModel()
        {
            ReportCode = "CA069";
        }
        [ProtoMember(3)]
        public string ReportByCode { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(ReportByCode), "Paramater_ReportByCode_Validation", () => !string.IsNullOrEmpty(ReportByCode));
        }
    }

    [ProtoContract]
    [Serializable]
    [ProtoInclude(100, typeof(CA001PramaterModel))]
    [ProtoInclude(200, typeof(CA005PramaterModel))]
    [ProtoInclude(300, typeof(CA009PramaterModel))]
    [ProtoInclude(400, typeof(CA012PramaterModel))]
    [ProtoInclude(500, typeof(CA014PramaterModel))]
    [ProtoInclude(600, typeof(CA031PramaterModel))]
    [ProtoInclude(700, typeof(CA069PramaterModel))]
    public abstract class BaseRightPramaterModel : DataContract, IVsdReportRight
    {
        protected BaseRightPramaterModel()
        {
            BoardType = BoardType.Hnx;
        }
        [ProtoMember(1)]
        public BoardType BoardType { get; set; }
        [ProtoMember(2)]
        public string RightNumber { get; set; }
        [ProtoMember(3)]
        public string ReportCode { get; set; }
        [ProtoMember(4)]
        public string ReportName { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(RightNumber), "Paramater_RightNumber_Validation", () => !string.IsNullOrEmpty(RightNumber));
            rules.Add(nameof(ReportCode), "Paramater_ReportCode_Validation", () => !string.IsNullOrEmpty(ReportCode));
            rules.Add(nameof(BoardType), "Paramater_BoardType_Validation", () => BoardType > 0);
        }
    }



    #endregion

    #region Tham số Danh sách báo cáo nghiệp vụ thanh toán bù trừ  

    [ProtoContract]
    [Serializable] 
    public abstract class ClearingAndSettlementReportRquest : ClearingAndSettlementAllBoardRequet
    {
        [ProtoMember(1)]
        public BoardType BoardType { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(BoardType), "Paramater_BoardType_Validation", () => BoardType > 0);
        }
    }

    [ProtoContract]
    [Serializable]
    [ProtoInclude(101, typeof(CS091PramaterModel))]
    [ProtoInclude(102, typeof(CS092PramaterModel))]
    [ProtoInclude(103, typeof(CS007PramaterModel))]
    [ProtoInclude(104, typeof(CS008PramaterModel))]
    [ProtoInclude(105, typeof(CS077PramaterModel))]
    [ProtoInclude(106, typeof(CS078PramaterModel))]
    [ProtoInclude(107, typeof(CS079PramaterModel))]
    [ProtoInclude(108, typeof(CS082PramaterModel))]
    [ProtoInclude(109, typeof(CS083PramaterModel))]
    public abstract class ClearingAndSettlementAllBoardRequet : DataContract, ICleadingReportRquest
    {
        protected ClearingAndSettlementAllBoardRequet()
        {
            //MemberCode and Period maybe add config later
            MemberCode = "076";
            Period = "2";
            ReportDate = DateTime.Now;
        }
        [ProtoIgnore]
        public string MemberCode { get; }
        [ProtoIgnore]
        public string Period { get; }
        [ProtoMember(1)]
        public DateTime ReportDate { get; set; }
        [ProtoMember(2)]
        public string ReportCode { get; set; }
        [ProtoMember(3)]
        public string ReportName { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(ReportDate), "Paramater_ReportDate_Validation", () => ReportDate > DateTime.MinValue && ReportDate <= DateTime.Now);
            rules.Add(nameof(ReportCode), "Paramater_ReportCode_Validation", () => string.IsNullOrEmpty(ReportCode));
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS077PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS077PramaterModel()
        {
            ReportCode = "CS077";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS078PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS078PramaterModel()
        {
            ReportCode = "CS077";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS079PramaterModel : ClearingAndSettlementReportRquest
    {
        public CS079PramaterModel()
        {
            ReportCode = "CS079";
        } 
    }
    [ProtoContract]
    [Serializable]
    public class CS082PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS082PramaterModel()
        {
            ReportCode = "CS082";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS083PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS083PramaterModel()
        {
            ReportCode = "CS083";
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS091PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS091PramaterModel()
        {
            ReportCode = "CS091";
        }
        [ProtoMember(1)]
        public string ReportByCode { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(ReportByCode), "Paramater_ReportByCode_Validation", () => !string.IsNullOrEmpty(ReportByCode));
        }
    }
    [ProtoContract]
    [Serializable]
    public class CS092PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS092PramaterModel()
        {
            ReportCode = "CS092";
        }
    }
    [ProtoContract]
    [Serializable] 
    public class CS007PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS007PramaterModel()
        {
            ReportCode = "CS007";
        }
         
    }
    [ProtoContract]
    [Serializable]
    public class CS008PramaterModel : ClearingAndSettlementAllBoardRequet
    {
        public CS008PramaterModel()
        {
            ReportCode = "CS008";
        }
    }

    #endregion
}
