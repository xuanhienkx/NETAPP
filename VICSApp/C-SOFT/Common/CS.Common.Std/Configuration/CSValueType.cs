using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CS.Common.Std.Configuration
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CSValueType
    {
        [EnumMember(Value = "String")] String,
        [EnumMember(Value = "Date")] Date,
        [EnumMember(Value = "Time")] Time,
        [EnumMember(Value = "Integer")] Integer,
        [EnumMember(Value = "Decimal")] Decimal
    }
}