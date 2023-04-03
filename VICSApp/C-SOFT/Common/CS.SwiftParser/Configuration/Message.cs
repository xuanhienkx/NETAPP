using CS.Common.Std.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CS.SwiftParser.Configuration
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "MT")] MT,
        [EnumMember(Value = "ACKNAK")] ACKNAK,
        [EnumMember(Value = "FileACT")] FileACT
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestType
    {
        [EnumMember(Value = "Request")] Request,
        [EnumMember(Value = "Response")] Response
    }

    [DataContract]
    public class Message
    {
        [DataMember(Name = "messageId")]
        public string Id { get; set; }
        [DataMember(Name = "messageType")]
        public MessageType Type { get; set; }
        [DataMember(Name = "requestType")]
        public RequestType RequestType { get; set; }
        [DataMember(Name = "blocks")]
        public IList<Block> Blocks { get; set; }
        [DataMember(Name = "keyValue")]
        public string KeyValue { get; set; }
        [DataMember(Name = "note")]
        public string Note { get; set; }
    }
}
