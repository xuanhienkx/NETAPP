using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerageGatewayManager.Entities
{
    public class Message
    {
        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private string _Value;
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }
}
