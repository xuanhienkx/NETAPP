using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace HnxWebService.Domain
{
   public static class HNXDal
   {
      internal static void CancelOrder(string orderNumber)
      {

         string sql = "SELECT ClOrdID FROM Msg_OrderCancelRequest WHERE ClOrdID = (SELECT ClOrdID FROM Msg_ExecutionReport WHERE MsgType = '8' and ExecType = '0' and OrdStatus = '0' and OrderID = '" + orderNumber + "')";
         if (DBUtil.ExecuteScalar(sql) != null)
            throw new Exception("Đã có lệnh hủy rồi");

         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP("HNX_Vics_CancelOrder");
         cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
         cmd.ExecuteNonQuery();
      }

      internal static void ModifyOrder(string orderNumber, decimal oldVolume, decimal newPrice, decimal? newVolume, decimal? newStopPrice, decimal? newIcebergVolume)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP("HNX_Vics_ModifyOrder");
         cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
         cmd.Parameters.AddWithValue("@oldVolume", oldVolume);
         cmd.Parameters.AddWithValue("@newPrice", newPrice); 

         if (newVolume.HasValue)
            cmd.Parameters.AddWithValue("@newVolume", newVolume);
         else
            cmd.Parameters.AddWithValue("@newVolume", DBNull.Value);

         if (newStopPrice.HasValue)
            cmd.Parameters.AddWithValue("@newStopPrice", newStopPrice);
         else
            cmd.Parameters.AddWithValue("@newStopPrice", DBNull.Value);

         if (newIcebergVolume.HasValue)
            cmd.Parameters.AddWithValue("@newIcebergVolume", newIcebergVolume);
         else
            cmd.Parameters.AddWithValue("@newIcebergVolume", DBNull.Value);

         cmd.ExecuteNonQuery();
         //Phong toa giai toa tien
      }

      public static HnxTradingSession GetTradingSession(string boardCode)
      {
         string sql = string.Format("select top 1 TradingSessionID, TradSesStatus from Msg_TradingSessionStatus where TradSesMode = 1 and tradsesReqId = '{0}' order by Id desc", boardCode);
         using (var dr = DBUtil.ExecuteDataReader(sql))
         {
            if (dr.Read())
            {
                return HnxTradingSession.Parse(dr["TradingSessionID"].ToString(), dr["TradSesStatus"].ToString());
            }
         }

         return new HnxTradingSession
         {
            TradingSessionMode = TradingSessionMode.NONE,
            TradingSessionStatus = TradingSessionStatus.None
         };
      }
   }
}
