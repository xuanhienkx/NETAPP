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
    public partial class SummaryCustodyForm : FormBase
    {
        DateTimePicker fromDate, interestDate;
        public SummaryCustodyForm()
        {
            InitializeComponent();
            fromDate = new DateTimePicker();
            interestDate = new DateTimePicker();
            GUIUtil.FormatDatePicker(fromDate);
            GUIUtil.FormatDatePicker(interestDate); 
            this.toolStrip1.Items.Insert(2, new ToolStripControlHost(fromDate));
            this.toolStrip1.Items.Insert(3, new System.Windows.Forms.ToolStripLabel("đến ngày:"));
            this.toolStrip1.Items.Insert(4, new ToolStripControlHost(interestDate));
            fromDate.Value = fromDate.Value.AddMonths(-1);
        }

        private void btnTinhFee_Click(object sender, EventArgs e)
        {
            ShowWaiting("Đang lấy dữ liệu ...");
            btnTinhFee.Enabled = false;
            DateTime fromD = fromDate.Value;
            DateTime toDate = interestDate.Value;
            try
            {
                var data = Util.VRMService.SummaryCustody(Util.TokenKey, fromD, toDate,(decimal) Util.Parameters.CustodyFeeRate);
                dataGridView1.DataSource = data;
                var tQuantity = data.Sum(x => x.Quantity);
                var tAmount = data.Sum(x => x.Amount);
                lblTongSL.Text = tQuantity.ToString("N0");
                lblTongPhi.Text = tAmount.ToString("N0");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            CloseWaiting();
        }
        public override bool CheckAccess()
        {
            var check = Util.CheckAccess(AccessPermission.LuuKy_Tinhphiluuky);
            return check;
        }
    }
}
