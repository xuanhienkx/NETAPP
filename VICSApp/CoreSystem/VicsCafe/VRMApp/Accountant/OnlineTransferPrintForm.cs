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
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;
using System.Globalization;


namespace VRMApp.Accountant
{
    public partial class OnlineTransferPrintForm : FormBase
    {
        public OnlineTransfer onlineTransfer;
        public bool viewOnly = false;

        public OnlineTransferPrintForm()
        {
            InitializeComponent();
        }

        private void OnlineTransferForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void printContractButton_Click(object sender, EventArgs e)
        {
            ShowWaiting();
            CrystalDecisions.CrystalReports.Engine.ReportClass rp;
            DataTable data;

            rp = new VRMApp.Reports.Accountant.TongHopChuyenTien();
            string status = "";
            if (executeRadioButton.Checked)
                status = "'T'";
            else
                status = "'O','A','E','X'";

            data = Util.VRMService.GetOnlineTransferReport(Util.TokenKey, fromDateTimePicker.Value, toDateTimePicker.Value, status);
            //if (Reports.ReportUtil.DataNotValidated(data.Rows.Count))
            //    return;

            
            rp.SetDataSource(data);

            if (executeRadioButton.Checked)
                rp.SetParameterValue("ReportTitle", "BẢNG TỔNG HỢP YÊU CẦU CHUYỂN KHOẢN ĐƯỢC THỰC HIỆN");
            else
                rp.SetParameterValue("ReportTitle", "BẢNG TỔNG HỢP YÊU CẦU CHUYỂN KHOẢN KHÔNG ĐƯỢC THỰC HIỆN");

            if (fromDateTimePicker.Value.ToString("dd/MM/yyyy") == toDateTimePicker.Value.ToString("dd/MM/yyyy"))
                rp.SetParameterValue("DateTitle", "Ngày: " + fromDateTimePicker.Value.ToString("dd/MM/yyyy"));
            else
                rp.SetParameterValue("DateTitle",string.Format("Từ ngày: {0} đến ngày {1} ",fromDateTimePicker.Value.ToString("dd/MM/yyyy"),toDateTimePicker.Value.ToString("dd/MM/yyyy"))); 

            Reports.ReportViewerForm.LoadReport(rp, null);

            CloseWaiting();

        }




    }
}
