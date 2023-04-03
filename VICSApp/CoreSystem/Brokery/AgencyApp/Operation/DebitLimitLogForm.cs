using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Operation
{
   public partial class DebitLimitLogForm : FormBase
   {
      private readonly DateTimePicker fromPicker;
      private readonly DateTimePicker toPicker;

      public DebitLimitLogForm() : this(string.Empty)
      {
      }

      public DebitLimitLogForm(string customerId)
      {
         InitializeComponent();
         fromPicker = new DateTimePicker();
         toPicker = new DateTimePicker();

         toolStrip1.Items.Insert(1, new ToolStripControlHost(fromPicker));
         toolStrip1.Items.Insert(3, new ToolStripControlHost(toPicker));


         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.FormatDatePicker(fromPicker);
         GUIUtil.FormatDatePicker(toPicker);

         if (!string.IsNullOrEmpty(customerId))
         {
            txtCustomerId.Text = customerId;
            UpdateList();
         }
      }

      private void UpdateList()
      {
         var data = Util.AgencyGateway.GetCustomerDebitLimitLog(Util.TokenKey, txtCustomerId.Text, fromPicker.Value,
            toPicker.Value);
         customerDebitLimitLogBindingSource.DataSource = data;
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Debitlimit_XemHanMucTinDungChoKhachHang; }
      }

      private void btnFind_Click(object sender, EventArgs e)
      {
         UpdateList();
      }
   }
}
