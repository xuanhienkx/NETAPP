using System;

namespace CommonDomain
{
   public sealed class CustomerDebitLimit
   {
      // Fields
      public bool Activate;
      public decimal CurrentLimitValue;
      public string CustomerID;
      public decimal LimitValue;
      public DateTime FromDate;
      public DateTime ToDate;
      public char DebitLimitType; //D
   }
}
