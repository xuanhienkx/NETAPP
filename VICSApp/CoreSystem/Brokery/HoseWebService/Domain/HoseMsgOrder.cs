using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using HoseWebService.Common;

namespace HoseWebService.Domain
{
   public sealed class HoseMsgOrder
   {
      public decimal ORDER_NUMBER;
      public string STATUS;

      public HoseMsgOrder() { }

      public static List<HoseMsgOrder> GetListForCancel(string customerId, string stockCode, string orderside)
      {
          try
          {
              List<HoseMsgOrder> result = new List<HoseMsgOrder>();
              using (SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_HOSEGATEWAY_ORDERLISTFORCANCEL))
              {
                  cmd.Parameters.AddWithValue("@customerid", customerId);
                  cmd.Parameters.AddWithValue("@stockcode", stockCode);
                  //cmd.Parameters.AddWithValue("@orderside", orderside);
                  using (SqlDataReader reader = cmd.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          HoseMsgOrder itm = new HoseMsgOrder();
                          itm.ORDER_NUMBER = (decimal)reader["ORDER_NUMBER"];
                          if (!string.IsNullOrEmpty(orderside) && (orderside == (string)reader["SIDE"]))
                              result.Add(itm);
                          else
                              result.Add(itm);
                      }
                      reader.Close();
                  }
              }
              return result;
          }catch (SqlException ex){
               throw new OperationCanceledException(ex.Message);
          }
      }

      internal static List<HoseMsgOrder> GetDayCancelList()
      {
         List<HoseMsgOrder> result = new List<HoseMsgOrder>();
         string sql = "SELECT ORDER_NUMBER, MESSAGE_STATUS FROM dbo.HOGW_1C";
         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql))
         {
            while (reader.Read())
            {
               HoseMsgOrder itm = new HoseMsgOrder();
               itm.ORDER_NUMBER = (decimal)reader["ORDER_NUMBER"];
               itm.STATUS = reader["MESSAGE_STATUS"].ToString();
               result.Add(itm);
            }

            reader.Close();
         }
         return result;
      }
   }
}
