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
using DevExpress.Utils;
using InterStock;

namespace HOGW_PT_Dealer
{
    public partial class frmAdvDeals : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl;
        public frmAdvDeals()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            //Format grid and data
            StyleFormatCondition styleCondition = new StyleFormatCondition();
            // Adds the style condition to the collection
            gridView1.FormatConditions.Add(styleCondition);
            styleCondition.Column = gridView1.Columns["ADD_CANCEL_FLAG"];
            styleCondition.Value1 = "C"; //neu la C thi row do co mau khac
            //styleCondition.Value2 = 20;
            // Modifying the appearance settings
            styleCondition.Appearance.BackColor = Color.FromArgb(255, 200, 200);
            styleCondition.Appearance.Font = new Font(gridView1.Appearance.Row.Font, FontStyle.Bold);
            styleCondition.Appearance.ForeColor = Color.Black;
            styleCondition.Condition = FormatConditionEnum.Equal;
            styleCondition.ApplyToRow = true;

            //------- data ------
            grdData.DataSource = Util.HosePTGW.GetAdvOrders();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ExpandAllGroups();
        }
        public void RefreshData(string status)
        {
            //Format grid and data
            StyleFormatCondition styleCondition = new StyleFormatCondition();
            // Adds the style condition to the collection
            gridView1.FormatConditions.Add(styleCondition);
            styleCondition.Column = gridView1.Columns["ADD_CANCEL_FLAG"];
            styleCondition.Value1 = null;
            //styleCondition.Value2 = 20;
            // Modifying the appearance settings
            styleCondition.Appearance.BackColor = Color.FromArgb(255, 200, 200);
            styleCondition.Appearance.Font = new Font(gridView1.Appearance.Row.Font, FontStyle.Bold);
            styleCondition.Appearance.ForeColor = Color.Black;
            styleCondition.Condition = FormatConditionEnum.Equal;
            styleCondition.ApplyToRow = true;

            //------- data ------
            grdData.DataSource = Util.HosePTGW.GetAdvOrdersByStatus(status);
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ExpandAllGroups();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close();
            Hide();
        }

        private void frm2FirmDealApprove_Load(object sender, EventArgs e)
        {
            //--- Add status vao cboStatus -------
            List<PTStatus> lstStatus = new List<PTStatus>();
            lstStatus.Add(new PTStatus("ALL", "Tất cả")); //P
            lstStatus.Add(new PTStatus(CommonSettings.PT_PENDING, "Chờ duyệt")); //P
            lstStatus.Add(new PTStatus(CommonSettings.PT_APPROVED, "Đã duyệt, chờ gửi")); //S
            lstStatus.Add(new PTStatus(CommonSettings.PT_ENTERED, "Đã gửi vào sàn")); //E
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_WAITING, "Chờ gửi lệnh hủy"));//MXS
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCELLED, "Đã hủy tại công ty chứng khoán")); //X
            
            cboStatus.Items.Clear();
            cboStatus.DataSource = lstStatus;
            cboStatus.DisplayMember = "Description";
            cboStatus.ValueMember = "Status";
            //------------------------------------

            #region Them cot cho GRID
            
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
            gridColumn0.Caption = "DATE";
            gridColumn0.FieldName = "ENTRY_DATE";
            gridColumn0.Name = "ENTRY_DATE";
            gridColumn0.Visible = true;
            gridColumn0.VisibleIndex = 0;
            gridColumn0.Width = 80;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "ID";
            gridColumn1.FieldName = "ID";
            gridColumn1.Name = "ID";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "STATUS";
            gridColumn2.FieldName = "MESSAGE_STATUS";
            gridColumn2.Name = "MESSAGE_STATUS";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            
            gridColumn3.Caption = "SIDE";
            gridColumn3.FieldName = "SIDE";
            gridColumn3.Name = "SIDE";
            gridColumn3.AppearanceCell.BackColor = Color.FromArgb(128, 128, 255);
            gridColumn3.AppearanceCell.BackColor2 = Color.FromArgb(255, 255, 255);
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            gridColumn3.Width = 90;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "STOCK";
            gridColumn4.FieldName = "SECURITY_SYMBOL";
            gridColumn4.Name = "SECURITY_SYMBOL";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "VOLUME";
            gridColumn5.FieldName = "VOLUME";
            gridColumn5.Name = "VOLUME";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "PRICE";
            gridColumn6.FieldName = "PRICE";
            gridColumn6.Name = "PRICE";
            gridColumn6.DisplayFormat.FormatType = FormatType.Numeric;
            gridColumn6.DisplayFormat.FormatString = "##.##";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;
            gridColumn6.Width = 60;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "A/C";
            gridColumn7.FieldName = "ADD_CANCEL_FLAG";
            gridColumn7.Name = "ADD_CANCEL_FLAG";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 7;
            gridColumn7.Width = 40;
            //
            // gridColumn8
            // 
            /*[MESSAGE_STATUS]
              ,[TRADER_ID]
              ,[SECURITY_SYMBOL]
              ,[SIDE]
              ,[VOLUME]
              ,[PRICE]
              ,[TIME]
              ,[ADD_CANCEL_FLAG]
              ,[CONTACT]
              ,[RECEIVED_BY]
              ,[APPROVED_BY]
              ,[ENTRY_DATE]*/
            gridColumn8.Caption = "TRADER";
            gridColumn8.FieldName = "TRADER_ID";
            gridColumn8.Name = "TRADER_ID";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 8;
            gridColumn8.Width = 70;

            gridColumn8_.Caption = "TIME";
            gridColumn8_.FieldName = "TIME";
            gridColumn8_.Name = "TIME";
            gridColumn8_.Visible = true;
            gridColumn8_.VisibleIndex = 8;
            gridColumn8_.Width = 70;

            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "CONTACT";
            gridColumn9.FieldName = "CONTACT";
            gridColumn9.Name = "CONTACT";            
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 9;
            gridColumn9.Width = 150;
            // 
            // gridColumn10
            //            
            //-----
            gridColumn10.Caption = "RECEIVER";
            gridColumn10.FieldName = "RECEIVED_BY";
            gridColumn10.Name = "RECEIVED_BY";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            gridColumn10.Width = 80;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "APPROVER";
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
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = !chkAutoRefresh.Checked;
            timerRefreshData.Interval = (int)udAutoRefreshInterval.Value * 1000;
            timerRefreshData.Enabled = chkAutoRefresh.Checked;    
        }

        private void timerRefreshData_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 0 || cboStatus.SelectedValue.ToString() == "ALL")
                RefreshData();
            else
            {
                string status = cboStatus.SelectedValue.ToString();
                RefreshData(status);
            }
        }
    }
}