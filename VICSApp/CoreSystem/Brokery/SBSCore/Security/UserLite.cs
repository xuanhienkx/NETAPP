using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Data.SqlClient;
using SBSCore.Common;
using System.Data;

namespace SBSCore.Security
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
      public string ClientIP;
      public string Status;
      public string UserTransCode;
      public int DepartmentId;
      public int GroupId;
         
      public UserLite Clone()
      {
         var cloned = new UserLite
         {
            BranchCode = BranchCode,
            AgencyName = AgencyName,
            ClientIP = ClientIP,
            DepartmentId = DepartmentId,
            FullName = FullName,
            GroupId = GroupId,
            Status = Status,
            TradeCode = TradeCode,
            UserId = UserId,
            UserName = UserName,
            UserTransCode = UserTransCode
         };
         return cloned;
      }

      public bool IsAgencyUser
      {
         get
         {
            return Util.BranchTradeCode.Values.All(x=> x != TradeCode);
         }
      }

      public static UserLite GetUser(string userName, string ip)
      {
         UserLite result = null;
         using (SqlDataReader r = DBUtil.ExecuteDataReader(SqlHelper.BuildGetSql(userName)))
         {
            if (r.Read())
            {
               result = Data2Object(r);
               result.ClientIP = ip;
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

      public static UserLite InsertOrUpdate(UserLite uInfo, UserLite user)
      {
         if (user.UserId == 0)
            user.UserId = (int)DBUtil.ExecuteScalar(SqlHelper.BuildInsert(uInfo, user));
         else
            DBUtil.ExecuteNonQuery(SqlHelper.BuildUpdate(uInfo, user));

         return user;
      }

      public static void Delete(int userId)
      {
         string sql = string.Format("DELETE FROM dbo.Users WHERE UserId = {0}", userId);
         DBUtil.ExecuteNonQuery(sql);
      }

      public static void ChangePassword(int userId, string newPassword)
      {
         using (SqlCommand command = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_CHANGEPASSWORD))
         {
            command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = newPassword;
            command.ExecuteNonQuery();
         }
      }

      private sealed class SqlHelper
      {
         internal static string BuildGetSql(string username)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("select [password], u.[branchcode], [fullname], u.[tradecode], t.unitname, u.[username], u.groupid, u.status, u.DepartmentId, u.userId, u.UserTransCode ");
            sql.Append("from [users] u join unittradecode t on u.tradecode = t.tradecode ");
            sql.AppendFormat("where [username] = '{0}'", LiteralUtil.GetLiteral(username));
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
            sql.Append("select [password], u.[branchcode], [fullname], u.[tradecode], t.unitname, u.[username], u.groupid, u.status, u.DepartmentId, u.userid, u.UserTransCode  ");
            sql.Append("from [users] u join unittradecode t on u.tradecode = t.tradecode ");
            sql.AppendFormat("where t.tradecode = '{0}' and u.branchcode = '{1}' ", uInfo.TradeCode, uInfo.BranchCode);

            if (!string.IsNullOrEmpty(username))
               sql.AppendFormat("and [username] like '%{0}%'", LiteralUtil.GetLiteral(username));

            if (groupId > 0)
               sql.AppendFormat("and [groupid] = {0}", groupId);

            return sql.ToString();
         }

         internal static string BuildInsert(UserLite uInfo, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO dbo.Users(UserName,Password,FullName,GroupId,UserTransCode,DepartmentId,Status,BranchCode,TradeCode,Notes) ");
            sql.Append(" OUTPUT INSERTED.UserId VALUES ( ");
            sql.AppendFormat("'{0}'", LiteralUtil.GetLiteral(user.UserName));
            sql.AppendFormat(",'{0}'", LiteralUtil.GetLiteral(user.Password));
            sql.AppendFormat(",N'{0}'", LiteralUtil.GetLiteral(user.FullName));
            sql.AppendFormat(",{0}", user.GroupId);
            sql.AppendFormat(",'{0}'", LiteralUtil.GetLiteral(user.UserTransCode));
            sql.AppendFormat(",{0}", user.DepartmentId);
            sql.AppendFormat(",'{0}'", LiteralUtil.GetLiteral(user.Status));
            sql.AppendFormat(",'{0}'", LiteralUtil.GetLiteral(user.BranchCode));
            sql.AppendFormat(",'{0}'", LiteralUtil.GetLiteral(user.TradeCode));
            sql.Append(",NULL)");
            return sql.ToString();
         }

         internal static string BuildUpdate(UserLite uInfo, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE dbo.Users SET ");
            sql.AppendFormat("UserName = '{0}' ", LiteralUtil.GetLiteral(user.UserName));
            //sql.AppendFormat(",Password = '{0}' ", LiteralUtil.GetLiteral(user.Password));
            sql.AppendFormat(",FullName = N'{0}' ", LiteralUtil.GetLiteral(user.FullName));
            sql.AppendFormat(",GroupId = {0} ", user.GroupId);
            //sql.AppendFormat(",UserTransCode = '{0}' ", LiteralUtil.GetLiteral(user.UserTransCode));
            sql.AppendFormat(",DepartmentId = {0}", user.DepartmentId);
            sql.AppendFormat(",Status = '{0}' ", LiteralUtil.GetLiteral(user.Status));
            sql.AppendFormat(",BranchCode = '{0}' ", LiteralUtil.GetLiteral(user.BranchCode));
            sql.AppendFormat(",TradeCode = '{0}' ", LiteralUtil.GetLiteral(user.TradeCode));
            sql.AppendFormat("WHERE UserId = {0} ", user.UserId);
            return sql.ToString();
         }
      }
   }
}
