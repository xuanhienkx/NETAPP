namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_2F
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] buyingFirm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] buyingTradeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
        public char[] side;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] sellingFirm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] sellingTradeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] symbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] volume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
        public char[] board;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] confirmNumber;
        public int offset;
        public string Time
        {
            get
            {
                return new string(this.time).Trim();
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
        public string Side
        {
            get
            {
                return new string(this.side).Trim();
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
        public string StockCode
        {
            get
            {
                return new string(this.symbol).Trim();
            }
        }
        public decimal Volume
        {
            get
            {
                return Convert.ToDecimal(new string(this.volume).Trim());
            }
        }
        public decimal Price
        {
            get
            {
                return Convert.ToDecimal(new string(this.price).Trim());
            }
        }
        public string Board
        {
            get
            {
                return new string(this.board).Trim();
            }
        }
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
    }
}
