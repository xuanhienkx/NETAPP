using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Threading;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using InterStock;
using HOGW_PT_Dealer.HosePTConnector;

namespace HOGW_PT_Dealer
{
    public partial class frmAdvAnnounce : DevExpress.XtraEditors.XtraForm
    {
        public frmAdvAnnounce()
        {
            InitializeComponent();
        }
        #region Threads
        #endregion //Threads

        private void tabMessageReceived_Enter(object sender, EventArgs e)
        {
            //
        }
        //private Thread threadAdvReceived = null;
        private void checkEditCheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit checkEdit = sender as DevExpress.XtraEditors.CheckEdit;
            int checkEditIndex = checkEdit.TabIndex;

            gridView2.BeginSort();

            if (checkEdit.Checked)
                gridView2.Columns[checkEditIndex].GroupIndex = gridView2.SortInfo.GroupCount;
            else
            {
                gridView2.Columns[checkEditIndex].GroupIndex = -1;
                gridView2.Columns[checkEditIndex].VisibleIndex = checkEditIndex;
            }

            gridView2.EndSort();
            gridView2.ExpandAllGroups();
            //</panel1>

            foreach (Control ctrl in panel1.Controls)
            {
                checkEdit = ctrl as DevExpress.XtraEditors.CheckEdit;

                if (gridView2.SortInfo.GroupCount >= panel1.Controls.Count - 1)
                {
                    if (!checkEdit.Checked) checkEdit.Enabled = false;
                }
                else
                {
                    if (!checkEdit.Enabled) checkEdit.Enabled = true;
                }
            }
            //<panel1>
        }
        private void InitGroupedColumns()
        {
            for (int i = gridView2.Columns.Count - 1; i >= 0; i--)
            {
                DevExpress.XtraEditors.CheckEdit checkEdit =
                    new DevExpress.XtraEditors.CheckEdit();
                checkEdit.Text = gridView2.Columns[i].Caption;
                checkEdit.Checked = gridView2.Columns[i].GroupIndex != -1;
                checkEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
                checkEdit.Dock = System.Windows.Forms.DockStyle.Top;
                checkEdit.Properties.FullFocusRect = true;
                checkEdit.TabIndex = gridView2.Columns[i].AbsoluteIndex;
                checkEdit.CheckedChanged += new EventHandler(checkEditCheckedChanged);
                panel1.Controls.Add(checkEdit);
            }
        }
        private void PTLiveBoard_Load(object sender, EventArgs e)
        {
            #region ListView
            //lvAdvBuyReceived
            ColumnHeader colFrim = new ColumnHeader();
            colFrim.Text = "C.ty";
            colFrim.Width = 50;
            lvAdvBuyReceived.Columns.Add(colFrim);

            ColumnHeader colTrader = new ColumnHeader();
            colTrader.Text = "Trader";
            colTrader.Width = 80;
            lvAdvBuyReceived.Columns.Add(colTrader);

            ColumnHeader colSecurity = new ColumnHeader();
            colSecurity.Text = "CK";
            colSecurity.Width = 100;
            lvAdvBuyReceived.Columns.Add(colSecurity);

            ColumnHeader colVol = new ColumnHeader();
            colVol.Text = "KLượng";
            colVol.Width = 100;
            lvAdvBuyReceived.Columns.Add(colVol);

            ColumnHeader colPrice = new ColumnHeader();
            colPrice.Text = "Giá";
            colPrice.Width = 100;
            lvAdvBuyReceived.Columns.Add(colPrice);

            ColumnHeader colSide = new ColumnHeader();
            colSide.Text = "Bên";
            colSide.Width = 50;
            lvAdvBuyReceived.Columns.Add(colSide);

            ColumnHeader colTime = new ColumnHeader();
            colTime.Text = "Giờ";
            colTime.Width = 70;
            lvAdvBuyReceived.Columns.Add(colTime);

            ColumnHeader colContact = new ColumnHeader();
            colContact.Text = "Liên hệ";
            colContact.Width = 150;
            lvAdvBuyReceived.Columns.Add(colContact);

            //lvAdvSellReceived
            ColumnHeader colFrim2 = new ColumnHeader();
            colFrim2.Text = "C.Ty";
            colFrim2.Width = 50;
            lvAdvSellReceived.Columns.Add(colFrim2);

            ColumnHeader colTrader2 = new ColumnHeader();
            colTrader2.Text = "Trader";
            colTrader2.Width = 80;
            lvAdvSellReceived.Columns.Add(colTrader2);

            ColumnHeader colSecurity2 = new ColumnHeader();
            colSecurity2.Text = "CK";
            colSecurity2.Width = 100;
            lvAdvSellReceived.Columns.Add(colSecurity2);

            ColumnHeader colVol2 = new ColumnHeader();
            colVol2.Text = "KLượng";
            colVol2.Width = 100;
            lvAdvSellReceived.Columns.Add(colVol2);

            ColumnHeader colPrice2 = new ColumnHeader();
            colPrice2.Text = "Giá";
            colPrice2.Width = 100;
            lvAdvSellReceived.Columns.Add(colPrice2);

            ColumnHeader colSide2 = new ColumnHeader();
            colSide2.Text = "Bên";
            colSide2.Width = 50;
            lvAdvSellReceived.Columns.Add(colSide2);

            ColumnHeader colTime2 = new ColumnHeader();
            colTime2.Text = "Giờ";
            colTime2.Width = 70;
            lvAdvSellReceived.Columns.Add(colTime2);

            ColumnHeader colContact2 = new ColumnHeader();
            colContact2.Text = "Liên hệ";
            colContact2.Width = 150;
            lvAdvSellReceived.Columns.Add(colContact2);
            #endregion ListView

            //----
            //threadAdvReceived = new Thread(new ThreadStart(ProcessReceiveAdv));
            //threadAdvReceived.Start();
            timerAdvReceived.Enabled = true;            

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
            gridColumn1.Caption = "Chứng khoán";
            gridColumn1.FieldName = "SECURITY_SYMBOL";
            gridColumn1.Name = "SECURITY_SYMBOL";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "C.Ty";
            gridColumn2.FieldName = "FIRM";
            gridColumn2.Name = "FIRM";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            gridColumn2.Width = 69;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "TRADER";
            gridColumn3.FieldName = "TRADER_ID";
            gridColumn3.Name = "TRADER_ID";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            gridColumn3.Width = 69;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Bên";
            gridColumn4.FieldName = "SIDE";
            gridColumn4.Name = "SIDE";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "KLượng";
            gridColumn5.FieldName = "VOLUME";
            gridColumn5.Name = "VOLUME";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Giá";
            gridColumn6.FieldName = "PRICE";
            gridColumn6.Name = "PRICE";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;
            gridColumn6.Width = 92;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "Giờ";
            gridColumn7.FieldName = "TIME";
            gridColumn7.Name = "TIME";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 7;
            gridColumn7.Width = 60;
            // 
            // gridColumn8
            // 
            gridColumn8.Caption = "Liên hệ";
            gridColumn8.FieldName = "CONTACT";
            gridColumn8.Name = "CONTACT";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 8;
            gridColumn8.Width = 150;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "Thêm/hủy";
            gridColumn9.FieldName = "ADD_CANCEL_FLAG";
            gridColumn9.Name = "ADD_CANCEL_FLAG";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 9;
            gridColumn9.Width = 80;
            // 
            // gridView2
            // 
            //gridView2.Columns.Clear();
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                gridColumn0,
                gridColumn1,
                gridColumn2,
                gridColumn3,
                gridColumn4,
                gridColumn5,
                gridColumn6,
                gridColumn7,
                gridColumn8,
                gridColumn9});
            gridView2.GridControl = gridControl1;
            gridView2.GroupCount = 1;
            gridView2.Name = "gridView2";
            //gridView2.OptionsMenu.EnableColumnMenu = false;
            //gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn0, 
                DevExpress.Data.ColumnSortOrder.Descending), 
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn1, 
                DevExpress.Data.ColumnSortOrder.Ascending)});
            #endregion

            //------ XtraGrid ------
            //gridControl1.ForceInitialize();
            RefreshData();
            InitGroupedColumns();
            gridView2.ExpandAllGroups();
            /*
            ColumnView colView = grdAdv.MainView as ColumnView;
            colView.Columns.Clear();            
            string[] fieldNames = { "security_symbol", "firm", "trader_id", "side", "volume", "price", "time", "contact", "add_cancel_flag" };
            string[] displayNames = { "Stock Code", "Firm", "Trader ID", "Side", "Volume", "Price", "Time", "Contact", "Add Or Cancel" };
            for (int i = 0; i < fieldNames.GetLength(0); i++)
            {
                GridColumn col = colView.Columns.AddField(fieldNames[i]);
                col.VisibleIndex = i;
            }*/            
        }
        private void RefreshData()
        {
            //Format grid and data
            StyleFormatCondition styleConditionSideS = new StyleFormatCondition();
            // Adds the style condition to the collection
            gridView2.FormatConditions.Add(styleConditionSideS);
            styleConditionSideS.Column = gridView2.Columns["SIDE"];
            styleConditionSideS.Value1 = "S";
            styleConditionSideS.Appearance.BackColor = Color.FromArgb(255, 200, 200); //do nhat
            styleConditionSideS.Appearance.Font = new Font(gridView2.Appearance.Row.Font, FontStyle.Bold);
            styleConditionSideS.Appearance.ForeColor = Color.Black;
            styleConditionSideS.Condition = FormatConditionEnum.Equal;
            styleConditionSideS.ApplyToRow = true;

            StyleFormatCondition styleConditionSideB = new StyleFormatCondition();
            gridView2.FormatConditions.Add(styleConditionSideB);
            styleConditionSideB.Column = gridView2.Columns["SIDE"];
            styleConditionSideB.Value1 = "B";
            styleConditionSideB.Appearance.BackColor = Color.FromArgb(200, 255, 200); //xanh green nhat
            styleConditionSideB.Appearance.Font = new Font(gridView2.Appearance.Row.Font, FontStyle.Bold);
            styleConditionSideB.Appearance.ForeColor = Color.Black;
            styleConditionSideB.Condition = FormatConditionEnum.Equal;
            styleConditionSideB.ApplyToRow = true;

            gridControl1.DataSource = Util.HosePTGW.GetAdvAnnounces(); //lay nhung quang cao vua nhan duoc trong PT_SBS
            gridView2.ExpandAllGroups();
        }
        private void PTLiveBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (threadAdvReceived != null)
                //threadAdvReceived.Abort();
        }

        private void timerAdvReceived_Tick(object sender, EventArgs e)
        {
            try
            {                
                List<ADVERTISEMENT_ANNOUCEMENT> anns = new List<ADVERTISEMENT_ANNOUCEMENT>(Util.HosePTGW.GetAdvAnnouncesByStatus(CommonSettings.GW_WRITTEN_TO_FILE)); //lay nhung message vua nhan ve tu AA
                //Neu listview > 100 items thi xoa chi con 100
                while (lvAdvBuyReceived.Items.Count > 100)
                {
                    lvAdvBuyReceived.Items.RemoveAt(100);
                }
                while (lvAdvSellReceived.Items.Count > 100)
                {
                    lvAdvSellReceived.Items.RemoveAt(100);
                }
                foreach (ADVERTISEMENT_ANNOUCEMENT a in anns)
                {
                    ListViewItem item = new ListViewItem(a.FIRM.ToString());
                    item.SubItems.Add(a.TRADER_ID.ToString());
                    item.SubItems.Add(a.SECURITY_SYMBOL.ToString());
                    item.SubItems.Add(a.VOLUME.ToString());
                    item.SubItems.Add(a.PRICE.ToString());
                    item.SubItems.Add(a.SIDE);
                    item.SubItems.Add(a.TIME.ToString());
                    item.SubItems.Add(a.CONTACT.ToString());
                    if(a.SIDE == "B")
                        lvAdvBuyReceived.Items.Insert(0, item);
                    else
                        lvAdvSellReceived.Items.Insert(0, item);
                    //update trang thai trong bang [PT_ADVERTISEMENT_ANNOUCEMENT]
                    Util.HosePTGW.UpdateAdvAnnouncementStatus(a.ID, CommonSettings.GW_READ);
                }                
            }
            catch (Exception ex)
            {
                frmMainPT.writeLog(ex.Message);
            }
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
    }
}