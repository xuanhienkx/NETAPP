using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Operation
{
   public partial class AgencyFee : ListFormBase
   {
       delegate void UpdateGrid(List<AgencyFee> source);

      public AgencyFee()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_CapNhatPhiDaiLy; }
      }

      private void AgencyFee_Load(object sender, EventArgs e)
      {
         ExportButton.Visible = PrintButton.Visible = false;
         GUIUtil.FormatGridView(dataGridView);
         BindInfo();
      }

      private void BindInfo()
      {
          dataGridView.DataSource = Util.AgencyGateway.GetAgencyFeeByTradeCode(Util.TokenKey);

         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
            backgroundWorker.RunWorkerAsync();
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {

          //List<AgencyFee> source = new List<AgencyFee>(Util.AgencyGateway.GetAgencyFeeByTradeCode(Util.TokenKey));
          //List<Customer> source1 = new List<Customer>(Util.AgencyGateway.FindCustomers(Util.TokenKey, customerId, string.Empty, string.Empty));
          //UpdateDataSource(source);
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);

          
         UpdateStatus(dataGridView);
      }

      private void UpdateDataSource(List<AgencyFee> source)
      {
         if (dataGridView.InvokeRequired)
            dataGridView.Invoke(new UpdateGrid(UpdateDataSource), new object[] { source });
         else
            customerBindingSource.DataSource = source;
      }

      private void AgencyFee_NewButtonClick(object sender, EventArgs e)
      {
          AgencyFeeAddEdit objF = new AgencyFeeAddEdit();
          objF.ShowDialog();
          BindInfo();
      }

      private void AgencyFee_EditButtonClick(object sender, EventArgs e)
      {
          AgencyFeeAddEdit objF = new AgencyFeeAddEdit();
          objF.FeeID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
          objF.ShowDialog();
          BindInfo();
      }

      private void AgencyFee_DeleteButtonClick(object sender, EventArgs e)
      {
          if (ShowQuestion("Bạn có chắc chắn không") == DialogResult.Yes)
          {
              int feeID = 0;
              feeID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
              if (feeID != 0)
                  Util.AgencyGateway.DeleteAgencyFee(Util.TokenKey, feeID);
              else
                  ShowNotice("Không thực hiện được");
              BindInfo();
          }
      }
   }
}
