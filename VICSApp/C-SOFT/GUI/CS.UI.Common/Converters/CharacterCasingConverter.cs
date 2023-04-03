using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class CharacterCasingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue && parameter is CharacterCasing characterCasing)
            {
                if (characterCasing == CharacterCasing.Lower)
                    return strValue.ToLowerInvariant();
                if (characterCasing == CharacterCasing.Upper)
                    return strValue.ToUpperInvariant();
                return strValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}