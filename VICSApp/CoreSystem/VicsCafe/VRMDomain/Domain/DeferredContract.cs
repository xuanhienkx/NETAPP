using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
   public sealed class DeferredContract
   {
      private int id;
      private string customerid;
      private byte producttype;
      private DateTime createddate = DateTime.Now;
      private DateTime contractdate;
      private DateTime expireddate;
      private DateTime approveddate;
      private string approvedby;
      private string createdby;
      private bool isactive;

      public string CustomerName;
      public string BranchCode;
      public string TradingCode;

      public DeferredContract() { }

      public int Id
      {
         get { return id; }
         set { this.id = value; }
      }
      public string CustomerId
      {
         get { return customerid; }
         set { this.customerid = value; }
      }
      public byte ProductType
      {
         get { return producttype; }
         set { this.producttype = value; }
      }
      public DateTime CreatedDate
      {
         get { return createddate; }
         set { this.createddate = value; }
      }
      public DateTime ContractDate
      {
         get { return contractdate; }
         set { this.contractdate = value; }
      }
      public DateTime ExpiredDate
      {
         get { return expireddate; }
         set { this.expireddate = value; }
      }
      public DateTime ApprovedDate
      {
         get { return approveddate; }
         set { this.approveddate = value; }
      }
      public string ApprovedBy
      {
         get { return approvedby; }
         set { this.approvedby = value; }
      }
      public string CreatedBy
      {
         get { return createdby; }
         set { this.createdby = value; }
      }
      public bool IsActive
      {
         get { return isactive; }
         set { this.isactive = value; }
      }

      private static DeferredContract DB2Object(IDataReader reader)
      {
         DeferredContract result = new DeferredContract();
         result.Id = (int)reader["Id"];
         result.customerid = reader["CustomerId"].ToString();
         result.CustomerName = reader["CustomerNameViet"].ToString();
         result.ProductType = (byte)reader["ProductType"];
         result.CreatedDate = (DateTime)reader["CreatedDate"];
         result.ContractDate = (DateTime)reader["ContractDate"];
         result.ExpiredDate = (DateTime)reader["ExpiredDate"];
         if (reader["ApprovedDate"] != DBNull.Value)
            result.ApprovedDate = (DateTime)reader["ApprovedDate"];
         if (reader["ApprovedBy"] != DBNull.Value)
            result.ApprovedBy = reader["ApprovedBy"].ToString();
         result.IsActive = (bool)reader["IsActive"];

         return result;
      }

      public static List<DeferredContract> FindContracts(string customerId, DateTime fromDate, DateTime toDate, bool isActive, UserLite user)
      {
         List<DeferredContract> result = new List<DeferredContract>();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildFindContracts(customerId, fromDate, toDate, isActive, user));
         while (reader.Read())
            result.Add(DB2Object(reader));
         reader.Close();
         return result;
      }

      public static DeferredContract GetContract(int contractId)
      {
         DeferredContract result = new DeferredContract();
         SqlDataReader reader = DBUtil.ExecuteDataReader("");
         if (reader.Read())
            result = DB2Object(reader);
         reader.Close();
         return result;
      }

      internal static DeferredContract GetCurrentContract(string customerId, UserLite user)
      {
         DeferredContract result = new DeferredContract();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildFindContracts(customerId, DateTime.MinValue, DateTime.MaxValue, true, user));
         if (reader.Read())
            result = DB2Object(reader);
         reader.Close();
         return result;
      }

      public static DeferredContract Save(DeferredContract contract)
      {
         string sql;
         if (contract.id == 0)
            sql = SqlHelper.BuildInserSql(contract);
         else
            sql = SqlHelper.BuildUpdateSql(contract);
         contract.id = (int)DBUtil.ExecuteScalar(sql);
         return contract;
      }

      private sealed class SqlHelper
      {

         internal static string BuildFindContracts(string customerId, DateTime fromDate, DateTime toDate, bool isActive, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT v.Id, v.CustomerId, c.CustomerNameViet, v.ProductType, v.CreatedDate, v.ContractDate, v.ExpiredDate, v.ApprovedDate, v.ApprovedBy, v.IsActive, v.BranchCode, v.TradingCode ");
            sql.Append("FROM vrm_Contract v JOIN dbo.Customers c ON v.CustomerId = c.CustomerId ");

            if (user.IsAgencyMember)
            {
               sql.Append("join dbo.agencycustomer a on c.customerid = a.customerid ");
               sql.AppendFormat("where a.AgencyTradingCode = '{0}' ", user.TradeCode);
            }
            else
               sql.AppendFormat("where v.TradingCode = '{0}' and v.BranchCode = '{1}' ", user.TradeCode, user.BranchCode);
            if (fromDate != DateTime.MinValue || toDate != DateTime.MaxValue)
               sql.AppendFormat("and v.CreatedDate BETWEEN {0} AND {1} AND v.IsActive = {2}",
                  LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate), LiteralUtil.GetLiteral(isActive));
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and v.customerid = '{0}' ", LiteralUtil.GetLiteral(customerId));
            if (!user.IsGeneralAdmin)
               sql.AppendFormat("AND c.UserTakeCared = {0} ", user.UserId);
            return sql.ToString();
         }

         internal static string BuildInserSql(DeferredContract contract)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO dbo.vrm_Contract( CustomerId ,ProductType ,CreatedDate ,ContractDate ,ExpiredDate ,ApprovedDate ,ApprovedBy ,CreatedBy ,IsActive ,BranchCode ,TradingCode) ");
            sql.Append("OUTPUT INSERTED.Id VALUES  ( ");
            sql.AppendFormat("'{0}' ,", contract.CustomerId);
            sql.AppendFormat("{0} ,", contract.ProductType);
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.CreatedDate));
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.ContractDate));
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.ExpiredDate));
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.ApprovedDate));
            sql.AppendFormat("'{0}' ,", contract.ApprovedBy);
            sql.AppendFormat("'{0}' ,", contract.CreatedBy);
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.IsActive));
            sql.AppendFormat("'{0}' ,", contract.BranchCode);
            sql.AppendFormat("'{0}')", contract.TradingCode);

            return sql.ToString();
         }

         internal static string BuildUpdateSql(DeferredContract contract)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE dbo.vrm_Contract SET ");
            sql.AppendFormat("CustomerId = '{0}' ,", contract.CustomerId);
            sql.AppendFormat("ProductType = {0} ,", contract.ProductType);
            sql.AppendFormat("CreatedDate = {0} ,", LiteralUtil.GetLiteral(contract.CreatedDate));
            sql.AppendFormat("ContractDate = {0} ,", LiteralUtil.GetLiteral(contract.ContractDate));
            sql.AppendFormat("ExpiredDate = {0} ,", LiteralUtil.GetLiteral(contract.ExpiredDate));
            sql.AppendFormat("ApprovedDate = {0} ,", LiteralUtil.GetLiteral(contract.ApprovedDate));
            sql.AppendFormat("ApprovedBy = '{0}' ,", contract.ApprovedBy);
            sql.AppendFormat("CreatedBy = '{0}' ,", contract.CreatedBy);
            sql.AppendFormat("IsActive = {0} ,", LiteralUtil.GetLiteral(contract.IsActive));
            sql.AppendFormat("BranchCode = '{0}' ,", contract.BranchCode);
            sql.AppendFormat("TradingCode = '{0}' ", contract.TradingCode);
            sql.AppendFormat("OUTPUT INSERTED.Id WHERE Id = {0} ", contract.Id);

            return sql.ToString();
         }
      }
   }
}
