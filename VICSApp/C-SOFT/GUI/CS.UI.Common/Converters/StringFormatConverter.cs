using System;
using System.Globalization;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class StringFormatConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var stringFormat = parameter as string;
            return string.IsNullOrEmpty(stringFormat)
                ? string.Join(string.Empty, values)
                : string.Format(stringFormat, values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
