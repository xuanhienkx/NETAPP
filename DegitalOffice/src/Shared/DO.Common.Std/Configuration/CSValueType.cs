using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DO.Common.Std.Configuration
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CSValueType
    {
        [EnumMember(Value = "String")] String,
        [EnumMember(Value = "Date")] Date,
        [EnumMember(Value = "Time")] Time,
        [EnumMember(Value = "Integer")] Integer, // for int, long
        [EnumMember(Value = "Decimal")] Decimal // Decimal, double
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrsUpdateType
    {
        [EnumMember(Value = "AddMore")] AddMore,
        [EnumMember(Value = "Override")] Override
    }
}