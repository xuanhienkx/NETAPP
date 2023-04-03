using System.Runtime.Serialization;

namespace DO.Common.Contract.Enums
{
    public enum AssetSubType : byte
    {
        [EnumMember(Value = "0")] None = 0,
        /// <summary>
        /// CK phổ thông:
        /// </summary>
        [EnumMember(Value = "1")] CommonStock = 1,
        /// <summary>
        /// CK HCCN
        /// </summary>
        [EnumMember(Value = "2")] RestictedStock = 2,
        /// <summary>
        /// CK ưu đãi biểu quyết
        /// </summary>
        [EnumMember(Value = "3")] PreferentialVotingStock = 3,
        /// <summary>
        /// CK ưu đãi ctuc ko bq
        /// </summary>
        [EnumMember(Value = "4")] PreferentialDividendUnVoteStock = 4,
        /// <summary>
        /// CK ưu đãi hoàn lại ko bq
        /// </summary>
        [EnumMember(Value = "5")] PreferentialRefundUnVoteStock = 5,
        /// <summary>
        ///  CK ưu đãi khác ko bq
        /// </summary>
        [EnumMember(Value = "6")] PreferentialOtherVotingStock = 6
    }

    public enum ActivityType : byte
    {
        /// <summary>
        /// Chứng khoán thông thường
        /// </summary>
        [EnumMember(Value = "NORM")] Normal,
        /// <summary>
        ///    Chứng khoán hạn chế chuyển nhượng
        /// </summary>
        [EnumMember(Value = "PEND")] RestictedStock,
        /// <summary>
        ///    Chứng khoán chuyển nhượng quyền
        /// </summary>
        [EnumMember(Value = "CORP")] BuyRightStock,
    }

    public enum PledgeReleasingType : byte
    {
        /// <summary>
        /// Giải tỏa chứng khoán
        /// </summary>
        [EnumMember(Value = "PLED")] Releasing,
        /// <summary>
        ///  Phong tỏa Chứng khoán  
        /// </summary>
        [EnumMember(Value = "AVAL")] Pledging,
    }
    public enum CrdbType : byte
    {/// <summary>
     /// Credit
     /// </summary>
        [EnumMember(Value = "CRED")]
        Credit,
        /// <summary>
        /// Debit
        /// </summary>
        [EnumMember(Value = "DEBT")]
        Debit
    }
}