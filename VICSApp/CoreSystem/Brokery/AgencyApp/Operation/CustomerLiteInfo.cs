using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using UnitTrade = Brokery.AgencyWebService.UnitTrade;

namespace Brokery.Operation
{
   public partial class CustomerLiteInfo : FormBase
   {
      private readonly List<UnitTrade> unitTrades;
      private readonly UnitTrade currentUnit;
      Customer customer;

      public CustomerLiteInfo(List<UnitTrade> unitTrades)
      {
         this.unitTrades = unitTrades;
         InitializeComponent();
         GUIUtil.FormatDropDownList(cboBranches);
         GUIUtil.FormatDropDownList(cboAgents);

         currentUnit = unitTrades.Single(x => x.TradeCode == Util.LoginUser.TradeCode);
         ShowUnitTrades();
      }

      private void ShowUnitTrades()
      {
         cboBranches.Items.Add(new DropDownObject(string.Empty, "<Chọn đơn vị>"));
         unitTrades.ForEach(x =>
         {
            if (x.Type < 3)
               cboBranches.Items.Add(new DropDownObject(x.TradeCode, x.Name));
         });
         if (currentUnit.Type < 3)
         {
            cboBranches.SelectedIndex = cboBranches.Items.IndexOf(new DropDownObject(currentUnit.TradeCode, currentUnit.Name));
         }
         else
         {
            var unit = unitTrades.Single(x => x.TradeCode == currentUnit.TradeCode);
            cboBranches.SelectedIndex = cboBranches.Items.IndexOf(new DropDownObject(unit.ParentTradeCode, string.Empty));
         }
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_DangKyGiaoDichChoKhachHang; }
      }

      private void cboBranches_SelectedIndexChanged(object sender, EventArgs e)
      {
         cboAgents.Items.Clear();
         var branchItem = cboBranches.SelectedItem as DropDownObject;
         if (branchItem == null || unitTrades == null)
            return;

         cboAgents.Items.Add(new DropDownObject(string.Empty, "<None>"));
         unitTrades.ForEach(x =>
         {
            if (x.Type == 3 && x.ParentTradeCode == branchItem.Code)
               cboAgents.Items.Add(new DropDownObject(x.TradeCode, x.Name));
         });

         cboAgents.SelectedIndex = currentUnit.Type == 3
            ? cboAgents.Items.IndexOf(new DropDownObject(currentUnit.TradeCode, currentUnit.Name))
            : 0;
      }

      private void textBox1_Validated(object sender, EventArgs e)
      {
         txtCustomerId.Text = GUIUtil.ValidateCustomerId(txtCustomerId.Text);
         findButon.Enabled = oKButton.Enabled = !string.IsNullOrEmpty(txtCustomerId.Text);
      }

      private void findButon_Click(object sender, EventArgs e)
      {
         try
         {
            customer = Util.AgencyGateway.GetCustomerForRegister(Util.TokenKey, txtCustomerId.Text.Trim());
            nameLabel.Text = customer.CustomerName.ToUpper();
            statusLabel.Text = customer.AccountStatus;
         }
         catch
         {
            ShowError("Không tìm thấy tài khoản khách hàng");
            customer = null;
         }
      }

      private void oKButton_Click(object sender, EventArgs e)
      {
         if (customer == null)
            return;

         var unit = cboAgents.SelectedItem as DropDownObject;
         if (unit == null || string.IsNullOrEmpty(unit.Code))
         {
            unit = cboBranches.SelectedItem as DropDownObject;

            if (unit == null || string.IsNullOrEmpty(unit.Code) || cboAgents.Items.Count > 1)
            {
               ShowError("Bạn phải chọn đơn vị giao dịch");
               return;
            }
         }

         int checkRegisterType = 0;
          checkRegisterType = Util.AgencyGateway.CheckRegisterCustomer(Util.TokenKey, customer.CustomerId, unit.Code);
          if (checkRegisterType == 1)
          {
              if (ShowQuestion("Khách hàng này đã tồn tại ở đơn vị giao dịch khác. Bạn muốn xoá và thêm vào đơn vị giao địch hiện tại?") == DialogResult.Yes)
              {
                  Util.AgencyGateway.UnRegisterCustomer(Util.TokenKey,customer.CustomerId);
                  Util.AgencyGateway.RegisterCustomer(Util.TokenKey, customer.CustomerId, customer.TradeCode, unit.Code);
                  resetValue();
                  ShowNotice("Đã thực hiện đăng kí xong."); 
              }
              else
              {
                  resetValue();
                 // this.DialogResult = DialogResult.Cancel;
                  //this.Close();
              }
          }
          else if (checkRegisterType == 2)
          {
              ShowNotice("Khách hàng này đã tồn tại."); 
          }
          else
          {
              Util.AgencyGateway.RegisterCustomer(Util.TokenKey, customer.CustomerId, customer.TradeCode, unit.Code);
              resetValue();
              ShowNotice("Đã thực hiện đăng kí xong."); 
          }
         
      }

       private void resetValue()
       {
           cboBranches.SelectedIndex = 0;
           txtCustomerId.Text = string.Empty;
           nameLabel.Text = string.Empty;
           statusLabel.Text = string.Empty;
           cboAgents.SelectedIndex = 0;
       }

      private void closeButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
