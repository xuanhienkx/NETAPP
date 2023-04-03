using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CS.Application.Framework
{
    public class VsdReportNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string code)) return value;

            var vsdReport = VsdReportList.Current.Items.SingleOrDefault(x => x.ReportCode.Equals(code));
            return vsdReport != null ? vsdReport.ReportName : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}