using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using InterStock;

namespace HOGW_PT_Dealer
{
   public partial class frm1FirmDealCancelSupper : DevExpress.XtraEditors.XtraForm
   {
      public frm1FirmDealCancelSupper()
      {
         InitializeComponent();
      }
      private void RefreshData()
      {
         grdData.DataSource = Util.HosePTGW.Get1FirmOrdersByStatus(CommonSettings.PT_PENDING_CANCEL); //chi nhung lenh dang cho duyet huy
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
         if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.Update1FirmStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCEL_WAITING, Util.LoginResult.UserName); //MXP -> MXS
         }
         RefreshData();
      }

      private void btnDisapprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.Update1FirmStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCELLED, Util.LoginResult.UserName); //MXP -> MXS
         }
         RefreshData();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         RefreshData();
      }
   }
}