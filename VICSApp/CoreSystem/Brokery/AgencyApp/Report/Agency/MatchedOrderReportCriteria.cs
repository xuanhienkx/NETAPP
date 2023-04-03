using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CrystalReport;
using CommonDomain;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Report.Agency
{
   public partial class MatchedOrderReportCriteria : FormBase
   {
      public MatchedOrderReportCriteria()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Daily_KetQuaKhopLenhTrongNgay; }
      }

      private void MatchedOrderReportCriteria_Load(object sender, EventArgs e)
      {

         GUIUtil.FormatDatePicker(tradingDatePicker);
         this.branchCodeTextBox.Text = Util.LoginUser.BranchCode;
         this.tradeCodeBox.Text = Util.LoginUser.TradeCode;
         this.bindingDropdownList();

      }

      private void bindingDropdownList()
      {
         // board type
         List<DropDownObject> items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(Util.HOSEBoard, "Sàn HOSE"));
         items.Add(new DropDownObject(Util.HNXBoard, "Sàn HNX"));
         items.Add(new DropDownObject(Util.UPCOMBoard, "Sàn OTC"));
         //UPCOM ??
         boardTypeCombo.DataSource = items;
         boardTypeCombo.DisplayMember = "Description";
         boardTypeCombo.ValueMember = "Code";

         // order side
         items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(OrderSide.B.ToString(), "Mua"));
         items.Add(new DropDownObject(OrderSide.S.ToString(), "Bán"));
         orderSideCombo.DataSource = items;
         orderSideCombo.DisplayMember = "Description";
         orderSideCombo.ValueMember = "Code";

         // stock type
         items = new List<DropDownObject>();
         items.Add(new DropDownObject("S", "Cổ phiếu/chứng chỉ quỹ"));
         items.Add(new DropDownObject("D", "Trái phiếu"));
         StockTypeComboBox.DataSource = items;
         StockTypeComboBox.DisplayMember = "Description";
         StockTypeComboBox.ValueMember = "Code";
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
               Convert.ToDateTime(tradingDatePicker.Value),
               boardTypeCombo.SelectedValue,
               orderSideCombo.SelectedValue,
               StockTypeComboBox.SelectedValue
            };
            backgroundWorker.RunWorkerAsync(args);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];

         e.Result = Util.AgencyGateway.GetAgencyOrderHistory(Util.TokenKey,
            (DateTime)args[0],
            (DateTime)args[0],
            args[1].ToString(),
            args[2].ToString(),
            args[3].ToString());
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
         AgentOrderHistoryReport reportDocument = new AgentOrderHistoryReport();

         dataTable.Columns["CustomerName"].ColumnName = "CustomerNameViet";
         if (dataTable.Rows.Count > 0)
         {
            reportDocument.SetDataSource(dataTable);
            reportDocument.SetParameterValue("TradingDate", Convert.ToDateTime(tradingDatePicker.Value).ToString("dd/MM/yyyy"));
            reportDocument.SetParameterValue("BoardType", ((DropDownObject)boardTypeCombo.SelectedItem).Description);
            reportDocument.SetParameterValue("StockType", ((DropDownObject)StockTypeComboBox.SelectedItem).Description);
            reportDocument.SetParameterValue("OrderSide", ((DropDownObject)orderSideCombo.SelectedItem).Description);
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("ReportLocation", Util.GetReportLocation());
            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowNotice("Không có dữ liệu");
         }
      }

      private bool ValidateInputData()
      {

         if (Convert.ToDateTime(this.tradingDatePicker.Value) > Util.CurrentTransactionDate)
         {
            errorProvider.SetError(this.tradingDatePicker, "Không được lớn hơn ngày giao dịch hiện tại");
            this.tradingDatePicker.Select();
            return false;
         }
         return true;
      }
   }
}
