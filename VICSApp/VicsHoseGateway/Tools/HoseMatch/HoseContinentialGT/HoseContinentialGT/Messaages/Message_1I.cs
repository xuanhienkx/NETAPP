namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message_1I
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] traderID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] orderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] clientID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] symbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] side;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] volume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] publishedVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] board;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] filler1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] pcflag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] filler2;
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
        public string OrderType
        {
            get
            {
                string str = new string(this.price).Trim();
                if ("ATO".Equals(str))
                {
                    return "ATO";
                }
                if ("ATC".Equals(str))
                {
                    return "ATC";
                }
                if ("MP".Equals(str))
                {
                    return "MP";
                }
                return "LO";
            }
        }
        public string OrderSide
        {
            get
            {
                return new string(this.side).Trim();
            }
        }
        public string CustomerID
        {
            get
            {
                return new string(this.clientID).Trim();
            }
        }
        public string StockCode
        {
            get
            {
                return new string(this.symbol).Trim();
            }
        }
        public decimal OrderVolume
        {
            get
            {
                return Convert.ToDecimal(new string(this.volume).Trim());
            }
        }
        public decimal OrderPrice
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
        public string Board
        {
            get
            {
                return new string(this.board).Trim();
            }
        }
        public string PCFlag
        {
            get
            {
                return new string(this.pcflag).Trim();
            }
        }
    }
}