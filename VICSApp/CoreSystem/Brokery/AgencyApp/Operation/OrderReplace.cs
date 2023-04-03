using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;

namespace Brokery.Operation
{
   public partial class OrderReplace : FormBase
   {
      private readonly Order modifyOrder;
      private readonly GLStockCode stock;
      private TradingSession tradingSession;

      public OrderReplace(Order modifyOrder)
      {
         tradingSession = TradingSession.GetCurrentSession(modifyOrder.StockCode, modifyOrder.BoardType);
         if (tradingSession.SessionStatus == SessionStatus.NotEdit)
         {
            ShowWaring("Trạng thái giao dịch hiện tại không cho phép sửa lệnh của chứng khoán " + modifyOrder.StockCode);
         }

         this.modifyOrder = modifyOrder;
         InitializeComponent();
         SetErrorTracker(errorProvider, () => btnSubmit.Enabled = Error.Count == 0);
         var findStock = new Predicate<GLStockCode>(
            s => modifyOrder.StockCode.Equals(s.StockCode, StringComparison.CurrentCultureIgnoreCase));

         stock = (Util.HOSEStock.Find(findStock) ?? Util.HNXStock.Find(findStock)) ??
                        Util.UPCOMStock.Find(findStock);
      }

      private void OrderReplace_Load(object sender, EventArgs e)
      {
         this.Text = this.Text + "- Sàn giao dich: " + Util.BoardTypeDescription(modifyOrder.BoardType);

         lblSHL.Text = modifyOrder.OrderSeq.ToString("n0");
         lblSHL2.Text = modifyOrder.OrderTime;
         lblLoaiLenh.Text = modifyOrder.OrderType;
         lblTaiKhoan.Text = modifyOrder.CustomerId;
         lblMaChungKhoan.Text = modifyOrder.StockCode;
         lblGiadat.Text = modifyOrder.PublishedPrice.ToString("n2");
         lblKhoiLuongDat.Text = modifyOrder.PublishedVolume.ToString("n0");
         lblSide.Text = modifyOrder.OrderSide == "B" ? "MUA" : "BÁN";

         lblCeilingPrice.Text = stock.CeilingPrice.ToString("N1");
         lblPreClosedPrice.Text = stock.BasicPrice.ToString("N1");
         lblFloorPrice.Text = stock.FloorPrice.ToString("N1");

         GUIUtil.FormatTextBoxForCurrency(txtPrice);
         GUIUtil.FormatTextBoxForNumber(txtVolume);

         if (modifyOrder.OrderType.StartsWith("SO"))
         {
            lblExtraInfo.Text = "Giá dừng:";
            lblExtra.Text = "Giá dừng cần sửa:";
            txtExtra.Visible = lblExtraInfo.Enabled = lblExtra.Enabled = true;
            txtExtra.Text = lblExtra.Text = modifyOrder.StopPrice.ToString("n2");
            GUIUtil.FormatTextBoxForCurrency(txtExtra);
         }
         else if (modifyOrder.OrderType == "IO")
         {
            lblExtraInfo.Text = "Khối lượng đỉnh:";
            lblExtra.Text = "KL đỉnh cần sửa";
            txtExtra.Visible = lblExtraInfo.Enabled = lblExtra.Enabled = true;
            txtExtra.Text = lblExtra.Text = modifyOrder.IcebergVolume.ToString("n0");
            GUIUtil.FormatTextBoxForNumber(txtExtra);
         }
         else
         {
            txtExtra.Text = lblExtraInfo.Text = lblExtra.Text = string.Empty;
            lblExtraInfo.Enabled = lblExtra.Enabled = txtExtra.Enabled = false;
         }

         lblSide.ForeColor = modifyOrder.OrderSide == "B" ? Color.Red : Color.Green;

         txtPrice.Text = modifyOrder.PublishedPrice.ToString();
         txtVolume.Text = modifyOrder.PublishedVolume.ToString();

         txtPrice.Enabled = modifyOrder.PublishedPrice > 0;
         txtVolume.Enabled = modifyOrder.PublishedVolume > 0;

         btnSubmit.Enabled = txtVolume.Enabled = txtPrice.Enabled = txtExtra.Enabled =
            tradingSession.SessionStatus != SessionStatus.NotEdit;
      }

      private void sendRequestProcess_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         decimal newPrice = (decimal)args[0];
         decimal newVolume = (decimal)args[1];
         decimal newExtra = (decimal)args[2];
         decimal holdValue = 0;

         var curentInquiryData = new InquiryData
                                    {
                                       OrderSide = modifyOrder.OrderSide == "B" ? OrderSide.B : OrderSide.S,
                                       Customer = Util.GetCustomer(modifyOrder.CustomerId),
                                       TradingStockPrice = modifyOrder.PublishedPrice,
                                       TradingStockVolume = (int)modifyOrder.PublishedVolume,
                                       TradingStock = stock,
                                    };

         if (curentInquiryData.Customer == null)
            curentInquiryData.Customer = new Customer { CustomerId = modifyOrder.CustomerId };

         // lay thong tin chung khoan, cash cua nha dau tu
         curentInquiryData = Util.GetInquiryData(curentInquiryData);

         var modifedInquiryData = new InquiryData()
                                     {
                                        OrderSide = curentInquiryData.OrderSide,
                                        Customer = curentInquiryData.Customer,
                                        TradingStock = curentInquiryData.TradingStock,
                                        TradingStockPriceType = curentInquiryData.TradingStockPriceType,
                                        TradingStockPrice = newPrice,
                                        TradingStockVolume = (int)newVolume
                                     };

         if (modifyOrder.OrderType.StartsWith("SO"))
            modifedInquiryData.StopPrice = newExtra;
         else if (modifyOrder.OrderType == "IO")
            modifedInquiryData.IcebergVolume = (int)newExtra;

         // thong tin chung khoan, cash cua nha dau tu sau khi thay doi lenh
         if (modifedInquiryData.OrderSide == OrderSide.B)
         {
            modifedInquiryData = Util.GetInquiryData(modifedInquiryData);

            holdValue = (modifedInquiryData.TradingValue - curentInquiryData.TradingValue) + (modifedInquiryData.TradingFee - curentInquiryData.TradingFee);
            decimal avlAmount = modifedInquiryData.AvaiableBalance - holdValue;
            decimal tongTienThieu = (modifedInquiryData.CurrentLimitValue * -1M) + Math.Min(avlAmount, 0M);
            if (tongTienThieu < (curentInquiryData.LitmitValue * -1M))
            {
               e.Result = "Khách hàng không đủ tiền để thực hiện lệnh.";
               return;
            }
         }
         else if (curentInquiryData.BeginStock - curentInquiryData.SoldStockNoPost - curentInquiryData.MortageStock < newVolume)
         {
            e.Result = "Số lượng bán chứng khoán vượt quá khối lượng đang có.";
            return;
         }

         Util.AgencyGateway.ModifyHnxAndUpcomOrder(Util.TokenKey, modifyOrder.BoardType, modifyOrder.OrderSeq, modifyOrder.OrderNo, curentInquiryData, modifedInquiryData, Util.CurrentTransactionDate, holdValue);
      }

      private void sendRequestProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
         }
         else
         {
            if (e.Result != null && !string.IsNullOrEmpty(e.Result.ToString()))
            {
               ShowWaring(e.Result.ToString());
               return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void btnSubmit_Click(object sender, EventArgs e)
      {
         decimal newPrice, newVolume;
         if (!decimal.TryParse(txtPrice.Text, out newPrice))
            newPrice = modifyOrder.PublishedPrice;
         if (!decimal.TryParse(txtVolume.Text, out newVolume))
            newVolume = modifyOrder.PublishedVolume;

         decimal newExtra = 0;
         if (txtExtra.Enabled && !decimal.TryParse(txtExtra.Text, out newExtra))
            newExtra = 0;

         if (newExtra == 0 && modifyOrder.OrderType == "IO") newExtra = modifyOrder.IcebergVolume;
         if (newExtra == 0 && modifyOrder.OrderType.StartsWith("SO")) newExtra = modifyOrder.StopPrice;

         btnSubmit.Enabled = false;

         if ((newPrice == modifyOrder.PublishedPrice && newVolume == modifyOrder.PublishedVolume)
            || ((modifyOrder.OrderType.StartsWith("SO") && modifyOrder.StopPrice == newExtra)
               || (modifyOrder.OrderType == "IO" && modifyOrder.IcebergVolume == newExtra)))
         {
            ShowError("Không có sự thay đổi liên quan đến lệnh đặt, yêu cầu không được xử lý");
            return;
         }

         if (!(this.sendRequestProcess.IsBusy || this.sendRequestProcess.CancellationPending))
            sendRequestProcess.RunWorkerAsync(new object[] { newPrice, newVolume, newExtra });
      }

      private void btnUndo_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void txtExtra_TextChanged(object sender, EventArgs e)
      {
         if (modifyOrder.OrderType.StartsWith("SO"))
            ValidatePrice(txtExtra);
         else
            ValidateVolume(txtExtra, modifyOrder.PublishedVolume);
      }

      private void ValidatePrice(TextBox priceTextBox)
      {
         Error.Clear(priceTextBox);

         decimal price;
         if (!decimal.TryParse(priceTextBox.Text, out price))
            Error.SetError(priceTextBox, "Không xác định được giá.");

         else if (price > stock.CeilingPrice)
            Error.SetError(priceTextBox, "Giá sửa lớn hơn giá trần.");

         else if (price < stock.FloorPrice)
            Error.SetError(priceTextBox, "Giá sửa nhỏ hơn giá sàn.");
      }

      private void ValidateVolume(TextBox volumeTextBox, decimal maxVolume)
      {
         Error.Clear(volumeTextBox);

         decimal volume;
         if (!decimal.TryParse(volumeTextBox.Text, out volume))
            Error.SetError(volumeTextBox, "Không xác định được khối lượng.");

         if (volume == 0)
            Error.SetError(volumeTextBox, "Số lượng phải > 0");

         else if (modifyOrder.OrderType != "LO" && volume > 99 && volume % 100 != 0)
            Error.SetError(txtVolume, "Số lượng phải tròn theo lô 100");

         else if (volume > maxVolume - stock.BoardLot)
            Error.SetError(txtVolume, "Số lượng không được vượt quá " + maxVolume.ToString("n0"));

         else if (modifyOrder.Volume < 100 && volume > 100)
            Error.SetError(txtVolume, "Không được phép sửa khối lượng lô lẻ sang lô chẵn (KL > 99).");
      }

      private void txtPrice_Validated(object sender, EventArgs e)
      {
         ValidatePrice(txtPrice);
      }

      private void txtVolume_Validated(object sender, EventArgs e)
      {
         var maxVolume = stock.BoardType == Util.HNXBoard ? Util.HNX_MAX_VOLUME : Util.UPCOM_MAX_VOLUME;
         ValidateVolume(txtVolume, maxVolume);
      }
   }
}
