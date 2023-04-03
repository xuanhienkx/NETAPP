using DSoft.Common.Exceptions;
using DSoft.Common.Extensions;
using DSoft.Common.Shared.Interfaces;

namespace DSoft.Common.Shared.Converter
{
    public class DecimalValueConverter : IValueConverter
    {
        private readonly IValueConverter valueConverter;

        public DecimalValueConverter(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }
        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Decimal))
                return valueConverter.Parse(data, type, format);

            return string.IsNullOrEmpty(data)
                ? 0
                : Executor.TryOrThrows(
                    () => decimal.Parse(data),
                    (s, exception) => new ParseFailureException(s, exception, data, type, format));
        }

        public string ToString(object value, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.Decimal))
                return valueConverter.ToString(value, type, format);

            var number = value as decimal?;
            if (number == null)
                throw new InvalidCastException($" not cast value {value} is Decimal");

            return Executor.TryOrThrows(
                () => ((decimal)value).ToString(format),
                (s, exception) => new BuildFailureException(s, exception, value, type, format));
        }
    }
}