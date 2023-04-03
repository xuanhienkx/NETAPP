using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FRoom
    {
        internal int StockNo;
        internal double TotalRoom;
        internal double CurrentRoom;
        internal double BuyVolume;
        internal double SellVoume; 
    }
}