using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyApp.Controls;
using AgencyApp.AgencyWebService;
using AgencyApp.Framework;
using AgencyApp.Report.CrystalReport;

namespace AgencyApp.Report
{
   public partial class CustomerGeneralReportCriteria : FormBase
   {
      delegate void UpdateCustomerInfo();
      Customer currentCustomer;

      public CustomerGeneralReportCriteria() : this(null) { }
      public CustomerGeneralReportCriteria(Customer customer)
      {
         currentCustomer = customer;
         InitializeComponent();
      }

      public override AccessPermission AccessKey
      {
         get { return AccessPermission.VICS_BaoCaoTongHopTaiKhoan; }
      }

      public Customer CurentCustomer
      {
         get { return currentCustomer; }
         set { currentCustomer = value; }
      }

      private void TransactionReportCriteria_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatDatePicker(TransactionDatePicker);
         tradeCodeBox.Text = Util.LoginUser.TradeCode;
         branchCodeTextBox.Text = Util.LoginUser.BranchCode;

         UpdateCustomerData();
      }

      private void UpdateCustomerData()
      {
         if (InvokeRequired)
         {
            Invoke(new UpdateCustomerInfo(UpdateCustomerData));
         }
         else
         {
            if (CurentCustomer != null)
            {
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
               accountIdTextBox.Text.Trim(),    //0
               Convert.ToDateTime(TransactionDatePicker.Value), //1
            };
            backgroundWorker.RunWorkerAsync(args);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];

         if (CurentCustomer == null)
         {
            CurentCustomer = Util.GetCustomer((string)args[0]);
            if (CurentCustomer == null)
               throw new Exception("Không tìm thấy khách hàng");

            UpdateCustomerData();
         }
         DataTable[] tables = new DataTable[2];
         tables[0] = Util.AgencyGateway.GetCustomerStockEnquiry(Util.TokenKey,
             (string)args[0],
             (DateTime)args[1]
             );
         //if (tables[0].Rows.Count > 0)
         tables[1] = Util.AgencyGateway.GetCustomerOrder3DayEarly(Util.TokenKey, 
               (string)args[0],
             (DateTime)args[1]
             );
         e.Result = tables;
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

         ShowCustomerGeneralReport(e.Result as DataTable[]);
      }

      private void ShowCustomerGeneralReport(DataTable[] tables)
      {
         CustomerGeneralReport reportDocument = new CustomerGeneralReport();
         if (tables[0].Rows.Count > 0 || tables[1].Rows.Count > 0)
         {
            SumerizeTradingResult subReport = new SumerizeTradingResult();
            subReport.SetDataSource(tables[1]);
            subReport.SetParameterValue("Sub_CompanyName_vi", Util.GetHeadOfficeOrBranchName());

            reportDocument.Subreports[0].SetDataSource(tables[1]);

            decimal decCurrentBalance = 0;
            decCurrentBalance = Util.AgencyGateway.GetCustomerCurrentBalance(Util.TokenKey, accountIdTextBox.Text, branchCodeTextBox.Text, Convert.ToDateTime(TransactionDatePicker.Value));
            reportDocument.SetDataSource(tables[0]);
            reportDocument.SetParameterValue("AccountID", accountIdTextBox.Text);
            reportDocument.SetParameterValue("AccountName", accountNameLabel.Text);
            reportDocument.SetParameterValue("CurrentBalance", decCurrentBalance);
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("TradingDate", Convert.ToDateTime(TransactionDatePicker.Value).ToString("dd/MM/yyyy"));

            if (tables[1].Rows.Count > 0)
               reportDocument.SetParameterValue("IsSubReportNull", "true");
            else
               reportDocument.SetParameterValue("IsSubReportNull", "false");

            reportDocument.SetParameterValue("HASE", "HASE");
            reportDocument.SetParameterValue("Sub_CompanyName_vi", Util.GetHeadOfficeOrBranchName());

            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowError("Không có dữ liệu");
         }
      }

      private bool ValidateInputData()
      {
         if (Convert.ToDateTime(this.TransactionDatePicker.Value) > Util.CurrentTransactionDate)
         {
            errorProvider.SetError(this.TransactionDatePicker, "Không được lớn hơn ngày giao dịch hiện tại");
            this.TransactionDatePicker.Select();
            return false;
         }

         if (string.IsNullOrEmpty(this.branchCodeTextBox.Text))
         {
            errorProvider.SetError(this.branchCodeTextBox, "Không được để trống");
            return false;
         }
         if (string.IsNullOrEmpty(this.accountIdTextBox.Text))
         {
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
      }

   }
}
