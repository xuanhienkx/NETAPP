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
   public partial class DeferredTDayListForm : FormBase
   {
      private class DebtLoad
      {
         public string customerid;
         public decimal paymatched;
         public decimal payfee;
         public decimal deferredmatched;
         public decimal deferredfee;
      }

      delegate void InformingUpdate2Row(string customerId, bool isSuccess);

      public DeferredTDayListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         dataGridView1.MultiSelect = true;
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         DataTable data = Util.VRMService.GetDefferedTDayList(Util.TokenKey, Util.CurrentTransactionDate, toolStripTextBox1.Text.Trim());

         if (data.Rows.Count == 0)
         {
            ShowNotice("Bạn chưa cập nhật chu kỳ hạch toán từ SBS hoặc bạn đã hạch toán hết các bút toán.");
            return;
         }

         data.Columns.Add("thuphi", typeof(decimal));
         data.Columns.Add("thutienmua", typeof(decimal));
         data.Columns.Add("tongthu", typeof(decimal));
         data.Columns.Add("nophi", typeof(decimal));
         data.Columns.Add("notienmua", typeof(decimal));
         data.Columns.Add("deferredamount", typeof(decimal));
         data.Columns.Add("active", typeof(bool));

         bindingSource.DataSource = data.DefaultView;
         toolStripButton4.Enabled = toolStripButton5.Enabled = (bindingSource.Count > 0);
         toolStripButton2.Enabled = false;
         soTienSeThuLabel.Text = soTienChoNoLabel.Text = "-";
         lblSoKH.Text = string.Format("Số KH hạch toán {0}/{1}", 0, dataGridView1.Rows.Count);
         decimal amount = 0;
         int hdAmount = 0;
         foreach (DataGridViewRow r in dataGridView1.Rows)
         {
            amount += (decimal)r.Cells["fee"].Value + (decimal)r.Cells["matched"].Value;
            if ((int)r.Cells["hd"].Value == 0)
            {
               r.DefaultCellStyle.BackColor = Color.BurlyWood;
               r.DefaultCellStyle.SelectionBackColor = Color.SaddleBrown;
               hdAmount++;
            }
         }
         lblTongTienMua.Text = string.Format("TỔNG TIỀN MUA: {0}", GUIUtil.MoneyAsString(amount));
         lblSoHD.Text = string.Format("Có {0:n0} KH chưa tạo HĐ hoặc HĐ chưa duyệt", hdAmount);

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

            List<DebtLoad> debts = new List<DebtLoad>();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
               if (!IsActive(r))
                  continue;

               debts.Add(new DebtLoad
               {
                  customerid = (string)r.Cells["accountid"].Value,
                  paymatched = (decimal)r.Cells["thutienmua"].Value,
                  payfee = (decimal)r.Cells["thuphi"].Value,
                  deferredfee = (decimal)r.Cells["nophi"].Value,
                  deferredmatched = (decimal)r.Cells["notienmua"].Value
               });
            }
            backgroundWorker.RunWorkerAsync(debts);
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         List<DebtLoad> debts = e.Argument as List<DebtLoad>;
         foreach (DebtLoad d in debts)
         {
            try
            {
               ShowWaiting("Xử lý khách hàng " + d.customerid);

               // call webservice 
               Util.VRMService.DeferringTDay(Util.TokenKey, d.customerid, d.paymatched, d.payfee, d.deferredmatched, d.deferredfee);

               // update statatus
               Informing2Row(d.customerid, true);
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
         ShowNotice("Hạch toán nợ ngày T hoàn tất.");
         CloseWaiting();
         toolStripButton1.Enabled = true;
      }

      public void CalculateClearingDeferred(DataGridViewRow r)
      {
         decimal balanceAmount, feeAmount, matchedAmount;
         decimal nophi, notienmua, thuphi, thutienmua;
         nophi = notienmua = thuphi = thutienmua = 0M;
         balanceAmount = (decimal)r.Cells["currentbalance"].Value;
         matchedAmount = (decimal)r.Cells["matched"].Value;
         feeAmount = (decimal)r.Cells["fee"].Value;
         if (balanceAmount >= feeAmount + matchedAmount) // kh du tien de thu het no
         {
            thuphi = feeAmount;
            thutienmua = matchedAmount;
            r.Cells["active"].Value = true;
         }
         else if ((int)r.Cells["hd"].Value != 0) // khong co hop dong thi khong cho thu no
         {
            if (balanceAmount >= feeAmount)
            {
               if (balanceAmount < feeAmount + 1000000)
               {
                  thuphi = feeAmount;
                  notienmua = matchedAmount;
               }
               else
               {
                  decimal deferred = decimal.Floor((balanceAmount - feeAmount) / 100000) * 100000;
                  notienmua = matchedAmount - deferred;
                  thuphi = feeAmount;
                  thutienmua = deferred;
               }
            }
            else
            {
               nophi = feeAmount;
               notienmua = matchedAmount;
            }
            r.Cells["active"].Value = true;
         }
         else if ((int)r.Cells["hd"].Value == 0)
         {
            r.DefaultCellStyle.SelectionBackColor = r.DefaultCellStyle.BackColor = Color.Red;
         }
         r.Cells["thuphi"].Value = thuphi;
         r.Cells["thutienmua"].Value = thutienmua;
         r.Cells["tongthu"].Value = thuphi + thutienmua;

         r.Cells["nophi"].Value = nophi;
         r.Cells["notienmua"].Value = notienmua;
         r.Cells["deferredamount"].Value = nophi + notienmua;
      }

      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 0)
            return;

         foreach (DataGridViewRow r in dataGridView1.SelectedRows)
         {
            r.Cells["active"].Value = false;
            r.Cells["tongthu"].Value = r.Cells["thutienmua"].Value = r.Cells["thuphi"].Value =
            r.Cells["notienmua"].Value = r.Cells["nophi"].Value = r.Cells["deferredamount"].Value = 0M;
         }

         UpdateGridState();
      }

      private void UpdateGridState()
      {
         decimal thuphi, thutienmua, nophi, notienmua;
         decimal tPhi, tGoc, tnPhi, tnGoc, rowactive;
         tPhi = tGoc = tnPhi = tnGoc = rowactive = 0M;
         foreach (DataGridViewRow gridRow in dataGridView1.Rows)
         {
            if (IsActive(gridRow))
            {
               if (decimal.TryParse(gridRow.Cells["thuphi"].Value.ToString(), out thuphi))
                  tPhi += thuphi;
               if (decimal.TryParse(gridRow.Cells["thutienmua"].Value.ToString(), out thutienmua))
                  tGoc += thutienmua;
               if (decimal.TryParse(gridRow.Cells["nophi"].Value.ToString(), out nophi))
                  tnPhi += nophi;
               if (decimal.TryParse(gridRow.Cells["notienmua"].Value.ToString(), out notienmua))
                  tnGoc += notienmua;

               for (int i = 0; i < gridRow.Cells.Count; i++)
                  gridRow.Cells["tongthu"].Style.BackColor = gridRow.Cells["deferredamount"].Style.BackColor = Color.YellowGreen;
               rowactive++;
            }
            else
            {
               for (int i = 0; i < gridRow.Cells.Count; i++)
                  gridRow.Cells["tongthu"].Style.BackColor = gridRow.Cells["deferredamount"].Style.BackColor = gridRow.DefaultCellStyle.BackColor;
            }
            thuphi = thutienmua = nophi = notienmua = 0M;
         }
         soTienChoNoLabel.Text = string.Format("{0:n0} : phí {1:n0} - gốc {2:n0}", tnPhi + tnGoc, tnPhi, tnGoc);
         soTienSeThuLabel.Text = string.Format("{0:n0} : phí {1:n0} - gốc {2:n0}", tPhi + tGoc, tPhi, tGoc);
         lblSoKH.Text = string.Format("Số KH hạch toán {0}/{1}", rowactive, dataGridView1.Rows.Count);
         toolStripButton2.Enabled = tnPhi + tnGoc + tPhi + tGoc > 0;
      }

      private void toolStripButton5_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 0)
            return;

         foreach (DataGridViewRow r in dataGridView1.SelectedRows)
         {
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

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_HachToanChoNoChamTienNgayT);
      }

      private void dataGridView1_Sorted(object sender, EventArgs e)
      {
         dataGridView1.ClearSelection();
         UpdateGridState();
      }
   }
}
