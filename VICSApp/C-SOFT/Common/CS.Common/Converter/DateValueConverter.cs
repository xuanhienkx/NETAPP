using CS.Common.Interfaces;
using System;
using System.Globalization;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;

namespace CS.Common.Converter
{
    public class DateValueConverter : IValueConverter
    {
        private readonly IValueConverter valueConverter;

        public DateValueConverter(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }

        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Date))
                return valueConverter.Parse(data, type, format);

            return Executor.TryOrThrows(
                () => DateTime.ParseExact(data, format, CultureInfo.CurrentUICulture),
                (s, exception) => new ParseFailureException(s, exception, data, type, format));
        }

        public string ToString(object value, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Date))
                return valueConverter.ToString(value, type, format);

            var date = value as DateTime?;
            if (date == null)
                throw new InvalidCastException($" not cast value {value} is DateTime");

            return Executor.TryOrThrows(
                () => ((DateTime)value).ToString(format, CultureInfo.InvariantCulture),
                (s, exception) => new BuildFailureException(s, exception, value, type, format));
        }
    }
}