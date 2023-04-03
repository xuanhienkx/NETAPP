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
   public partial class frm2FirmSellerCancelSuper : DevExpress.XtraEditors.XtraForm
   {
      DataTable tbl;
      public frm2FirmSellerCancelSuper()
      {
         InitializeComponent();
      }
      private void RefreshData()
      {
         grdData.DataSource = Util.HosePTGW.GetSellerOrdersByStatus(CommonSettings.PT_PENDING_CANCEL); //duyet nhung lenh da duoc broker duyet cho huy
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
         if (MessageBox.Show("Chắc chắn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateSellerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCEL_WAITING, Util.LoginResult.UserName); //MXP -> MXS
         }
         RefreshData();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         RefreshData();
      }

      private void btnDisapprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateSellerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCELLED, Util.LoginResult.UserName); //MXP -> X
         }
         RefreshData();
      }

   }
}