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
   public partial class BankTransactiontReportForm : FormBase
   {
      public BankTransactiontReportForm()
      {
         InitializeComponent();
         GUIUtil.FormatDatePicker(fromDate);
         GUIUtil.FormatDatePicker(toDate);
         comboBox1.DataSource = new DropDownObject[] {
            new DropDownObject("", "Chưa duyệt"),
            new DropDownObject("", "Đã duyệt"),
            new DropDownObject("", "Chưa phát vay"),
            new DropDownObject("", "Đã phát vay"),
            new DropDownObject("", "Phải thu nợ"),
            new DropDownObject("", "Đã thu nợ"),
            new DropDownObject("", "Có bán CK cầm cố")
         };
         comboBox1.DisplayMember = "Description";
         comboBox1.ValueMember = "Code";
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_InDSHDUTVoiNH);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ShowWaiting();

         CloseWaiting();
      }
   }
}
