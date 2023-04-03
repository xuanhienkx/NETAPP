using System;

namespace HoseStockTrader.Models
{
    public class MarketInfo
    {
        public string Symbol { get; set; }

        public DateTime Date { get; set; }

        public double TotalTrade { get; set; }

        public double TotalValue { get; set; }

        public double TotalVolume { get; set; }

        public double CurrentIndex { get; set; }

        public double HighestIndex { get; set; }

        public double LowestIndex { get; set; }

        public double BasicIndex { get; set; }

        public int Advances { get; set; }

        public int NoChange { get; set; }

        public int Declines { get; set; }

        public string Status { get; set; }
    }
}
