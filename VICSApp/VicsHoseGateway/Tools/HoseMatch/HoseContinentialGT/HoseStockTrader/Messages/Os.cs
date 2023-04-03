using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Os
    {
        internal int StockNo;
        internal int Price;
    }
}