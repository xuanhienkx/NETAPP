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
   public partial class OnlineTransferHistForm : StdForm
   {
      DateTimePicker fromDate = new DateTimePicker();
      DateTimePicker toDate = new DateTimePicker();
      
      public OnlineTransferHistForm()
      {
         InitializeComponent();
         this.toolStrip1.Items.Insert(1, new ToolStripControlHost(fromDate));
         this.toolStrip1.Items.Insert(4, new ToolStripControlHost(toDate));

         GUIUtil.FormatDatePicker(fromDate);
         GUIUtil.FormatDatePicker(toDate);

         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.AddContextMenuOnColumns(dataGridView1);


         trangThaiCombo.ComboBox.DataSource = new DropDownObject[] {
            new DropDownObject(string.Empty, "<Tất cả>"),
            new DropDownObject("O", "O - Chờ xử lý"),
            new DropDownObject("E", "E - Đang xử lý"),
            new DropDownObject("A", "A - Đã thực hiện"),
            new DropDownObject("X", "X - Bị từ chối")
         };
         trangThaiCombo.ComboBox.DisplayMember = "Description";
         trangThaiCombo.ComboBox.ValueMember = "Code";
         UpdateStatus(dataGridView1);
      }


      public override bool CheckAccess()
      {
          return Util.CheckAccess(AccessPermission.KeToan_DuyetGiaoDichChuyenTien);
      }


      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         e.Result = Util.VRMService.GetOnlineTransferList(Util.TokenKey, (string)args[2], (string)args[3], (DateTime)args[0], (DateTime)args[1], (string)args[4]);
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         onlineTransferBindingSource.DataSource = e.Result;
         UpdateStatus(dataGridView1);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(new object[] { fromDate.Value,toDate.Value,customerIDToolStripTextBox.Text,accountIDTolStripTextBox.Text,(trangThaiCombo.SelectedItem as DropDownObject).Code });
      }

      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
          if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0)
              return;

          VRMApp.VRMGateway.OnlineTransfer objItem = onlineTransferBindingSource.Current as VRMApp.VRMGateway.OnlineTransfer;
          if (objItem == null)
              return;

          OnlineTransferForm frm = new OnlineTransferForm(objItem);
          frm.viewOnly = true;
          frm.ShowDialog();

      }

   }
}
