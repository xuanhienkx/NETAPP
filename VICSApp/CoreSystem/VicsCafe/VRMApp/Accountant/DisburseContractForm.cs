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
   public partial class DisburseContractForm : FormBase
   {
      CustAssetInfo cinfo;
      private Contract contract;
      private bool disbursed = false;
      public DisburseContractForm()
      {
         InitializeComponent();
         GUIUtil.FormatTextBoxForNumber(disbursedAmountTextBox);
      }

      public Contract CurrentContract
      {
         get { return contract; }
         set { contract = value; }
      }

      public bool Disbursed
      {
         get { return disbursed; }
      }

      private void DisburseForm_Load(object sender, EventArgs e)
      {
         if (contract != null)
         {
            UpdateContractInfo();
         }
      }

      private void UpdateContractInfo()
      {
         ShowWaiting();
         customerIdTextBox.Text = contract.CustomerID;
         customerNameTextBox.Text = contract.CustomerName;
         customerIdTextBox.ReadOnly = true;
         findButton.Visible = false;
         textBoxSoHD.Text = contract.ContractID;

         trangThaiLbl.Text = contract.ContractStatus.ToString().ToUpper();
         labelDaGiaiToa.Text = string.Format("Đã giải tỏa: {0}", GUIUtil.MoneyAsString(contract.DisbursedAmount));
         soTienToiDaTextBox.Text = string.Format("Số tiền giải ngân tối đa: {0}", GUIUtil.MoneyAsString(contract.ApprovalAmount - contract.DisbursedAmount));
         disbursedAmountTextBox.Text = (contract.ApprovalAmount - contract.DisbursedAmount).ToString();

         UpdateCustomerAsset(contract.CustomerID);
         CloseWaiting();
      }

      private void UpdateCustomerAsset(string customerId)
      {
         cinfo = Util.VRMService.GetCustomerAssetInfo(Util.TokenKey, Util.CurrentTransactionDate, customerId, true);

         tongTSLbl.Text = GUIUtil.MoneyAsString(cinfo.TongTS);
         tongNoLbl.Text = GUIUtil.MoneyAsString(cinfo.TongNo);
         lblTiLeNo.Text = GUIUtil.FormatRate(cinfo.TyLeNo / 100, true);
         tileHopTacLbl.Text = GUIUtil.FormatRate(cinfo.TyLeHopTac / 100, true);

         //if (cinfo.NoQuaHan + cinfo.NoTrongHan > 0 && contract.DisbursedAmount == 0)
         //{
         //   disbursedAmountTextBox.Enabled = false;
         //   ShowError(string.Format("Khách hàng này đang nợ {0} nên không thể giải ngân được.", GUIUtil.MoneyAsString(cinfo.NoTrongHan + cinfo.NoQuaHan)));
         //   disburseButton.Enabled = false;
         //   return;
         //}
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         disbursed = false;
         this.Close();
      }

      private void disburseButton_Click(object sender, EventArgs e)
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
         if (cinfo.TongTS == 0 || cinfo.TongTS == cinfo.TongNo)
         {
            ShowError("Tài sản và nợ của khách hàng không hợp lệ để thực hiện giải ngân.");
            return;
         }

         decimal amount = decimal.Parse(disbursedAmountTextBox.Text);
         if (amount > contract.ApprovalAmount - contract.DisbursedAmount || amount == 0M)
         {
            ShowError(string.Format("Giá trị giải ngân phải lớn hơn 0 và không được vượt quá số tiền {0}.", GUIUtil.MoneyAsString(contract.ApprovalAmount - contract.DisbursedAmount)));
            return;
         }

         if ((amount + cinfo.TongNo) * 100M / (amount + cinfo.TongTS) > cinfo.TyLeHopTac)
         {
            ShowError("Giá trị giải ngân làm tỷ lệ hợp tác lớn hơn cam kết");
            return;
         }

         try
         {
            Util.VRMService.DisburseContract(Util.TokenKey, contract, amount);
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
            return;
         }
         contract.DisbursedAmount += amount;
         contract.ContractStatus = ContractStatus.DaGiaiNgan;
         contract.DisbursedBy = Util.LoginUser.UserName;
         contract.DisbursedDate = DateTime.Now;

         disbursed = true;
         this.Close();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_GiaiNganHopDong);
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         contract = Util.VRMService.GetCurrentContract(Util.TokenKey, customerIdTextBox.Text);
         if (contract != null)
         {
            if (contract.ContractType == ContractType.CoThoiHan &&
               contract.ContractStatus == ContractStatus.DaDuyet || contract.ContractStatus == ContractStatus.DaGiaiNgan)
               UpdateContractInfo();
            else
            {
               contract = null;
               ShowError("Khách hàng hiện tại không có hợp đồng chờ giải ngân");
            }
         }
      }
   }
}
