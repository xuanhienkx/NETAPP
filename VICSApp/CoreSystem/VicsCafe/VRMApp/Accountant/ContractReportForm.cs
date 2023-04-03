using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Accountant
{
   public partial class ContractReportForm : FormBase
   {
      public enum ContractFormType
      {
         BuyCash,
         Advance
      }

      ContractFormType formType;
      public ContractReportForm(ContractFormType formType)
      {
         InitializeComponent();
         GUIUtil.FormatDatePicker(fromDate);
         GUIUtil.FormatDatePicker(toDate);
         if (formType == ContractFormType.Advance && Util.CheckAccess(AccessPermission.KeToan_ChonDSHDUngTruocVoiNH))
            comboBox.DataSource = new DropDownObject[] {
               new DropDownObject(string.Empty, "<Tất cả>"),
               new DropDownObject("100", GUIUtil.BranchCodeAsString("100")),
               new DropDownObject("200", GUIUtil.BranchCodeAsString("200")),
               new DropDownObject("300", GUIUtil.BranchCodeAsString("300"))
         };
         else
            comboBox.DataSource = new DropDownObject[] { new DropDownObject(Util.LoginUser.BranchCode, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode)) };
         comboBox.DisplayMember = "Description";
         comboBox.ValueMember = "Code";

         this.formType = formType;
         if (formType == ContractFormType.BuyCash)
            this.Text = "DS hợp đồng mua quyền đã phát vay";
         else
            this.Text = "Danh sách hợp đồng ứng trước với ngân hàng";
      }

      public ContractFormType GetFormType()
      {
         return formType;
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_InDSHDMuaQuyen);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         CrystalDecisions.CrystalReports.Engine.ReportClass rp;
         DataTable data;
         if (formType == ContractFormType.BuyCash)
         {
            data = Util.VRMService.GetBuyCashContractReport(Util.TokenKey, fromDate.Value, toDate.Value, "T", "S", 0, false);
            if (Reports.ReportUtil.DataNotValidated(data.Rows.Count))
               return;

            rp = new VRMApp.Reports.Accountant.DSHDMuaQuyenBanCK();
         }
         else
         {
            data = Util.VRMService.GetAdvanceBankTransactionReport(Util.TokenKey, fromDate.Value, toDate.Value, "ABB", "T", "S", 0, false, (string)comboBox.SelectedValue);
            if (Reports.ReportUtil.DataNotValidated(data.Rows.Count))
               return;

            rp = new VRMApp.Reports.Accountant.UngTruocTienBanNH();
         }
         rp.SetDataSource(data);
         rp.SetParameterValue("fromDate", fromDate.Value.ToString("dd/MM/yyyy"));
         rp.SetParameterValue("toDate", toDate.Value.ToString("dd/MM/yyyy"));

         Reports.ReportViewerForm.LoadReport(rp, null);

         CloseWaiting();
      }
   }
}
