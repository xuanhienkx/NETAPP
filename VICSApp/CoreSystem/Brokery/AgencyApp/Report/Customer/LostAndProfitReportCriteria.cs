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
   public partial class LostAndProfitReportCriteria : FormBase
   {
      delegate void UpdateCustomerInfo();
      Customer currentCustomer;

      public LostAndProfitReportCriteria() : this(null) { }
      public LostAndProfitReportCriteria(Customer customer)
      {
         currentCustomer = customer;
         InitializeComponent();
      }

      public override AccessPermission AccessKey
      {
         get { return AccessPermission.VICS_BaoCaoLoLaiDuKien; }
      }

      public Customer CurentCustomer
      {
         get { return currentCustomer; }
         set { currentCustomer = value; }
      }

      private void LostAndProfitReportCriteria_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatDatePicker(fromDatePicker);
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
               Convert.ToDateTime(fromDatePicker.Value), //1
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

         e.Result = Util.AgencyGateway.GetCustomerLostAndProfit(Util.TokenKey,
            (string)args[0],
             (DateTime)args[1]
             );
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

         ShowLostAndProfitReport(e.Result as DataTable);
      }


      private void ShowLostAndProfitReport(DataTable tbl)
      {
         LostAndProfitReport reportDocument = new LostAndProfitReport();
         if (tbl.Rows.Count > 0)
         {
            reportDocument.SetDataSource(tbl);
            reportDocument.SetParameterValue("FromDate", Convert.ToDateTime(fromDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("CustomerID", accountIdTextBox.Text);
            reportDocument.SetParameterValue("TotalProfit", 0);
            reportDocument.SetParameterValue("CustomerName", accountNameLabel.Text);
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("ReportLocation", Util.GetReportLocation());

            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowWaring("Không có dữ liệu");
         }
      }

      private bool ValidateInputData()
      {
         if (Convert.ToDateTime(this.fromDatePicker.Value) > Util.CurrentTransactionDate)
         {
            errorProvider.SetError(this.fromDatePicker, "Không được lớn hơn ngày giao dịch hiện tại");
            this.fromDatePicker.Select();
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
