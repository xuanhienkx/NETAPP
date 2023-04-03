using System;
using System.Collections.Generic;

namespace SMS.Data.Services.EF.Models
{
    public class MatchedMessageModel
    {
        public string CustomerId { get; set; }
        public string OrderNo { get; set; }
        public string StockCode { get; set; }
        public string OrderSide { get; set; }
        public int OrderVolume { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public List<Guid> SbsReultId { get; set; }
    }

    public class MatchedModel
    {
        public string CustomerId { get; set; }
        public string StockCode { get; set; }
        public string OrderSide { get; set; }
        public int OrderVolume { get; set; }
        public List<MatchedByOrderModel> Matcheds { get; set; }
    }

    public class MatchedByOrderModel
    {
        public decimal Price { get; set; }
        public int Volume { get; set; }
    }

}