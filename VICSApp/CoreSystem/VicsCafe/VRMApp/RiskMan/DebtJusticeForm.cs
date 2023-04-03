using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using VRMApp.Framework;
using VRMApp.ControlBase;
using VRMApp.VRMGateway;

namespace VRMApp.RiskMan
{
   public partial class DebtJusticeForm : FormBase
   {
      public class TransData
      {
         public Customer Customer;
         public decimal Balance;
         public decimal TongNo;
         public decimal TongTS;
         public decimal TiLeNo;
         public decimal F1;
         public decimal F2;
         public decimal SoTienDuocRut;
      }

      private CustAssetInfo data;
      public DebtJusticeForm(CustAssetInfo data)
      {
         this.data = data;
         this.Text = string.Format("Xử lý công nợ cho khách hàng {0} - Tài khoản: {1}", data.CustomerName, data.CustomerID);
         InitializeComponent();

         GUIUtil.FormatGridView(dataGridView, true);
         GUIUtil.FormatTextBoxForNumber(txtTienRutToiDa);
         dataGridView.Columns[0].ReadOnly = dataGridView.Columns[7].ReadOnly = false;
         cboHanMuc.KeyPress += new KeyPressEventHandler(GUIHelper.NumberTextBox_KeyPress);
      }

      private void DebtJustice_Load(object sender, EventArgs e)
      {
         DataTable d = Util.VRMService.GetCustomerStockEnquiry(Util.TokenKey, data.CustomerID, Util.CurrentTransactionDate);
         d.Columns.Add("conlai", typeof(long));
         foreach (DataRow r in d.Rows)
            r["conlai"] = (long)r["ckgd"] - (long)r["CKban"];

         bindingSource1.DataSource = d;
         foreach (DataGridViewRow r in dataGridView.Rows)
            if ((long)r.Cells["conlai"].Value == default(long))
            {
               r.Cells["check"].ReadOnly = true;
               r.DefaultCellStyle.BackColor = Color.Red;
            }

         lblDebtRate.Text = GUIUtil.FormatRate(data.TyLeNo / 100M, true);
         lblF1.Text = GUIUtil.FormatRate(data.TyLeF1 / 100M, true);
         lblF2.Text = GUIUtil.FormatRate(data.TyLeF2 / 100M, true);
         lblTongCo.Text = GUIUtil.MoneyAsString(data.TongTS);
         lblTongNo.Text = GUIUtil.MoneyAsString(data.TongNo);
         lblWarningRate.Text = GUIUtil.FormatRate(data.TyLeHopTac / 100M, true);
         lblHanMucToiDa.Text = GUIUtil.MoneyAsString(data.HanMucToiDa);

         DataTable dData = Util.VRMService.GetDebitLimitInfo(Util.TokenKey, data.CustomerID);
         // debit limit and trading result
         if (dData != null && dData.Rows.Count > 0)
         {
            lblHanMucDaCap.Text = GUIUtil.MoneyAsString(dData.Rows[0].IsNull("limitvalue") ? 0 : (decimal)dData.Rows[0]["limitvalue"]);
            lblHanMucDung.Text = GUIUtil.MoneyAsString(dData.Rows[0].IsNull("currentlimitvalue") ? 0 : (decimal)dData.Rows[0]["currentlimitvalue"]);
            lblLenhMuaKhop.Text = GUIUtil.MoneyAsString(dData.Rows[0].IsNull("matechebuyingdordervalue") ? 0 : (decimal)dData.Rows[0]["matechebuyingdordervalue"]);
            lblTongMua.Text = GUIUtil.MoneyAsString(dData.Rows[0].IsNull("totalbuyingordervalue") ? 0 : (decimal)dData.Rows[0]["totalbuyingordervalue"]);
            lblLastMonthValue.Text = GUIUtil.MoneyAsString(dData.Rows[0].IsNull("LastMonthTradingValue") ? 0 : (decimal)dData.Rows[0]["LastMonthTradingValue"]);
         }
      }

      private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex < 0)
            return;

         DataGridViewRow row = dataGridView.Rows[e.RowIndex];
         if (decimal.Parse(row.Cells[5].Value.ToString()) == 0M)
            return;

         bool chk = !(bool)row.Cells[0].Value;
         row.Cells[0].Value = chk;
         if (chk)
            row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = Color.Red;
         else
         {
            if (e.RowIndex % 2 == 0)
            {
               row.DefaultCellStyle.BackColor = dataGridView.DefaultCellStyle.BackColor;
               row.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.SelectionBackColor;
            }
            else
            {
               row.DefaultCellStyle.BackColor = dataGridView.AlternatingRowsDefaultCellStyle.BackColor;
               row.DefaultCellStyle.SelectionBackColor = dataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor;
            }
         }
      }

      private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
         if (e.Control is TextBox)
            GUIUtil.FormatTextBoxForNumber(e.Control as TextBox);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         decimal newRate, sotienrut;
         if (decimal.TryParse(cboHanMuc.Text, out newRate))
            newRate = newRate / 100M;
         else
            newRate = 0M;

         if (!decimal.TryParse(txtTienRutToiDa.Text, out sotienrut))
            sotienrut = 0M;

         decimal sellAmount = (data.TongNo + sotienrut - data.TongTS * newRate) / (1 - newRate);
         if (sellAmount < 0M)
         {
            txtTienRutToiDa.Text = (data.TongTS * newRate - data.TongNo).ToString();
            sellAmount = 0M;
         }

         decimal proposalSell = 0M;
         decimal price, volume, selling;
         foreach (DataGridViewRow r in dataGridView.Rows)
         {
            if (sellAmount == 0M || r.Cells[0].Value == null || !(bool)r.Cells[0].Value || r.Cells[7].Value == null)
            {
               r.Cells[6].Value = string.Empty;
               continue;
            }

            price = decimal.Parse(r.Cells[7].Value.ToString()) * 1000M;
            if (price == 0M)
            {
               r.Cells[6].Value = string.Empty;
               continue;
            }

            volume = decimal.Parse(r.Cells[5].Value.ToString());
            selling = volume * price;
            if (selling > sellAmount)
            {
               r.Cells[6].Value = GUIUtil.FormatNumber(Math.Round(sellAmount / price));
               proposalSell += sellAmount;
               sellAmount = 0M;
            }
            else
            {
               r.Cells[6].Value = r.Cells[5].Value;
               sellAmount -= selling;
               proposalSell += selling;
            }
         }
         decimal sotiennop = 0M;
         if (proposalSell == 0)
            sotiennop = data.TongNo - newRate * (data.TongTS - sotienrut);
         else if (sellAmount > 0)
            sotiennop = data.TongNo - proposalSell - newRate * (data.TongTS - sotienrut - proposalSell);

         lblTienNop.Text = GUIUtil.MoneyAsString(sotiennop);
         lblTongCKBan.Text = GUIUtil.MoneyAsString(proposalSell);
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.QTRR_XuLyKhachHangViPham);
      }
   }
}
