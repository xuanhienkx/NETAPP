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
    public partial class frmAdvCancel : DevExpress.XtraEditors.XtraForm
    {
        public frmAdvCancel()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            grdData.DataSource = Util.HosePTGW.GetAdvOrdersByStatus(CommonSettings.PT_ENTERED); //chi huy nhung lenh quang cao da gui vao san
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

        private void btnSendCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int[] rowHandles = gridView1.GetSelectedRows();
            if (rowHandles.Length <= 0) return;
            foreach (int i in rowHandles)
            {
                DataRowView row = (DataRowView)gridView1.GetRow(i);
                //Util.HosePTGW.Update1FirmStatusByUser(row["DEAL_ID"], CommonSettings.PT_PENDING_CANCEL, Util.LoginResult.UserName); //M -> MXP de cho kiem soat duyet -> MXS
                //Chuyen sang MXS de cho CoreConnector gui di va update trang thai thanh X
                //Dong thoi update AddAndCancel cua ADV nay thanh C
               Util.HosePTGW.UpdateAdvStatusByUser(long.Parse(row["ID"].ToString()), CommonSettings.PT_CANCEL_WAITING, Util.LoginResult.UserName); //E -> MXS
               Util.HosePTGW.UpdateAdvACFlag(long.Parse(row["ID"].ToString()), "C"); //update add_cancel_flag tu A -> C
            }
            RefreshData(); 
        }
      
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}