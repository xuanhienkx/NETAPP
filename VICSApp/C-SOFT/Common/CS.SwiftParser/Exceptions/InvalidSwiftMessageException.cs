using CS.Common.Std;

namespace CS.SwiftParser.Exceptions
{
    public class InvalidSwiftMessageException : CsException
    {
        private readonly string rawData;

        public InvalidSwiftMessageException(string rawData)
        {
            this.rawData = rawData;
        }

        protected override string Detail()
        {
            return $"Rawdata: {rawData}";
        }
    }
}
