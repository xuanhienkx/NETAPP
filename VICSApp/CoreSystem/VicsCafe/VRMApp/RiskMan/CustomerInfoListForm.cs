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
using VRMApp.VRMGateway;

namespace VRMApp.RiskMan
{
   public partial class CustomerInfoListForm : StdForm
   {
      public CustomerInfoListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.AddContextMenuOnColumns(dataGridView1); 
         dataGridView1.MultiSelect = true;

         if (Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach))
         {
            List<DropDownObject> source = new List<DropDownObject>();
            source.Add(new DropDownObject(string.Empty, "<Tất cả>"));

            List<UserLite> users = new List<UserLite>(Util.VRMService.FindUsers(Util.TokenKey, string.Empty));
            foreach (UserLite u in users)
               source.Add(new DropDownObject(u.UserId.ToString(), u.UserName));
            nhanvienComboBox.ComboBox.DataSource = source;
         }
         else
            nhanvienComboBox.ComboBox.DataSource = new DropDownObject[] { new DropDownObject(Util.LoginUser.UserId.ToString(), Util.LoginUser.UserName) };
         nhanvienComboBox.ComboBox.DisplayMember = "Description";
         nhanvienComboBox.ComboBox.ValueMember = "Code";
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.BaoCao_LietKeThongTinChiTietKH);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
         {
            backgroundWorker1.RunWorkerAsync(new string[] { 
               khachHangTextBox.Text.Trim(), 
               (string)nhanvienComboBox.ComboBox.SelectedValue,
               tileComboBox.Text.Trim()
            });
         }
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         string[] args = e.Argument as string[];
         int userId = string.IsNullOrEmpty(args[1]) ? 0 : int.Parse(args[1]);
         decimal rate = string.IsNullOrEmpty(args[2]) ? 0 : decimal.Parse(args[2]);
         e.Result = Util.VRMService.GetCustomerAssetInfoList(Util.TokenKey, Util.CurrentTransactionDate, args[0], userId, false, rate, false, ContractType.Both);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            return;
         }
         custAssetInfoBindingSource.DataSource = e.Result as CustAssetInfo[];
         UpdateStatus(dataGridView1);
         CloseWaiting();
      }

      private void printReport(bool coTuc)
      {
         if (custAssetInfoBindingSource.Count == 0)
            return;

         CrystalDecisions.CrystalReports.Engine.ReportClass rp;
         if (coTuc)
            rp = new Reports.RiskMan.TaiSanVaCongNoVoiCoTuc();
         else
            rp = new Reports.RiskMan.TaiSanVaCongNo();
         rp.SetDataSource(custAssetInfoBindingSource.DataSource);
         rp.SetParameterValue("Branch", GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         if (coTuc)
            rp.SetParameterValue("Title", "BÁO CÁO TÌNH HÌNH TÀI SẢN VÀ CÔNG NỢ CÓ CỔ TỨC");
         else
            rp.SetParameterValue("Title", "BÁO CÁO TÌNH HÌNH TÀI SẢN VÀ CÔNG NỢ");

         int userTakeCare = string.IsNullOrEmpty((string)nhanvienComboBox.ComboBox.SelectedValue) ? 0 : int.Parse((string)nhanvienComboBox.ComboBox.SelectedValue);
         rp.SetParameterValue("UserTakeCare", userTakeCare == 0 ? "<Tất cả>" : nhanvienComboBox.ComboBox.SelectedText);
         rp.SetParameterValue("printdate", Util.CurrentTransactionDate.ToString("dd/MM/yyyy"));

         Reports.ReportViewerForm.LoadReport(rp, null);
      }

      private void dsTàiSảnKhôngTínhCổTứcToolStripMenuItem_Click(object sender, EventArgs e)
      {
         printReport(false);
      }

      private void dsTàiSảnCóTínhCổTứcToolStripMenuItem_Click(object sender, EventArgs e)
      {
         printReport(true);
      }

   }
}
