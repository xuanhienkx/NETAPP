using System;
using System.Collections.Generic;
using System.Text;

namespace VSDGateway
{
    public class SessionConfigurationSection
    {
        public string CurrentDate { get; set; }
        public long SessionNumber { get; set; }
        public long InputSequenceNumber { get; set; }
    }
}
