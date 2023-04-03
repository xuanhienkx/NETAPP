using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace PTStock
{
   /// <summary>
   /// class nay connect voi Put Through database
   /// </summary>
   public class Firm
   {
      private int _firmID;
      public int FirmID
      {
         set { _firmID = value; }
         get { return _firmID; }
      }
      private string _firmCode;
      public string FirmCode
      {
         set { _firmCode = value; }
         get { return _firmCode; }
      }
      private string _firmName;
      public string FirmName
      {
         set { _firmName = value; }
         get { return _firmName; }
      }
      private int _numberOfTraders;
      public int NumberOfTrader
      {
         set { _numberOfTraders = value; }
         get { return _numberOfTraders; }
      }
      private string _contact;
      public string Contact
      {
         set { _contact = value; }
         get { return _contact; }
      }
      private int _coreID;
      public int CoreID
      {
         set { _coreID = value; }
         get { return _coreID; }
      }

      static private PTDBDataContext dataContext = new PTDBDataContext(ConfigurationManager.ConnectionStrings["ConnStrPTCore"].ConnectionString);

      public static List<PT_FIRM> GetAllFirms()
      {
         return dataContext.PT_FIRMs.OrderBy(x => x.FIRM_ID).ToList();
      }

      public static List<PT_FIRM> GetFirmsAreNotCurrentFirm(int currentFirm)
      {
         return dataContext.PT_FIRMs.Where(x => x.FIRM_ID != currentFirm).OrderBy(x => x.FIRM_ID).ToList();
      }

      public static List<PT_TRADER> GetTraders(int firmId)
      {
         return dataContext.PT_TRADERs.Where(x => x.FIRM_ID == firmId).OrderBy(x => x.TRADER_ID).ToList();
      }

      public static int GetTraderIdByUser(string username)
      {
         return dataContext.PT_USERs.Where(x => x.USER_NAME == username).SingleOrDefault().TRADER_ID.Value;
      }

      //---------------
      public static DataSet getAllFirms()
      {
         string sql = "SELECT [FIRM_ID],[FIRM_NAME],[NUMBER_OF_TRADERS],[CONTACT],[CORE_ID],[FIRM_CODE] FROM [PT_FIRMS] order by FIRM_ID";
         Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         return DbPTCore.ExecuteDataSet(CommandType.Text, sql);
      }
      public static DataSet getFirmsAreNotCurrentFirm(int currentFirm)
      {
         string sql = "SELECT [FIRM_ID],[FIRM_NAME],[NUMBER_OF_TRADERS],[CONTACT],[CORE_ID],[FIRM_CODE] FROM [PT_FIRMS] where FIRM_ID <> @currentFirm order by FIRM_ID";
         Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
         DbPTCore.AddInParameter(cmd, "@currentFirm", DbType.Int32, currentFirm);
         return DbPTCore.ExecuteDataSet(cmd);
      }
      public static DataSet getTraders(int firmID)
      {
         string sql = "SELECT [FIRM_ID],[TRADER_ID],[TRADER_NAME],[NOTE] FROM [PT_TRADERS] where FIRM_ID = @FirmID order by TRADER_ID";
         Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
         DbPTCore.AddInParameter(cmd, "@FirmID", DbType.Int32, firmID);
         return DbPTCore.ExecuteDataSet(cmd);
      }
      public static int getTraderIdByUser(string username)
      {
         string sql = "SELECT TRADER_ID FROM PT_USER where USER_NAME = @username";
         Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
         DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
         DbPTCore.AddInParameter(cmd, "@username", DbType.String, username);
         object ret = DbPTCore.ExecuteScalar(cmd);
         if (ret != null && ret != System.DBNull.Value) return (int)ret;
         else return -1;
      }
   }
}
