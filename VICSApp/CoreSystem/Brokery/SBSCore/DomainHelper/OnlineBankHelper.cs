using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDomain;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
   public static class OnlineBankHelper
   {
      
      public static List<OnlineBank> GetList(string branchCode)
      {
         List<OnlineBank> list = new List<OnlineBank>();

         SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_GETONLINEBANK);
         command.Parameters.AddWithValue("@BranchCode", branchCode);
         OnlineBank item = null;
         using (SqlDataReader reader = command.ExecuteReader())
         {
            while (reader.Read())
            {
               item = new OnlineBank();
               item.BankCode = reader["BankCode"].ToString();
               item.Status = (bool)reader["Status"];
               list.Add(item);
            }
         }
         return list;
      }
   }
}
