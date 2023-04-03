using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Accountant
{
    public partial class IssuedAccountForm : StdForm
    {
        DataTable dataSource;
        ToolStripLabel labelAmount;
        public IssuedAccountForm()
        {
            InitializeComponent();
            GUIUtil.FormatGridView(gridNghiepVu);
            GUIUtil.FormatGridView(gridButToan);
            GUIUtil.FormatGridView(gridCo);
            GUIUtil.FormatGridView(gridNo);
            gridNghiepVu.MultiSelect = true;
            labelAmount = new ToolStripLabel();
            statusStrip.Items.Add(labelAmount);

            nghiepVuCombo.ComboBox.DataSource = new DropDownObject[]{
            new DropDownObject(string.Empty, "<Tất cả>"),
            new DropDownObject("APTT3", "VCF - Tiền mua ngày T"),
            new DropDownObject("INTER", "VCF - Tính lãi"),
             new DropDownObject("CTODY", "VCF - Tính phí lưu ký"),
            new DropDownObject("DEFER", "VCF - Thu nợ chậm tiền T"),
            new DropDownObject("VRMDC", "VCF - Giải ngân HĐ kỳ hạn"),
            new DropDownObject("VRMWC", "VCF - Thanh lý HĐ kỳ hạn")
         };

            trangThaiCombo.ComboBox.DataSource = new DropDownObject[]{
            new DropDownObject("N", "Chờ duyệt"),
            new DropDownObject("Y", "Đã duyệt")
         };
            nghiepVuCombo.ComboBox.ValueMember = trangThaiCombo.ComboBox.ValueMember = "Code";
            nghiepVuCombo.ComboBox.DisplayMember = trangThaiCombo.ComboBox.DisplayMember = "Description";

            DataTable data = Util.VRMService.GetUserTransCodeList(Util.TokenKey);
            DataRow row = data.NewRow();
            row["userTransCode"] = string.Empty;
            row["userName"] = "<Tất cả>";
            data.Rows.InsertAt(row, 0);
            nguoiNhapCombo.ComboBox.DataSource = data;
            nguoiNhapCombo.ComboBox.ValueMember = "userTransCode";
            nguoiNhapCombo.ComboBox.DisplayMember = "userName";
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_XemCacButToanHachToan);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            {
                if (!string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue))
                {
                    gridNghiepVu.Columns[0].HeaderText = "Mã khách hàng";
                    gridButToan.Columns["nhomnghiepvu"].Visible = true;
                }
                else
                {
                    gridNghiepVu.Columns[0].HeaderText = "Nhóm nghiệp vụ";
                    gridButToan.Columns["nhomnghiepvu"].Visible = false;
                }

                backgroundWorker1.RunWorkerAsync(new string[] {
               (string)nguoiNhapCombo.ComboBox.SelectedValue,
               (string)nghiepVuCombo.ComboBox.SelectedValue,
               (string)trangThaiCombo.ComboBox.SelectedValue,
               taiKhoanTextBox.Text.Trim()
            });
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowWaiting("Đang lấy dữ liệu");
            string[] args = e.Argument as string[];
            e.Result = Util.VRMService.GetIssuedTransactionList(Util.TokenKey, args[0], args[1], args[2], args[3]);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                return;
            }

            dataSource = e.Result as DataTable;
            ShowIssuedAccount();
            if (dataSource != null)
            {
                if (nghiepVuCombo.ComboBox.SelectedItem != null)
                    toolStripButton6.Enabled = !string.IsNullOrEmpty((nghiepVuCombo.ComboBox.SelectedItem as DropDownObject).Code)
                       && dataSource.Rows.Count > 0 && Util.CheckAccess(AccessPermission.KeToan_XoaButToan);
                toolStripexportExcel.Enabled = dataSource.Rows.Count > 0;
                toolStripButton2.Enabled = toolStripButton6.Enabled && Util.CheckAccess(AccessPermission.KeToan_DuyetButToan) && "N".Equals(trangThaiCombo.ComboBox.SelectedValue);

            }
            UpdateStatus(gridNghiepVu);
            CloseWaiting();
        }

        private void ShowIssuedAccount()
        {
            gridNghiepVu.Rows.Clear();

            string transCode = string.Empty;
            foreach (DataRow r in dataSource.Rows)
            {
                if (string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue) && transCode != (string)r["TransactionCode"])
                {
                    transCode = (string)r["TransactionCode"];
                    gridNghiepVu.Rows.Add(transCode);
                }
                else if (!string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue) && transCode != (string)r["Notes"])
                {
                    transCode = (string)r["Notes"];
                    gridNghiepVu.Rows.Add(transCode);
                }
            }
        }

        private void gridNghiepVu_SelectionChanged(object sender, EventArgs e)
        {
            if (gridNghiepVu.Rows.Count == 0)
                return;

            gridButToan.Rows.Clear();

            string tempCode, transCode;
            string transNumber = string.Empty;
            decimal amount = 0M;
            decimal totalAmount = 0M;
            foreach (DataGridViewRow row in gridNghiepVu.SelectedRows)
            {
                tempCode = (string)row.Cells[0].Value;
                transCode = tempCode;
                foreach (DataRow r in dataSource.Rows)
                {
                    if ((string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue) && transCode != (string)r["TransactionCode"]) ||
                       (!string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue) && tempCode != (string)r["Notes"]))
                        continue;

                    if (!string.IsNullOrEmpty((string)nghiepVuCombo.ComboBox.SelectedValue))
                        transCode = (string)r["TransactionCode"];

                    if (transNumber != (string)r["TransactionNumber"])
                    {
                        if ("C".Equals(r["DebitOrCredit"]))
                            amount += (decimal)r["Amount"];
                        transNumber = (string)r["TransactionNumber"];
                    }
                    else
                    {
                        if ("C".Equals(r["DebitOrCredit"]))
                            amount += (decimal)r["Amount"];
                        else if (amount > 0)
                        {
                            gridButToan.Rows.Add(transCode, transNumber, amount, r["Description"], r["UserName"], r.IsNull("Approver") ? string.Empty : r["Approver"], tempCode);
                            totalAmount += amount;
                            amount = 0M;
                        }
                    }
                }
            }
            labelAmount.Text = string.Format("| Tổng số tiền được chọn: {0:n0}", totalAmount);
        }

        private void gridButToan_SelectionChanged(object sender, EventArgs e)
        {
            if (gridButToan.Rows.Count == 0)
                return;

            gridCo.Rows.Clear();
            gridNo.Rows.Clear();

            string transCode = (string)gridButToan.CurrentRow.Cells["nhomnghiepvu"].Value;
            string transNumber = (string)gridButToan.CurrentRow.Cells["buttoan"].Value;
            foreach (DataRow r in dataSource.Rows)
            {
                if (transCode != (string)r["TransactionCode"] || transNumber != (string)r["TransactionNumber"])
                    continue;

                if ((string)r["DebitOrCredit"] == "C")
                {
                    gridCo.Rows.Add(
                       (string)r["accountid"],
                       (decimal)r["Amount"],
                       (string)r["AccountName"]
                       );
                }
                else
                {
                    gridNo.Rows.Add(
                       (string)r["accountid"],
                       (decimal)r["Amount"],
                       (string)r["AccountName"]
                       );
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (gridNghiepVu.Rows.Count * gridButToan.Rows.Count == 0)
                return;

            if (ShowQuestion("Bạn có chắc muốn xóa các bút toán của khách hàng đang chọn không?") == DialogResult.No)
                return;

            if (!backgroundWorker2.IsBusy && !backgroundWorker2.CancellationPending)
            {
                backgroundWorker2.RunWorkerAsync(new object[] {
               gridButToan.CurrentRow.Cells["nhomnghiepvu"].Value,
               gridNghiepVu.SelectedRows,
               (string) trangThaiCombo.ComboBox.SelectedValue
            });
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowWaiting();
            object[] args = e.Argument as object[];
            string nghiepVu = (args[0] as string).Substring(0, 5); // chi lay 5 ky tu dau tien
            DataGridViewSelectedRowCollection rows = args[1] as DataGridViewSelectedRowCollection;

            foreach (DataGridViewRow r in rows)
            {
                ShowWaiting(string.Format("Đang hủy các bút toán liên quan đến TK {0}", r.Cells[0].Value));
                Util.VRMService.DeleteIssuedTransaction(Util.TokenKey, (string)r.Cells[0].Value, nghiepVu, (string)args[2]);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                ShowError(e.Error.Message);
            else
                toolStripButton1.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (gridNghiepVu.Rows.Count * gridButToan.Rows.Count == 0)
                return;

            if (ShowQuestion("Bạn có chắc muốn duyệt các bút toán đang chọn không?") == DialogResult.No)
                return;

            if (!backgroundWorker3.IsBusy && !backgroundWorker3.CancellationPending)
            {
                backgroundWorker3.RunWorkerAsync(gridButToan.Rows);
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowWaiting();
            DataGridViewRowCollection rows = e.Argument as DataGridViewRowCollection;

            foreach (DataGridViewRow r in rows)
            {
                Util.VRMService.ApproveTransaction(Util.TokenKey,
                   (string)r.Cells["customerid"].Value,
                   (string)r.Cells["buttoan"].Value,
                   Util.CurrentTransactionDate);
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                ShowError(e.Error.Message);
            toolStripButton1.PerformClick();
        }

        private void toolStripexportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaiting("Đang xữ lý ...");
                string fileName = @"butoan.xls";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                DataSet ds = new DataSet();
                if (gridButToan.Rows.Count > 0)
                {
                    DataTable dt =  gridButToan.GridToTable();
                    ds.Tables.Add(dt);
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
