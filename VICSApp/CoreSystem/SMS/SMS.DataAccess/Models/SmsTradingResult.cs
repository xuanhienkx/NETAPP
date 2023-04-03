using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsTradingResult
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(10)]
        public string OrderDate { get; set; }

        [MaxLength(30)]
        public string OrderNo { get; set; }

        [MaxLength(30)]
        public string ConfirmNo { get; set; }

        [MaxLength(15)]
        public string ConfirmTime { get; set; }

        [MaxLength(1)]
        public string OrderSide { get; set; }

        public virtual SmsCustomer Customer { get; set; }

        [MaxLength(4)]
        public string StockCode { get; set; }

        [DefaultValue(0)]
        public decimal MatchedVolume { get; set; }

        [DefaultValue(0)]
        public decimal MatchedPrice { get; set; }

        public ICollection<SmsRequest> Requests { get; set; }
        public Guid SbsResultId { get; set; }

        public decimal OrderVolume { get; set; }
        [DefaultValue(false)]
        public bool IsBuildMessage { get; set; }
    }
}