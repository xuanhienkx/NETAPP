using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VRMApp.Brokerage;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;

namespace VRMApp.Accountant
{
    public partial class CustomerIncomeTax : FormBase
    {
        private const string TaxAccountNumber = "333511";
        private const string CustodyAccountNumber = "511611";
        public CustomerIncomeTax()
        {
            InitializeComponent();
            BindDate();
            this.cbBranch.DisplayMember = "Text";
            this.cbBranch.ValueMember = "Value";
            btImportData.Enabled = false;
            var item = new[]
            {
                new { Value = "All", Text = "<Tất cả>" }, 
                new { Value = "100", Text = "100" },  
                new { Value = "200", Text =  "200" }
            };
            cbBranch.DataSource = item;
        }

        protected void BindDate()
        {
            var date = DateTime.Now.AddMonths(-1);
            var firstDate = new DateTime(date.Year, date.Month, 1);
            fromDate.Value = firstDate;
            todate.Value = firstDate.AddMonths(1).AddDays(-1);
        }
        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_ImprotThuethunhapcanhan);
        }

        private IncomeTax[] listSbs;
        private void btSbsIncomTaxGet_Click(object sender, EventArgs e)
        {
            ShowWaiting("Đang lấy dữ liệu từ sbs ...");
            var accontN = tax.Checked ? TaxAccountNumber : CustodyAccountNumber;
            var data = Util.VRMService.GetSbsIncomeTax(Util.TokenKey, cbBranch.SelectedValue.ToString(), fromDate.Value,
                todate.Value, accontN);
            if (!data.Any())
            {
                ShowNotice(@"Không có dữ liệu");
                return;
            }
            exportXLS.Enabled = true;
            listSbs = data;
            gSBS.DataSource = data;
            btImportData.Enabled = true;
            totallsbs.Text = data.Count().ToString("##,###");
            totalTaxSbs.Text = data.Sum(x => x.Amount).ToString("##,###");
            ShowNotice(string.Format("Có {0} dòng dữ liệu", data.Count()));
        }

        private void btKtIncomtaxGet_Click(object sender, EventArgs e)
        {
            ShowWaiting("Đang lấy dữ liệu từ Kế toán ...");
            var accontN = tax.Checked ? TaxAccountNumber : CustodyAccountNumber;
            var data = Util.VRMService.GetKtIncomeTax(Util.TokenKey, cbBranch.SelectedValue.ToString(), fromDate.Value,
                todate.Value, accontN);
            if (!data.Any())
            {
                ShowNotice(@"Không có dữ liệu");
                return;
            }
            totalkt.Text = data.Count().ToString("##,###");
            gKetoan.DataSource = data;
            totalTaxKT.Text = data.Sum(x => x.Amount).ToString("##,###");
            ShowNotice(string.Format("Có {0} dòng dữ liệu", data.Count()));
        }

        private void btImportData_Click(object sender, EventArgs e)
        {
            ShowWaiting("Đang lấy import dữ liệu ...");
            gKetoan.DataSource = null;

            if (!listSbs.Any())
            {
                ShowNotice(@"Phải lấy dữ liệu tu sbs trước khi import");
                return;
            }
            // ShowWaiting("Đang import dữ liệu sbs vào kế toán ...");
            var accontN = tax.Checked ? TaxAccountNumber : CustodyAccountNumber;
            var data = Util.VRMService.InsertKtIncomeTax(Util.TokenKey, cbBranch.SelectedValue.ToString(), fromDate.Value, todate.Value, accontN);
            gKetoan.DataSource = data;
            totalTaxKT.Text = data.Sum(x => x.Amount).ToString("##,###");
            totalkt.Text = data.Count().ToString("##,###");
            btImportData.Enabled = false;
            // CloseWaiting();
            ShowNotice(string.Format("Import dữ liệu thành công {0} dòng", data.Count()));
        }

        private void exportXLS_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaiting("Đang xữ lý ...");
                string fileName = tax.Checked ? @"ThueTNCN.xls" : @"LUUKY.xls";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                //CsvExport(fileName);
                DataSet ds = new DataSet();
                if (gSBS.Rows.Count > 0)
                {
                    ds.Tables.Add(gSBS.GridToTable());
                }
                CloseWaiting();
                Util.ExcelExport(ds, fileName, true);

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
