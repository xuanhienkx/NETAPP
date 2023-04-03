using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.VRMGateway;
using VRMApp.ControlBase;
using VRMApp.Framework;
using CrystalDecisions.CrystalReports.Engine;

namespace VRMApp.Accountant
{
   public partial class ContractStatusCriteriaForm : FormBase
   {
      bool isGeneralReport;
      private ContractType contractType;
      public ContractStatusCriteriaForm(ContractType type)
      {
         contractType = type;
         InitializeComponent();
         GUIUtil.FormatDatePicker(tranDatePicker);
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_BaoCaoTinhHinhHDKhongKH);
      }

      public ContractType ContractType
      {
         get { return contractType; }
      }

      private void tongHopButton_Click(object sender, EventArgs e)
      {
         GetData(true);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         GetData(false);
      }

      private void GetData(bool isGeneral)
      {
         if (tranDatePicker.Value.DayOfYear < Util.CurrentTransactionDate.DayOfYear)
         {
            ShowError("Ngày hết hạn hợp đồng phải lớn hơn hoặc bằng ngày giao dịch hiện tại");
            tranDatePicker.Focus();
            return;
         }
         isGeneralReport = isGeneral;
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
         {
            int inDebtType = 0;
            if (coNoRadio.Checked) inDebtType = 1; else if (hetnoRadio.Checked) inDebtType = 2;
            backgroundWorker.RunWorkerAsync(new object[] { Util.CurrentTransactionDate, tranDatePicker.Value, checkBox.Checked, maKHBox.Text.Trim(), inDebtType });
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         object[] args = e.Argument as object[];
         e.Result = Util.VRMService.GetExpireContractStatusReport(Util.TokenKey, (DateTime)args[0], (DateTime)args[1], (bool)args[2], (string)args[3], ContractType.KhongThoiHan, (int)args[4]);
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (Reports.ReportUtil.DataNotValidated((e.Result as DataTable).Rows.Count))
            return;

         ReportClass rp;
         if (isGeneralReport)
            rp = new Reports.Accountant.BaoCaoTongHopTienNo();
         else
            rp = new Reports.Accountant.BaoCaoChiTietTienNo();

         rp.SetDataSource(e.Result as DataTable);
         rp.SetParameterValue("Branch", GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         rp.SetParameterValue("condition", GetConditionString());

         CloseWaiting();

         Reports.ReportViewerForm.LoadReport(rp, this);
      }

      private string GetConditionString()
      {
         string s = checkBox.Checked? "vào" : "trước";
         if (tatcaRadio.Checked)
            return string.Format("Tất cả các khách hàng có hợp đồng HTKD hết hạn {0} ngày {1}", s, GUIUtil.FormatDate(tranDatePicker.Value));
         else if (coNoRadio.Checked)
            return string.Format("Tất cả các khách hàng đang còn nợ T và có hợp đồng HTKD hết hạn {0} ngày {1}", s, GUIUtil.FormatDate(tranDatePicker.Value));
         else
            return string.Format("Tất cả các khách hàng không còn nợ T và có hợp đồng HTKD hết hạn {0} ngày {1}", s, GUIUtil.FormatDate(tranDatePicker.Value));
      }
   }
}
