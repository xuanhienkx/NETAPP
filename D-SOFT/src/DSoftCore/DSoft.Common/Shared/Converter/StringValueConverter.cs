using DSoft.Common.Shared.Interfaces;

namespace DSoft.Common.Shared.Converter
{
    public class StringValueConverter : IValueConverter
    {                                                     
        private readonly IValueConverter valueConverter;
        public StringValueConverter(IValueConverter valueConverter)
        {                                                                                                     
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        }

        public object Parse(string data, CSValueType type, string format)
        {
            if (!type.Equals(CSValueType.String))
                return valueConverter.Parse(data, type, format);    
            return data;
            
        }

        public string ToString(object value, CSValueType type, string format)
        {    
            return $"{value}";// stringEncoder.Encode(value.ToString());
        }
    }

}