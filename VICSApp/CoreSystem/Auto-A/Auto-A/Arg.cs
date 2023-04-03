using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auto_A
{
   public class Arg
   {
      public decimal LimitAmount;
      public int Interval;

      public Arg(decimal limitAmount, int interval)
      {
         LimitAmount = limitAmount;
         Interval = interval;
      }
   }
}
