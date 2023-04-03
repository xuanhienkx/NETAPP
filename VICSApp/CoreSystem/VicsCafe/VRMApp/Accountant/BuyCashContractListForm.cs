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
   public partial class BuyCashContractListForm : StdForm
   {
      DateTimePicker contractDate = new DateTimePicker();
      CheckBox autoRefresh = new CheckBox();
      public BuyCashContractListForm()
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
            new DropDownObject("A", "A - Đã tạo HĐ"),
            new DropDownObject("X", "X - Bị từ chối")
         };
         trangThaiCombo.ComboBox.DisplayMember = "Description";
         trangThaiCombo.ComboBox.ValueMember = "Code";
         UpdateStatus(dataGridView1);
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

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KetToan_UngTruocInternet);
      }

      private void timer_Tick(object sender, EventArgs e)
      {
         toolStripButton1.PerformClick();
         if (buyCashContractBindingSource.Count > 0)
            Util.MainMDI.ShowNotification("Có {0:n0} yêu cầu ứng trước internet chờ xử lý!", buyCashContractBindingSource.Count);
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         e.Result = Util.VRMService.GetBuyCashContractList(Util.TokenKey, (DateTime)args[0], (string)args[1]);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         buyCashContractBindingSource.DataSource = e.Result;
         UpdateStatus(dataGridView1);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(new object[] { contractDate.Value, (trangThaiCombo.SelectedItem as DropDownObject).Code });
      }

      private void chơXưLyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeStaus("O");
      }

      private void aĐaTaoHĐToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeStaus("A");
      }

      private void xBiTưChôiToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeStaus("X");
      }

      private void ChangeStaus(string status)
      {
         VRMApp.VRMGateway.BuyCashContract obj = buyCashContractBindingSource.Current as VRMApp.VRMGateway.BuyCashContract;
         if (obj == null)
            return;

         Util.VRMService.ChangeBuyCashContractStatus(Util.TokenKey, obj.Id, status);
         if (!autoRefresh.Checked)
            toolStripButton1.PerformClick();
      }
   }
}
