namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct NewList
    {
        [MarshalAs(UnmanagedType.U2)]
        internal ushort StockNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        internal char[] stockSymbol;
        [MarshalAs(UnmanagedType.U1)]
        internal char StockType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x19)]
        internal char[] stockName;
        internal short SectorNo;
        internal string StockSymbol
        {
            get
            {
                return new string(this.stockSymbol).Trim();
            }
        }
        internal string StockName
        {
            get
            {
                return new string(this.stockName).Trim();
            }
        }
    }
}
