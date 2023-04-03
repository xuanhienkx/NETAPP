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

namespace VRMApp.Accountant
{
   public partial class ReleaseBlockedBalanceForm : FormBase
   {
      string customerId;
      decimal currentDebit, localBlockedAmount, bankBlockedAmount;
      public ReleaseBlockedBalanceForm()
      {
         InitializeComponent();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_GiaiToaTien);
      }


      private void button1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(txtCustomerId.Text.Trim());
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         e.Result = Util.VRMService.GetBlockBalanceAndDebitLimitInfo(Util.TokenKey, (string)e.Argument);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            return;
         }
         if ((e.Result as DataTable).Rows.Count == 0)
         {
            ShowError("Không tìm thấy thông tin khách hàng");
            txtCustomerId.Focus();
            BindingResult(null);
         }
         else
            BindingResult((e.Result as DataTable).Rows[0]);
         CloseWaiting();
      }

      private void BindingResult(DataRow row)
      {
         if (row == null)
         {
            customerId = txtCustomerId.Text = khadungNHLbl.Text = phongtoaLbl.Text = giaitoaLbl.Text = tenkhachhangLbl.Text = nhanvienchamsocLbl.Text =
               khadungnoiboLbl.Text = soduNHLbl.Text = khadunghientaiLBL.Text = sotienthieuLbl.Text = string.Empty;
            currentDebit = localBlockedAmount = bankBlockedAmount = 0M;
         }
         else
         {
            txtCustomerId.Text = customerId = (string)row["CustomerId"];
            tenkhachhangLbl.Text = (string)row["CustomerNameViet"];
            nhanvienchamsocLbl.Text = row.IsNull("FullName")? string.Empty : (string)row["FullName"];

            currentDebit = row.IsNull("CurrentLimitValue") ? 0M : (decimal)row["CurrentLimitValue"];
            localBlockedAmount = (decimal)row["BlockBalance"];
            bankBlockedAmount = (decimal)row["Balance"];

            khadungNHLbl.Text = GUIUtil.MoneyAsString((decimal)row["LastBalance"] - bankBlockedAmount);
            phongtoaLbl.Text = GUIUtil.MoneyAsString((decimal)row["DayBlock"]);
            giaitoaLbl.Text = GUIUtil.MoneyAsString((decimal)row["DayUnBlock"]);
            khadungnoiboLbl.Text = GUIUtil.MoneyAsString(bankBlockedAmount - localBlockedAmount);
            soduNHLbl.Text = GUIUtil.MoneyAsString((decimal)row["LastBalance"]);
            khadunghientaiLBL.Text = GUIUtil.MoneyAsString((decimal)row["LastBalance"] - localBlockedAmount);
            sotienthieuLbl.Text = GUIUtil.MoneyAsString(currentDebit);
         }
      }

      private void button4_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker2.IsBusy && !backgroundWorker2.CancellationPending)
            backgroundWorker2.RunWorkerAsync();
      }

      private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         Util.VRMService.UnBlockBalanceAmount(Util.TokenKey, customerId, currentDebit, localBlockedAmount, bankBlockedAmount, Util.CurrentTransactionDate);
      }

      private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
            BindingResult(null);
      }

      private void button2_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
