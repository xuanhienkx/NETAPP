namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message_2D
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] orderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] orderDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] clientID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] pcFlag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] publishedVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] filler;
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
        public string CustomerID
        {
            get
            {
                return new string(this.clientID).Trim();
            }
        }
        public string PCFlag
        {
            get
            {
                return new string(this.pcFlag).Trim();
            }
        }
        public decimal Volume
        {
            get
            {
                string str = new string(this.publishedVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal Price
        {
            get
            {
                string str = new string(this.price).Trim();
                if ((!"ATO".Equals(str) && !"ATC".Equals(str)) && !"MP".Equals(str))
                {
                    return Convert.ToDecimal(str);
                }
                return 0M;
            }
        }
    }
}