using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Common.Contract.MarketModels
{
    [ProtoContract]
    public class PrsMessageModel
    {
        public string MessageName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public string UpdateType { get; set; }
        public string TradingDate { get; set; }
        public DateTime ProcessTime => DateTime.Now;
    }
}
