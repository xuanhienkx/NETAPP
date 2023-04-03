using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using InterStock;

namespace HOGW_PT_Dealer
{
   public partial class frm2FirmSellerApprove : DevExpress.XtraEditors.XtraForm
   {
      public frm2FirmSellerApprove()
      {
         InitializeComponent();
      }
      private void RefreshData()
      {
         grdData.DataSource = Util.HosePTGW.GetSellerOrdersByStatus(CommonSettings.PT_PENDING); //chi lay nhung lenh vua duoc nhap, co trang thai la P
         gridView1.OptionsView.ColumnAutoWidth = false;

         //enable buttons
         btnApprove.Enabled = btnDisapprove.Enabled = gridView1.RowCount > 0;
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void frm2FirmDealApprove_Load(object sender, EventArgs e)
      {
         RefreshData();
      }

      private void btnSelectAll_Click(object sender, EventArgs e)
      {
         gridView1.SelectAll();
      }

      private void btnApprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateSellerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_APPROVED, Util.LoginResult.UserName); //P->S
         }
         RefreshData();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         RefreshData();
      }

      private void btnDisapprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateSellerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCELLED, Util.LoginResult.UserName); //P->X, khong duyet
         }
         RefreshData();
      }
   }
}