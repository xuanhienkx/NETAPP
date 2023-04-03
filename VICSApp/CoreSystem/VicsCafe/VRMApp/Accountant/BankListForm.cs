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

   public partial class BankListForm : ListFormBase
   {

      public BankListForm()
      {
         InitializeComponent();
         HideExportButton = true;
         HidePrintButton = true;

         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.FormatGridView(bankBranchDataGridView);

         toolStripButton1.PerformClick();
      }

      public override bool CheckAccess()
      {
          return Util.CheckAccess(AccessPermission.KeToan_DSNganHangChuyenTien);
      }


      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
         {
            backgroundWorker.RunWorkerAsync(new object[] { });
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
            e.Result = new List<Bank>(Util.VRMService.GetBankList(Util.TokenKey));
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
            bankBindingSource.DataSource = e.Result as List<Bank>;
            UpdateStatus(dataGridView1);
         }
      }

      private void dataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         Bank dc = bankBindingSource.Current as Bank;
         if (dc == null)
            return;
         List<BankBranch> list = new List<BankBranch>(Util.VRMService.GetBankBranchList(Util.TokenKey, dc.BankCode));
         bankBranchBindingSource.DataSource =  list;
         //UpdateStatus(bankBranchDataGridView);

      }


      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0)
            return;
         ModifyButton.PerformClick();
      }

      private void BankListForm_NewButtonClick(object sender, EventArgs e)
      {
          BankForm frm = new BankForm(null);
          frm.ShowDialog();
          if (frm.bank != null)
              bankBindingSource.Add(frm.bank);

      }

      private void BankListForm_EditButtonClick(object sender, EventArgs e)
      {
          Bank dc = bankBindingSource.Current as Bank;
          if (dc == null)
              return;

          BankForm frm = new BankForm(dc);
          frm.ShowDialog();
          //bankBindingSource.ResetCurrentItem();
          if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
              backgroundWorker.RunWorkerAsync(new object[] { });

      }

      private void ContractListForm_DeleteButtonClick(object sender, EventArgs e)
      {
          if (DialogResult.Yes == ShowQuestion("Bạn có muốn xóa ngân hàng này không ?"))
          {
              Bank dc = bankBindingSource.Current as Bank;
              try
              {
                  Util.VRMService.DeleteBank(Util.TokenKey, dc.BankCode);
              }
              catch (Exception ex) {
                  ShowNotice(ex.Message.Replace("System.Web.Services.Protocols.SoapException: Server was unable to process request. --->", "").Replace(" --- End of inner exception stack trace ---", ""));
              }

              if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
                  backgroundWorker.RunWorkerAsync(new object[] { });
          }
      }

      private void addBranchButton_Click(object sender, EventArgs e)
      {
          Bank dc = bankBindingSource.Current as Bank;
          if (dc == null)
              return;

          BankBranchForm frm = new BankBranchForm(null,dc.BankCode);
        
          frm.ShowDialog();
          if (frm.bankBranch != null)
              bankBranchBindingSource.Add(frm.bankBranch);

      }

      private void editBranchButton_Click(object sender, EventArgs e)
      {
          BankBranch bb = bankBranchBindingSource.Current as BankBranch;
          if (bb == null)
              return;

          BankBranchForm frm = new BankBranchForm(bb,bb.BankCode);
          frm.ShowDialog();

          Bank dc = bankBindingSource.Current as Bank;
          if (dc == null)
              return;
          List<BankBranch> list = new List<BankBranch>(Util.VRMService.GetBankBranchList(Util.TokenKey, dc.BankCode));
          bankBranchBindingSource.DataSource = list;

      }

      private void delBranchButton_Click(object sender, EventArgs e)
      {
          if (DialogResult.Yes == ShowQuestion("Bạn có muốn xóa chi nhánh này không ?"))
          {


              BankBranch bb = bankBranchBindingSource.Current as BankBranch;
              if (bb == null)
                  return;
              Util.VRMService.DeleteBankBranch(Util.TokenKey, bb.BankBranchCode);

              Bank dc = bankBindingSource.Current as Bank;
              List<BankBranch> list = new List<BankBranch>(Util.VRMService.GetBankBranchList(Util.TokenKey, dc.BankCode));
              bankBranchBindingSource.DataSource = list;
          }
      }

   }
}
