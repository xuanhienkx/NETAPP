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
   public partial class frmMakeNewPTDeal : Form
   {
      public frmMakeNewPTDeal()
      {
         InitializeComponent();
         //db = DatabaseFactory.CreateDatabase("ConnStrHOGW");
         //validation = new HOGWValidation(db);
      }
      private Dictionary<string, HoseConnector.GWStockPrice> dictStockPrice = new Dictionary<string, HoseConnector.GWStockPrice>();
      private Dictionary<string, HoseConnector.GWStockData> dictStockData = new Dictionary<string, HoseConnector.GWStockData>();
      private Dictionary<int, HosePTConnector.PT_FIRM> dictBuyerFirms = new Dictionary<int, HosePTConnector.PT_FIRM>();
      private Dictionary<int, HosePTConnector.PT_FIRM> dictSellerFirms = new Dictionary<int, HosePTConnector.PT_FIRM>();
      private Dictionary<string, CoreConnector.CustomerBalance> dictCustomerBalances = new Dictionary<string, CoreConnector.CustomerBalance>();
      private List<HoseConnector.GWStockData> lstStockData = new List<HoseConnector.GWStockData>();
      private int traderID = -1;
      private bool isHalted = false;
      private bool isSuspended = false;
      private bool isDelisted = false;
      private bool isSplitted = false;
      private bool isLoadFromCore = false;
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
            HoseConnector.GWStockData[] stockData = Util.HoseGW.getStockCodes();
            if (stockData == null || stockData.Length <= 0)
            {
               MessageBox.Show("Lỗi khi lấy thông tin về chứng khoán từ HOGW", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            foreach (HoseConnector.GWStockData row in stockData)
            {
               if (!dictStockData.ContainsKey(row.StockCode))
               {
                  dictStockData.Add(row.StockCode, row);
                  lstStockData.Add(row);
               }
            }
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về chứng khoán", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               HoseConnector.GWStockPrice[] stockPrices = Util.HoseGW.getStockPrices();
               if (stockPrices == null || stockPrices.Length <= 0)
               {
                  MessageBox.Show("Lỗi khi lấy giá chứng khoán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               foreach (HoseConnector.GWStockPrice row in stockPrices)
               {
                  if (!dictStockPrice.ContainsKey(row.StockCode))
                     dictStockPrice.Add(row.StockCode, row);
               }
            }
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy giá chứng khoán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      protected void FillFirms()
      {
         try
         {
            //------------- BUYER FIRMS -----------
            List<HosePTConnector.PT_FIRM> dsBuyerFirms = new List<HosePTConnector.PT_FIRM>(Util.HosePTGW.GetFirmsAreNotCurrentFirm(CommonSettings.FirmID));//khong lay firm hien tai
            DataTable buyers = new DataTable();
            buyers.Columns.Add("FIRM_ID");
            buyers.Columns.Add("FIRM_NAME");
            if (dsBuyerFirms.Count == 0)
            {
               MessageBox.Show("Lỗi khi lấy dữ liệu về công ty bên mua (buyer firm)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            foreach (HosePTConnector.PT_FIRM f in dsBuyerFirms)
            {
               dictBuyerFirms.Add(f.FIRM_ID, f); //buyer firms                                                  
               buyers.Rows.Add(f.FIRM_ID, f.FIRM_NAME);
            }

            //---- auto-completion
            cboBuyerFirms.DataSource = buyers;
            cboBuyerFirms.DisplayMember = "FIRM_NAME";
            cboBuyerFirms.ValueMember = "FIRM_ID";
            cboBuyerFirms.AutoComplete = true;
            cboBuyerFirms.SelectedIndex = 0;

            //------------- SELLER FIRMS ----------                
            List<HosePTConnector.PT_FIRM> dsSellerFirms = new List<HosePTConnector.PT_FIRM>(Util.HosePTGW.GetAllFirms());
            DataTable sellers = new DataTable();
            sellers.Columns.Add("FIRM_ID");
            sellers.Columns.Add("FIRM_NAME");
            if (dsSellerFirms.Count == 0)
            {
               MessageBox.Show("Lỗi khi lấy dữ liệu về công ty bên bán (seller firm)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            foreach (HosePTConnector.PT_FIRM f in dsSellerFirms)
            {
               dictSellerFirms.Add(f.FIRM_ID, f); //seller firms   
               sellers.Rows.Add(f.FIRM_ID, f.FIRM_NAME);
            }
            //--- auto completion --------
            cboSellerFirms.DataSource = sellers;
            cboSellerFirms.DisplayMember = "FIRM_NAME";
            cboSellerFirms.ValueMember = "FIRM_ID";
            cboSellerFirms.Text = CommonSettings.FirmID.ToString();
            cboSellerFirms.Enabled = false;

            //--- no need to fill seller firms if login user matches a trader-------                
            if (traderID < 0) //khong co trader nao tuong ung voi user
            {
               cboSellerTraderID.Enabled = true;
            }
            else
            {
               cboSellerTraderID.Text = traderID.ToString();
               cboSellerTraderID.Enabled = false;
            }
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy dữ liệu về công ty (firm)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      protected void FillSellerClients()
      {
         try
         {
            CoreConnector.CustomerBalance[] cusBalances = Util.CoreGW.GetAllCustomersBalance();
            if (cusBalances == null || cusBalances.Length <= 0)
            {
               MessageBox.Show("Lỗi khi lấy dữ liệu khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            List<CoreConnector.CustomerBalance> lstCus = new List<CoreConnector.CustomerBalance>();
            //---- fill customer balance into dictionary -----
            foreach (CoreConnector.CustomerBalance cus in cusBalances)
            {
               if (!dictCustomerBalances.ContainsKey(cus.CustomerID))
               {
                  dictCustomerBalances.Add(cus.CustomerID, cus);
                  lstCus.Add(cus);
               }

            }
            cboSellerClientID.ValueMember = "CustomerID";
            cboSellerClientID.DisplayMember = "CustomerNameViet";
            cboSellerClientID.SelectedIndexChanged -= new EventHandler(this.cboSellerClientID_SelectedIndexChanged);
            cboSellerClientID.DataSource = lstCus;
            cboSellerClientID.SelectedIndexChanged += new EventHandler(this.cboSellerClientID_SelectedIndexChanged);

         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy dữ liệu khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      private void loadSellerTraders(int firmID)
      {
         cboSellerTraderID.DataSource = Util.HosePTGW.GetTraders(firmID);
         cboSellerTraderID.DisplayMember = "TRADER_NAME";
         cboSellerTraderID.ValueMember = "TRADER_ID";
      }
      private void loadBuyerTraders(int firmID)
      {
         cboBuyerTraderID.DataSource = Util.HosePTGW.GetTraders(firmID);
         cboBuyerTraderID.DisplayMember = "TRADER_NAME";
         cboBuyerTraderID.ValueMember = "TRADER_ID";
      }
      private void frmMakeNewPTDeal_Load(object sender, EventArgs e)
      {
         //cboBranch.SelectedIndex = 0;
         lbTotalValue.Text = "...";
         lblDelist.Text = "";
         label22.Text = "";
         label23.Text = "";
         label21.Text = "";
         //----
         ttipStatus.Text = "";// "Press F1 to reset form, Ctrl + I to [un]check 'Ignore Halt' control";
         lblBasicPrice.Text = "";
         lblCeilingPrice.Text = "";
         lblFloorPrice.Text = "";
         lblBuyerTraderID.Text = "";
         lblSellerTraderID.Text = "";
         //------            
         lblAvailBalance.Text = "...";
         lblCashBalance.Text = "...";
         lblAvailSecBalance.Text = "...";
         lblSellerSecBalance.Text = "...";

         FillStockPricesInDictionary();
         FillStockInfoInDictionary();
         FillAllSecurities();
         FillFirms();
         //Goi event nay lan dau de locate TraderID
         cboBuyerFirms_SelectedIndexChanged(sender, e);
         //FillSellerClients();
         //if (db != null)
         //    ttipHOGW.Text = "HOGW database connected!";
         //else
         //    ttipHOGW.Text = "HOGW database NOT connected!";
         traderID = Util.HosePTGW.GetTraderIdByUser(Util.LoginResult.UserName);
         //---- fill board type ---
         List<PTBoardType> lstBoardType = new List<PTBoardType>();
         lstBoardType.Add(new PTBoardType("Lô chẵn", CommonSettings.BoardPT));
         lstBoardType.Add(new PTBoardType("Lô lẻ", CommonSettings.BoardOdd));
         cboBoardType.DataSource = lstBoardType;
         cboBoardType.ValueMember = "BoardType";
         cboBoardType.DisplayMember = "BoardName";
         cboBoardType.SelectedIndex = 0;
         cboBoardType.Enabled = false;

         chkLoadFromCore.Checked = false;
         chkLoadFromCore_CheckedChanged(sender, e);

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
            MessageBox.Show("Sai định dạng về giá!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (price >= 1000)
         {
            MessageBox.Show("Giá phải < 1 tỷ", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (string.IsNullOrEmpty(cboSellerFirms.Text))
         {
            MessageBox.Show("Công ty bên bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (string.IsNullOrEmpty(cboSellerTraderID.Text))
         {
            MessageBox.Show("Trader bên bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         //----------- check client ID ------------
         string SellerClientID;
         if (chkLoadFromCore.Checked)
            SellerClientID = cboSellerClientID.SelectedValue == null ? "" : cboSellerClientID.SelectedValue.ToString();
         else
            SellerClientID = cboSellerClientID.Text;
         if (string.IsNullOrEmpty(SellerClientID))
         {
            MessageBox.Show("Mã KH bên bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (SellerClientID.Length != 10)
         {
            MessageBox.Show("Mã khách hàng bán có độ dài khác 10!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (string.IsNullOrEmpty(cboBuyerFirms.Text))
         {
            MessageBox.Show("Công ty bên mua không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         //Modified by DUONGPT 17/12/2010
         //if (string.IsNullOrEmpty(cboBuyerTraderID.Text))
         string strBuyerFirms = cboBuyerFirms.Text;
         int iBuyerFirmLength = cboBuyerFirms.Text.Length;
         if (string.IsNullOrEmpty(txtBuyerTraderID.Text))
         {
            MessageBox.Show("Trader bên mua không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         double dbBuyerTraderID = 0;
         if (!double.TryParse(txtBuyerTraderID.Text.Trim().ToString(), out dbBuyerTraderID))
         {
            MessageBox.Show("Sai định dạng TraderID bên mua!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (txtBuyerTraderID.Text.Length < 2 || txtBuyerTraderID.Text.Length > 4)
         {
            MessageBox.Show("Trader bên mua có độ dài < 2 hoặc > 4!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (txtBuyerTraderID.Text.Substring(0, iBuyerFirmLength) != strBuyerFirms)
         {
            MessageBox.Show("TraderID và BrokerID khác dải số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         //volumes
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
         double volCSell, volFSell, volMSell, volPSell;
         if (SellerClientID[3] == 'P' || SellerClientID[3] == 'p') { volPSell = vol; volFSell = volCSell = volMSell = 0; } //porfolio
         else if (SellerClientID[3] == 'M' || SellerClientID[3] == 'm') { volMSell = vol; volFSell = volCSell = volPSell = 0; } //mutual fund
         else if (SellerClientID[3] == 'F' || SellerClientID[3] == 'f') { volFSell = vol; volPSell = volCSell = volMSell = 0; } //foreigner
         else { volCSell = vol; volFSell = volPSell = volMSell = 0; } //client


         //khong du chung khoan thi canh bao, nhung khong cam
         CoreConnector.Securities cusSec = Util.CoreGW.GetSecurity(SellerClientID, cboSecurities.SelectedValue.ToString());
         if ((cusSec == null) || (cusSec != null && cusSec.Quatity < vol))
         {
            if (MessageBox.Show("TK " + SellerClientID + " không có đủ số dư chứng khoán! \nBạn có muốn tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
               return;
         }

         if (MessageBox.Show("Bạn chắc chắn muốn nhập!", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         try
         {
            string orderStatus, s;
            if (!CommonSettings.HasApprove) //khong can duyet lenh
               orderStatus = CommonSettings.PT_APPROVED;
            else
               orderStatus = CommonSettings.PT_PENDING;
            //Lay thong tin ve thi truong tu HOGW de validate
            string marketStatus = Util.HoseGW.GetMarketStatusHOSE();

            // bool b = gw
            //validation order
            HoseConnector.HOGWValidOutput output = Util.HoseGW.ValidateOrder(SellerClientID, cboSecurities.SelectedValue.ToString().Trim(),
                "PT", marketStatus, "N", "S", Convert.ToInt32(cboSellerTraderID.SelectedValue),
                Convert.ToDecimal(txtPrice.Text), Convert.ToDouble(txtVolume.Text),
                Convert.ToDouble(txtVolume.Text), PTOrderType.ORDER_TYPE_2_FIRM_DEAL, "");
            if (!output.IsOK && (output.ErrCode == 12112 || output.ErrCode == 1211))
            {
               s = "[VALID_ERROR - 1G] Cust=" + SellerClientID + ", Stock=" +
                           cboSecurities.SelectedValue.ToString().Trim() +
                           ", Vol=" + txtVolume.Text + ", Price=" + txtPrice.Text +
                           ", Trader=" + cboSellerTraderID.SelectedValue + ", MktSts=" + marketStatus;
               s += " [ErrCode: " + output.ErrCode.ToString() + " - " + output.ErrDesc + "]";
               frmMainPT.writeLog(s);
               MessageBox.Show(s, "LỖI KHI KIỂM TRA ĐẦU VÀO LỆNH", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            //Goi ham insert vao SBS core (Order Type = PT, side = S)
            //Modified by DUONGPT 13/08/2010
            /*
            int iBranch = cboBranch.SelectedIndex;
            string sBranchCode = "";
            string sTradeCode = "";
            if (iBranch == 0)
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
            //string sBranchCode = CommonSettings.CoreOnlineBranchCode;
            string orderDate = ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode); //"05/12/2008";//DateTime.Now.ToString("dd/MM/yyyy");
            CreateOrderResult ret1 = ConnectToSBSFacade.CreateOrder(orderDate, "S", "PT",
                cboSecurities.SelectedValue.ToString(), (decimal)vol,
                Convert.ToDecimal(txtPrice.Text), SellerClientID, Util.LoginResult.Branch.BrachCode,
                Util.LoginResult.Branch.TradeCode, CommonSettings.CoreOnlineUser, "PT 2-FIRM SELL", -300);
            if (ret1.Transtate == (int)TranState.Success) //neu insert lenh ban thanh cong
            {
               /*
               int r = Util.HosePTGW.InsertSellerDeal(orderStatus, CommonSettings.FirmID, Convert.ToInt32(cboSellerTraderID.SelectedValue), SellerClientID,
                   Convert.ToInt32(cboBuyerFirms.Text), Convert.ToInt32(cboBuyerTraderID.SelectedValue), cboSecurities.SelectedValue.ToString().Trim(), Convert.ToDecimal(txtPrice.Text) //*CommonSettings.PriceMultipleOperandPT
                   , cboBoardType.SelectedValue.ToString(), volPSell, volCSell, volMSell, volFSell, 
                   Util.LoginResult.UserName, "", ret1.OrderSeq);                    
                */
               int r = Util.HosePTGW.PTInsertSellerDeal(orderStatus, CommonSettings.FirmID, Convert.ToInt32(cboSellerTraderID.SelectedValue), SellerClientID,
                   Convert.ToInt32(cboBuyerFirms.Text), Convert.ToInt32(txtBuyerTraderID.Text), cboSecurities.SelectedValue.ToString().Trim(), Convert.ToDecimal(txtPrice.Text) //*CommonSettings.PriceMultipleOperandPT
                   , cboBoardType.SelectedValue.ToString(), volPSell, volCSell, volMSell, volFSell,
                   Util.LoginResult.UserName, "", ret1.OrderSeq);
               if (r > 0)
               {
                  ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Nhập lệnh thành công!";
                  //Log
                  /*
                  s = "[OK] 2FIRM-1G: " + "ContraFirm=" + cboBuyerFirms.Text + ", Trader=" + cboSellerTraderID.SelectedValue +
                      ", ContraTrader=" + cboBuyerTraderID.SelectedValue +
                      ", Seller=" + SellerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                      txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                   */
                  s = "[OK] 2FIRM-1G: " + "ContraFirm=" + cboBuyerFirms.Text + ", Trader=" + cboSellerTraderID.SelectedValue +
                      ", ContraTrader=" + txtBuyerTraderID.Text +
                      ", Seller=" + SellerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                      txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                  frmMainPT.writeLog(s);
                  MessageBox.Show(s, "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               else
               {
                  ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Có lỗi xảy ra khi thêm lệnh!";
                  //Log
                  /*
                  s = "[FAIL] 2FIRM-1G: " + "ContraFirm=" + cboBuyerFirms.Text + ", Trader=" + cboSellerTraderID.SelectedValue +
                      ", ContraTrader=" + cboBuyerTraderID.SelectedValue +
                      ", Seller=" + SellerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                      txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                   */
                  s = "[FAIL] 2FIRM-1G: " + "ContraFirm=" + cboBuyerFirms.Text + ", Trader=" + cboSellerTraderID.SelectedValue +
                     ", ContraTrader=" + txtBuyerTraderID.Text +
                     ", Seller=" + SellerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString().Trim() + ", Vol=" +
                     txtVolume.Text + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                  frmMainPT.writeLog(s);
                  MessageBox.Show(s, "LỖI XẢY RA", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            else
            {
               MessageBox.Show(ret1.Message, "Lỗi từ SBS Gateway khi nhập lệnh 2-FIRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
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
            if (isDelisted) lblDelist.Text = "Hủy NY"; else lblDelist.Text = "";
            if (isSuspended) label22.Text = "Treo"; else label22.Text = "";
            if (isSplitted) label23.Text = "Chia tách"; else label23.Text = "";
            //if (isHalted) label21.Text = "Ngừng GD"; else label21.Text = "";
            if (stockData.Halt == "H")
            {
               label21.Text = "Ngừng GD trong phiên AOM và PT";
            }
            else if (stockData.Halt == "A")
            {
               label21.Text = "Ngừng GD trong phiên AOM";
            }
            else if (stockData.Halt == "P")
            {
               label21.Text = "Ngừng GD trong phiên PT";
            }
            else
            {
               label21.Text = "";
            }
            chkHalt_CheckedChanged(sender, e);
         }
      }

      private void cboSellerFirms_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(cboSellerFirms.Text)) return;
         //Thay doi danh sach trader tuong ung voi firm nay
         int firmID = int.Parse(cboSellerFirms.Text.Trim());
         loadSellerTraders(firmID);
      }

      private void cboBuyerFirms_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(cboBuyerFirms.Text)) return;
         int firmID = int.Parse(cboBuyerFirms.Text.Trim());
         loadBuyerTraders(firmID);
      }

      private void cboSellerClientID_SelectedIndexChanged(object sender, EventArgs e)
      {
         //update balance tuong ung
         string customerID = cboSellerClientID.SelectedValue.ToString();
         CustomerBalanceInfoResult rCus = ConnectToSBSFacade.getCustomerBalanceInfo(customerID);
         if (rCus.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(rCus.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         lblCashBalance.Text = string.Format("{0:###,#}", rCus.balance);
         lblAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

         //lay so du chung khoan tu SBS_ws
         //Modified by DUONGPT 13/08/2010
         /*
         int iBranch = cboBranch.SelectedIndex;
         string sBranchCode = "";
         //string sTradeCode = "";
         if (iBranch == 0)
         {
             sBranchCode = "100";
             //sTradeCode = "VICS";
         }
         else
         {
             sBranchCode = "200";
             //sTradeCode = "VICSHCM";
         }
          */
         string StockCode = cboSecurities.SelectedValue == null ? "" : cboSecurities.SelectedValue.ToString();
         GetStockEnquiry stockEnquiry = ConnectToSBSFacade.getStockEnquiry(customerID,
             ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode), StockCode);
         if (stockEnquiry.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(stockEnquiry.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //Modified by DUONGPT 13/08/2010
         //lblSellerSecBalance.Text = stockEnquiry.TotalQuantity.ToString();
         //lblAvailSecBalance.Text = stockEnquiry.AvaiableQuantity.ToString();
         lblSellerSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.TotalQuantity);
         lblAvailSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.AvaiableQuantity);
         /*
         CoreConnector.CustomerBalance cusBalance = new CoreConnector.CustomerBalance();
         if (dictCustomerBalances.TryGetValue(customerID, out cusBalance))
         {
             lblCashBalance.Text = string.Format("{0:###,#}", cusBalance.Balance);
             lblAvailBalance.Text = string.Format("{0:###,#}", cusBalance.AvailBalance);
         }
         if (cboSecurities.SelectedIndex < 0) return;
         string stock = cboSecurities.SelectedValue.ToString();
         CoreConnector.Securities cusSec = coreService.GetSecurity(customerID, stock);
         if (cusSec != null) lblSellerSecBalance.Text = string.Format("{0:###,#} {1}", cusSec.Quatity, cusSec.StockCode);
         else lblSellerSecBalance.Text = "";*/
      }

      private void cboSellerTraderID_SelectedIndexChanged(object sender, EventArgs e)
      {
         lblSellerTraderID.Text = cboSellerTraderID.SelectedValue.ToString();
      }

      private void cboBuyerTraderID_SelectedIndexChanged(object sender, EventArgs e)
      {
         lblBuyerTraderID.Text = cboBuyerTraderID.SelectedValue.ToString();
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

      private void frmMakeNewPTDeal_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F1:
               //reset all field empty
               cboBoardType.SelectedIndex = 0;
               cboBuyerFirms.SelectedIndex = 0;
               cboBuyerTraderID.SelectedIndex = 0;
               cboSecurities.SelectedIndex = 0;
               cboSellerTraderID.SelectedIndex = 0;
               txtPrice.Text = "";
               txtVolume.Text = "";
               cboSecurities.Focus();
               break;
            case Keys.I:
               if (e.Control) //Ctrl + I
                  chkHalt.Checked = !chkHalt.Checked;
               break;
         }
      }

      private void btnLoadSellerClients_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Lấy DS khách hàng từ CORE SBS mất vài phút, chắc chắn thực hiện?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         try
         {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            FillSellerClients();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            isLoadFromCore = true;
            btnLoadSellerClients.Enabled = false;
            chkLoadFromCore.Enabled = false;
         }
         catch
         {
            this.Cursor = System.Windows.Forms.Cursors.Default;
         }
      }

      private void chkLoadFromCore_CheckedChanged(object sender, EventArgs e)
      {
         btnLoadSellerClients.Enabled = chkLoadFromCore.Checked && !isLoadFromCore;
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
            MessageBox.Show("Khối lượng phải là số nguyên", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtVolume.Text = "";
            txtVolume.Focus();
            return;
         }
         if (i <= 0)
         {
            MessageBox.Show("Khối lượng phải lớn hơn 0", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      private void btnGetBalance_Click(object sender, EventArgs e)
      {
         string customerID;
         if (chkLoadFromCore.Checked && cboSellerClientID.SelectedValue != null)
            customerID = cboSellerClientID.SelectedValue.ToString();
         else
            customerID = cboSellerClientID.Text;
         if (string.IsNullOrEmpty(customerID))
         {
            MessageBox.Show("Mã khách hàng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (customerID.Length != 10)
         {
            MessageBox.Show("Độ dài mã khách hàng phải = 10", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         CustomerBalanceInfoResult rCus = ConnectToSBSFacade.getCustomerBalanceInfo(customerID);
         if (rCus.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(rCus.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         lblCashBalance.Text = string.Format("{0:###,#}", rCus.balance);
         lblAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

         //lay so du chung khoan tu SBS_ws
         //Added by DUONGPT 13/08/2010
         /*
         int iBranch = cboBranch.SelectedIndex;
         string sBranchCode = "";
         //string sTradeCode = "";
         if (iBranch == 0)
         {
             sBranchCode = "100";
             //sTradeCode = "VICS";
         }
         else
         {
             sBranchCode = "200";
             //sTradeCode = "VICSHCM";
         }
          */
         string StockCode = cboSecurities.SelectedValue == null ? "" : cboSecurities.SelectedValue.ToString();
         GetStockEnquiry stockEnquiry = ConnectToSBSFacade.getStockEnquiry(customerID,
             ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode), StockCode);
         if (stockEnquiry.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(stockEnquiry.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //Modified by DUONGPT 13/08/2010
         //lblSellerSecBalance.Text = stockEnquiry.TotalQuantity.ToString();
         //lblAvailSecBalance.Text = stockEnquiry.AvaiableQuantity.ToString();
         lblSellerSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.TotalQuantity);
         lblAvailSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.AvaiableQuantity);
      }

      private void cboSellerClientID_Leave(object sender, EventArgs e)
      {
         cboSellerClientID.Text = cboSellerClientID.Text.ToUpper();
         //try to locate
         int i = cboSellerClientID.FindString(cboSellerClientID.Text);
         if (i >= 0)
            cboSellerClientID.SelectedIndex = i;
      }

      private void txtVolume_Leave(object sender, EventArgs e)
      {
         cboBoardType.Enabled = false;
      }

   }
}
