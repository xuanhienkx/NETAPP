namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_3C
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] contraFirm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] tradeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] confirmNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] symbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
        public char[] side;
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
        public int ContraFirm
        {
            get
            {
                return Convert.ToInt32(new string(this.contraFirm).Trim());
            }
        }
        public string TradeID
        {
            get
            {
                return new string(this.tradeID).Trim();
            }
        }
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
        public string StockCode
        {
            get
            {
                return new string(this.symbol).Trim();
            }
        }
        public string OrderSide
        {
            get
            {
                return new string(this.side).Trim();
            }
        }
    }
}
