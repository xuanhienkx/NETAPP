using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CrystalReport;
using CommonDomain;
using AgencyFee = Brokery.AgencyWebService.AgencyFee;

namespace Brokery.Report.Agency
{
   public partial class AgencyTransferFeeReportCriteria : FormBase
   {
      public AgencyTransferFeeReportCriteria()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Daily_BaoCaoPhiGiaoDich; }
      }

      private void AgencyTransferFeeReportCriteria_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatDatePicker(fromDatePicker);
         GUIUtil.FormatDatePicker(toDatePicker);
         this.branchCodeTextBox.Text = Util.LoginUser.BranchCode;
         this.tradeCodeBox.Text = Util.LoginUser.TradeCode;
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
               Convert.ToDateTime(fromDatePicker.Value),
               Convert.ToDateTime(toDatePicker.Value)
            };
            backgroundWorker.RunWorkerAsync(args);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];

         e.Result = Util.AgencyGateway.GetTransferFeeAgentReport(Util.TokenKey,
            (DateTime)args[0],
            (DateTime)args[1]);
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

         StockOrderListReport(e.Result as DataTable);
      }

      private void StockOrderListReport(DataTable dataTable)
      {
         AgentTransferFeeReport reportDocument = new AgentTransferFeeReport();
         if (dataTable.Rows.Count > 0)
         {

            decimal totalValue = 0;
            foreach (DataRow dr in dataTable.Rows)
                totalValue += Convert.ToDecimal(dataTable.Rows[0]["MatchedValue"]);
            totalValue = totalValue / 1000000; 
            AgencyFee[] agencyFees = Util.AgencyGateway.GetAgencyFeeByTradeCode(Util.TokenKey);
            decimal agencyFeePercent=0;
            foreach (AgencyFee aFee in agencyFees)
                if (totalValue >= aFee.ValueFrom && totalValue < aFee.ToValue)
                    agencyFeePercent = aFee.Fee;

            MessageBox.Show(string.Format("Tổng giá trị giao dịch: {0} triệu đồng.\n Tỷ lệ chia phí: Công ty:{1}%. Đại lý:{2}%.",
                totalValue.ToString(),(100-agencyFeePercent).ToString(), agencyFeePercent.ToString()));

            reportDocument.SetDataSource(dataTable);
            reportDocument.SetParameterValue("FromDate", Convert.ToDateTime(fromDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("ToDate", Convert.ToDateTime(toDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("ReportLocation", Util.GetReportLocation());
            //reportDocument.SetParameterValue("CompanyFee", companyFeeNumericUpDown.Value.ToString());
            //reportDocument.SetParameterValue("AgentFee", agentFeeNumericUpDown.Value.ToString());

            reportDocument.SetParameterValue("CompanyFee", (100 - agencyFeePercent).ToString());
            reportDocument.SetParameterValue("AgentFee", agencyFeePercent.ToString());

            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowNotice("Không có dữ liệu");
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

         if (Convert.ToDateTime(this.toDatePicker.Value) > Util.CurrentTransactionDate)
         {
            errorProvider.SetError(this.toDatePicker, "Không được lớn hơn ngày giao dịch hiện tại");
            this.toDatePicker.Select();
            return false;
         }

         return true;
      }

   }
}
