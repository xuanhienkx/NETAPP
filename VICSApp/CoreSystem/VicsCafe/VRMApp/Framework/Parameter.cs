using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using VRMApp.Properties;

namespace VRMApp.Framework
{
    [DefaultPropertyAttribute("Parameter")]
    public sealed class Parameter
    {
        [DescriptionAttribute("Màu nền của dòng mặc định trên bảng")]
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

        [DescriptionAttribute("Màu nền của dòng mặc định khi được chọn trên bảng")]
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

        [DescriptionAttribute("Màu nền của dòng xen kẽ dòng mặc định trên bảng")]
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

        [DescriptionAttribute("Màu nền của dòng xen kẽ dòng mặc định khi được chọn trên bảng")]
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

        [DescriptionAttribute("Thiết lập đơn vị làm tròn số khi tính tiền lãi hoặc tiền nợ")]
        public int RoundFee
        {
            get
            {
                return Settings.Default.VRMApp_VRMGateway_RoundFee;
            }
            set
            {
                Settings.Default.VRMApp_VRMGateway_RoundFee = value;
            }
        }
       [DescriptionAttribute("Thiết lập phí lưu ký")]
         
        public decimal CustodyFeeRate
        {
            get { return Settings.Default.VRMApp_VRMGateway_CUSTODYFEE; }
            set
            {
                Settings.Default.VRMApp_VRMGateway_CUSTODYFEE = value;
            }
        }

        public void Save()
        {
            Settings.Default.Save();
        }
    }
}
