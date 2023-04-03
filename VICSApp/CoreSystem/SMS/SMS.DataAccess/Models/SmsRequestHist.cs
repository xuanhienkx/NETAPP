using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
   public class SmsRequestHist
   {
      [Key]
      public Guid Id { get; set; }

      public Guid RequestId { get; set; }
      public string Message { get; set; }

      [DefaultValue(false)]
      public bool IsSent { get; set; } //0:Cho gui, 1 Da gui thanh cong
      public Int16 Type { get; set; }

      [MaxLength(255)]
      public string SmsIdResponse { get; set; }
      public bool IsBrandName { get; set; }

      [MaxLength(10)]
      public string OrderDate { get; set; }

      public DateTime CreatedTime { get; set; }
       [MaxLength(10)]
      public string CustomerId { get; set; }
       [MaxLength(15)]
      public string Mobile { get; set; }
   }
}