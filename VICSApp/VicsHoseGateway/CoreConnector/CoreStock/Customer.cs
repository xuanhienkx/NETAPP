using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CoreStock
{
   /// <summary>
   /// CLASS nay connect voi CORE
   /// </summary>
   public class CustomerBalance
   {
      public string CustomerID { get; set; }
      public string CustomerNameViet { get; set; }
      public double Balance { get; set; }
      public double AvailBalance { get; set; }
      public double BlockBalance { get; set; }
      public static CustomerBalance[] getAllCustomerBalances()
      {
         string sql = "select A.CustomerID, A.CustomerNameViet, " +
                         "B.Balance, B.AvailBalance, B.BlockBalance " +
                     "from Customers A inner join CustomerBalance B on A.CustomerID = b.CustomerID " +
                     "where A.AccountStatus = 'O' order by A.CustomerID";

         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(CommandType.Text, sql);
         List<CustomerBalance> lstBl = new List<CustomerBalance>();
         while (rd.Read())
         {
            CustomerBalance bl = new CustomerBalance();
            bl.CustomerID = rd["CustomerID"] == DBNull.Value ? "" : rd["CustomerID"].ToString();
            bl.CustomerNameViet = rd["CustomerNameViet"] == DBNull.Value ? "" : rd["CustomerNameViet"].ToString();
            bl.CustomerNameViet = bl.CustomerID + " - " + bl.CustomerNameViet;
            bl.AvailBalance = rd["Balance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["Balance"]);
            bl.AvailBalance = rd["AvailBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["AvailBalance"]);
            bl.AvailBalance = rd["BlockBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BlockBalance"]);
            lstBl.Add(bl);
         }
         return lstBl.ToArray();
      }
   }
   public class Customer
   {
      public string CustomerID { get; set; }
      public string CustomerNameViet { get; set; }
      public double Balance { get; set; }
      public double AvailBalance { get; set; }
      public double BlockBalance { get; set; }
      public string BranchCode { get; set; }
      public string AddressViet { get; set; }
      public string Tel { get; set; }
      public string MobilePhone { get; set; }
      public string Email { get; set; }
      public string DOB { get; set; }
      public int BrokerID { get; set; }
      public static Customer[] getAllCustomers()
      {
         string sql = "select A.BranchCode, A.CustomerID, A.BrokerID, A.CustomerNameViet, A.DOB, A.AddressViet, " +
                         "A.Tel, A.Mobile, A.Email, B.Balance, B.AvailBalance, B.BlockBalance " +
                     "from Customers A inner join CustomerBalance B on A.CustomerID = b.CustomerID " +
                     "where A.AccountStatus = 'O' order by A.CustomerID";
         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(CommandType.Text, sql);
         List<Customer> lstCus = new List<Customer>();
         while (rd.Read())
         {
            Customer cus = new Customer();
            cus.CustomerID = rd["CustomerID"] == DBNull.Value ? "" : rd["CustomerID"].ToString();
            cus.CustomerNameViet = rd["CustomerNameViet"] == DBNull.Value ? "" : rd["CustomerNameViet"].ToString();
            cus.CustomerNameViet = cus.CustomerID + " - " + cus.CustomerNameViet;
            cus.AddressViet = rd["AddressViet"] == DBNull.Value ? "" : rd["AddressViet"].ToString();
            cus.AvailBalance = rd["Balance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["Balance"]);
            cus.AvailBalance = rd["AvailBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["AvailBalance"]);
            cus.AvailBalance = rd["BlockBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BlockBalance"]);
            cus.Tel = rd["Tel"] == DBNull.Value ? "" : rd["Tel"].ToString();
            cus.Email = rd["Email"] == DBNull.Value ? "" : rd["Email"].ToString();
            cus.MobilePhone = rd["Mobile"] == DBNull.Value ? "" : rd["Mobile"].ToString();
            cus.DOB = rd["DOB"] == DBNull.Value ? "" : rd["DOB"].ToString();
            cus.BranchCode = rd["BranchCode"] == DBNull.Value ? "" : rd["BranchCode"].ToString();
            cus.BrokerID = rd["BrokerID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BrokerID"]);
            lstCus.Add(cus);
         }
         return lstCus.ToArray();
      }
   }
   public class CustomerCompact
   {
      public string CustomerID { get; set; }
      public string CustomerNameViet { get; set; }
      public double Balance { get; set; }
      public double AvailBalance { get; set; }
      public double BlockBalance { get; set; }
      public string BranchCode { get; set; }
      public int BrokerID { get; set; }
      public static CustomerCompact[] getAllCustomersCompact()
      {
         string sql = "select A.BranchCode, A.CustomerID, A.BrokerID, A.CustomerNameViet, " +
                         "B.Balance, B.AvailBalance, B.BlockBalance " +
                     "from Customers A inner join CustomerBalance B on A.CustomerID = b.CustomerID " +
                     "where A.AccountStatus = 'O' order by A.CustomerID";
         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(CommandType.Text, sql);
         List<CustomerCompact> lstCus = new List<CustomerCompact>();
         while (rd.Read())
         {
            CustomerCompact cus = new CustomerCompact();
            cus.CustomerID = rd["CustomerID"] == DBNull.Value ? "" : rd["CustomerID"].ToString();
            cus.CustomerNameViet = rd["CustomerNameViet"] == DBNull.Value ? "" : rd["CustomerNameViet"].ToString();
            cus.CustomerNameViet = cus.CustomerID + " - " + cus.CustomerNameViet;
            cus.AvailBalance = rd["Balance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["Balance"]);
            cus.AvailBalance = rd["AvailBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["AvailBalance"]);
            cus.AvailBalance = rd["BlockBalance"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BlockBalance"]);
            cus.BranchCode = rd["BranchCode"] == DBNull.Value ? "" : rd["BranchCode"].ToString();
            cus.BrokerID = rd["BrokerID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BrokerID"]);
            lstCus.Add(cus);
         }
         return lstCus.ToArray();
      }
   }
   public class Securities
   {
      public string StockCode { get; set; }
      public int Quatity { get; set; }
   }
   public class CustomerSecurities
   {
      public string CustomerID { get; set; }
      public string CustomerNameViet { get; set; }
      public Securities[] OwnedSecurities;
      public static CustomerSecurities getAllCustomerSecurities(string customerID)
      {
         CustomerSecurities cusSec = new CustomerSecurities();
         cusSec.CustomerID = customerID;
         string sql = "select A.CustomerID, A.CustomerNameViet, " +
                         "B.StockCode, B.Quantity " +
                     "from Customers A inner join Securities B on A.CustomerID = b.AccountID " +
                     "where A.CustomerID = @cus and b.SectionGL <> '0122' order by B.StockCode";
         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         DbCommand cmd = DbCore.GetSqlStringCommand(sql);
         DbCore.AddInParameter(cmd, "@cus", DbType.String, customerID);
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(cmd);
         List<Securities> lstSec = new List<Securities>();
         while (rd.Read())
         {
            cusSec.CustomerNameViet = rd["CustomerNameViet"] == DBNull.Value ? "" : rd["CustomerNameViet"].ToString();
            Securities sec = new Securities();
            sec.StockCode = rd["StockCode"] == DBNull.Value ? "" : rd["StockCode"].ToString();
            sec.Quatity = rd["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Quantity"]);
            lstSec.Add(sec);
         }
         rd.Close();
         cusSec.OwnedSecurities = lstSec.ToArray();
         return cusSec;
      }
      public static Securities[] getSecurities(string customerID)
      {
         string sql = "select StockCode, Quantity from Securities " +
                     "where AccountID = @cus and SectionGL <> '0122' order by StockCode";
         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         DbCommand cmd = DbCore.GetSqlStringCommand(sql);
         DbCore.AddInParameter(cmd, "@cus", DbType.String, customerID);
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(cmd);
         List<Securities> lstSec = new List<Securities>();
         while (rd.Read())
         {
            Securities sec = new Securities();
            sec.StockCode = rd["StockCode"] == DBNull.Value ? "" : rd["StockCode"].ToString();
            sec.Quatity = rd["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Quantity"]);
            lstSec.Add(sec);
         }
         rd.Close();
         return lstSec.ToArray();
      }
      public static Securities getSecurity(string customerID, string stockCode)
      {
         string sql = "select StockCode, Quantity from Securities " +
                     "where AccountID = @cus and StockCode = @stock and SectionGL <> '0122'"; //0121 la chung khoan GD, 0122 la chung khoan Tam ngung
         Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
         DbCommand cmd = DbCore.GetSqlStringCommand(sql);
         DbCore.AddInParameter(cmd, "@cus", DbType.String, customerID);
         DbCore.AddInParameter(cmd, "@stock", DbType.String, stockCode);
         SqlDataReader rd = (SqlDataReader)DbCore.ExecuteReader(cmd);
         Securities sec = null;
         while (rd.Read())
         {
            sec = new Securities();
            sec.StockCode = rd["StockCode"] == DBNull.Value ? "" : rd["StockCode"].ToString();
            sec.Quatity = rd["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Quantity"]);
         }
         rd.Close();
         return sec;
      }
   }
}
