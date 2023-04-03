using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace HosePriceUpdate
{
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HoseGateway"].ConnectionString))
               {
                  connection.Open();
                  var command = new SqlCommand
                                   {
                                      CommandType = CommandType.Text,
                                      Connection = connection
                                   };
                  
                  command.CommandText = "select max(id) from dbo.HIST_HOSE_SU";
                  var idObj = command.ExecuteScalar();
                  if (idObj == null)
                  {
                     Console.WriteLine("Cannot get the max id of SU hist");
                     Console.ReadKey();
                     return;
                  }
                  int id = int.Parse(idObj.ToString());
                  Console.WriteLine("Get max id of SU hist: " + id);

                  var path = Path.Combine(ConfigurationManager.AppSettings["SecurityFilePath"], "SECURITY.DAT");

                  Console.WriteLine("Security path: " + path);

                  var securities = new SecuritiesReader(path);
                  securities.Open();
                  while (securities.Read() )
                  {
                     Console.WriteLine(securities.Data.StockSymbol + " Type:" + securities.Data.StockType + " StockNo:" +
                                       securities.Data.StockNo);


                     command.CommandText = BuildSql(securities.Data, ++id);
                     var result = command.ExecuteNonQuery();
                     if (result > 1)
                        Console.WriteLine("Inserted 1 record to history SU");
                     
                     // update SBS
                     command.CommandText = BuildSBSSql(securities.Data);
                     command.ExecuteNonQuery();
                  }

               }
               scope.Complete();

            }
         }
         catch (Exception exception)
         {
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
         }
         Console.ReadKey();
      }

      private static string BuildSBSSql(Securities sec)
      {
         return string.Empty;

         //var sql = "if not exits(select * from dbo.GlStockCode where StockCode = '"+sec.StockSymbol+"') \n" +
         //   "insert into dbo.GlStockCode(StockCode, StockType, StockName, ParValue, ShortName, BoarType, StocknameViet, StockFee, ListedVolume, RoomForeigner) \n" +
         //   "values('"+sec.StockSymbol+"', '"+sec.StockType+"','"+sec.StockName.Replace("'", "''")+"',"+sec.ParValue+",'"+sec.StockName.Replace("'", "''")+"','M','"+sec.StockName.Replace("'", "''")+",1,1000000,50000) \n" +


      }


      static string BuildSql(Securities sec, int id)
      {
         var sql =
            "if not exits(select * from dbo.HIST_HOSE_SU where SECURITY_SYMBOL = '"+sec.stockSymbol+"') \n" +
            "INSERT INTO dbo.HIST_HOSE_SU(id, LAST_MODIFIED ,MESSAGE_STATUS ,MESSAGE_TYPE ,SECURITY_NUMBER_NEW ,SECURITY_NUMBER_OLD ,SECTOR_NUMBER ,SECURITY_SYMBOL ,SECURITY_TYPE ,CEILING_PRICE ,FLOOR_PRICE ,LAST_SALE_PRICE ,MARKET_ID ,SECURITY_NAME ,PAR_VALUE ,BOARD_LOT ) \n" +
            "values(" + id + ",getdate() - 1,'R', 'SU','" + sec.StockNo + "','" + sec.StockNo + "',1,'" +
            sec.StockSymbol + "','" + sec.StockType + "','" + sec.Ceiling + "','" +
            sec.Floor + "','" + sec.PriorClosePrice + "','A','" + string.Join(string.Empty, sec.stockName).Replace("'", "''") +
            "',1000,10);";
         return sql;
      }

   }
}
