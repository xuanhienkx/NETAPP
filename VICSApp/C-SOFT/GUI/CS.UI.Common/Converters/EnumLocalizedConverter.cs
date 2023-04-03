using CS.Common.Contract;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CS.UI.Common.Converters
{
    public class EnumLocalizedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumType = value?.GetType();
            if (enumType == null || !enumType.IsEnum)
                return value;

            var resourceKey = $"Enum_{enumType.Name}_{value}";
            return DataContractResourceManager.Current.Translate(resourceKey);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
