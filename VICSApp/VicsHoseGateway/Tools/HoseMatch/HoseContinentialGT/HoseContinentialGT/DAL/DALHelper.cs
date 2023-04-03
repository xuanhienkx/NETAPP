using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console.App;

namespace HoseContinentialGT.DAL
{
    public static class DALHelper
    {
        public static bool HasTradingOrder(string orderDate, string orderNo, SqlConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                "SELECT COUNT(*) FROM [TradingOrder] WHERE [OrderDate]   = @OrderDate AND [BoardType]     = 'M' AND [OrderNo]       = @OrderNo";
            command.Parameters.Clear();
            command.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = orderDate;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = orderNo;
            return (((int)command.ExecuteScalar()) > 0);
        }

        public static void InsertTradingResult(string orderDate, string orderNo, string confirmNo, string confirmTime,
            string orderSide, string stockCode, string stockType, string customerId, decimal matchedVolume,
            decimal matchedPrice, bool isCross, SqlConnection connection)
        {
            Logger.Log("Insert trading result for {0}", orderNo);
            Logger.ConsoleLog("Insert trading result for {0}", orderNo);

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            string str = null;
            string str2 = null;
            command.CommandText = "SELECT [BranchCode], [TradeCode] FROM [Customers] WHERE [CustomerID] = @CustomerID";
            command.Parameters.Clear();
            command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    str = Convert.ToString(reader["BranchCode"]);
                    str2 = Convert.ToString(reader["TradeCode"]);
                }
            }
            confirmTime = confirmTime.Substring(0, 2) + ":" + confirmTime.Substring(2, 2) + ":" +
                          confirmTime.Substring(4, 2) + ":000";
            command.CommandText =
                "INSERT INTO [TradingResult] ( [OrderDate], [TransactionDate], [OrderSeq], [BranchCode], [TradeCode], [ConfirmTime], [ConfirmNo], [OrderNo], [OrderSide], [CustomerID], [CustomerBranchCode], [CustomerTradeCode], [BoardType], [StockCode], [StockType], [MatchedVolume], [MatchedPrice], [MatchedValue], [IsCross]) VALUES (@OrderDate, CONVERT(smalldatetime, @OrderDate, 103), NULL,NULL,NULL,@ConfirmTime,@ConfirmNo,@OrderNo,@OrderSide,@CustomerID,@CustomerBranchCode,@CustomerTradeCode,@BoardType,@StockCode,@StockType,@MatchedVolume,@MatchedPrice,@MatchedValue,@IsCross)";
            command.Parameters.Clear();
            command.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = orderDate;
            command.Parameters.Add("@ConfirmTime", SqlDbType.VarChar).Value = confirmTime;
            command.Parameters.Add("@ConfirmNo", SqlDbType.VarChar).Value = confirmNo;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = orderNo;
            command.Parameters.Add("@OrderSide", SqlDbType.VarChar).Value = orderSide;
            command.Parameters.Add("@BoardType", SqlDbType.VarChar).Value = "M";
            command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
            if (str != null)
            {
                command.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value = str;
            }
            else
            {
                command.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            if (str2 != null)
            {
                command.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value = str2;
            }
            else
            {
                command.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
            command.Parameters.Add("@StockType", SqlDbType.VarChar).Value = stockType;
            command.Parameters.Add("@MatchedVolume", SqlDbType.Decimal).Value = matchedVolume;
            command.Parameters.Add("@MatchedPrice", SqlDbType.Decimal).Value = matchedPrice;
            command.Parameters.Add("@MatchedValue", SqlDbType.Decimal).Value = (matchedVolume * matchedPrice) * 1000M;
            command.Parameters.Add("@IsCross", SqlDbType.VarChar).Value = isCross ? "Y" : "N";
            command.ExecuteNonQuery();
        }

        public static void InsertTradingOrder(string orderDate, string orderTime, string orderNo, string orderType,
            string orderSide, string stockCode, decimal orderVolume, decimal orderPrice, string customerId,
            string pcFlag, string orderStatus, decimal matchedVolume, decimal matchedValue,
            decimal publishedVolume, decimal publishedPrice, decimal cancelledVolume, SqlConnection connection)
        {
            Logger.Log("Insert trading order for {0}", orderNo);
            Logger.ConsoleLog("Insert trading order for {0}", orderNo);

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [StockType] FROM [GLStockCode] WHERE [StockCode] = @StockCode";
            command.Parameters.Clear();
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
            object obj2 = command.ExecuteScalar();
            if (obj2 == null)
            {
                throw new ApplicationException("Kh\x00f4ng thể x\x00e1c định loại chứng kho\x00e1n m\x00e3 " + stockCode);
            }
            string str = (string)obj2;
            string str2 = null;
            string str3 = null;
            command.CommandText = "SELECT [BranchCode], [TradeCode] FROM [Customers] WHERE [CustomerID] = @CustomerID";
            command.Parameters.Clear();
            command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    str2 = Convert.ToString(reader["BranchCode"]);
                    str3 = Convert.ToString(reader["TradeCode"]);
                }
            }
            orderTime = orderTime.Substring(0, 2) + ":" + orderTime.Substring(2, 2) + ":" + orderTime.Substring(4, 2) +
                        ":000";
            command.CommandText =
                "INSERT INTO [TradingOrder] ( [OrderDate], [TransactionDate], [OrderTime], [OrderSeq], [BranchCode], [TradeCode], [OrderNo], [OrderType], [OrderSide], [BoardType], [StockCode], [StockType], [OrderVolume], [OrderPrice], [CustomerID], [CustomerBranchCode], [CustomerTradeCode], [PCFlag], [OrderStatus], [MatchedVolume], [MatchedValue], [FeeRate], [PublishedVolume], [PublishedPrice], [CancelledVolume]) VALUES (@OrderDate,CONVERT(smalldatetime, @OrderDate, 103),@OrderTime,NULL,NULL,NULL,@OrderNo,@OrderType,@OrderSide,@BoardType,@StockCode,@StockType,@OrderVolume,@OrderPrice,@CustomerID,@CustomerBranchCode,@CustomerTradeCode,@PcFlag,@OrderStatus,@MatchedVolume,@MatchedValue,0,@PublishedVolume,@PublishedPrice,@CancelledVolume)";
            command.Parameters.Clear();
            command.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = orderDate;
            command.Parameters.Add("@OrderTime", SqlDbType.VarChar).Value = orderTime;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = orderNo;
            command.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = orderType;
            command.Parameters.Add("@OrderSide", SqlDbType.VarChar).Value = orderSide;
            command.Parameters.Add("@BoardType", SqlDbType.VarChar).Value = "M";
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
            command.Parameters.Add("@StockType", SqlDbType.VarChar).Value = str;
            command.Parameters.Add("@OrderVolume", SqlDbType.Decimal).Value = orderVolume;
            command.Parameters.Add("@OrderPrice", SqlDbType.Decimal).Value = orderPrice;
            command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
            if (str2 != null)
            {
                command.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value = str2;
            }
            else
            {
                command.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            if (str3 != null)
            {
                command.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value = str3;
            }
            else
            {
                command.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            command.Parameters.Add("@PcFlag", SqlDbType.VarChar).Value = pcFlag;
            command.Parameters.Add("@OrderStatus", SqlDbType.VarChar).Value = orderStatus;
            command.Parameters.Add("@MatchedVolume", SqlDbType.Decimal).Value = matchedVolume;
            command.Parameters.Add("@MatchedValue", SqlDbType.Decimal).Value = matchedValue;
            command.Parameters.Add("@PublishedVolume", SqlDbType.Decimal).Value = publishedVolume;
            command.Parameters.Add("@PublishedPrice", SqlDbType.Decimal).Value = publishedPrice;
            command.Parameters.Add("@CancelledVolume", SqlDbType.Decimal).Value = cancelledVolume;
            command.ExecuteNonQuery();
        }

        public static void UpdateFee(string tradingDate, List<string> stockTypes, SqlConnection connection)
        {
            var stockTypeCondition = string.Join("','", stockTypes);
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                Connection = connection,
                CommandText =
                    "SELECT [CustomerID], SUM([MatchedValue]) [MatchedValue] FROM [TradingResult] WHERE [OrderDate] = '" +
                    tradingDate +
                    "' AND [CustomerID] NOT LIKE '076P%' AND [StockType] in ('" + stockTypeCondition + "') AND [NoPost] = 0 GROUP BY [CustomerID]"
            };
            var adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string customerId = table.Rows[i]["CustomerID"].ToString();
                decimal matchedValue = Convert.ToDecimal(table.Rows[i]["MatchedValue"]);
                command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText =
                        "SELECT [Fee] FROM [TradeFeeDiscount] WHERE [CustomerID] = '" + customerId +
                        "' AND [StockType] = '" + stockTypes.First() + "'"
                };
                object discountFee = command.ExecuteScalar();
                command.CommandText =
                    string.Concat(
                        "SELECT [Fee] FROM [TradeFee] WHERE [StockType] = '" + stockTypes.First() +
                        "' AND [FromValue] <= ", matchedValue, " AND ", matchedValue, " <= [ToValue]");
                object tradeFee = command.ExecuteScalar();
                decimal fee = (tradeFee != null) ? Convert.ToDecimal(tradeFee) : 0M;
                decimal applyFee;
                if (discountFee != null)
                {
                    decimal discount = Convert.ToDecimal(discountFee);
                    applyFee = discount < fee ? discount : fee;
                }
                else
                {
                    applyFee = fee;
                }
                command.CommandText =
                    string.Concat("UPDATE [TradingResult] SET [FeeRate] = ", applyFee, " WHERE [OrderDate] = '",
                        tradingDate, "' AND [CustomerID] = '", customerId,
                        "' AND [StockType] IN ('" + stockTypeCondition + "') AND [FeeRate] <> ", applyFee);
                command.ExecuteNonQuery();
            }
            table.Dispose();
            adapter.Dispose();
        }

        public static SqlDataReader DataReader(string sql,SqlConnection connection)
        {
            Logger.Log("Select: {0}", sql);
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                Connection = connection,
                CommandText = sql
            };
            return command.ExecuteReader();
        }

        public static void ExecuteNonQuery(string sql, SqlConnection connection)
        {
            Logger.Log("Insert/Update: {0}", sql);
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                Connection = connection,
                CommandText = sql
            };
            command.ExecuteNonQuery();
        }
    }
}
