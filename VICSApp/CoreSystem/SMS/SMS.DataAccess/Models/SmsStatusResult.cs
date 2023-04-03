using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SMS.Common;

namespace SMS.DataAccess.Models
{
    public class SmsStatusResult
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string SmsId { get; set; }
        public DateTime Transdate { get; set; }
        [MaxLength(10)]
        public string OrderDate { get; set; }
        public Guid SmsRequestId { get; set; }
        [MaxLength(3)]
        public string CodeResult { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [DefaultValue(false)]
        public bool SentResult { get; set; }
        [DefaultValue(false)]
        public bool IsSent { get; set; }
        public MobileType MobileType { get; set; }
        [DefaultValue(false)]
        public bool IsAllSuccess { get; set; }
    }
}