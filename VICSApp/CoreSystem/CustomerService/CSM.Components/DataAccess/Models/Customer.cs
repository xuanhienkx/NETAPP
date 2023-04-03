using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSM.Components.DataAccess.Models
{
    [Table("Customer")]
    public class Customer
    {
        [StringLength(10)]
        public string CustomerId { get; set; }

        [StringLength(250)]
        public string CustomerName { get; set; }
        
        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(1)]
        public bool IsActive { get; set; }

    }
}
