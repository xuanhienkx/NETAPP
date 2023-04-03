using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Le
    {
        internal int StockNo;
        internal int Price;
        internal long AccumulatedVol;
        internal double AccumulatedVal;
        internal int Highest;
        internal int Lowest;
        internal int Time; 
        internal string TimeString => this.Time.ToString();
    }
}