using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SBSCore.Security;
using System.Data;
using System.Configuration;
using SBSCore.Common;

namespace SBSCore
{
   public static class SBSDal
   {
      public static DateTime GetCurrentTransaction(string branchCode)
      {
         string cmdText = string.Format("select [currenttransdate] from [transdate] where [branchcode]='{0}'", branchCode);
         SqlDataReader r = DBUtil.ExecuteDataReader(cmdText);
         DateTime result = DateTime.Now;
         if (r.Read())
         {
            result = r.GetDateTime(0).Add(DateTime.Now.TimeOfDay);
         }
         r.Close();
         return result;
      }

      public static DateTime GetT3Date(string branchCode, DateTime currentTransDate, int numberOfDay, bool isNextDay)
      {
         using (SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_GETTDATE))
         {
            command.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = branchCode;
            command.Parameters.Add("@TransactionDate", SqlDbType.SmallDateTime).Value = currentTransDate;
            command.Parameters.Add("@GetFutureDate", SqlDbType.Bit).Value = isNextDay;
            command.Parameters.Add("@NumberOfDay", SqlDbType.Int).Value = numberOfDay;

            command.Parameters.Add("@TDate", SqlDbType.DateTime);
            command.Parameters["@TDate"].Direction = ParameterDirection.Output;

            command.ExecuteNonQuery();
            return Convert.ToDateTime(command.Parameters["@TDate"].Value);
         }
      }

      internal static decimal GetFeeValue(string customerId, string stockCode, decimal tradingValue)
      {
         decimal result = 0M;
         using (SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_GETORDERFEE))
         {
            command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = customerId;
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
            command.Parameters.Add("@OrderValue", SqlDbType.Decimal).Value = tradingValue;
            command.Parameters.Add("@FeeRate", SqlDbType.Decimal);
            command.Parameters["@FeeRate"].Direction = ParameterDirection.Output;
            command.Parameters["@FeeRate"].Precision = 0x12;
            command.Parameters["@FeeRate"].Scale = 5;

            command.ExecuteNonQuery();
            if (command.Parameters["@FeeRate"].Value != DBNull.Value)
               result = Convert.ToDecimal(command.Parameters["@FeeRate"].Value) * tradingValue;
         }
         return result;
      }

   }
}
