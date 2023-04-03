using DO.Common.Std.Configuration;

namespace DO.Common.Interfaces
{
    public interface IValueConverter
    {
        object Parse(string data, CSValueType type, string format);
        string ToString(object value, CSValueType type, string format);
    }
}
