using System;
using System.Collections.Generic;

namespace Api.Data.SBSModels
{
    /// <summary>
    /// Chọn dữ liệu trên Database SBS, table StockPriceHist.
    /// </summary>
    public  class StockPriceHist
    {
        public string TradingDate { get; set; }
        public string StockCode { get; set; }
        public int? StockNo { get; set; }
        public string StockType { get; set; }
        public string BoardType { get; set; }
        public decimal? OpenPrice { get; set; }
        public decimal? ClosePrice { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? CeilingPrice { get; set; }
        public decimal? FloorPrice { get; set; }
        public decimal? AveragePrice { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? TotalRoom { get; set; }
        public decimal? CurrentRoom { get; set; }
        public string Suspension { get; set; }
        public string Delisted { get; set; }
        public string Halted { get; set; }
        public string Split { get; set; }
        public string Benefit { get; set; }
        public string Meeting { get; set; }
        public string Notice { get; set; }
        public string UnderlyingSymbol { get; set; }
        public string IssuerName { get; set; }
        public string CoveredWarrantType { get; set; }
        public string MaturityDate { get; set; }
        public string LastTradingDate { get; set; }
        public decimal? ExercisePrice { get; set; }
        public string ExerciseRatio { get; set; }
        public decimal? ListedShare { get; set; }
    }
}
