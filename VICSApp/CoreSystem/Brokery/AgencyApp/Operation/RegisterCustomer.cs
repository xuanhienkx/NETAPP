using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using UnitTrade = Brokery.AgencyWebService.UnitTrade;

namespace Brokery.Operation
{
   public partial class RegisterCustomer : ListFormBase
   {
      private readonly List<UnitTrade> unitTrades;
      delegate void UpdateGrid(List<Customer> source);

      public RegisterCustomer()
      {
         InitializeComponent();
         GUIUtil.FormatDropDownList(cboUnitTrade.ComboBox);
         GUIUtil.FormatGridView(dataGridView);
         ModifyButton.Visible = ExportButton.Visible = PrintButton.Visible = false;

         unitTrades = new List<UnitTrade>(Util.AgencyGateway.GetUnitTradeCodes(Util.TokenKey));
         UpdateUnitTrades();
      }

      private void UpdateUnitTrades()
      {
         cboUnitTrade.ComboBox.Items.Clear();
         if (unitTrades.Count == 0)
         {
            NewButton.Enabled = false;
            cboUnitTrade.ComboBox.Items.Add(new DropDownObject(Util.LoginUser.TradeCode, Util.LoginUser.AgencyName));
         }
         else
         {
            cboUnitTrade.ComboBox.Items.Add(new DropDownObject(string.Empty, "<None>"));
            unitTrades.ForEach(x => cboUnitTrade.ComboBox.Items.Add(new DropDownObject(x.TradeCode, x.Name)));
         }
         cboUnitTrade.ComboBox.SelectedIndex = 0;
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_DangKyGiaoDichChoKhachHang; }
      }

      private void BindCustomerInfo()
      {
         var currentUnit = cboUnitTrade.ComboBox.SelectedItem as DropDownObject;
         if (string.IsNullOrEmpty(currentUnit.Code))
         {
            ShowError("Vui lòng chọn đơn vị quản lý");
            return;
         }
         var unitTrade = unitTrades.FirstOrDefault(x => x.TradeCode == currentUnit.Code);
         var branchCode = unitTrade == null ? Util.LoginUser.BranchCode : unitTrade.BranchCode;

         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            backgroundWorker.RunWorkerAsync(new[] { customerIdText.Text.Trim(), currentUnit.Code, branchCode });
      }

      private void RegisterCustomer_DeleteButtonClick(object sender, EventArgs e)
      {
         if (customerBindingSource.Current == null || ShowQuestion("Bạn có chắc là muốn xóa?") == DialogResult.No)
            return;

         try
         {
            Customer cus = customerBindingSource.Current as Customer;
            Util.AgencyGateway.UnRegisterCustomer(Util.TokenKey, cus.CustomerId);
            customerBindingSource.RemoveCurrent();
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }

      private void RegisterCustomer_NewButtonClick(object sender, EventArgs e)
      {
         CustomerLiteInfo cusF = new CustomerLiteInfo(unitTrades);
         cusF.ShowDialog();
         BindCustomerInfo();
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         BindCustomerInfo();
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         var args = e.Argument as object[];
         string customerId = args[0].ToString();
         var tradeCode = args[1].ToString();
         var brachCode = args[2].ToString();

         List<Customer> source = new List<Customer>(Util.AgencyGateway.FindCustomers(Util.TokenKey, customerId, string.Empty, string.Empty, brachCode, tradeCode));
         UpdateDataSource(source);
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         UpdateStatus(dataGridView);
      }

      private void UpdateDataSource(List<Customer> source)
      {
         if (dataGridView.InvokeRequired)
            dataGridView.Invoke(new UpdateGrid(UpdateDataSource), new object[] { source });
         else
            customerBindingSource.DataSource = source;
      }
   }
}
