namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TotalMarket
    {
        internal int SetIndex;
        internal int TotalTrade;
        internal double TotalShares;
        internal double TotalValue;
        internal double UpVolume;
        internal double NoChangeVolume;
        internal double DownVolume;
        internal short Advances;
        internal short NoChange;
        internal short Declines;
        internal int SET50Index;
        [MarshalAs(UnmanagedType.U1)]
        internal char MarketID;
        [MarshalAs(UnmanagedType.U1)]
        internal char Filter;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Time;
    }
}
