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
   public partial class OnlineTransferListForm : StdForm
   {
      DateTimePicker contractDate = new DateTimePicker();
      CheckBox autoRefresh = new CheckBox();
      public OnlineTransferListForm()
      {
         InitializeComponent();
         this.toolStrip1.Items.Insert(1, new ToolStripControlHost(contractDate));
         this.toolStrip1.Items.Insert(10, new ToolStripControlHost(autoRefresh));
         GUIUtil.FormatDatePicker(contractDate);
         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.AddContextMenuOnColumns(dataGridView1);

         autoRefresh.Text = "Tự động cập nhật danh sách";
         autoRefresh.Click += new EventHandler(autoRefresh_Click);

         trangThaiCombo.ComboBox.DataSource = new DropDownObject[] {
            new DropDownObject(string.Empty, "<Tất cả>"),
            new DropDownObject("O", "O - Chờ xử lý"),
            new DropDownObject("A", "A - Đang xử lý"),
            new DropDownObject("E", "E - Bị từ chối"),
            new DropDownObject("T", "T - Đã thực hiện"),
            new DropDownObject("X", "X - Đã bị hủy"),
            
            
         };
         trangThaiCombo.ComboBox.DisplayMember = "Description";
         trangThaiCombo.ComboBox.ValueMember = "Code";
         UpdateStatus(dataGridView1);
      }

      public override bool CheckAccess()
      {
          return Util.CheckAccess(AccessPermission.KeToan_DuyetGiaoDichChuyenTien);
      }


      void autoRefresh_Click(object sender, EventArgs e)
      {
         if (autoRefresh.Checked)
         {
            trangThaiCombo.SelectedIndex = 1;
            toolStripButton1.PerformClick();
            
            timer.Interval = 7000;
            timer.Start();
         }
         else
            timer.Stop();

         trangThaiCombo.Enabled = !autoRefresh.Checked;
      }


      private void timer_Tick(object sender, EventArgs e)
      {
         toolStripButton1.PerformClick();
         if (onlineTransferBindingSource.Count > 0)
            Util.MainMDI.ShowNotification("Có {0:n0} yêu cầu chuyển tiền internet chờ xử lý!", onlineTransferBindingSource.Count);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(new object[] { contractDate.Value,(trangThaiCombo.SelectedItem as DropDownObject).Code });
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
          object[] args = e.Argument as object[];
          e.Result = Util.VRMService.GetOnlineTransferList(Util.TokenKey, string.Empty, string.Empty, (DateTime)args[0], (DateTime)args[0], (string)args[1]);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
          onlineTransferBindingSource.DataSource = e.Result;
          UpdateStatus(dataGridView1);
      }


      private void chơXưLyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //ChangeStaus("O");
      }

      private void eĐangXửLýToolStripMenuItem_Click(object sender, EventArgs e)
      {
          //ChangeStaus("E");
      }

      private void aĐaTaoHĐToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //ChangeStaus("A");
      }

      private void xBiTưChôiToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //ChangeStaus("X");
      }

      private void ChangeStaus(string status)
      {
          VRMApp.VRMGateway.OnlineTransfer obj = onlineTransferBindingSource.Current as VRMApp.VRMGateway.OnlineTransfer;
         if (obj == null)
            return;

         //Util.VRMService.OnlineTransferChangeStatus(Util.TokenKey, obj.TransferID, status);
         if (!autoRefresh.Checked)
            toolStripButton1.PerformClick();
      }

      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {

      }

      private void xulyyeucauToolStripButton_Click(object sender, EventArgs e)
      {
          VRMApp.VRMGateway.OnlineTransfer objItem = onlineTransferBindingSource.Current as VRMApp.VRMGateway.OnlineTransfer;
          if (objItem == null)
              return;

          OnlineTransferForm frm = new OnlineTransferForm(objItem);
          frm.ShowDialog();
          if (!autoRefresh.Checked)
              toolStripButton1.PerformClick();

      }

      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
          if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0)
              return;
          xulyyeucauToolStripButton.PerformClick();

      }

      private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
          if (dataGridView1.Columns[e.ColumnIndex].Name == "statusDataGridViewTextBoxColumn")
          {
              if (e.Value.ToString() == "O")
              {
                  e.CellStyle.ForeColor = Color.Blue;
                  e.Value = "O - Chờ xử lý";
              }
              if (e.Value.ToString() == "A")
              {
                  e.CellStyle.ForeColor = Color.Orange;
                  e.Value = "A - Đang xử lý";
              }
              if (e.Value.ToString() == "E")
              {
                  e.CellStyle.ForeColor = Color.Red;
                  e.Value = "E - Bị từ chối";
              }
              if (e.Value.ToString() == "T")
              {
                  e.CellStyle.ForeColor = Color.DarkGreen;
                  e.Value = "T - Đã thực hiện";
              }
              if (e.Value.ToString() == "X")
              {
                  e.CellStyle.ForeColor = Color.DarkGray;
                  e.Value = "X - Đã bị hủy";
              }
          }
      }

      private void printToolStripButton_Click(object sender, EventArgs e)
      {
          OnlineTransferPrintForm frm = new OnlineTransferPrintForm();
          frm.ShowDialog();

          

      }


   }
}
