using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DSoft.Common.Shared.Interfaces
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CSValueType
    {
        [EnumMember(Value = "String")] String,
        [EnumMember(Value = "Date")] Date,
        [EnumMember(Value = "Time")] Time,
        [EnumMember(Value = "Integer")] Integer, // for int, long
        [EnumMember(Value = "Short")] Short, // for int, long
        [EnumMember(Value = "Long")] Long, // for int, long
        [EnumMember(Value = "Double")] Double, // Decimal, double
        [EnumMember(Value = "Decimal")] Decimal // Decimal, double
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrsUpdateType
    {
        [EnumMember(Value = "AddMore")] AddMore,
        [EnumMember(Value = "Override")] Override
    }
}
