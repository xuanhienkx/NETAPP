using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CommonDomain;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
   public static class InquiryStockHelper
   {
      
      public static List<InquiryStock> GetStock(string customerId, string branchCode, DateTime tradingDate)
      {
         List<InquiryStock> result = new List<InquiryStock>();
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_CUSTOMERSTOCKENQUIRY);
         cmd.Parameters.Add("@AccountId", SqlDbType.VarChar).Value = customerId;
         cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = branchCode;
         cmd.Parameters.Add("@TradingDate", SqlDbType.DateTime).Value = tradingDate;

         using (SqlDataReader reader = cmd.ExecuteReader())
         {
            while (reader.Read())
            {
               InquiryStock item = new InquiryStock();
               item.BoardType = reader["BoardTypeText"].ToString();
               item.StockCode = reader["MaCK"].ToString();
               item.CKGD = (long)reader["CKGD"];
               item.CKCC = (long)reader["CKCC"];
               item.CKHC = (long)reader["CKHC"];
               item.CKTONG = (long)reader["Tong"];
               item.DayTrading = (long)reader["CKBan"];
               item.RemainVolume = item.CKTONG - item.DayTrading;
               result.Add(item);
            }
            reader.Close();
         }
         return result;
      }
   }
}
