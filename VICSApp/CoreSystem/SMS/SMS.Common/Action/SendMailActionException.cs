using System;
using System.Runtime.Serialization;

namespace SMS.Common.Action
{
    [Serializable]
    public class SendMailActionException : ActionException
    {
        public SendMailActionException() { }
        public SendMailActionException(string msg) : base(msg) { }
        public SendMailActionException(string msg, Exception innerException) : base(msg, innerException) { }
        protected SendMailActionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}