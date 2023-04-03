using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HoseContinentialGT.Messaages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MarketStatus
    {
        [MarshalAs(UnmanagedType.U1)]
        internal char ControlCode;
        internal int Time;
    }
}
