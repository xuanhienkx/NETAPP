using CS.Common.Std.Configuration;

namespace CS.Common.Interfaces
{
    public interface IValueConverter
    {
        object Parse(string data, CSValueType type, string format);
        string ToString(object value, CSValueType type, string format);
    }
}
