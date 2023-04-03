using System;
using System.Collections;
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

namespace VRMApp.RiskMan
{
    public partial class PriceAdvance : FormBase
    {
        private DateTimePicker from;
        private DateTimePicker to;
        private VariableCapitalPrice capitalPrice;

        public PriceAdvance()
        {
            InitializeComponent();
            GUIUtil.FormatGridView(dataGridView1);
            from = new DateTimePicker();
            to = new DateTimePicker();
            //orderDate.Value = DateTime.Now.AddDays(-3);
            GUIUtil.FormatDatePicker(from);
            GUIUtil.FormatDatePicker(to);
            this.toolStrip1.Items.Insert(5, new ToolStripControlHost(from));
            this.toolStrip1.Items.Insert(7, new ToolStripControlHost(to));
            this.txtorderDate.MaxDate = DateTime.Now;
        }

        public PriceAdvance(VariableCapitalPrice capitalPrice)
            : this()
        {
            if (capitalPrice != null)
            {
                this.capitalPrice = capitalPrice;
            }
        }



        private void UpdateList()
        {
            variableCapitalPriceBindingSource.DataSource = Util.VRMService.VariableCapitalPrices(Util.TokenKey,
                txtFStockCode.Text.Trim(), from.Value,to.Value);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void PriceAdvance_Load(object sender, EventArgs e)
        {
            if (capitalPrice != null)
            {

            }
            UpdateList();
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.QTRR_GiaVonBinhQuan);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (this.capitalPrice != null)
            {
                capitalPrice.Price = Convert.ToDecimal(txtPrice.Text);
            }
            else
            {
                capitalPrice = new VariableCapitalPrice();
                capitalPrice.Price = Convert.ToDecimal(txtPrice.Text);
                capitalPrice.StockCode = txtStockCode.Text;
                capitalPrice.TransactionDate = from.Value;
                capitalPrice.Id = Guid.Empty;
            }
            Util.VRMService.SaveVariableCapitalPric(Util.TokenKey, this.capitalPrice);
            UpdateList();

        } 

        public VariableCapitalPrice ConvertRowToVariableCapitalPrice(DataGridViewRow row)
        {
            this.txtPrice.Text = row.Cells["Price"].Value.ToString();
            this.txtStockCode.Text = row.Cells["StockCode"].Value.ToString();
            this.txtorderDate.Value = Convert.ToDateTime(row.Cells["TransactionDate"].Value.ToString());
            txtStockCode.Enabled = false;
            txtorderDate.Enabled = false;

            var result = new VariableCapitalPrice();
            result.Id = Guid.Parse(row.Cells["Id"].Value.ToString());
            result.Price = Convert.ToDecimal(row.Cells["Price"].Value.ToString());
            result.StockCode = row.Cells["StockCode"].Value.ToString();
            result.TransactionDate = Convert.ToDateTime(row.Cells["TransactionDate"].Value.ToString());

            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow != null && dgv.CurrentRow.Selected)
            {
                DataGridViewRow row = dgv.CurrentRow;
                this.capitalPrice = ConvertRowToVariableCapitalPrice(row);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtPrice.Text = "";
            this.txtStockCode.Text = "";
            this.txtorderDate.Value = DateTime.Now;
            txtStockCode.Enabled = true;
            txtorderDate.Enabled = true;
        }
    }
}
