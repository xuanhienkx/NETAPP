using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.MarketInfoGateway
{
    public class SessionConfigurationSection
    {
        public string CurrentDate { get; set; }
        public long SessionNumber { get; set; }
        public long InputSequenceNumber { get; set; }
    }
}
