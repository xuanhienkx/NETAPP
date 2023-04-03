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

namespace VRMApp.Brokerage
{
   public partial class DebitLimitOnCustomerListForm : StdForm
   {
      delegate void InformRowOnSumit(string customerId, decimal limitAmount, bool success);
      Dictionary<string, decimal> debitLimits;

      public DebitLimitOnCustomerListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView);
         dataGridView.MultiSelect = true;
         dataGridView.Columns["hanMucToiDaDataGridViewTextBoxColumn"].ReadOnly = false;

         if (Util.IsAdmin(AccessPermission.AdminLocal) || Util.CheckAccess(AccessPermission.MoiGioi_CapHanMucTinDungTatCa))
         {
            List<DropDownObject> source = new List<DropDownObject>();
            source.Add(new DropDownObject(string.Empty, "<Tất cả>"));

            List<UserLite> users = new List<UserLite>(Util.VRMService.FindUsers(Util.TokenKey, string.Empty));
            foreach (UserLite u in users)
               source.Add(new DropDownObject(u.UserId.ToString(), u.UserName));
            nvchamsoccb.ComboBox.DataSource = source;
         }
         else
            nvchamsoccb.ComboBox.DataSource = new DropDownObject[] { new DropDownObject(Util.LoginUser.UserId.ToString(), Util.LoginUser.UserName) };
         nvchamsoccb.ComboBox.DisplayMember = "Description";
         nvchamsoccb.ComboBox.ValueMember = "Code";
      }

      private void CustomerListForm_Load(object sender, EventArgs e)
      {
         UpdateStatus(dataGridView);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            backgroundWorker.RunWorkerAsync(new object[] { maKHBox.Text, nvchamsoccb.ComboBox.SelectedValue });
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         string customerId = (string)args[0];
         int userTk = string.IsNullOrEmpty((string)args[1]) ? 0 : int.Parse((string)args[1]);
         List<CustAssetInfo> data = new List<CustAssetInfo>(Util.VRMService.GetCustomerAssetInfoList(Util.TokenKey, Util.CurrentTransactionDate, customerId, userTk, true, 0, false, ContractType.KhongThoiHan));
         var source = data.AsQueryable().Where(c => c.HanMucToiDa > 0);
         debitLimits = source.ToDictionary(c => c.CustomerID, c => c.HanMucToiDa);
         e.Result = source;
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
            custAssetInfoBindingSource.DataSource = e.Result;
            UpdateStatus(dataGridView);
            toolStripButton2.Enabled = true;
         }
         CloseWaiting();
      }

      private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         CustAssetInfo c = custAssetInfoBindingSource.Current as CustAssetInfo;
         if (c == null)
            return;

         RiskMan.CustomerInfoForm cF = new VRMApp.RiskMan.CustomerInfoForm(c.CustomerID);
         cF.ShowDialog();
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         toolStripButton2.Enabled = false;
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(dataGridView.SelectedRows);
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         DataGridViewSelectedRowCollection selectedRows = e.Argument as DataGridViewSelectedRowCollection;

         Result result;
         foreach (DataGridViewRow r in selectedRows)
         {
            if ((decimal)r.Cells["hanMucToiDaDataGridViewTextBoxColumn"].Value == 0M)
            {
               InformRow((string)r.Cells["customerIDDataGridViewTextBoxColumn"].Value, 0M, false);
               continue;
            }
            try
            {
               result = Util.VRMService.CreateDebitLimit(Util.TokenKey, 
                  (string)r.Cells["customerIDDataGridViewTextBoxColumn"].Value,
                  Util.CurrentTransactionDate, (decimal)r.Cells["hanMucToiDaDataGridViewTextBoxColumn"].Value);
               InformRow((string)r.Cells["customerIDDataGridViewTextBoxColumn"].Value, (decimal)result.Value, result.IsSuccess);
            }
            catch
            {
               InformRow((string)r.Cells["customerIDDataGridViewTextBoxColumn"].Value, 
                  (decimal)r.Cells["hanMucToiDaDataGridViewTextBoxColumn"].Value,
                  false);
            }
         }
      }

      private void InformRow(string customerID, decimal debitAmount, bool success)
      {
         if (dataGridView.InvokeRequired)
            dataGridView.Invoke(new InformRowOnSumit(InformRow), customerID, debitAmount, success);
         else
         {
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
               if ((string)r.Cells["customerIDDataGridViewTextBoxColumn"].Value != customerID)
                  continue;
               
               Color color = r.DefaultCellStyle.BackColor;
               if (debitAmount == 0M || !success)
                  color = Color.Red;

               r.DefaultCellStyle.BackColor = r.DefaultCellStyle.SelectionBackColor = color;
               r.Cells["hanmuctoidadacap"].Value = debitAmount;
               return;
            }
         }
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            return;
         }
         ShowNotice("Hạn mức cấp hoàn tất");
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_CapHanMucTinDung);
      }

      private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex == -1)
            return;
         CustAssetInfo c = custAssetInfoBindingSource.Current as CustAssetInfo;

         if (c.HanMucToiDa > debitLimits[c.CustomerID])
            dataGridView[e.ColumnIndex, e.RowIndex].Value = c.HanMucToiDa = debitLimits[c.CustomerID];
      }
   }
}
