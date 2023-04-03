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
   public partial class DeferredCalcForm : FormBase
   {
      private class Paying
      {
         public string customerid;
         public decimal amount;
      }
      delegate void InformingUpdate2Row(string customerId, bool isSuccess);
      List<string> selectedId = new List<string>();

      public DeferredCalcForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         dataGridView1.MultiSelect = true;
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         DataTable data = Util.VRMService.GetDefferedList(Util.TokenKey, customerIDTextBox.Text.Trim(), Util.CurrentTransactionDate);
         data.Columns.Add("active", typeof(bool));
         bindingSource.DataSource = data;

         toolStripButton4.Enabled = toolStripButton5.Enabled = (bindingSource.Count > 0);
         toolStripButton2.Enabled = false;
         soTienSeThuLabel.Text = soTienChoNoLabel.Text = "-";
         lblSoKH.Text = string.Format("Tổng số hạch toán {0}/{1}", 0, dataGridView1.Rows.Count);
         CloseWaiting();
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         if (ShowQuestion("Bạn thực sự muốn hạch toán tất cả các KH bạn có trong danh sách?") == DialogResult.No)
            return;

         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
         {
            toolStripButton1.Enabled = toolStripButton2.Enabled = false;
            toolStripButton4.Enabled = toolStripButton5.Enabled = dataGridView1.Rows.Count > 0;

            List<Paying> debts = new List<Paying>();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
               if (!IsActive(r))
                  continue;

               debts.Add(new Paying
               {
                  customerid = (string)r.Cells["accountid"].Value,
                  amount = (decimal)r.Cells["nosethu"].Value
               });
            }
            backgroundWorker.RunWorkerAsync(debts);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         List<Paying> debts = e.Argument as List<Paying>;
         foreach (Paying d in debts)
         {
            try
            {
               ShowWaiting(string.Format("Thu nợ khách hàng {0} số tiền {1}", d.customerid, GUIUtil.MoneyAsString(d.amount)));

               if (d.amount > 0)
               {
                  // call webservice 
                  Util.VRMService.CreateWithdrawDeferredTransaction(Util.TokenKey, d.customerid, d.amount, Util.CurrentTransactionDate);

                  // update statatus
                  Informing2Row(d.customerid, true);
               }
            }
            catch
            {
               // update statatus
               Informing2Row(d.customerid, false);
            }
         }
      }

      private void Informing2Row(string customerId, bool isSuccess)
      {
         if (dataGridView1.InvokeRequired)
            dataGridView1.Invoke(new InformingUpdate2Row(Informing2Row), new object[] { customerId, isSuccess });
         else
         {
            int rowIndex = bindingSource.Find("accountid", customerId);
            if (isSuccess)
            {
               bindingSource.RemoveAt(rowIndex);
            }
            else
            {
               dataGridView1.Rows[rowIndex].Cells["active"].Value = false;
               dataGridView1.Rows[rowIndex].Cells[6].Style.BackColor = dataGridView1.Rows[rowIndex].Cells[6].Style.SelectionBackColor =
               dataGridView1.Rows[rowIndex].Cells[7].Style.BackColor = dataGridView1.Rows[rowIndex].Cells[7].Style.SelectionBackColor =
               Color.Red;
            }
         }
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         CloseWaiting();
         ShowNotice("Hạch toán nợ thu nợ hoàn tất.");
         toolStripButton1.Enabled = true;
      }

      public void CalculateClearingDeferred(DataGridViewRow r)
      {
         if (!IsActive(r))
         {
            r.Cells["nosethu"].Value = 0M;
            return;
         }

         decimal deferred = (decimal)r.Cells["nohientai"].Value;
         decimal balance = (decimal)r.Cells["currentbalance"].Value;
         decimal nosethu = balance >= deferred ? deferred : decimal.Floor(balance / Util.Parameters.RoundFee) * Util.Parameters.RoundFee;

         r.Cells["nosethu"].Value = nosethu;
      }

      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 0)
            return;

         foreach (DataGridViewRow r in dataGridView1.SelectedRows)
         {
            r.Cells["active"].Value = false;
            r.Cells["nosethu"].Value = 0M;
         }

         UpdateGridState();
      }

      private void UpdateGridState()
      {
         decimal debt, nothu, Tdebt, tongNothu, rowactive;
         tongNothu = Tdebt = rowactive = 0M;
         foreach (DataGridViewRow gridRow in dataGridView1.Rows)
         {
            if (IsActive(gridRow))
            {
               if (decimal.TryParse(gridRow.Cells["nosethu"].Value.ToString(), out nothu))
                  tongNothu += nothu;
               if (decimal.TryParse(gridRow.Cells["nohientai"].Value.ToString(), out debt))
                  Tdebt += debt;
               
               for (int i = 0; i < gridRow.Cells.Count; i++)
               {
                  gridRow.Cells[i].Style.BackColor = gridRow.Cells[i].Style.SelectionBackColor =
                     nothu > 0 ? Color.YellowGreen : Color.Peru;
               }
               rowactive++;
            }
            else
            {
               for (int i = 0; i < gridRow.Cells.Count; i++)
               {
                  gridRow.Cells[i].Style.BackColor = gridRow.DefaultCellStyle.BackColor;
                  gridRow.Cells[i].Style.SelectionBackColor = gridRow.DefaultCellStyle.SelectionBackColor;
               }
            }
            nothu = debt = 0M;
         }
         soTienChoNoLabel.Text = GUIUtil.FormatNumber(Tdebt - tongNothu);
         soTienSeThuLabel.Text = GUIUtil.FormatNumber(tongNothu);

         lblSoKH.Text = string.Format("Tổng số hạch toán {0}/{1}", rowactive, dataGridView1.Rows.Count);
         toolStripButton2.Enabled = Tdebt + tongNothu > 0;
      }

      private void toolStripButton5_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 0)
            return;
         foreach (DataGridViewRow r in dataGridView1.SelectedRows)
         {
            r.Cells["active"].Value = true;
            CalculateClearingDeferred(r);
         }
         UpdateGridState();
      }

      private bool IsActive(DataGridViewRow dataGridViewRow)
      {
         if (dataGridViewRow.Cells["active"].Value == null)
            return false;

         bool result;
         if (bool.TryParse(dataGridViewRow.Cells["active"].Value.ToString(), out result))
            return result;
         return false;
      }

      private void dataGridView1_Sorted(object sender, EventArgs e)
      {
         dataGridView1.ClearSelection();
         UpdateGridState();
      }


      private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
      {
         if (selectedId.Count > 0 && e.ListChangedType == ListChangedType.Reset)
         {
            int row = 0;
            foreach (string id in selectedId)
            {
               row = bindingSource.Find("accountid", id);
               dataGridView1.BeginInvoke((MethodInvoker)delegate()
               {
                  dataGridView1.Rows[row].Selected = true;
               });
            }
            dataGridView1.CurrentCell = dataGridView1[0, row];
         }
      }

      private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
      {
         if (e.RowIndex == -1)
         {
            selectedId.Clear();
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
               selectedId.Add((string)r.Cells["accountid"].Value);
         }
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_ThuTienNoHDKhongKyHan);
      }
   }
}
