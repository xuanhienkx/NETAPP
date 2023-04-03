using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CrystalReport;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;

namespace Brokery.Report.CustomerReport
{
    public partial class TransactionReportCriteria : FormBase
    {
        AccountType accountType;
        delegate void UpdateCustomerInfo();
        Customer currentCustomer;
        private bool isCustomerSpecified;
        private string accountName;

        public TransactionReportCriteria(AccountType type, bool isCustomerSpecified)
            : this(type, null)
        {
            this.isCustomerSpecified = isCustomerSpecified;
            if (!this.isCustomerSpecified)
            {
                this.bankGLTextBox.Enabled = true;
                this.sectionGLTextBox.Enabled = true;
                this.accountIdTextBox.Enabled = true;
                this.Text = "Liệt kê giao dịch tài khoản";
                //this.multiBalanceTransaction.Enabled = true;
            }
            else
            {
                accountName = string.Empty;
            }
        }

        public TransactionReportCriteria(AccountType type, Customer customer)
        {
            accountType = type;
            InitializeComponent();
            this.isCustomerSpecified = true;
            if (accountType == AccountType.Balance)
                this.Text = "Liệt kê giao dịch tiền";
            else if (accountType == AccountType.Contigen)
                this.Text = "Liệt kê giao dịch chứng khoán";

            currentCustomer = customer;
        }

        public override IEnumerable<AccessPermission> AccessKey
        {
            get
            {
                if (!isCustomerSpecified)
                    yield return AccessPermission.VICS_Daily_BaoCaoGiaoDichTaiKhoan;
                if (accountType == AccountType.Balance)
                    yield return AccessPermission.VICS_LietKeGiaoDichTien;
                if (accountType == AccountType.Contigen)
                    yield return AccessPermission.VICS_LietKeGiaoDichChungKhoan;
                yield return AccessPermission.None;
            }
        }

        public Customer CurentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }

        public AccountType AccountType
        {
            get { return accountType; }
        }

        public bool IsForCustomer
        {
            get { return isCustomerSpecified; }
            set { isCustomerSpecified = value; }
        }

        private void TransactionReportCriteria_Load(object sender, EventArgs e)
        {
            GUIUtil.FormatDatePicker(fromDatePicker);
            GUIUtil.FormatDatePicker(toDatePicker);
            tradeCodeBox.Text = Util.LoginUser.TradeCode;
            branchCodeTextBox.Text = Util.LoginUser.BranchCode;

            UpdateCustomerData();
        }

        private void UpdateCustomerData()
        {

            if (!isCustomerSpecified)
            {
                if (!string.IsNullOrEmpty(accountName))
                    this.accountNameLabel.Text = accountName;
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new UpdateCustomerInfo(UpdateCustomerData));
            }
            else
            {
                if (CurentCustomer != null)
                {
                    if (string.IsNullOrEmpty(bankGLTextBox.Text) && CurentCustomer.CustomerId != this.accountIdTextBox.Text)
                        this.bankGLTextBox.Text = Util.GetBankGl(CurentCustomer.CustomerId, accountType);
                    if (string.IsNullOrEmpty(sectionGLTextBox.Text) && CurentCustomer.CustomerId != this.accountIdTextBox.Text)
                        this.sectionGLTextBox.Text = Util.GetSectionGl(CurentCustomer.CustomerId, accountType);
                    accountName = string.Empty;
                    this.accountIdTextBox.Text = CurentCustomer.CustomerId;
                    this.accountNameLabel.Text = CurentCustomer.CustomerNameViet;
                }
                   
                else
                    this.accountNameLabel.Text = string.Empty;
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputData())
                return;

            if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            {
                object[] args = new object[]{
               balanceTransactionRadio.Checked, //0
               bankGLTextBox.Text.Trim(),       //1
               sectionGLTextBox.Text.Trim(),    //2
               accountIdTextBox.Text.Trim(),    //3
               Convert.ToDateTime(fromDatePicker.Value), //4
               Convert.ToDateTime(toDatePicker.Value)    //5
            };
                backgroundWorker.RunWorkerAsync(args);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];

            string accountId =  accountIdTextBox.Text.Trim();
            if (isCustomerSpecified && CurentCustomer == null)
            {
                CurentCustomer = Util.GetCustomer((string)args[3]);
                if (CurentCustomer == null)
                    throw new Exception("Không tìm thấy khách hàng");

                UpdateCustomerData();
                accountName = string.Empty;
                args[1] = Util.GetBankGl(CurentCustomer.CustomerId, accountType);
                args[2] = Util.GetSectionGl(CurentCustomer.CustomerId, accountType);
                accountId = currentCustomer.CustomerId;
            }else if (!isCustomerSpecified)
            {
                DataTable table = Util.AgencyGateway.GetAccountNameBalanceTransaction(Util.TokenKey,accountId);
                if (table.Rows.Count == 0)
                {
                    throw new Exception("Không tìm thấy tài khoản");
                }
                else
                {
                    accountName = table.Rows[0]["AccountName"].ToString();
                    UpdateCustomerData();
                }
            }

            if ((bool)args[0])
            {
                if (accountType == AccountType.Balance)
                {
                    e.Result = Util.AgencyGateway.GetBalanceTransaction(Util.TokenKey,
                        (string)args[1],
                        (string)args[2],
                        accountId,
                        "Balance",
                        (DateTime)args[4],
                        (DateTime)args[5]
                        );
                }
                else if (accountType == AccountType.Contigen)
                {
                    e.Result = Util.AgencyGateway.GetContigenTransaction(Util.TokenKey,
                        (string)args[1],
                        (string)args[2],
                        accountId,
                        "Contigen",
                        (DateTime)args[4],
                        (DateTime)args[5]
                        );
                }
                else
                    throw new Exception("Không xác định được loại báo cáo");
            }
            else
            {
                ShowGroupBalanceTransactionReport();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                return;
            }

            if (e.Result == null)
                return;

            if (accountType == AccountType.Balance)
            {
                if (balanceTransactionRadio.Checked)
                    ShowBalanceTransactionReport(e.Result as BalanceTransactionDataSource);
                else
                    ShowGroupBalanceTransactionReport();
            }
            else if (accountType == AccountType.Contigen)
            {
                if (balanceTransactionRadio.Checked)
                    ShowContigenTransactionReport(e.Result as ContigenTransactionDataSource);
                else
                    ShowGroupContigenTransactionReport();
            }
        }

        private void ShowGroupContigenTransactionReport()
        {
            throw new NotImplementedException();
        }

        private void ShowContigenTransactionReport(ContigenTransactionDataSource contigenTransaction)
        {
            if (string.IsNullOrEmpty(contigenTransaction.Message))
            {
                ContigenTransactionReport reportDocument = new ContigenTransactionReport();
                reportDocument.SetDataSource(contigenTransaction.Items);

                reportDocument.SetParameterValue("Report_Location", Util.GetReportLocation());
                reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
                reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
                reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
                reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
                reportDocument.SetParameterValue("LastBalance", contigenTransaction.LastBalance);
                if (this.fromDatePicker.Value == null)
                {
                    reportDocument.SetParameterValue("StartDate", fromDatePicker.Text);
                }
                else
                {
                    reportDocument.SetParameterValue("StartDate", Convert.ToDateTime(this.fromDatePicker.Value));
                }
                if (this.toDatePicker.Value == null)
                {
                    reportDocument.SetParameterValue("EndDate", toDatePicker.Text);
                }
                else
                {
                    reportDocument.SetParameterValue("EndDate", Convert.ToDateTime(this.toDatePicker.Value));
                }
                reportDocument.SetParameterValue("BankGL", contigenTransaction.BankGl);
                reportDocument.SetParameterValue("AccountId", contigenTransaction.AccountId);
                reportDocument.SetParameterValue("AccountName", contigenTransaction.AccountName);
                reportDocument.SetParameterValue("BranchCode", contigenTransaction.BranchCode);
                reportDocument.SetParameterValue("SumDebit", contigenTransaction.SumDebit);
                reportDocument.SetParameterValue("SumCredit", contigenTransaction.SumCredit);
                reportDocument.SetParameterValue("BeginDay", contigenTransaction.BeginDay);
                reportDocument.SetParameterValue("BeginDayQuantity", contigenTransaction.BeginDayQuantity);
                reportDocument.SetParameterValue("SumDebitQuantity", contigenTransaction.SumDebitQuantity);
                reportDocument.SetParameterValue("SumCreditQuantity", contigenTransaction.SumCreditQuantity);
                reportDocument.SetParameterValue("LastBalanceQuantity", contigenTransaction.LastBalanceQuantity);
                reportDocument.SetParameterValue("SectionGL", contigenTransaction.SectionGl);

                ReportViewer.LoadReport(reportDocument, this);
            }
            else
            {
                ShowNotice(contigenTransaction.Message);
            }
        }

        private void ShowGroupBalanceTransactionReport()
        {
            throw new NotImplementedException();
        }

        private void ShowBalanceTransactionReport(BalanceTransactionDataSource balanceTransaction)
        {
            if (string.IsNullOrEmpty(balanceTransaction.Message))
            {
                BalanceTransactionReport reportDocument = new BalanceTransactionReport();
                reportDocument.SetDataSource(balanceTransaction.Items);

                if (this.fromDatePicker.Value == null)
                {
                    reportDocument.SetParameterValue("StartDate", fromDatePicker.Text);
                }
                else
                {
                    reportDocument.SetParameterValue("StartDate", Convert.ToDateTime(this.fromDatePicker.Value));
                }
                if (this.toDatePicker.Value == null)
                {
                    reportDocument.SetParameterValue("EndDate", toDatePicker.Text);
                }
                else
                {
                    reportDocument.SetParameterValue("EndDate", Convert.ToDateTime(this.toDatePicker.Value));
                }
                reportDocument.SetParameterValue("AccountId", accountIdTextBox.Text);
                reportDocument.SetParameterValue("AccountName", accountNameLabel.Text);
                reportDocument.SetParameterValue("Report_Location", Util.GetReportLocation());
                reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
                reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
                reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
                reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
                reportDocument.SetParameterValue("BankGL", bankGLTextBox.Text);
                reportDocument.SetParameterValue("BeginBalance", balanceTransaction.BeginBalance);
                reportDocument.SetParameterValue("SumDebit", balanceTransaction.SumDebit);
                reportDocument.SetParameterValue("SumCredit", balanceTransaction.SumCredit);
                reportDocument.SetParameterValue("LastBalance", balanceTransaction.LastBalance);
                reportDocument.SetParameterValue("BranchCode", branchCodeTextBox.Text);
                reportDocument.SetParameterValue("SectionGL", sectionGLTextBox.Text);
                reportDocument.SetParameterValue("AccountDebitOrCredit", balanceTransaction.AccountDebitOrCredit);
                reportDocument.SetParameterValue("Footer1", Util.Parameters.Report_Footer1);
                reportDocument.SetParameterValue("Footer2", Util.Parameters.Report_Footer2);
                reportDocument.SetParameterValue("Footer3", Util.Parameters.Report_Footer3);

                ReportViewer.LoadReport(reportDocument, this);
            }
            else
            {
                ShowWaring(balanceTransaction.Message);
            }
        }

        private bool ValidateInputData()
        {
            errorProvider.Clear();

            if (Convert.ToDateTime(this.fromDatePicker.Value) > Convert.ToDateTime(this.toDatePicker.Value))
            {
                errorProvider.SetError(this.fromDatePicker, "Không được lớn hơn ngày kết thúc");
                this.fromDatePicker.Select();
                return false;
            }
            if (Convert.ToDateTime(this.toDatePicker.Value) > Util.CurrentTransactionDate)
            {
                errorProvider.SetError(this.toDatePicker, "Không được lớn hơn ngày giao dịch hiện tại");
                this.toDatePicker.Select();
                return false;
            }
            if (balanceTransactionRadio.Checked)
            {
                if (string.IsNullOrEmpty(this.branchCodeTextBox.Text))
                {
                    errorProvider.SetError(this.branchCodeTextBox, "Không được để trống");
                    return false;
                }
                if (string.IsNullOrEmpty(this.bankGLTextBox.Text))
                {
                    errorProvider.SetError(this.bankGLTextBox, "Không được để trống");
                    return false;
                }
                if (string.IsNullOrEmpty(this.sectionGLTextBox.Text))
                {
                    errorProvider.SetError(this.sectionGLTextBox, "Không được để trống");
                    return false;
                }
                if (string.IsNullOrEmpty(this.accountIdTextBox.Text))
                {
                    errorProvider.SetError(this.accountIdTextBox, "Không được để trống");
                    return false;
                }
            }
            else if (string.IsNullOrEmpty(this.bankGLTextBox.Text)
               && string.IsNullOrEmpty(this.sectionGLTextBox.Text) &&
               string.IsNullOrEmpty(this.accountIdTextBox.Text))
            {
                errorProvider.SetError(this.bankGLTextBox, "Không được để trống");
                errorProvider.SetError(this.sectionGLTextBox, "Không được để trống");
                errorProvider.SetError(this.accountIdTextBox, "Không được để trống");
                return false;
            }
            return true;
        }

        private void accountIdTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(accountIdTextBox.Text))
            {
                CurentCustomer = null;
                errorProvider.SetError(accountIdTextBox, "Không được để trống");
                return;
            }

            accountIdTextBox.Text = GUIUtil.ValidateCustomerId(accountIdTextBox.Text);
            if (CurentCustomer != null && accountIdTextBox.Text != CurentCustomer.CustomerId)
            {
                CurentCustomer = null;
                UpdateCustomerData();
            }

            if (string.IsNullOrEmpty(bankGLTextBox.Text))
                this.bankGLTextBox.Text = Util.GetBankGl(accountIdTextBox.Text, accountType);
            if (string.IsNullOrEmpty(sectionGLTextBox.Text))
                this.sectionGLTextBox.Text = Util.GetSectionGl(accountIdTextBox.Text, accountType);
        }
    }
}
