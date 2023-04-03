using CS.Common.Interfaces;
using System;
using System.Globalization;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;

namespace CS.Common.Converter
{
    public class TimeValueConverter : IValueConverter
    {
        private readonly IValueConverter valueConverter;

        public TimeValueConverter(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }
        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Time))
                return valueConverter.Parse(data, type, format);

            return Executor.TryOrThrows(
                () => DateTime.ParseExact(data, format, CultureInfo.CurrentUICulture).TimeOfDay,
                (s, exception) => new ParseFailureException(s, exception, data, type, format));
        }

        public string ToString(object value, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Time))
                return valueConverter.ToString(value, type, format);

            var timeSpan = value as TimeSpan?;
            if (timeSpan == null)
                throw new InvalidCastException($" not cast value {value} is TimeSpan");

            return Executor.TryOrThrows(
                  () => new DateTime(timeSpan.Value.Ticks).ToString(format),
                  (s, exception) => new BuildFailureException(s, exception, value, type, format));
        }
    }
}