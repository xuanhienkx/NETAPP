using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VRMDomain.Domain
{
    public class VariableCapitalPrice
    {
        public Guid Id { get; set; }
        public string StockCode { get; set; }
        public Decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public static VariableCapitalPrice Db2Object(SqlDataReader r)
        {
            var s = new VariableCapitalPrice();
            s.Id = Guid.Parse(r["Id"].ToString());
            s.StockCode = r["StockCode"].ToString();
            s.Price = (Decimal)r["Price"];
            s.TransactionDate = (DateTime)r["TransactionDate"];
            return s;
        }

        public static List<VariableCapitalPrice> GetList(string stockCode, DateTime fromDate, DateTime toDate)
        {
            var result = new List<VariableCapitalPrice>();
            string sql =
                string.Format(
                    "select * from VariableCapitalPriceHist where TransactionDate between '{0}' and '{1} 23:59:59'", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            if (!string.IsNullOrEmpty(stockCode))
            {
                sql += string.Format(" and StockCode = '{0}'", stockCode);
            }

            sql += " order by StockCode, TransactionDate";

            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
            {
                while (r.Read())
                    result.Add(Db2Object(r));
                r.Close();
                r.Dispose();
            }
            return result;
        }
        internal static string BuildInserSql(VariableCapitalPrice capitalPrice)
        {
            var sql = new StringBuilder();
            sql.Append("INSERT INTO [dbo].[VariableCapitalPriceHist] ([Id] ,[StockCode] ,[Price] ,[TransactionDate]) VALUES(");
            sql.AppendFormat("'{0}' ,", Guid.NewGuid());
            sql.AppendFormat("'{0}' ,", capitalPrice.StockCode);
            sql.AppendFormat("{0} ,", capitalPrice.Price);
            sql.AppendFormat("'{0}' )", capitalPrice.TransactionDate.ToString("yyyy-MM-dd"));
            return sql.ToString();
        }
        internal static string BuildUpdateSql(VariableCapitalPrice capitalPrice)
        {
            var sql = new StringBuilder();
            sql.Append("Update [dbo].[VariableCapitalPriceHist] SET");
            sql.AppendFormat(" Price = {0} ", capitalPrice.Price);
            sql.AppendFormat(" where Id = '{0}'", capitalPrice.Id);
            return sql.ToString();
        }

        internal static string BuildDeleteSql(VariableCapitalPrice capitalPrice)
        {
            var sql = new StringBuilder();
            sql.Append("Delete [dbo].[VariableCapitalPriceHist] "); 
            sql.AppendFormat(" where Id = '{0}'", capitalPrice.Id);
            return sql.ToString();
        }

        public static void Save(VariableCapitalPrice capitalPrice)
        {
            var sql = string.Empty;
            sql = capitalPrice.Id == Guid.Empty ? BuildInserSql(capitalPrice) : BuildUpdateSql(capitalPrice);
            DBUtil.ExecuteNonQuery(sql);
        }
        public static void Delete(VariableCapitalPrice capitalPrice)
        {
            var sql = string.Empty;
            sql = BuildDeleteSql(capitalPrice);
            DBUtil.ExecuteNonQuery(sql);
        }

    }
}