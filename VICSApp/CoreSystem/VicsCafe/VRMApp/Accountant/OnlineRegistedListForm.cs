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
using VRMApp.Accountant;
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;

namespace VRMApp.Accountant
{

   public partial class OnlineRegistedListForm : ListFormBase
   {

      public OnlineRegistedListForm()
      {
         InitializeComponent();
         HideExportButton = true;
         HidePrintButton = false;

         GUIUtil.FormatGridView(dataGridView1);

         toolStripButton1.PerformClick();
      }

      public override bool CheckAccess()
      {
          return Util.CheckAccess(AccessPermission.KeToan_DangKyChuyenTien);
      }


      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
         {
            backgroundWorker.RunWorkerAsync(new object[] {maKHBox.Text,accountIDToolStripTextBox.Text});
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
          object[] args = e.Argument as object[];
          e.Result = new List<AccountTransfer>(Util.VRMService.GetAccountTransferList(Util.TokenKey, (string)args[0], (string)args[1]));
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
             accountTransferBindingSource.DataSource = e.Result as List<AccountTransfer>;
            UpdateStatus(dataGridView1);
         }
      }





      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0)
            return;
         ModifyButton.PerformClick();
      }

      private void BankListForm_NewButtonClick(object sender, EventArgs e)
      {
          OnlineRegistedForm frm = new OnlineRegistedForm(null);
          frm.ShowDialog();
          if (frm.accountTransfer!=null)
              accountTransferBindingSource.Add(frm.accountTransfer);

      }

      private void BankListForm_EditButtonClick(object sender, EventArgs e)
      {
          AccountTransfer citem = accountTransferBindingSource.Current as AccountTransfer;
          if (citem == null)
              return;

          OnlineRegistedForm frm = new OnlineRegistedForm(citem);
          frm.ShowDialog();
          //bankBindingSource.ResetCurrentItem();
          if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
              backgroundWorker.RunWorkerAsync(new object[] { maKHBox.Text, accountIDToolStripTextBox.Text });

      }

      private void ContractListForm_DeleteButtonClick(object sender, EventArgs e)
      {
          if (DialogResult.Yes == ShowQuestion("Bạn có muốn xóa tài khoản chuyển tiền của khách hàng này không ?"))
          {
              AccountTransfer citem = accountTransferBindingSource.Current as AccountTransfer;
              try
              {
                  Util.VRMService.DeleteAccountTransfer(Util.TokenKey, citem.AccountID, citem.CustomerID);
              }
              catch (Exception ex) {
                  ShowNotice(ex.Message.Replace("System.Web.Services.Protocols.SoapException: Server was unable to process request. --->", "").Replace(" --- End of inner exception stack trace ---", ""));
              }

              if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
                  backgroundWorker.RunWorkerAsync(new object[] { maKHBox.Text, accountIDToolStripTextBox.Text });
          }
      }

      private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
          if (dataGridView1.Columns[e.ColumnIndex].Name == "ActiveTextBox")
          {
              if (e.Value.ToString() == "True")
              {
                  e.Value = "Đang hoạt động";
              }
              else
              {
                  e.CellStyle.ForeColor = Color.Red;
                  e.Value = "Ngừng sử dụng";
              }
          }

          if (dataGridView1.Columns[e.ColumnIndex].Name == "isAuthorizationDataGridViewTextBoxColumn")
          {
              if (e.Value.ToString() == "Y")
                  e.Value = "Ủy quyền";
              else
                  e.Value = "Chính chủ";
          }
          
      }

      private void OnlineRegistedListForm_PrintButtonClick(object sender, EventArgs e)
      {
          OnlineRegistedPrintForm frm = new OnlineRegistedPrintForm();
          frm.ShowDialog();

      }


   }
}
