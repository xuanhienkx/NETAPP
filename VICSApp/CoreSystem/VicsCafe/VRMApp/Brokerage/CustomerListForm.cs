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
   public partial class CustomerListForm : StdForm
   {
      List<Customer> data;
      public CustomerListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView);

         if (Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach))
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

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_DanhSachKhachHang);
      }

      private void CustomerListForm_Load(object sender, EventArgs e)
      {
         UpdateStatus(dataGridView);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            backgroundWorker.RunWorkerAsync(new object[] { maKHBox.Text, nvchamsoccb.ComboBox.SelectedValue });
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting();
         object[] args = e.Argument as object[];
         string customerId = (string)args[0];
         int userTk = string.IsNullOrEmpty((string)args[1]) ? 0 : int.Parse((string)args[1]);
         data = new List<Customer>(Util.VRMService.FindCustomers(Util.TokenKey, customerId, userTk));
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
            customerBindingSource.DataSource = data;
            UpdateStatus(dataGridView);
            dataGridView.Columns["isspecial"].Visible = toolStripButton2.Enabled =
            toolStripButton3.Enabled = toolStripButton4.Enabled =
               Util.CheckAccess(AccessPermission.QTRR_TheoGioiKhachHangDacBiet) && customerBindingSource.Count > 0;

         }
         CloseWaiting();
      }

      private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         Customer c = customerBindingSource.Current as Customer;
         if (c == null)
            return;

         CustomerForm cF = new CustomerForm(c);
         cF.ShowDialog();
         if (cF.IsUpdateable)
            customerBindingSource.ResetCurrentItem();
      }

      private void toolStripButton2_Click(object sender, EventArgs e)
      {
         Customer c = customerBindingSource.Current as Customer;
         if (c == null)
            return;

         if (ShowQuestion(string.Format("Bạn thực sự muốn đưa khách hàng {0} vào danh sách đặc biệt?", c.CustomerId)) == DialogResult.No)
            return;
         byte rate = c.MarginRate.HasValue ? c.MarginRate.Value : byte.MinValue;
         Util.VRMService.UpdateVRMCustomerInfo(Util.TokenKey, c.CustomerId, rate, true);
         c.IsSpecial = true;
         customerBindingSource.ResetCurrentItem();
      }

      private void toolStripButton3_Click(object sender, EventArgs e)
      {
         Customer c = customerBindingSource.Current as Customer;
         if (c == null)
            return;
        
         if (ShowQuestion(string.Format("Bạn thực sự muốn loại khách hàng {0} ra khỏi danh sách đặc biệt?", c.CustomerId)) == DialogResult.No)
            return;
         byte rate = c.MarginRate.HasValue ? c.MarginRate.Value : byte.MinValue;
         Util.VRMService.UpdateVRMCustomerInfo(Util.TokenKey, c.CustomerId, rate, false);
         c.IsSpecial = false;
         customerBindingSource.ResetCurrentItem();
      }

      private void toolStripButton4_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(customerBindingSource.Filter))
         {
            customerBindingSource.Filter = "IsSpecial != false";
            toolStripButton4.Text = "Bỏ lọc các ds KH đặc biệt";
            customerBindingSource.DataSource = data.Where(c => c.IsSpecial == true);            
         }
         else
         {
            customerBindingSource.Filter = string.Empty;
            toolStripButton4.Text = "Lọc ra ds KH đặc biệt";
            customerBindingSource.DataSource = data;
         }
         UpdateStatus(dataGridView);
      }
   }
}
