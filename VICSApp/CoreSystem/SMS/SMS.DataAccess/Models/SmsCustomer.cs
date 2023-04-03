using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DataAccess.Models
{
    public class SmsCustomer
    {
        [Key]
        [MaxLength(10)]
        [Column("CustomerId")]
        public string Id { get; set; }

        [MaxLength(200)]
        public string CustomerName { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        [MaxLength(3)]
        public string BranchCode { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public bool Sex { get; set; }

        [MaxLength(200)]
        public string Pin { get; set; }

        public virtual ICollection<SmsRequest> Requests { get; set; }
        public virtual ICollection<SmsTradingResult> TradingResults { get; set; }
        public bool IsInfo { get; set; }
        public bool IsOrder { get; set; }
        public bool IsAccountStatus { get; set; }
        public bool IsResult { get; set; }
        [MaxLength(1)]
        public string CustomerType { get; set; }
        [MaxLength(1)]
        public string DomesticForeign { get; set; }
        [DefaultValue(false)]
        public bool IsClose { get; set; }
    }
}