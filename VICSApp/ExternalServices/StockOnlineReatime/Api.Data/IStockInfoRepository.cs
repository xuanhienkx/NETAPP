using System;
using System.Collections.Generic;
using Api.Data.Models;
using Api.Data.SBSModels;

namespace Api.Data
{
    public interface IStockInfoRepository
    {
        IEnumerable<StockCurrentStockInfo> GetCurrentStock(string stockCode);
        IEnumerable<StockPriceHist> GetStockHistory(DateTime fromDate, DateTime toDate, string stockCode);
    }
}
