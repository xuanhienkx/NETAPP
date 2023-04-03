using System.Runtime.Serialization;

namespace CS.Common.Contract.Enums
{
    public enum CustomerType : byte
    {
        [EnumMember(Value = "3")]
        DomesticPrivate = 0,
        [EnumMember(Value = "5")]
        DomesticOrganization = 1,
        [EnumMember(Value = "4")]
        ForeignPrivate = 2,
        [EnumMember(Value = "6")]
        ForeignOrganization = 3,
        [EnumMember(Value = "7")]
        Country = 3
    }
}
