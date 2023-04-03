using Api.Data;
using Api.Data.Models;
using Api.Data.SBSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace WebAPI.Controllers
{
    [Authorize] 
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private readonly IStockInfoRepository stockInfoRepository;

        public StocksController(IStockInfoRepository stockInfoRepository)
        {
            this.stockInfoRepository = stockInfoRepository ?? throw new ArgumentNullException(nameof(stockInfoRepository));
        }

        // GET api/values
        [HttpGet("{stockCode}")]
        public IEnumerable<StockCurrentStockInfo> Get(string stockCode)
        {
            return stockInfoRepository.GetCurrentStock(stockCode);
            //return new List<StockCurrentStockInfo>();
        }

        // GET api/values/5/
        /// <summary>
        /// List Stock Hist
        /// </summary>
        /// <param name="from">yyyyMMdd</param>
        /// <param name="to">yyyyMMdd</param>
        /// <param name="stockCode">AAA</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(StockPriceHist), (int)HttpStatusCode.OK)]
        [HttpGet("{stockCode}/{from}/{to}")]
        public IEnumerable<StockPriceHist> GetPriceHistory(string stockCode, string from, string to)
        {
            try
            {
                if (!DateTime.TryParseExact(from, "yyyyMMdd", null, DateTimeStyles.None, out DateTime fromDate))
                    return new List<StockPriceHist>();
                if (!DateTime.TryParseExact(to, "yyyyMMdd", null, DateTimeStyles.None, out DateTime toDate))
                    return new List<StockPriceHist>();

                return stockInfoRepository.GetStockHistory(fromDate, toDate, stockCode);
            }
            catch
            {
                return new List<StockPriceHist>();
            }
        }
    }
}
