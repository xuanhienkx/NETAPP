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
using GroupDebitLimit = Brokery.AgencyWebService.GroupDebitLimit;

namespace Brokery.Operation
{
   public partial class UnitDebitLimitListForm : FormBase
   {
      public UnitDebitLimitListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         btnEdit.Enabled = Util.CheckAccess(AccessPermission.VICS_DebitLimit_CapHanMucTinDungDauNgay);
         UpdateList();
      }

      private void UpdateList()
      {
         var data = new List<GroupDebitLimit>(Util.AgencyGateway.GetUnitDebitLimits(Util.TokenKey, Util.CurrentTransactionDate));
         groupDebitLimitBindingSource.DataSource = data;

         decimal totalDebit = 0;
         decimal totalUsed = 0;
         data.ForEach(limit =>
                      {
                         if (limit.UnitType == 0) // hach toan rieng
                         {
                            totalDebit += limit.DebitLimitAmount;
                            totalUsed += limit.DebitLimitDay;
                         }
                      });

         lblNote.Text = string.Format("TỔNG HẠN MỨC ĐÃ CẤP: {0:c0} - ĐÃ SỬ DỤNG: {1:c0} - CÒN LẠI: {2:c0}", totalDebit,
            totalUsed, totalDebit - totalUsed);
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Debitlimit_XemHanMucTinDungDauNgay; }
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         UpdateList();
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         var selectedItem = groupDebitLimitBindingSource.Current as GroupDebitLimit;
         var result = FormBase.ShowDialog<SetupDebitLimitForm>(() => new SetupDebitLimitForm(selectedItem));
         if (result == DialogResult.OK)
         {
            UpdateList();
         }
      }
   }
}
