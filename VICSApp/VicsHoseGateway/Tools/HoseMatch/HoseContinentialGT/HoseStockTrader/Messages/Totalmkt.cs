using System.Runtime.InteropServices;

namespace HoseStockTrader.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Totalmkt
    {
        internal int VnIndex;
        internal int TotalTrade;
        internal double TotalShares;
        internal double TotalValues;
        internal double UpVolume;
        internal double DownVolume;
        internal double NoChangeVolume;
        internal short Advences;
        internal short Declines;
        internal short NoChange;
        internal int Vn50Index;
        [MarshalAs(UnmanagedType.U1)]
        internal char MarketId;
        [MarshalAs(UnmanagedType.U1)]
        internal char Filter;
        internal int Time;
    }
}