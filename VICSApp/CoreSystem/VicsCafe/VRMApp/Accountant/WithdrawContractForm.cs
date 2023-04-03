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

namespace VRMApp.Accountant
{
   public partial class WithdrawContractForm : FormBase
   {
      CustAssetInfo cinfo;
      private Contract contract;
      private bool isWithdraw = false;

      public WithdrawContractForm()
      {
         InitializeComponent();
         GUIUtil.FormatTextBoxForNumber(textBoxGocPhaiThu);
         GUIUtil.FormatTextBoxForNumber(textBoxNgayQuaHan);
         GUIUtil.FormatTextBoxForNumber(ngayHTTextBox);
         GUIUtil.FormatTextBoxForCurrency(textBoxLaiPhat);
         GUIUtil.FormatTextBoxForNumber(textBoxPhiTraCham);
         GUIUtil.FormatTextBoxForCurrency(textBoxLaiNgay);
         GUIUtil.FormatTextBoxForNumber(textBoxPhiHT);
      }

      public Contract CurrentContract
      {
         get { return contract; }
         set { contract = value; }
      }

      public bool IsWithdraw
      {
         get { return isWithdraw; }
      }

      private void WithdrawContractForm_Load(object sender, EventArgs e)
      {
         if (contract != null)
         {
            UpdateContractInfo();
         }
         else
            withdrawButton.Enabled = false;
      }

      private void UpdateContractInfo()
      {
         ShowWaiting();
         customerIdTextBox.Text = contract.CustomerID;
         customerNameTextBox.Text = contract.CustomerName;
         customerIdTextBox.ReadOnly = true;
         findButton.Visible = false;
         textBoxSoHD.Text = contract.ContractID;
         textBoxLaiNgay.Text = contract.InterestRatePerDay.ToString();
         textBoxLaiPhat.Text = contract.InterestRatePenalty.ToString();
         textBoxGocPhaiThu.Text = (contract.DisbursedAmount - contract.WithdrawAmount).ToString();

         trangThaiLbl.Text = contract.ContractStatus.ToString().ToUpper();
         UpdateInfo(contract.CustomerID);

         withdrawButton.Enabled = true;

         CloseWaiting();
      }

      private void UpdateInfo(string customerId)
      {
         cinfo = Util.VRMService.GetCustomerAssetInfo(Util.TokenKey, Util.CurrentTransactionDate, customerId, true);

         tongTSLbl.Text = GUIUtil.MoneyAsString(cinfo.TongTS);
         tongNoLbl.Text = GUIUtil.MoneyAsString(cinfo.TongNo);
         lblTiLeNo.Text = GUIUtil.FormatRate(cinfo.TyLeNo / 100, true);
         tileHopTacLbl.Text = GUIUtil.FormatRate(cinfo.TyLeHopTac / 100, true);
         labelSoDuTien.Text = GUIUtil.MoneyAsString(cinfo.SoDuHienTai);

         lblFromDate.Text = contract.ContractDueDate.ToString("dd/MM/yyyy");
         lblToDate.Text = contract.ExpiredDate.ToString("dd/MM/yyyy");

         int ngayHT = (DateTime.Today - contract.ContractDueDate).Days;
         int ngayQH = DateTime.Today > contract.ExpiredDate ? (DateTime.Today - contract.ExpiredDate).Days : 0;

         ngayHTTextBox.Text = ngayHT.ToString();
         textBoxNgayQuaHan.Text = ngayQH.ToString();
      }

      private void withdrawButton_Click(object sender, EventArgs e)
      {
         if (contract == null)
         {
            ShowError("Hợp đồng không xác định");
            return;
         }
         if (cinfo == null)
         {
            ShowError("Khách hàng không xác định");
            return;
         }
         decimal phiHT, phiCham, tienGoc;
         phiHT = phiCham = tienGoc = 0M;
         if (!decimal.TryParse(textBoxPhiHT.Text, out phiHT))
         {
            ShowError("Phí hợp tác phải thu không xác định được");
            return;
         }
         if (!decimal.TryParse(textBoxPhiTraCham.Text, out phiCham))
         {
            ShowError("Phí trả chậm phải thu không xác định được");
            return;
         }
         if (!decimal.TryParse(textBoxGocPhaiThu.Text, out tienGoc))
         {
            ShowError("Tiền gốc phải thu không xác định được");
            return;
         }
         if (tienGoc <= 0 || tienGoc > contract.DisbursedAmount)
         {
            ShowError(string.Format("Số tiền gốc cần thanh lý phải nằm trong khoảng 0 đ đến {0}", GUIUtil.MoneyAsString(contract.DisbursedAmount)));
            return;
         }
         if (tienGoc + phiCham + phiHT > cinfo.SoDuHienTai)
         {
            ShowError("Số dư tiền của khách hàng không đủ để thanh lý tiền lãi và nợ gốc.");
            return;
         }
         try
         {
            string note = string.Format("(PHI HT {0}/{1} NGAY, PHI TRA CHAM {2}/{3} NGAY)",
               textBoxLaiNgay.Text, ngayHTTextBox.Text,
               textBoxLaiPhat.Text, textBoxNgayQuaHan.Text);
            Util.VRMService.WithdrawContract(Util.TokenKey, contract, tienGoc, phiHT + phiCham, note);
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
            return;
         }
         contract.WithdrawDate = DateTime.Now;
         contract.WithdrawBy = Util.LoginUser.UserName;
         contract.WithdrawAmount += tienGoc;
         contract.InterestAmount += phiCham + phiHT;
         if (contract.WithdrawAmount == contract.DisbursedAmount)
            contract.ContractStatus = ContractStatus.KetThuc;
         isWithdraw = true;

         this.Close();
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         isWithdraw = false;
         this.Close();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_ThanhLyHopHong);
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         contract = Util.VRMService.GetCurrentContract(Util.TokenKey, customerIdTextBox.Text);
         if (contract != null)
         {
            if (contract.ContractType == ContractType.CoThoiHan && contract.ContractStatus == ContractStatus.DaGiaiNgan)
               UpdateContractInfo();
            else
            {
               contract = null;
               ShowError("Khách hàng hiện tại không có hợp đồng để thanh lý");
            }
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         int ngayHT = int.Parse(ngayHTTextBox.Text);
         int ngayQH = int.Parse(textBoxNgayQuaHan.Text);
         decimal noGoc = decimal.Parse(textBoxGocPhaiThu.Text);
         decimal phiHT = ngayHT * contract.InterestRatePerDay * noGoc / 100;
         decimal phiCham = ngayQH * contract.InterestRatePenalty * noGoc / 100;

         textBoxPhiHT.Text = phiHT.ToString();
         textBoxPhiTraCham.Text = phiCham.ToString();
         labelTongPhi.Text = GUIUtil.MoneyAsString(phiHT + phiCham);
         labelTongGoc.Text = GUIUtil.MoneyAsString(noGoc + phiHT + phiCham);
      }
   }
}
