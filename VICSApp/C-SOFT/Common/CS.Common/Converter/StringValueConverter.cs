using CS.Common.Interfaces;
using System;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;

namespace CS.Common.Converter
{
    public class StringValueConverter : IValueConverter
    {
        private readonly IStringEncoder stringEncoder;
        private readonly IValueConverter valueConverter;
        public StringValueConverter(IValueConverter valueConverter, IStringEncoder stringEncoder)
        {
            this.stringEncoder = stringEncoder ?? throw new ArgumentNullException(nameof(stringEncoder));
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }

        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.String))
                return valueConverter.Parse(data, type, format);

            return Executor.TryOrThrows(
                () => stringEncoder.Decode(data), 
                (s, exception) => new ParseFailureException(s, exception, data, type, format));
        }

        public string ToString(object value, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.String))
                return valueConverter.ToString(value, type, format);

            if (!(value is string strvalue))
                throw new InvalidCastException($" not cast value [{value}] as String");

            return stringEncoder.Encode(value.ToString());
        }
    }

}