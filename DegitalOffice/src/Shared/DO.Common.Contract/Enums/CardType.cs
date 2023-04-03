using System.Runtime.Serialization;

namespace DO.Common.Contract.Enums
{
    public enum CardType : byte
    {
        None = 0,
        [EnumMember(Value = "IDNO")] DomesticIdentity = 1,
        [EnumMember(Value = "CCPT")] Passport = 2,
        [EnumMember(Value = "CORP")] DomesticCorpIdentity = 3,// DKKD
        [EnumMember(Value = "OTHR")] SocialSecurity = 4,//ASXH
        [EnumMember(Value = "FIIN")] ForeignCorpIdentity = 5,//Mã Trading Code cho tổ chức nước ngoài
        [EnumMember(Value = "ARNU")] ForeignIdentity = 6,//Mã Trading Code cho cá nhân nước ngoài
        [EnumMember(Value = "GOVT")] Government = 7//Cơ quan chính phủ
    }
}