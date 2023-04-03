using System.ComponentModel;
using System.Runtime.Serialization;

namespace CS.Common.Contract.Enums
{
    public enum TypeOfRightInfo
    {

        /// <summary>
        ///Hoán đổi từ cổ phiếu này sang cổ phiếu khác.
        /// </summary>
        [EnumMember(Value = "OTHR")]
        [Description("Hoán đổi cổ phiếu")]   
        Other,
        /// <summary>
        /// Thông báo đại hội cổ đông thường niên
        /// </summary>
        [Description("Thông báo DHCDNT")]
        [EnumMember(Value = "MEET")] 
        ShareHolderMeeting,

        /// <summary>
        /// Thông báo đại hội cổ đông bất thường
        /// </summary>
        [EnumMember(Value = "XMET")]
        [Description("Thông báo DHCD Bất thường")]
        ExtraordinaryShareHolderMeeting,

        /// <summary>
        /// Chia cổ tức bằng tiền mặt
        /// </summary>
        [EnumMember(Value = "DVCA")]
        [Description("Chia cổ tức bằng tiền mặt")]
        CashDividend,

        /// <summary>
        /// Chia cổ tức bằng cổ phiếu
        /// </summary>
        [EnumMember(Value = "DVSE")]
        [Description("Chia cổ tức bằng cổ phiếu")]
        StockDividend,

        /// <summary>
        /// Quyền mua thêm chứng khoán
        /// </summary>
        [EnumMember(Value = "RHTS")]
        [Description("Quyền mua thêm chứng khoán")]
        RightBuySecurities,
        /// <summary>
        ///Hoán đổi trái phiếu thành cổ phiếu
        /// </summary>
        [EnumMember(Value = "CONV")]
        [Description("Hoán đổi trái phiếu thành cổ phiếu")]
        SwapBonds,

        /// <summary>
        ///Thanh toán Vốn gốc trái phiếu
        /// </summary>
        [EnumMember(Value = "REDM")] 
        [Description("Thanh toán Vốn gốc trái phiếu")] 
        PaymentPrincipalBonds,
        /// <summary>
        ///Thanh toán Lãi trái phiếu
        /// </summary>
        [EnumMember(Value = "INTR")]
        [Description("Thanh toán Lãi trái phiếu")]
        PaymentInterestBonds,


        /// <summary>
        ///Thanh toán Vốn gốc + Lãi trái phiếu
        /// </summary>
        [EnumMember(Value = "PRII")]
        [Description("Thanh toán Vốn gốc + Lãi trái phiếu")]
        PrincipalPaymentAndBondInterest,

        /// <summary>
        ///Thưởng cổ phiếu
        /// </summary>
        [EnumMember(Value = "BONU")]
        [Description("Thưởng cổ phiếu")]
        StockRating
    }
}