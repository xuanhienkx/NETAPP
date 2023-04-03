using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OrderChecker;
using InterStock;
using OrderChecker.Business;

namespace HOGW_PT_Dealer
{
    public partial class frmMakeNewAdv : Form
    {
        public frmMakeNewAdv()
        {
            InitializeComponent();
            //db = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            //validation = new HOGWValidation(db);
        }
        private Dictionary<string, HoseConnector.GWStockPrice> dictStockPrice = new Dictionary<string, HoseConnector.GWStockPrice>();
        private Dictionary<string, HoseConnector.GWStockData> dictStockData = new Dictionary<string, HoseConnector.GWStockData>();
        private List<HoseConnector.GWStockData> lstStockData = new List<HoseConnector.GWStockData>();
        private bool isHalted = false;
        private bool isSuspended = false;
        private bool isDelisted = false;
        private bool isSplitted = false;
        //private HOGWValidation validation = null;
        //private Database db;
        private HoseConnector.GWConnectorWS gwService = new HOGW_PT_Dealer.HoseConnector.GWConnectorWS();
        protected void FillAllSecurities()
        {
            //Get securities
            try
            {
                if (CommonSettings.CheckPriceFromCore)
                {
                    //do nothing
                }
                else
                {
                    if (lstStockData.Count <= 0) return;
                    cboSecurities.DisplayMember = "StockName";
                    cboSecurities.ValueMember = "StockCode";
                    cboSecurities.DataSource = lstStockData;
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về chứng khoán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        protected void FillStockInfoInDictionary()
        {
            try
            {
                if (CommonSettings.CheckPriceFromCore)
                {
                    //do nothing
                }
                else
                {
                    HoseConnector.GWStockData[] stockData = gwService.getStockCodes();
                    if (stockData == null || stockData.Length <= 0)
                    {
                        MessageBox.Show("Lỗi khi lấy thông tin về giá chứng khoán từ HOGW", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (HoseConnector.GWStockData row in stockData)
                    {
                        if(!dictStockData.ContainsKey(row.StockCode))
                        {
                            dictStockData.Add(row.StockCode, row);
                            lstStockData.Add(row);                            
                        }                        
                    }
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về giá chứng khoán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        protected void FillStockPricesInDictionary()
        {
            try
            {
                if (CommonSettings.CheckPriceFromCore)
                {
                    //do nothing
                }
                else
                {
                    HoseConnector.GWStockPrice[] stockPrices = gwService.getStockPrices();
                    if (stockPrices == null || stockPrices.Length <= 0)
                    {
                        MessageBox.Show("Lỗi khi lấy thông tin về giá chứng khoán từ HOGW", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (HoseConnector.GWStockPrice row in stockPrices)
                    {
                        if(!dictStockPrice.ContainsKey(row.StockCode))
                        {
                            dictStockPrice.Add(row.StockCode, row);                            
                        }
                        
                    }
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về giá chứng khoán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
                
        private void loadTraders()
        {
            cboTraderID.DisplayMember = "TRADER_NAME";
            cboTraderID.ValueMember = "TRADER_ID";
            cboTraderID.DataSource = Util.HosePTGW.GetTraders(CommonSettings.FirmID);
        }
        private void frmMakeNewPTDeal_Load(object sender, EventArgs e)
        {
            lbTotalValue.Text = "...";
            lblDelist.Text = "";
            lblSuspension.Text = "";
            lblSplit.Text = "";
            lblHalt.Text = "";

            //txtVolume.Text = "20000";
            //----
            ttipStatus.Text = "";// "Press F1 to reset form, Ctrl + I to [un]check 'Ignore Halt' control";
            lblBasicPrice.Text = "";
            lblCeilingPrice.Text = "";
            lblFloorPrice.Text = "";
            lblTraderID.Text = "";

            cboAddOrCancel.Items.Clear();
            cboAddOrCancel.Items.Add("A");
            cboAddOrCancel.Items.Add("C");
            cboAddOrCancel.SelectedIndex = 0;

            cboSide.Items.Clear();
            cboSide.Items.Add("S");
            cboSide.Items.Add("B");
            cboSide.SelectedIndex = 0;
            //------
            FillStockInfoInDictionary();
            FillStockPricesInDictionary();            
            FillAllSecurities();            
            loadTraders();
            
            //if (db != null)
            //    ttipHOGW.Text = "HOGW database connected!";
            //else
            //    ttipHOGW.Text = "HOGW database NOT connected!";
            //---- fill board type ---
            List<PTBoardType> lstBoardType = new List<PTBoardType>();
            lstBoardType.Add(new PTBoardType("Even Lot", CommonSettings.BoardPT));
            lstBoardType.Add(new PTBoardType("Odd Lot", CommonSettings.BoardOdd));
            cboBoardType.DataSource = lstBoardType;
            cboBoardType.ValueMember = "BoardType";
            cboBoardType.DisplayMember = "BoardName";
            cboBoardType.SelectedIndex = 0;
            
            cboSecurities.Focus();
        }
        
        void BtnEnterClick(object sender, EventArgs e)
        {
            if (cboSecurities.SelectedIndex < 0) return;
            if (string.IsNullOrEmpty(cboSecurities.SelectedValue.ToString()))
            {
                MessageBox.Show("Mã chứng khoán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Giá không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double price = 0;
            if (!double.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Sai định dạng giá!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (price >= 1000)
            {
                MessageBox.Show("Giá quá cao! Giá phải nhỏ hơn 1 tỷ", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTraderID.SelectedValue == null)
            {
                MessageBox.Show("Trader bên bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtVolume.Text))
            {
                MessageBox.Show("Khối lượng không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double vol = 0;
            if (!double.TryParse(txtVolume.Text, out vol))
            {
                MessageBox.Show("Sai định dạng khối lượng!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Chắc chắn nhập?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                string orderStatus,s;
                if (!CommonSettings.HasApprove) //khong can duyet lenh
                    orderStatus = CommonSettings.PT_APPROVED;
                else
                    orderStatus = CommonSettings.PT_PENDING;
                //Lay thong tin ve thi truong tu HOGW de validate
                string marketStatus = gwService.GetMarketStatusHOSE();
                //validation order
                HoseConnector.HOGWValidOutput output = gwService.ValidateOrder("", cboSecurities.SelectedValue.ToString().Trim(), //khong kiem tra ClientID voi lenh Adv
                    "PT", marketStatus, "N", cboSide.Text, Convert.ToInt32(cboTraderID.SelectedValue),
                    Convert.ToDecimal(txtPrice.Text), Convert.ToDouble(txtVolume.Text),
                    Convert.ToDouble(txtVolume.Text), PTOrderType.ORDER_TYPE_ADVERTISEMENT, "");
                if (!output.IsOK && (output.ErrCode == 12112 || output.ErrCode == 1211))
                {
                    s = "[VALID_ERROR - 1E] Stock=" +
                                cboSecurities.SelectedValue.ToString().Trim() + ", Side=" +
                                cboSide.Text + ", Vol=" + txtVolume.Text + ", Price=" + txtPrice.Text +   
                                ", Trader=" + cboTraderID.SelectedValue + ", MktSts=" + marketStatus;  
                    s += " [ErrCode: " + output.ErrCode.ToString() + " - " + output.ErrDesc + "]";
                    frmMainPT.writeLog(s);
                    MessageBox.Show(s, "VALIDATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int r = Util.HosePTGW.PTInsertAdv(orderStatus, "1E", CommonSettings.FirmID, cboTraderID.SelectedValue,
                    cboSecurities.SelectedValue.ToString(), cboSide.Text, Convert.ToDecimal(txtVolume.Text), Convert.ToDecimal(txtPrice.Text) //* CommonSettings.PriceMultipleOperandPT
                    ,cboBoardType.SelectedValue, Convert.ToDecimal(DateTime.Now.ToString("hhmmss")), cboAddOrCancel.Text, CommonSettings.ContactAddress, 
                    Util.LoginResult.UserName, "");
                if (r > 0)
                {
                    ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Successfully insert Advertisement!";
                    //Log
                    s = "[OK] ADV-1E: AdOrCan=" + cboAddOrCancel.Text + ", Trader=" + cboTraderID.SelectedValue +
                        ", Side=" + cboSide.Text + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                        txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                    frmMainPT.writeLog(s);
                    MessageBox.Show(s, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Inserting Advertisement fails!";
                    //Log
                    s = "[FAIL] ADV-1E: AdOrCan=" + cboAddOrCancel.Text + ", Trader=" + cboTraderID.SelectedValue +
                        ", Side=" + cboSide.Text + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                        txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                    frmMainPT.writeLog(s);
                    MessageBox.Show(s, "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ttipStatus.Text = ex.Message;
            }
        }
        
        void BtnCloseClick(object sender, EventArgs e)
        {
        	Close();
        }

        private void cboSecurities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSecurities.SelectedIndex < 0) return;
            string stockCode = cboSecurities.SelectedValue.ToString();
            HoseConnector.GWStockPrice stockPrice = new HoseConnector.GWStockPrice();
            if (dictStockPrice.TryGetValue(stockCode, out stockPrice))
            {
                lblBasicPrice.Text = string.Format("{0:F2}", stockPrice.BasicPrice);
                lblCeilingPrice.Text = string.Format("{0:F2}", stockPrice.CeilingPrice);
                lblFloorPrice.Text = string.Format("{0:F2}", stockPrice.FloorPrice);                
            }
            else
            {
                lblBasicPrice.Text = "";
                lblCeilingPrice.Text = "";
                lblFloorPrice.Text = "";
            }
            txtPrice.Text = lblBasicPrice.Text;
            //tim cac thong tin khac ve ma chung khoan nay
            HoseConnector.GWStockData stockData = new HoseConnector.GWStockData();
            if (dictStockData.TryGetValue(stockCode, out stockData))
            {
                isDelisted = stockData.Delist == "D" ? true : false;
                //isHalted = stockData.Halt == "H" ? true : false;
                isSplitted = stockData.Split == "S" ? true : false;
                isSuspended = stockData.Suspension == "S" ? true : false;
                if (isDelisted) lblDelist.Text = "Bị hủy niêm yết (Delisted)"; else lblDelist.Text = "";
                if (isSuspended) lblSuspension.Text = "Bị treo (Suspended)"; else lblSuspension.Text = "";
                if (isSplitted) lblSplit.Text = "Chia tách (Splitted)"; else lblSplit.Text = "";
                //if (isHalted) lblHalt.Text = "Bị ngừng GD (Halted)"; else lblHalt.Text = "";
                if (stockData.Halt == "H")
                {
                    lblHalt.Text = "Ngừng GD trong phiên AOM và PT";
                }
                else if (stockData.Halt == "A")
                {
                    lblHalt.Text = "Ngừng GD trong phiên AOM";
                }
                else if (stockData.Halt == "P")
                {
                    lblHalt.Text = "Ngừng GD trong phiên PT";
                }
                else
                {
                    lblHalt.Text = "";
                }
                chkHalt_CheckedChanged(sender, e);
            }
        }
        
        private void cboTraderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTraderID.Text = cboTraderID.SelectedValue.ToString();
        }

        private void chkHalt_CheckedChanged(object sender, EventArgs e)
        {
            //neu stock bi halt hoac suspend thi khong cho nhap lenh neu un-checked
            if (chkHalt.Checked)
            {
                btnEnter.Enabled = true;
            }
            else
            {
                if (isHalted || isDelisted || isSuspended || isSplitted)
                    btnEnter.Enabled = false;
                else
                    btnEnter.Enabled = true;
            }
        }

        private void frmMakeNewAdv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: 
                    //reset all field empty
                    cboAddOrCancel.SelectedIndex = 0;
                    cboBoardType.SelectedIndex = 0;
                    cboSide.SelectedIndex = 0;
                    cboTraderID.SelectedIndex = 0;
                    cboSecurities.SelectedIndex = 0;
                    txtVolume.Text = "";
                    cboSecurities.Focus();
                    break;
                case Keys.I:
                    if (e.Control) //Ctrl + I
                        chkHalt.Checked = !chkHalt.Checked;
                    break;
            }
        }

        private void cboSecurities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //locate 
                int i = cboSecurities.FindString(cboSecurities.Text);
                if (i >= 0) cboSecurities.SelectedIndex = i;
            }
        }

        private void cboSecurities_Leave(object sender, EventArgs e)
        {
            //locate 
            int i = cboSecurities.FindString(cboSecurities.Text);
            if (i >= 0) cboSecurities.SelectedIndex = i;
        }

        private void txtVolume_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVolume.Text)) return;
            long i;
            if (!long.TryParse(txtVolume.Text, out i)) //khong phai integer
            {
                MessageBox.Show("Khối lượng phải là số nguyên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVolume.Text = "";
                txtVolume.Focus();
                return;
            }
            if (i <= 0)
            {
                MessageBox.Show("Khối lượng phải > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVolume.Text = "";
                txtVolume.Focus();
                return;
            }
            else
            {
                if (i < 10)
                    cboBoardType.SelectedIndex = 1; //odd lot
                else
                    cboBoardType.SelectedIndex = 0; //even lot
            }
            //added by DUONGPT 13/08/2010
            double vol = 0;
            double.TryParse(txtVolume.Text, out vol);
            double price = 0;
            double.TryParse(txtPrice.Text, out price);
            double dbTotalValue = vol * price * CommonSettings.PriceMultipleOperandPT / 1000;
            lbTotalValue.Text = string.Format("{0:###,#}", dbTotalValue);
        }

        private void txtVolume_Leave(object sender, EventArgs e)
        {
            cboBoardType.Enabled = false;
        }        
    }
}
