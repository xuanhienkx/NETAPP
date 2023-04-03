using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using VRMDomain.Common;
using System.Data;

namespace VRMDomain.Domain
{
   public sealed class Stock
   {
      public string StockCode;
      public int ValueRate;
      public decimal CellingFixedPrice;
      public string CreatedBy;
      public string ModifiedBy;
      public DateTime CreatedDate = DateTime.MinValue;
      public DateTime ModifiedDate = DateTime.MinValue;

      public Stock() { }

      private static Stock DB2Object(SqlDataReader r)
      {
         Stock s = new Stock();
         s.CellingFixedPrice = (decimal)r["CellingFixedPrice"];
         s.CreatedBy = r["CreatedBy"].ToString();
         s.CreatedDate = (DateTime)r["CreatedDate"];
         if (r["ModifiedBy"] != DBNull.Value)
            s.ModifiedBy = r["ModifiedBy"].ToString();
         if (r["ModifiedDate"] != DBNull.Value)
            s.ModifiedDate = (DateTime)r["ModifiedDate"];
         s.StockCode = r["StockCode"].ToString();
         s.ValueRate = (int)r["ValueRate"];
         return s;
      }

      public static List<Stock> GetList(UserLite user, string stockCode)
      {
         List<Stock> result = new List<Stock>();
         string sql = "select StockCode,ValueRate,CellingFixedPrice,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate from vrm_Stock";
         if (!string.IsNullOrEmpty(stockCode))
            sql += " where stockcode like '%" + LiteralUtil.GetLiteral(stockCode) + "%'";
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            while (r.Read())
               result.Add(DB2Object(r));

            r.Close();
            r.Dispose();
         }
         return result;
      }

      public static void Save(Stock stock, UserLite user)
      {
         string sql;
         if (stock.CreatedDate == DateTime.MinValue)
            sql = SqlHelper.BuildInsertSql(stock, user);
         else
            sql = SqlHelper.BuildUpdateSql(stock, user);
         DBUtil.ExecuteNonQuery(sql);
      }

      public static void Delete(Stock stock)
      {
         string sql = string.Format("delete from vrm_Stock where StockCode = '{0}'", stock.StockCode);
         DBUtil.ExecuteNonQuery(sql);
      }

      public static Stock Get(string stockCode, UserLite user)
      {
         Stock result = null;
         string sql = string.Format("select StockCode,ValueRate,CellingFixedPrice,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate from vrm_Stock where stockcode = '{0}' ", stockCode);
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            if (r.Read())
               result = DB2Object(r);

            r.Close();
            r.Dispose();
         }
         if (result == null)
         {
            sql = string.Format("select StockCode,0 as ValueRate,0.0 as CellingFixedPrice,'' as CreatedBy,null as ModifiedBy,getdate() as CreatedDate,null as ModifiedDate from glstockcode where stockcode = '{0}'", stockCode);
            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
            {
               if (r.Read())
               {
                  result = DB2Object(r);
                  result.CreatedDate = DateTime.MinValue;
               }

               r.Close();
               r.Dispose();
            }
         }
         return result;
      }

      private sealed class SqlHelper
      {
         internal static string BuildInsertSql(Stock stock, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into vrm_Stock(StockCode,ValueRate,CellingFixedPrice,CreatedBy,CreatedDate) values(");
            sql.AppendFormat("'{0}'", stock.StockCode);
            sql.AppendFormat(",{0}", stock.ValueRate);
            sql.AppendFormat(",{0}", LiteralUtil.GetNumericLiteral(stock.CellingFixedPrice));
            sql.AppendFormat(",'{0}'", user.UserName);
            sql.AppendFormat(",{0})", LiteralUtil.GetLiteral(DateTime.Now));
            return sql.ToString();
         }

         internal static string BuildUpdateSql(Stock stock, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("update vrm_Stock set ");
            sql.AppendFormat("ValueRate = {0}", stock.ValueRate);
            sql.AppendFormat(",CellingFixedPrice = {0}", LiteralUtil.GetNumericLiteral(stock.CellingFixedPrice));
            sql.AppendFormat(",ModifiedBy = '{0}'", user.UserName);
            sql.AppendFormat(",ModifiedDate = {0}", LiteralUtil.GetLiteral(DateTime.Now));
            sql.AppendFormat("where StockCode = '{0}' ", stock.StockCode);
            return sql.ToString();
         }
      }

      public static DataTable GetMissingStocks()
      {
         string sql = "select StockCode, BoardType, OpenPrice, ClosePrice, BasicPrice, StockType from dbo.StockPrice where StockCode not in (select StockCode from dbo.GlStockCode) ";
         return DBUtil.ExecuteDataSet(sql).Tables[0];
      }
   }
}
