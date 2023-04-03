using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HnxWebService.Domain
{
   public sealed class HnxMsgOrder
   {
      public HnxMsgOrder() { }

      public string ClOrdID;
      public decimal ModiPrice;
      public decimal ModiVolume;
      public decimal ModiIoVolume;
      public string Status;

      public static List<HnxMsgOrder> GetListForCancel(string customerId, string stockCode, string orderside)
      {
         List<HnxMsgOrder> result = new List<HnxMsgOrder>();
         StringBuilder sql = new StringBuilder();
         sql.Append("SELECT o.ClOrdID FROM dbo.Msg_NewSingleOrder o WHERE o.Status = 'S' ");
         // khong co lenh huy
         sql.Append("AND NOT EXISTS(SELECT * FROM dbo.Msg_ExecutionReport c WHERE c.ClOrdID = o.ClOrdID and c.ExecType = 4 AND c.OrdStatus != '9') ");
         // khong co lenh cho sua
         sql.Append("AND NOT EXISTS(SELECT * FROM msg_orderreplacerequest r WHERE r.ClOrdId = o.ClOrdId and r.Status like '[SN]') \n");
         // khong co lenh cho huy chua
         sql.Append("AND NOT EXISTS(SELECT * FROM msg_ordercancelrequest n WHERE n.ClOrdId = o.ClOrdId and n.Status like '[SN]') \n");

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat(" AND o.Account like '%{0}' ", DBUtil.GetLiteral(customerId));
         if (!string.IsNullOrEmpty(stockCode))
            sql.AppendFormat(" AND o.Symbol = '{0}' ", DBUtil.GetLiteral(stockCode));
         if (!string.IsNullOrEmpty(orderside))
            sql.AppendFormat(" AND o.Side = '{0}' ", DBUtil.GetLiteral(orderside));

         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (reader.Read())
            {
               var itm = new HnxMsgOrder {ClOrdID = reader["ClOrdID"].ToString()};
               result.Add(itm);
            }
            reader.Close();
         }
         return result;
      }

      internal static List<HnxMsgOrder> GetDayCanceledList()
      {
         List<HnxMsgOrder> result = new List<HnxMsgOrder>();
         StringBuilder sql = new StringBuilder();

         sql.Append("select c.ClOrdID, c.Status, f.OrdStatus from msg_ordercancelrequest c ");
         sql.Append("left join [dbo].[Msg_ExecutionReport] f on f.[ClOrdID] = c.[ClOrdID] and f.ExecType = '4' ");

         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (reader.Read())
            {
               var itm = new HnxMsgOrder
                                    {
                                       ClOrdID = reader["ClOrdID"].ToString(),
                                       Status = reader["OrdStatus"] != DBNull.Value ? reader["OrdStatus"].ToString() : reader["Status"].ToString()
                                    };
               result.Add(itm);
            }
            reader.Close();
         }
         return result;
      }

      internal static List<HnxMsgOrder> GetDayModifiedList()
      {
         List<HnxMsgOrder> result = new List<HnxMsgOrder>();
         StringBuilder sql = new StringBuilder();

         sql.AppendLine("select c.ClOrdID, c.Price, c.CashOrderQty, c.OrderQty2, c.StopPx, c.Status, f.OrdStatus ");
         sql.AppendLine("from Msg_OrderReplaceRequest c left join ");
         sql.AppendLine("(select * from [Msg_ExecutionReport] m where m.id = (select max(id) from [Msg_ExecutionReport] where clordid = m.clordid and exectype = 5) ");
         sql.AppendLine(") f on f.[ClOrdID] = c.[ClOrdID] and f.LastPx = c.Price and f.LastQty = c.CashOrderQty ");
         sql.AppendLine("and (c.StopPx is null or f.StopPx = c.StopPx) and (c.OrderQty2 is null or f.OrderQty2 = c.OrderQty2) ");
         sql.AppendLine("order by c.ClOrdID, c.SendingTime ");
         //sql.AppendLine("where c.id = (select max(id) from Msg_OrderReplaceRequest m where m.ClOrdID = c.ClOrdID) ");

         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (reader.Read())
            {
               var itm = new HnxMsgOrder
                            {
                               ClOrdID = reader["ClOrdID"].ToString(),
                               Status =
                                  reader["OrdStatus"] != DBNull.Value
                                     ? reader["OrdStatus"].ToString()
                                     : reader["Status"].ToString(),
                               ModiPrice = (decimal) reader["Price"],
                               ModiVolume = (decimal) reader["CashOrderQty"]
                            };
               if (reader["OrderQty2"] != DBNull.Value)
                  itm.ModiIoVolume = (decimal)reader["OrderQty2"];
               if (reader["StopPx"] != DBNull.Value)
                  itm.ModiIoVolume = (decimal)reader["StopPx"];
               result.Add(itm);
            }
            reader.Close();
         }
         return result;
      }
   }
}
