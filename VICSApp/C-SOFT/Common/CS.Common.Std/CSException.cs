using System;

namespace CS.Common.Std
{
    public abstract class CsException : Exception
    {
        protected CsException()  { }
        protected CsException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

        protected abstract string Detail();

        public override string Message => $"{base.Message}. Detail: {Detail()}";
    }
}
