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
   public partial class CustomerForm : FormBase
   {
      Customer dc;
      public bool IsUpdateable = true;
      public CustomerForm()
      {
         InitializeComponent();
         saveButton.Enabled = tilyNumberUpDown.Enabled = Util.CheckAccess(AccessPermission.QTRR_ThietLapTiLeHopTac);
      }

      public CustomerForm(Customer customer)
         : this()
      {
         dc = customer;
      }

      private void UpdateDataInfo(Customer dc)
      {
         lblCustomerName.Text = dc.CustomerName;
         textBox1.Text = dc.CustomerId;
         if (dc.MarginRate.HasValue)
            tilyNumberUpDown.Value = (decimal)dc.MarginRate;
      }

      private void textBox1_Enter(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(textBox1.Text))
         {
            textBox1.Text = "076C0";
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
         }
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         try
         {
            dc = Util.VRMService.GetCustomer(Util.TokenKey, textBox1.Text.Trim());
            if (dc == null)
               throw new Exception();
            UpdateDataInfo(dc);
         }
         catch
         {
            ShowError("Không thấy khách hàng");
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            textBox1.Focus();
            return;
         }
      }

      private void saveButton_Click(object sender, EventArgs e)
      {
         if (dc == null)
         {
            ShowError("Này, chưa vấn tin thông tin khách hàng đầy đủ mà muốn lưu hả?!\nVấn tin lại đi chứ.");
            return;
         }

         dc.MarginRate = (byte)tilyNumberUpDown.Value;
         Util.VRMService.UpdateVRMCustomerInfo(Util.TokenKey, dc.CustomerId, dc.MarginRate.Value, dc.IsSpecial);
         if (findButton.Visible)
         {
            if (ShowQuestion("Bạn tiếp tục cập nhật tỉ lệ cầm cố cho khách hàng nữa chứ?") == DialogResult.Yes)
            {
               dc = new Customer();
               UpdateDataInfo(dc);
               IsUpdateable = false;
               return;
            }
         }
         this.Close();
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         IsUpdateable = false;
         this.Close();
      }

      private void CustomerForm_Load(object sender, EventArgs e)
      {
         if (dc != null)
         {
            UpdateDataInfo(dc);
            textBox1.ReadOnly = true;
            findButton.Visible = false;
         }
      }

      public override bool CheckAccess()
      {
         return true;
      }
   }
}
