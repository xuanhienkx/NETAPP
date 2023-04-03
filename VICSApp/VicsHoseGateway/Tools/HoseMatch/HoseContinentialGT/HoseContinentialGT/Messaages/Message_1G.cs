namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message_1G
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] sellingFirm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] sellingTradeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] sellingClientID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] buyingFirm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] buyingTradeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] stockSymbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] board;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] dealID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] filler1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sellingPortfolioVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sellingClientVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sellingMutualFundVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sellingForeignVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public char[] filler2;
        public int offset;
        public string Time
        {
            get
            {
                return new string(this.time).Trim();
            }
        }
        public int SellingFirm
        {
            get
            {
                return Convert.ToInt32(new string(this.sellingFirm).Trim());
            }
        }
        public string SellingTradeID
        {
            get
            {
                return new string(this.sellingTradeID).Trim();
            }
        }
        public string SellingCustomerID
        {
            get
            {
                return new string(this.sellingClientID).Trim();
            }
        }
        public int BuyingFirm
        {
            get
            {
                return Convert.ToInt32(new string(this.buyingFirm).Trim());
            }
        }
        public string BuyingTradeID
        {
            get
            {
                return new string(this.buyingTradeID).Trim();
            }
        }
        public string StockSymbol
        {
            get
            {
                return new string(this.stockSymbol).Trim();
            }
        }
        public decimal Price
        {
            get
            {
                string str = new string(this.price).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public string Board
        {
            get
            {
                return new string(this.board).Trim();
            }
        }
        public string DealID
        {
            get
            {
                return new string(this.dealID).Trim();
            }
        }
        public decimal SellingPortfolioVolume
        {
            get
            {
                string str = new string(this.sellingPortfolioVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal SellingClientVolume
        {
            get
            {
                string str = new string(this.sellingClientVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal SellingMutualFundVolume
        {
            get
            {
                string str = new string(this.sellingMutualFundVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
        public decimal SellingForeignVolume
        {
            get
            {
                string str = new string(this.sellingForeignVolume).Trim();
                if (str == "")
                {
                    str = "0";
                }
                return Convert.ToDecimal(str);
            }
        }
    }
}