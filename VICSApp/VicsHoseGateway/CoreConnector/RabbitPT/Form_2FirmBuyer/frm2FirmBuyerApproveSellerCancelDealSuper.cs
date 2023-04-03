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
   public partial class frm2FirmBuyerApproveSellerCancelDealSuper : DevExpress.XtraEditors.XtraForm
   {
      public frm2FirmBuyerApproveSellerCancelDealSuper()
      {
         InitializeComponent();
      }
      private void RefreshData(string status)
      {
         grdData.DataSource = Util.HosePTGW.GetBuyerOrdersByStatus(status); //nhung lenh huy tu seller cho buyer broker duyet = MX
         gridView1.OptionsView.ColumnAutoWidth = false;
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
         RefreshData(CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING); //duyet chap nhan la default
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
         if (cboApproveType.SelectedIndex == 0) //duyet de chap nhan lenh huy
         {
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_APPROVE, Util.LoginResult.UserName); //broker duyet tu MXP -> MXS
            }
            RefreshData(CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING);
         }
         else //duyet de khong chap nhan lenh huy
         {
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_DISAPPROVE, Util.LoginResult.UserName); ////broker duyet tu MXCP -> MXCS
            }
            RefreshData(CommonSettings.PT_BUYER_CANCEL_DISAPPROVE_PENDING);
         }
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         if (cboApproveType.SelectedIndex == 0) //duyet de chap nhan lenh huy
            RefreshData(CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING);
         else
            RefreshData(CommonSettings.PT_BUYER_CANCEL_DISAPPROVE_PENDING);
      }

      private void btnDisapprove_Click(object sender, EventArgs e)
      {
         //Kiem soat khong duyet nhung deal da duoc Broker duyet
         //Cho phep SuperVisor co the duyet nguoc so voi Broker duyet (hoi truoc khi duyet)
         //Neu khong thi chuyen ve trang thai PT_BUYER_CANCEL_WAITING (MX) de broker duyet lai            
         int[] rowHandles = gridView1.GetSelectedRows();
         if (rowHandles.Length <= 0) return;
         string SupervisorStatus;
         if (cboApproveType.SelectedIndex == 0) //khong duyet chap nhan lenh huy
         {
            if (MessageBox.Show("Từ chối hay để broker duyệt lại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
               SupervisorStatus = CommonSettings.PT_BUYER_CANCEL_DISAPPROVE;//MXCS
            else
               SupervisorStatus = CommonSettings.PT_BUYER_CANCEL_WAITING;//MX
            //Duyet nguoc voi broker (MXP -> MXCS) hay de broker duyet lai (chuyen ve MX)
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), SupervisorStatus, Util.LoginResult.UserName);  //broker duyet tu MXP -> MXS
            }
            RefreshData(CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING);
         }
         else //Khong duyet khong chap nhan lenh huy
         {
            if (MessageBox.Show("Từ chối hay để broker duyệt lại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
               SupervisorStatus = CommonSettings.PT_BUYER_CANCEL_APPROVE;//MXS
            else
               SupervisorStatus = CommonSettings.PT_BUYER_CANCEL_WAITING;//MX
            //Duyet nguoc voi broker (MXCP -> MXS) hay de broker duyet lai (chuyen ve MX)
            foreach (int i in rowHandles)
            {
               DataRowView row = (DataRowView)gridView1.GetRow(i);
               Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), SupervisorStatus, Util.LoginResult.UserName); //broker duyet tu MXCP -> MXCS
            }
            RefreshData(CommonSettings.PT_BUYER_CANCEL_DISAPPROVE_PENDING);
         }
      }

      private void cboApproveType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cboApproveType.SelectedIndex == 0) //approve
            RefreshData(CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING);
         else //disapprove seller deals
            RefreshData(CommonSettings.PT_BUYER_CANCEL_DISAPPROVE_PENDING);
      }
   }
}