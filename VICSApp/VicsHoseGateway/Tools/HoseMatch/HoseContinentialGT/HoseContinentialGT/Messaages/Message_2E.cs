namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message_2E
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] side;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] orderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] orderDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] filler;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] volume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] confirmNumber;
        public int offset;
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
        public string OrderSide
        {
            get
            {
                return new string(this.side).Trim();
            }
        }
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
        public int Firm
        {
            get
            {
                return Convert.ToInt32(new string(this.firm).Trim());
            }
        }
        public decimal MatchedVolume
        {
            get
            {
                return Convert.ToDecimal(new string(this.volume).Trim());
            }
        }
        public decimal MatchedPrice
        {
            get
            {
                return Convert.ToDecimal(new string(this.price).Trim());
            }
        }
    }
}