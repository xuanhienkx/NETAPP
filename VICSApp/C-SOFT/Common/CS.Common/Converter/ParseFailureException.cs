using Newtonsoft.Json;
using System;
using CS.Common.Std;
using CS.Common.Std.Configuration;

namespace CS.Common.Converter
{
    public class ParseFailureException : CsException
    {
        private readonly string data;
        private readonly CSValueType type;
        private readonly string format;

        public ParseFailureException(string message, Exception innerException, string data, CSValueType type, string format)
            : base(message, innerException)
        {
            this.data = data;
            this.type = type;
            this.format = format;
        }

        protected override string Detail()
        {
            return $"Value type: {type} - Format: {format}.  Data: {data}";
        }
    }
    public class BuildFailureException : CsException
    {
        private readonly object data;
        private readonly CSValueType type;
        private readonly string format;

        public BuildFailureException(string message, Exception innerException, object data, CSValueType type, string format)
            : base(message, innerException)
        {
            this.data = data;
            this.type = type;
            this.format = format;
        }

        protected override string Detail()
        {
            return $"Value type: {type} - Format: {format}.  Data: {JsonConvert.SerializeObject(data)}";
        }
    }
}
