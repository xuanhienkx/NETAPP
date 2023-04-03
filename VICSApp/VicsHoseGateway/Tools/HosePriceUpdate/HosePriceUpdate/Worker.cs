using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace HosePriceUpdate
{
   internal class Worker
   {
      // Fields
      private static string prsFileRoot = ConfigurationManager.AppSettings["PRSFileData"];
      private string marketStatus;
      // Events


      // Methods
      public static string GetFilePath(DateTime time)
      {
         string path = Path.Combine(prsFileRoot,"DATAPATH.MAP");
         if (!File.Exists(path))
         {
            throw new Exception("Không tìm thấy DATAPATH.MAP");
         }
         Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
         var reader = new StreamReader(stream);
         string s = null;
         var buffer = new char[0x12];
         while ((s = reader.ReadLine()) != null)
         {
            var reader2 = new StringReader(s);
            while (reader2.Read(buffer, 0, buffer.Length) == buffer.Length)
            {
               var str3 = new string(buffer, 0, 10);
               if (time.ToString("dd/MM/yyyy").Equals(str3))
               {
                  var str4 = new string(buffer, 10, 8);
                  return Path.Combine(prsFileRoot, str4);
               }
            }
         }
         throw new Exception("Không có thư mục dữ liệu cho ngày " + time.ToString("dd/MM/yyyy"));
      }



      protected void OnDoWork(DoWorkEventArgs e)
      {
         var fileRoot = GetFilePath(DateTime.Now);
         var tradingDate = DateTime.Now.ToString("dd/MM/yyyy");
         using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
         {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SBS"].ConnectionString))
            {
               connection.Open();
               var command = new SqlCommand
                                       {
                                          CommandType = CommandType.Text,
                                          Connection = connection
                                       };
               var path = Path.Combine(fileRoot, "MARKET_STAT.DAT");
               if (File.Exists(path))
               {
                  var marketStatus = new MarketStatusReader(path);
                  marketStatus.Open();
                  while (marketStatus.Read())
                  {
                     if (((marketStatus.Data.ControlCode == 'P') ||
                     (marketStatus.Data.ControlCode == 'O')) ||
                     ((marketStatus.Data.ControlCode == 'A') ||
                     (marketStatus.Data.ControlCode == 'C')))
                     {
                        this.marketStatus = "O";
                     }
                  else
                     if (marketStatus.Data.ControlCode == 'K')
                     {
                        this.marketStatus = "C";
                     }
                  }
                  marketStatus.Close();
                  command.CommandText = "UPDATE [OrderSysStat] SET [MarketStatus] = @MarketStatus WHERE [OrderDate] = @OrderDate AND [BoardType] = @BoardType";
                  command.Parameters.Clear();
                  command.Parameters.Add("@MarketStatus", SqlDbType.VarChar).Value = this.marketStatus;
                  command.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = tradingDate;
                  command.Parameters.Add("@BoardType", SqlDbType.VarChar).Value = "M";
                  command.ExecuteNonQuery();
               }

               path = Path.Combine(fileRoot, "SECURITY.DAT");
               var securities = new SecuritiesReader(path);
               securities.Open();
               while (securities.Read())
               {
                  string sql = "SELECT COUNT(*) FROM [StockPrice] WHERE [TradingDate] = '" + tradingDate + "' AND [StockCode] = '" + securities.Data.StockSymbol + "' AND [BoardType] = 'M'";
                  command.CommandText = sql;
                  bool flag = ((int) command.ExecuteScalar()) > 0;
                  decimal priorClosePrice = Convert.ToDecimal(securities.Data.PriorClosePrice) / 100M;
                  decimal cellingPrice = Convert.ToDecimal(securities.Data.Ceiling) / 100M;
                  decimal floorPrice = Convert.ToDecimal(securities.Data.Floor) / 100M;
                  decimal openPrice = Convert.ToDecimal(securities.Data.OpenPrice) / 100M;
                  decimal lastPrice = Convert.ToDecimal(securities.Data.LastPrice) / 100M;
                  if (flag)
                  {
                     if (this.marketStatus.Equals("C"))
                     {
                        sql =
                           string.Concat(new object[]
                                            {
                                               "UPDATE [StockPrice] SET [OpenPrice] = ", openPrice, ", [ClosePrice] = ", lastPrice,
                                               ", [AveragePrice] = 0 WHERE [TradingDate] = '", tradingDate,
                                               "' AND [StockCode] = '", securities.Data.StockSymbol, "' AND [BoardType] = 'M'"
                                            });
                     }
                  else
                     {
                        sql =
                           string.Concat(new object[]
                                            {
                                               "UPDATE [StockPrice] SET [BasicPrice] = ", priorClosePrice, ", [CeilingPrice] = ",
                                               cellingPrice, ", [FloorPrice] = ", floorPrice, ", [OpenPrice] = ", openPrice,
                                               ", [ClosePrice] = ", lastPrice, ", [AveragePrice] = 0 WHERE [TradingDate] = '",
                                               tradingDate, "' AND [StockCode] = '", securities.Data.StockSymbol, "' AND [BoardType] = 'M'"
                                            });
                     }
                     command.CommandText = sql;
                     command.ExecuteNonQuery();
                  }
                  else
                  {
                     sql = string.Concat(new object[]
                                             {
                                                "INSERT INTO [StockPrice] ( [TradingDate], [StockCode], [StockType], [BoardType], [BasicPrice], [CeilingPrice], [FloorPrice], [OpenPrice], [ClosePrice], [AveragePrice]) VALUES ('"
                                                , tradingDate, "','", securities.Data.StockSymbol, "','", securities.Data.StockType, "','M',", priorClosePrice, ",",
                                                cellingPrice, ",", floorPrice, ",", openPrice, ",", lastPrice,
                                                ",0)"
                                             });
                     command.CommandText = sql;
                     command.ExecuteNonQuery();
                  }
               }
               securities.Close();

               if (this.marketStatus.Equals("C"))
               {
                  ///Close();
               }
            }
         }
      }
   }

}