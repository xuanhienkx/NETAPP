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
   public partial class BankTransactionForm : FormBase
   {
      public bool isAnBinhBank;
      public BankTransactionForm() : this(false)
      {
      }

      public BankTransactionForm(bool notAnBinhAsDefault)
      {
         InitializeComponent();
         GUIUtil.FormatDatePicker(NgayGDdateTimePicker);
         isAnBinhBank = !notAnBinhAsDefault;

         if (isAnBinhBank)
         {
            if (Util.LoginUser.BranchCode == "100")
            {
               txtSection.Text = "112306";
               txtBank.Text = "9999";
               TKTextBox.Text = "1123060001";
            }
         }
         else
         {
            this.Text = "Liệt kê giao dịch tiền";
            txtSection.Text = txtBank.Text = TKTextBox.Text = string.Empty;
         }
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_LietKeGiaoDichTienNH);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ShowWaiting();
         Reports.ReportUtil.ShowGiaoDichNH(NgayGDdateTimePicker.Value, txtSection.Text.Trim(), txtBank.Text.Trim(), TKTextBox.Text.Trim(), isAnBinhBank? "NH An Bình" : string.Empty);
         
         CloseWaiting();
      }
   }
}
