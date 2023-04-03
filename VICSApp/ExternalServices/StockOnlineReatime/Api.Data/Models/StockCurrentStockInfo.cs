using System;
using System.Collections.Generic;

namespace Api.Data.Models
{
    public class StockCurrentStockInfo
    {
        public int SymbolId { get; set; }
        public DateTime PermDate { get; set; }
        public double? PriceBasic { get; set; }
        public double? PriceCeiling { get; set; }
        public double? PriceFloor { get; set; }
        public double? PriceCurrent { get; set; }
        public double? PriceLast { get; set; }
        public double? PriceChange { get; set; }
        public double? PricePercentChange { get; set; }
        public double? TotalVolume { get; set; }
        public double? Volume { get; set; }
        public double? TotalTrade { get; set; }
        public double? TotalValue { get; set; }
        public double? PriceHigh { get; set; }
        public double? PriceLow { get; set; }
        public double? PriceOpen { get; set; }
        public double? PriceClose { get; set; }
        public double? PriceAverage { get; set; }
        public double? PriceBid1 { get; set; }
        public double? QuantityBid1 { get; set; }
        public double? PriceBid2 { get; set; }
        public double? QuantityBid2 { get; set; }
        public double? PriceBid3 { get; set; }
        public double? QuantityBid3 { get; set; }
        public double? PriceOffer1 { get; set; }
        public double? QuantityOffer1 { get; set; }
        public double? PriceOffer2 { get; set; }
        public double? QuantityOffer2 { get; set; }
        public double? PriceOffer3 { get; set; }
        public double? QuantityOffer3 { get; set; }
        public double? BasicForeignRoom { get; set; }
        public double? CurrentForeignRoom { get; set; }
        public double? BuyCount { get; set; }
        public double? SellCount { get; set; }
        public double? BuyForeignCount { get; set; }
        public double? BuyForeignQuantity { get; set; }
        public double? BuyForeignValue { get; set; }
        public double? SellForeignCount { get; set; }
        public double? SellForeignQuantity { get; set; }
        public double? SellForeignValue { get; set; }
        public double? SellQuantity { get; set; }
        public double? BuyQuantity { get; set; }
        public string UnderlyingSymbol { get; set; }
        public string IssuerName { get; set; }
        public string CoveredWarrantType { get; set; }
        public string MaturityDate { get; set; }
        public string LastTradingDate { get; set; }
        public decimal? ExercisePrice { get; set; }
        public string ExerciseRatio { get; set; }
        public decimal? ListedShare { get; set; } 
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
