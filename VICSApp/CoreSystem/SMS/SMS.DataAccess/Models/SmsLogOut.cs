using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsLogOut
    {
        [Key]
        public Guid Id { get; set; }

        public virtual SmsRequest SmsRequest { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? ReceiverTime { get; set; }

        [MaxLength(255)]
        public string SmsIdResponse { get; set; }

        [MaxLength(3)]
        public string CodeResultResponse { get; set; }

        public string ErrorMessage { get; set; }
    }
}