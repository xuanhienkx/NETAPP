using DSoft.Common.Exceptions;
using DSoft.Common.Extensions;
using DSoft.Common.Shared.Interfaces;

namespace DSoft.Common.Shared.Converter
{
    public class NumberValueConverter : IValueConverter
    {
        private readonly IValueConverter valueConverter;

        public NumberValueConverter(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }
        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Integer) || !type.Equals(CSValueType.Long))
                return valueConverter.Parse(data, type, format);

            return string.IsNullOrEmpty(data)
                ? 0
                : Executor.TryOrThrows(
                    () => long.Parse(data.Replace(",", "")),
                    (s, exception) => new ParseFailureException(s, exception, data, type, format));
        }

        public string ToString(object value, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Integer) || !type.Equals(CSValueType.Long) )
                return valueConverter.ToString(value, type, format);

            var number = value as long?;
            if (number == null)
                throw new InvalidCastException($" not cast value {value} is long number");

            return Executor.TryOrThrows(
                () => ((long)value).ToString(format),
                (s, exception) => new BuildFailureException(s, exception, value, type, format));
        }
    }
}