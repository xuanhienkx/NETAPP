using System.Collections.Generic;
using Newtonsoft.Json;
using ProtoBuf;

namespace CS.Common.Std
{
    [ProtoContract]
    public class RequestResult<T>
    {
        public RequestResult() { }
        public RequestResult(T result, bool success)
        {
            this.Value = result;
            this.IsSuccess = success;
        }

        [ProtoMember(1)]
        public T Value { get; set; }
        [ProtoMember(2)]
        public IList<string> ErrorMessages { get; set; }
        [ProtoMember(3)]
        public bool IsSuccess { get; set; }

        [JsonIgnore]
        [ProtoIgnore]
        public bool HasResult => IsSuccess && Value != null;
    }
}
