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
   public partial class frm2FirmBuyerApproveSuper : DevExpress.XtraEditors.XtraForm
   {
      public frm2FirmBuyerApproveSuper()
      {
         InitializeComponent();
      }
      private void RefreshData(string status)
      {
         //CommonSettings.PT_PENDING
         grdData.DataSource = Util.HosePTGW.GetBuyerOrdersByStatus(status); //chi lay nhung lenh vua duoc connector day vao
         gridView1.OptionsView.ColumnAutoWidth = false;

         //enable buttons
         btnApprove.Enabled = gridView1.RowCount > 0;
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void frm2FirmDealApprove_Load(object sender, EventArgs e)
      {
         cboApproveType.Items.Clear();
         cboApproveType.Items.Add("Duyệt");
         cboApproveType.Items.Add("Từ chối");

         cboApproveType.SelectedIndex = 0;
         RefreshData(CommonSettings.PT_PENDING);
      }

      private void btnSelectAll_Click(object sender, EventArgs e)
      {
         gridView1.SelectAll();
      }

      private void btnApprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn duyệt?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         if (cboApproveType.SelectedIndex == 0) //approve lenh tu seller
         {
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_APPROVED, Util.LoginResult.UserName); //P->S (supervisor duyet)
            }
            RefreshData(CommonSettings.PT_PENDING);
         }
         else
         {
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_DEAL_DISAPPROVE, Util.LoginResult.UserName); //P->S (supervisor duyet)
            }
            RefreshData(CommonSettings.PT_BUYER_DEAL_DISAPPROVE_PENDING);
         }
      }

      private void cboApproveType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cboApproveType.SelectedIndex == 0) //approve
            RefreshData(CommonSettings.PT_PENDING);
         else //disapprove seller deals
            RefreshData(CommonSettings.PT_BUYER_DEAL_DISAPPROVE_PENDING);
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         if (cboApproveType.SelectedIndex == 0) //approve lenh tu seller
            RefreshData(CommonSettings.PT_PENDING);
         else
            RefreshData(CommonSettings.PT_BUYER_DEAL_DISAPPROVE_PENDING);
      }
   }
}