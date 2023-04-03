using CS.Common.Interfaces;
using System;
using CS.Common.Std.Configuration;

namespace CS.Common.Converter
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