namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_2I
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] buyerOrderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] buyerOrderDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] sellerOrderNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public char[] sellerOrderDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        public char[] volume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] price;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] confirmNumber;
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
        public string BuyerOrderNumber
        {
            get
            {
                return new string(this.buyerOrderNumber).Trim();
            }
        }
        public string SellerOrderNumber
        {
            get
            {
                return new string(this.sellerOrderNumber).Trim();
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
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
    }
}
