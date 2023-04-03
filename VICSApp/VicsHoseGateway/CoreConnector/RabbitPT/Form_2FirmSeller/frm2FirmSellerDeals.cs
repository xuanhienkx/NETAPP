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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using InterStock;

namespace HOGW_PT_Dealer
{
    public partial class frm2FirmSellerDeals : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl;
        public frm2FirmSellerDeals()
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

            //------- data ------
            grdData.DataSource = Util.HosePTGW.GetSellerOrders(); 
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView1.ExpandAllGroups();
        }
        public void RefreshData(string status)
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

            //------- data ------
            grdData.DataSource = Util.HosePTGW.GetSellerOrdersByStatus(status);
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
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
            lstStatus.Add(new PTStatus(CommonSettings.PT_DISAPPROVED_BY_HOSE, "Sàn không chấp nhận")); //NS
            lstStatus.Add(new PTStatus(CommonSettings.PT_DISAPPROVED_BY_CONTRA, "Công ty mua không chấp nhận")); //NC
            lstStatus.Add(new PTStatus(CommonSettings.PT_MATCHED, "Đã khớp")); //M
            lstStatus.Add(new PTStatus(CommonSettings.PT_PENDING_CANCEL, "Chờ duyệt hủy")); //MXP
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_WAITING, "Đã được duyệt hủy"));//MXS
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_ENTERED, "Lệnh hủy đã được gửi vào sàn"));//MXE
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_CONFIRMED, "Đã hủy thông qua sàn")); //MXD
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCELLED, "Đã hủy tại công ty chứng khoán")); //X
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_UNCONFIRMED_BY_HOSE, "Sàn không chấp nhận lệnh hủy")); //MS
            lstStatus.Add(new PTStatus(CommonSettings.PT_CANCEL_UNCONFIRMED_BY_CONTRA, "Công ty mua không chấp nhận lệnh hủy")); //MC

            cboStatus.SelectedIndexChanged -= new EventHandler(cboStatus_SelectedIndexChanged);
            cboStatus.Items.Clear();
            cboStatus.DataSource = lstStatus;
            cboStatus.DisplayMember = "Description";
            cboStatus.ValueMember = "Status";
            cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
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
            gridColumn2.Caption = "Trạng thái";
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
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            gridColumn3.Width = 90;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Mã KH bán";
            gridColumn4.FieldName = "SELLER_CLIENT_ID";
            gridColumn4.Name = "SELLER_CLIENT_ID";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "C.Ty mua";
            gridColumn5.FieldName = "BUYER_FIRM";
            gridColumn5.Name = "BUYER_FIRM";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            gridColumn5.Width = 60;
            gridColumn5.GroupIndex = 0;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Trader mua";
            gridColumn6.FieldName = "BUYER_TRADER_ID";
            gridColumn6.Name = "BUYER_TRADER_ID";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;
            gridColumn6.Width = 100;
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
            gridColumn8.Caption = "K.Lượng";
            gridColumn8.FieldName = "VOLUME";
            gridColumn8.Name = "VOLUME";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 8;
            gridColumn8.Width = 60;
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
            
            //-----
            gridColumn10.Caption = "Người nhận";
            gridColumn10.FieldName = "RECEIVED_BY";
            gridColumn10.Name = "RECEIVED_BY";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 11;
            gridColumn10.Width = 80;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "Người duyệt";
            gridColumn11.FieldName = "APPROVED_BY";
            gridColumn11.Name = "APPROVED_BY";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 12;
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
            gridView1.GroupCount = 1;
            //gridView1.Name = "gridView2";
            //gridView2.OptionsMenu.EnableColumnMenu = false;
            //gridView2.OptionsView.ShowGroupPanel = false;
            
            gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn5, 
                DevExpress.Data.ColumnSortOrder.Ascending), 
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
            else if (e.Column.FieldName == "BUYER_FIRM")
            {
                //mau Blue
                e.Appearance.ForeColor = Color.Blue;
            }
            else if (e.Column.FieldName == "BUYER_TRADER_ID")
            {
                //mau Blue
                e.Appearance.ForeColor = Color.Blue;
            }
            else if (e.Column.FieldName == "SELLER_CLIENT_ID" || e.Column.FieldName == "MESSAGE_STATUS" || e.Column.FieldName == "SECURITY_SYMBOL" || e.Column.FieldName == "VOLUME" || e.Column.FieldName == "PRICE")
            {
                //mau Blue
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            } 
        }
    }
}