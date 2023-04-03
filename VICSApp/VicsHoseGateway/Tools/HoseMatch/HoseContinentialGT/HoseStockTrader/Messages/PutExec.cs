using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct PutExec
    {
        internal int ConfirmNo;
        internal short StockNo;
        internal int Vol;
        internal int Price;
        [MarshalAs(UnmanagedType.U1)]
        internal char Board;
    }
}