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
   public partial class frmMakeNewPT1FirmDeal : Form
   {
      public frmMakeNewPT1FirmDeal()
      {
         InitializeComponent();
         //db = DatabaseFactory.CreateDatabase("ConnStrHOGW");
         firmID = Util.HosePTGW.GetTraderIdByUser(Util.LoginResult.UserName);
         //validation = new HOGWValidation(db);
      }
      private int firmID = -1;
      private Dictionary<string, HoseConnector.GWStockPrice> dictStockPrice = new Dictionary<string, HoseConnector.GWStockPrice>();
      private Dictionary<int, HosePTConnector.PT_FIRM> dictSellerFirms = new Dictionary<int, HosePTConnector.PT_FIRM>();
      private Dictionary<string, CoreConnector.CustomerBalance> dictSellerClients = new Dictionary<string, CoreConnector.CustomerBalance>();
      private Dictionary<string, CoreConnector.CustomerBalance> dictBuyerClients = new Dictionary<string, CoreConnector.CustomerBalance>();
      private Dictionary<string, HoseConnector.GWStockData> dictStockData = new Dictionary<string, HoseConnector.GWStockData>();
      private List<HoseConnector.GWStockData> lstStockData = new List<HoseConnector.GWStockData>();
      private Dictionary<string, CoreConnector.Securities> dictCurrentSellerSecurities = new Dictionary<string, CoreConnector.Securities>();
      private bool isHalted = false;
      private bool isSuspended = false;
      private bool isDelisted = false;
      private bool isSplitted = false;
      private bool isLoadFromCore = false;
      //private HOGWValidation validation = null;
      //private Database db;
      private HoseConnector.GWConnectorWS gwService = new HoseConnector.GWConnectorWS();
      private CoreConnector.CoreConnectorWS coreService = new CoreConnector.CoreConnectorWS();
      protected void FillAllSecurities()
      {
         //Get securities
         try
         {
            if (CommonSettings.CheckPriceFromCore)
            {
               //Do nothing
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
                  MessageBox.Show("Lỗi khi lấy thông tin về giá chứng khoán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                  MessageBox.Show("Lỗi khi lấy thông tin về giá chứng khoán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               foreach (HoseConnector.GWStockPrice row in stockPrices)
               {
                  if (!dictStockPrice.ContainsKey(row.StockCode))
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
      protected void FillClients()
      {
         try
         {
            //Customer data

            CoreConnector.CustomerBalance[] cusBalances = coreService.GetAllCustomersBalance();
            if (cusBalances == null || cusBalances.Length <= 0)
            {
               MessageBox.Show("Lỗi khi lấy thông tin về khách hàng từ CORE SBS", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            List<CoreConnector.CustomerBalance> lstCusSeller = new List<CoreConnector.CustomerBalance>();
            List<CoreConnector.CustomerBalance> lstCusBuyer = new List<CoreConnector.CustomerBalance>();
            //---- fill customer balance into dictionary -----
            foreach (CoreConnector.CustomerBalance cus in cusBalances)
            {
               if (!dictSellerClients.ContainsKey(cus.CustomerID))
               {
                  dictSellerClients.Add(cus.CustomerID, cus);
                  lstCusSeller.Add(cus);
               }
               if (!dictBuyerClients.ContainsKey(cus.CustomerID))
               {
                  dictBuyerClients.Add(cus.CustomerID, cus);
                  lstCusBuyer.Add(cus);
               }
            }
            cboSellerClientID.ValueMember = "CustomerID";
            cboSellerClientID.DisplayMember = "CustomerNameViet";
            cboSellerClientID.SelectedIndexChanged -= new EventHandler(this.cboSellerClientID_SelectedIndexChanged);
            cboSellerClientID.DataSource = lstCusSeller;
            cboSellerClientID.SelectedIndexChanged += new EventHandler(this.cboSellerClientID_SelectedIndexChanged);
            cboBuyerClientID.ValueMember = "CustomerID";
            cboBuyerClientID.DisplayMember = "CustomerNameViet";
            cboBuyerClientID.SelectedIndexChanged -= new EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
            cboBuyerClientID.DataSource = lstCusBuyer;
            cboBuyerClientID.SelectedIndexChanged += new EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      protected void FillSellerClients()
      {
         try
         {
            //Customer data

            CoreConnector.CustomerBalance[] cusBalances = coreService.GetAllCustomersBalance();
            if (cusBalances == null || cusBalances.Length <= 0)
            {
               MessageBox.Show("Lỗi khi lấy thông tin về KH bên bán từ core SBS", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            List<CoreConnector.CustomerBalance> lstCus = new List<CoreConnector.CustomerBalance>();
            //---- fill customer balance into dictionary -----
            foreach (CoreConnector.CustomerBalance cus in cusBalances)
            {
               if (!dictSellerClients.ContainsKey(cus.CustomerID))
               {
                  dictSellerClients.Add(cus.CustomerID, cus);
                  lstCus.Add(cus);
               }
            }
            cboSellerClientID.ValueMember = "CustomerID";
            cboSellerClientID.DisplayMember = "CustomerNameViet";
            cboSellerClientID.DataSource = lstCus;
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về khách hàng bên bán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      protected void FillBuyerClients()
      {
         try
         {
            //Customer data
            CoreConnector.CustomerBalance[] cusBalances = coreService.GetAllCustomersBalance();
            if (cusBalances == null || cusBalances.Length <= 0)
            {
               MessageBox.Show("Lỗi khi lấy thông tin về khách hàng bên mua từ core SBS", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            List<CoreConnector.CustomerBalance> lstCus = new List<CoreConnector.CustomerBalance>();
            //---- fill customer balance into dictionary -----
            foreach (CoreConnector.CustomerBalance cus in cusBalances)
            {
               if (!dictBuyerClients.ContainsKey(cus.CustomerID))
               {
                  lstCus.Add(cus);
                  dictBuyerClients.Add(cus.CustomerID, cus);
               }
            }
            cboBuyerClientID.ValueMember = "CustomerID";
            cboBuyerClientID.DisplayMember = "CustomerNameViet";
            cboBuyerClientID.DataSource = lstCus;
         }
         catch (SystemException exception)
         {
            MessageBox.Show(exception.Message, "Lỗi khi lấy thông tin về khách hàng bên mua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }
      private void loadSellerTraders()
      {
         //neu user login co trader tuong ung thi khong load traders
         if (firmID < 0)
         {
            cboSellerTraderID.DisplayMember = "TRADER_NAME";
            cboSellerTraderID.ValueMember = "TRADER_ID";
            cboSellerTraderID.DataSource = Util.HosePTGW.GetTraders(CommonSettings.FirmID);
         }
         else
         {
            cboSellerTraderID.Text = firmID.ToString();
            cboSellerTraderID.Enabled = false;
         }
      }
      private void frmMakeNewPTDeal_Load(object sender, EventArgs e)
      {
         //cboBranch.SelectedIndex = 0;
         lblDelist.Text = "";
         lblSuspension.Text = "";
         lblSplit.Text = "";
         lblHalt.Text = "";

         //----
         ttipStatus.Text = "";// "Press F1 to reset form, Ctrl + I to [un]check 'Ignore Halt' control";
         lblBasicPrice.Text = "";
         lblCeilingPrice.Text = "";
         lblFloorPrice.Text = "";
         lblSellerTraderID.Text = "";
         //------
         lblBuyerAvailBalance.Text = "...";
         lblSellerAvailBalance.Text = "...";
         lblAvailSecBalance.Text = "...";
         lblBuyerBalance.Text = "...";
         lblSellerBalance.Text = "...";
         lblSellerSecBalance.Text = "...";
         lbTotalValue.Text = "...";

         FillStockInfoInDictionary();
         FillStockPricesInDictionary();
         FillAllSecurities();
         //vi Customers load tu CORE qua webservice nen de load option
         //FillSellerClients();
         //FillBuyerClients();
         loadSellerTraders();

         //if (db != null)
         //    ttipHOGW.Text = "HOGW database connected!";
         //else
         //    ttipHOGW.Text = "HOGW database NOT connected!";
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
         double vol = 0;
         if (!double.TryParse(txtVolume.Text, out vol))
         {
            MessageBox.Show("Sai định dạng về khối lượng!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (vol < 20000)
         {
            MessageBox.Show("Khối lượng phải >= 20.000 CP", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (string.IsNullOrEmpty(cboSellerTraderID.Text))
         {
            MessageBox.Show("Trader bên bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         //----------- check client ID ------------
         string SellerClientID, BuyerClientID;
         if (chkLoadFromCore.Checked)
         {
            SellerClientID = cboSellerClientID.SelectedValue == null ? "" : cboSellerClientID.SelectedValue.ToString();
            BuyerClientID = cboBuyerClientID.SelectedValue == null ? "" : cboBuyerClientID.SelectedValue.ToString();
         }
         else
         {
            SellerClientID = cboSellerClientID.Text;
            BuyerClientID = cboBuyerClientID.Text;
         }
         if (string.IsNullOrEmpty(BuyerClientID))
         {
            MessageBox.Show("Mã khách hàng mua không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (string.IsNullOrEmpty(SellerClientID))
         {
            MessageBox.Show("Mã khách hàng bán không được để trống!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         BuyerClientID = BuyerClientID.Trim();
         SellerClientID = SellerClientID.Trim();
         if (BuyerClientID == SellerClientID)
         {
            MessageBox.Show("Khách hàng mua và khách hàng bán phải khác nhau!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (BuyerClientID.Length != 10)
         {
            MessageBox.Show("Mã khách hàng mua có độ dài khác 10!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         if (SellerClientID.Length != 10)
         {
            MessageBox.Show("Mã khách hàng bán có độ dài khác 10!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         /*
         double vol = 0;
         if (!double.TryParse(txtVolume.Text, out vol))
         {
             MessageBox.Show("Khối lượng sai định dạng!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             return;
         }
          */
         //Modified by DUONGPT
         //12/08/2010
         //double dbTotalValue=vol * price * CommonSettings.PriceMultipleOperandPT / 1000;
         //lbTotalValue.Text = Convert.ToString(dbTotalValue);
         //Neu khong du tien thi canh bao, nhung khong cam
         CoreConnector.CustomerBalance cusBalance = new CoreConnector.CustomerBalance();
         if (dictBuyerClients.TryGetValue(BuyerClientID, out cusBalance))
         {
            //if (cusBalance.AvailBalance < vol * price * CommonSettings.PriceMultipleOperandPT)
            if (cusBalance.AvailBalance < vol * price * CommonSettings.PriceMultipleOperandPT / 1000)
            {
               if (MessageBox.Show(BuyerClientID + " không có số dư tiền để mua! Bạn có muốn tiếp tục?", "Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                  return;
            }
         }
         else//khong lay duoc so du tien
         {
            if (MessageBox.Show("Không lấy được số dư tiền của TK " + BuyerClientID + ". Bạn có muốn tiếp tục?", "Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
               return;
         }
         //khong du chung khoan thi canh bao, nhung khong cam
         CoreConnector.Securities cusSec = coreService.GetSecurity(SellerClientID, cboSecurities.SelectedValue.ToString());
         if ((cusSec == null) || (cusSec != null && cusSec.Quatity < vol))
         {
            if (MessageBox.Show(SellerClientID + " không có đủ số dư chứng khoán! Bạn có muốn tiếp tục?", "Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
               return;
         }
         //------------------
         if (MessageBox.Show("Chắc chắn thêm mới giao dịch thỏa thuận này!", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;

         try
         {
            string orderStatus, s;
            if (!CommonSettings.HasApprove) //khong can duyet lenh
               orderStatus = CommonSettings.PT_APPROVED;
            else
               orderStatus = CommonSettings.PT_PENDING;
            //Lay thong tin ve thi truong tu HOGW de validate
            string marketStatus = gwService.GetMarketStatusHOSE();

            //double vol = Convert.ToDouble(txtVolume.Text);
            double volCBuy, volCSell, volFBuy, volFSell, volMBuy, volMSell, volPBuy, volPSell;
            if (BuyerClientID[3] == 'P' || BuyerClientID[3] == 'p') { volPBuy = vol; volFBuy = volCBuy = volMBuy = 0; } //porfolio
            else if (BuyerClientID[3] == 'M' || BuyerClientID[3] == 'm') { volMBuy = vol; volFBuy = volCBuy = volPBuy = 0; } //mutual fund
            else if (BuyerClientID[3] == 'F' || BuyerClientID[3] == 'f') { volFBuy = vol; volPBuy = volCBuy = volMBuy = 0; } //foreigner
            else { volCBuy = vol; volFBuy = volPBuy = volMBuy = 0; } //client

            if (SellerClientID[3] == 'P' || SellerClientID[3] == 'p') { volPSell = vol; volFSell = volCSell = volMSell = 0; } //porfolio
            else if (SellerClientID[3] == 'M' || SellerClientID[3] == 'm') { volMSell = vol; volFSell = volCSell = volPSell = 0; } //mutual fund
            else if (SellerClientID[3] == 'F' || SellerClientID[3] == 'f') { volFSell = vol; volPSell = volCSell = volMSell = 0; } //foreigner
            else { volCSell = vol; volFSell = volPSell = volMSell = 0; } //client

            //validation order
            //Neu lenh 1-firm giua 2 NDT nuoc ngoai thi khong check room (truyen vao PTOrderType tuong ung)
            int ptOrderType = PTOrderType.ORDER_TYPE_1_FIRM_DEAL;
            if (volFBuy > 0 && volFSell > 0)
               ptOrderType = (int)PTOrderType.ORDER_TYPE_1_FIRM_ALL_FOREIGN;
            HoseConnector.HOGWValidOutput output1 = gwService.ValidateOrder(SellerClientID, cboSecurities.SelectedValue.ToString().Trim(),
                "PT", marketStatus, "N", "S", Convert.ToInt32(cboSellerTraderID.SelectedValue),
                Convert.ToDecimal(txtPrice.Text), vol, vol, ptOrderType, "");
            HoseConnector.HOGWValidOutput output2 = gwService.ValidateOrder(BuyerClientID, cboSecurities.SelectedValue.ToString().Trim(),
                "PT", marketStatus, "N", "B", Convert.ToInt32(cboSellerTraderID.SelectedValue),
                Convert.ToDecimal(txtPrice.Text), vol, vol, ptOrderType, "");
            if (!output1.IsOK && (output1.ErrCode == 12112 || output1.ErrCode == 1211))
            {
               s = "[VALID_ERROR - SELLER 1F] Seller=" + SellerClientID + ", Buyer=" + BuyerClientID + ", Stock=" +
                           cboSecurities.SelectedValue.ToString().Trim() +
                           ", Vol=" + vol.ToString() + ", Price=" + txtPrice.Text +
                           ", Trader=" + cboSellerTraderID.SelectedValue + ", MktSts=" + marketStatus;
               s += " [ErrCode: " + output1.ErrCode.ToString() + " - " + output1.ErrDesc + "]";
               frmMainPT.writeLog(s);
               MessageBox.Show(s, "Lỗi khi kiểm tra đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            if (!output2.IsOK && (output1.ErrCode == 12112 || output1.ErrCode == 1211))
            {
               s = "[VALID_ERROR - BUYER 1F] Buyer=" + BuyerClientID + ", Seller=" + SellerClientID + ", Stock=" +
                           cboSecurities.SelectedValue.ToString().Trim() +
                           ", Vol=" + vol.ToString() + ", Price=" + txtPrice.Text +
                           ", Trader=" + cboSellerTraderID.SelectedValue + ", MktSts=" + marketStatus;
               s += " [ErrCode: " + output2.ErrCode.ToString() + " - " + output2.ErrDesc + "]";
               frmMainPT.writeLog(s);
               MessageBox.Show(s, "Lỗi khi kiểm tra đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            //Goi ham insert (2 lan) vao SBS core (Order Type = PT)
            string orderDate = ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode); //"05/12/2008";//DateTime.Now.ToString("dd/MM/yyyy");
            CreateOrderResult retSell = ConnectToSBSFacade.CreateOrder(orderDate, "S", "PT", cboSecurities.SelectedValue.ToString(),
                (decimal)vol, Convert.ToDecimal(txtPrice.Text), SellerClientID, Util.LoginResult.Branch.BrachCode,
                Util.LoginResult.Branch.TradeCode, CommonSettings.CoreOnlineUser, "PT 1-FIRM SELL", -300);
            if (retSell.Transtate == (int)TranState.Success) //neu insert lenh ban thanh cong
            {
               CreateOrderResult retBuy = ConnectToSBSFacade.CreateOrder(orderDate, "B", "PT", cboSecurities.SelectedValue.ToString(),
                   (decimal)vol, Convert.ToDecimal(txtPrice.Text), BuyerClientID, Util.LoginResult.Branch.BrachCode,
               Util.LoginResult.Branch.TradeCode, CommonSettings.CoreOnlineUser, "PT 1-FIRM BUY", -300);
               if (retBuy.Transtate == (int)TranState.Success) //neu insert lenh mua thanh cong
               {
                  //thi moi tao lenh 1 firm trong PT_SBS va Update Order_Seq
                  int r = Util.HosePTGW.PTInsert1FirmDeal(orderStatus, CommonSettings.FirmID, Convert.ToInt32(cboSellerTraderID.Text), BuyerClientID,
                      SellerClientID, cboSecurities.SelectedValue.ToString(), Convert.ToDecimal(txtPrice.Text) // * CommonSettings.PriceMultipleOperandPT
                      , cboBoardType.SelectedValue, volPBuy, volCBuy, volMBuy, volFBuy, volPSell, volCSell, volMSell, volFSell,
                      Util.LoginResult.UserName, "", retBuy.OrderSeq, retSell.OrderSeq);
                  if (r > 0)
                  {
                     ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Giao dịch thỏa thuận THÀNH CÔNG!";
                     //Log
                     s = "[OK] 1FIRM-1F: " + "Trader=" + cboSellerTraderID.Text + ", Seller=" + SellerClientID +
                         ", Buyer=" + BuyerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString() + ", Vol=" +
                         vol.ToString() + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                     frmMainPT.writeLog(s);
                     MessageBox.Show(s, "Giao dịch THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  else
                  {
                     ttipStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": Giao dịch thỏa thuận KHÔNG thành công!";
                     //Log
                     s = "[FAIL] 1FIRM-1F: " + "Trader=" + cboSellerTraderID.Text + ", Seller=" + SellerClientID +
                         ", Buyer=" + BuyerClientID + ", Stock=" + cboSecurities.SelectedValue.ToString() + ", Vol=" +
                         vol.ToString() + ", Price=" + txtPrice.Text + "[" + Util.LoginResult.UserName + "]";
                     MessageBox.Show(s, "LỖI khi thêm mới giao dịch TT cùng công ty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
               else //insert lenh mua khong thanh cong, thi huy luon lenh ban
               {
                  MessageBox.Show(retBuy.Message, "Lỗi từ SBS Gateway khi tạo lệnh thỏa thuận cùng công ty - bên mua.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  ConnectToSBSFacade.deleteOrder(orderDate, retSell.OrderSeq.ToString());
                  MessageBox.Show("Lệnh thỏa thuận đối ứng (bên bán) đã được hủy - do lệnh mua tương ứng không vào được hệ thống!",
                      "Tạo lệnh thỏa thuận cùng công ty - bên mua thất bại. Hủy lệnh bán đối ứng.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  return;
               }
            }
            else //insert lenh ban khong thanh cong
            {
               MessageBox.Show(retSell.Message, "Lỗi từ SBS Gateway , tạo lệnh thỏa thuận cùng công ty (bên bán) không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (isSuspended) lblSuspension.Text = "Treo"; else lblSuspension.Text = "";
            if (isSplitted) lblSplit.Text = "Chia tách"; else lblSplit.Text = "";
            //if (isHalted) lblHalt.Text = "Ngừng GD"; else lblHalt.Text = "";
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
         lblSellerBalance.Text = string.Format("{0:###,#}", rCus.balance);
         lblSellerAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

         //lay so du chung khoan tu SBS_ws
         //Added by DUONGPT 13/08/2010
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

         double vol = 0;
         double.TryParse(txtVolume.Text, out vol);
         double price = 0;
         double.TryParse(txtPrice.Text, out price);
         double dbTotalValue = vol * price * CommonSettings.PriceMultipleOperandPT / 1000;
         lbTotalValue.Text = string.Format("{0:###,#}", dbTotalValue);

      }

      private void cboSellerTraderID_SelectedIndexChanged(object sender, EventArgs e)
      {
         lblSellerTraderID.Text = cboSellerTraderID.SelectedValue == null ? "" : cboSellerTraderID.SelectedValue.ToString();
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

         //added by DUONGPT 13/08/2010
         double vol = 0;
         double.TryParse(txtVolume.Text, out vol);
         double price = 0;
         double.TryParse(txtPrice.Text, out price);
         double dbTotalValue = vol * price * CommonSettings.PriceMultipleOperandPT / 1000;
         lbTotalValue.Text = string.Format("{0:###,#}", dbTotalValue);
         /*
         CoreConnector.CustomerBalance cusBalance = new CoreConnector.CustomerBalance();            
         if (dictBuyerClients.TryGetValue(customerID, out cusBalance))
         {
             lblBuyerBalance.Text = string.Format("{0:###,#}", cusBalance.Balance);
             lblBuyerAvailBalance.Text = string.Format("{0:###,#}", cusBalance.AvailBalance);
         } */
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

      private void frmMakeNewPT1FirmDeal_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F1:
               //reset all field empty
               cboBoardType.SelectedIndex = 0;
               cboBuyerClientID.SelectedIndex = 0;
               cboSecurities.SelectedIndex = 0;
               cboSellerClientID.SelectedIndex = 0;
               //cboSellerTraderID.SelectedIndex = 0;
               txtVolume.Text = "";
               cboSecurities.Focus();
               break;
            case Keys.I:
               if (e.Control) //Ctrl + I
                  chkHalt.Checked = !chkHalt.Checked;
               break;
         }
      }

      private void chkLoadFromCore_CheckedChanged(object sender, EventArgs e)
      {
         btnLoadClientsFromCore.Enabled = chkLoadFromCore.Checked;
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
            MessageBox.Show("Khối lượng phải > 0", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      private void cboBuyerClientID_Leave(object sender, EventArgs e)
      {
         cboBuyerClientID.Text = cboBuyerClientID.Text.ToUpper();
         //try to locate
         int i = cboBuyerClientID.FindString(cboBuyerClientID.Text);
         if (i > 0)
            cboBuyerClientID.SelectedIndex = i;
      }

      private void cboSellerClientID_Leave(object sender, EventArgs e)
      {
         cboSellerClientID.Text = cboSellerClientID.Text.ToUpper();
         //try to locate
         int i = cboSellerClientID.FindString(cboSellerClientID.Text);
         if (i >= 0)
            cboSellerClientID.SelectedIndex = i;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         //update balance tuong ung
         string customerID;
         if (chkLoadFromCore.Checked && cboBuyerClientID.SelectedValue != null)
            customerID = cboBuyerClientID.SelectedValue.ToString();
         else
            customerID = cboBuyerClientID.Text;
         if (string.IsNullOrEmpty(customerID))
         {
            MessageBox.Show("Mã khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (customerID.Length != 10)
         {
            MessageBox.Show("Độ dài mã khách hàng VICS phải = 10", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         CustomerBalanceInfoResult rCus = ConnectToSBSFacade.getCustomerBalanceInfo(customerID);
         if (rCus.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(rCus.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         lblBuyerBalance.Text = string.Format("{0:###,#}", rCus.balance);
         lblBuyerAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

         //added by DUONGPT 13/08/2010
         double vol = 0;
         double.TryParse(txtVolume.Text, out vol);
         double price = 0;
         double.TryParse(txtPrice.Text, out price);
         double dbTotalValue = vol * price * CommonSettings.PriceMultipleOperandPT / 1000;
         lbTotalValue.Text = string.Format("{0:###,#}", dbTotalValue);

      }

      private void button2_Click(object sender, EventArgs e)
      {
         //update balance tuong ung
         string customerID;
         if (chkLoadFromCore.Checked && cboSellerClientID.SelectedValue != null)
            customerID = cboSellerClientID.SelectedValue.ToString();
         else
            customerID = cboSellerClientID.Text;
         if (string.IsNullOrEmpty(customerID))
         {
            MessageBox.Show("Mã khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (customerID.Length != 10)
         {
            MessageBox.Show("Độ dài mã khách hàng VICS phải = 10", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         CustomerBalanceInfoResult rCus = ConnectToSBSFacade.getCustomerBalanceInfo(customerID);
         if (rCus.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(rCus.Message, "Lỗi từ SBS Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //lblSellerBalance.Text = string.Format("{0:###,#}", rCus.balance);
         //lblSellerAvailBalance.Text = string.Format("{0:###,#}", rCus.availBalance);

         lblSellerBalance.Text = string.Format("{0:###,#}", 88180);
         lblSellerAvailBalance.Text = string.Format("{0:###,#}", 88180);

         //lay so du chung khoan tu SBS_ws
         //Added by DUONGPT 13/08/2010
         
         string StockCode = cboSecurities.SelectedValue == null ? "" : cboSecurities.SelectedValue.ToString();
         GetStockEnquiry stockEnquiry = ConnectToSBSFacade.getStockEnquiry(customerID,
             ConnectToSBSFacade.GetCurrentTranDay(Util.LoginResult.Branch.BrachCode), StockCode);
         if (stockEnquiry.Transtate != (int)TranState.Success)
         {
            MessageBox.Show(stockEnquiry.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //Modified by DUONGPT 13/08/2010
         //lblSellerSecBalance.Text = stockEnquiry.TotalQuantity.ToString();
         //lblAvailSecBalance.Text = stockEnquiry.AvaiableQuantity.ToString();
         lblSellerSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.TotalQuantity);
         lblAvailSecBalance.Text = string.Format("{0:###,#}", stockEnquiry.AvaiableQuantity);

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

      private void btnLoadClientsFromCore_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Có thể mất vài phút để lấy thông tin khách hàng từ CORE SBS, tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         try
         {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            FillClients();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            isLoadFromCore = true;
            btnLoadClientsFromCore.Enabled = false;
            if (isLoadFromCore)
               chkLoadFromCore.Enabled = false;
         }
         catch
         {
            this.Cursor = System.Windows.Forms.Cursors.Default;
         }
      }
   }
}
