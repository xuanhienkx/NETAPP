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
    public partial class frm2FirmBuyerApproveSellerCancelDeal : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl;
        public frm2FirmBuyerApproveSellerCancelDeal()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            //Format grid and data
            //--- format cot confirm_number NULL
            StyleFormatCondition styleCondition = new StyleFormatCondition();
            // Adds the style condition to the collection
            gridView1.FormatConditions.Add(styleCondition);
            styleCondition.Column = gridView1.Columns["CONFIRM_NUMBER"];
            styleCondition.Value1 = null;
            //styleCondition.Value2 = 20;
            // Modifying the appearance settings            
            styleCondition.Appearance.BackColor = Color.DarkRed;
            styleCondition.Appearance.BackColor2 = Color.White;
            styleCondition.Appearance.Font = new Font(gridView1.Appearance.Row.Font, FontStyle.Italic);
            styleCondition.Appearance.ForeColor = Color.Black;
            styleCondition.Condition = FormatConditionEnum.Equal;
            styleCondition.ApplyToRow = false;

            //--- format cot confirm_number <> NULL
            StyleFormatCondition styleCondition1 = new StyleFormatCondition();
            // Adds the style condition to the collection
            gridView1.FormatConditions.Add(styleCondition1);
            styleCondition1.Column = gridView1.Columns["CONFIRM_NUMBER"];
            styleCondition1.Value1 = null;
            //styleCondition.Value2 = 20;
            // Modifying the appearance settings
            styleCondition1.Appearance.BackColor = Color.LimeGreen;
            styleCondition1.Appearance.BackColor2 = Color.LightYellow;
            styleCondition1.Appearance.Font = new Font(gridView1.Appearance.Row.Font, FontStyle.Bold);
            styleCondition1.Appearance.ForeColor = Color.Black;
            styleCondition1.Condition = FormatConditionEnum.NotEqual;
            styleCondition1.ApplyToRow = false;

            int traderID = Util.HosePTGW.GetTraderIdByUser(Util.LoginResult.UserName);
            if (traderID <= 0)
            {
                MessageBox.Show("Không lấy được mã Trader cho người dùng này.");
                return;
            }
            
            tbl = Util.HosePTGW.GetBuyerOrdersByTraderID(CommonSettings.PT_BUYER_CANCEL_WAITING, traderID); //nhung lenh huy tu seller cho buyer broker duyet = MX
            if (tbl == null) return;
            grdData.DataSource = tbl;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView1.ExpandAllGroups();

            //enable buttons
            if (tbl.Rows.Count > 0)
            {
                btnApprove.Enabled = true;
                btnDisapprove.Enabled = true;
            }
            else
            {
                btnApprove.Enabled = false;
                btnDisapprove.Enabled = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close();
            Hide();
        }

        private void frm2FirmDealApprove_Load(object sender, EventArgs e)
        {
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
            DevExpress.XtraGrid.Columns.GridColumn gridColumn9 = new GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn9_ = new GridColumn();
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
            gridColumn1.Caption = "DEAL";
            gridColumn1.FieldName = "DEAL_ID";
            gridColumn1.Name = "DEAL_ID";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            gridColumn1.Width = 60;
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
            gridColumn3.Caption = "CONFIRM_NO";
            gridColumn3.FieldName = "CONFIRM_NUMBER";
            gridColumn3.Name = "CONFIRM_NUMBER";
            gridColumn3.AppearanceCell.BackColor = Color.FromArgb(128, 128, 255);
            gridColumn3.AppearanceCell.BackColor2 = Color.FromArgb(255, 255, 255);
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "BUYER_CLIENT";
            gridColumn4.FieldName = "BUYER_CLIENT_ID";
            gridColumn4.Name = "BUYER_CLIENT_ID";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "SELLER";
            gridColumn5.FieldName = "SELLER_CONTRA_FIRM";
            gridColumn5.Name = "SELLER_CONTRA_FIRM";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            gridColumn5.Width = 60;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "SELLER_TRADER";
            gridColumn6.FieldName = "SELLER_TRADER_ID";
            gridColumn6.Name = "SELLER_TRADER_ID";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;
            gridColumn6.Width = 100;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "STOCK";
            gridColumn7.FieldName = "SECURITY_SYMBOL";
            gridColumn7.Name = "SECURITY_SYMBOL";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 7;
            gridColumn7.Width = 70;
            // 
            // gridColumn8
            // 
            gridColumn8.Caption = "VOLUME";
            gridColumn8.FieldName = "VOLUME";
            gridColumn8.Name = "VOLUME";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 8;
            gridColumn8.Width = 60;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "PRICE";
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
            gridColumn9_.Caption = "BUYER_TRADER";
            gridColumn9_.FieldName = "BUYER_TRADER_ID";
            gridColumn9_.Name = "BUYER_TRADER_ID";
            gridColumn9_.Visible = true;
            gridColumn9_.VisibleIndex = 4;
            gridColumn9_.Width = 90;
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
                gridColumn9_,
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
            timerRefreshData.Enabled = false;
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
                //Util.HosePTGW.ptUpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_APPROVE_PENDING, Util.LoginResult.UserName); //broker duyet tu MX -> MXP
                //Khong phai cho super duyet nua
                Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_APPROVE, Util.LoginResult.UserName); //duyet tu MX -> MXS
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
                DataRowView row = (DataRowView)gridView1.GetRow(i);
                //Util.HosePTGW.ptUpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_DISAPPROVE_PENDING, Util.LoginResult.UserName); //broker tu choi huy MX -> MXCP
                //khong phai super duyet nua
                Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_CANCEL_DISAPPROVE, Util.LoginResult.UserName); //tu choi huy MX -> MXCS
            }
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
            else if (e.Column.FieldName == "SELLER_CONTRA_FIRM" || e.Column.FieldName == "SELLER_TRADER_ID")
            {
                //mau Blue
                e.Appearance.ForeColor = Color.DodgerBlue;
            }
            else if (e.Column.FieldName == "MESSAGE_STATUS" || e.Column.FieldName == "SECURITY_SYMBOL" || e.Column.FieldName == "VOLUME" || e.Column.FieldName == "PRICE")
            {
                //mau Blue
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }
    }
}