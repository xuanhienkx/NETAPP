using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HosePriceUpdate
{
   internal class MarketStatusReader : FileReader
   {
      // Fields
      private MarketStatus marketStatus;

      // Methods
      public MarketStatusReader(string sFileName)
         : base(sFileName)
      {
      }

      public override bool Read()
      {
         if (!base.IsOpen)
         {
            GCHandle handle = GCHandle.Alloc(base.reader.ReadBytes(Marshal.SizeOf(typeof(MarketStatus))), GCHandleType.Pinned);
            this.marketStatus = (MarketStatus)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MarketStatus));
            base.length += Marshal.SizeOf(typeof(MarketStatus));
            handle.Free();
            return true;
         }
         return false;
      }

      // Properties
      public MarketStatus Data
      {
         get
         {
            return this.marketStatus;
         }
      }

      public override int NumberOfRecords
      {
         get
         {
            return (int)(base.Length / ((long)Marshal.SizeOf(typeof(MarketStatus))));
         }
      }
   }

}
