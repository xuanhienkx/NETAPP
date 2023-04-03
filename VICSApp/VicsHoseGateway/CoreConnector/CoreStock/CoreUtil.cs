using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using InterStock;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CoreStock
{
    public class CoreUtil
    {
        //------------------------------------------------
        //---------------- LINQ --------------------------
        //------------------------------------------------        

        static private CoreDBDataContext dataContext = new CoreDBDataContext(ConfigurationManager.ConnectionStrings["ConnStrCore"].ConnectionString);

        //----------- UPDATE STOCK_ORDER ----------------
        static public int linqUpdateOrderStatusBySeq(object orderSeq, object newStatus)
        {
            try{
                var order = (from row in dataContext.StockOrders where row.OrderSeq == Convert.ToInt32(orderSeq) select row).Single();
                order.OrderStatus = Convert.ToChar(newStatus);
                dataContext.SubmitChanges();
                return 1;
            }catch{return -1;}
        }
        static public int linqUpdateOrderStatusByOrderNo(object orderNo, object newStatus)
        {
            try
            {
                var order = (from row in dataContext.StockOrders where row.OrderNo == orderNo.ToString() select row).Single();
                order.OrderStatus = Convert.ToChar(newStatus);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqGetNextOrderSeq()
        {
            var r = dataContext.StockOrders.Max(tbl => tbl.OrderSeq) + 1;
            return r;
        }
        static public int linqUpdateOrderStatus(object OrderDate, object OrderSeq, object newStatus)
        {
            try
            {
                var order = (from row in dataContext.StockOrders where row.OrderSeq == Convert.ToInt32(OrderSeq) && 
                                 row.OrderDate == OrderDate.ToString() select row).Single();
                order.OrderStatus = Convert.ToChar(newStatus);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }  
        }

        //---------------- GET ORDERS ---------------------
        static public Branch[] linqGetBranches()
        {
            var brans = from row in dataContext.Branches
                        select row;
            return brans.ToArray();
        }
        static public StockOrder[] linqGetStockOrders(object status)
        {
            var stocks = from row in dataContext.StockOrders 
                         where row.OrderStatus == Convert.ToChar(status) && row.BoardType.ToString() == CommonSettings.Board
                         select row;
            return stocks.ToArray();            
        }
        static public StockOrder[] linqGetStockOrders(object lastSeq, object status)
        {
            var stocks = from row in dataContext.StockOrders
                         where row.OrderStatus == Convert.ToChar(status) && row.BoardType.ToString() == CommonSettings.Board
                         && row.OrderSeq > Convert.ToInt32(lastSeq)
                         select row;
            return stocks.ToArray();
        }
        static public StockOrder[] linqGetStockOrdersForCancel()
        {
            //var stocks = dataContext.StockOrders.Where(tbl => tbl.OrderStatus in ( char[]{'P','S'}));
            var stocks = from row in dataContext.StockOrders
                         where (row.OrderStatus == 'P' || row.OrderStatus == 'S' || row.OrderStatus == 'O')
                         && row.BoardType.ToString() == CommonSettings.Board
                         select row;
            return stocks.ToArray();            
        }
        //------------------------------------------------
        //---------------- END LINQ ----------------------
        //------------------------------------------------        


        //------------------------------------------------
        //---------------- CORE DATABASE ORDERS ----------
        //------------------------------------------------       
        static public int updateOrderNotes(object OrderSeq, object Notes)
        {
            string sql = "update StockOrder set Notes = @Notes " +
                "where OrderSeq = @OrderSeq";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@Notes", DbType.String, Notes);
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.String, OrderSeq);
            return DbCore.ExecuteNonQuery(cmd);
        } 
        static public int updateOrderStatusBySeq(object Seq, object NewStatus, object notes)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql;
            if (notes == null)
            {
                sql = "update StockOrder set OrderStatus = @NewStatus where OrderSeq = @Seq";
                DbCommand cmd = DbCore.GetSqlStringCommand(sql);
                DbCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
                DbCore.AddInParameter(cmd, "@Seq", DbType.Decimal, Seq);
                return DbCore.ExecuteNonQuery(cmd);
            }
            else
            {
                sql = "update StockOrder set OrderStatus = @NewStatus, notes = @notes where OrderSeq = @Seq";
                DbCommand cmd = DbCore.GetSqlStringCommand(sql);
                DbCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
                DbCore.AddInParameter(cmd, "@notes", DbType.String, notes);
                DbCore.AddInParameter(cmd, "@Seq", DbType.Decimal, Seq);
                return DbCore.ExecuteNonQuery(cmd);
            }            
        }
        static public int updateCancelOrderStatusBySeq(object Seq, object NewStatus)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand("update GW_StockOrderCancel set OrderStatus = @NewStatus where OrderSeq = @Seq");
            DbCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbCore.AddInParameter(cmd, "@Seq", DbType.Decimal, Seq);
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int updateChangeOrderStatusBySeq(object Seq, object NewStatus)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand("update GW_StockOrderChange set OrderStatus = @NewStatus where OrderSeq = @Seq");
            DbCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbCore.AddInParameter(cmd, "@Seq", DbType.Decimal, Seq);
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int updateOrderStatusByOrderNo(object OrderNumber, object NewStatus)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand("update StockOrder set OrderStatus = @NewStatus where OrderSeq = @OrderNumber");
            DbCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbCore.AddInParameter(cmd, "@OrderNumber", DbType.Decimal, OrderNumber);
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int updateStockOrder(object OrderDate, object OrderTime, object OrderSeq, object OrderType, object OrderSide
                , object BoardType, object StockCode, object OrderVolume, object OrderPrice, object OrderValue, object OrderFee
                , object CustomerID, object BranchCode, object TradeCode,
                object ReceivedBy, object ApprovedBy, object OrderStatus, object AlertCode, object Notes)
        {
            string sql = "update StockOrder set OrderType = @OrderType,OrderSide = @OrderSide" +
                                ",BoardType=@BoardType,StockCode=@StockCode,OrderVolume=@OrderVolume,OrderPrice=@OrderPrice, " +
                                "OrderValue = @OrderValue,OrderFee = @OrderFee" +
                                ",CustomerID = @CustomerID,BranchCode = @BranchCode,TradeCode=@TradeCode,ReceivedBy=@ReceivedBy " +
                                ",ApprovedBy=@ApprovedBy,OrderStatus=@OrderStatus,AlertCode=@AlertCode,Notes=@Notes " +
                                "where OrderDate = @OrderDate and OrderTime = @OrderTime and OrderSeq = @OrderSeq";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderType", DbType.String, OrderType);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@OrderVolume", DbType.Decimal, OrderVolume);
            DbCore.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, OrderPrice);
            DbCore.AddInParameter(cmd, "@OrderValue", DbType.Decimal, OrderValue);
            DbCore.AddInParameter(cmd, "@OrderFee", DbType.Decimal, OrderFee);
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);
            DbCore.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
            DbCore.AddInParameter(cmd, "@TradeCode", DbType.String, TradeCode);
            DbCore.AddInParameter(cmd, "@ReceivedBy", DbType.String, ReceivedBy);
            DbCore.AddInParameter(cmd, "@ApprovedBy", DbType.String, ApprovedBy);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, OrderStatus);
            DbCore.AddInParameter(cmd, "@AlertCode", DbType.String, AlertCode);
            DbCore.AddInParameter(cmd, "@Notes", DbType.String, Notes);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderTime", DbType.String, OrderTime);
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.String, OrderSeq);
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int getNextOrderSeq()
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            return (int)DbCore.ExecuteScalar(CommandType.Text, "select max(OrderSeq)+1 from StockOrder");            
        }         
        static public int insertStockOrder(object OrderDate,object OrderTime,object OrderSeq, object OrderType,object OrderSide
		        ,object BoardType,object StockCode,object OrderVolume,object OrderPrice,object OrderValue,object OrderFee
                , object CustomerID, object BranchCode, object TradeCode, object CustomerBranchCode, object CustomerTradeCode, 
                object ReceivedBy, object ApprovedBy, object OrderStatus, object AlertCode, object Notes, object Session,
                object TransactionDate, object RefNo)
        {
            string sql = "INSERT INTO StockOrder (OrderDate,OrderTime,OrderSeq, OrderType,OrderSide "+
		                        ",BoardType,StockCode,OrderVolume,OrderPrice,OrderValue,OrderFee "+
		                        ",CustomerID,BranchCode,TradeCode,CustomerBranchCode,CustomerTradeCode, "+
                        "ReceivedBy,ApprovedBy,OrderStatus,AlertCode,Notes, Session, TransactionDate, RefNo) "+
                        "values (@OrderDate,@OrderTime,@OrderSeq, @OrderType,@OrderSide " +
		                        ",@BoardType,@StockCode,@OrderVolume,@OrderPrice,@OrderValue,@OrderFee "+
                                ",@CustomerID,@BranchCode,@TradeCode,@CustomerBranchCode,@CustomerTradeCode,@ReceivedBy,@ApprovedBy,@OrderStatus,@AlertCode,@Notes, " +
                        "@Session, @TransactionDate, @RefNo)";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderTime", DbType.String, OrderTime);
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.Int32, OrderSeq);
            DbCore.AddInParameter(cmd, "@OrderType", DbType.String, OrderType);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@OrderVolume", DbType.Decimal, OrderVolume);
            DbCore.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, OrderPrice);
            DbCore.AddInParameter(cmd, "@OrderValue", DbType.Decimal, OrderValue);
            DbCore.AddInParameter(cmd, "@OrderFee", DbType.Decimal, OrderFee);
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);
            DbCore.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
            DbCore.AddInParameter(cmd, "@TradeCode", DbType.String, TradeCode);
            DbCore.AddInParameter(cmd, "@CustomerBranchCode", DbType.String, CustomerBranchCode);
            DbCore.AddInParameter(cmd, "@CustomerTradeCode", DbType.String, CustomerTradeCode);
            DbCore.AddInParameter(cmd, "@ReceivedBy", DbType.String, ReceivedBy);
            DbCore.AddInParameter(cmd, "@ApprovedBy", DbType.String, ApprovedBy);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, OrderStatus);
            DbCore.AddInParameter(cmd, "@AlertCode", DbType.String, AlertCode);
            DbCore.AddInParameter(cmd, "@Notes", DbType.String, Notes);
            DbCore.AddInParameter(cmd, "@Session", DbType.Int32, Session);
            DbCore.AddInParameter(cmd, "@TransactionDate", DbType.DateTime, TransactionDate);
            DbCore.AddInParameter(cmd, "@RefNo", DbType.Int32, RefNo);
            return DbCore.ExecuteNonQuery(cmd);      
        }
         
        static public int updateOrderStatus(object OrderDate, object OrderSeq, object newStatus)
        {
            string sql = "update StockOrder set OrderStatus = @OrderStatus "+
                "where OrderDate = @OrderDate and OrderSeq = @OrderSeq";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, newStatus);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);            
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.String, OrderSeq);
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int insertTradingOrder(object OrderDate,object OrderTime, object OrderNo, 
                object OrderSide ,object BoardType,object StockCode,object OrderVolume,object OrderPrice ,object CustomerID)
        {
            string sql = "INSERT INTO TradingOrder (OrderDate,OrderTime,OrderNo, OrderSide " +
                                ",BoardType,StockCode,OrderVolume,OrderPrice ,CustomerID) " +
                        "values (@OrderDate,@OrderTime, @OrderNo, @OrderSide " +
                                ",@BoardType,@StockCode,@OrderVolume,@OrderPrice ,@CustomerID)";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderTime", DbType.String, OrderTime);
            DbCore.AddInParameter(cmd, "@OrderNo", DbType.String, OrderNo);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@OrderVolume", DbType.Decimal, OrderVolume);
            DbCore.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, OrderPrice);            
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);            
            
            return DbCore.ExecuteNonQuery(cmd);
        }
        static public int insertTradingOrder(object OrderDate,object OrderTime,object OrderSeq, 
                object BranchCode, object TradeCode, object OrderNo, 
                object OrderType,object OrderSide ,object BoardType,object StockCode,object StockType, object OrderVolume,object OrderPrice
                ,object CustomerID,object CustomerBranchCode,object CustomerTradeCode, object PCFlag, object OrderStatus, 
                object MatchedVolume, object MatchedValue, object FeeRate, object PublishedVolume, object PublishedPrice, 
                object CancelledVolume, object TransactionDate)
        {
            string sql = "INSERT INTO TradingOrder (OrderDate,OrderTime,OrderSeq, BranchCode, TradeCode, OrderNo, OrderType,OrderSide " +
                                ",BoardType,StockCode,StockType, OrderVolume,OrderPrice" +
                                ",CustomerID,CustomerBranchCode,CustomerTradeCode, PCFlag, OrderStatus, MatchedVolume, MatchedValue, FeeRate," +
                        "PublishedVolume,PublishedPrice,CancelledVolume,TransactionDate) " +
                        "values (@OrderDate,@OrderTime,@OrderSeq, @BranchCode, @TradeCode, @OrderNo, @OrderType,@OrderSide " +
                                ",@BoardType,@StockCode,@StockType, @OrderVolume,@OrderPrice" +
                                ",@CustomerID,@CustomerBranchCode,@CustomerTradeCode, @PCFlag, @OrderStatus, @MatchedVolume, @MatchedValue, @FeeRate," +
                        "@PublishedVolume,@PublishedPrice,@CancelledVolume,@TransactionDate)";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderTime", DbType.String, OrderTime);
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.Int32, OrderSeq);
            DbCore.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
            DbCore.AddInParameter(cmd, "@TradeCode", DbType.String, TradeCode);
            DbCore.AddInParameter(cmd, "@OrderNo", DbType.String, OrderNo);
            DbCore.AddInParameter(cmd, "@OrderType", DbType.String, OrderType);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@StockType", DbType.String, StockType);
            DbCore.AddInParameter(cmd, "@OrderVolume", DbType.Decimal, OrderVolume);
            DbCore.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, OrderPrice);            
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);            
            DbCore.AddInParameter(cmd, "@CustomerBranchCode", DbType.String, CustomerBranchCode);
            DbCore.AddInParameter(cmd, "@CustomerTradeCode", DbType.String, CustomerTradeCode);
            DbCore.AddInParameter(cmd, "@PCFlag", DbType.String, PCFlag);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, OrderStatus);
            DbCore.AddInParameter(cmd, "@MatchedVolume", DbType.Decimal, MatchedVolume);
            DbCore.AddInParameter(cmd, "@MatchedValue", DbType.Decimal, MatchedValue);
            DbCore.AddInParameter(cmd, "@FeeRate", DbType.Decimal, FeeRate);
            DbCore.AddInParameter(cmd, "@PublishedVolume", DbType.Decimal, PublishedVolume);
            DbCore.AddInParameter(cmd, "@PublishedPrice", DbType.Decimal, PublishedPrice);
            DbCore.AddInParameter(cmd, "@CancelledVolume", DbType.Decimal, CancelledVolume);
            DbCore.AddInParameter(cmd, "@TransactionDate", DbType.DateTime, TransactionDate);
            
            return DbCore.ExecuteNonQuery(cmd);
        }        
        static public int insertTradingResult(object Id,object OrderDate,object OrderNo,object ConfirmNo,object ConfirmTime,object BranchCode,object TradeCode 
		                    ,object OrderSeq,object OrderSide,object CustomerID,object CustomerBranchCode,object CustomerTradeCode 
		                    ,object BoardType,object StockCode,object StockType,object MatchedVolume,object MatchedPrice,object MatchedValue
                            , object FeeRate, object NoPost, object Status, object IsCross, object T, object T2, object T3, object Deferred, object TransactionDate)
        {
            string sql = "INSERT INTO TradingResult "+
                    "(Id,OrderDate,OrderNo,ConfirmNo,ConfirmTime,BranchCode,TradeCode "+
		                    ",OrderSeq,OrderSide,CustomerID,CustomerBranchCode,CustomerTradeCode "+
		                    ",BoardType,StockCode,StockType,MatchedVolume,MatchedPrice,MatchedValue "+
		                    ",FeeRate,NoPost,Status,IsCross,T,T2,T3,Deferred,TransactionDate) "+
                    "values (@Id,@OrderDate,@OrderNo,@ConfirmNo,@ConfirmTime,@BranchCode,@TradeCode "+
		                    ",@OrderSeq,@OrderSide,@CustomerID,@CustomerBranchCode,@CustomerTradeCode "+
		                    ",@BoardType,@StockCode,@StockType,@MatchedVolume,@MatchedPrice,@MatchedValue "+
		                    ",@FeeRate,@NoPost,@Status,@IsCross,@T,@T2,@T3,@Deferred,@TransactionDate)";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@Id", DbType.String, Id);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderNo", DbType.String, OrderNo);
            DbCore.AddInParameter(cmd, "@ConfirmNo", DbType.String, ConfirmNo);
            DbCore.AddInParameter(cmd, "@ConfirmTime", DbType.String, ConfirmTime);
            DbCore.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
            DbCore.AddInParameter(cmd, "@TradeCode", DbType.String, TradeCode);
            DbCore.AddInParameter(cmd, "@OrderSeq", DbType.Int32, OrderSeq);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);
            DbCore.AddInParameter(cmd, "@CustomerBranchCode", DbType.String, CustomerBranchCode);
            DbCore.AddInParameter(cmd, "@CustomerTradeCode", DbType.String, CustomerTradeCode);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@StockType", DbType.String, StockType);
            DbCore.AddInParameter(cmd, "@MatchedVolume", DbType.Decimal, MatchedVolume);
            DbCore.AddInParameter(cmd, "@MatchedPrice", DbType.Decimal, MatchedPrice);
            DbCore.AddInParameter(cmd, "@MatchedValue", DbType.Decimal, MatchedValue);
            DbCore.AddInParameter(cmd, "@FeeRate", DbType.Decimal, FeeRate);
            DbCore.AddInParameter(cmd, "@NoPost", DbType.Boolean, NoPost);
            DbCore.AddInParameter(cmd, "@Status", DbType.Int32, Status);
            DbCore.AddInParameter(cmd, "@IsCross", DbType.String, IsCross);
            DbCore.AddInParameter(cmd, "@T", DbType.Boolean, T);
            DbCore.AddInParameter(cmd, "@T2", DbType.Boolean, T2);
            DbCore.AddInParameter(cmd, "@T3", DbType.Boolean, T3);
            DbCore.AddInParameter(cmd, "@Deferred", DbType.Boolean, Deferred);
            DbCore.AddInParameter(cmd, "@TransactionDate", DbType.DateTime, TransactionDate);

            return DbCore.ExecuteNonQuery(cmd);
        }
        /// it truong hon        
        static public int insertTradingResult(object OrderDate, object OrderNo, object ConfirmNo, object ConfirmTime, 
                            object OrderSide, object CustomerID, object BoardType, 
                    object StockCode, object MatchedVolume, object MatchedPrice, object MatchedValue)
        {
            string sql = "INSERT INTO TradingResult " +
                    "(OrderDate,OrderNo,ConfirmNo,ConfirmTime,OrderSide,CustomerID" +
                            ",BoardType,StockCode,MatchedVolume,MatchedPrice,MatchedValue) " +
                    "values (@OrderDate,@OrderNo,@ConfirmNo,@ConfirmTime, @OrderSide,@CustomerID " +
                            ",@BoardType,@StockCode,@MatchedVolume,@MatchedPrice,@MatchedValue) ";                            
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderDate", DbType.String, OrderDate);
            DbCore.AddInParameter(cmd, "@OrderNo", DbType.String, OrderNo);
            DbCore.AddInParameter(cmd, "@ConfirmNo", DbType.String, ConfirmNo);
            DbCore.AddInParameter(cmd, "@ConfirmTime", DbType.String, ConfirmTime);
            DbCore.AddInParameter(cmd, "@OrderSide", DbType.String, OrderSide);
            DbCore.AddInParameter(cmd, "@CustomerID", DbType.String, CustomerID);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, BoardType);
            DbCore.AddInParameter(cmd, "@StockCode", DbType.String, StockCode);
            DbCore.AddInParameter(cmd, "@MatchedVolume", DbType.Decimal, MatchedVolume);
            DbCore.AddInParameter(cmd, "@MatchedPrice", DbType.Decimal, MatchedPrice);
            DbCore.AddInParameter(cmd, "@MatchedValue", DbType.Decimal, MatchedValue);
            
            return DbCore.ExecuteNonQuery(cmd);
        }  
        //////////////////////////////
        static public IDataReader getStockOrders(object status)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT A.OrderDate, A.OrderTime, a.OrderSeq, a.OrderNo, a.OrderType, a.OrderSide, a.BoardType, a.StockCode, a.OrderVolume, " +
                        "a.OrderPrice, a.OrderValue, a.OrderFee, a.CustomerID, a.BranchCode, a.TradeCode, a.OrderStatus, " +
                        "a.ReceivedBy,a.ApprovedBy,a.AlertCode,a.Notes, b.DomesticForeign, case when b.DomesticForeign = 'D' then 'C' else 'F' end as PCFlag "+
                        "FROM StockOrder A left join Customers B on A.CustomerID = B.CustomerID " +
                        "where A.OrderStatus = @OrderStatus and a.BoardType = @BoardType " +
                        "ORDER BY a.OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, status);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, CommonSettings.Board);
            return DbCore.ExecuteReader(cmd);
        }
        /*
        static public StockOrder[] getStockOrdersArray(object status)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT A.OrderDate, A.OrderTime, a.OrderSeq, a.OrderNo, a.OrderType, a.OrderSide, a.BoardType, a.StockCode, a.OrderVolume, " +
                        "a.OrderPrice, a.OrderValue, a.OrderFee, a.CustomerID, a.BranchCode, a.TradeCode, a.OrderStatus, " +
                        "a.ReceivedBy,a.ApprovedBy,a.AlertCode,a.Notes, b.DomesticForeign, case when b.DomesticForeign = 'D' then 'C' else 'F' end as PCFlag FROM StockOrder A inner join Customers B on A.CustomerID = B.CustomerID " +
                        "where A.OrderStatus = @OrderStatus and a.BoardType = @BoardType " +
                        "ORDER BY a.OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, status);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, CommonSettings.Board);
            return DbCore.ExecuteReader(cmd);
        }*/
        static public StockOrder[] getStockOrdersArray(object status)
        {
            List<StockOrder> lstStockOrders = new List<StockOrder>();
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT A.OrderDate, A.OrderTime, a.OrderSeq, a.OrderNo, a.OrderType, a.OrderSide, a.BoardType, a.StockCode, a.OrderVolume, " +
                        "a.OrderPrice, a.OrderValue, a.OrderFee, a.CustomerID, a.BranchCode, a.TradeCode, a.OrderStatus, " +
                        "a.ReceivedBy,a.ApprovedBy,a.AlertCode,a.Notes, b.DomesticForeign, case when b.DomesticForeign = 'D' then 'C' else 'F' end as PCFlag "+
                        "FROM StockOrder A left join Customers B on A.CustomerID = B.CustomerID " +
                        "where A.OrderStatus = @OrderStatus and a.BoardType = @BoardType " +
                        "ORDER BY a.OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, status);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, CommonSettings.Board);
            SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(cmd);
            while (rd.Read())
            {
                StockOrder order = new StockOrder();
                order.OrderDate = rd["OrderDate"].ToString();
                order.CustomerID = rd["CustomerID"].ToString();
                order.OrderTime = rd["OrderTime"].ToString();
                order.OrderSeq = Convert.ToInt32(rd["OrderSeq"]);
                order.OrderNo = DBNull.Value == rd["OrderNo"] ? "" : rd["OrderNo"].ToString();
                order.OrderType = rd["OrderType"].ToString();
                order.OrderSide = Convert.ToChar(rd["OrderSide"]);
                order.BoardType = Convert.ToChar(rd["BoardType"]);
                order.StockCode = rd["StockCode"].ToString().Trim();
                order.OrderVolume = DBNull.Value == rd["OrderVolume"] ? 0 : Convert.ToDecimal(rd["OrderVolume"]);
                order.OrderPrice = DBNull.Value == rd["OrderPrice"] ? 0 : Convert.ToDecimal(rd["OrderPrice"]);
                order.OrderValue = DBNull.Value == rd["OrderValue"] ? 0 : Convert.ToDecimal(rd["OrderValue"]);
                order.OrderFee = DBNull.Value == rd["OrderFee"] ? 0 : Convert.ToDecimal(rd["OrderFee"]);
                order.BranchCode = rd["BranchCode"].ToString();
                order.TradeCode = rd["TradeCode"].ToString();
                order.OrderStatus = Convert.ToChar(rd["OrderStatus"]);
                order.ReceivedBy = rd["ReceivedBy"].ToString();
                order.ApprovedBy = rd["ApprovedBy"].ToString();
                lstStockOrders.Add(order);
            }
            rd.Close();
            return lstStockOrders.ToArray();
        }
        static public IDataReader getStockOrders(object lastID, object status)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT A.OrderDate, A.OrderTime, a.OrderSeq, a.OrderNo, a.OrderType, a.OrderSide, a.BoardType, a.StockCode, a.OrderVolume, " +
                        "a.OrderPrice, a.OrderValue, a.OrderFee, a.CustomerID, a.BranchCode, a.TradeCode, a.OrderStatus, " +
                        "a.ReceivedBy,a.ApprovedBy,a.AlertCode,a.Notes, b.DomesticForeign, case when b.DomesticForeign = 'D' then 'C' else 'F' end as PCFlag "+
                        "FROM StockOrder A left join Customers B on A.CustomerID = B.CustomerID " +
                        "where A.OrderSeq > @lastID AND A.OrderStatus = @OrderStatus and a.BoardType = @BoardType " +
                        "ORDER BY a.OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@lastID", DbType.Int64, lastID);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, status);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, CommonSettings.Board);
            return DbCore.ExecuteReader(cmd);
        }
        static public DataTable getStockOrdersByStatus(object orderStatus)
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT A.OrderDate, A.OrderTime, a.OrderSeq, a.OrderNo, a.OrderType, a.OrderSide, a.BoardType, a.StockCode, a.OrderVolume, " +
                        "a.OrderPrice, a.OrderValue, a.OrderFee, a.CustomerID, a.BranchCode, a.TradeCode, a.OrderStatus, " +
                        "a.ReceivedBy,a.ApprovedBy,a.AlertCode,a.Notes, b.DomesticForeign, case when b.DomesticForeign = 'D' then 'C' else 'F' end as PCFlag "+
                        "FROM StockOrder A left join Customers B on A.CustomerID = B.CustomerID " +
                        "where A.OrderStatus = @OrderStatus and a.BoardType = @BoardType " +
                        "ORDER BY a.OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@OrderStatus", DbType.String, orderStatus);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, CommonSettings.Board);
            return DbCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public DataTable getStockOrdersForCancel()
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT [OrderDate],[OrderSeq],[OrderStatus] FROM [GW_StockOrderCancel] where OrderStatus = 'N' order by OrderSeq";
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            return DbCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public CoreStockOrderCancel[] getStockOrdersForCancelArray()
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT [OrderDate],[OrderSeq],[OrderStatus] FROM [GW_StockOrderCancel] where OrderStatus = 'N' order by OrderSeq";
            //DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(CommandType.Text,sql);
            List<CoreStockOrderCancel> lst = new List<CoreStockOrderCancel>();
            while (rd.Read())
            {
                CoreStockOrderCancel order = new CoreStockOrderCancel();
                order.OrderDate = rd["OrderDate"].ToString();
                order.OrderStatus = rd["OrderStatus"].ToString();
                order.OrderSeq = Convert.ToInt32(rd["OrderSeq"]);
                lst.Add(order);
            }
            rd.Close();
            return lst.ToArray();
        }
        static public CoreStockOrderChange[] getStockOrdersForChangeArray()
        {
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            string sql = "SELECT [OrderDate],[OrderSeq],[OrderStatus],CustomerID FROM [GW_StockOrderChange] where OrderStatus = 'N' order by OrderSeq";
            //DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(CommandType.Text, sql);
            List<CoreStockOrderChange> lst = new List<CoreStockOrderChange>();
            while (rd.Read())
            {
                CoreStockOrderChange order = new CoreStockOrderChange();
                order.OrderDate = rd["OrderDate"].ToString();
                order.OrderStatus = rd["OrderStatus"].ToString();
                order.OrderSeq = Convert.ToInt32(rd["OrderSeq"]);
                order.CustomerIDNew = rd["CustomerID"].ToString();
                lst.Add(order);
            }
            rd.Close();
            return lst.ToArray();
        }
    }
}
