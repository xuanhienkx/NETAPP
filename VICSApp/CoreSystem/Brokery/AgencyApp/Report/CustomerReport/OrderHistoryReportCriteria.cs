using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CrystalReport;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;

namespace Brokery.Report.CustomerReport
{
   public partial class OrderHistoryReportCriteria : FormBase
   {
      delegate void UpdateCustomerInfo();
      Customer currentCustomer;

      public OrderHistoryReportCriteria() : this(null) { }
      public OrderHistoryReportCriteria(Customer customer)
      {
         currentCustomer = customer;
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_LietKeLichSuLenh; }
      }

      public Customer CurentCustomer
      {
         get { return currentCustomer; }
         set { currentCustomer = value; }
      }

      private void OrderHistoryReportCriteria_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatDatePicker(fromDatePicker);
         GUIUtil.FormatDatePicker(toDatePicker);
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
               Convert.ToDateTime(toDatePicker.Value)    //2
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

         e.Result = Util.AgencyGateway.GetCustomerOrderHistory(Util.TokenKey,
             (string)args[0],
             (DateTime)args[1],
             (DateTime)args[2]
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

         if (chkNhomTheoSan.Checked)
            ShowGroupOrderHistoryReport(e.Result as DataTable);
         else
            ShowOrderHistoryReport(e.Result as DataTable);
      }


      private void ShowGroupOrderHistoryReport(DataTable tbl)
      {
         GroupOrderHistoryReport reportDocument = new GroupOrderHistoryReport();
         if (tbl.Rows.Count > 0)
         {
            reportDocument.SetDataSource(tbl);
            reportDocument.SetParameterValue("CustomerID", accountIdTextBox.Text);
            reportDocument.SetParameterValue("CustomerName", accountNameLabel.Text);
            reportDocument.SetParameterValue("FromDate", Convert.ToDateTime(fromDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("ToDate", Convert.ToDateTime(toDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("HASE", "HASE");

            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowWaring("Không có dữ liệu");
         }
      }

      private void ShowOrderHistoryReport(DataTable tbl)
      {
         OrderHistoryReport reportDocument = new OrderHistoryReport();
         if (tbl.Rows.Count > 0)
         {
            reportDocument.SetDataSource(tbl);
            reportDocument.SetParameterValue("CustomerID", accountIdTextBox.Text);
            reportDocument.SetParameterValue("CustomerName", accountNameLabel.Text);
            reportDocument.SetParameterValue("FromDate", Convert.ToDateTime(fromDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("ToDate", Convert.ToDateTime(toDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("HASE", "HASE?");

            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowWaring("Không có dữ liệu");
         }
      }

      private bool ValidateInputData()
      {
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

         if (string.IsNullOrEmpty(this.accountIdTextBox.Text))
         {
            errorProvider.SetError(this.accountIdTextBox, "Không được để trống");
            return false;
         }
         return true;
      }

      private void accountIdTextBox_Validated(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(accountIdTextBox.Text))
         {
            CurentCustomer = null;
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
