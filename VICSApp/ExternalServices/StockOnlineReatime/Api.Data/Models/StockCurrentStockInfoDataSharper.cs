using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Api.Data.Extensions;

namespace Api.Data.Models
{
    public sealed class StockCurrentStockInfoDataSharper : DataShaper<StockCurrentStockInfo>
    {
        public StockCurrentStockInfoDataSharper()
            : base(rd =>
            {
                var scsi = new StockCurrentStockInfo
                {
                    BuyForeignQuantity = rd.TryGet("BuyForeignQuantity", rd.GetDouble, 0),
                    BuyCount = rd.TryGet("BuyCount", rd.GetDouble, 0),
                    BuyForeignValue = rd.TryGet("BuyForeignValue", rd.GetDouble, 0),
                    BuyQuantity = rd.TryGet("BuyQuantity", rd.GetDouble, 0),
                    CoveredWarrantType = rd.TryGet("BuyQuantity", rd.GetString, string.Empty),
                    CurrentForeignRoom = rd.TryGet("CurrentForeignRoom", rd.GetDouble, 0),
                    ExercisePrice = rd.TryGet("ExercisePrice", rd.GetDecimal, 0),
                    ExerciseRatio = rd.TryGet("ExerciseRatio", rd.GetString, string.Empty),
                    IssuerName = rd.TryGet("IssuerName", rd.GetString, string.Empty),
                    LastTradingDate = rd.TryGet("LastTradingDate", rd.GetString, string.Empty),
                    ListedShare = rd.TryGet("ListedShare", rd.GetDecimal, 0),
                    MaturityDate = rd.TryGet("MaturityDate", rd.GetString, string.Empty),
                    PermDate = rd.TryGet("PermDate", rd.GetDateTime, DateTime.Today),
                    PriceAverage = rd.TryGet("PriceAverage", rd.GetDouble, 0),
                    PriceBasic = rd.TryGet("PriceBasic", rd.GetDouble, 0),
                    PriceBid1 = rd.TryGet("PriceBid1", rd.GetDouble, 0),
                    PriceBid2 = rd.TryGet("PriceBid2", rd.GetDouble, 0),
                    PriceBid3 = rd.TryGet("PriceBid3", rd.GetDouble, 0),
                    PriceCeiling = rd.TryGet("PriceCeiling", rd.GetDouble, 0),
                    PriceClose = rd.TryGet("PriceClose", rd.GetDouble, 0),
                    PriceCurrent = rd.TryGet("PriceCurrent", rd.GetDouble, 0),
                    PriceFloor = rd.TryGet("PriceFloor", rd.GetDouble, 0),
                    PriceHigh = rd.TryGet("PriceHigh", rd.GetDouble, 0),
                    PriceLow = rd.TryGet("PriceLow", rd.GetDouble, 0),
                    PriceOffer1 = rd.TryGet("PriceOffer1", rd.GetDouble, 0),
                    PriceOffer2 = rd.TryGet("PriceOffer2", rd.GetDouble, 0),
                    PriceOffer3 = rd.TryGet("PriceOffer3", rd.GetDouble, 0),
                    PriceOpen = rd.TryGet("PriceOpen", rd.GetDouble, 0),
                    QuantityBid1 = rd.TryGet("QuantityBid1", rd.GetDouble, 0),
                    QuantityBid2 = rd.TryGet("QuantityBid2", rd.GetDouble, 0),
                    QuantityBid3 = rd.TryGet("QuantityBid3", rd.GetDouble, 0),
                    QuantityOffer1 = rd.TryGet("QuantityOffer1", rd.GetDouble, 0),
                    QuantityOffer2 = rd.TryGet("QuantityOffer2", rd.GetDouble, 0),
                    QuantityOffer3 = rd.TryGet("QuantityOffer3", rd.GetDouble, 0),
                    SellCount = rd.TryGet("SellCount", rd.GetDouble, 0),
                    SellForeignQuantity = rd.TryGet("SellForeignQuantity", rd.GetDouble, 0),
                    SellForeignValue = rd.TryGet("SellForeignValue", rd.GetDouble, 0),
                    SellQuantity = rd.TryGet("SellQuantity", rd.GetDouble, 0),
                    TotalValue = rd.TryGet("TotalValue", rd.GetDouble, 0),
                    TotalVolume = rd.TryGet("TotalVolume", rd.GetDouble, 0),
                    UnderlyingSymbol = rd.TryGet("UnderlyingSymbol", rd.GetString, string.Empty),
                    Volume = rd.TryGet("Volume", rd.GetDouble, 0),
                    Name = rd.TryGet("Name", rd.GetString, string.Empty),
                    Symbol = rd.TryGet("Symbol", rd.GetString, string.Empty)
                };
                return scsi;
            })
        {
        }
    }
}