using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Report.CustomerReport;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using CustomerService = Brokery.AgencyWebService.CustomerService;
using InquiryData = Brokery.AgencyWebService.InquiryData;
using InquiryStock = Brokery.AgencyWebService.InquiryStock;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Operation
{
   public partial class CustomerInfo : FormBase
   {
      InquiryData currentDataInfo = null;
      private delegate void UpdateCustomerInfoOnGUI(InquiryData orderInfo, bool isReset);
      private delegate void UpdateServiceInfoOnGUI(CustomerService[] services);
      private delegate void UpdateStockInfoOnGUI(InquiryStock[] stocks);
      public CustomerInfo()
      {
         InitializeComponent();
      }

      private void CustomerInfo_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatGridView(customerGrid);
         GUIUtil.FormatGridView(mainGrid);
         GUIUtil.FormatGridView(serviceGrid);
         

         loLaiDuKienBtn.Enabled = Util.CheckAccess(AccessPermission.VICS_BaoCaoLoLaiDuKien);
         btListMoneyTrans.Enabled = Util.CheckAccess(AccessPermission.VICS_LietKeGiaoDichTien);
         btListStockTrans.Enabled = Util.CheckAccess(AccessPermission.VICS_LietKeGiaoDichChungKhoan);
         lichSuGiaoDichLenhBtn.Enabled = Util.CheckAccess(AccessPermission.VICS_LietKeLichSuLenh);
         accountSumerizeReporBtn.Enabled = Util.CheckAccess(AccessPermission.VICS_BaoCaoTongHopTaiKhoan);
         this.customerIdTextBox.Select();
      }

      private void customerIdTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            findButton.PerformClick();
      }

      private void customerNameTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            findButton.PerformClick();
      }

      private void identityNumberTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            findButton.PerformClick();
      }

      private void customerGrid_SelectionChanged(object sender, EventArgs e)
      {
         BindDetailData();
      }

      private void customerGrid_DoubleClick(object sender, EventArgs e)
      {
         btnInquiryOnline.PerformClick();

         if (bindingSource.Current == null)
             return;
         CustomerDetailInfo objF = new CustomerDetailInfo((Customer)bindingSource.Current);
         objF.ShowDialog();
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         if (customerIdTextBox.Text.Trim().Length < 3)
         {
            ShowError("Bạn phải nhập vào ít nhất 3 ký tự của mã khách hàng để tìm kiếm");
            customerIdTextBox.Focus();
            return;
         }

         ShowWaiting("Đang tìm ...");

         Customer[] custs = Util.AgencyGateway.FindCustomers(Util.TokenKey, this.customerIdTextBox.Text.Trim(),
            this.customerNameTextBox.Text.Trim(), this.identityNumberTextBox.Text.Trim(), Util.LoginUser.BranchCode,
            Util.LoginUser.TradeCode);
         bindingSource.DataSource = custs;

         if (this.customerGrid.RowCount == 0)
            this.ResetInformation();
         else
            this.BindDetailData();

         CloseWaiting();
      }

      private void ResetInformation()
      {
         this.customerIdTextBox.Focus();
         this.customerIdTextBox.SelectAll();
         this.picSign1.Image = null;
         this.picSign2.Image = null;
         this.availBalanceLabel.Text = this.bankAvailBalanceLabel.Text = string.Empty;
         this.currentBalanceLabel.Text = string.Empty;
         this.boughtCashLabel.Text = string.Empty;
         this.customerDebitLabel.Text = string.Empty;
         this.mainGrid.DataSource = null;
      }

      public static Image ParseFromByte(byte[] data)
      {
         if (data == null)
            return null;

         System.IO.MemoryStream stream = new System.IO.MemoryStream(data);
         return Image.FromStream(stream);
      }

      private void BindDetailData()
      {
          if (bindingSource.DataSource == null || bindingSource.Count==0)
            return;

         currentDataInfo = new InquiryData();
         // binding userinfo
         currentDataInfo.Customer = (Customer)this.bindingSource[this.customerGrid.CurrentRow.Index];
         this.picSign1.Image = ParseFromByte(currentDataInfo.Customer.SignatureImage1);
         this.picSign2.Image = ParseFromByte(currentDataInfo.Customer.SignatureImage2);

         BindingInquiriedCustomerDetail();
      }

      private void btnInquiryOnline_Click(object sender, EventArgs e)
      {
         BindingInquiriedCustomerDetail();
      }

      private void BindingInquiriedCustomerDetail()
      {
         ShowWaiting("Đang truy vấn thông tin ...");

         if (!(this.inquiryOnlineWorker.IsBusy || this.inquiryOnlineWorker.CancellationPending))
            this.inquiryOnlineWorker.RunWorkerAsync();

         CloseWaiting();
      }

      private void inquiryOnlineWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         if (currentDataInfo == null)
            return;

         // to make the core query the cash
         currentDataInfo.OrderSide = OrderSide.B;
         try
         {
             currentDataInfo = Util.GetInquiryData(currentDataInfo);
         }
         catch (Exception ex) {
             throw new ArgumentException(ex.Message);
         }

         UpdateCustomerInfo(currentDataInfo, false);

         // update stock
         UpdateStockInfo(Util.AgencyGateway.GetCustomerStocks(Util.TokenKey, currentDataInfo.Customer.CustomerId, Util.CurrentTransactionDate));

         // update services
         UpdateServiceInfo(Util.AgencyGateway.GetCustomerServices(Util.TokenKey, currentDataInfo.Customer.CustomerId));
      }

      private void inquiryOnlineWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            UpdateCustomerInfo(null, true);
         }
         CloseWaiting();
      }

      private void UpdateCustomerInfo(InquiryData data, bool isReset)
      {
         if (InvokeRequired)
         {
            base.Invoke(new UpdateCustomerInfoOnGUI(UpdateCustomerInfo),
               new object[] { data, isReset });
         }
         else
         {

            if (isReset)
            {
               this.availBalanceLabel.Text = this.currentBalanceLabel.Text = this.bankAvailBalanceLabel.Text = this.lblLastTimeInquiry.Text =
                  this.lblLastTimeInquiry.Text = this.customerDebitLabel.Text = this.boughtCashLabel.Text = string.Empty;
            }
            else
            {
               this.availBalanceLabel.Text = Util.MoneyAsString(data.AvaiableBalance);
               this.bankAvailBalanceLabel.Text = Util.MoneyAsString(data.CustomerBalance.BankAvailBalance);
               this.currentBalanceLabel.Text = Util.MoneyAsString(data.CustomerBalance.Balance);
               this.customerDebitLabel.Text = Util.MoneyAsString(Math.Max(data.BoughtCash - data.CustomerBalance.Balance, 0));
               this.boughtCashLabel.Text = Util.MoneyAsString(data.BoughtCash);
               this.lblLastTimeInquiry.Text = string.Format("Vấn tin sang ngân hàng lần cuối: {0}", data.CustomerBalance.LasttimeInquiry);
            }
         }
      }

      private void UpdateStockInfo(InquiryStock[] stocks)
      {
         if (InvokeRequired)
         {
            base.Invoke(new UpdateStockInfoOnGUI(UpdateStockInfo),
               new object[] { stocks });
         }
         else
         {
            inquiryStockBindingSource.DataSource = stocks;
         }
      }

      private void UpdateServiceInfo(CustomerService[] data)
      {
         if (InvokeRequired)
         {
            base.Invoke(new UpdateServiceInfoOnGUI(UpdateServiceInfo),
               new object[] { data });
         }
         else
         {
            customerServiceBindingSource.DataSource = data;
         }
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_VanTin; }
      }

      private void exitBtn_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void btListMoneyTrans_Click(object sender, EventArgs e)
      {
         if (bindingSource.Current == null)
            return;

         TransactionReportCriteria.Show<TransactionReportCriteria>(
            new CreateForm(delegate() { return new TransactionReportCriteria(AccountType.Balance, (Customer)bindingSource.Current); }),
            new Predicate<TransactionReportCriteria>(delegate(TransactionReportCriteria f)
               {
                  return f.AccountType == AccountType.Balance && f.IsForCustomer;
               }));
      }

      private void btListStockTrans_Click(object sender, EventArgs e)
      {
         if (bindingSource.Current == null)
            return;

         TransactionReportCriteria.Show<TransactionReportCriteria>(
            new CreateForm(delegate() { return new TransactionReportCriteria(AccountType.Contigen, (Customer)bindingSource.Current); }),
            new Predicate<TransactionReportCriteria>(delegate(TransactionReportCriteria f)
            {
               return f.AccountType == AccountType.Contigen && f.IsForCustomer;
            }));
      }

      private void accountSumerizeReporBtn_Click(object sender, EventArgs e)
      {
         if (bindingSource.Current == null)
            return;

         CustomerGeneralReportCriteria.Show<CustomerGeneralReportCriteria>(
             new CreateForm(delegate() { return new CustomerGeneralReportCriteria((Customer)bindingSource.Current); }
                ));
      }

      private void lichSuGiaoDichLenhBtn_Click(object sender, EventArgs e)
      {
         if (bindingSource.Current == null)
            return;

         OrderHistoryReportCriteria.Show<OrderHistoryReportCriteria>(
             new CreateForm(delegate() { return new OrderHistoryReportCriteria((Customer)bindingSource.Current); }
                ));
      }

      private void loLaiDuKienBtn_Click(object sender, EventArgs e)
      {
         if (bindingSource.Current == null)
            return;

         LostAndProfitReportCriteria.Show<LostAndProfitReportCriteria>(
             new CreateForm(delegate() { return new LostAndProfitReportCriteria((Customer)bindingSource.Current); }
                ));
      }
   }
}
