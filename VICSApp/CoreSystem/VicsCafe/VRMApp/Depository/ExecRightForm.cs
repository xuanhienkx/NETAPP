using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Depository
{
   public partial class ExecRightForm : FormBase
   {
      public ExecRightForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.AddContextMenuOnColumns(dataGridView1); 
         dataGridView1.MultiSelect = true;
         toolStripButton2.Enabled = Util.CheckAccess(AccessPermission.LuuKy_HuyGiaoDichDaChot);
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.LuuKy_TheoGioiCoTucChuaVe);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(new string[] { txtStockCode.Text.Trim(), txtCustomerID.Text.Trim() });
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         string[] args = e.Argument as string[];
         e.Result = Util.VRMService.GetRightExecNotPayYet(Util.TokenKey, args[0], args[1]);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            return;
         }
         DataTable data = e.Result as DataTable;
         dataGridView1.DataSource = data;

         long quantity = 0;
         decimal amount = 0M;
         foreach (DataRow r in data.Rows)
         {
            quantity += r["quantity"] == DBNull.Value ? 0 : (long)r["quantity"];
            amount += r["amount"] == DBNull.Value ? 0 : (decimal)r["amount"];
         }
         lblTotalHoding.Text = string.Format("Tổng số lượng: {0}", GUIUtil.FormatNumber(quantity));
         lblTotalReceived.Text = string.Format("Tổng giá trị: {0}", GUIUtil.MoneyAsString(amount));
         CloseWaiting();
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 0)
            return;

         ShowWaiting();
         foreach (DataGridViewRow r in dataGridView1.SelectedRows)
         {
            Util.VRMService.CancelRightExec(Util.TokenKey, (int)r.Cells["id"].Value, (string)r.Cells["CustomerId"].Value, false);
         }
         toolStripButton1.PerformClick();
      }
   }
}
