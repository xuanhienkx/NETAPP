using System.Runtime.Serialization;

namespace DO.Common.Contract.Enums
{
    public enum BoardType : byte
    {
        [EnumMember(Value = "HSTC")] Hnx = 1,//Ha Noi
        [EnumMember(Value = "XSTC")] Hose = 2,//HCM
        [EnumMember(Value = "XHNX")] Upcom = 3,//UPCOM
        [EnumMember(Value = "OTCO")] Dccny = 7,// OTC
        [EnumMember(Value = "BOND")] Bond = 4,//Trai phieu
        [EnumMember(Value = "BUSD")] UsdBond = 5,//USDBOND (sàn 0005-USDBOND)
        [EnumMember(Value = "BTNP")] Btnp = 6//BOND_TP (sàn 0006-BOND_TP)
    }

    public enum ConfirmType
    {
        /// <summary>
        /// Xác nhận
        /// </summary>
        [EnumMember(Value = "CONF")] Confirm,
        /// <summary>
        /// Từ chối
        /// </summary>
        [EnumMember(Value = "REJT")] Rejected
    }
    public enum SubMessageType
    {
        [EnumMember(Value = "001")]
        OpenCloseRequest = 1,
        [EnumMember(Value = "002")]
        OpenCloseRespose = 2,
        [EnumMember(Value = "003")]
        ReportsRequested = 3,
        [EnumMember(Value = "005")]
        AprovalConfirm = 5,
        [EnumMember(Value = "006")]
        RejectedConfirm = 6,
        [EnumMember(Value = "007")]
        InfoRespose = 7,
    }
    public enum MarketType
    {
        [EnumMember(Value = "001")]
        PRS = 1,
        [EnumMember(Value = "002")]
        INFOGATE = 2,
        [EnumMember(Value = "003")]
        INDEX = 3,
    }
}