using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class LanguageNameLocalizedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string code)
            {
                var language = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                    .FirstOrDefault(x => x.TwoLetterISOLanguageName.Equals(code, StringComparison.OrdinalIgnoreCase));
                if (language != null)
                    return language.NativeName;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
