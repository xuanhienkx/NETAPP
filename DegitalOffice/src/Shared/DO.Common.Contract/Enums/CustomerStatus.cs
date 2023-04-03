using System.Runtime.Serialization;

namespace DO.Common.Contract.Enums
{
    public enum CustomerStatus : byte
    {
        [EnumMember(Value = "AOPN")] Open,
        [EnumMember(Value = "ACLS")] Closed,

        Initial,
        PendingOpen,
        RequestDeleted,
        PendingClose
    }
}