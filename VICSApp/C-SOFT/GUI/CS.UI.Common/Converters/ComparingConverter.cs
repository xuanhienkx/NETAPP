using System;
using System.Globalization;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class ComparingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null && parameter is null)
                return true;

            if (value != null && value.Equals(parameter))
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null || parameter == null)
                return null;

            if (bool.TryParse(value.ToString(), out var boolValue) && boolValue)
                return Enum.Parse(targetType, parameter.ToString());

            return Enum.ToObject(targetType, value);
        }
    }
}