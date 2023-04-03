using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
   public class UnitTrade
   {
      public string TradeCode;
      public string BranchCode;
      public string Name;
      public int Type; // 0: root, 1: branch, 3: agency
      public string ParentTradeCode;
      public short PostType;
   }
}
