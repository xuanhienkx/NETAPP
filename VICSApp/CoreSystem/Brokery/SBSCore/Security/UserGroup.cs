using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBSCore.Common;
using System.Data.SqlClient;
using System.Data;

namespace SBSCore.Security
{
   public sealed class UserGroup
   {
      public int GroupId;
      public string GroupName;
      public UserGroup() { }


      public static List<UserGroup> GetList(string branchCode, string tradeCode)
      {
         List<UserGroup> result = new List<UserGroup>();
         StringBuilder sqlBuilder = new StringBuilder();
         sqlBuilder.AppendFormat("SELECT GroupId, GroupName FROM dbo.UserGroups WHERE BranchCode = '{0}' ",LiteralUtil.GetLiteral(branchCode));
         if (tradeCode != "VICS" && tradeCode != "VICSHCM" && tradeCode != "VICSHUE")
             sqlBuilder.AppendFormat(" AND TradeCode = '{0}'", LiteralUtil.GetLiteral(tradeCode));
         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sqlBuilder.ToString()))
         {
            while (reader.Read())
            {
               UserGroup g = new UserGroup();
               g.GroupId = (int)reader["GroupId"];
               g.GroupName = reader["GroupName"].ToString();
               result.Add(g);
            }
         }
         return result;
      }

      public static List<string> GetGroupPermission(int groupId)
      {
         List<string> result = new List<string>();
         string sql = string.Format("SELECT Permission FROM dbo.AgencyPermission WHERE Permission LIKE 'VICS_%' AND GroupId = {0}", groupId);

         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql))
         {
            while (reader.Read())
            {
               result.Add(reader["Permission"].ToString());
            }
         }
         return result;
      }

      public static void SetGroupPermission(int groupId, List<string> rights)
      {
         StringBuilder sql = new StringBuilder();
         sql.AppendFormat("DELETE FROM dbo.AgencyPermission WHERE Permission LIKE 'VICS_%' AND GroupId = {0} \n", groupId);
         foreach (string r in rights)
            sql.AppendFormat("INSERT INTO dbo.AgencyPermission ( GroupId, Permission ) VALUES  ( {0}, '{1}') \n", groupId, r);
         DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static UserGroup InsertOrUpdate(UserLite uInfo, UserGroup group)
      {
         string sql;
         if (group.GroupId == 0)
         {
            sql = string.Format("INSERT INTO dbo.UserGroups( GroupName, BranchCode, TradeCode ) OUTPUT INSERTED.GroupId VALUES (N'{0}', '{1}', '{2}')",
               LiteralUtil.GetLiteral(group.GroupName), uInfo.BranchCode, uInfo.TradeCode);

            group.GroupId = (int)DBUtil.ExecuteScalar(sql);
         }
         else
         {
            sql = string.Format("UPDATE dbo.UserGroups SET GroupName = N'{0}' WHERE GroupId = {1}",
               LiteralUtil.GetLiteral(group.GroupName), group.GroupId);
            DBUtil.ExecuteNonQuery(sql);
         }

         return group;
      }

      public static void Delete(int groupId)
      {
         string sql = string.Format("DELETE FROM dbo.UserGroups WHERE GroupId = {0}", groupId);
         DBUtil.ExecuteNonQuery(sql);
      }
   }
}
