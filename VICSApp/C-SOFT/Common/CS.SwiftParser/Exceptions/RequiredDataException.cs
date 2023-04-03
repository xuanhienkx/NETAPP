using CS.Common.Std;

namespace CS.SwiftParser.Exceptions
{
    public class RequiredDataException : CsException
    {
        private readonly string fieldKey;

        public RequiredDataException(string fieldKey)
        {
            this.fieldKey = fieldKey;
        }

        protected override string Detail()
        {
            return $"Field [{fieldKey}] does not find in value bag while building message";
        }
    }
}
