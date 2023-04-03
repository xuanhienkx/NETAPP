using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using CustomerDebitLimit = Brokery.AgencyWebService.CustomerDebitLimit;

namespace Brokery.Operation
{
   public partial class DebitLimitForm : FormBase
   {
      private CustomerDebitLimit debitLimit;
      Customer customer;
      public DebitLimitForm()
      {
         InitializeComponent();

         GUIUtil.FormatTextBoxForNumber(txtDebitLimit);
         GUIUtil.FormatDatePicker(dtpFromDate);
         GUIUtil.FormatDatePicker(dtpToDate);
         cboType.SelectedIndex = 0;
         dtpFromDate.Value = dtpToDate.Value = Util.CurrentTransactionDate;

         cboType.Enabled = dtpFromDate.Enabled = dtpToDate.Enabled = false;
      }

      public DebitLimitForm(AgencyWebService.CustomerDebitLimit debitLimit)
         : this()
      {
         // TODO: Complete member initialization
         this.debitLimit = debitLimit;

         if (debitLimit != null)
         {
            txtCustomerId.Enabled = false;
            btnAccept.Enabled = true;
            button1.Text = "Chọn lại";

            txtCustomerId.Text = debitLimit.CustomerID;
            txtDebitLimit.Text = debitLimit.LimitValue.ToString();
         }
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get
         {
            yield return AccessPermission.VICS_Debitlimit_CapHanMucTinDungChoKhachHang;
            yield return AccessPermission.VICS_Debitlimit_XemHanMucTinDungChoKhachHang;
         }
      }

      private void btnAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(txtCustomerId.Text) || string.IsNullOrEmpty(txtDebitLimit.Text))
         {
            ShowError("Mã khách hàng và hạn mức cần cấp không được để trống.");
            btnAccept.Enabled = false;
            return;
         }

         if (debitLimit == null)
         {
            ShowError("Không xác định được tài khoản khách hàng");
            btnAccept.Enabled = false;
            return;
         }
         var debitLimitAmount = decimal.Parse(txtDebitLimit.Text);
         if (debitLimit.CurrentLimitValue > debitLimitAmount)
         {
            ShowError("Không thể thực hiện do số tiền thiếu hiện tại lớn hơn hạn mức được cấp");
            return;
         }

         debitLimit.Activate = ckbValid.Checked;
         debitLimit.CustomerID = txtCustomerId.Text;
         debitLimit.DebitLimitType = 'D';
         debitLimit.FromDate = dtpFromDate.Value;
         debitLimit.ToDate = dtpToDate.Value;
         debitLimit.LimitValue = debitLimitAmount;

         try
         {
            Util.AgencyGateway.CreateCustomerDebitLimit(Util.TokenKey, debitLimit, Util.CurrentTransactionDate);
                if (ShowQuestion("Cấp hạn mức hoàn tất. Bạn muốn tiếp tục cấp hạn mức cho khách hàng mới?") ==
                DialogResult.Yes)
            {
               debitLimit = null;
               txtCustomerId.Text = txtDebitLimit.Text = string.Empty;
            }
            else
            {
               this.DialogResult = DialogResult.OK;
            }
         }
         catch (Exception ex)
         {
            ShowError("Không thể cấp hạn mức tín dụng được. Lỗi: " + ex.Message);
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

       private void button1_Click(object sender, EventArgs e)
       {
           if (!txtCustomerId.Enabled)
           {
               txtCustomerId.Enabled = true;
               txtCustomerId.Select();
               button1.Text = "Vấn tin";
               btnAccept.Enabled = false;
               return;
           }

           debitLimit = Util.AgencyGateway.FindCustomerDebitLimit(Util.TokenKey, txtCustomerId.Text,
               Util.CurrentTransactionDate);
           if (debitLimit == null || string.IsNullOrEmpty(debitLimit.CustomerID))
           {
               ShowError("Không xác định được tài khoản khách hàng");
               btnAccept.Enabled = false;
               return;
           }
           txtCustomerId.Text = debitLimit.CustomerID;
           customer = Util.AgencyGateway.GetCustomerForRegister(Util.TokenKey, txtCustomerId.Text.Trim());
           if (customer != null && !string.IsNullOrEmpty(customer.CustomerName))
           {
               textName.Text = customer.CustomerName.ToUpper();  
           }
           btnAccept.Enabled = true;
           txtCustomerId.Enabled = false;
           button1.Text = "Chọn lại";
       }
   }
}
