using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsLogOutHist
    {
        [Key]
        public Guid Id { get; set; }

        public Guid LogId { get; set; }
        public Guid SmsRequestId { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? ReceiverTime { get; set; }

        [MaxLength(255)]
        public string SmsIdResponse { get; set; }

        [MaxLength(3)]
        public string CodeResultResponse { get; set; }

        public string ErrorMessage { get; set; }
    }
}