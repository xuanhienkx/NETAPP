namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct PTAdv
    {
        internal ushort TradeID;
        internal ushort StockNo;
        internal uint Volume;
        internal double Price;
        internal uint FirmNo;
        [MarshalAs(UnmanagedType.U1)]
        internal char Side;
        [MarshalAs(UnmanagedType.U1)]
        internal char Board;
        internal uint Time;
        [MarshalAs(UnmanagedType.U1)]
        internal char Flag;
    }
}
