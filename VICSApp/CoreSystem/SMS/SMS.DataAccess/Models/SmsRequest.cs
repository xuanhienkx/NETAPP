using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsRequest
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        [DefaultValue(false)]
        public bool IsSent { get; set; } //0:Chua gui, 1 Da gui thanh cong
        public Int16 Type { get; set; }
        [MaxLength(255)]
        public string SmsIdResponse { get; set; }
        public bool IsBrandName { get; set; }
        public virtual ICollection<SmsCustomer> Customers { get; set; }
        public virtual ICollection<SmsTradingResult> TradingResults { get; set; } 
        public virtual ICollection<SmsLogOut> LogOuts { get; set; }
        [MaxLength(10)]
        public string OrderDate { get; set; }
        public DateTime CreatedTime { get; set; } 
    }
}