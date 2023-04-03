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
    public partial class PriceAveragecs : FormBase
    {
        private DateTimePicker from;
        private DateTimePicker to;
        private VariableCapitalPrice capitalPrice;

        public PriceAveragecs()
        {
            InitializeComponent();
            GUIUtil.FormatGridView(dataGridView1);
            from = new DateTimePicker();
            from.MaxDate = Util.CurrentTransactionDate;
            to = new DateTimePicker();
            //orderDate.Value = DateTime.Now.AddDays(-3);
            GUIUtil.FormatDatePicker(from);
            GUIUtil.FormatDatePicker(to);
            this.toolStrip1.Items.Insert(5, new ToolStripControlHost(from));
            this.toolStrip1.Items.Insert(7, new ToolStripControlHost(to)); 
            this.txtorderDate.Value = Util.CurrentTransactionDate;
        }
  
        private void UpdateList()
        {
            variableCapitalPriceBindingSource.DataSource = Util.VRMService.VariableCapitalPrices(Util.TokenKey,
                txtFStockCode.Text.Trim(), from.Value, to.Value);
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
            if (string.IsNullOrEmpty(txtStockCode.Text))
            {
                ShowError("Mã chứng khoán không được để trống!");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                ShowError("Giá không được để trống!");
            }
            else if (Convert.ToDecimal(txtPrice.Text) <= 0)
            {
                ShowError("Giá phải lớn hơn 0!");
            }
            else
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
                ShowNotice("Cập nhật thành công");
            }
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
            this.txtStockCode.Enabled = true;
            this.txtorderDate.Enabled = true;
            this.txtPrice.Text = "";
            this.txtStockCode.Text = "";
            this.txtorderDate.Value = Util.CurrentTransactionDate;
            this.capitalPrice = null;
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == ShowQuestion("Bạn có muốn xóa giá vốn này không ?"))
            {
                Util.VRMService.DeleteVariableCapitalPric(Util.TokenKey, this.capitalPrice);
                UpdateList();
                ShowNotice("Xóa thành công");
            }
        }
    }
}
