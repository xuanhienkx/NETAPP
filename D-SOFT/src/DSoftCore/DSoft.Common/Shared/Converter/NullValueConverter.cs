using DSoft.Common.Shared.Interfaces;

namespace DSoft.Common.Shared.Converter
{
    public class NullValueConverter : IValueConverter
    {
        public object Parse(string data, CSValueType type, string format)
        {
            throw new NotSupportedException($"Value type invalid: {type}");
        }

        public string ToString(object value, CSValueType type, string format)
        {
            throw new NotSupportedException($"Value type invalid: {type}");
        }
    }
}