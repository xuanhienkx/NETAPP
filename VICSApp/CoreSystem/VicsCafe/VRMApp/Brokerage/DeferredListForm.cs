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

namespace VRMApp.Brokerage
{
   public partial class DeferredListForm : StdForm
   {
      public DeferredListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView);

         if (Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach))
         {
            List<DropDownObject> source = new List<DropDownObject>();
            source.Add(new DropDownObject(string.Empty, "<Tất cả>"));

            List<UserLite> users = new List<UserLite>(Util.VRMService.FindUsers(Util.TokenKey, string.Empty));
            foreach (UserLite u in users)
               source.Add(new DropDownObject(u.UserId.ToString(), u.UserName));
            nvchamsoccb.ComboBox.DataSource = source;
         }
         else
            nvchamsoccb.ComboBox.DataSource = new DropDownObject[] { new DropDownObject(Util.LoginUser.UserId.ToString(), Util.LoginUser.UserName) };

         loaiHDCombo.ComboBox.DataSource = new DropDownObject[]{
            new DropDownObject(string.Empty, "<Tất cả>"),
            new DropDownObject("OFFTERM", "Không có HĐ"),
            new DropDownObject("OUTTERM", "HĐ không thời hạn"),
            new DropDownObject("INTERM", "HĐ có thời hạn")
         };
         nvchamsoccb.ComboBox.DisplayMember = loaiHDCombo.ComboBox.DisplayMember = "Description";
         nvchamsoccb.ComboBox.ValueMember = loaiHDCombo.ComboBox.ValueMember = "Code";
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_XemDSKhachHangThieuTien);
      }

      private void CustomerListForm_Load(object sender, EventArgs e)
      {
         UpdateStatus(dataGridView);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            backgroundWorker.RunWorkerAsync(new string[] { 
               maKHBox.Text, (string)nvchamsoccb.ComboBox.SelectedValue, (string)loaiHDCombo.ComboBox.SelectedValue 
            });
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         string[] args = e.Argument as string[];
         int userTk = string.IsNullOrEmpty(args[1]) ? 0 : int.Parse(args[1]);
         e.Result = Util.VRMService.FindDeferredTDayList(Util.TokenKey, userTk, args[2], args[0]);
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
            DataTable data = e.Result as DataTable;
            data.Columns.Add("loaihd", typeof(string));
            data.Columns.Add("tienthieu", typeof(decimal));
            foreach (DataRow r in data.Rows)
            {
               r["loaihd"] = GetContractTypeAsString(r["ContractType"]);
               r["tienthieu"] = Math.Max(0, (decimal)r["tienmua"] - (decimal)r["tienno"] - (decimal)r["currentbalance"]);
            }

            dataGridView.DataSource = data;
            UpdateStatus(dataGridView);
         }
         CloseWaiting();
      }

      private string GetContractTypeAsString(object type)
      {
         if (type == DBNull.Value)
            return string.Empty;

         if ((byte)type == (byte)ContractType.CoThoiHan)
            return "Có thời hạn";
         if ((byte)type == (byte)ContractType.KhongThoiHan)
            return "Không thời hạn";
         return string.Empty;
      }

      private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex == -1 || dataGridView["hopdong", e.RowIndex].Value != DBNull.Value)
            return;

         Contract contract = new Contract();
         contract.CustomerID = (string)dataGridView["customerid", e.RowIndex].Value;
         contract.ContractType = ContractType.KhongThoiHan;
         ContractForm cf = new ContractForm(contract);
         cf.ShowDialog();
         toolStripButton1.PerformClick();
      }
   }
}
