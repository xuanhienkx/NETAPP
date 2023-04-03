using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsTransactionDayHist
    { 
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        [MaxLength(10)]
        public string CustomerId { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        [MaxLength(1)]
        public string DebitOrCredit { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime TransactionTime { get; set; }
        [MaxLength(12)]
        public string TransactionNumber { get; set; }
        [MaxLength(1)]
        public string BankDebitOrCredit { get; set; }
        [MaxLength(10)]
        public string BankAccountId { get; set; }
        [MaxLength(100)]
        public string BankAccountName { get; set; }
        public bool IsBuild { get; set; }
    }
}