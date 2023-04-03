using System;

namespace HoseStockTrader.Models
{
    public class PutAd
    {
        public string StockId { get; set; }

        public int TradeId { get; set; }

        public double Volume { get; set; }

        public double Price { get; set; }

        public int FirmNo { get; set; }

        public string Side { get; set; }

        public string Board { get; set; }

        public DateTime Time { get; set; }

        public string Flag { get; set; }
    }
}
