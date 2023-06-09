using System.ComponentModel;
using System.Drawing;
using Brokery.Properties;

namespace Brokery.Framework
{
   [DefaultProperty("Parameter")]
   public sealed class Parameter
   {
      [Description("Màu nền của dòng mặc định trên bảng")]
      public Color DefaultRowBackColor
      {
         get
         {
            return Settings.Default.DefaultRowBackColor;
         }
         set
         {
            Settings.Default.DefaultRowBackColor = value;
         }
      }

      [Description("Màu nền của dòng mặc định khi được chọn trên bảng")]
      public Color DefaultSelectedRowBackColor
      {
         get
         {
            return Settings.Default.DefaultSelectedRowBackColor;
         }
         set
         {
            Settings.Default.DefaultSelectedRowBackColor = value;
         }
      }

      [Description("Màu nền của dòng xen kẽ dòng mặc định trên bảng")]
      public Color AlternateRowBackColor
      {
         get
         {
            return Settings.Default.AlternateRowBackColor;
         }
         set
         {
            Settings.Default.AlternateRowBackColor = value;
         }
      }

      [Description("Màu nền của dòng xen kẽ dòng mặc định khi được chọn trên bảng")]
      public Color AlternateSelectedRowBackColor
      {
         get
         {
            return Settings.Default.AlternateSelectedRowBackColor;
         }
         set
         {
            Settings.Default.AlternateSelectedRowBackColor = value;
         }
      }

      [Description("Vị trí địa lý của phòng giao dịch được in trên báo cáo")]
      public string AgencyLocation
      {
         get
         {
            return Settings.Default.AgencyLocation;
         }
         set
         {
            Settings.Default.AgencyLocation = value;
         }
      }

      [Description("Tên của phòng giao dịch được in trên báo cáo")]
      public string AgencyName
      {
         get
         {
            return Settings.Default.AgencyName;
         }
         set
         {
            Settings.Default.AgencyName = value;
         }
      }

      [Description("Địa chỉ và điện thoại của phòng giao dịch được in trên báo cáo")]
      public string AgencyAddressAndTelephone
      {
         get
         {
            return Settings.Default.AgencyAddressAndTelephone;
         }
         set
         {
            Settings.Default.AgencyAddressAndTelephone = value;
         }
      }

      [Description("Người ký vào vị trí đầu tiên bên trái trên báo cáo")]
      public string Report_Footer1
      {
         get
         {
            return Settings.Default.Report_Footer1;
         }
         set
         {
            Settings.Default.Report_Footer1 = value;
         }
      }

      [Description("Người ký vào vị trí ở giữa trên báo cáo")]
      public string Report_Footer2
      {
         get
         {
            return Settings.Default.Report_Footer2;
         }
         set
         {
            Settings.Default.Report_Footer2 = value;
         }
      }

      [Description("Người ký vào vị trí cuối cùng bên phải trên báo cáo")]
      public string Report_Footer3
      {
         get
         {
            return Settings.Default.Report_Footer3;
         }
         set
         {
            Settings.Default.Report_Footer3 = value;
         }
      }
      
      public void Save()
      {
         Settings.Default.Save();
      }
   }
}
