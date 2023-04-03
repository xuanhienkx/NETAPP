namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_3B
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] confirmNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
        public char[] dealID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        public char[] buyingClientID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
        public char[] replyCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] filler1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] buyingPortfolioVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] buyingClientVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] buyingMutualFundVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] buyingForeignVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x20)]
        public char[] filler2;
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
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
        public string DealID
        {
            get
            {
                return new string(this.dealID).Trim();
            }
        }
        public string BuyingCustomerID
        {
            get
            {
                return new string(this.buyingClientID).Trim();
            }
        }
        public string ReplyCode
        {
            get
            {
                return new string(this.replyCode).Trim();
            }
        }
        public decimal BuyingPortfolioVolume
        {
            get
            {
                string str = new string(this.buyingPortfolioVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal BuyingClientVolume
        {
            get
            {
                string str = new string(this.buyingClientVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal BuyingMutualFundVolume
        {
            get
            {
                string str = new string(this.buyingMutualFundVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal BuyingForeignVolume
        {
            get
            {
                string str = new string(this.buyingForeignVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
    }
}
