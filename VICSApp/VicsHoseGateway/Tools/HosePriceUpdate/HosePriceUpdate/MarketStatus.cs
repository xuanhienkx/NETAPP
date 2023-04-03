using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HosePriceUpdate
{
   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   internal struct MarketStatus
   {
      internal char ControlCode;
      internal int Time;
   }
}
