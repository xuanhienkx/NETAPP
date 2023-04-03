using SMS.Common;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Models
{
    public class SmsSummary
    {
        public MobileType Type { get; set; }
        public int Quantity { get; set; }
    }
}