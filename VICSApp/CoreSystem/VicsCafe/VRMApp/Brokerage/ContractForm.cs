using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;

namespace VRMApp.Brokerage
{
   public partial class ContractForm : FormBase
   {
      public enum Mode
      {
         None,
         Renew,
         Approve
      }
         
      public Contract Contract;
      private Mode mode = Mode.None;

      public ContractForm(Contract contract)
      {
         InitializeComponent();
         Contract = contract;
         GUIUtil.FormatTextBoxForNumber(textBoxAmount);
         GUIUtil.FormatTextBoxForCurrency(textBoxLaiNgay);
         GUIUtil.FormatTextBoxForCurrency(textBoxLaiPhat);
      }

      public ContractForm(Contract contract, Mode mode) : this(contract)
      {
         this.mode = mode;
      }

      private void ContractForm_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatDatePicker(fromDate);
         GUIUtil.FormatDatePicker(expriedDate);
         customerIdTextBox.Focus();
         if (Contract != null)
         {
            this.Text = string.Format("HĐ: {0} - Khách hàng: {1}", Contract.ContractID, Contract.CustomerID);
            customerIdTextBox.Text = Contract.CustomerID;
            trangThaiLbl.Text = Contract.ContractStatus.ToString().ToUpper();
            approvedButton.Enabled = Contract.ContractStatus == ContractStatus.ChoDuyet;
            fromDate.Enabled = saveButton.Enabled = Contract.ContractStatus == ContractStatus.None;

            if (!string.IsNullOrEmpty(Contract.ContractID))
            {
               UpdateCustomerAsset(Contract.CustomerID);

               customerNameTextBox.Text = Contract.CustomerName;
               coKyHanOption.Checked = Contract.ContractType == ContractType.CoThoiHan;
               fromDate.Value = Contract.ContractDueDate;
               expriedDate.Value = Contract.ExpiredDate;
               textBoxSoHD.Text = Contract.ContractID;
               thangKyHanNumber.Enabled = expriedDate.Enabled = mode == Mode.Renew;

               if (Contract.ContractType == ContractType.CoThoiHan)
               {
                  labelSoTienDeNghi.Text = string.Format("(Số tiền đề nghị:{0})", GUIUtil.MoneyAsString(Contract.RegisteredAmount));
                  textBoxAmount.Text = Contract.RegisteredAmount.ToString();
                  textBoxLaiNgay.Text = Contract.InterestRatePerDay.ToString();
                  textBoxLaiPhat.Text = Contract.InterestRatePenalty.ToString();
                  thangKyHanNumber.Value = Contract.ExpiredDate.Month - Contract.ContractDueDate.Month;

                  // gia han hop dong
                  if (mode == Mode.Renew)
                  {
                     textBoxAmount.Enabled = approvedButton.Visible = false;
                     saveButton.Enabled = true;
                  }
               }
            }
            else
            {
               findButton.Focus();
            }
         }
      }

      private void UpdateCustomerAsset(string customerId)
      {
         ShowWaiting("Lấy thông tin khách hàng...");
         CustAssetInfo cinfo = Util.VRMService.GetCustomerAssetInfo(Util.TokenKey, Util.CurrentTransactionDate, customerId, true);

         tongTSLbl.Text = GUIUtil.MoneyAsString(cinfo.TongTS);
         tongNoLbl.Text = GUIUtil.MoneyAsString(cinfo.TongNo);
         lblTiLeNo.Text = GUIUtil.FormatRate(cinfo.TyLeNo / 100M, true);
         tileHopTacLbl.Text = GUIUtil.FormatRate(cinfo.TyLeHopTac / 100M, true);

         if (cinfo.TyLeHopTac > 0 && cinfo.TyLeHopTac != 100)
         {
            decimal maxAmount = Math.Max(0M, (cinfo.TongNo * 100M / cinfo.TyLeHopTac - cinfo.TongTS) / (1 - 100M / cinfo.TyLeHopTac));
            soTienToiDaTextBox.Text = string.Format("Số tiền hợp tác tối đa có thể: {0}", GUIUtil.MoneyAsString(maxAmount));
            textBoxAmount.Text = maxAmount.ToString();
         }
         CloseWaiting();
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         errorProvider.Clear();
         Customer c = Util.GetCustomer(customerIdTextBox.Text);
         if (c == null)
            errorProvider.SetError(customerIdTextBox, "Sao khách hàng này tìm không ra nhỉ?");
         else
         {
            customerIdTextBox.Text = c.CustomerId;
            customerNameTextBox.Text = c.CustomerName;
            if (!c.MarginRate.HasValue)
            {
               CloseWaiting();
               CustomerForm f = new CustomerForm(c);
               f.ShowDialog();
               if (!f.IsUpdateable)
               {
                  errorProvider.SetError(customerIdTextBox, "Khách hàng này chưa thiết lập tỷ lệ hợp tác.");
                  return;
               }
            }
            UpdateCustomerAsset(c.CustomerId);
         }
         CloseWaiting();
      }

      private void approvedButton_Click(object sender, EventArgs e)
      {
         if (Contract == null || Contract.Id == 0)
            return;

         try
         {
            if (Contract.ContractType == ContractType.CoThoiHan)
            {
               string val = Util.VRMService.ValidateInTermContract(Util.TokenKey, Contract, 0);
               if (!string.IsNullOrEmpty(val))
               {
                  ShowError(val);
                  return;
               }
               Contract.ApprovalAmount = decimal.Parse(textBoxAmount.Text);
            }

            Contract.ApprovedBy = Util.LoginUser.UserName;
            Contract.ApprovedDate = DateTime.Now;
            Contract.ContractStatus = ContractStatus.DaDuyet;
            Contract = Util.VRMService.SaveContract(Util.TokenKey, Contract, 0);

            trangThaiLbl.Text = Contract.ContractStatus.ToString().ToUpper();
            approvedButton.Enabled = saveButton.Enabled = false;
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }

      private void saveButton_Click(object sender, EventArgs e)
      {
         errorProvider.Clear();
         if (fromDate.Value.DayOfYear < Util.CurrentTransactionDate.DayOfYear)
         {
            errorProvider.SetError(fromDate, "Êh, ngày hợp đồng phải lớn hơn ngày giao dịch nhá");
            return;
         }
         if (coKyHanOption.Checked && expriedDate.Value.DayOfYear > fromDate.Value.AddMonths((int)thangKyHanNumber.Value).DayOfYear)
         {
            errorProvider.SetError(expriedDate, string.Format("Này, kỳ hạn trong vòng {0} tháng mà", thangKyHanNumber.Value));
            return;
         }
         if (string.IsNullOrEmpty(customerIdTextBox.Text))
         {
            errorProvider.SetError(customerIdTextBox, "Nhập mã khách hàng vào chứ!");
            return;
         }
         if (this.mode == Mode.Renew && expriedDate.Value < Contract.ExpiredDate)
         {
            errorProvider.SetError(expriedDate, "Gia hạn hợp đồng mà ngày gia hạn lại nhỏ hơn ngày hết hạn thực tế à!?");
            return;
         }

         ContractType contractType = coKyHanOption.Checked ? ContractType.CoThoiHan : ContractType.KhongThoiHan;
         if (contractType == ContractType.KhongThoiHan && (Contract == null || Contract.ContractStatus != VRMGateway.ContractStatus.ChoDuyet))
         {
            List<Contract> contracts = new List<Contract>(Util.VRMService.FindContracts(Util.TokenKey, customerIdTextBox.Text.Trim(), contractType, DateTime.MinValue, DateTime.MaxValue, ContractStatus.None));
            if (contracts != null && contracts.Count > 0)
            {
               ShowError("Khách hàng này đã tồn tại hợp đồng KHÔNG THỜI HẠN đang hiệu lực, vì thế không thể tạo thêm hợp đồng nữa");
               return;
            }
         }

         if (Contract == null)
            Contract = new Contract();
         Contract.CustomerID = customerIdTextBox.Text.Trim();
         Contract.CustomerName = customerNameTextBox.Text.Trim();
         Contract.ContractType = contractType;
         Contract.BranchCode = Util.LoginUser.BranchCode;
         Contract.ContractDueDate = fromDate.Value;
         Contract.CreatedBy = Util.LoginUser.UserName;
         Contract.CreatedDate = DateTime.Now;
         Contract.ExpiredDate = expriedDate.Value;
         Contract.TradeCode = Util.LoginUser.TradeCode;
         Contract.ContractStatus = ContractStatus.ChoDuyet;
         int modetype = this.mode == Mode.Renew ? 1 : 0;

         if (Contract.ContractType == ContractType.CoThoiHan)
         {
            string val = Util.VRMService.ValidateInTermContract(Util.TokenKey, Contract, modetype);
            if (!string.IsNullOrEmpty(val))
            {
               ShowError(val);
               Contract = null;
               return;
            }
            Contract.RegisteredAmount = decimal.Parse(textBoxAmount.Text);
            Contract.InterestRatePenalty = decimal.Parse(textBoxLaiPhat.Text);
            Contract.InterestRatePerDay = decimal.Parse(textBoxLaiNgay.Text);
         }

         Contract = Util.VRMService.SaveContract(Util.TokenKey, Contract, modetype);
         textBoxSoHD.Text = Contract.ContractID;

         if (ShowQuestion("Lưu hoàn tất rồi đấy. Bạn muốn thoát luôn chứ?") == DialogResult.Yes)
         {
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Abort;
         this.Close();
      }

      private void coKyHanOption_CheckedChanged(object sender, EventArgs e)
      {
         textBoxAmount.Enabled = thangKyHanNumber.Enabled = coKyHanOption.Checked;
         textBoxLaiNgay.Enabled = textBoxLaiPhat.Enabled = coKyHanOption.Checked &&
                     (Contract == null || Contract.ContractStatus == ContractStatus.ChoDuyet);

         if (coKyHanOption.Checked && expriedDate.Value.DayOfYear != fromDate.Value.AddMonths((int)thangKyHanNumber.Value).DayOfYear)
            expriedDate.Value = fromDate.Value.AddMonths((int)thangKyHanNumber.Value);
         else if (khongKyHanOption.Checked && expriedDate.Value.DayOfYear > fromDate.Value.AddDays(30).DayOfYear)
            expriedDate.Value = fromDate.Value.AddDays(30);
         if (coKyHanOption.Checked && string.IsNullOrEmpty(textBoxLaiNgay.Text))
         {
            textBoxLaiNgay.Text = "0,063";
            textBoxLaiPhat.Text = "0,068";
         }
         //else if (khongKyHanOption.Checked)
         //   textBoxLaiPhat.Text = textBoxLaiNgay.Text = textBoxAmount.Text = "0";
      }

      private void fromDate_Validated(object sender, EventArgs e)
      {
         errorProvider.Clear();
         if (fromDate.Value.DayOfYear < Util.CurrentTransactionDate.DayOfYear)
            errorProvider.SetError(fromDate, "Êh, ngày hợp đồng phải lớn hơn ngày giao dịch nhá");

         if (coKyHanOption.Checked)
            expriedDate.Value = fromDate.Value.AddMonths((int)thangKyHanNumber.Value);
      }

      private void expriedDate_Validated(object sender, EventArgs e)
      {
         errorProvider.Clear();
         if (coKyHanOption.Checked && expriedDate.Value.DayOfYear > fromDate.Value.AddMonths((int)thangKyHanNumber.Value).DayOfYear)
            errorProvider.SetError(expriedDate, string.Format("Này, kỳ hạn trong vòng {0} tháng mà", thangKyHanNumber.Value));
      }

      private void thangKyHanNumber_ValueChanged(object sender, EventArgs e)
      {
         expriedDate.Value = fromDate.Value.AddMonths((int)thangKyHanNumber.Value);
      }

      private void customerIdTextBox_Validated(object sender, EventArgs e)
      {
         errorProvider.Clear();
         if (string.IsNullOrEmpty(customerIdTextBox.Text))
         {
            errorProvider.SetError(customerIdTextBox, "Nhập mã khách hàng vào chứ!");
            customerNameTextBox.Text = string.Empty;
            return;
         }

         customerIdTextBox.Text = GUIUtil.ValidateCustomerId(customerIdTextBox.Text);
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_HopDongHTKD);
      }

      private void printButton_Click(object sender, EventArgs e)
      {
         if (Contract == null)
            return;

         ReportUtil.ShowHopDongKD(Contract);
      }
   }
}
