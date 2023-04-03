using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Data.SqlClient;
using VRMDomain.Common;
using System.Data;

namespace VRMDomain.Domain
{
   [Serializable]
   public sealed class UserLite
   {
      public int UserId;
      public string UserName;
      public string Password;
      public string BranchCode;
      public string FullName;
      public string TradeCode;
      public string AgencyName;
      public string ClientIp;
      public string Status;
      public string UserTransCode;
      public int DepartmentId;
      public int GroupId;
      public List<string> Rights;

      public UserLite()
      { }

      internal bool IsAgencyMember
      {
         get
         {
            return TradeCode != "VICS" && TradeCode != "VICSHCM" && TradeCode != "VICSHUE";
         }
      }

      internal bool IsBranchAdmin
      {
         get
         {
            return AdminChecker(GlobalConstants.ADMIN_BRANCH_RIGHT, this);
         }
      }

      internal bool IsLocalAdmin
      {
         get
         {
            return AdminChecker(GlobalConstants.ADMIN_LOCAL_RIGHT, this);
         }
      }

      private static bool AdminChecker(string adminConstantRight, UserLite u)
      {
         if (u.Rights == null || u.Rights.Count == 0)
            return false;
         if (u.Rights.Contains(GlobalConstants.ADMIN_BRANCH_RIGHT))
            return true;
         if (u.Rights.Contains(GlobalConstants.ADMIN_LOCAL_RIGHT) && 
            adminConstantRight.Equals(GlobalConstants.ADMIN_LOCAL_RIGHT, StringComparison.CurrentCultureIgnoreCase))
            return true;
         return false;
      }

      public static UserLite GetUser(string userName,string ip)
      {
         UserLite result = null;
         using (SqlDataReader r = DBUtil.ExecuteDataReader(SqlHelper.BuildGetSql(userName)))
         {
            if (r.Read())
            {
               result = Data2Object(r);
               result.ClientIp = ip;
            }

            r.Close();
            r.Dispose();
         }
         return result;
      }

      public static List<UserLite> Find(string username, UserLite uInfo)
      {
         List<UserLite> result = new List<UserLite>();
         using (SqlDataReader r = DBUtil.ExecuteDataReader(SqlHelper.BuildGetSqlLike(username, uInfo)))
         {
            while (r.Read())
               result.Add(Data2Object(r));

            r.Close();
            r.Dispose();
         }
         return result;
      }

      public static List<UserLite> GetList(int groupId, UserLite uInfo)
      {
         List<UserLite> result = new List<UserLite>();
         using (SqlDataReader r = DBUtil.ExecuteDataReader(SqlHelper.BuildGetSql(groupId, uInfo)))
         {
            while (r.Read())
               result.Add(Data2Object(r));

            r.Close();
            r.Dispose();
         }
         return result;
      }

      private static UserLite Data2Object(SqlDataReader r)
      {
         UserLite user = new UserLite();
         user.UserName = r["username"].ToString();
         user.Password = r["password"].ToString();
         user.BranchCode = r["branchcode"].ToString();
         user.FullName = r["fullname"].ToString();
         user.AgencyName = r["unitname"].ToString();
         user.UserName = r["username"].ToString();
         user.TradeCode = r["tradecode"].ToString();
         user.UserTransCode = r["UserTransCode"].ToString();
         user.Status = r["Status"].ToString();
         user.GroupId = (int)r["groupid"];
         user.DepartmentId = (int)r["DepartmentId"];
         user.UserId = (int)r["UserId"];
         return user;
      }

      public static void ChangePassword(int userId, string newPassword)
      {
         using (SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_CHANGEPASSWORD))
         {
            command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = newPassword;
            command.ExecuteNonQuery();
         }
      }

      public static List<string> GetUserAccess(int userID)
      {
         List<string> result = new List<string>();
         string sql = string.Format("select accessright from vrm_useraccess where userid = {0}", userID);
         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql))
         {
            while (reader.Read())
               result.Add(reader[0].ToString());
            reader.Close();
         }
         return result;
      }
      
      private sealed class SqlHelper
      {
         internal static string BuildGetSql(string username)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("select [password], u.[branchcode], [fullname], u.[tradecode], t.unitname, u.[username], u.groupid, u.status, u.DepartmentId, u.userId, u.UserTransCode ");
            
            sql.Append("from [users] u join unittradecode t on u.tradecode = t.tradecode ");
            sql.AppendFormat("where [username] = '{0}' ", LiteralUtil.GetLiteral(username));
            return sql.ToString();
         }

         internal static string BuildGetSqlLike(string username, UserLite uInfo)
         {
            return BuildGetSql(username, 0, uInfo);
         }

         internal static string BuildGetSql(int groupId, UserLite uInfo)
         {
            return BuildGetSql(string.Empty, groupId, uInfo);
         }

         private static string BuildGetSql(string username, int groupId, UserLite uInfo)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("select [password], u.[branchcode], [fullname], u.[tradecode], t.unitname, u.[username], u.groupid, u.status, u.DepartmentId, u.userid, u.UserTransCode ");
            sql.Append("from [users] u join unittradecode t on u.tradecode = t.tradecode ");
            sql.AppendFormat("where u.status != 'C' and u.branchcode = '{0}' ", uInfo.BranchCode);

            if (!uInfo.IsBranchAdmin)
               sql.AppendFormat("and t.tradecode = '{0}' ", uInfo.TradeCode);

            if (!string.IsNullOrEmpty(username))
               sql.AppendFormat("and [username] like '%{0}%'", LiteralUtil.GetLiteral(username));

            if (groupId > 0)
               sql.AppendFormat("and [groupid] = {0}", groupId);

            return sql.ToString();
         }
      }

      public static void UpdateUserAccess(List<string> accessList, int userId)
      {
         StringBuilder sql = new StringBuilder();

         sql.AppendFormat("if not exists (select * from vrm_useraccess where userid = {0} and accessright = 'AdminBranch') begin \n", userId);
         sql.AppendFormat("delete from vrm_useraccess where userid = {0} and accessright != 'AdminLocal' \n", userId);
         foreach (string s in accessList)
            sql.AppendFormat("insert into vrm_useraccess(userid, accessright) values ({0}, '{1}') \n", userId, s);
         sql.Append(" end");

         DBUtil.ExecuteNonQuery(sql.ToString());
      }
   }
}
