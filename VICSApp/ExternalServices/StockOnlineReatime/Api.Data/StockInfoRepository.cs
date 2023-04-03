using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Api.Data.Core;
using Api.Data.Models;
using Api.Data.SBSModels;
using Microsoft.Extensions.Configuration;

namespace Api.Data
{
    public class StockInfoRepository : IStockInfoRepository
    {
        private readonly IConfigurationRoot config;
        private readonly DataMaterializer<StockCurrentStockInfo> stockMaterializer;
        private readonly DataMaterializer<StockPriceHist> stockHistMaterializer;

        public StockInfoRepository(IConfigurationRoot config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            stockMaterializer = new DataMaterializer<StockCurrentStockInfo>(new StockCurrentStockInfoDataSharper());
            stockHistMaterializer = new DataMaterializer<StockPriceHist>(new StockPriceHistDataSharper());
        }

        public IEnumerable<StockCurrentStockInfo> GetCurrentStock(string stockCode)
        {
            try
            {
                using (var conn = new SqlConnection { ConnectionString = config.GetConnectionString(GlobalConstantsProvider.QuoteConnectionString) })
                {
                    conn.Open();
                    using (var command = new SqlCommand("GetListStockQuotes", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@SymbolList", stockCode.Trim().ToUpper());
                        return stockMaterializer.Materialize(command);
                    }
                }
            }
            catch
            {
                return new List<StockCurrentStockInfo>();
            }
        }


        public IEnumerable<StockPriceHist> GetStockHistory(DateTime fromDate, DateTime toDate, string stockCode)
        {
            try
            {
                using (var conn = new SqlConnection { ConnectionString = config.GetConnectionString(GlobalConstantsProvider.SbsConnectionString) })
                {
                    var sbsQuery = "Select * From StockPriceHist Where StockCode=@StockCode And Convert(date, TransactionDate) Between @BeginDate And @EndDate Order By TransactionDate";

                    conn.Open();
                    using (var command = new SqlCommand(sbsQuery, conn) { CommandType = CommandType.Text })
                    {
                        command.Parameters.AddWithValue("@StockCode", stockCode);
                        command.Parameters.AddWithValue("@BeginDate", fromDate);
                        command.Parameters.AddWithValue("@EndDate", toDate);
                        return stockHistMaterializer.Materialize(command);
                    }
                }
            }
            catch
            {
                return new List<StockPriceHist>();
            }
        }
    }
}
