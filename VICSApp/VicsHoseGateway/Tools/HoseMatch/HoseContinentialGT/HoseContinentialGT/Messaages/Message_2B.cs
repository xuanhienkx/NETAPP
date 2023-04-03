using System;
using System.Runtime.InteropServices;

namespace HoseContinentialGT.Messaages
{  
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_2B
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] orderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] orderDate;
        public int offset;
        public int Firm
        {
            get
            {
                return Convert.ToInt32(new string(this.firm).Trim());
            }
        }
        public string Time
        {
            get
            {
                return new string(this.time).Trim();
            }
        }
        public string OrderNumber
        {
            get
            {
                return new string(this.orderNumber).Trim();
            }
        }
    }
}