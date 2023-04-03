using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct PutAd
    {
        internal short TradeId;
        internal short StockNo;
        internal int Vol;
        internal double Price;
        internal int FirmNo;
        [MarshalAs(UnmanagedType.U1)]
        internal char Side;
        [MarshalAs(UnmanagedType.U1)]
        internal char Board;
        internal int Time;
        [MarshalAs(UnmanagedType.U1)]
        internal char Flag;  
    }
}