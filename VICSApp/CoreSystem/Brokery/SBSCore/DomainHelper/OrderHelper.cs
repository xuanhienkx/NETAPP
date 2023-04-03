using CommonDomain;
using SBSCore.Common;
using SBSCore.HnxGateway;
using SBSCore.HoseGateway;
using SBSCore.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SBSCore.DomainHelper
{
    public static class OrderHelper
    {

        public static Order SubmitInfo(InquiryData orderInfo, DateTime transDate, UserLite uInfo)
        {
            Order result = null;

            Logger.Info("[SUBMIT ORDER] - {0} {1} {2} KL:{3:n0} {4}:{5:c}", orderInfo.Customer.CustomerId,
               orderInfo.OrderSide, orderInfo.TradingStock.StockCode, orderInfo.TradingStockVolume,
               orderInfo.TradingStockPriceType, orderInfo.TradingStockPrice);

            if (orderInfo.OrderSide == OrderSide.B)
            {
                decimal avlAmount = orderInfo.AvaiableBalance - orderInfo.TradingValue - orderInfo.TradingFee;

                if (avlAmount >= 0M) //TK co du so du tien mat dat lenh
                {
                    decimal amount = orderInfo.TradingValue + orderInfo.TradingFee;

                    Logger.Debug("AvaiableBalance: {0:n0}, amount: {1:n0}", orderInfo.AvaiableBalance, orderInfo.TradingValue + orderInfo.TradingFee);

                    CustomerTransactionDayHelper.Insert(CustomerTransactionDayHelper.Initialize(orderInfo, uInfo, transDate, amount, "H",
                       string.Format("Agency:PHONG TOA TIEN NGAN HANG TAI KHOAN {0} SO TIEN {1:n0}", orderInfo.Customer.CustomerId, amount)));

                    CustomerTransactionDayHelper.Insert(CustomerTransactionDayHelper.Initialize(orderInfo, uInfo, transDate, amount, "B",
                       string.Format("Agency:PHONG TOA TIEN MUA {0} SL: {1:n0} GIA: {2:c}",
                          orderInfo.TradingStock.StockCode,
                          orderInfo.TradingStockVolume.Value,
                          orderInfo.TradingStockPrice.Value))
                          );
                }
                else //Khong co so du tien mat
                {
                    Logger.Debug("AvaiableBalance: {0:n0} - Value:{1:n0} + Fee:{2:n0} - DebitLimit: {3:n0}",
                       orderInfo.AvaiableBalance, orderInfo.TradingValue, orderInfo.TradingFee, avlAmount);

                    CustomerDebitTransactionHelper.Insert(CustomerDebitTransactionHelper.Initialize(orderInfo, uInfo, transDate, avlAmount));
                }

                orderInfo.AvaiableBalance = Math.Max(avlAmount, 0M);
            }

            // insert new order
            result = OrderHelper.Initialize(orderInfo, uInfo, transDate);
            Insert(result);

            return result;
        }

        public static List<Order> SubmitOrderInfoForMany(InquiryData orderInfo, DateTime transDate, UserLite uInfo)
        {
            var result = new List<Order>();

            int maxVol = (orderInfo.TradingStock.BoardType == Util.HOSEBoard)
                ? Util.HOSE_MAX_VOLUME
                : Util.HNX_MAX_VOLUME - orderInfo.TradingStock.BoardLot;

            int stockVolume = orderInfo.TradingStockVolume.Value;
            int remaindVolume = stockVolume % maxVol;
            int numberOfOrders = stockVolume / maxVol;
            decimal feeRate = orderInfo.TradingFee / orderInfo.TradingValue;
            Order order;
            for (int i = 0; i < numberOfOrders; i++)
            {
                orderInfo.TradingStockVolume = maxVol;
                orderInfo.TradingValue = orderInfo.TradingStockVolume.Value * orderInfo.TradingStockPrice.Value * 1000;
                orderInfo.TradingFee = feeRate * orderInfo.TradingValue;

                // insert new order
                order = SubmitInfo(orderInfo, transDate, uInfo);
                result.Add(order);
            }

            // insert new order for remain volume
            orderInfo.TradingStockVolume = remaindVolume;
            orderInfo.TradingValue = orderInfo.TradingStockVolume.Value * orderInfo.TradingStockPrice.Value * 1000;
            orderInfo.TradingFee = feeRate * orderInfo.TradingValue;
            order = SubmitInfo(orderInfo, transDate, uInfo);
            result.Add(order);

            return result;
        }

        private static Order Initialize(InquiryData orderInfo, UserLite uInfo, DateTime transDate)
        {
            Order order = new Order();

            order.BoardType = orderInfo.TradingStock.BoardType;
            order.CustomerId = orderInfo.Customer.CustomerId;
            order.Fee = orderInfo.TradingFee;
            order.OrderDate = transDate;
            order.OrderSide = orderInfo.OrderSide.ToString();
            order.OrderType = orderInfo.TradingStockPriceType;
            order.Price = orderInfo.TradingStockPrice.Value;
            order.ReceivedBy = uInfo.UserName;
            order.StockCode = orderInfo.TradingStock.StockCode;
            order.Value = orderInfo.TradingValue;
            order.Volume = orderInfo.TradingStockVolume.Value;
            order.BranchCode = uInfo.BranchCode;
            order.TradeCode = uInfo.TradeCode;
            order.AlertCode = orderInfo.AlertCode;
            order.Session = orderInfo.Session;
            order.Notes = orderInfo.Notes;

            if (orderInfo.IcebergVolume.HasValue)
                order.IcebergVolume = orderInfo.IcebergVolume.Value;
            if (orderInfo.StopPrice.HasValue)
                order.StopPrice = orderInfo.StopPrice.Value;

            return order;
        }

        private static void Insert(Order order)
        {
            SqlParameter p1 = new SqlParameter("@OrderDate", SqlDbType.SmallDateTime);
            p1.Value = order.OrderDate;
            SqlParameter p2 = new SqlParameter("@OrderSide", SqlDbType.Char);
            p2.Value = order.OrderSide;
            SqlParameter p3 = new SqlParameter("@OrderType", SqlDbType.VarChar);
            p3.Value = order.OrderType;
            SqlParameter p4 = new SqlParameter("@StockCode", SqlDbType.VarChar);
            p4.Value = order.StockCode;
            SqlParameter p5 = new SqlParameter("@OrderVolume", SqlDbType.Int);
            p5.Value = order.Volume;
            SqlParameter p6 = new SqlParameter("@OrderPrice", SqlDbType.Decimal);
            p6.Value = order.Price;
            SqlParameter p7 = new SqlParameter("@CustomerID", SqlDbType.VarChar);
            p7.Value = order.CustomerId;
            SqlParameter p8 = new SqlParameter("@BranchCode", SqlDbType.VarChar);
            p8.Value = order.BranchCode;
            SqlParameter p9 = new SqlParameter("@TradeCode", SqlDbType.VarChar);
            p9.Value = order.TradeCode;
            SqlParameter p10 = new SqlParameter("@ReceivedBy", SqlDbType.VarChar);
            p10.Value = order.ReceivedBy;
            SqlParameter p11 = new SqlParameter("@AlertCode", SqlDbType.Char);
            p11.Value = order.AlertCode;
            SqlParameter p12 = new SqlParameter("@Notes", SqlDbType.VarChar);
            p12.Value = order.Notes;
            SqlParameter p13 = new SqlParameter("@Session", SqlDbType.Int);
            p13.Value = order.Session;
            SqlParameter p14 = new SqlParameter("@OrderTime", SqlDbType.VarChar, 12);
            p14.Direction = ParameterDirection.Output;
            SqlParameter p15 = new SqlParameter("@OrderSeq", SqlDbType.Int);
            p15.Direction = ParameterDirection.Output;
            SqlParameter p16 = new SqlParameter("@refNo", SqlDbType.Int);
            p16.Value = order.NoRef;
            SqlParameter p17 = new SqlParameter("@IsAgentOder", SqlDbType.Bit);
            p17.Value = order.IsOrderFromAgent;
            SqlParameter p18 = new SqlParameter("@OrderStatus", SqlDbType.Char);
            p18.Value = string.IsNullOrEmpty(order.OrderStatus) ? "P" : order.OrderStatus;
            SqlParameter p19 = new SqlParameter("@IcebergVolume", SqlDbType.Int);
            p19.Value = order.IcebergVolume;
            SqlParameter p20 = new SqlParameter("@StopPrice", SqlDbType.Decimal);
            p20.Value = order.StopPrice;

            DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_INSERTORDER,
               p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20);

            order.OrderSeq = (int)p15.Value;
            order.OrderTime = p14.Value.ToString();
        }

        public static void approveOrder(DateTime orderdate, int orderSeq, string approvedBy, string BranchCode)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@OrderDate", SqlDbType.SmallDateTime);
                p1.Value = orderdate;
                SqlParameter p2 = new SqlParameter("@OrderSeq", SqlDbType.Int);
                p2.Value = orderSeq;
                SqlParameter p3 = new SqlParameter("@ApprovedBy", SqlDbType.VarChar);
                p3.Value = approvedBy;
                SqlParameter p4 = new SqlParameter("@BranchCode", SqlDbType.VarChar);
                p4.Value = BranchCode;
                DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_APPROVEORDER, p1, p2, p3, p4);
            }
            catch (SqlException ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }

        public static void deleteOrder(DateTime orderdate, int orderSeq, string deleteBy)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@OrderDate", SqlDbType.SmallDateTime);
                p1.Value = orderdate;
                SqlParameter p2 = new SqlParameter("@OrderSeq", SqlDbType.Int);
                p2.Value = orderSeq;
                SqlParameter p3 = new SqlParameter("@DeleteBy", SqlDbType.VarChar);
                p3.Value = deleteBy;
                SqlParameter p4 = new SqlParameter("@AmountUnBlock", SqlDbType.Decimal);
                p4.Direction = ParameterDirection.Output;
                DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_DELETEORDER, p1, p2, p3, p4);
                //return Convert.ToDecimal(p4.Value);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }

        public static List<Order> GetList(IEnumerable<string> ids, bool isFilterOnOrderSeq)
        {
            var list = new List<Order>();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT     StockOrder.OrderDate, StockOrder.OrderTime, StockOrder.OrderSeq, StockOrder.OrderNo, StockOrder.OrderType, StockOrder.OrderSide, ");
            sql.AppendLine("CASE [StockOrder].[OrderSide] WHEN 'B' THEN N'Mua' WHEN 'S' THEN N'Bán' ELSE 'N/A' END AS OrderSideViet, StockOrder.BoardType, ");
            sql.AppendLine("StockOrder.StockCode, ISNULL(TradingOrder.OrderVolume, StockOrder.OrderVolume) as OrderVolume, ISNULL(TradingOrder.OrderPrice, StockOrder.OrderPrice) as OrderPrice, StockOrder.OrderFee, ");
            sql.AppendLine("StockOrder.CustomerId AS CustomerID, StockOrder.BranchCode, StockOrder.TradeCode, StockOrder.CustomerBranchCode, ");
            sql.AppendLine("StockOrder.CustomerTradeCode, StockOrder.ReceivedBy, StockOrder.ApprovedBy, StockOrder.Session, StockOrder.Notes, ");
            sql.AppendLine("ISNULL(TradingOrder.MatchedVolume, 0) AS MatchedVolume, ISNULL(TradingOrder.MatchedValue, 0) AS MatchedValue, ");
            sql.AppendLine("ISNULL(TradingOrder.PublishedVolume, 0) AS PublishedVolume, ISNULL(TradingOrder.PublishedPrice, 0) AS PublishedPrice, ");
            sql.AppendLine("ISNULL(TradingOrder.CancelledVolume, 0) AS CancelledVolume, ISNULL(TradingOrder.OrderStatus, StockOrder.OrderStatus) AS OrderStatus ");
            sql.AppendLine("FROM         StockOrder LEFT OUTER JOIN TradingOrder ON StockOrder.OrderNo = TradingOrder.OrderNo");

            sql.AppendFormat("Where StockOrder.{0} in ({1}) ",
               isFilterOnOrderSeq ? "OrderSeq" : "OrderNo",
               string.Join(",", ids.ToArray()));

            sql.AppendLine("ORDER BY dbo.StockOrder.OrderTime DESC");

            using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
            {
                while (reader.Read())
                {
                    var item = BuildOrder(reader);
                    list.Add(item);
                }
            }

            return list;
        }

        public static List<Order> GetList(DateTime orderdate, string branchcode, string tradecode, string stockCode, string customerid, string orderstatus, string receivedby, string orderside, int session, string boardtype, string bankCode, bool isPrivate)
        {
            List<Order> list = new List<Order>();

            using (SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_GETORDERLIST))
            {
                command.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = orderdate.ToString("dd/MM/yyyy");
                command.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(branchcode) ? null : branchcode;
                if (tradecode == "VICS" || tradecode == "VICSHCM" || tradecode == "VICSHUE")
                    command.Parameters.Add("@TradeCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(string.Empty) ? null : tradecode;
                else
                    command.Parameters.Add("@TradeCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(tradecode) ? null : tradecode;

                command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(stockCode) ? null : stockCode;
                command.Parameters.Add("@OrderSide", SqlDbType.VarChar).Value = string.IsNullOrEmpty(orderside) ? null : orderside;
                command.Parameters.Add("@BoardType", SqlDbType.VarChar).Value = string.IsNullOrEmpty(boardtype) ? null : boardtype;
                command.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(bankCode) ? DBNull.Value : (object)bankCode;

                command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerid;
                command.Parameters.Add("@OrderStatus", SqlDbType.Char).Value = orderstatus;
                command.Parameters.Add("@ReceivedBy", SqlDbType.VarChar).Value = receivedby;
                command.Parameters.Add("@IsPrivate", SqlDbType.Bit).Value = isPrivate;

                if (session > 0)
                    command.Parameters.Add("@Session", SqlDbType.Int).Value = session;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = BuildOrder(reader);
                        if ("XCF".Contains(item.OrderStatus))
                        {
                            item.PublishedPrice = 0;
                            item.PublishedVolume = 0;
                            if (item.OrderStatus.Trim().ToUpper().Equals("X"))
                            {
                                item.CancelledVolume = item.Volume;
                            }
                        }
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static List<Order> GetMatchedOrderList(DateTime orderdate, string branchcode, string tradecode, string stockCode, string customerid, string orderSide, string boardType)
        {
            var list = new List<Order>();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT     TradingOrder.OrderDate, TradingOrder.OrderTime, TradingOrder.OrderSeq, TradingOrder.OrderNo, TradingOrder.OrderType, TradingOrder.OrderSide, ");
            sql.AppendLine("CASE [TradingOrder].[OrderSide] WHEN 'B' THEN N'Mua' WHEN 'S' THEN N'Bán' ELSE 'N/A' END AS OrderSideViet, TradingOrder.BoardType, ");
            sql.AppendLine("TradingOrder.StockCode, TradingOrder.OrderVolume, TradingOrder.OrderPrice,  ");
            sql.AppendLine("TradingOrder.CustomerId AS CustomerID, TradingOrder.BranchCode, TradingOrder.TradeCode, TradingOrder.CustomerBranchCode, ");
            sql.AppendLine("TradingOrder.CustomerTradeCode, StockOrder.ReceivedBy, StockOrder.ApprovedBy, StockOrder.Session, StockOrder.Notes, StockOrder.OrderFee, ");
            sql.AppendLine("ISNULL(TradingResult.MatchedVolume, 0) as MatchedVolume, ");
            sql.AppendLine("ISNULL(TradingResult.MatchedPrice, 0) as MatchedPrice, ");
            sql.AppendLine("ISNULL(TradingResult.MatchedValue, 0) as MatchedValue, ");
            sql.AppendLine("ISNULL(TradingResult.FeeRate, TradingOrder.FeeRate) as FeeRate,");
            sql.AppendLine("TradingOrder.PublishedVolume, TradingOrder.PublishedPrice, TradingOrder.CancelledVolume, TradingOrder.OrderStatus ");
            sql.AppendLine("FROM         TradingOrder INNER JOIN StockOrder ON TradingOrder.OrderNo = StockOrder.OrderNo ");
            sql.AppendLine("LEFT OUTER JOIN TradingResult ON TradingOrder.OrderNo = TradingResult.OrderNo ");
            sql.AppendFormat("WHERE TradingOrder.BranchCode='{0}' and TradingOrder.TradeCode='{1}' \n",
                             LiteralUtil.GetLiteral(branchcode), LiteralUtil.GetLiteral(tradecode));
            if (!string.IsNullOrEmpty(stockCode))
                sql.AppendFormat("and TradingOrder.StockCode='{0}' \n", LiteralUtil.GetLiteral(stockCode));
            if (!string.IsNullOrEmpty(customerid))
                sql.AppendFormat("and TradingOrder.CustomerId like '%{0}' \n", LiteralUtil.GetLiteral(customerid));
            if (!string.IsNullOrEmpty(orderSide))
                sql.AppendFormat("and TradingOrder.OrderSide ='{0}' \n", LiteralUtil.GetLiteral(orderSide));
            if (!string.IsNullOrEmpty(boardType))
                sql.AppendFormat("and TradingOrder.BoardType ='{0}' \n", LiteralUtil.GetLiteral(boardType));

            using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
            {
                while (reader.Read())
                {
                    var item = BuildOrder(reader);
                    list.Add(item);
                }
            }
            return list;
        }

        private static Order BuildOrder(IDataReader reader)
        {
            var item = new Order();
            item.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
            item.OrderTime = reader["OrderTime"].ToString();
            item.OrderSeq = (int)reader["OrderSeq"];
            if (reader["OrderNo"] != DBNull.Value)
                item.OrderNo = reader["OrderNo"].ToString();
            item.OrderType = reader["OrderType"].ToString();
            item.OrderSide = reader["OrderSide"].ToString();
            item.OrderSideViet = reader["OrderSideViet"].ToString();
            item.BoardType = reader["BoardType"].ToString();
            item.StockCode = reader["StockCode"].ToString();
            item.Volume = (decimal)reader["OrderVolume"];
            item.Price = (decimal)reader["OrderPrice"];
            item.Value = item.Volume * item.Price * 1000;
            item.Fee = (decimal)reader["OrderFee"];
            item.CustomerId = reader["CustomerID"].ToString();
            item.BranchCode = reader["BranchCode"].ToString();
            item.TradeCode = reader["TradeCode"].ToString();
            item.ReceivedBy = reader["ReceivedBy"].ToString();
            item.ApprovedBy = reader["ApprovedBy"].ToString();
            item.Notes = reader["Notes"].ToString();
            item.MatchedVolume = (decimal)reader["MatchedVolume"];
            item.MatchedValue = (decimal)reader["MatchedValue"];
            if (reader.Contains("MatchedPrice"))
                item.MatchedPrice = (decimal)reader["MatchedPrice"];
            else
            {
                if ((decimal)reader["MatchedVolume"] > 0)
                    item.MatchedPrice = (decimal)reader["MatchedValue"] / (decimal)reader["MatchedVolume"] / 1000;
            }
            item.PublishedVolume = (decimal)reader["PublishedVolume"];
            item.PublishedPrice = (decimal)reader["PublishedPrice"];
            if (reader.Contains("FeeRate"))
                item.FeeRate = (decimal)reader["FeeRate"];

            item.OrderStatus = reader["OrderStatus"].ToString();
            if (item.OrderStatus == "X")
                item.CancelledVolume = (decimal)reader["OrderVolume"];
            else
                item.CancelledVolume = (decimal)reader["CancelledVolume"];
            if (reader["Session"] != DBNull.Value)
                item.Session = (int)reader["Session"];
            return item;
        }

        public static List<Order> GetListForCancel(string boardType, string customerId, string stockCode, string orderSide, DateTime transDate, UserLite user)
        {
            try
            {
                List<Order> result = new List<Order>();

                if (boardType == Util.HOSEBoard)
                {
                    HoseMsgOrder[] msgs = Util.HoseGateWay.GetListForCancel(customerId, stockCode, orderSide);
                    if (msgs.Length == 0)
                        return result;

                    List<Order> orders = OrderHelper.GetList(msgs.Select(x => string.Format("'{0}'", x.ORDER_NUMBER)), false);
                    FilterOrder(orders, msgs, result, false);
                }


                else if (boardType == Util.HNXBoard || boardType == Util.UpComBoard)
                {
                    string hnxOrderSide = string.Empty;
                    if (!string.IsNullOrEmpty(orderSide))
                        hnxOrderSide = orderSide == "B" ? "1" : "2";
                    HnxMsgOrder[] msgs = Util.HNXGateway.GetListForCancel(customerId, stockCode, hnxOrderSide);

                    if (msgs.Length == 0)
                        return result;

                    List<Order> orders = OrderHelper.GetList(msgs.Select(x => x.ClOrdID), true);
                    FilterOrder(orders, msgs, result, false);
                }
                else
                    throw new InvalidExpressionException("Không xác định được mã sàn giao dịch.");

                return result;
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }

        public static List<Order> GetDayCanceledOrModifiedList(string boardType, DateTime transDate, bool forCancel, UserLite user)
        {
            List<Order> result = new List<Order>();

            if (boardType == Util.HOSEBoard)
            {
                HoseMsgOrder[] msgs;
                if (forCancel)
                    msgs = Util.HoseGateWay.GetDayCancelList();
                else
                    return result;

                if (msgs.Length == 0)
                    return result;

                List<Order> orders = OrderHelper.GetList(msgs.Select(x => string.Format("'{0}'", x.ORDER_NUMBER)), false);
                OrderHelper.FilterOrder(orders, msgs, result, true);
            }
            else if (boardType == Util.HNXBoard || boardType == Util.UpComBoard)
            {
                HnxMsgOrder[] msgs;
                msgs = forCancel ? Util.HNXGateway.GetDayCanceledList() : Util.HNXGateway.GetDayModifiedList();
                if (msgs.Length == 0)
                    return result;

                List<Order> orders = OrderHelper.GetList(msgs.Select(x => x.ClOrdID), true);
                OrderHelper.FilterOrder(orders, msgs, result, true);
            }
            else
                throw new InvalidExpressionException("Không xác định được mã sàn giao dịch.");

            return result;
        }

        private static void FilterOrder(List<Order> orders, HoseMsgOrder[] msgs, List<Order> result, bool justShow)
        {
            foreach (Order ord in orders)
            {
                if (string.IsNullOrEmpty(ord.OrderNo))
                    continue;
                if (!justShow && "MCFD".Contains(ord.OrderStatus))
                    continue;

                foreach (HoseMsgOrder msg in msgs)
                {
                    if (msg.ORDER_NUMBER.ToString() == ord.OrderNo)
                    {
                        ord.OrderStatus = msg.STATUS;// to display on GUI instead of order status
                        result.Add(ord);
                        break;
                    }
                }
            }
        }

        private static void FilterOrder(List<Order> orders, HnxMsgOrder[] msgs, List<Order> result, bool justShow)
        {
            foreach (Order ord in orders)
            {
                if (string.IsNullOrEmpty(ord.OrderNo))
                    continue;
                if (!justShow && "MCFDX".Contains(ord.OrderStatus))
                    continue;

                foreach (HnxMsgOrder msg in msgs)
                {
                    if (msg.ClOrdID == ord.OrderSeq.ToString())
                    {
                        ord.ModifiedPrice = msg.ModiPrice;
                        ord.ModifiedVolume = msg.ModiVolume;
                        ord.OrderStatus = GetStatusString(msg.Status);
                        result.Add(ord);
                        break;
                    }
                }
            }
        }

        private static string GetStatusString(string hnxStatus)
        {
            if (hnxStatus == "N")
                return "Lệnh đang chờ tại VICS";
            if (hnxStatus == "S")
                return "Lệnh đã chuyển sang HNX";
            if (hnxStatus == "3")
                return "Lệnh hủy/sửa thành công";
            if (hnxStatus == "A")
                return "Lệnh đang chờ kiểm soát";
            if (hnxStatus == "D")
                return "Lệnh đã được đồng ý hủy/sửa";
            if (hnxStatus == "9")
                return "Lệnh không được hủy/sửa";
            if (hnxStatus == "C")
                return "Lệnh hủy/sửa không thành công do khớp hết";
            if (hnxStatus == "8")
                return "Lệnh bị từ chối";
            return "Không xác định trạng thái";
        }

        public static void Cancel(string boardType, string orderNumber, string canceledBy)
        {
            Logger.Info("[CANCEL ORDER] - Board:{0} orderNumber:{1} By:{2}", boardType, orderNumber, canceledBy);

            if (boardType == Util.HOSEBoard)
                Util.HoseGateWay.CancelOrder(orderNumber, canceledBy);
            else if (boardType == Util.HNXBoard || boardType == Util.UpComBoard)
                Util.HNXGateway.CancelOrder(orderNumber, canceledBy);
            else
                throw new InvalidExpressionException("Không xác định được sàn giao dịch.");
        }

        public static string GetHOSECurrentSession()
        {
            return Util.HoseGateWay.GetCurrentSession();
        }

        public static void ModifyHnxAndUpcomOrder(string boardType, int orderSeq, string orderNumber, InquiryData orderInfo, InquiryData modifiedOrderInfo, DateTime transDate, UserLite uInfo, decimal newHoldValue)
        {
            Logger.Info("[MODIFY ORDER] - {0} {1} {2} KL:{3:n0} {4}:{5:c}", orderInfo.Customer.CustomerId,
                        orderInfo.OrderSide, orderInfo.TradingStock.StockCode, orderInfo.TradingStockVolume,
                        orderInfo.TradingStockPriceType, orderInfo.TradingStockPrice);

            if (boardType == Util.HNXBoard || boardType == Util.UpComBoard)
            {
                Util.HNXGateway.ModifyOrder(orderNumber, orderInfo.TradingStockVolume.Value,
                   modifiedOrderInfo.TradingStockPrice.Value, modifiedOrderInfo.TradingStockVolume,
                   modifiedOrderInfo.StopPrice, modifiedOrderInfo.IcebergVolume);
            }
            else
            {
                var ex = new Exception("Yêu cầu không thực hiện được");
                Logger.Error("Modify order", ex);
                throw ex;
            }

            // phong toa va giai toa tien
            if (newHoldValue > 0M)//Hold
            {
                decimal tongTienThieu = (orderInfo.CurrentLimitValue * -1M) + Math.Min(orderInfo.AvaiableBalance - newHoldValue, 0M);
                if (tongTienThieu * -1M <= orderInfo.LitmitValue)
                {
                    // phong toa tien ngan hang
                    CustomerTransactionDayHelper.Insert(CustomerTransactionDayHelper.Initialize(orderInfo, uInfo, transDate,
                       newHoldValue, "H",
                       string.Format("Agency:PHONG TOA TIEN NGAN HANG TAI KHOAN {0} SO TIEN {1:n0}",
                          orderInfo.Customer.CustomerId,
                          newHoldValue
                          )));
                    // phong toa tien tai khoan
                    CustomerTransactionDayHelper.Insert(CustomerTransactionDayHelper.Initialize(orderInfo, uInfo, transDate,
                       newHoldValue, "B",
                       string.Format("Agency:PHONG TOA TIEN SUA MUA {0} SL: {1:n0} -> {2:n0} GIA: {3:c} -> {4:c}",
                          orderInfo.TradingStock.StockCode,
                          orderInfo.TradingStockVolume.Value,
                          modifiedOrderInfo.TradingStockVolume.Value,
                          orderInfo.TradingStockPrice.Value,
                          modifiedOrderInfo.TradingStockPrice.Value
                          )));

                    //Insert vao bang TradingChange phuc vu giai toa neu lenh huy
                    TradingChangeHelper.Insert(TradingChangeHelper.Initialize(orderSeq, orderNumber,
                       orderInfo.Customer.BranchCode,
                       orderInfo.Customer.BranchCode, orderInfo.Customer.CustomerId, orderInfo.Customer.CustomerName,
                       newHoldValue,
                       string.Format("Agency:TIEN CHENH LECH DO SUA GIA MUA {0} SL: {1:n0} -> {2:n0} GIA: {3:c} -> {4:c}",
                          orderInfo.TradingStock.StockCode,
                          orderInfo.TradingStockVolume.Value,
                          modifiedOrderInfo.TradingStockVolume.Value,
                          orderInfo.TradingStockPrice.Value,
                          modifiedOrderInfo.TradingStockPrice.Value),
                       uInfo.UserName));
                }
                else
                {
                    var ex = new Exception("Không đủ số dư để sửa lệnh");
                    Logger.Error("Modify order", ex);
                    throw ex;
                }
            }
        }
    }
}
