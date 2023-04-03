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
using UnitTrade = Brokery.AgencyWebService.UnitTrade;


namespace Brokery.Operation
{
   public partial class SetupDebitLimitForm : FormBase
   {
      private readonly List<UnitTrade> unitTrades;
      private List<AgencyWebService.GroupDebitLimit> groupDebit;
      private AgencyWebService.GroupDebitLimit selectedGroup;

      public SetupDebitLimitForm() : this(null)
      {
      }

      public SetupDebitLimitForm(AgencyWebService.GroupDebitLimit selectedGroup)
      {
         InitializeComponent();
         this.selectedGroup = selectedGroup;

         GUIUtil.FormatTextBoxForNumber(txtAmount);
         GUIUtil.FormatDropDownList(cboBranches);
         GUIUtil.FormatDropDownList(cboAgents);
         GUIUtil.FormatTextBoxForNumber(txtAmount);

         unitTrades = new List<UnitTrade>(Util.AgencyGateway.GetUnitTradeCodes(Util.TokenKey));
         BuildDropdownlist();
      }

      private IEnumerable<GroupDebitLimit> GroupDebits
      {
         get
         {
            return groupDebit ??
                   (groupDebit =
                      new List<GroupDebitLimit>(Util.AgencyGateway.GetUnitDebitLimits(Util.TokenKey,
                         Util.CurrentTransactionDate)));
         }
      }

      private void BuildDropdownlist()
      {
         cboBranches.Items.Clear();
         if (unitTrades == null)
            return;

         cboBranches.Items.Add(new DropDownObject(string.Empty, "<Chọn đơn vị>"));
         unitTrades.ForEach(x =>
                            {
                               if (x.Type < 3)
                                  cboBranches.Items.Add(new DropDownObject(x.TradeCode, x.Name));
                            });
         if (selectedGroup != null)
         {
            if (selectedGroup.UnitType == 0)
            {
               cboBranches.SelectedIndex =
                  cboBranches.Items.IndexOf(new DropDownObject(selectedGroup.TradeCode, selectedGroup.Name));
               txtAmount.Text = selectedGroup.DebitLimitAmount.ToString();
            }
            else
            {
               var unit = unitTrades.Single(x => x.TradeCode == selectedGroup.TradeCode);
               cboBranches.SelectedIndex =
                  cboBranches.Items.IndexOf(new DropDownObject(unit.ParentTradeCode, string.Empty));
            }
         }
         else
         {
            cboBranches.SelectedIndex = 0;
         }
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get
         {
            yield return AccessPermission.VICS_DebitLimit_CapHanMucTinDungDauNgay;
            yield return AccessPermission.VICS_Debitlimit_XemHanMucTinDungDauNgay;
         }
      }

      private void cboBranches_SelectedIndexChanged(object sender, EventArgs e)
      {
         cboAgents.Items.Clear();
         var branchItem = cboBranches.SelectedItem as DropDownObject;
         if (branchItem == null || unitTrades == null)
            return;

         cboAgents.Items.Add(new DropDownObject(string.Empty, "<None>"));
         unitTrades.ForEach(x =>
         {
            if (x.Type == 3  && x.ParentTradeCode == branchItem.Code)
               cboAgents.Items.Add(new DropDownObject(x.TradeCode, x.Name));
         });

         if (selectedGroup != null && selectedGroup.UnitType == 1)
         {
            cboAgents.SelectedIndex =
               cboAgents.Items.IndexOf(new DropDownObject(selectedGroup.TradeCode, selectedGroup.Name));
            txtAmount.Text = selectedGroup.DebitLimitAmount.ToString();
         }
         else
         {
            cboAgents.SelectedIndex = 0;   
         }
         
         var branchDebitLimit = GroupDebits.SingleOrDefault(x => x.TradeCode == branchItem.Code);
         if (branchDebitLimit == null)
         {
            lblTotalDebitAmount.Text = lblUsedDebitLimitAmount.Text = lblCurrentDebitLimit.Text = ((decimal)0).AsCurrency();
         }
         else
         {
            lblTotalDebitAmount.Text = branchDebitLimit.DebitLimitAmount.AsCurrency();
            lblUsedDebitLimitAmount.Text = branchDebitLimit.DebitLimitDay.AsCurrency();
            lblCurrentDebitLimit.Text = branchDebitLimit.CurrentDebitLimit.AsCurrency();
         }
      }

      private void btnAccept_Click(object sender, EventArgs e)
      {
         var selectItem = cboAgents.SelectedItem as DropDownObject;
         if (selectItem == null || string.IsNullOrEmpty(selectItem.Code))
         {
            if (Util.LoginUser.BranchCode == "200")
               selectItem = cboBranches.SelectedItem as DropDownObject;
            else
            {
               ShowError("Chi nhánh không được cấp hạn mức tín dụng hoặc đơn vị cần phân bổ hạn mức tín dụng chưa được chọn.");
               return;
            }
         }

         if (selectItem == null || string.IsNullOrEmpty(selectItem.Code))
         {
            ShowError("Xin vui lòng chọn đơn vị cần phân bổ hạn mức tín dụng.");
            return;
         }

         if (string.IsNullOrEmpty(txtAmount.Text))
         {
            ShowError("Hạn mức tín dụng phân bổ không được để trống.");
            return;
         }

         var amount = decimal.Parse(txtAmount.Text);
         var debitGroup = GroupDebits.FirstOrDefault(x => x.TradeCode == selectItem.Code);

         if (debitGroup != null && amount < debitGroup.DebitLimitDay)
         {
            ShowError("Hạn mức tín dụng phân bổ mới không được nhỏ hơn số tiền hiện đang bị thiếu.");
            return;
         }
         var unit = unitTrades.SingleOrDefault(x => x.TradeCode == selectItem.Code);
         if (unit == null)
         {
            ShowError("Không xác định được đơn vị cần phân bổ hạn mức tín dụng");
            return;
         }

         try
         {
            Util.AgencyGateway.CreateUnitDebitLimit(Util.TokenKey, unit.BranchCode, unit.TradeCode, amount,
               Util.CurrentTransactionDate);
            
            if (ShowQuestion("Hạn mức đã được cập nhật. Bạn có muốn thực hiện tiếp?") == DialogResult.Yes)
            {
               selectedGroup = null;
               groupDebit = null;
               cboBranches.SelectedIndex = 0;
               txtAmount.Text = string.Empty;
            }
            else
            {
               this.DialogResult = DialogResult.OK;
               this.Close();
            }
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);    
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void cboAgents_SelectedIndexChanged(object sender, EventArgs e)
      {
         var agentItem = cboAgents.SelectedItem as DropDownObject;
         if (agentItem == null || unitTrades == null)
            return;

         var agentDebitLimit = GroupDebits.SingleOrDefault(x => x.TradeCode == agentItem.Code);
         if (agentDebitLimit == null)
         {
            lblAgenDebit.Text =
               lblAgentUsed.Text = lblAgentCurrent.Text = ((decimal)0).AsCurrency();
         }
         else
         {
            lblAgenDebit.Text = agentDebitLimit.DebitLimitAmount.AsCurrency();
            lblAgentUsed.Text = agentDebitLimit.DebitLimitDay.AsCurrency();
            lblAgentCurrent.Text = agentDebitLimit.CurrentDebitLimit.AsCurrency();
         }
      }
   }
}
