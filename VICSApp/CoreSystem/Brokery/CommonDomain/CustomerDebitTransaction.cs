using System;

namespace CommonDomain
{
   public sealed class CustomerDebitTransaction
   {
      public decimal Amount;
      public string BranchCode;
      public string CustomerID;
      public DateTime TransDate;
      public string Type;
      public string UserEnter;
      public decimal BeforeLimitValue;
      public decimal CurrentLimitValue;
   }
}
