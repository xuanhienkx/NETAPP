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
   public partial class frmAdvApprove : DevExpress.XtraEditors.XtraForm
   {
      public frmAdvApprove()
      {
         InitializeComponent();
      }
      private void RefreshData()
      {
         grdData.DataSource = Util.HosePTGW.GetAdvOrdersByStatus(CommonSettings.PT_PENDING); //chi lay nhung lenh vua duoc nhap, co trang thai la 
         gridView1.OptionsView.ColumnAutoWidth = false;
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
         if (MessageBox.Show("Chắc chắn duyệt?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateAdvStatusByUser(long.Parse(row["ID"].ToString()), CommonSettings.PT_APPROVED, Util.LoginResult.UserName); //P->S
         }
         RefreshData();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         RefreshData();
      }

      private void btnDisapprove_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn từ chối?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         foreach (int i in rowHandles)
         {
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.UpdateAdvStatusByUser(long.Parse(row["ID"].ToString()), CommonSettings.PT_CANCELLED, Util.LoginResult.UserName); //P->S
         }
         RefreshData();
      }
   }
}