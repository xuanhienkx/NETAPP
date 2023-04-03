using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class VisibilityByComparingNotEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null && parameter is null)
                return Visibility.Collapsed;

            if (value != null && value.Equals(parameter))
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}