namespace CS.Common.Interfaces
{
    public interface IStringEncoder
    {
        string Encode(string input);
        string Decode(string input);
    }
}