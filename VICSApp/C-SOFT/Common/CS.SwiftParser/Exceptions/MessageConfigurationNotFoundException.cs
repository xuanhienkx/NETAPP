using CS.Common.Std;
using CS.SwiftParser.Configuration;

namespace CS.SwiftParser.Exceptions
{
    public class MessageConfigurationNotFoundException : CsException
    {
        private readonly MessageType type;
        private readonly RequestType requestType;

        public MessageConfigurationNotFoundException(MessageType type, RequestType requestType)
        {
            this.type = type;
            this.requestType = requestType;
        }

        protected override string Detail()
        {
            return $"Cannot find the message configuration setting for messageType: [{type}] and requestType: [{requestType}]";
        }
    }
}
