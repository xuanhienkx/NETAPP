namespace DO.Common.Interfaces
{
    public interface IStringEncoder
    {
        string Encode(string input);
        string Decode(string input);
    }

    public class NotStringEncode : IStringEncoder
    {
        public string Encode(string input)
        {
            return input;
        }

        public string Decode(string input)
        {
            return input;
        }
    }
}