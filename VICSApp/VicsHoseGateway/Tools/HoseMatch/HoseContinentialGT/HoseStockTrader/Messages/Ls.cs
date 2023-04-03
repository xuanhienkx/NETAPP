using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Ls
    {
        internal int ConfirmNo;
        internal int StockNo;
        internal double MatchedVol;
        internal int Price;
        [MarshalAs(UnmanagedType.U1)]
        internal char Side;
    }
}