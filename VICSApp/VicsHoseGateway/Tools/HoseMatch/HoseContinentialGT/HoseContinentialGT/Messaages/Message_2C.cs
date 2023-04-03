namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message_2C
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] cancelShares;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] orderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] orderDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] cancelStatus;
        public int offset;
        public string Time
        {
            get
            {
                return new string(this.time).Trim();
            }
        }
        public int Firm
        {
            get
            {
                return Convert.ToInt32(new string(this.firm).Trim());
            }
        }
        public string OrderNumber
        {
            get
            {
                return new string(this.orderNumber).Trim();
            }
        }
        public decimal CancelledVolume
        {
            get
            {
                return Convert.ToDecimal(new string(this.cancelShares).Trim());
            }
        }
        public string Status
        {
            get
            {
                return new string(this.cancelStatus).Trim();
            }
        }
    }
}