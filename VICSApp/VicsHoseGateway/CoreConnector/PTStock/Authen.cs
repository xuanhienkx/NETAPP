using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PTStock
{
   public class LoginResult
   {
      public string UserName;
      public Branch Branch;
      public int Result;
      public int RoleID;
      public string RoleName;
   }
   //Added by DUONGPT
   public class Branch
   {
      public int BranchID;
      public string BrachCode;
      public string TradeCode;
   }
   public static class Authen
   {
      static public int getTraderIDByUser(Database db, object user)
      {
         string sql = "select TRADER_ID from PT_USER where user_name = @user";
         DbCommand cmd = db.GetSqlStringCommand(sql);
         db.AddInParameter(cmd, "@user", DbType.String, user);
         object o = db.ExecuteScalar(cmd);
         if (o != null)
            return (int)o;
         else return -1;
      }
      static public int getTraderIDByUser(object user)
      {
         string sql = "select TRADER_ID from PT_USER where user_name = @user";
         Database db = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = db.GetSqlStringCommand(sql);
         db.AddInParameter(cmd, "@user", DbType.String, user);
         object o = db.ExecuteScalar(cmd);
         if (o != null)
            return (int)o;
         else return -1;
      }
      //Added by DUONGPT
      static private Branch getBranch(string user)
      {
         Branch b = new Branch();
         string sql = "select b.branch_id, b.branch_code, b.trade_code from PT_USER a inner join PT_BRANCH b on a.branch_id = b.branch_id where a.user_name = @user";
         Database db = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = db.GetSqlStringCommand(sql);
         db.AddInParameter(cmd, "@user", DbType.String, user);
         SqlDataReader rd = (SqlDataReader)db.ExecuteReader(cmd);
         if (rd == null) return null;
         if (rd.Read())
         {
            b.BranchID = Convert.ToInt32(rd["branch_id"]);
            b.BrachCode = Convert.ToString(rd["branch_code"]);
            b.TradeCode = Convert.ToString(rd["trade_code"]);
         }
         return b;
      }
      static private LoginResult getRoles(object user)
      {
         LoginResult r = new LoginResult();
         string sql = "select b.role_id, b.role_name from PT_USER a inner join PT_ROLES b on a.role_id = b.role_id where a.user_name = @user";
         Database db = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = db.GetSqlStringCommand(sql);
         db.AddInParameter(cmd, "@user", DbType.String, user);
         SqlDataReader rd = (SqlDataReader)db.ExecuteReader(cmd);
         if (rd == null) return null;
         while (rd.Read())
         {
            r.RoleID = Convert.ToInt32(rd["role_id"]);
            r.RoleName = Convert.ToString(rd["role_name"]);
         }
         return r;
      }
      static public LoginResult login(string user, string pass)
      {
         LoginResult r = null;
         Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         int ret = (int)DbPTCore.ExecuteScalar("Login", user, pass);
         if (ret > 0)
         {
            r = getRoles(user);
            if (r != null)
               r.Result = ret;
            r.Branch = getBranch(user);
            r.UserName = user;
         }
         else
         {
            r = new LoginResult();
            r.Result = ret;
         }
         return r;
      }
   }
}
