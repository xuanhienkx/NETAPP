using System.Runtime.Serialization;

namespace CS.Common.Contract.Enums
{
    public enum SettlementType : byte
    {
        /// <summary>
        /// chuyển khoản lô lẻ , hoặc ký gửi rút chứng khoán
        /// </summary>
        [EnumMember(Value = "TRAD")] TransactionStandard,
        /// <summary>
        /// Chuyển khoản cùng TVLK
        /// </summary>
        [EnumMember(Value = "OWNI")] TransactionOnOneMember,
        /// <summary>
        /// Chuyển khoản khác TVLK
        /// </summary>
        [EnumMember(Value = "OWNE")] TransactionWithOtherMember,
        /// <summary>
        /// Chuyển khoản toàn bộ và tất toán đóng tài khoản.
        /// </summary>
        [EnumMember(Value = "TBAC")] MoveAllStockAndCloseAcount,
        /// <summary>
        /// Chuyển khoản toàn bộ nhưng không đóng tài khoản
        /// </summary>
        [EnumMember(Value = "TWAC")] MoveAllStockAndNotCloseAcount,
    }
}