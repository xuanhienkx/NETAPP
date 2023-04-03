using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using InterStock;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace HOGW_PT_Dealer
{
   public partial class frm1FirmDealCancel : DevExpress.XtraEditors.XtraForm
   {
      public frm1FirmDealCancel()
      {
         InitializeComponent();
      }
      private void RefreshData()
      {
         grdData.DataSource = Util.HosePTGW.Get1FirmOrdersByStatus(CommonSettings.PT_MATCHED); //chi huy nhung lenh da khop
         gridView1.OptionsView.ColumnAutoWidth = false;
         gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
         gridView1.ExpandAllGroups();

         //enable buttons
         btnApprove.Enabled = btnDisapprove.Enabled = gridView1.RowCount > 0;
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void frm2FirmDealApprove_Load(object sender, EventArgs e)
      {
         #region Them cot cho GRID
         /*[SECURITY_SYMBOL]
            
              ,[RECEIVED_BY]
              ,[APPROVED_BY]
               1*/
         //----- Them cot vao by manual -----
         DevExpress.XtraGrid.Columns.GridColumn gridColumn0 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn2 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn3 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn4 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn5 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn6 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn7 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn8 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn8_ = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn9 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn10 = new GridColumn();
         DevExpress.XtraGrid.Columns.GridColumn gridColumn11 = new GridColumn();
         // 
         // gridColumn0
         // 
         gridColumn0.Caption = "Ngày";
         gridColumn0.FieldName = "ENTRY_DATE";
         gridColumn0.Name = "ENTRY_DATE";
         gridColumn0.Visible = true;
         gridColumn0.VisibleIndex = 0;
         gridColumn0.Width = 80;
         // 
         // gridColumn1
         // 
         gridColumn1.Caption = "Mã lệnh";
         gridColumn1.FieldName = "DEAL_ID";
         gridColumn1.Name = "DEAL_ID";
         gridColumn1.Visible = true;
         gridColumn1.VisibleIndex = 1;
         gridColumn1.Width = 70;
         // 
         // gridColumn2
         // 
         gridColumn2.Caption = "Tr.Thái";
         gridColumn2.FieldName = "MESSAGE_STATUS";
         gridColumn2.Name = "MESSAGE_STATUS";
         gridColumn2.Visible = true;
         gridColumn2.VisibleIndex = 2;
         gridColumn2.Width = 70;
         // 
         // gridColumn3
         // 
         gridColumn3.Caption = "Mã xác nhận";
         gridColumn3.FieldName = "CONFIRM_NUMBER";
         gridColumn3.Name = "CONFIRM_NUMBER";
         gridColumn3.AppearanceCell.BackColor = Color.FromArgb(128, 128, 255);
         gridColumn3.AppearanceCell.BackColor2 = Color.FromArgb(255, 255, 255);
         gridColumn3.Visible = true;
         gridColumn3.VisibleIndex = 3;
         gridColumn3.Width = 90;
         // 
         // gridColumn4
         // 
         gridColumn4.Caption = "KH bán";
         gridColumn4.FieldName = "SELLER_CLIENT_ID";
         gridColumn4.Name = "SELLER_CLIENT_ID";
         gridColumn4.Visible = true;
         gridColumn4.VisibleIndex = 4;
         gridColumn4.Width = 90;
         // 
         // gridColumn5
         // 
         gridColumn5.Caption = "KH mua";
         gridColumn5.FieldName = "BUYER_CLIENT_ID";
         gridColumn5.Name = "BUYER_CLIENT_ID";
         gridColumn5.Visible = true;
         gridColumn5.VisibleIndex = 5;
         gridColumn5.Width = 90;
         // 
         // gridColumn6
         // 
         gridColumn6.Caption = "TRADER";
         gridColumn6.FieldName = "TRADER_ID";
         gridColumn6.Name = "TRADER_ID";
         gridColumn6.Visible = true;
         gridColumn6.VisibleIndex = 6;
         gridColumn6.Width = 60;
         // 
         // gridColumn7
         // 
         gridColumn7.Caption = "Mã CK";
         gridColumn7.FieldName = "SECURITY_SYMBOL";
         gridColumn7.Name = "SECURITY_SYMBOL";
         gridColumn7.Visible = true;
         gridColumn7.VisibleIndex = 7;
         gridColumn7.Width = 70;
         //
         // gridColumn8
         // 
         gridColumn8.Caption = "KL bán";
         gridColumn8.FieldName = "SELLER_VOLUME";
         gridColumn8.Name = "SELLER_VOLUME";
         gridColumn8.Visible = true;
         gridColumn8.VisibleIndex = 8;
         gridColumn8.Width = 80;

         gridColumn8_.Caption = "KL mua";
         gridColumn8_.FieldName = "BUYER_VOLUME";
         gridColumn8_.Name = "BUYER_VOLUME";
         gridColumn8_.Visible = true;
         gridColumn8_.VisibleIndex = 8;
         gridColumn8_.Width = 80;

         // 
         // gridColumn9
         // 
         gridColumn9.Caption = "Giá";
         gridColumn9.FieldName = "PRICE";
         gridColumn9.Name = "PRICE";
         gridColumn9.DisplayFormat.FormatType = FormatType.Numeric;
         gridColumn9.DisplayFormat.FormatString = "##.##";
         gridColumn9.Visible = true;
         gridColumn9.VisibleIndex = 9;
         gridColumn9.Width = 80;
         // 
         // gridColumn10
         //            
         //-----
         gridColumn10.Caption = "Ng.nhận";
         gridColumn10.FieldName = "RECEIVED_BY";
         gridColumn10.Name = "RECEIVED_BY";
         gridColumn10.Visible = true;
         gridColumn10.VisibleIndex = 9;
         gridColumn10.Width = 80;
         // 
         // gridColumn11
         // 
         gridColumn11.Caption = "Ng.duyệt";
         gridColumn11.FieldName = "APPROVED_BY";
         gridColumn11.Name = "APPROVED_BY";
         gridColumn11.Visible = true;
         gridColumn11.VisibleIndex = 9;
         gridColumn11.Width = 80;
         // 
         // gridView2
         // 
         gridView1.Columns.Clear();
         gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                gridColumn0,
                gridColumn1,
                gridColumn2,
                gridColumn3,
                gridColumn4,
                gridColumn5,
                gridColumn6,
                gridColumn7,
                gridColumn8,
                gridColumn8_,
                gridColumn9,                
                gridColumn10,
                gridColumn11});
         //gridView1.GridControl = gridControl1;
         //gridView1.GroupCount = 1;
         //gridView1.Name = "gridView2";
         //gridView2.OptionsMenu.EnableColumnMenu = false;
         //gridView2.OptionsView.ShowGroupPanel = false;
         gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn1, 
                DevExpress.Data.ColumnSortOrder.Descending), 
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn2, 
                DevExpress.Data.ColumnSortOrder.Ascending)});
         #endregion

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
            //Util.HosePTGW.Update1FirmStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_PENDING_CANCEL, Util.LoginResult.UserName); //M -> MXP de cho kiem soat duyet -> MXS
            //Khong can cho kiem soat duyet ma duyet luon
            if (Convert.ToDateTime(row["ENTRY_DATE"]).ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
            {
               if (MessageBox.Show("Có muốn duyệt lệnh của ngày khác không? HOSE sẽ từ chối!.", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                  continue;
            }
            Util.HosePTGW.Update1FirmStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCEL_WAITING, Util.LoginResult.UserName); //M -> MXS
         }
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
            //Broker duoc phep tu choi lenh bang cach chuyen trang thai thanh X (da huy), khi do suppervisor khong nhin thay lenh nay
            //-> phai co' co* che^' kiem tra lai cac' lenh da duoc broker huy/ko duyet bang cac bao cao nga`y
            DataRowView row = (DataRowView)gridView1.GetRow(i);
            Util.HosePTGW.Update1FirmStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_CANCELLED, Util.LoginResult.UserName); //broker tu choi huy M -> X
         }
         RefreshData();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         RefreshData();
      }

      private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
      {
         //Neu la ngay giao dich hien tai thi boi mau xanh
         GridView view = sender as GridView;
         if (e.Column.FieldName == "ENTRY_DATE")
         {
            //so sanh ngay
            if ((Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, "ENTRY_DATE"))).ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
            {
               e.Appearance.BackColor = Color.LimeGreen;
               e.Appearance.BackColor2 = Color.LightYellow;
            }
            else //khong phai ngay hien tai -> mau do
            {
               e.Appearance.BackColor = Color.DarkRed;
               e.Appearance.BackColor2 = Color.White;
            }
         }
         else if (e.Column.FieldName == "SELLER_CLIENT_ID")
         {
            //mau Blue
            e.Appearance.ForeColor = Color.Red;
         }
         else if (e.Column.FieldName == "BUYER_CLIENT_ID")
         {
            //mau Blue
            e.Appearance.ForeColor = Color.Green;
         }
         else if (e.Column.FieldName == "TRADER_ID")
         {
            //mau Blue
            e.Appearance.ForeColor = Color.DodgerBlue;
         }
         else if (e.Column.FieldName == "MESSAGE_STATUS" || e.Column.FieldName == "SECURITY_SYMBOL" || e.Column.FieldName == "SELLER_VOLUME" || e.Column.FieldName == "BUYER_VOLUME" || e.Column.FieldName == "PRICE")
         {
            //mau Blue
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
         }
      }
   }
}