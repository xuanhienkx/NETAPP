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
using VRMApp.Accountant;
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;

namespace VRMApp.Brokerage
{
   public enum ContractListAction
   {
      All,
      Approve,
      Disburse,
      Withdraw
   }

   public partial class ContractListForm : ListFormBase
   {
      ContractListAction formAction = ContractListAction.All;

      DateTimePicker fromDate = new DateTimePicker();
      DateTimePicker toDate = new DateTimePicker();
      ToolStripButton approveButton = new ToolStripButton();
      ToolStripButton disbursedButton = new ToolStripButton();
      ToolStripButton withdrawButton = new ToolStripButton();

      public ContractListForm() : this(ContractListAction.All) { }

      public ContractListForm(ContractListAction formAction)
      {
         this.formAction = formAction;

         InitializeComponent();
         HideExportButton = true;
         DeleteButton.Text = "Kết thúc";
         GUIUtil.FormatGridView(dataGridView1);
         GUIUtil.FormatDatePicker(fromDate);
         GUIUtil.FormatDatePicker(toDate);
         GUIUtil.AddContextMenuOnColumns(dataGridView1);

         fromDate.Value = Util.CurrentTransactionDate.AddMonths(-1);
         this.toolStrip1.Items.Insert(4, new ToolStripControlHost(fromDate));
         this.toolStrip1.Items.Insert(6, new ToolStripControlHost(toDate));

         comboStatus.ComboBox.DisplayMember = "Description";
         comboStatus.ComboBox.ValueMember = "Code";
         if (formAction == ContractListAction.All)
         {
            comboStatus.ComboBox.DataSource = new DropDownObject[]{
               new DropDownObject(VRMGateway.ContractStatus.None.ToString(), "<Tất cả>"),
               new DropDownObject(VRMGateway.ContractStatus.ChoDuyet.ToString(), "Chờ duyệt"),
               new DropDownObject(VRMGateway.ContractStatus.DaDuyet.ToString(), "Đã duyệt"),
               new DropDownObject(VRMGateway.ContractStatus.DaGiaiNgan.ToString(), "Đã giải ngân"),
               new DropDownObject(VRMGateway.ContractStatus.KetThuc.ToString(), "Đã thanh lý")
               };

            if (Util.CheckAccess(AccessPermission.MoiGioi_DuyetHopDong))
            {
               approveButton.Image = Properties.Resources.accept;
               approveButton.Text = "Duyệt";
               approveButton.TextImageRelation = TextImageRelation.ImageBeforeText;
               approveButton.Click += new EventHandler(approveButton_Click);
               this.mainToolStrip.Items.Add(new ToolStripSeparator());
               this.mainToolStrip.Items.Add(approveButton);
            }
         }

         ShowDataAsStatus();
      }

      private void ShowDataAsStatus()
      {
         if (formAction == ContractListAction.All)
            return;

         if (formAction == ContractListAction.Disburse && Util.CheckAccess(AccessPermission.KeToan_GiaiNganHopDong))
         {
            disbursedButton.Image = Properties.Resources.goldset;
            disbursedButton.Text = "Giải ngân";
            disbursedButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            disbursedButton.Click += new EventHandler(disbursedButton_Click);
            this.mainToolStrip.Items.Add(new ToolStripSeparator());
            this.mainToolStrip.Items.Add(disbursedButton);
            comboStatus.ComboBox.DataSource = new DropDownObject[] { 
               new DropDownObject(VRMGateway.ContractStatus.None.ToString(), "<Tất cả>"),
               new DropDownObject(VRMGateway.ContractStatus.DaDuyet.ToString(), "Đã duyệt"),
               new DropDownObject(VRMGateway.ContractStatus.DaGiaiNgan.ToString(), "Đã giải ngân") 
            };
            //DisbursedBy.Visible = DisbursedDate.Visible = disbursedAmountDataGridViewTextBoxColumn.Visible = true;
         }
         else if (formAction == ContractListAction.Withdraw && Util.CheckAccess(AccessPermission.KeToan_ThanhLyHopHong))
         {
            withdrawButton.Image = Properties.Resources.axdown;
            withdrawButton.Text = "Thanh lý";
            withdrawButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            withdrawButton.Click += new EventHandler(withdrawButton_Click);
            this.mainToolStrip.Items.Add(new ToolStripSeparator());
            this.mainToolStrip.Items.Add(withdrawButton);
            comboStatus.ComboBox.DataSource = new DropDownObject[] { 
               new DropDownObject(VRMGateway.ContractStatus.DaGiaiNgan.ToString(), "Đã giải ngân") 
            };
            //DisbursedBy.Visible = DisbursedDate.Visible = disbursedAmountDataGridViewTextBoxColumn.Visible = interestAmountDataGridViewTextBoxColumn.Visible =
            //WithdrawBy.Visible = WithdrawDate.Visible = disbursedAmountDataGridViewTextBoxColumn.Visible = true;
         }
         HideDeleteButton = HidePrintButton = true;
         NewButton.Enabled = ModifyButton.Enabled = false;
         toolStripButton1.PerformClick();
      }

      internal ContractListAction ShowAsAction
      {
         get { return formAction; }
      }

      void approveButton_Click(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null || dc.ContractStatus != VRMGateway.ContractStatus.ChoDuyet)
            return;

         ModifyButton.PerformClick();
      }

      void disbursedButton_Click(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null)
            return;

         // giai ngan tại đây
         DisburseContractForm dF = new DisburseContractForm();
         dF.CurrentContract = dc;
         dF.ShowDialog(this);

         // update lại hơp đồng
         if (dF.Disbursed && dF.CurrentContract.DisbursedAmount == dF.CurrentContract.ApprovalAmount)
         {
            contractBindingSource.RemoveCurrent();
         }
      }

      void withdrawButton_Click(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null)
            return;

         // thanh lý tại đây
         WithdrawContractForm f = new WithdrawContractForm();
         f.CurrentContract = dc;
         f.ShowDialog(this);

         // update lại hơp đồng
         if (f.IsWithdraw)
         {
            contractBindingSource.RemoveCurrent();
         }
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         if (!backgroundWorker.IsBusy && !backgroundWorker.CancellationPending)
         {
            backgroundWorker.RunWorkerAsync(new object[] 
            { 
               maKHBox.Text,
               fromDate.Value,
               toDate.Value,
               comboStatus.ComboBox.SelectedValue
            });
         }
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         object[] args = e.Argument as object[];
         if (formAction == ContractListAction.Disburse)
            e.Result = new List<Contract>(Util.VRMService.GetContractsForDisburse(Util.TokenKey, (string)args[0], (DateTime)args[1], (DateTime)args[2], (VRMGateway.ContractStatus)Enum.Parse(typeof(VRMGateway.ContractStatus), (string)args[3])));
         else if (formAction == ContractListAction.Withdraw)
            e.Result = new List<Contract>(Util.VRMService.GetContractsForWithdraw(Util.TokenKey, (string)args[0], (DateTime)args[1], (DateTime)args[2]));
         else
            e.Result = new List<Contract>(Util.VRMService.FindContracts(Util.TokenKey, (string)args[0], VRMGateway.ContractType.Both, (DateTime)args[1], (DateTime)args[2], (VRMGateway.ContractStatus)Enum.Parse(typeof(VRMGateway.ContractStatus), (string)args[3])));
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
         else
         {
            contractBindingSource.DataSource = e.Result as List<Contract>;
            UpdateStatus(dataGridView1);
         }
      }

      private void ContractListForm_NewButtonClick(object sender, EventArgs e)
      {
         ContractForm cf = new ContractForm(null);
         if (cf.ShowDialog() == DialogResult.OK && cf.Contract != null)
            contractBindingSource.Add(cf.Contract);
      }

      private void ContractListForm_EditButtonClick(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null)
            return;

         ContractForm cf = new ContractForm(dc);
         if (cf.ShowDialog() == DialogResult.OK)
            contractBindingSource.ResetCurrentItem();
      }

      private void dataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null)
            return;
         DeleteButton.Enabled = dc.ContractStatus == VRMGateway.ContractStatus.ChoDuyet || dc.ContractStatus == VRMGateway.ContractStatus.DaDuyet;
         approveButton.Enabled = dc.ContractStatus == VRMGateway.ContractStatus.ChoDuyet;
         giahanButton.Enabled = dc.ContractType == VRMApp.VRMGateway.ContractType.CoThoiHan && dc.ContractStatus == VRMApp.VRMGateway.ContractStatus.DaGiaiNgan;
      }

      private void ContractListForm_DeleteButtonClick(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc != null && (dc.ContractStatus == VRMGateway.ContractStatus.ChoDuyet || dc.ContractStatus == VRMGateway.ContractStatus.DaDuyet))
         {
            dc.ContractStatus = VRMGateway.ContractStatus.KetThuc;
            Util.VRMService.SaveContract(Util.TokenKey, dc, 0);
            contractBindingSource.ResetCurrentItem();
         }
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_HopDongHTKD);
      }

      private void ContractListForm_PrintButtonClick(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null)
            return;
         ReportUtil.ShowHopDongKD(dc);
      }

      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0)
            return;
         ModifyButton.PerformClick();
      }

      private void giahanButton_Click(object sender, EventArgs e)
      {
         Contract dc = contractBindingSource.Current as Contract;
         if (dc == null || dc.ContractType != VRMApp.VRMGateway.ContractType.CoThoiHan
            || dc.ContractStatus != VRMApp.VRMGateway.ContractStatus.DaGiaiNgan)
            return;

         ContractForm cf = new ContractForm(dc, ContractForm.Mode.Renew);
         if (cf.ShowDialog() == DialogResult.OK)
            contractBindingSource.ResetCurrentItem();
      }
   }
}
