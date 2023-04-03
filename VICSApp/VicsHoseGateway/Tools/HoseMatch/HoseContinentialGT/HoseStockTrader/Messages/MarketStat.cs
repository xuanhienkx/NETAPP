using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MarketStat
    {
        [MarshalAs(UnmanagedType.U1)]
        internal char ControlCode; 
        internal int Time; 
        internal string Status
        {
            get
            {
                return this.ControlCode.ToString();
            }
        }
    }
}