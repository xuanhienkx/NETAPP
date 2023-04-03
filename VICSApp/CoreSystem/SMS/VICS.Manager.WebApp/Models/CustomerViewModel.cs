using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VICS.Manager.WebApp.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        public string Id { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string CustomerName { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        public string Mobile { get; set; } 
        public DateTime? CloseDate { get; set; }
        [MaxLength(3)]
        public string BranchCode { get; set; }

        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Email không đúng")]
        public string Email { get; set; }

        public bool Sex { get; set; }
        public string CustomerType { get; set; }
        [MaxLength(1)]
        public string DomesticForeign { get; set; }
        public bool IsClose { get; set; }
        public string MessageContent { get; set; }
        public bool IsInfo { get; set; }
    }
}