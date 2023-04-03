using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.Services;
using VRMDomain;
using VRMDomain.Common;
using VRMDomain.Domain;

namespace VRMGateway
{
    /// <summary>
    /// Vics Risk Managerment Service
    /// </summary>
    [WebService(Namespace = "http://vics.vn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class VRMService : System.Web.Services.WebService
    {
        #region Private

        private const string MESSAGE = "Thông tin đăng nhập bị sai hoặc đã hết phiên làm việc. Yêu cầu đăng nhập lại";

        private UserLite Authorize(string key)
        {
            key = CryptoEngine.Decrypt(key);
            string version = key.Split('|')[1];
            if (version != System.Configuration.ConfigurationManager.AppSettings["RequiredApplicationVersion"])
                throw new Exception("Hiện phiên bản bạn đang dùng chưa được cập nhật, xin vui lòng đóng chương trình và mở lại để có được bản cập nhật nhất.");

            string tokenKey = key.Split('|')[0];
            var uInfo = Session[tokenKey] as UserLite;
            if (uInfo == null)
                throw new Exception(MESSAGE);
            return uInfo;
        }

        private static DateTime Convert2SmallDateTime(DateTime time)
        {
            return time.Add(-time.TimeOfDay);
        }

        #endregion

        #region Security & Common

        [WebMethod]
        public string HelloVics()
        {
            return System.Configuration.ConfigurationManager.AppSettings["RequiredApplicationVersion"];
        }

        [WebMethod(EnableSession = true)]
        public string GetAuthorize(string username, string password)
        {
            Session.RemoveAll();
            UserLite u = UserLite.GetUser(CryptoEngine.Decrypt(username), Context.Request.UserHostAddress);
            if (u == null || LiteralUtil.Encrypt(CryptoEngine.Decrypt(password)) != u.Password)
                return string.Empty;
            u.Rights = UserLite.GetUserAccess(u.UserId);
            string key = Guid.NewGuid().ToString();
            Session[key] = u;
            return key;
        }

        [WebMethod(EnableSession = true)]
        public void ClearTokenKey(string key)
        {
            Session.Remove(CryptoEngine.Decrypt(key));
        }

        [WebMethod(EnableSession = true)]
        public UserLite GetUser(string key, string username)
        {
            UserLite uInfo = Authorize(key);
            if (uInfo != null)
                return uInfo;
            return UserLite.GetUser(username, string.Empty);
        }

        [WebMethod(EnableSession = true)]
        public List<UserLite> FindUsers(string key, string username)
        {
            UserLite uInfo = Authorize(key);
            return UserLite.Find(username, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public List<UserLite> GetUserList(string key, int groupId)
        {
            UserLite uInfo = Authorize(key);
            return UserLite.GetList(groupId, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public void ChangeUserPassword(string key, int userId, string newPassword)
        {
            Authorize(key);
            UserLite.ChangePassword(userId, newPassword);
        }

        [WebMethod(EnableSession = true)]
        public DateTime GetCurrentTransactionDate(string key)
        {
            UserLite uInfo = Authorize(key);
            return SBSDal.GetCurrentTransaction(uInfo.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetUserAccessString(string key, int userId)
        {
            UserLite uInfo = Authorize(key);
            if (userId == 0)
                userId = uInfo.UserId;
            return UserLite.GetUserAccess(userId);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateUserAccessString(string key, List<string> accessList, int userId)
        {
            UserLite uInfo = Authorize(key);
            if (userId == 0)
                userId = uInfo.UserId;
            UserLite.UpdateUserAccess(accessList, userId);
        }

        #endregion

        # region Customers & Contract & Stock

        [WebMethod(EnableSession = true)]
        public Customer GetCustomer(string key, string customerId)
        {
            UserLite uInfo = Authorize(key);
            return Customer.GetCustomer(customerId, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateVRMCustomerInfo(string key, string customerId, byte rate, bool isSpecial)
        {
            UserLite uInfo = Authorize(key);
            Customer.UpdateVRMCustomerInfo(customerId, rate, isSpecial, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public List<Customer> FindCustomers(string key, string customerId, int userTakeCare)
        {
            UserLite uInfo = Authorize(key);
            return Customer.Find(customerId, userTakeCare, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public void SetUserTakeCare(string key, string customerId, int userTakeCareId)
        {
            UserLite uInfo = Authorize(key);
            Customer.SetUserTakeCare(customerId, userTakeCareId);
        }

        [WebMethod(EnableSession = true)]
        public List<Contract> FindContracts(string key, string customerId, ContractType type, DateTime fromDate, DateTime toDate, ContractStatus status)
        {
            UserLite user = Authorize(key);
            return Contract.FindContracts(customerId, type, fromDate, toDate, status, user);
        }

        [WebMethod(EnableSession = true)]
        public List<Contract> GetContractsForDisburse(string key, string customerId, DateTime fromDate, DateTime toDate, ContractStatus status)
        {
            UserLite user = Authorize(key);
            return Contract.GetListForDisburse(customerId, fromDate, toDate, status, user);
        }

        [WebMethod(EnableSession = true)]
        public List<Contract> GetContractsForWithdraw(string key, string customerId, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return Contract.GetListForWithdraw(customerId, fromDate, toDate, user);
        }

        [WebMethod(EnableSession = true)]
        public Contract GetCurrentContract(string key, string customerId)
        {
            UserLite u = Authorize(key);
            return Contract.GetContractByCustomerId(customerId, u);
        }

        [WebMethod(EnableSession = true)]
        public Contract SaveContract(string key, Contract contract, int mode)
        {
            UserLite user = Authorize(key);
            return Contract.Save(contract, mode, user);
        }

        [WebMethod(EnableSession = true)]
        public string ValidateInTermContract(string key, Contract contract, int mode)
        {
            UserLite user = Authorize(key);
            return Contract.Validate(contract, mode);
        }

        [WebMethod(EnableSession = true)]
        public List<Stock> GetStockList(string key, string stockCode)
        {
            UserLite u = Authorize(key);
            return Stock.GetList(u, stockCode);
        }

        [WebMethod(EnableSession = true)]
        public Stock GetStock(string key, string stockCode)
        {
            UserLite u = Authorize(key);
            return Stock.Get(stockCode, u);
        }

        [WebMethod(EnableSession = true)]
        public void SaveStock(string key, Stock stock)
        {
            UserLite u = Authorize(key);
            Stock.Save(stock, u);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteStock(string key, Stock stock)
        {
            UserLite u = Authorize(key);
            Stock.Delete(stock);
        }

        #endregion

        #region Deffered

        [WebMethod(EnableSession = true)]
        public CustAssetInfo GetCustomerAssetInfo(string key, DateTime transDate, string customerId, bool isGetTopOne)
        {
            UserLite u = Authorize(key);
            return CustAssetInfo.GetCustomerAssetInfo(customerId, transDate, u, isGetTopOne);
        }

        [WebMethod(EnableSession = true)]
        public List<CustAssetInfo> GetCustomerAssetInfoList(string key, DateTime transDate, string customerId, int userTakeCareID, bool forDebitLimit, decimal limitDebtRatio, bool showWarning, ContractType contractType)
        {
            UserLite u = Authorize(key);
            return CustAssetInfo.GetCustomerAssetInfoList(customerId, transDate, u, userTakeCareID, forDebitLimit, limitDebtRatio, showWarning, contractType);
        }

        [WebMethod(EnableSession = true)]
        public List<CustAssetInfo> GetCustomerAssetInfoListForDebt(string key, DateTime transDate, string customerId, int userTakeCareID, bool isOverT2Debt)
        {
            UserLite u = Authorize(key);
            return CustAssetInfo.GetCustomerAssetInfoListForDebt(customerId, transDate, u, userTakeCareID, isOverT2Debt);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetDefferedTDayList(string key, DateTime tradingDate, string customerId)
        {
            UserLite u = Authorize(key);
            return DeferredUtil.GetDefferedTDayList(u, tradingDate, customerId);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetDefferedList(string key, string customerID, DateTime transDate)
        {
            UserLite u = Authorize(key);
            return DeferredUtil.GetDefferedList(u, transDate, customerID);
        }

        [WebMethod(EnableSession = true)]
        public void DeferringTDay(string key, string customerId, decimal payMatchedAmount, decimal payFeeAmount, decimal deferredMatchedAmount, decimal deferredFeeAmount)
        {
            UserLite u = Authorize(key);
            DeferredUtil.DeferringTDay(customerId, payMatchedAmount, payFeeAmount, deferredMatchedAmount, deferredFeeAmount, u);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerDeferredTranList(string key, string customerId, DateTime prvInterestDate, DateTime interestDate)
        {
            UserLite u = Authorize(key);
            var table = DeferredUtil.GetCustomerDeferredTranList(customerId, prvInterestDate, interestDate, u);
            return table;
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetUserTransCodeList(string key)
        {
            UserLite u = Authorize(key);
            return DeferredUtil.GetUserTransCode(u);
        }

        [WebMethod(EnableSession = true)]
        public DataTable FindDeferredTDayList(string key, int takeCareId, string contractTypeString, string customerID)
        {
            UserLite user = Authorize(key);
            return DeferredUtil.FindDeferredTDayList(takeCareId, contractTypeString, customerID, user);
        }

        #endregion

        #region Disbursed & Withdraw Contract

        [WebMethod(EnableSession = true)]
        public void DisburseContract(string key, Contract contract, decimal disburseAmount)
        {
            UserLite u = Authorize(key);
            Contract.Disburse(disburseAmount, contract, u);
        }

        [WebMethod(EnableSession = true)]
        public void WithdrawContract(string key, Contract contract, decimal withdrawAmount, decimal interestAmount, string note)
        {
            UserLite u = Authorize(key);
            Contract.Withdraw(contract, withdrawAmount, interestAmount, note, u);
        }

        [WebMethod(EnableSession = true)]
        public Result CreateDebitLimit(string key, string customerId, DateTime transDate, decimal debitAmount)
        {
            UserLite user = Authorize(key);
            return DeferredUtil.CreateDebitLimit(customerId, transDate, debitAmount, user);
        }

        #endregion

        #region Transaction

        [WebMethod(EnableSession = true)]
        public void CreateWithdrawDeferredTransaction(string key, string customerId, decimal amount, DateTime transDate)
        {
            UserLite u = Authorize(key);
            DeferredUtil.Withdraw(customerId, amount, u, transDate);
        }

        [WebMethod(EnableSession = true)]
        public void CreateRetreiveInterestTransaction(string key, BalanceAccount account, string customerid, decimal amount, DateTime interestedDate)
        {
            UserLite user = Authorize(key);
            DeferredUtil.RetreiveInterest(account, customerid, amount, interestedDate, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetInterestTransactionList(string key, string customerId, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return DeferredUtil.GetInterestTransactionList(customerId, fromDate, toDate, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetIssuedTransactionList(string key, string userTranscode, string transCode, string status, string accountid)
        {
            UserLite user = Authorize(key);
            return TransactionUtil.GetIssuedTransactionList(userTranscode, transCode, status, accountid, user);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteIssuedTransaction(string key, string customerId, string transCode, string status)
        {
            UserLite user = Authorize(key);
            TransactionUtil.DeleteIssuedTransaction(customerId, transCode, status, user);
        }

        [WebMethod(EnableSession = true)]
        public void ApproveTransaction(string key, string customerId, string transactionNumber, DateTime transDate)
        {
            UserLite user = Authorize(key);
            TransactionUtil.ApprovingTransaction(customerId, transactionNumber, transDate, user);
        }

        [WebMethod(EnableSession = true)]
        public void UnBlockBalanceAmount(string key, string customerId, decimal unBlockedCreditAmount, decimal unBlockedLocalAmount, decimal unBlockedBankAmount, DateTime transDate)
        {
            UserLite user = Authorize(key);
            TransactionUtil.UnBlockBalanceAmount(customerId, unBlockedCreditAmount, unBlockedLocalAmount, unBlockedBankAmount, transDate, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetBlockBalanceAndDebitLimitInfo(string key, string customerId)
        {
            UserLite user = Authorize(key);
            return Customer.GetBlockBalanceAndDebitLimitInfo(customerId, user);
        }

        #endregion

        #region Report

        [WebMethod(EnableSession = true)]
        public DataTable GetDebitLimitInfo(string key, string customerId)
        {
            UserLite u = Authorize(key);
            return DebtInfo.GetDebitLimitInfo(customerId);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerStockEnquiry(string key, string customerId, DateTime transDate)
        {
            UserLite u = Authorize(key);
            return Customer.GetCustomerStockEnquiry(customerId, Convert2SmallDateTime(transDate), u);
        }

        [WebMethod(EnableSession = true)]
        public DataSet ShowBalanceAccountTransaction(string key, string bankGl, string sectionGl, string accountId, DateTime fromDate, DateTime toDate, bool isGetBeginDay)
        {
            UserLite user = Authorize(key);
            return BalanceAccount.ShowBalanceAccountTransaction(bankGl, sectionGl, accountId, fromDate, toDate, isGetBeginDay, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetAdvanceBankTransactionReport(string key, DateTime fromDate, DateTime toDate, string bankCode, string contractStatus, string stockType, int dateType, bool isSoldMortage, string branchCode)
        {
            UserLite user = Authorize(key);
            return BalanceAccount.GetAdvanceBankTransactionReport(fromDate, toDate, bankCode, contractStatus, stockType, dateType, isSoldMortage, branchCode, user);
        }

        [WebMethod(EnableSession = true)]
        // inDebtType: 0 - tat ca, 1 - dang no, 2 - da het no (chua chot lai)
        public DataTable GetExpireContractStatusReport(string key, DateTime tranDate, DateTime exprireDate, bool isExactlyExp, string customerId, ContractType contractType, int inDebtType)
        {
            UserLite user = Authorize(key);
            return DeferredUtil.GetExpireContractStatusReport(contractType, tranDate, exprireDate, isExactlyExp, customerId, inDebtType, user);
        }


        #endregion

        #region Depository

        [WebMethod(EnableSession = true)]
        public DataTable GetMissingStocks(string key)
        {
            Authorize(key);
            return Stock.GetMissingStocks();
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetRightExecNotPayYet(string key, string stockCode, string customerId)
        {
            UserLite user = Authorize(key);
            return CustAssetInfo.GetRightExecNotPayYet(stockCode, customerId, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetRightExecRegisterNotPayYet(string key, string stockCode, string customerId, DateTime transDate)
        {
            UserLite user = Authorize(key);
            return CustAssetInfo.GetRightExecRegisterNotPayYet(stockCode, customerId, transDate, user);
        }

        [WebMethod(EnableSession = true)]
        public void CancelRightExec(string key, int rightId, string customerID, bool isRightRegisterd)
        {
            UserLite user = Authorize(key);
            CustAssetInfo.CancelRightExec(rightId, customerID, isRightRegisterd);
        }

        #endregion

        #region Utitilies

        [WebMethod(EnableSession = true)]
        public List<BuyCashContract> GetBuyCashContractList(string key, DateTime createdDate, string status)
        {
            UserLite user = Authorize(key);
            return BuyCashContract.GetList(createdDate, status, user);
        }

        [WebMethod(EnableSession = true)]
        public void ChangeBuyCashContractStatus(string key, Guid id, string status)
        {
            UserLite user = Authorize(key);
            BuyCashContract.ChangeStatus(id, status, user);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetBuyCashContractReport(string key, DateTime fromDate, DateTime toDate, string status, string stockType, int dateType, bool isSoldMortage)
        {
            UserLite user = Authorize(key);
            return BuyCashContract.GetBuyCashContractReport(fromDate, toDate, status, stockType, dateType, isSoldMortage, user);
        }

        [WebMethod(EnableSession = true)]
        public List<BalanceAccount> GetDefinedBalanceAccounts(string key, string code)
        {
            UserLite user = Authorize(key);
            return BalanceAccount.GetDefinedBalanceAccounts(code, user);
        }

        #endregion

        #region OnlineTransfer
        //Bank
        [WebMethod(EnableSession = true)]
        public void InsertBank(string key, Bank bank)
        {
            UserLite user = Authorize(key);
            Bank.InsertBank(bank);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateBank(string key, Bank bank)
        {
            UserLite user = Authorize(key);
            Bank.UpdateBank(bank);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteBank(string key, string bankCode)
        {
            UserLite user = Authorize(key);
            Bank.DeleteBank(bankCode);
        }

        [WebMethod(EnableSession = true)]
        public List<Bank> GetBankList(string key)
        {
            UserLite user = Authorize(key);
            return Bank.GetBankList();
        }

        [WebMethod(EnableSession = true)]
        public Bank GetBank(string key, string bankCode)
        {
            UserLite user = Authorize(key);
            return Bank.GetBank(bankCode);
        }


        //BankBranch
        [WebMethod(EnableSession = true)]
        public void InsertBankBranch(string key, BankBranch bankBranch)
        {
            UserLite user = Authorize(key);
            BankBranch.InsertBankBranch(bankBranch);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateBankBranch(string key, BankBranch bankBranch)
        {
            UserLite user = Authorize(key);
            BankBranch.UpdateBankBranch(bankBranch);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteBankBranch(string key, string bankBranchCode)
        {
            UserLite user = Authorize(key);
            BankBranch.DeleteBankBranch(bankBranchCode);
        }

        [WebMethod(EnableSession = true)]
        public List<BankBranch> GetBankBranchList(string key, string bankCode)
        {
            UserLite user = Authorize(key);
            return BankBranch.GetBankBranchList(bankCode);
        }

        [WebMethod(EnableSession = true)]
        public BankBranch GetBankBranch(string key, string bankBranchCode)
        {
            UserLite user = Authorize(key);
            return BankBranch.GetBankBranch(bankBranchCode);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetAllProvince(string key)
        {
            UserLite user = Authorize(key);
            return BankBranch.GetAllProvinceCode();
        }

        //Regist an account for transfer money
        [WebMethod(EnableSession = true)]
        public void InsertAccountTransfer(string key, AccountTransfer accountTransfer)
        {
            UserLite user = Authorize(key);

            AccountTransfer.InsertAccountTransfer(accountTransfer, user.UserName);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateAccountTransfer(string key, AccountTransfer accountTransfer)
        {
            UserLite user = Authorize(key);
            AccountTransfer.UpdateAccountTransfer(accountTransfer, user.UserName);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteAccountTransfer(string key, string accountID, string customerID)
        {
            UserLite user = Authorize(key);
            AccountTransfer.DeleteAccountTransfer(accountID, customerID);
        }

        [WebMethod(EnableSession = true)]
        public List<AccountTransfer> GetAccountTransferList(string key, string customerID, string accountID)
        {
            UserLite user = Authorize(key);
            return AccountTransfer.GetAccountTransferList(customerID, accountID, user.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public AccountTransfer GetAccountTransfer(string key, string accountID, string customerID)
        {
            UserLite user = Authorize(key);
            return AccountTransfer.GetAccountTransfer(accountID, customerID);
        }


        //View and Process online transfer request
        [WebMethod(EnableSession = true)]
        public void OnlineTransferChangeStatus(string key, Int64 transferID, string status, string reject, decimal transferFee)
        {
            UserLite user = Authorize(key);
            OnlineTransfer.OnlineTransferChangeStatus(transferID, user.UserName, status, reject, transferFee);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetOnlineTransferReport(string key, DateTime fromDate, DateTime toDate, string status)
        {
            UserLite user = Authorize(key);
            return OnlineTransfer.GetOnlineTransferReport(fromDate, toDate, status, user.BranchCode);
        }


        [WebMethod(EnableSession = true)]
        public DataTable GetOnlineRegistedReport(string key, DateTime fromDate, DateTime toDate, string active)
        {
            UserLite user = Authorize(key);
            return OnlineTransfer.GetOnlineRegistedReport(fromDate, toDate, active, user.BranchCode);
        }



        [WebMethod(EnableSession = true)]
        public List<OnlineTransfer> GetOnlineTransferList(string key, string customerID, string accountID, DateTime fromDate, DateTime toDate, string status)
        {
            UserLite user = Authorize(key);
            return OnlineTransfer.GetOnlineTransferList(customerID, accountID, fromDate, toDate, status, user.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public OnlineTransfer GetOnlineTransfer(string key, Int64 transferID)
        {
            UserLite user = Authorize(key);
            return OnlineTransfer.GetOnlineTransfer(transferID);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetInterestRate(string key)
        {
            UserLite user = Authorize(key);
            return SBSDal.GetInterestRateOnDb(user.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public List<IncomeTax> GetSbsIncomeTax(string key, string branch, DateTime from, DateTime to, string accountNumner)
        {
            UserLite user = Authorize(key);
            return IncomeTax.GetList(branch, from, to, accountNumner);
        }
       
        [WebMethod(EnableSession = true)]
        public List<IncomeTax> GetKtIncomeTax(string key, string branch, DateTime from, DateTime to, string accountNumner)
        {
            UserLite user = Authorize(key);
            return IncomeTax.GetKtList(branch, from, to, accountNumner);
        }

        [WebMethod(EnableSession = true)]
        public List<IncomeTax> InsertKtIncomeTax(string key, string branch, DateTime from, DateTime to, string accountNumner)
        {
            UserLite user = Authorize(key);
            IncomeTax.ImportIncomeTax(branch, from, to, accountNumner);
            return IncomeTax.GetKtList(branch, from, to, accountNumner);
        }

        #endregion

        #region VariableCapitalPrice

        [WebMethod(EnableSession = true)]
        public List<VariableCapitalPrice> VariableCapitalPrices(string key, string stockCode, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return VariableCapitalPrice.GetList(stockCode, fromDate, toDate);
        }

        [WebMethod(EnableSession = true)]
        public void SaveVariableCapitalPric(string key, VariableCapitalPrice variableCapitalPrice)
        {
            UserLite user = Authorize(key);
            VariableCapitalPrice.Save(variableCapitalPrice);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteVariableCapitalPric(string key, VariableCapitalPrice variableCapitalPrice)
        {
            UserLite user = Authorize(key);
            VariableCapitalPrice.Delete(variableCapitalPrice);
        }
        #endregion

        #region Custody
        /// <summary>
        /// Get detail Custody fee
        /// </summary>
        /// <param name="key">Token key</param>
        /// <param name="customerId">customerId</param>
        /// <param name="callDate">callDate</param>
        /// <param name="feeRate">feeRate</param>
        /// <param name="isSellT3">Call for Sell T-3</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<SecurityFeeLog> GetDataForCallFeeCustory(string key, string customerId, DateTime callDate, double feeRate, bool isSellT3 = true)
        {
            UserLite user = Authorize(key);
            return SecurityFeeLog.GetCustomerSecurityFeeDetails(user, callDate, customerId, feeRate, isSellT3);
        }

        [WebMethod(EnableSession = true)]
        public SecuriryCallResult InsertTransactionFeeCustody(string key, string customerId, decimal amount, DateTime interestedDate)
        {
            UserLite user = Authorize(key);
            return SecurityFeeLog.PutFeeCustody(customerId, amount, interestedDate, user);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateSecurityLog(string key, List<SecurityFeeLog> securityFeeLogs, SecuriryCallResult callResult)
        {
            UserLite user = Authorize(key);
            SecurityFeeLog.UpdateSecurityLog(securityFeeLogs,  callResult);
        }
        [WebMethod(EnableSession = true)]
        public bool IsAccountingCustody(string key, string accountId, DateTime feeDate)
        {
            UserLite user = Authorize(key);
            return SecurityFeeLog.IsAccoutingCustody(accountId,feeDate);
        }
        [WebMethod(EnableSession = true)]
        public List<SummaryCustody> SummaryCustody(string key, DateTime fromDate, DateTime toDate, decimal feeRate = 0.4M)
        {
            UserLite user = Authorize(key);
            return SecurityFeeLog.SummaryCustody(fromDate, toDate,feeRate);
        }
        #endregion Custody

        [WebMethod(EnableSession = true)]
        public DataSet GetSummaryTrading(string key, DateTime calldate)
        {
            UserLite user = Authorize(key);
            return TradingResult.GetSummaryTrading(calldate);
        }
    }
}
