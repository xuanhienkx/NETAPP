using System;
using System.Runtime.Serialization;

namespace SMS.Common.Action
{
    [Serializable]
    public class ActionException : Exception
    {
        public ActionException() { }
        public ActionException(string msg) : base(msg) { }
        public ActionException(string msg, Exception innerException) : base(msg, innerException) { }
        protected ActionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}