using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class CountryNameLocalizedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string code)
            {
                var country = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                    .Select(x => new RegionInfo(x.LCID))
                    .FirstOrDefault(x => x.Name.Equals(code, StringComparison.OrdinalIgnoreCase));
                if (country != null)
                    return country.NativeName;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}