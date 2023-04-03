using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Customer = Brokery.AgencyWebService.Customer;
using CustomerService = Brokery.AgencyWebService.CustomerService;
using GLStockCode = Brokery.AgencyWebService.GLStockCode;
using InquiryData = Brokery.AgencyWebService.InquiryData;
using Order = Brokery.AgencyWebService.Order;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Operation
{
    public partial class SubmitOrder : FormBase
    {
        private delegate void UpdateCashOnGUI(InquiryData orderInfo, bool isReset);
        private delegate void UpdateCustomerInfoOnGUI(InquiryData orderInfo, bool isReset);
        private delegate void UpdateStockOnGUI(InquiryData orderInfo, bool isReset);
        InquiryData curentInquiryData;
        private TradingSession tradingSession;
        private CustomerService service;
        private bool autoSplitOrder = false;

        public SubmitOrder()
        {
            InitializeComponent();
            txtCustomerId.Text = lblCustomerName.Text = lblBankAccount.Text = lblBank.Text = string.Empty;
            lbcardNo.Text =
                lbmobiphone.Text = lbAddress.Text = lbphone1.Text = lbPassword.Text = string.Empty;
            this.picSign1.Image = null;
            this.picSign2.Image = null;
            SetErrorTracker(errorProvider, () =>
            {
                btnQueryInfo.Enabled = Error.Count == 0
                                       && curentInquiryData != null
                                       && curentInquiryData.Customer != null
                                       && curentInquiryData.TradingStockVolume.HasValue
                                       && curentInquiryData.TradingStockPrice.HasValue;
            });
            foreach (GLStockCode s in Util.HNXStock)
                cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));
            foreach (GLStockCode s in Util.HOSEStock)
                cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));
            foreach (GLStockCode s in Util.UPCOMStock)
                cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));

            cboStock.KeyPress += new KeyPressEventHandler(GUIUtil.ToUpcaseKeyPress);
            cboPriceType.KeyPress += new KeyPressEventHandler(GUIUtil.ToUpcaseKeyPress);

            curentInquiryData = new InquiryData();

            GUIUtil.FormatTextBoxForNumber(txtVolume);
            GUIUtil.FormatTextBoxForNumber(txtIcebergVolume);
            GUIUtil.FormatTextBoxForCurrency(txtPrice);
            GUIUtil.FormatTextBoxForCurrency(txtStopPrice);

        }

        private void ResetFormState(bool isLocked, bool reset)
        {
            cboStock.Enabled = txtVolume.Enabled = cboPriceType.Enabled = txtPrice.Enabled = !isLocked;
            btnQueryInfo.Enabled = btnSubmit.Enabled = false;

            txtIcebergVolume.Enabled = txtStopPrice.Enabled = !isLocked;

            if (reset)
            {
                lblPhien.Text = lblSHL.Text = lblSHL2.Text = lblStockName.Text = lblBoard.Text = cboStock.Text = string.Empty;
                lblCeilingPrice.Text = lblFloorPrice.Text = lblPreClosedPrice.Text = txtPrice.Text = txtStopPrice.Text = "0,0";

                UpdateCashValue(curentInquiryData, true);
                UpdateStockValue(curentInquiryData, true);

                cboPriceType.Items.Clear();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UpdateCustomerInfoValue(curentInquiryData, true);

            lblMuaBan.Text = string.Empty;
            groupBox1.BackColor = SystemColors.Control;
            rdbDatMua.Checked = true;
            cboStock.Text = string.Empty;
            txtVolume.Text = "0";

            ResetFormState(true, true);
            txtCustomerId.Enabled = true;
            txtCustomerId.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override IEnumerable<AccessPermission> AccessKey
        {
            get { yield return AccessPermission.VICS_DatLenh; }
        }

        private void cboStock_Validated(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            if (curentInquiryData == null || curentInquiryData.Customer == null)
                return;

            Error.Clear(sender as Control);
            if (cboStock.SelectedItem == null)
            {
                Error.SetError(sender as Control, "Không tìm thấy mã chứng khoán, nhấn F6 để cập nhật lại tất cả các mã chứng khoán.");

                UpdateOrderTypeAndPrice(null);
                return;
            }

            MTGCComboBoxItem item = cboStock.SelectedItem;
            var stock = new Predicate<GLStockCode>(s => item.Col1.Equals(s.StockCode, StringComparison.CurrentCultureIgnoreCase));
            var stockTmp = (Util.HOSEStock.Find(stock) ?? Util.HNXStock.Find(stock)) ?? Util.UPCOMStock.Find(stock);

            cboStock.Enabled = false;
            if (!(this.backgroundWorkerCheckSideAndSession.IsBusy || this.backgroundWorkerCheckSideAndSession.CancellationPending))
                this.backgroundWorkerCheckSideAndSession.RunWorkerAsync(new object[] { stockTmp, curentInquiryData.Customer.CustomerId, curentInquiryData.OrderSide });
            else
            {
                Error.SetError(sender as Control, "Đang kiểm tra dữ liệu");
            }
        }

        private void backgroundWorkerCheckSideAndSession_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as object[];
            var stock = args[0] as GLStockCode;
            var side = args[2].ToString() == "S" ? "B" : "S";

            var result = new object[3]; // 0: message, 2: traiding session, 3: stockorder
            result[0] = string.Empty;
            //phapnx sua mua ban cung phien
            // check if exists the positive order that not match
            //var orders = Util.AgencyGateway.GetOrderList(Util.TokenKey, Util.CurrentTransactionDate, args[1].ToString(),
            //                                             stock.StockCode, "A", string.Empty, side, 0, stock.BoardType);
            //if (orders != null && orders.Any())
            //{
            //    var isExists = false;
            //    var message = string.Format("Đang tồn tại lệnh {0} chưa khớp hết:", (side == "S") ? "BÁN" : "MUA");

            //    Enumerable.All(orders, o =>
            //    {
            //        if (o.OrderStatus == "O" || o.OrderStatus == "S" || o.OrderStatus == "P" || o.OrderStatus == "E")
            //        {
            //            message += string.Format("\n   -#{0} {1} Giá: {2:n3} KL: {3:n0}", o.OrderSeq,
            //                                     o.OrderTime,
            //                                     o.PublishedPrice == 0 ? o.Price : o.PublishedPrice,
            //                                     o.PublishedVolume == 0 ? o.Volume : o.PublishedVolume);
            //            isExists = true;
            //        }
            //        return true;
            //    });
            //    if (isExists)
            //    {
            //        result[0] = message;
            //        e.Result = result;
            //        return;
            //    }
            //}

            result[1] = TradingSession.GetCurrentSession(stock.StockCode, stock.BoardType);
            result[2] = stock;
            e.Result = result;
        }

        private void backgroundWorkerCheckSideAndSession_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as object[];
            if (!string.IsNullOrEmpty(result[0].ToString()))
            {
                ShowError(result[0].ToString());
                Error.SetError(cboStock, "Tồn tại lệnh mua/bán chưa khớp.");
                cboStock.Enabled = true;
                return;
            }

            tradingSession = result[1] as TradingSession;
            var stockTmp = result[2] as GLStockCode;
            var isInvalidAndReturn = false;
            if (tradingSession.SessionStatus == SessionStatus.Halt)
            {
                isInvalidAndReturn = ShowQuestion(
                   string.Format("Chứng khoán {0} đang bị hạn chế giao dịch. Bạn có muốn tiếp tục đặt lệnh?", stockTmp.StockCode)) ==
                                     DialogResult.No;
            }
            else if (tradingSession.SessionStatus == SessionStatus.Delay)
            {
                isInvalidAndReturn = ShowQuestion(
                   string.Format("Chứng khoán {0} đang bị tạm dừng giao dịch. Bạn có muốn tiếp tục đặt lệnh?", stockTmp.StockCode)) ==
                                     DialogResult.No;
            }

            if (tradingSession.SessionStatus == SessionStatus.Empty || tradingSession.SessionStatus == SessionStatus.End)
            {
                ShowError(string.Format("Chứng khoán {0} đang bị tạm dừng giao dịch. Bạn không thể đặt lệnh được.",
                                        stockTmp.StockCode));
                isInvalidAndReturn = true;
            }

            if (tradingSession.SessionType == SessionType.EndSession || (stockTmp.BoardType == Util.HNXBoard && tradingSession.SessionType == SessionType.PostCloseSession))
            {
                const string message = "Đã hết phiên giao dịch, không thể nhập lệnh vào hệ thống";
                ShowError(message);
                btnUndo.PerformClick();
                return;
            }

            if (isInvalidAndReturn)
            {
                cboStock.Enabled = true;
                cboStock.Select();
                return;
            }

            lblBoard.Text = stockTmp.BoardName;
            lblStockName.Text = stockTmp.StockName;

            cboStock.Enabled = true;
            UpdateOrderTypeAndPrice(stockTmp);
        }

        private void UpdateOrderTypeAndPrice(GLStockCode newStock)
        {
            if (newStock == null)
            {
                cboPriceType.Items.Clear();
                lblCeilingPrice.Text = lblPreClosedPrice.Text = lblFloorPrice.Text = "0,0";
                curentInquiryData.TradingStock = null;
                lblPhien.Text = string.Empty;
                return;
            }

            if (curentInquiryData.TradingStock == null || curentInquiryData.TradingStock.StockCode != newStock.StockCode)
            {
                cboPriceType.Items.Clear();
                if (newStock.BoardType == Util.HOSEBoard)
                {
                    if (tradingSession.SessionType == SessionType.OpenSession || tradingSession.SessionType == SessionType.None)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATO", "ATC", "MP" });
                    else if (tradingSession.SessionType == SessionType.ContSession)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATC", "MP" });
                    else if (tradingSession.SessionType == SessionType.CloseSession)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATC" });
                }
                else if (newStock.BoardType == Util.HNXBoard)
                {
                    if (tradingSession.SessionType == SessionType.OpenSession || tradingSession.SessionType == SessionType.None)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATC", "MAK", "MOK", "MTL" }); //  "SO>", "SO<", "SBO", "OBO" IO & PLO chua trien khai, ATO khong co
                    else if (tradingSession.SessionType == SessionType.ContSession)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATC", "MAK", "MOK", "MTL" });
                    else if (tradingSession.SessionType == SessionType.CloseSession)
                        cboPriceType.Items.AddRange(new string[] { "LO", "ATC" });
                    //else if (tradingSession.SessionType == SessionType.PostCloseSession)
                    //   cboPriceType.Items.AddRange(new string[] { "PLO" });
                }
                else if (newStock.BoardType == Util.UPCOMBoard)
                {
                    cboPriceType.Items.Add("LO");
                }

                curentInquiryData.Session = (int)tradingSession.SessionType;
                lblPhien.Text = curentInquiryData.Session.ToString();
                cboPriceType.SelectedIndex = 0;
            }


            if (curentInquiryData.TradingStock == null || curentInquiryData.TradingStock.StockCode != newStock.StockCode)
            {
                lblCeilingPrice.Text = newStock.CeilingPrice.ToString("N3");
                lblPreClosedPrice.Text = newStock.BasicPrice.ToString("N3");
                lblFloorPrice.Text = newStock.FloorPrice.ToString("N3");
            }

            if (cboPriceType.Text == "ATO" || cboPriceType.Text == "ATC" || cboPriceType.Text == "MP" ||
                cboPriceType.Text == "MOK" || cboPriceType.Text == "MAK" || cboPriceType.Text == "MTL" ||
                cboPriceType.Text == "SBO" || cboPriceType.Text == "OBO")
            {
                if (curentInquiryData.OrderSide == OrderSide.B)
                {
                    curentInquiryData.TradingStockPrice = newStock.CeilingPrice;
                    txtPrice.Text = newStock.CeilingPrice.ToString("N3");
                }
                else
                {
                    curentInquiryData.TradingStockPrice = newStock.FloorPrice;
                    txtPrice.Text = newStock.FloorPrice.ToString("N3");
                }

                txtPrice.Enabled = false;
            }
            else
                txtPrice.Enabled = true;

            curentInquiryData.TradingStockPriceType = cboPriceType.Text;
            curentInquiryData.TradingStock = newStock;

            if (cboPriceType.Text.StartsWith("SO"))
            {
                lblExtra.Text = "Giá dừng:";
                if (!curentInquiryData.StopPrice.HasValue)
                    txtStopPrice.Text = txtPrice.Text;
                lblExtra.Visible = txtStopPrice.Visible = true;
                txtIcebergVolume.Visible = false;
            }
            else if (cboPriceType.Text == "IO")
            {
                lblExtra.Text = "Khối lượng đỉnh:";
                if (!curentInquiryData.IcebergVolume.HasValue)
                    txtIcebergVolume.Text = txtVolume.Text;
                lblExtra.Visible = txtIcebergVolume.Visible = true;
                txtStopPrice.Visible = false;
            }
            else
            {
                lblExtra.Visible = txtIcebergVolume.Visible = txtStopPrice.Visible = false;
            }

            txtVolume_Validated(null, null);
        }

        private void cboStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboStock.DroppedDown == false)
                cboStock.DroppedDown = true;
        }

        private void SubmitOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                if (!(this.backgroundWorkerUpdateStock.IsBusy || this.backgroundWorkerUpdateStock.CancellationPending))
                    this.backgroundWorkerUpdateStock.RunWorkerAsync();
                else
                {
                    ShowNotice("Đang cập nhật tất cả mã chứng khoán.");
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                MessageBox.Show(ActiveControl.Name + " Tab index " + ActiveControl.TabIndex);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (ActiveControl != txtCustomerId)
                {
                    curentInquiryData = new InquiryData();
                    btnUndo.PerformClick();
                    txtCustomerId.Select();
                }
                else
                {
                    txtCustomerId.Text = string.Empty;
                }
            }
        }

        private void backgroundWorkerUpdateStock_DoWork(object sender, DoWorkEventArgs e)
        {
            var hoseStocks = Util.AgencyGateway.GetStockList(Util.TokenKey, Util.HOSEBoard);
            var hnxStocks = Util.AgencyGateway.GetStockList(Util.TokenKey, Util.HNXBoard);
            var upcomStocks = Util.AgencyGateway.GetStockList(Util.TokenKey, Util.UPCOMBoard);

            e.Result = new[] { hoseStocks, hnxStocks, upcomStocks };
        }

        private void backgroundWorkerUpdateStock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                ShowError(e.Error.Message);
            if (e.Result != null)
            {
                var result = e.Result as object[];
                Util.UpdateAllStocks(result[0] as GLStockCode[], result[1] as GLStockCode[], result[2] as GLStockCode);

                cboStock.Items.Clear();
                foreach (GLStockCode s in Util.HNXStock)
                    cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));
                foreach (GLStockCode s in Util.HOSEStock)
                    cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));
                foreach (GLStockCode s in Util.UPCOMStock)
                    cboStock.Items.Add(new MTGCComboBoxItem(s.StockCode, s.StockName, string.Empty, string.Empty));
                ShowNotice("Đã cập nhật xong tất cả các mã chứng khoán.");
            }
        }

        private void cboPriceType_Validated(object sender, EventArgs e)
        {
            Error.Clear(sender as Control);
            if (curentInquiryData == null)
                return;

            UpdateOrderTypeAndPrice(curentInquiryData.TradingStock);

            if (!txtPrice.Enabled && !txtStopPrice.Visible && !txtIcebergVolume.Visible && btnQueryInfo.Enabled)
                btnQueryInfo.Focus();
        }

        private void txtVolume_Validated(object sender, EventArgs e)
        {
            Error.Clear(txtVolume);

            if (curentInquiryData == null || curentInquiryData.TradingStock == null)
                return;

            curentInquiryData.TradingStockVolume = null;

            try
            {
                curentInquiryData.TradingStockVolume = int.Parse(txtVolume.Text.Replace(".", string.Empty));
            }
            catch
            {
                Error.SetError(txtVolume, "Khối lượng không hợp lệ");
                return;
            }
            ValidateStockVolume();
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;

            if (curentInquiryData == null)
                return;

            curentInquiryData.TradingStockPrice = null;

            try
            {
                curentInquiryData.TradingStockPrice = decimal.Parse(txtPrice.Text);
            }
            catch
            {
                curentInquiryData.TradingStockPrice = null;
                Error.SetError(sender as Control, "Giá không hợp lệ");
                return;
            }

            if (curentInquiryData.TradingStock == null)
                return;

            if (curentInquiryData.TradingStockPrice < curentInquiryData.TradingStock.FloorPrice)
            {
                curentInquiryData.TradingStockPrice = null;
                Error.SetError(sender as Control, "Giá không được thấp hơn giá sàn");
                return;
            }

            if (curentInquiryData.TradingStockPrice > curentInquiryData.TradingStock.CeilingPrice)
            {
                curentInquiryData.TradingStockPrice = null;
                Error.SetError(sender as Control, "Giá không được cao hơn giá trần");
                return;
            }

            // price lot validation
            var getPriceLot = new Func<decimal?, int>(price =>
            {
                if (price < 10000) return 10;
                if (price >= 50000) return 100;
                return 50;
            });
            var priceLost = curentInquiryData.TradingStock.StockType == Util.HOSEETFType
                ? 10
                : getPriceLot(curentInquiryData.TradingStockPrice * 1000);

            if (curentInquiryData.TradingStockPrice * 1000 % priceLost != 0)
            {
                curentInquiryData.TradingStockPrice = null;
                Error.SetError(sender as Control, string.Format("Giá đặt phải tròn lô {0:n0}", priceLost));
                return;
            }

            Error.Clear(txtPrice);
            if (!txtStopPrice.Visible && !txtIcebergVolume.Visible && btnQueryInfo.Enabled)
                btnQueryInfo.Focus();
        }

        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                rdbDatMua.Focus();
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            rdbDatMua.Enabled = rdbBan.Enabled = !string.IsNullOrEmpty(txtCustomerId.Text);
        }

        private void txtCustomerId_Validated(object sender, EventArgs e)
        {
            Error.Clear(txtCustomerId);
            if (string.IsNullOrEmpty(txtCustomerId.Text))
            {
                Error.SetError(txtCustomerId, "Mã khách hàng không được để trống");
                return;
            }

            txtCustomerId.Text = GUIUtil.ValidateCustomerId(txtCustomerId.Text);
            if (curentInquiryData.Customer == null || curentInquiryData.Customer.CustomerId != txtCustomerId.Text)
            {
                if (
                    !(this.backgroundWorkerCustomerDetail.IsBusy ||
                      this.backgroundWorkerCustomerDetail.CancellationPending))
                {
                    this.backgroundWorkerCustomerDetail.RunWorkerAsync(txtCustomerId.Text);
                    // update services
                    var services = Util.AgencyGateway.GetCustomerServices(Util.TokenKey, txtCustomerId.Text);
                    if (services.Any())
                        this.service = services.FirstOrDefault();
                    else
                        this.service = null;
                }

                else
                {
                    Error.SetError(txtCustomerId, "Đang kiểm tra mã khách hàng");
                }
            }
            else
            {
                UpdateCustomerInfoValue(curentInquiryData, false);
                SetOrderMode(rdbDatMua.Checked ? OrderSide.B : OrderSide.S);
            }
        }

        private void backgroundWorkerCustomerDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Util.GetCustomer(e.Argument.ToString());
        }

        private void backgroundWorkerCustomerDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var customer = e.Result as Customer;
            if (customer == null)
            {
                rdbDatMua.Enabled = rdbBan.Enabled = btnUndo.Enabled = false;
                Error.SetError(txtCustomerId, "Mã khách hàng không tồn tại");
                curentInquiryData.Customer = null;
                UpdateCustomerInfoValue(curentInquiryData, true);
                txtCustomerId.Focus();
            }
            else
            {
                btnUndo.Enabled = true;
                txtCustomerId.Enabled = false;
                curentInquiryData.Customer = customer;
                UpdateCustomerInfoValue(curentInquiryData, false);
                SetOrderMode(OrderSide.B);
                rdbDatMua.Select();
            }
        }

        public static Image ParseFromByte(byte[] data)
        {
            if (data == null)
                return null;

            System.IO.MemoryStream stream = new System.IO.MemoryStream(data);
            return Image.FromStream(stream);
        }
        private void UpdateCustomerInfoValue(InquiryData orderInfo, bool isReset)
        {
            if (InvokeRequired)
            {
                base.Invoke(new UpdateCustomerInfoOnGUI(UpdateCustomerInfoValue),
                   new object[] { orderInfo, isReset });
            }
            else
            {
                if (isReset)
                {
                    txtCustomerId.Text = lblCustomerName.Text = lblBankAccount.Text = lblBank.Text = string.Empty;
                    lbcardNo.Text =
                        lbmobiphone.Text = lbAddress.Text = lbphone1.Text = lbPassword.Text = string.Empty;
                    this.picSign1.Image = null;
                    this.picSign2.Image = null;
                }
                else
                {
                    lblCustomerName.Text = curentInquiryData.Customer.CustomerNameViet;
                    lblBankAccount.Text = curentInquiryData.Customer.CIF;
                    lblBank.Text = string.Format("Tài khoản tiền tại ngân hàng {0}", curentInquiryData.Customer.BankCode);
                    lbcardNo.Text = curentInquiryData.Customer.CardIdentity;
                    lbmobiphone.Text = curentInquiryData.Customer.Mobile;
                    lbAddress.Text = curentInquiryData.Customer.AddressViet;
                    if (service != null)
                    {
                        lbphone1.Text = service.Mobile;
                        lbPassword.Text = service.Reserved;
                    }
                    else
                    {
                        lbphone1.Text = lbPassword.Text = string.Empty;
                    }
                    this.picSign1.Image = ParseFromByte(curentInquiryData.Customer.SignatureImage1);
                    this.picSign2.Image = ParseFromByte(curentInquiryData.Customer.SignatureImage2);

                }
            }
        }

        private void UpdateCashValue(InquiryData orderInfo, bool isReset)
        {
            if (InvokeRequired)
            {
                base.Invoke(new UpdateCashOnGUI(UpdateCashValue),
                   new object[] { orderInfo, isReset });
            }
            else
            {
                if (isReset)
                {
                    lblDayTradingAmount.Text = lblUsableAmount.Text = lblUsagableAmountLater.Text = lblTotalLosingAmount.Text =
                       lblLimitAmount.Text = lblBlockAmount.Text = lblOrderValue.Text = lblLooseAmount.Text = lblOrderableAmount.Text =
                       Util.MoneyAsString(0M);
                }
                else
                {
                    decimal avlAmount = orderInfo.AvaiableBalance - orderInfo.TradingValue - orderInfo.TradingFee;

                    lblDayTradingAmount.Text = Util.MoneyAsString(orderInfo.BoughtCash + orderInfo.TradingValue + orderInfo.TradingFee);
                    lblUsableAmount.Text = Util.MoneyAsString(orderInfo.AvaiableBalance);
                    lblUsagableAmountLater.Text = Util.MoneyAsString(Math.Max(avlAmount, 0M));
                    lblTotalLosingAmount.Text = Util.MoneyAsString((orderInfo.CurrentLimitValue * -1M) + Math.Min(avlAmount, 0M));
                    lblLimitAmount.Text = Util.MoneyAsString(orderInfo.LitmitValue);
                    lblBlockAmount.Text = Util.MoneyAsString(orderInfo.BlockBalance);
                    lblOrderValue.Text = Util.MoneyAsString(orderInfo.TradingValue + orderInfo.TradingFee);
                    lblLooseAmount.Text = Util.MoneyAsString(Math.Min(avlAmount, 0M));
                    lblOrderableAmount.Text = Util.MoneyAsString(orderInfo.CustomerLimitDebit);
                }
            }
        }

        private void UpdateStockValue(InquiryData orderInfo, bool isReset)
        {
            if (InvokeRequired)
            {
                base.Invoke(new UpdateStockOnGUI(UpdateStockValue),
                   new object[] { orderInfo, isReset });
            }
            else
            {
                if (isReset)
                {
                    txtVolume.Text = lblAvailStockLater.Text = lblDayTradingStock.Text = lblAvailStockLater.Text = txtIcebergVolume.Text =
                       lblDayTradingStock.Text = Util.FormatNumber(0M);
                }
                else
                {
                    lblAvailStock.Text = Util.FormatNumber(curentInquiryData.BeginStock);
                    lblHoldingStock.Text = Util.FormatNumber(curentInquiryData.MortageStock);
                    if (curentInquiryData.OrderSide == OrderSide.S)
                    {
                        lblAvailStockLater.Text = Util.FormatNumber(curentInquiryData.BeginStock - (curentInquiryData.TradingStockVolume + curentInquiryData.SoldStock));
                        lblDayTradingStock.Text = Util.FormatNumber(curentInquiryData.SoldStock + curentInquiryData.TradingStockVolume);
                    }
                    else
                        lblAvailStockLater.Text = Util.FormatNumber(curentInquiryData.BeginStock);
                }
            }
        }

        private bool ValidateCash()
        {
            if (curentInquiryData.OrderSide == OrderSide.S)
                return true;

            decimal avlAmount = curentInquiryData.AvaiableBalance - curentInquiryData.TradingValue - curentInquiryData.TradingFee;
            decimal tongTienThieu = (curentInquiryData.CurrentLimitValue * -1M) + Math.Min(avlAmount, 0M);
            if (tongTienThieu < (curentInquiryData.LitmitValue * -1M))
            {
                ShowError("Khách hàng không đủ tiền để thực hiện lệnh.");
                return false;
            }
            if (avlAmount < 0M)
            {
                if (ShowQuestion("Số dư tiền mặt không đủ để đặt lệnh mua. Bạn có đồng ý đặt lệnh?") == DialogResult.No)
                    return false;
                curentInquiryData.Notes = string.Format("MUA THIEU:{0}", Util.LoginUser.UserName);
                curentInquiryData.AlertCode = "C";
            }
            return true;
        }

        private bool ValidateStock()
        {
            if (!ValidateStockVolume())
                return false;

            if (curentInquiryData.OrderSide == OrderSide.S)
            {
                long avlVol = curentInquiryData.BeginStock - curentInquiryData.SoldStock - curentInquiryData.TradingStockVolume.Value;
                if (avlVol < 0)
                {
                    ShowError("Số lượng bán chứng khoán vượt quá khối lượng đang có.");
                    return false;
                }
            }

            if (curentInquiryData.TradingStockPriceType == "IO")
            {
                if (!curentInquiryData.IcebergVolume.HasValue)
                {
                    ShowError(
                       "Lệnh tảng băng (IO) yều cầu phải nhập khối lượng tảng băng là khối lượng hiển thị đến nhà đầu tư.");
                    return false;
                }

                if (curentInquiryData.IcebergVolume.Value % 100 != 0)
                {
                    ShowError("Khối lượng tảng băng của lệnh IO phải tròn lô 100.");
                    return false;
                }

                if (curentInquiryData.IcebergVolume.Value <= 0)
                {
                    ShowError("Khối lượng tảng băng của lệnh IO phải > 0.");
                    return false;
                }

                if (curentInquiryData.IcebergVolume.Value > curentInquiryData.TradingStockVolume.Value)
                {
                    ShowError("Khối lượng tảng băng của lệnh IO không được vượt quá " + Util.HOSE_MAX_VOLUME.ToString());
                    return false;
                }
            }

            if (curentInquiryData.TradingStockPriceType.StartsWith("SO") && !curentInquiryData.StopPrice.HasValue)
            {
                ShowError("Lệnh giới hạn (SO) yều cầu phải nhập giá dừng.");
                return false;
            }

            return true;
        }

        private bool ValidateStockVolume()
        {
            btnSubmit.Enabled = false;

            if (curentInquiryData == null)
                return false;

            if (curentInquiryData.TradingStockVolume == null || curentInquiryData.TradingStockVolume.Value == 0)
            {
                Error.SetError(txtVolume, "Số lượng phải > 0");
                curentInquiryData.TradingStockVolume = null;
                return false;
            }

            if (curentInquiryData.TradingStock.BoardType == Util.HOSEBoard)
            {
                if (curentInquiryData.TradingStockVolume.Value % 10 != 0)
                {
                    Error.SetError(txtVolume, "Số lượng phải tròn theo lô 10");
                    curentInquiryData.TradingStockVolume = null;
                    return false;
                }
                else if (!autoSplitOrder &&
                         (curentInquiryData.TradingStockVolume.Value > Util.HOSE_MAX_VOLUME - curentInquiryData.TradingStock.BoardLot) &&
                         (cboPriceType.Text != "PT"))
                {
                    var result = ShowQuestion(string.Format("Số lượng không được vượt quá {0}. \nBạn có đồng ý chương trình tự động chia nhỏ thành nhiều lệnh?", Util.HOSE_MAX_VOLUME));
                    if (result == DialogResult.No)
                    {
                        autoSplitOrder = false;
                        Error.SetError(txtVolume, "Số lượng không được vượt quá " + Util.HOSE_MAX_VOLUME.ToString());
                        curentInquiryData.TradingStockVolume = null;
                        return false;
                    }
                    autoSplitOrder = true;
                }
            }
            else if (curentInquiryData.TradingStock.BoardType == Util.HNXBoard || curentInquiryData.TradingStock.BoardType == Util.UPCOMBoard)
            {
                if (curentInquiryData.TradingStockPriceType == "LO")
                {
                    if (curentInquiryData.TradingStockVolume.Value > 99 && curentInquiryData.TradingStockVolume.Value % 100 != 0)
                    {
                        Error.SetError(txtVolume, "Số lượng phải tròn theo lô 100");
                        curentInquiryData.TradingStockVolume = null;
                        return false;
                    }
                }
                else if (curentInquiryData.TradingStockVolume.Value % 100 != 0)
                {
                    Error.SetError(txtVolume, "Số lượng phải tròn theo lô 100");
                    curentInquiryData.TradingStockVolume = null;
                    return false;
                }
                else if ((curentInquiryData.TradingStockVolume.Value > Util.HNX_MAX_VOLUME - curentInquiryData.TradingStock.BoardLot) && (cboPriceType.Text != "PT"))
                {
                    Error.SetError(txtVolume, "Số lượng không được vượt quá " + Util.HNX_MAX_VOLUME.ToString());
                    curentInquiryData.TradingStockVolume = null;
                    return false;
                }
            }

            if (curentInquiryData.OrderSide == OrderSide.S && curentInquiryData.CustomerBalance != null)
            {
                long avlVol = curentInquiryData.BeginStock - curentInquiryData.SoldStock - curentInquiryData.TradingStockVolume.Value;
                if (avlVol < 0)
                {
                    Error.SetError(txtVolume, "Số lượng bán chứng khoán vượt quá khối lượng đang có.");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateAllValues()
        {
            return curentInquiryData != null &&
                   !string.IsNullOrEmpty(curentInquiryData.Customer.CustomerId) &&
                   curentInquiryData.TradingStockVolume.HasValue &&
                   curentInquiryData.TradingStockPrice.HasValue &&
                   curentInquiryData.TradingStock != null;
        }

        private void btnQueryInfo_Click(object sender, EventArgs e)
        {
            if (!ValidateAllValues())
            {
                ShowWaring("Dữ liệu còn thiếu hoặc không hợp lệ để vấn tin. Vui lòng thông tin đầy đủ.");
                return;
            }

            if (!(this.backgroundWorkerQueryCash.IsBusy || this.backgroundWorkerQueryCash.CancellationPending))
            {
                this.ShowWaiting("Đang vấn tin...");
                this.btnQueryInfo.Enabled = this.btnSubmit.Enabled = false;
                this.backgroundWorkerQueryCash.RunWorkerAsync();
            }
        }

        private void backgroundWorkerQueryCash_DoWork(object sender, DoWorkEventArgs e)
        {
            this.CloseWaiting();
            if (curentInquiryData.Customer == null)
            {
                ShowNotice("Tài khoản khách hàng không được để trống");
                return;
            }

            InquiryData inquiryData = Util.GetInquiryData(curentInquiryData);
            if (inquiryData.Customer == null)
                //ShowError("Không tìm thấy thông tin khách hàng");
                curentInquiryData.Customer.CustomerId = "";
            else
                curentInquiryData = inquiryData;

            if (curentInquiryData.TradingStock == null && !ValidateAllValues())
                return;

            UpdateCustomerInfoValue(curentInquiryData, false);
            UpdateStockValue(curentInquiryData, false);

            if (curentInquiryData.OrderSide == OrderSide.B)
                UpdateCashValue(curentInquiryData, false);
        }

        private void backgroundWorkerQueryCash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnQueryInfo.Enabled = true;
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                txtCustomerId.SelectionStart = 0;
                txtCustomerId.SelectionLength = txtCustomerId.Text.Length;
                btnUndo.Select();
                return;
            }
            else
            {
                this.btnSubmit.Enabled = true;
                this.btnSubmit.Select();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateAllValues())
            {
                ShowWaring("Dữ liệu còn thiếu hoặc sai, xin vui lòng điều chỉnh lại trước khi nhập lệnh.");
                return;
            }
            if (!ValidateStock())
                return;
            if (!ValidateCash())
                return;

            ResetFormState(true, false);

            if (!(this.backgroundWorkerSubmit.IsBusy || this.backgroundWorkerSubmit.CancellationPending))
                this.backgroundWorkerSubmit.RunWorkerAsync();
        }


        private void backgroundWorkerSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Util.AgencyGateway.SubmitOrderInfo(Util.TokenKey, curentInquiryData, Util.CurrentTransactionDate);
        }

        private void backgroundWorkerSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                ResetFormState(false, false);
                return;
            }

            ShowSubmitedOrdersValue(e.Result as Order[]);
            GetOrderForApproveOrCancel();
            btnDuyetLenh.Select();
        }

        private void ShowSubmitedOrdersValue(Order[] orders)
        {
            StringBuilder msg = new StringBuilder();
            if (orders.Length > 1)
            {
                msg.AppendFormat("Có {0} lệnh đã được đưa vào hệ thống:\n\n", orders.Length);
                foreach (Order o in orders)
                    msg.AppendFormat("\t#SHL:{0} giờ:{1} - {2}\n", o.OrderSeq, o.OrderTime, BuildInquiryData(o));
            }
            else
            {
                msg.Append("Lệnh đã được đưa vào hệ thống");
            }
            ShowNotice(msg.ToString());
            lblSHL.Text = orders[0].OrderSeq.ToString("n0");
            lblSHL2.Text = orders[0].OrderTime;
        }

        private static string BuildInquiryData(Order order)
        {
            return string.Format("SL: {0} giá: {1}", Util.FormatNumber(order.Volume), Util.MoneyAsString(order.Price));
        }

        private void SubmitOrder_Load(object sender, EventArgs e)
        {
            cboStock.DropDownWidth = 720;
            cboStock.DropDownHeight = 220;
            cboStock.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown;

            GetOrderForApproveOrCancel();
            ResetFormState(true, true);
            txtCustomerId.Select();
            txtCustomerId.Focus();
        }

        private void txtVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                cboPriceType.Select();
        }

        private void cboPriceType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPrice.Select();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtStopPrice.Enabled)
                    txtStopPrice.Select();
                else
                {
                    btnQueryInfo.Select();
                }
            }
        }



        private void txtIcebergVolume_Validated(object sender, EventArgs e)
        {
            Error.Clear(txtIcebergVolume);
            if (curentInquiryData == null)
                return;

            curentInquiryData.IcebergVolume = null;

            int icebergVolume;
            if (!int.TryParse(txtIcebergVolume.Text.Replace(".", string.Empty), out icebergVolume))
            {
                Error.SetError(txtIcebergVolume, "Khối lượng đỉnh không hợp lệ");
                return;
            }

            if (!curentInquiryData.TradingStockVolume.HasValue)
                return;

            if (icebergVolume <= 0)
            {
                Error.SetError(txtIcebergVolume, "Khối lượng đỉnh phải > 0");
                return;
            }

            if (icebergVolume > curentInquiryData.TradingStockVolume.Value)
            {
                Error.SetError(txtIcebergVolume, "Khối lượng đỉnh không được vượt quá khối lượng đặt.");
                return;
            }

            if (icebergVolume % 100 != 0)
            {
                Error.SetError(txtIcebergVolume, "Khối lượng đỉnh phải tròn theo lô 100");
                return;
            }

            curentInquiryData.IcebergVolume = icebergVolume;
        }


        private void txtStopPrice_Validated(object sender, EventArgs e)
        {
            Error.Clear(txtStopPrice);

            if (curentInquiryData == null)
                return;

            curentInquiryData.StopPrice = null;

            decimal stopPrice;
            if (!decimal.TryParse(txtStopPrice.Text, out stopPrice))
            {
                Error.SetError(txtStopPrice, "Giá dừng không hợp lệ.");
                return;
            }


            if (curentInquiryData.TradingStock == null && !curentInquiryData.TradingStockPrice.HasValue)
                return;


            if (stopPrice < curentInquiryData.TradingStock.FloorPrice)
            {
                Error.SetError(txtStopPrice, "Giá dừng không được thấp hơn giá sàn");
                return;
            }

            if (stopPrice > curentInquiryData.TradingStock.CeilingPrice)
            {
                Error.SetError(txtStopPrice, "Giá dừng không được cao hơn giá trần");
                return;
            }

            curentInquiryData.StopPrice = stopPrice;
        }

        private void txtIcebergVolume_TextChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
        }

        private void txtStopPrice_TextChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
        }

        private void cboPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;

            if (cboPriceType.Text == "ATO" || cboPriceType.Text == "ATC" || cboPriceType.Text == "MP" ||
                cboPriceType.Text == "MOK" || cboPriceType.Text == "MAK" || cboPriceType.Text == "MTL" ||
                cboPriceType.Text == "SBO" || cboPriceType.Text == "OBO")
            {
                txtPrice.Enabled = false;
                Error.Clear(txtPrice);
            }
            else
            {
                txtPrice.Enabled = true;
            }

            if (cboPriceType.Text.StartsWith("SO"))
            {
                lblExtra.Text = "Giá dừng:";
                lblExtra.Visible = txtStopPrice.Visible = true;
                txtIcebergVolume.Visible = false;
                Error.Clear(txtIcebergVolume);
            }
            else if (cboPriceType.Text == "IO")
            {
                lblExtra.Text = "Khối lượng đỉnh:";
                lblExtra.Visible = txtIcebergVolume.Visible = true;
                txtStopPrice.Visible = false;
                Error.Clear(txtStopPrice);
            }
            else
            {
                lblExtra.Visible = txtIcebergVolume.Visible = txtStopPrice.Visible = false;
                Error.Clear(txtStopPrice);
                Error.Clear(txtIcebergVolume);
            }
        }

        private void duyệtLệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridOrder.SelectedRows.Count <= 0)
                return;

            if (gridOrder.SelectedRows.Count > 1)
            {
                var result = ShowQuestion(string.Format("Bạn có đồng ý duyệt hết {0} lệnh hiện có?", gridOrder.Rows.Count));
                if (result == DialogResult.No)
                    return;
            }

            var values =
               gridOrder.SelectedRows.Cast<DataGridViewRow>().ToDictionary(row => int.Parse(row.Cells[0].Value.ToString()),
                                                                   row => row.Cells[4].Value.ToString());

            if (!(this.backgroundWorkerApproverOrDelete.IsBusy || this.backgroundWorkerApproverOrDelete.CancellationPending))
                this.backgroundWorkerApproverOrDelete.RunWorkerAsync(new object[] { true, values });
        }

        private void hủyLệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridOrder.SelectedRows.Count <= 0)
                return;

            if (gridOrder.SelectedRows.Count > 1)
            {
                var result = ShowQuestion(string.Format("Bạn có đồng ý hủy hết {0} lệnh hiện có?", gridOrder.Rows.Count));
                if (result == DialogResult.No)
                    return;
            }

            var values =
               gridOrder.SelectedRows.Cast<DataGridViewRow>().ToDictionary(row => int.Parse(row.Cells[0].Value.ToString()),
                                                                   row => row.Cells[4].Value.ToString());

            if (!(this.backgroundWorkerApproverOrDelete.IsBusy || this.backgroundWorkerApproverOrDelete.CancellationPending))
                this.backgroundWorkerApproverOrDelete.RunWorkerAsync(new object[] { false, values });
        }

        private void GetOrderForApproveOrCancel()
        {
            lấyLạiDữLiệuToolStripMenuItem.Enabled =
               hủyLệnhToolStripMenuItem.Enabled = duyệtLệnhToolStripMenuItem.Enabled = false;

            if (!(this.backgroundWorkerGetOrders.IsBusy || this.backgroundWorkerGetOrders.CancellationPending))
                this.backgroundWorkerGetOrders.RunWorkerAsync();
        }

        private void backgroundWorkerGetOrders_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Util.AgencyGateway.GetOrderList(
                 Util.TokenKey,
                 Util.CurrentTransactionDate, string.Empty,
                 string.Empty,
                 "P",
                 Util.LoginUser.UserName,
                 string.Empty,
                 0,
                 string.Empty);
        }

        private void backgroundWorkerGetOrders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            orderBindingSource.DataSource = e.Result;
            btnDuyetLenh.Enabled =
               hủyLệnhToolStripMenuItem.Enabled = duyệtLệnhToolStripMenuItem.Enabled = gridOrder.Rows.Count > 0;
            lấyLạiDữLiệuToolStripMenuItem.Enabled = true;
        }

        private void lấyLạiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetOrderForApproveOrCancel();
        }

        private void duyệtHếtCácLệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridOrder.Rows.Count <= 0)
                return;
            if (gridOrder.Rows.Count > 1)
            {
                var result = ShowQuestion(string.Format("Bạn có đồng ý duyệt hết {0} lệnh hiện có?", gridOrder.Rows.Count));
                if (result == DialogResult.No)
                    return;
            }
            var values =
               gridOrder.Rows.Cast<DataGridViewRow>().ToDictionary(row => int.Parse(row.Cells[0].Value.ToString()),
                                                                   row => row.Cells[4].Value.ToString());

            if (!(this.backgroundWorkerApproverOrDelete.IsBusy || this.backgroundWorkerApproverOrDelete.CancellationPending))
                this.backgroundWorkerApproverOrDelete.RunWorkerAsync(new object[] { true, values });
        }

        private void gridOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                hủyLệnhToolStripMenuItem.Enabled = duyệtLệnhToolStripMenuItem.Enabled = gridOrder.SelectedRows.Count > 0;
                duyệtHếtCácLệnhToolStripMenuItem.Enabled = gridOrder.SelectedRows.Count > 1;
                lấyLạiDữLiệuToolStripMenuItem.Enabled = true;
            }
        }

        private void backgroundWorkerApprove_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var args = e.Argument as object[];
                bool forApprove = (bool)args[0];
                var values = args[1] as Dictionary<int, string>;
                foreach (var value in values)
                {
                    if (forApprove)
                        Util.AgencyGateway.ApproveOrder(Util.TokenKey, Util.CurrentTransactionDate, value.Value, value.Key);
                    else
                        Util.AgencyGateway.DeleteOrder(Util.TokenKey, Util.CurrentTransactionDate, value.Key);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                return;
            }
        }

        private void backgroundWorkerApprove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
                ShowError(e.Result.ToString());

            GetOrderForApproveOrCancel();
        }

        private void btnDuyetLenh_Click(object sender, EventArgs e)
        {
            if (gridOrder.Rows.Count <= 0)
                return;
            if (gridOrder.Rows.Count > 1)
            {
                var result = ShowQuestion(string.Format("Bạn có đồng ý duyệt hết {0} lệnh hiện có?", gridOrder.Rows.Count));
                if (result == DialogResult.No)
                    return;
            }

            var values =
               gridOrder.Rows.Cast<DataGridViewRow>().ToDictionary(row => int.Parse(row.Cells[0].Value.ToString()),
                                                                   row => row.Cells[4].Value.ToString());

            if (!(this.backgroundWorkerApproverOrDelete.IsBusy || this.backgroundWorkerApproverOrDelete.CancellationPending))
                this.backgroundWorkerApproverOrDelete.RunWorkerAsync(new object[] { true, values });
        }

        private void rdbDatMua_CheckedChanged(object sender, EventArgs e)
        {
            SetOrderMode(rdbDatMua.Checked ? OrderSide.B : OrderSide.S);
        }

        private void SetOrderMode(OrderSide orderSide)
        {
            if (curentInquiryData == null || curentInquiryData.Customer == null)
                return;

            ResetFormState(false, true);

            if (curentInquiryData.Customer != null)
            {
                var newInquiryData = new InquiryData()
                {
                    Customer = curentInquiryData.Customer
                };
                curentInquiryData = newInquiryData;
            }

            if (orderSide == OrderSide.B)
            {
                lblMuaBan.Text = "MUA";
                lblMuaBan.ForeColor = Color.Green;
                groupBox1.BackColor = Color.MistyRose;
                curentInquiryData.OrderSide = OrderSide.B;
                rdbDatMua.Checked = true;
            }
            else
            {
                lblMuaBan.Text = "BÁN";
                lblMuaBan.ForeColor = Color.Red;
                groupBox1.BackColor = Color.LightBlue;
                curentInquiryData.OrderSide = OrderSide.S;
                rdbBan.Checked = true;
            }

            txtCustomerId.Enabled = false;
        }

    }
}