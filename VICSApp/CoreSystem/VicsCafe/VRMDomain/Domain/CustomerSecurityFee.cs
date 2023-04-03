using System;
using System.Text;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
    public class CustomerSecurityFee
    {
        public string AccountId { get; set; }
        public decimal FeeAmount { get; set; }
        public DateTime TradingDate { get; set; }
        public DateTime FeeDate { get; set; }
        public string Status { get; set; }
        public bool IsLasted { get; set; }
        public string CreatedBy { get; set; }
        public string BranchCode { get; set; }
        public string TradeCode { get; set; } 

    }
}