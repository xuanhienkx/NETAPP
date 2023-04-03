namespace HoseContinentialGT.Messaages
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct PTExec
    {
        internal uint ConfirmNo;
        internal ushort StockNo;
        internal uint Volume;
        internal uint Price;
        [MarshalAs(UnmanagedType.U1)]
        internal char Board;
    }
}
