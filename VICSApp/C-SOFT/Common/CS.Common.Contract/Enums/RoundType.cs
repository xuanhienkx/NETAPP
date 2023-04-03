using System.Runtime.Serialization;

namespace CS.Common.Contract.Enums
{
    public enum RoundType : byte
    {
        /// <summary>
        /// Không xác định nguyên tắc làm tròn
        /// </summary>
        [EnumMember(Value = "UKWN")] Unknown,
        /// <summary>
        /// Phần lẻ cũng được phân bổ, Không làm tròn
        /// </summary>
        [EnumMember(Value = "DIST")] None,
        /// <summary>
        /// Cổ phiếu lẻ qui đổi thành tiền
        /// </summary>
        [EnumMember(Value = "CINL")] StockToMany,
        /// <summary>
        /// Làm tròn xuống
        /// </summary>
        [EnumMember(Value = "RDDN")] RoundDown,
        /// <summary>
        /// Làm tròn lên
        /// </summary>
        [EnumMember(Value = "RDUP")] RoundUp,
        /// <summary>
        /// Phần lẻ lớn hơn hoặc bằng 0.5 được làm tròn lên, ngược lại sẽ làm tròn xuống
        /// </summary>
        [EnumMember(Value = "STAN")] RoundStandard,

    }
}