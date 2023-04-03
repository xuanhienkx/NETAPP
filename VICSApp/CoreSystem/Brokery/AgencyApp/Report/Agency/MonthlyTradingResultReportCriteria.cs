using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CrystalReport;
using CommonDomain;

namespace Brokery.Report.Agency
{
   public partial class MonthlyTradingResultReportCriteria : FormBase
   {
      public MonthlyTradingResultReportCriteria()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Daily_BaoCaoGiaoDich; }
      }

      private void MonthlyTradingResultReportCriteria_Load(object sender, EventArgs e)
      {
         this.branchCodeTextBox.Text = Util.LoginUser.BranchCode;
         this.tradeCodeBox.Text = Util.LoginUser.TradeCode;
         this.bindingDropdownList();

         quarterComboBox1.SelectedIndex = 0;
         monthComboBox.SelectedIndex = 0;
         YearNumericUpDown.Value = DateTime.Now.Year;
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

         quarterComboBox1.DataSource = new int[] { 1, 2, 3, 4 };
         monthComboBox.DataSource = new string[] { "<Tất cả>", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
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
               quarterRadioButton.Checked,      //0
               boardTypeCombo.SelectedValue,    //1
               (Quarter)Enum.Parse(typeof(Quarter), quarterComboBox1.SelectedValue.ToString()),  //2
               monthComboBox.SelectedIndex,     //3
               YearNumericUpDown.Value.ToString(),         //4
            };
            backgroundWorker.RunWorkerAsync(args);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         DateTime fromDate;
         DateTime toDate;
         int year = int.Parse(args[4].ToString());
         if ((bool)args[0])
         {
            fromDate = DateUtil.GetStartOfQuarter(year, (Quarter)args[2]);
            toDate = DateUtil.GetEndOfQuarter(year, (Quarter)args[2]);
         }
         else
         {
            if ((int)args[3] == 0) // tat ca cac thang
            {
               fromDate = DateUtil.GetStartOfYear(year);
               toDate = DateUtil.GetEndOfYear(year);
            }
            else
            {
               fromDate = DateUtil.GetStartOfMonth(int.Parse(args[3].ToString()), year);
               toDate = DateUtil.GetEndOfMonth(int.Parse(args[3].ToString()), year);
            }
         }
         e.Result = Util.AgencyGateway.GetMonthlyTradingResultReport(Util.TokenKey,
            fromDate,
            toDate,
            args[1].ToString());
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

         ShowMonthlyTradingReport(e.Result as DataTable);
      }

      private void ShowMonthlyTradingReport(DataTable dataTable)
      {
         AgentTransationReport reportDocument = new AgentTransationReport();

         DataView buyView = new DataView(dataTable);
         buyView.RowFilter = "OrderSide = 'B'";
         DataTable tblBuy = new DataTable();
         tblBuy = buyView.ToTable();
         tblBuy.Columns["MatchedVolume"].ColumnName = "MatchedBuyVolume";
         tblBuy.Columns["MatchedPrice"].ColumnName = "MatchedBuyPrice";
         tblBuy.Columns["MatchedValue"].ColumnName = "MatchedBuyValue";

         DataView sellView = new DataView(dataTable);
         sellView.RowFilter = "OrderSide = 'S'";
         DataTable tblSell = new DataTable();
         tblSell = sellView.ToTable();
         tblSell.Columns["MatchedVolume"].ColumnName = "MatchedSellVolume";
         tblSell.Columns["MatchedPrice"].ColumnName = "MatchedSellPrice";
         tblSell.Columns["MatchedValue"].ColumnName = "MatchedSellValue";

         tblSell.Merge(tblBuy);
         tblSell.Columns["IsPrivateAccount"].ColumnName = "IsPrivateAccountString";

         if (dataTable.Rows.Count > 0)
         {
            reportDocument.SetDataSource(tblSell);
            reportDocument.SetParameterValue("BoardName", ((DropDownObject)boardTypeCombo.SelectedItem).Description);
            reportDocument.SetParameterValue("HeadOfficeOrBranchName", Util.GetHeadOfficeOrBranchName());
            reportDocument.SetParameterValue("HeadOfficeOrBranchAddress", Util.GetHeadOfficeOrBranchAddress());
            reportDocument.SetParameterValue("AgencyName", Util.GetAgencyName());
            reportDocument.SetParameterValue("AgencyAddressAndTelephone", Util.GetAgencyAddressAndTelephone());
            reportDocument.SetParameterValue("ReportLocation", Util.GetReportLocation());
            reportDocument.SetParameterValue("DateReport", GetDateString(quarterRadioButton.Checked));
            ReportViewer.LoadReport(reportDocument, this);
         }
         else
         {
            ShowNotice("Không có dữ liệu");
         }
      }

      private bool ValidateInputData()
      {

         if (string.IsNullOrEmpty(this.branchCodeTextBox.Text))
         {
            errorProvider.SetError(this.branchCodeTextBox, "Không được để trống");
            return false;
         }
         return true;
      }

      private void quarterRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         if (quarterRadioButton.Checked == true)
         {
            quarterComboBox1.Enabled = true;
            monthComboBox.Enabled = false;
         }
         else
         {
            quarterComboBox1.Enabled = false;
            monthComboBox.Enabled = true;
         }
      }

      private string GetDateString(bool isQuarter)
      {
         if (isQuarter)
            return string.Format("Quý {0} năm {1}", quarterComboBox1.SelectedIndex + 1, YearNumericUpDown.Value.ToString());
         else
         {
            if (monthComboBox.SelectedIndex == 0)//Tat ca cac thang
               return string.Format("Năm {0}", YearNumericUpDown.Value.ToString());
            else
               return string.Format("Tháng {0} năm {1}", monthComboBox.SelectedIndex, YearNumericUpDown.Value.ToString());
         }
      }
   }
}
