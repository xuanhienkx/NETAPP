using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SBSCore.Common;

namespace SBSCore.Domain.Inquiry
{
   public sealed class StockInquiry
   {
      // Properties
      public decimal Amount;
      public long CKBan;
      public long CKCC;
      public long CKGD;
      public long CKHC;
      public long CKLe;
      public decimal CurrentPrice;
      public string StockCode;
      public string StockNameViet;
      public string StockType;
      public long SumQuantity;

      public StockInquiry() { }

      public static List<StockInquiry> GetStockInquiry(string customerid, string branchcode, DateTime tradingDate)
      {
         SqlParameter p1 = new SqlParameter("@AccountId", SqlDbType.VarChar);
         p1.Value = customerid;
         SqlParameter p2 = new SqlParameter("@BranchCode", SqlDbType.VarChar);
         p2.Value = branchcode;
         SqlParameter p3 = new SqlParameter("@TradingDate", SqlDbType.SmallDateTime);
         p3.Value = tradingDate;

         List<StockInquiry> result = new List<StockInquiry>();
         using (SqlDataReader dataReader = DBUtil.SBExecuteDataReader(ProviderConstants.SP_SBS_CUSTOMERSTOCKENQUIRY, p1, p2, p3))
         {
            while (dataReader.Read())
            {
               StockInquiry item = new StockInquiry();
               item.Amount = Convert.ToDecimal(dataReader["Amount"]);
               item.CKBan = Convert.ToInt64(dataReader["CKBan"]);
               item.CKCC = Convert.ToInt64(dataReader["CKCC"]);
               item.CKGD = Convert.ToInt64(dataReader["CKGD"]);
               item.CKHC = Convert.ToInt64(dataReader["CKHC"]);
               item.CKLe = Convert.ToInt64(dataReader["CKLe"]);
               item.CurrentPrice = Convert.ToDecimal(dataReader["CurrentPrice"]);
               item.StockCode = Convert.ToString(dataReader["MaCK"]);
               item.StockType = Convert.ToString(dataReader["StockTypeOriginal"]);
               item.SumQuantity = Convert.ToInt64(dataReader["Tong"]);
            }
         }
         return result;
      }
   }
}
