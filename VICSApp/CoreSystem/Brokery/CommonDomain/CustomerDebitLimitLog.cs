using System;

namespace CommonDomain
{
   public sealed class CustomerDebitLimitLog
   {
      public DateTime TransactionDate;

      public string TransactionTime;

      public string CustomerId;

      public string CustomerName;

      public decimal OldLimitValue;

      public decimal LimitValue;

      public DateTime OldFromDate;

      public DateTime FromDate;

      public DateTime OldToDate;

      public DateTime ToDate;

      public string UserEnter;
   }
}
