using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SMS.Common;
using SMS.DataAccess.Models;

namespace VICS.Manager.WebApp.Models
{
    public class DoiSoatModel
    {
        public string From { get; set; } 
        public string To { get; set; }
        public bool IsToday { get; set; }
    }

    public class DoiSoatViewModel
    {
        public DoiSoatModel DoiSoatModel { get; set; }
        public Summary Summary { get; set; } 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public int TotalQty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public decimal SumAmount { get; set; }
    }
    public class DoisoatDataListView
    {
        public string CustomerId { get; set; }
        public string Mobile { get; set; }
        public MobileType TelecomType { get; set; }
        public DateTime TimeSend { get; set; }
        public string SmsId { get; set; }
        public SmsType Type { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }
    }

    public class Summary
    {

        public decimal MRate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public int MQty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public decimal MAmount { get; set; }

        public decimal VRate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public int VQty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public decimal VAmount { get; set; }
        public decimal VnRate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public int VnQty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public decimal VnAmount { get; set; }
        public decimal OrRate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public int OrQty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###}")]
        public decimal OrAmount { get; set; }

    }
}