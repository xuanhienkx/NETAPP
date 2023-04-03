using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DeList
    {
        internal short StockNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        internal char[] StockSymbol;
        [MarshalAs(UnmanagedType.U1)]
        internal char StockType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        internal char[] stockName;
        internal short SectorNo;
        internal string StockCode => new string(this.StockSymbol).Trim();
        internal string StockName => new string(this.stockName).Trim();
    }
}