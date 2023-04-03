using CS.Common.Interfaces;

namespace CS.SwiftParser
{
    public class LatinStringEncode : IStringEncoder
    {
        public string Encode(string input)
        {
            return LatinEncoder.VniEscape(input);
        }

        public string Decode(string input)
        {
            return LatinEncoder.VniEncode(input);
        }
    }
}