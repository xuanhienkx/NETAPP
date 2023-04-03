using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace HoseWebService.Common
{
   public static class HoseDal
   {
      internal static void CancelOrder(string orderNumber, string canceledBy)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_HOSEGATEWAY_CANCELORDER);
         cmd.Parameters.AddWithValue("@Orderno", decimal.Parse(orderNumber));
         cmd.Parameters.AddWithValue("@DeletedBy", canceledBy);
         cmd.ExecuteNonQuery();
      }
      internal static string GetCurrentSession()
      {
          if (DBUtil.ExecuteScalar("SELECT TOP 1 SYSTEM_CONTROL_CODE FROM HOSE_SC ORDER BY ID DESC") != null)
              return DBUtil.ExecuteScalar("SELECT TOP 1 SYSTEM_CONTROL_CODE FROM HOSE_SC ORDER BY ID DESC").ToString();
          else
              return "";
      }



          internal static string getStockHalted(string StockCode)
          {
              string halt_resume_flag = "";
              string sql = "select y.*, z.TOTAL_ROOM, z.CURRENT_ROOM  from ( " +
                          "select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, " +
                              "security_symbol, security_name, par_value, security_type, board_lot,  " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then halt_su else halt_ss end as halt_resume_flag, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then suspension_su else suspension_ss end as suspension, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then split_su else split_ss end as split, " +
                              "case when last_date_su >= last_date_ss or last_date_ss is null then delist_su else delist_ss end as delist, " +
                              "security_number_old, security_number_new, market_id " +
                          "from ( " +
                              "select a.last_modified last_date_ss, b.last_modified last_date_su, " +
                                  "ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, isnull(b.board_lot,a.board_lot) as board_lot,  " +
                                  "a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, " +
                                  "b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su, " +
                                  "a.HALT_RESUME_FLAG as halt_ss, a.suspension as suspension_ss, a.split as split_ss, a.delist as delist_ss, " +
                                  "b.HALT_RESUME_FLAG as halt_su, b.suspension as suspension_su, b.split as split_su, b.delist as delist_su, " +
                                  "b.security_number_old, b.security_number_new, b.market_id " +
                              "from (select * from (select dense_rank()  " +
                                      "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                      ", * from hose_su) X where RankNum = 1 " +
                              ") b left outer join (select * from (select dense_rank()  " +
                                      "over(partition by security_number order by security_number, last_modified desc) as RankNum " +
                                      ", * from hose_ss) X where RankNum = 1 " +
                              ") a ON a.security_number = b.security_number_new " +
                          ") X " +
                      ") Y left outer join ( select * from (select dense_rank()  " +
                              "over(partition by security_number order by security_number, last_modified desc) as RankNum, * from hose_tr) X " +
                          "where RankNum = 1 " +
                      ") Z on Y.security_number_new = Z.security_number " +
                      "WHERE UPPER(y.security_symbol) = UPPER('" + StockCode + "') " +
                      "order by Y.security_symbol";

              SqlDataReader rd = DBUtil.ExecuteDataReader(sql);
              while (rd.Read())
              {
                  halt_resume_flag = rd["halt_resume_flag"] == DBNull.Value ? "" : rd["halt_resume_flag"].ToString();
              }
              rd.Close();
              return halt_resume_flag;

          }

   }
}
