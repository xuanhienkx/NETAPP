using System;

namespace HoseStockTrader.Models
{
    public class StockInfo
    {
        public string StockId { get; set; }

        public string Symbol { get; set; }

        public DateTime Date { get; set; }

        public double PriceBasic { get; set; }

        public double PriceCeiling { get; set; }

        public double PriceFloor { get; set; }

        public double PriceCurrent { get; set; }

        public double PriceHigh { get; set; }

        public double PriceLow { get; set; }

        public double PriceOpen { get; set; }

        public double PriceClose { get; set; }

        public double PriceAverage { get; set; }

        public double Volume { get; set; }

        public double TotalVolume { get; set; }

        public double TotalValue { get; set; }

        public double Bid1Price { get; set; }

        public double Bid1Volume { get; set; }

        public double Bid2Price { get; set; }

        public double Bid2Volume { get; set; }

        public double Bid3Price { get; set; }

        public double Bid3Volume { get; set; }

        public double Offer1Price { get; set; }

        public double Offer1Volume { get; set; }

        public double Offer2Price { get; set; }

        public double Offer2Volume { get; set; }

        public double Offer3Price { get; set; }

        public double Offer3Volume { get; set; }

        public double BuyCount { get; set; }

        public double BuyQuantity { get; set; }

        public double SellQuantity { get; set; }

        public double SellCount { get; set; }

        public double BuyForeignQuantity { get; set; }

        public double SellForeignQuantity { get; set; }

        public double BuyForeignValue { get; set; }

        public double SellForeignValue { get; set; }

        public double CurrentForeignRoom { get; set; }
        private double _currentForeignRoom;
        public string UnderlyingSymbol { get; set; }

        public string IssuerName { get; set; }

        public string CoveredWarrantType { get; set; }

        public string MaturityDate { get; set; }

        public string LastTradingDate { get; set; }

        public long ExercisePrice { get; set; }

        public string ExerciseRatio { get; set; }

        public double ListedShare { get; set; }
    }
}
