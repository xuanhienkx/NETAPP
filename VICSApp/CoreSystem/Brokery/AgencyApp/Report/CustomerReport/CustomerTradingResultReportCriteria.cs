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
   public partial class CustomerTradingResultReportCriteria : FormBase
   {
      delegate void UpdateCustomerInfo();
      Customer currentCustomer;

      public CustomerTradingResultReportCriteria()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_BaoCaoXacNhanGiaoDich; }
      }

      public Customer CurentCustomer
      {
         get { return currentCustomer; }
         set { currentCustomer = value; }
      }

      private void CustomerTradingResultReportCriteria_Load(object sender, EventArgs e)
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
         tables[0] = Util.AgencyGateway.GetCustomerOrderReport(Util.TokenKey,
            (string)args[0],
             (DateTime)args[1]
             );
         tables[1] = Util.AgencyGateway.GetCustomerSubTradingResult(Util.TokenKey,
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

         ShowCustomerTradingResultReport(e.Result as DataTable[]);
      }


      private void ShowCustomerTradingResultReport(DataTable[] tbl)
      {
          CustomerTradingResultReport reportDocument = new CustomerTradingResultReport();
          if (tbl[0].Rows.Count > 0)
         {
             SubCustomerTradingResult subReport = new SubCustomerTradingResult();
             subReport.SetDataSource(tbl[1]);
             reportDocument.Subreports[0].SetDataSource(tbl[1]);

            reportDocument.SetDataSource(tbl[0]);
            reportDocument.SetParameterValue("TradingDate", Convert.ToDateTime(TransactionDatePicker.Value));
            reportDocument.SetParameterValue("CustomerID", accountIdTextBox.Text);
            reportDocument.SetParameterValue("CustomerName", accountNameLabel.Text);
            reportDocument.SetParameterValue("PayDate", Util.T3Date);
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());


            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowWaring("Không có dữ liệu");
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
