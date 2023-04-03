using System.Runtime.Serialization;

namespace DO.Common.Contract.Enums
{
    public enum UnitType : byte
    {
        /// <summary>
        /// Sử dụng cho cổ phiếu, chứng chỉ quỹ.
        /// </summary>
        [EnumMember(Value = "UNIT")] StockUnit,
        /// <summary>
        /// Sử dụng cho trái phiếu.
        /// </summary>
        [EnumMember(Value = "FAMT")] BondsUnit,
    }

    public enum RightBuyType : byte
    {
        /// <summary>
        /// Quyền mua không được chuyển nhượng.
        /// </summary>
        [EnumMember(Value = "NREN")] NonRightTransferable,
        /// <summary>
        /// Quyền mua được chuyển nhượng.
        /// </summary>
        [EnumMember(Value = "RENO")] RightAreTransferred,
    }
    public enum RateOption : byte
    {
        /// <summary>
        /// GRSS: Cổ tức không khấu trừ thuế tại TCPH
        /// </summary>
        [EnumMember(Value = "GRSS")] DividendsNoTax,
        /// <summary>
        ///  NETT: Cổ tức khấu trừ thuế tại TCPH 
        /// </summary>
        [EnumMember(Value = "NETT")] DividendsTax,
        /// <summary>
        ///  INTP: Lãi suất thanh toán
        /// </summary>
        [EnumMember(Value = "INTP")] Interest
    }

    public enum PriceRateType : byte
    {
        /// <summary>
        /// Tỷ lệ (trên mệnh giá) thanh toán cho cổ phiếu lẻ.
        /// </summary>
        [EnumMember(Value = "PRCT")] RatioPerPriceValue
    }
}