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
using CustomerDebitLimit = Brokery.AgencyWebService.CustomerDebitLimit;
using CustomerDebitTransaction = Brokery.AgencyWebService.CustomerDebitTransaction;

namespace Brokery.Operation
{
   public partial class DebitLimitListForm : FormBase
   {
      public DebitLimitListForm()
      {
         InitializeComponent();

         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.FormatGridView(dataGridView2);

         UpdateList();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_Debitlimit_XemHanMucTinDungChoKhachHang; }
      }

      private void btnFind_Click(object sender, EventArgs e)
      {
         UpdateList();
      }

      private void UpdateList()
      {
         var debitDat = new List<CustomerDebitLimit>(Util.AgencyGateway.GetCustomerDebitLimit(Util.TokenKey, txtCustomerId.Text,
            Util.CurrentTransactionDate));
         customerDebitLimitBindingSource.DataSource = debitDat;

         decimal debit = 0;
         decimal current = 0;
         debitDat.ForEach(x =>
                          {
                             debit += x.LimitValue;
                             current += x.CurrentLimitValue;
                          });
         lblNote.Text = string.Format("TỔNG HẠN MỨC ĐÃ CẤP: {0:C0} - SỐ TIỀN ĐANG MUA THIẾU: {1:C0}", debit, current);
         customerDebitTransactionBindingSource.DataSource = new List<CustomerDebitTransaction>();
      }

      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         var deb = customerDebitLimitBindingSource.Current as CustomerDebitLimit;
         btnEdit.Enabled = deb != null;
         if (deb == null)
            return;

         var logDat = Util.AgencyGateway.GetCustomerDebitTransactions(Util.TokenKey, deb.CustomerID);
         customerDebitTransactionBindingSource.DataSource = new List<CustomerDebitTransaction>(logDat);
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         var deb = customerDebitLimitBindingSource.Current as CustomerDebitLimit;
         var result = FormBase.ShowDialog<DebitLimitForm>(() => new DebitLimitForm(deb));
         if (result == DialogResult.OK)
            UpdateList();
      }

      private void btnViewHistory_Click(object sender, EventArgs e)
      {
         var deb = customerDebitLimitBindingSource.Current as CustomerDebitLimit;
         var customerId = deb == null ? string.Empty : deb.CustomerID;
         FormBase.Show<DebitLimitLogForm>(() => new DebitLimitLogForm(customerId));
      }
   }
}
