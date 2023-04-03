using System;

namespace SMS.Data.Services.EF.Models
{
    public class BalanceModel
    {
        public string AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}