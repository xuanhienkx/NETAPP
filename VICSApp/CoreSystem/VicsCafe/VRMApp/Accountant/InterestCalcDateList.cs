using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRM.Controls;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.Reports;
using VRMApp.Reports.Accountant;

namespace VRMApp.Accountant
{
   public partial class InterestCalcDateList : FormBase
   {
      DateTimePicker fromDate;
      DateTimePicker toDate;
      public InterestCalcDateList()
      {
         InitializeComponent();
         
         GUIUtil.FormatGridView(dataGrid);
         
         fromDate = new DateTimePicker();
         GUIUtil.FormatDatePicker(fromDate);
         this.toolStrip1.Items.Insert(4, new ToolStripControlHost(fromDate));
         toDate = new DateTimePicker();
         GUIUtil.FormatDatePicker(toDate);
         this.toolStrip1.Items.Insert(7, new ToolStripControlHost(toDate));
      }

      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         DataTable data = Util.VRMService.GetInterestTransactionList(Util.TokenKey,KHtoolStripTextBox.Text.Trim(), fromDate.Value, toDate.Value);
         dataGrid.DataSource = data;

         lblRecordNum.Text = data.Rows.Count.ToString();
         decimal amount = 0;
         foreach(DataRow r in data.Rows)
            amount += r["interestamount"] == DBNull.Value ? 0M : (decimal)r["interestamount"];
         lblTongLai.Text = GUIUtil.MoneyAsString(amount);
      }

      public override bool CheckAccess()
      {
         return true;
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
        ShowWaiting("Xử lý dữ liệu trước khi load ...");

         VRMDataSet.DSKHchotphiDataTable data = new VRMDataSet.DSKHchotphiDataTable();
         DSKHchotphi rp = new DSKHchotphi();

         rp.SetDataSource(dataGrid.DataSource as DataTable);
         rp.SetParameterValue(rp.Parameter_fromDate.ParameterFieldName,toolStrip1.Items[4].ToString());
         rp.SetParameterValue(rp.Parameter_toDate.ParameterFieldName, toolStrip1.Items[7].ToString());
         rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         ReportViewerForm.LoadReport(rp, this);
      }
      }
   }
