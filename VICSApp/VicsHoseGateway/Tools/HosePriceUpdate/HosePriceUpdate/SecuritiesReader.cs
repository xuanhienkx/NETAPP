using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HosePriceUpdate
{
   public class SecuritiesReader : FileReader
   {
      // Fields
      private Securities securities;

      // Methods
      public SecuritiesReader(string sFileName)
         : base(sFileName)
      {
      }

      public override bool Read()
      {
         if (!base.EOF)
         {
            GCHandle handle = GCHandle.Alloc(base.reader.ReadBytes(Marshal.SizeOf(typeof(Securities))), GCHandleType.Pinned);
            this.securities = (Securities)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Securities));
            base.length += Marshal.SizeOf(typeof(Securities));
            handle.Free();
            return true;
         }
         return false;
      }

      // Properties
      public Securities Data
      {
         get
         {
            return this.securities;
         }
      }

      public override int NumberOfRecords
      {
         get
         {
            return (int)(base.Length / ((long)Marshal.SizeOf(typeof(Securities))));
         }
      }
   }
}
