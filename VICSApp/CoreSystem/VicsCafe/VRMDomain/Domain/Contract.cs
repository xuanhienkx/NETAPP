using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
   public enum ContractStatus : byte
   {
      None = 0,
      ChoDuyet = 1, // hợp đồng bắt đầu khởi tạo
      DaDuyet = 2, // hợp đồng được duyệt bởi cán bộ QLRR 
      DaGiaiNgan = 3, // hợp đồng được giải ngân bởi cán bộ kế toán
      KetThuc = 4  // hợp đồng được thanh lý bởi hết hạn hợp đồng
   }

   public enum ContractType : byte
   {
      CoThoiHan = 0,
      KhongThoiHan = 1,
      Both = 2
   }

   public sealed class Contract
   {
      public int Id;
      public string ContractID;
      public string CustomerID;
      public string CustomerName;
      public ContractType ContractType;
      public ContractStatus ContractStatus;
      public string BranchCode;
      public string TradeCode;
      public DateTime ContractDueDate;
      public DateTime ExpiredDate;

      public DateTime CreatedDate;
      public string CreatedBy;
      public string ApprovedBy;
      public DateTime ApprovedDate = DateTime.MinValue;

      // hop dong co ky han
      public DateTime WithdrawDate = DateTime.MinValue;
      public DateTime DisbursedDate = DateTime.MinValue;
      public string WithdrawBy;
      public string DisbursedBy;
      public decimal RegisteredAmount;
      public decimal ApprovalAmount;
      public decimal InterestAmount;
      public decimal DisbursedAmount;
      public decimal WithdrawAmount;
      public decimal InterestRatePerDay; // gia tri %
      public decimal InterestRatePenalty;

      public Contract() { }

      private static Contract DB2Object(IDataReader reader)
      {
         Contract result = new Contract();
         result.Id = (int)reader["Id"];
         result.ContractID = (string)reader["ContractID"];
         result.CustomerID = reader["CustomerId"].ToString();
         result.CustomerName = reader["CustomerNameViet"].ToString();
         result.ContractType = (ContractType)Enum.Parse(typeof(ContractType), reader["ContractType"].ToString());
         result.ContractStatus = (ContractStatus)Enum.Parse(typeof(ContractStatus), reader["Status"].ToString());
         result.BranchCode = reader["BranchCode"].ToString();
         result.TradeCode = reader["TradeCode"].ToString();

         result.ContractDueDate = (DateTime)reader["DueDate"];
         result.ExpiredDate = (DateTime)reader["ExpiredDate"];
         result.CreatedBy = reader["CreatedBy"].ToString();
         result.CreatedDate = (DateTime)reader["CreatedDate"];

         if (reader["ApprovedDate"] != DBNull.Value)
            result.ApprovedDate = (DateTime)reader["ApprovedDate"];
         if (reader["ApprovedBy"] != DBNull.Value)
            result.ApprovedBy = reader["ApprovedBy"].ToString();

         // hop dong ky han
         if (reader["RegisteredAmount"] != DBNull.Value)
            result.RegisteredAmount = (decimal)reader["RegisteredAmount"];
         if (reader["ApprovalAmount"] != DBNull.Value)
            result.ApprovalAmount = (decimal)reader["ApprovalAmount"];
         if (reader["DisbursedAmount"] != DBNull.Value)
            result.DisbursedAmount = (decimal)reader["DisbursedAmount"];
         if (reader["WithdrawAmount"] != DBNull.Value)
            result.WithdrawAmount = (decimal)reader["WithdrawAmount"];
         if (reader["InterestRatePerDay"] != DBNull.Value)
            result.InterestRatePerDay = (decimal)reader["InterestRatePerDay"];
         if (reader["InterestRatePenalty"] != DBNull.Value)
            result.InterestRatePenalty = (decimal)reader["InterestRatePenalty"];
         if (reader["InterestAmount"] != DBNull.Value)
            result.InterestAmount = (decimal)reader["InterestAmount"];
         if (reader["DisbursedDate"] != DBNull.Value)
            result.DisbursedDate = (DateTime)reader["DisbursedDate"];
         if (reader["DisbursedBy"] != DBNull.Value)
            result.DisbursedBy = reader["DisbursedBy"].ToString();
         if (reader["WithdrawDate"] != DBNull.Value)
            result.WithdrawDate = (DateTime)reader["WithdrawDate"];
         if (reader["WithdrawBy"] != DBNull.Value)
            result.WithdrawBy = reader["WithdrawBy"].ToString();

         return result;
      }

      public static List<Contract> FindContracts(string customerId, ContractType type, DateTime fromDate, DateTime toDate, ContractStatus status, UserLite user)
      {
         List<Contract> result = new List<Contract>();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildFindContracts(customerId, type, fromDate, toDate, status, user));
         while (reader.Read())
            result.Add(DB2Object(reader));
         reader.Close();
         return result;
      }

      public static List<Contract> GetListForDisburse(string customerId, DateTime fromDate, DateTime toDate, ContractStatus status, UserLite user)
      {
         List<Contract> result = new List<Contract>();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildGetListForDisburse(customerId, fromDate, toDate, status, user));
         while (reader.Read())
            result.Add(DB2Object(reader));
         reader.Close();
         return result;
      }

      public static List<Contract> GetListForWithdraw(string customerId, DateTime fromDate, DateTime toDate, UserLite user)
      {
         List<Contract> result = new List<Contract>();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildGetListForWithdraw(customerId, fromDate, toDate, user));
         while (reader.Read())
            result.Add(DB2Object(reader));
         reader.Close();
         return result;
      }

      public static Contract GetContract(int contractId)
      {
         Contract result = new Contract();
         SqlDataReader reader = DBUtil.ExecuteDataReader("");
         if (reader.Read())
            result = DB2Object(reader);
         reader.Close();
         return result;
      }

      internal static Contract GetCurrentContract(string customerId, UserLite user)
      {
         Contract result = new Contract();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildFindContracts(customerId, ContractType.Both, DateTime.MinValue, DateTime.MaxValue, ContractStatus.None, user));
         if (reader.Read())
            result = DB2Object(reader);
         reader.Close();
         return result;
      }

      // mode: 0 - save normal, 1 - renewal
      public static Contract Save(Contract contract, int mode, UserLite user)
      {
         string sql, sqlU = null;
         if (contract.Id == 0)
         {
            sql = SqlHelper.BuildInserSql(contract);
            sqlU = "update vrm_contract set contractid = '{0}' where id = {1}";
         }
         else
            sql = SqlHelper.BuildUpdateSql(contract);
         contract.Id = (int)DBUtil.ExecuteScalar(sql);
         // update contractid
         if (!string.IsNullOrEmpty(sqlU))
         {
            contract.ContractID = string.Format(@"{0:000#}-{1}/{2}", contract.Id, contract.BranchCode, contract.TradeCode);
            DBUtil.ExecuteNonQuery(string.Format(sqlU, contract.ContractID, contract.Id));
         }

         if (mode == 1) // renewal
            UpdateContractLog(contract, user, "R", string.Empty, 
               contract.DisbursedAmount - contract.WithdrawAmount, 
               string.Format("GIA HAN HOP DONG {0} DEN NGAY {1:dd/MM/yyyy}", contract.ContractID, contract.ExpiredDate));

         return contract;
      }

      public static void Disburse(decimal amount, Contract contract, UserLite user)
      {
         if (contract.ContractType == ContractType.KhongThoiHan)
            return;

         string validate = Validate(contract, 0);
         if (!string.IsNullOrEmpty(validate))
            throw new Exception(validate);

         TransactionResult trans = TransactionUtil.CreateTransaction(
            BalanceAccount.Get_135411(contract.CustomerID, user),
            BalanceAccount.Get_324111(contract.CustomerID, user),
            GlobalConstants.HACHTOAN_GIAINGANHDKH,
            amount,
            string.Format("GIAI NGAN HDHTKD:{0} NGAY {1} SO TIEN {2:n0}", contract.ContractID, DateTime.Today.ToString("dd/MM/yyyy"), contract.RegisteredAmount),
            contract.CustomerID,
            user);

         contract.DisbursedAmount += amount;
         contract.DisbursedBy = user.UserName;
         contract.DisbursedDate = DateTime.Now;
         contract.ContractStatus = ContractStatus.DaGiaiNgan;

         Contract.Save(contract, 0, user);

         // save log
         string des = string.Format("GIAI NGAN HD {0} SO TIEN {1:n0}", contract.ContractID, amount);
         UpdateContractLog(contract, user, GlobalConstants.HD_GIAINGAN, trans.TransactionNumber, amount, des);
      }

      private static void UpdateContractLog(Contract contract, UserLite user, string tranCode, string tranNumber, decimal amount, string note)
      {
         string sql = SqlHelper.BuildInsertContractLogSql(contract, user, tranCode, tranNumber, amount, note);
         DBUtil.ExecuteNonQuery(sql);
      }

      public static string Validate(Contract contract, int mode)
      {
         if (contract.ContractType != ContractType.CoThoiHan)
            return string.Empty;

         object value = DBUtil.ExecuteScalar(SqlHelper.BuildCheckContract(contract, mode));
         if (value == null)
            return string.Empty;
         return value.ToString();
      }

      public static void Withdraw(Contract contract, decimal withdrawAmount, decimal interestAmount, string note, UserLite user)
      {
         if (contract.ContractType == ContractType.KhongThoiHan)
            return;

         BalanceAccount b324 = BalanceAccount.Get_324111(contract.CustomerID, user);

         TransactionResult trans = TransactionUtil.CreateTransaction(
            b324,
            BalanceAccount.Get_135411(contract.CustomerID, user),
            GlobalConstants.HACHTOAN_THANHLYHDKH,
            withdrawAmount,
            string.Format("THANH LY HDHTKD:{0} ({3:dd/MM/yyyy} - {4:dd/MM/yyyy}) {1} SO TIEN {2:n0}", 
               contract.ContractID, DateTime.Today.ToString("dd/MM/yyyy"), withdrawAmount, contract.ContractDueDate, contract.ExpiredDate),
            contract.CustomerID,
            user);

         // save log
         string des = string.Format("THU NO GOC HD {0} SO TIEN {1:n0} {2} ", contract.ContractID, withdrawAmount, note);
         UpdateContractLog(contract, user, GlobalConstants.HD_THANHLY_THUNOGOC, trans.TransactionNumber, withdrawAmount, des);

         trans = TransactionUtil.CreateTransaction(
            b324,
            BalanceAccount.Get_511871(contract.CustomerID, user),
            GlobalConstants.HACHTOAN_THANHLYHDKH,
            interestAmount,
            string.Format("THU NHAP TU HDHTKD SO {0} THANH LY NGAY {1:n0} {2}", contract.ContractID, DateTime.Today.ToString("dd/MM/yyyy"), note),
            contract.CustomerID,
            user);

         // log
         des = string.Format("THU PHI HOP TAC DO THANH LY HD {0} SO TIEN {1:n0} {2} ", contract.ContractID, interestAmount, note);
         UpdateContractLog(contract, user, GlobalConstants.HD_THANHLY_THULAI, trans.TransactionNumber, interestAmount, des);

         contract.InterestAmount += interestAmount;
         contract.WithdrawAmount += withdrawAmount;
         contract.WithdrawBy = user.UserName;
         contract.WithdrawDate = DateTime.Now;
         if (contract.DisbursedAmount == contract.WithdrawAmount)
            contract.ContractStatus = ContractStatus.KetThuc;

         Contract.Save(contract, 0, user);
      }

      private sealed class SqlHelper
      {

         internal static string BuildFindContracts(string customerId, ContractType type, DateTime fromDate, DateTime toDate, ContractStatus status, UserLite user)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT v.*, c.CustomerNameViet ");
            sql.Append("FROM vrm_Contract v JOIN dbo.Customers c ON v.CustomerId = c.CustomerId ");

            if (user.IsAgencyMember)
            {
               sql.Append("join dbo.agencycustomer a on c.customerid = a.customerid ");
               sql.AppendFormat("where a.AgencyTradingCode = '{0}' ", user.TradeCode);
            }
            else
               sql.AppendFormat("where v.BranchCode = '{0}' ", user.BranchCode);
            if (fromDate != DateTime.MinValue || toDate != DateTime.MaxValue)
               sql.AppendFormat("and v.CreatedDate BETWEEN {0} AND {1} ",
                  LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
            if (status != ContractStatus.None)
               sql.AppendFormat("AND v.Status = {0} ", (byte)status);
            else if (fromDate == DateTime.MinValue || toDate == DateTime.MaxValue)
               sql.AppendFormat("AND v.Status != {0} ", (byte)ContractStatus.KetThuc);
            if (type != ContractType.Both)
               sql.AppendFormat("AND v.ContractType = {0} ", (byte)type);

            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and v.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));

            return sql.ToString();
         }

         internal static string BuildGetListForDisburse(string customerId, DateTime fromDate, DateTime toDate, ContractStatus status, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append(BuildFindContracts(customerId, ContractType.CoThoiHan, fromDate, toDate, ContractStatus.None, user));
            if (status == ContractStatus.DaDuyet)
               sql.AppendFormat(" and v.Status = {0} ", (byte)ContractStatus.DaDuyet);
            else if (status == ContractStatus.DaGiaiNgan)
               sql.AppendFormat(" and (v.Status = {0} and v.approvalamount > v.disbursedamount) ", (byte)ContractStatus.DaGiaiNgan);
            else
               sql.AppendFormat(" and (v.Status = {0} or (v.Status = {1} and v.approvalamount > v.disbursedamount)) ",
                     (byte)ContractStatus.DaDuyet, (byte)ContractStatus.DaGiaiNgan);

            return sql.ToString();
         }

         internal static string BuildGetListForWithdraw(string customerId, DateTime fromDate, DateTime toDate, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append(BuildFindContracts(customerId, ContractType.CoThoiHan, fromDate, toDate, ContractStatus.None, user));
            sql.AppendFormat(" and v.Status = {0} ", (byte)ContractStatus.DaGiaiNgan);

            return sql.ToString();
         }

         internal static string BuildInserSql(Contract contract)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO dbo.vrm_Contract( CustomerId ,ContractType ,CreatedDate,DueDate ,ExpiredDate , CreatedBy , BranchCode ,TradeCode, ");
            sql.Append("RegisteredAmount, InterestRatePerDay, InterestRatePenalty, Status) ");
            sql.Append("OUTPUT INSERTED.Id VALUES  ( ");
            sql.AppendFormat("'{0}' ,", contract.CustomerID);
            sql.AppendFormat("{0} ,", (byte)contract.ContractType);
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.CreatedDate));
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.ContractDueDate));
            sql.AppendFormat("{0} ,", LiteralUtil.GetLiteral(contract.ExpiredDate));
            sql.AppendFormat("'{0}' ,", contract.CreatedBy);
            sql.AppendFormat("'{0}' ,", contract.BranchCode);
            sql.AppendFormat("'{0}' ,", contract.TradeCode);
            // hop dong ky han
            sql.AppendFormat("{0}, ", LiteralUtil.GetNumericLiteral(contract.RegisteredAmount));
            sql.AppendFormat("{0}, ", LiteralUtil.GetNumericLiteral(contract.InterestRatePerDay));
            sql.AppendFormat("{0}, ", LiteralUtil.GetNumericLiteral(contract.InterestRatePenalty));
            sql.AppendFormat("{0})", (byte)contract.ContractStatus);

            return sql.ToString();
         }

         internal static string BuildUpdateSql(Contract contract)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE dbo.vrm_Contract SET ");
            sql.AppendFormat("CustomerId = '{0}' ,", contract.CustomerID);
            sql.AppendFormat("ContractType = {0} ,", (byte)contract.ContractType);
            sql.AppendFormat("DueDate = {0} ,", LiteralUtil.GetLiteral(contract.ContractDueDate));
            sql.AppendFormat("ExpiredDate = {0} ,", LiteralUtil.GetLiteral(contract.ExpiredDate));
            if (contract.ApprovedDate != DateTime.MinValue && contract.ApprovedDate != DateTime.MaxValue)
            {
               sql.AppendFormat("ApprovedDate = {0} ,", LiteralUtil.GetLiteral(contract.ApprovedDate));
               sql.AppendFormat("ApprovedBy = '{0}' ,", contract.ApprovedBy);
               sql.AppendFormat("ApprovalAmount = {0} ,", LiteralUtil.GetNumericLiteral(contract.ApprovalAmount));
            }
            if (contract.DisbursedDate != DateTime.MinValue && contract.DisbursedDate != DateTime.MaxValue)
            {
               sql.AppendFormat("DisbursedDate = {0} ,", LiteralUtil.GetLiteral(contract.DisbursedDate));
               sql.AppendFormat("DisbursedBy = '{0}' ,", LiteralUtil.GetLiteral(contract.DisbursedBy));
               sql.AppendFormat("DisbursedAmount = {0} ,", LiteralUtil.GetNumericLiteral(contract.DisbursedAmount));
            }
            if (contract.WithdrawDate != DateTime.MinValue && contract.WithdrawDate != DateTime.MaxValue)
            {
               sql.AppendFormat("WithdrawDate = {0} ,", LiteralUtil.GetLiteral(contract.WithdrawDate));
               sql.AppendFormat("WithdrawBy = '{0}' ,", LiteralUtil.GetLiteral(contract.WithdrawBy));
               sql.AppendFormat("WithdrawAmount = {0} ,", LiteralUtil.GetNumericLiteral(contract.WithdrawAmount));
            }
            sql.AppendFormat("RegisteredAmount = {0} ", LiteralUtil.GetNumericLiteral(contract.RegisteredAmount));
            sql.AppendFormat(",InterestRatePerDay = {0} ", LiteralUtil.GetNumericLiteral(contract.InterestRatePerDay));
            sql.AppendFormat(",InterestRatePenalty = {0} ", LiteralUtil.GetNumericLiteral(contract.InterestRatePenalty));
            sql.AppendFormat(",InterestAmount = {0} ", LiteralUtil.GetNumericLiteral(contract.InterestAmount));
            sql.AppendFormat(",Status = {0} ", (byte)contract.ContractStatus);
            sql.AppendFormat("OUTPUT INSERTED.Id WHERE Id = {0} ", contract.Id);

            return sql.ToString();
         }

         internal static string BuildCheckContract(Contract contract, int mode)
         {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("IF EXISTS (SELECT * FROM dbo.DeferredBalance WHERE CustomerID = '{0}' AND CurrentDebit > 0) \n", contract.CustomerID);
            sql.Append("SELECT N'Khách hàng đang nợ tiền T' \n");
            sql.AppendFormat("ELSE IF EXISTS (SELECT * FROM dbo.CustomerDebitLimit WHERE CustomerId = '{0}' AND DayLimitValue > 0 AND IsActive = 1) \n", contract.CustomerID);
            sql.Append("SELECT N'Đang tồn tại hạn mức tín dụng của khách hàng. Đề nghị bỏ trước khi thực hiện' \n");
            if (mode == 1) // renewal: check if the current contract has issued the interest 
               sql.AppendFormat("ELSE IF NOT EXISTS (SELECT * FROM dbo.vrm_Contract_Transaction WHERE where ContractId = {0} and TransactionCode = 'I' and convert(nvarchar(10), TransactionDay, 103) = {1:dd/MM/yyyy}) and isdeleted <> 1 \n", 
                  contract.Id, DateTime.Today);
            sql.Append("SELECT N'Hợp đồng hiện tại chưa chốt phí, đề nghị chốt phí trước khi gia hạn hợp đồng' \n");

            return sql.ToString();
         }

         internal static string BuildInsertContractLogSql(Contract contract, UserLite user, string tranCode, string tranNumber, decimal amount, string note)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into [dbo].[vrm_Contract_Transaction]( [ContractId] ,[TransactionDay] ,[CreatedBy] ,[TransactionCode] ,[Amount], [Notes], [TransactionNumber]) \n");
            sql.AppendFormat("values  ( {0} , {1}, '{2}', '{3}', {4}, '{5}', '{6}')",
               contract.Id, 
               LiteralUtil.GetLiteral(DateTime.Now), 
               user.UserName, 
               tranCode, 
               LiteralUtil.GetNumericLiteral(amount),
               LiteralUtil.GetLiteral(note),
               tranNumber);
            return sql.ToString();
         }
      }

      public static Contract GetContractByCustomerId(string customerId, UserLite user)
      {
         Contract result = new Contract();
         SqlDataReader reader = DBUtil.ExecuteDataReader(SqlHelper.BuildFindContracts(customerId, ContractType.Both, DateTime.MinValue, DateTime.MaxValue, ContractStatus.None, user));
         if (reader.Read())
            result = DB2Object(reader);
         reader.Close();
         return result;
      }
   }
}
