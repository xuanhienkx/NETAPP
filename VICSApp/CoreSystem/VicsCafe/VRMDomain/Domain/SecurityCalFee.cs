using System;
using System.Data.SqlClient;
using System.Text;

namespace VRMDomain.Domain
{
    public class SecurityCalFee
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public DateTime DateCalFee { get; set; }
        public int Quantity { get; set; }
        public string StockCode { get; set; }
        public decimal FeeAmount { get; set; }
    }
}