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
    public partial class frm2FirmBuyerApprove : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl;
        private CoreConnector.CoreConnectorWS coreService = new CoreConnector.CoreConnectorWS();
        private Dictionary<string, CoreConnector.CustomerBalance> dictBuyerClients = new Dictionary<string, CoreConnector.CustomerBalance>();
        private bool isLoadFromCore = false;
        public frm2FirmBuyerApprove()
        {
            InitializeComponent();
        }
        protected void FillBuyerClients()
        {
            try
            {
                //Customer data

                CoreConnector.CustomerBalance[] cusBalances = coreService.GetAllCustomersBalance();
                if (cusBalances == null || cusBalances.Length <= 0)
                {
                    MessageBox.Show("Error when getting seller customer data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<CoreConnector.CustomerBalance> lstCus = new List<CoreConnector.CustomerBalance>();
                //---- fill customer balance into dictionary -----
                foreach (CoreConnector.CustomerBalance cus in cusBalances)
                {
                    if (!dictBuyerClients.ContainsKey(cus.CustomerID))
                    {
                        dictBuyerClients.Add(cus.CustomerID, cus);
                        lstCus.Add(cus);
                    }
                }
                cboBuyerClientID.ValueMember = "CustomerID";
                cboBuyerClientID.DisplayMember = "CustomerNameViet";
                cboBuyerClientID.SelectedIndexChanged -= new EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
                cboBuyerClientID.DataSource = lstCus;
                cboBuyerClientID.SelectedIndexChanged += new EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Error when getting seller customer data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

            //tbl = Util.HosePTGW.GetBuyerOrders(CommonSettings.PT_BUYER_BEFORE_PENDING); //chi lay nhung lenh vua duoc connector day vao
            int traderID = Util.HosePTGW.GetTraderIdByUser(Util.LoginResult.UserName);
            if (traderID <= 0)
            {
                MessageBox.Show("Không lấy được mã Trader cho người dùng này");
                return;
            }
            tbl = Util.HosePTGW.GetBuyerOrdersByTraderID(CommonSettings.PT_BUYER_BEFORE_PENDING, traderID); //chi lay nhung lenh vua duoc connector day vao VA CUA TRADER dang ACTIVE
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
            gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Mã KH mua";
            gridColumn4.FieldName = "BUYER_CLIENT_ID";
            gridColumn4.Name = "BUYER_CLIENT_ID";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            gridColumn4.Width = 100;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "Công ty";
            gridColumn5.FieldName = "SELLER_CONTRA_FIRM";
            gridColumn5.Name = "SELLER_CONTRA_FIRM";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            gridColumn5.Width = 60;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Mã Trader bán";
            gridColumn6.FieldName = "SELLER_TRADER_ID";
            gridColumn6.Name = "SELLER_TRADER_ID";
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
            // 
            // gridColumn10
            // 
            gridColumn9_.Caption = "Mã Trader mua";
            gridColumn9_.FieldName = "BUYER_TRADER_ID";
            gridColumn9_.Name = "BUYER_TRADER_ID";
            gridColumn9_.Visible = true;
            gridColumn9_.VisibleIndex = 4;
            gridColumn9_.Width = 90;
            //-----
            gridColumn10.Caption = "Người nhận";
            gridColumn10.FieldName = "RECEIVED_BY";
            gridColumn10.Name = "RECEIVED_BY";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            gridColumn10.Width = 80;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "Người duyệt";
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
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn0, 
                DevExpress.Data.ColumnSortOrder.Descending), 
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn1, 
                DevExpress.Data.ColumnSortOrder.Ascending)});
            #endregion    

            //Added by DUONGPT 13/08/2010
            //cboBranch.SelectedIndex = 0;
            lblBuyerBalance.Text = "...";
            lblBuyerAvailBalance.Text = "...";

            RefreshData();
            timerRefreshData.Enabled = false;
            //FillBuyerClients();
            chkLoadFromCore.Checked = false;
            chkLoadFromCore_CheckedChanged(sender, e);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridView1.SelectAll();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //Kiem tra BuyerClient
            string BuyerClientID;
            if (chkLoadFromCore.Checked)
            {
                if (cboBuyerClientID.SelectedIndex < 0)
                {
                    MessageBox.Show("Phải chọn khách hàng mua.");
                    return;
                }
                BuyerClientID = cboBuyerClientID.SelectedValue.ToString();
            }
            else
            {
                BuyerClientID = cboBuyerClientID.Text;
            }
            if(string.IsNullOrEmpty(BuyerClientID))
            {
                MessageBox.Show("Mã khách hàng không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BuyerClientID.Length != 10)
            {
                MessageBox.Show("Mã khách hàng có độ dài khác 10 - không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Chắc chắn duyệt?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int[] rowHandles = gridView1.GetSelectedRows();
            if (rowHandles.Length <= 0) return;
            foreach (int i in rowHandles)
            {
                DataRowView row = (DataRowView)gridView1.GetRow(i);
                //if (Convert.ToInt32(row["BUYER_TRADER_ID"]) != traderID) //khong dung traderID ma seller gui cho
                    //continue;
                //Util.HosePTGW.UpdateBuyerStatus(row["DEAL_ID"], CommonSettings.PT_PENDING); //broker duyet tu RP -> P cho super duyet thanh SP
                //truoc khi update status phai them BuyerClient vao, va ko duoc approve deal cua ngay khac ngay giao dich hien tai
                if (Convert.ToDateTime(row["ENTRY_DATE"]).ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    if (MessageBox.Show("Chắc chắn duyệt lệnh cho ngày khác với ngày hiện tại?", "Cảnh báo: Lệnh có ngày khác với ngày hiện tại. HOSE sẽ từ chối lệnh này.", MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                }
                //INSERT PT ORDER VAO SBS CORE
                //Modified by DUONGPT 13/08/2010
                /*
                int iBranch = cboBranch.SelectedIndex;
                string sBranchCode="";
                string sTradeCode="";
                if(iBranch==0)
                {
                    sBranchCode = "100";
                    sTradeCode = "VICS";
                }
                else
                {

                    sBranchCode = "200";
                    sTradeCode = "VICSHCM";
                }
                 */
                string strUsername = Util.LoginResult.UserName;
                /*string sBranchCode = CommonSettings.CoreOnlineBranchCode;*/
                //MessageBox.Show(CommonSettings.CoreOnlineTradeCode);
                /*
                string orderDate = ConnectToSBSFacade.GetCurrentTranDay(sBranchCode); //"05/12/2008";//DateTime.Now.ToString("dd/MM/yyyy");
                CreateOrderResult ret2 = ConnectToSBSFacade.CreateOrder(orderDate, "B", "PT",
                    row["SECURITY_SYMBOL"].ToString(), Convert.ToDecimal(row["VOLUME"]),
                    Convert.ToDecimal(row["PRICE"]), BuyerClientID, sBranchCode,
                    CommonSettings.CoreOnlineTradeCode, CommonSettings.CoreOnlineUser, "PT 2-FIRM BUY", -300);*/
                string orderDate = ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode); //"05/12/2008";//DateTime.Now.ToString("dd/MM/yyyy");
                 CreateOrderResult ret2 = ConnectToSBSFacade.CreateOrder(orderDate, "B", "PT",
                    row["SECURITY_SYMBOL"].ToString(), Convert.ToDecimal(row["VOLUME"]),
                    Convert.ToDecimal(row["PRICE"]), BuyerClientID, Util.LoginResult.Branch.BrachCode,
                    Util.LoginResult.Branch.TradeCode, CommonSettings.CoreOnlineUser, "PT 2-FIRM BUY", -300);
                if (ret2.Transtate == (int)TranState.Success) //neu insert lenh mua thanh cong
                {

                    if (Util.HosePTGW.UpdateBuyerClient(row["DEAL_ID"], BuyerClientID) > 0)
                    {
                        Util.HosePTGW.UpdateBuyerStatusByUserWithOldStatus(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_BEFORE_PENDING, CommonSettings.PT_BUYER_APPROVED, Util.LoginResult.UserName); //broker duyet tu RP -> SP luon
                        Util.HosePTGW.UpdateBuyerCoreSeq(row["DEAL_ID"], ret2.OrderSeq);
                    }
                } else 
                {
                    MessageBox.Show(ret2.Message, "Có lỗi từ SBS Gateway khi tạo lệnh thỏa thuận cho bên mua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            RefreshData(); 
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            //Kiem tra BuyerClient
            /*
            if (cboBuyerClientID.SelectedIndex < 0)
            {
                MessageBox.Show("Must choose one client to buy this deal.");
                return;
            }
            
            int traderID = Authen.getTraderIDByUser(Util.LoginResult.UserName);
            if (traderID <= 0)
            {
                MessageBox.Show("Cannot retrieve TraderID from PT database for this username.");
                return;
            }*/
            if (MessageBox.Show("Chắc chắn từ chối?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int[] rowHandles = gridView1.GetSelectedRows();
            if (rowHandles.Length <= 0) return;
            foreach (int i in rowHandles)
            {
                DataRowView row = (DataRowView)gridView1.GetRow(i);
                //if (Convert.ToInt32(row["BUYER_TRADER_ID"]) != traderID) //khong dung traderID ma seller gui cho
                    //continue;
                //Util.HosePTGW.UpdateBuyerStatus(row["DEAL_ID"], CommonSettings.PT_BUYER_DEAL_DISAPPROVE_PENDING); //broker duyet tu RP -> C, cho super duyet -> SC
                //duyet luon, khong can supervisor
                //truoc khi update status KHONG CAN them BuyerClient vao, va ko duoc approve deal cua ngay khac ngay giao dich hien tai
                if (Convert.ToDateTime(row["ENTRY_DATE"]).ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    if (MessageBox.Show("Do you really want to disapprove deal in another trading date?", "WARNING: This deal's ENTRY DATE differs from the CURRENT DATE. You might receive REJECT from HOSE.", MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                }
                if (Util.HosePTGW.UpdateBuyerClient(row["DEAL_ID"], cboBuyerClientID.SelectedValue.ToString()) > 0)
                    Util.HosePTGW.UpdateBuyerStatusByUser(long.Parse(row["DEAL_ID"].ToString()), CommonSettings.PT_BUYER_DEAL_DISAPPROVE, Util.LoginResult.UserName); //broker duyet tu RP -> SC luon
            }
            RefreshData(); 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public int iRefreshData = 0;
        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            //btnRefresh.Enabled = !chkAutoRefresh.Checked;
            //timerRefreshData.Interval = (int)udAutoRefreshInterval.Value * 1000;
            //timerRefreshData.Enabled = chkAutoRefresh.Checked;
            btnRefresh.Enabled = !chkAutoRefresh.Checked;
            if (chkAutoRefresh.Checked==true)
            {                
                timerRefreshData.Interval = (int)udAutoRefreshInterval.Value * 1000;
                timerRefreshData.Enabled = true;
                timerRefreshData.Start();                
            } 
            else
            {
                iRefreshData = 0;
                lbRefresh.Text = "Tự động cập nhật: " + iRefreshData.ToString();
                timerRefreshData.Stop();
                timerRefreshData.Enabled = false;                

            }
        }

        private void timerRefreshData_Tick(object sender, EventArgs e)
        {
            lbRefresh.Text = "Tự động cập nhật: " + iRefreshData.ToString();            
            timerRefreshData.Interval = (int)udAutoRefreshInterval.Value * 1000;
            RefreshData();
            iRefreshData++;
        }

        private void cboBuyerClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update balance tuong ung
            string customerID = cboBuyerClientID.SelectedValue.ToString();
            CustomerBalanceInfoResult rCus = ConnectToSBSFacade.getCustomerBalanceInfo(customerID);
            if (rCus.Transtate != (int)TranState.Success)
            {
                MessageBox.Show(rCus.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblBuyerBalance.Text = string.Format("{0:###,#}", rCus.balance);
            lblBuyerAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

            /*string customerID = cboBuyerClientID.SelectedValue.ToString();
            CoreConnector.CustomerBalance cusBalance = new CoreConnector.CustomerBalance();
            if (dictBuyerClients.TryGetValue(customerID, out cusBalance))
            {
                lblBuyerBalance.Text = string.Format("{0:###,#}", cusBalance.Balance);
                lblBuyerAvailBalance.Text = string.Format("{0:###,#}", cusBalance.AvailBalance);
            }*/
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

        private void chkLoadFromCore_CheckedChanged(object sender, EventArgs e)
        {
            btnLoadClients.Enabled = chkLoadFromCore.Checked && !isLoadFromCore;
        }

        private void btnLoadClients_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có thể mất vài phút để lấy dữ liệu khách hàng từ core SBS, tiếp tục thực hiện?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                FillBuyerClients();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                isLoadFromCore = true;
                btnLoadClients.Enabled = false;
                chkLoadFromCore.Enabled = false;
            }
            catch
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void cboBuyerClientID_Leave(object sender, EventArgs e)
        {
            cboBuyerClientID.Text = cboBuyerClientID.Text.ToUpper();
            //try to locate
            int i = cboBuyerClientID.FindString(cboBuyerClientID.Text);
            if (i >= 0)
                cboBuyerClientID.SelectedIndex = i;
        }
    }
}