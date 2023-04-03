using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CommonDomain;

namespace SBSCore.DomainHelper
{
   public static class GLStockCodeHelper
   {
      
      public static List<GLStockCode> GetStockList(string board)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("SELECT b.[StockCode], b.[StockType], a.[Name], a.[BoardLot], b.[StockNameViet], [CeilingPrice], [FloorPrice], [BasicPrice],Halted ");
         sql.Append("FROM [TradingBoard]	a ");
         sql.Append("INNER JOIN [GLStockCode] b ON a.[BoardType] = b.[BoardType] ");
         sql.Append("INNER JOIN [StockPrice] s ON b.[StockCode] = s.[StockCode] ");
         sql.AppendFormat("WHERE b.[StockType] like '[SUE]' AND a.[BoardType] = '{0}'", board);
        
         List<GLStockCode> result = new List<GLStockCode>();
         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (reader.Read())
            {
               GLStockCode code = new GLStockCode();
               code.StockCode = reader.GetString(reader.GetOrdinal("StockCode"));
               code.StockType = reader.GetString(reader.GetOrdinal("StockType"));
               code.CeilingPrice = reader.GetDecimal(reader.GetOrdinal("CeilingPrice"));
               code.FloorPrice = reader.GetDecimal(reader.GetOrdinal("FloorPrice"));
               code.BasicPrice = reader.GetDecimal(reader.GetOrdinal("BasicPrice"));
               code.BoardType = board;
               code.BoardName = reader.GetString(reader.GetOrdinal("Name"));
               code.BoardLot = reader.GetInt32(reader.GetOrdinal("BoardLot"));
               code.StockName = reader.GetString(reader.GetOrdinal("StockNameViet"));
               code.Halted = reader.GetString(reader.GetOrdinal("Halted"));
               result.Add(code);
            }
            reader.Close();
            reader.Dispose();
         }
         if (result.Count == 0)
            return null;
         return result;
      }


   }
}
