using System; 
using System.Data.SqlClient;
using System.Data; 
using VRMDomain.Domain;

namespace VRMDomain
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
      public static DataTable GetInterestRateOnDb(string branchCode)
      {
          string sql = string.Format("select BranchCode,BeginDate,rate from vrm_InterestRate where BranchCode='{0}' order by BeginDate", branchCode);
          return DBUtil.ExecuteDataSet(sql).Tables[0];
      }
   }
}
