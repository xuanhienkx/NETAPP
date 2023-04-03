using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRM.Controls.DataGridColumnExtend;
using VRM.Controls.ExpandableGridView;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.Reports;
using VRMApp.Reports.Accountant;
using VRMApp.VRMGateway;

namespace VRMApp.Accountant
{
    public partial class DefInterestCalcForm : FormBase
    {
        public enum ShowMode
        {
            ShowAll,
            ShowForCriteria
        }
        public ShowMode showMode = ShowMode.ShowAll;

        delegate void UpdateNode(int nodeIndex);
        CheckBoxDataGridViewColumn headerCheckbox;
        DateTimePicker fromDate, interestDate;
        DataTable dataSource;
        VRMDataSet.InterestCalcDataTable dataReport;
        List<string> payableCustomers;
        List<string> paidCustomers;
        private static Dictionary<DateTime, decimal> dayAndRates = new Dictionary<DateTime, decimal>();
        private List<BalanceAccount> definedAccounts;

        public DefInterestCalcForm(ShowMode mode)
        {
            InitializeComponent();
            showMode = mode;

            if (showMode == ShowMode.ShowForCriteria)
            {
                headerCheckbox = new CheckBoxDataGridViewColumn();
                headerCheckbox.Style.BackColor = System.Drawing.SystemColors.Control;
                headerCheckbox.Value = string.Empty;
                headerCheckbox.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                treeGridView.Columns[0].HeaderCell = headerCheckbox;
                checkBoxColumn.Visible = true;
                inBangNoMenuItem.Enabled = danhSáchTổngHợpKháchHàngNợPhíToolStripMenuItem.Enabled = false;

                interestDate = new DateTimePicker();
                interestDate.MaxDate = Util.CurrentTransactionDate;
                GUIUtil.FormatDatePicker(interestDate);
                this.toolStrip1.Items.Insert(4, new ToolStripControlHost(interestDate));
            }
            else
            {
                fromDate = new DateTimePicker();
                interestDate = new DateTimePicker();
                GUIUtil.FormatDatePicker(fromDate);
                GUIUtil.FormatDatePicker(interestDate);
                this.toolStrip1.Items[3].Text = @"Chốt phí từ ngày:";
                this.toolStrip1.Items.Insert(4, new ToolStripControlHost(fromDate));
                this.toolStrip1.Items.Insert(5, new System.Windows.Forms.ToolStripLabel("đến ngày:"));
                this.toolStrip1.Items.Insert(6, new ToolStripControlHost(interestDate));
                fromDate.Value = fromDate.Value.AddMonths(-1);
            }

            GUIUtil.FormatGridView(treeGridView);
            treeGridView.Columns[5].ReadOnly = false;
            treeGridView.Columns[0].Resizable = DataGridViewTriState.False;

            // initialize day to change rate
            if (dayAndRates.Count == 0)
            {
                var interestRate = Util.InterestRate;
                if (interestRate == null)
                {
                    ShowError("Lỗi lấy phí hợp tác kinh doanh, vui lòng liên hệ IT.");
                }
                else
                {
                    dayAndRates = interestRate;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (interestDate.Value > Util.CurrentTransactionDate)
            {
                ShowError(@"Ngày hạch toán không được lớn hơn ngày giao dịch hiện tại");
            }
            else if (tsCboDinhKhoan.SelectedItem == null || string.IsNullOrEmpty(tsCboDinhKhoan.SelectedItem.ToString()))
            {
                ShowError(@"Định khoản không được để trống.");
            }
            else if (!backgroundWorker2.IsBusy && !backgroundWorker2.CancellationPending)
            {
                interestDate.Enabled = btnTinhLai.Enabled = toolStripButton1.Enabled = false;
                var index = tsCboDinhKhoan.SelectedIndex; 
                var ac = definedAccounts[index];
                backgroundWorker2.RunWorkerAsync(new object[] { treeGridView.Nodes, interestDate.Value,ac });
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            TreeGridNodeCollection nodes = args[0] as TreeGridNodeCollection;
            DateTime interestDate = (DateTime)args[1];

            BalanceAccount account = (BalanceAccount)args[2];

            decimal tienlai, balance;
            string customerid;
            bool isChecked;
            foreach (TreeGridNode n in nodes)
            {
                isChecked = bool.Parse(n.Cells[0].Value.ToString());
                if (!isChecked)
                    continue;

                tienlai = (decimal)n.Cells[9].Value;
                balance = (decimal)n.Cells[10].Value;
                if (tienlai > balance)
                {
                    UpdateTreeGrid(n.Index);
                    continue;
                }

                customerid = n.Cells[1].Value.ToString().Split('-')[0].Trim();
                ShowWaiting("Hạch toán tiền lãi khách hàng " + customerid);

                // hach toan tinh lai
                Util.VRMService.CreateRetreiveInterestTransaction(Util.TokenKey,
                    account, customerid, tienlai, interestDate);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseWaiting();
            interestDate.Enabled = btnTinhLai.Enabled = true;
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                toolStripButton1.Enabled = showMode == ShowMode.ShowForCriteria && Util.CheckAccess(AccessPermission.KeToan_HachToanTinhLaiTraCham);
                return;
            }
            ShowNotice("Hạch toán tính lãi hoàn tất.");
        }

        private void UpdateTreeGrid(int nodeIndex)
        {
            if (treeGridView.InvokeRequired)
                treeGridView.Invoke(new UpdateNode(UpdateTreeGrid), nodeIndex);
            else
            {
                treeGridView.Nodes[nodeIndex].Cells[0].Value = false;
                treeGridView.Nodes[nodeIndex].Cells[0].ReadOnly = true;
                treeGridView.Nodes[nodeIndex].Cells[1].Style.BackColor = Color.Red;
                treeGridView.Nodes[nodeIndex].Cells[4].Value = interestDate.Value;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InterestCalcDateList.Show<InterestCalcDateList>(new CreateForm(delegate() { return new InterestCalcDateList(); }));
        }

        private void treeGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    DateTime value = (DateTime)treeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void treeGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 5)
                    return;

                DataRow currentRow = dataSource.Rows[(int)treeGridView.Rows[e.RowIndex].Cells[11].Value];
                DateTime ngaytinhlai = interestDate.Value.Add(-interestDate.Value.TimeOfDay);
                DateTime ngaytrano = (DateTime)treeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                DateTime ngayno = (DateTime)currentRow["ngayno"];
                if (ngaytrano > interestDate.Value || ngaytrano < ngayno)
                {
                    MessageBox.Show(string.Format("Ngày trả nợ sửa lại phải nằm từ ngày {0} đến ngày {1}",
                       GUIUtil.FormatDate(ngayno), GUIUtil.FormatDate(ngaytinhlai)), "Lỗi");
                    treeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (DateTime)currentRow["ngaytrano"];

                    return;
                }

                // recalculate the number of day
                DateTime ngaychotlai = (DateTime)treeGridView.CurrentNode.Parent.Cells[4].Value;
                DateTime ngayquahan = (DateTime)currentRow["ngayquahan"];

                int numberOfDay = 0;//CalculatingInterestDays(ngaytinhlai, ngaytrano, ngaychotlai, ngayno, ngayquahan);
                decimal amount = (decimal)treeGridView.CurrentNode.Cells[6].Value;
                decimal interest = 0M; //CalculatingInterest(amount, numberOfDay, ngayno);
                decimal oldInterest = decimal.Parse(treeGridView.CurrentNode.Cells[9].Value.ToString().Replace(Util.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty));
                string interestCalForm = string.Empty;
                CalculateInterest(ngaytinhlai, ngaytrano, ngaychotlai, ngayno, ngayquahan, amount, out interest, out numberOfDay, out interestCalForm);

                treeGridView.CurrentNode.Cells[8].Value = numberOfDay;
                treeGridView.CurrentNode.Cells[9].Value = interest;
                treeGridView.CurrentNode.Cells[9].ToolTipText = interestCalForm.Trim(new char[] { ' ', '+' });

                // update the subtotal interest and total interest
                ReupdateInterestTotal(treeGridView.CurrentNode, interest, oldInterest);

                // update report data
                foreach (VRMDataSet.InterestCalcRow r in dataReport.Rows)
                {
                    if (r.customerid == (string)currentRow["customerid"] && r.ngayno == ngayno && r.ngaytrano == GUIUtil.FormatDate((DateTime)currentRow["ngaytrano"]))
                    {
                        r.tienlai = interest;
                        r.songaytinhlai = numberOfDay;
                        r.ngaytrano = GUIUtil.FormatDate(ngaytrano);
                        break;
                    }
                }

                // update table
                currentRow["ngaytrano"] = ngaytrano;
            }
            catch
            {
            }
        }

        private void ReupdateInterestTotal(TreeGridNode currentNode, decimal amount, decimal oldAmount)
        {
            // lai tren transaction
            decimal curentAmount = decimal.Parse(currentNode.Parent.Cells[9].Value.ToString().Replace(Util.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty));
            currentNode.Parent.Cells[9].Value = curentAmount - oldAmount + amount;

            // lai tren khach hang
            curentAmount = decimal.Parse(currentNode.Parent.Parent.Cells[9].Value.ToString().Replace(Util.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty));
            currentNode.Parent.Parent.Cells[9].Value = curentAmount - oldAmount + amount;

            // tong lai
            curentAmount = decimal.Parse(lblTongLai.Text.Replace(Util.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty));

            // check or uncheck to issued
            decimal balance = decimal.Parse(currentNode.Parent.Parent.Cells[10].Value.ToString().Replace(Util.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty));
            currentNode.Parent.Parent.Cells[0].Value = balance >= curentAmount - oldAmount + amount;

            lblTongLai.Text = GUIUtil.MoneyAsString(curentAmount - oldAmount + amount);
        }

        private void treeGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && string.IsNullOrEmpty(treeGridView[1, e.RowIndex].Value.ToString()))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void treeGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (TreeGridNode node in treeGridView.Nodes)
                {
                    node.Cells[0].Value = headerCheckbox.CheckAll;
                }
            }
        }

        private void btnTinhLai_Click(object sender, EventArgs e)
        {
            if (interestDate.Value > Util.CurrentTransactionDate)
            {
                ShowError("Ngày hạch toán không được lớn hơn ngày hiện tại");
            }
            else if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            {
                ShowWaiting("Đang lấy dữ liệu ...");
                btnTinhLai.Enabled = false;
                DateTime from = (showMode == ShowMode.ShowAll) ? fromDate.Value : DateTime.MinValue;
                DateTime to = interestDate.Value;
                backgroundWorker1.RunWorkerAsync(new object[] { txtCustomerId.Text, from, to });
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            e.Result = Util.VRMService.GetCustomerDeferredTranList(Util.TokenKey, (string)args[0], (DateTime)args[1], (DateTime)args[2]);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                return;
            }
            ShowWaiting("Đang tính phí ....");
            dataSource = e.Result as DataTable;

            try
            {
                CalculatingInterest();

                if (headerCheckbox != null)
                {
                    toolStripButton1.Enabled = treeGridView.Rows.Count > 0 && Util.CheckAccess(AccessPermission.KeToan_HachToanTinhLaiTraCham);
                    tsCboDinhKhoan.Enabled = headerCheckbox.CheckAll = toolStripButton1.Enabled;
                }

                // lay cac tai khoan dinh khoan
                if (tsCboDinhKhoan.Items.Count == 0)
                {
                    definedAccounts = new List<BalanceAccount>(Util.VRMService.GetDefinedBalanceAccounts(Util.TokenKey, "HTKD"));
                    tsCboDinhKhoan.ComboBox.Items.AddRange(definedAccounts.Select(a => a.AccountName != null ? string.Format("{0}.{1}.{2} - {3}", a.SectionGl, a.BankGl, a.AccountID, a.AccountName) : null).ToArray());
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            interestDate.Enabled = btnTinhLai.Enabled = true;

            CloseWaiting();
        }

        #region Calculating interest and building node

        private void CalculatingInterest()
        {
            treeGridView.Nodes.Clear();
            dataReport = new VRMDataSet.InterestCalcDataTable();
            payableCustomers = new List<string>();
            paidCustomers = new List<string>();

            if (dataSource == null || dataSource.Rows.Count == 0)
                return;

            DateTime ngaytinhlai = interestDate.Value.Add(-interestDate.Value.TimeOfDay);
            DateTime ngayno, ngaytrano, ngaychotlai, ngayquahan, ngaythulai;
            decimal sotienno, sotientra, nohientai;
            string custName, custId;

            TreeGridNode customerNode, debitNode;
            int songayno = 0;
            decimal laisuat, tonglai, tonglaichokh, tonglaichogd, laitienthieu;
            decimal tongno, tongnochokh, currentbalance;
            decimal tongtra, tongtrachokh, tongtrachogd;

            customerNode = debitNode = null;
            ngayno = ngaychotlai = ngaytrano = ngayquahan = ngaythulai = DateTime.MinValue;
            custId = custName = string.Empty;
            tonglaichokh = tonglaichokh = tongtra = tongno = tonglai = tonglaichogd = sotienno = nohientai = tongtrachogd =
               tongtrachokh = currentbalance = tongnochokh = sotientra = laisuat = 0M;

            if (showMode == ShowMode.ShowAll)
                ngaychotlai = fromDate.Value.Add(-fromDate.Value.TimeOfDay);

            int rowIndex = 0;
            foreach (DataRow r in dataSource.Rows)
            {
                if ((debitNode != null && !ngayno.Equals(r["ngayno"])) || (!custId.Equals(r["customerid"]) && customerNode != null))
                {
                    if (sotienno > tongtrachogd + nohientai)
                    {
                        tongtrachogd += sotienno - (tongtrachogd + nohientai);
                        debitNode.Cells[6].Value = sotienno;
                    }

                    if (nohientai > 0)
                    {
                        string calForm;
                        CalculateInterest(ngaytinhlai, Util.CurrentTransactionDate, ngaychotlai, ngayno, ngayquahan, nohientai, out laitienthieu, out songayno, out calForm);

                        InsertRemainDeferred(debitNode, nohientai, laitienthieu, songayno, rowIndex, calForm);
                        tonglaichogd += laitienthieu;

                        dataReport.AddInterestCalcRow(custId, custName, ngayno, sotienno, ngaychotlai, string.Empty, 0, nohientai, songayno, laitienthieu, currentbalance);
                    }

                    UpdateTotalPerDeferring(debitNode, tongtrachogd, tonglaichogd, nohientai);
                    tongnochokh += sotienno;
                    tongtrachokh += tongtrachogd;
                    tonglaichokh += tonglaichogd;
                    tongtrachogd = tonglaichogd = 0;
                }

                if (!custId.Equals(r["customerid"]) && customerNode != null) // kh dau tien
                {
                    if (showMode == ShowMode.ShowForCriteria && (currentbalance < tonglaichokh || currentbalance * tonglaichokh == 0))
                    {
                        treeGridView.Nodes.Remove(customerNode);
                    }
                    else
                    {
                        UpdateTotalPerCustomer(customerNode, tongnochokh, tongtrachokh, tonglaichokh, currentbalance >= tonglaichokh);
                        if (currentbalance >= tonglaichokh)
                            payableCustomers.Add(custId);
                        if (ngaythulai >= ngaytinhlai)
                            paidCustomers.Add(custId);

                        tongno += tongnochokh;
                        tongtra += tongtrachokh;
                        tonglai += tonglaichokh;
                    }
                }

                if (!custId.Equals(r["customerid"])) // new customer
                {

                    custId = (string)r["customerid"];
                    custName = (string)r["customernameviet"];
                    currentbalance = (decimal)r["currentbalance"];
                    ngaythulai = r.IsNull("ngaythu") ? DateTime.MinValue : (DateTime)r["ngaythu"];

                    if (showMode == ShowMode.ShowAll)
                    {
                        ngaychotlai = fromDate.Value.Add(-fromDate.Value.TimeOfDay);

                        // khach hang nay khong phai la no phi
                        if (ngaychotlai < ngaythulai)
                            paidCustomers.Add(custId);
                    }
                    else
                        ngaychotlai = r.IsNull("ngaychotlai") ? DateTime.MinValue : (DateTime)r["ngaychotlai"];

                    customerNode = InsertCustomerTitle(custId, custName, currentbalance);
                    tongnochokh = tongtrachokh = tonglaichokh = 0M;
                    ngayno = DateTime.MinValue;
                }

                if (!ngayno.Equals(r["ngayno"]) && custId.Equals(r["customerid"]))
                {
                    ngayno = (DateTime)r["ngayno"];
                    ngayquahan = (DateTime)r["ngayquahan"];
                    sotienno = (decimal)r["sotienno"];
                    nohientai = (decimal)r["nohientai"];
                    debitNode = InsertDeferedNode(customerNode, ngayno, sotienno, nohientai, ngaychotlai, rowIndex);
                }

                if (!r.IsNull("ngaytrano"))
                {
                    ngaytrano = (DateTime)r["ngaytrano"];
                    sotientra = (decimal)r["sotientra"];
                    nohientai = (decimal)r["nohientai"];
                    string calForm;
                    CalculateInterest(ngaytinhlai, ngaytrano, ngaychotlai, ngayno, ngayquahan, sotientra, out laisuat, out songayno, out calForm);

                    InsertDeferedPaying(debitNode, songayno, sotientra, 0, ngaytrano, laisuat, rowIndex, calForm);
                    dataReport.AddInterestCalcRow(custId, custName, ngayno, sotienno, ngaychotlai, GUIUtil.FormatDate(ngaytrano), sotientra, 0, songayno, laisuat, currentbalance);

                    tonglaichogd += laisuat;
                    tongtrachogd += sotientra;
                }

                rowIndex++;
            }

            // end of dataset
            if (customerNode != null && debitNode != null)
            {
                if (sotienno > tongtrachogd + nohientai)
                {
                    tongtrachogd += sotienno - (tongtrachogd + nohientai);
                    debitNode.Cells[6].Value = sotienno;
                }

                if (nohientai > 0)
                {
                    string calForm;
                    CalculateInterest(ngaytinhlai, Util.CurrentTransactionDate, ngaychotlai, ngayno, ngayquahan, nohientai, out laitienthieu, out songayno, out calForm);

                    InsertRemainDeferred(debitNode, nohientai, laitienthieu, songayno, --rowIndex, calForm);
                    tonglaichogd += laitienthieu;
                    dataReport.AddInterestCalcRow(custId, custName, ngayno, sotienno, ngaychotlai, string.Empty, 0, nohientai, songayno, laitienthieu, currentbalance);
                }

                UpdateTotalPerDeferring(debitNode, tongtrachogd, tonglaichogd, nohientai);
                tongnochokh += sotienno;
                tongtrachokh += tongtrachogd;
                tonglaichokh += tonglaichogd;

                if (showMode == ShowMode.ShowForCriteria && (currentbalance < tonglaichokh || currentbalance * tonglaichokh == 0))
                {
                    treeGridView.Nodes.Remove(customerNode);
                }
                else
                {
                    UpdateTotalPerCustomer(customerNode, tongnochokh, tongtrachokh, tonglaichokh, currentbalance >= tonglaichokh);
                    if (currentbalance >= tonglaichokh)
                        payableCustomers.Add(custId);
                    if (ngaythulai.DayOfYear >= ngaytinhlai.DayOfYear)
                        paidCustomers.Add(custId);


                    tongno += tongnochokh;
                    tongtra += tongtrachokh;
                    tonglai += tonglaichokh;
                }
            }

            lblTongKH.Text = treeGridView.Rows.Count.ToString();
            lblTongLai.Text = GUIUtil.MoneyAsString(tonglai);
            toolStripButton1.Enabled = (showMode == ShowMode.ShowForCriteria && Util.CheckAccess(AccessPermission.KeToan_HachToanTinhLaiTraCham));
            btnPrint.Enabled = treeGridView.RowCount > 0;
            treeGridView.Columns[0].ReadOnly = false;
        }

        private TreeGridNode InsertCustomerTitle(string custId, string custName, decimal currentBalance)
        {
            TreeGridNode node = treeGridView.Nodes.Add(true, string.Format("{0} - {1}", custId, custName),
               string.Empty, string.Empty, string.Empty, null, string.Empty, string.Empty, string.Empty, string.Empty, currentBalance);
            node.DefaultCellStyle.Font = new Font(treeGridView.DefaultCellStyle.Font, FontStyle.Bold);
            node.Cells[0].ReadOnly = false;
            node.Cells[5].ReadOnly = true;

            return node;
        }

        private TreeGridNode InsertDeferedNode(TreeGridNode node, DateTime deferedDate, decimal debtAmount, decimal remain, DateTime deferedCalcDate, int rowIndex)
        {
            TreeGridNode child = node.Nodes.Add(true, string.Empty,
               deferedDate, debtAmount, deferedCalcDate,
                  null, remain, string.Empty, string.Empty, string.Empty, string.Empty, rowIndex);
            child.DefaultCellStyle.Font = new Font(treeGridView.DefaultCellStyle.Font, FontStyle.Bold);
            child.Cells[0].ReadOnly = node.Cells[5].ReadOnly = true;
            return child;
        }

        private void InsertDeferedPaying(TreeGridNode node, int numberOfDay, decimal payAmount, decimal remain, DateTime payDate, decimal interestAmount, int rowIndex, string calForm)
        {
            node.Nodes.Add(true, string.Empty, string.Empty, string.Empty, string.Empty,
              payDate, payAmount, remain, numberOfDay, interestAmount, string.Empty, rowIndex)
              .Cells[9].ToolTipText = calForm.Trim(new char[] { '+', ' ' });
            node.Cells[0].ReadOnly = true;
        }

        private void InsertRemainDeferred(TreeGridNode node, decimal defAmount, decimal interestAmount, int numberOfDay, int rowIndex, string calForm)
        {
            node.Nodes.Add(true, string.Empty, string.Empty, string.Empty, string.Empty,
               null, string.Empty, defAmount, numberOfDay, interestAmount, string.Empty, rowIndex)
               .Cells[9].ToolTipText = calForm.Trim(new char[] { '+', ' ' });

            node.Cells[0].ReadOnly = node.Cells[5].ReadOnly = true;
        }

        private void UpdateTotalPerCustomer(TreeGridNode customerNode, decimal tongnochokh, decimal tongtrachokh, decimal tonglaichokh, bool isChecked)
        {
            customerNode.Cells[0].Value = isChecked;
            customerNode.Cells[3].Value = tongnochokh;
            customerNode.Cells[6].Value = tongtrachokh;
            customerNode.Cells[7].Value = tongnochokh - tongtrachokh;
            customerNode.Cells[9].Value = tonglaichokh;

            if (!isChecked)
                customerNode.DefaultCellStyle.BackColor = Color.Yellow;
        }

        private void UpdateTotalPerDeferring(TreeGridNode debitNode, decimal tongtrachogd, decimal tonglaichogd, decimal noconlai)
        {
            debitNode.Cells[6].Value = tongtrachogd;
            debitNode.Cells[7].Value = noconlai;
            debitNode.Cells[9].Value = tonglaichogd;
        }

        private void CalculateInterest(DateTime ngayTinhLai, DateTime ngayTraNo, DateTime ngayChotLai, DateTime ngayNo, DateTime ngayquahan,
                    decimal amount, out decimal interestAmount, out int songayno, out string calForm)
        {
            interestAmount = 0M;
            songayno = 0;
            calForm = string.Empty;
            if (ngayTinhLai <= ngayChotLai)
                return;

            // bat dau tinh lai
            DateTime ngaycuoi = ngayTinhLai < ngayTraNo ? ngayTinhLai : ngayTraNo; //min:(ngaytrano, ngaytinhlai)
            DateTime ngaydau = GetEndDate(ngayChotLai, ngayquahan, ngayNo);      //max:(ngaychotlai, branchday(ngayquahan, ngayno))
            if (ngaydau >= ngaycuoi || ngayTraNo <= ngayquahan)
                return;

            songayno = (int)(ngaycuoi - ngaydau).TotalDays;
            interestAmount = amount * GetRateAndNumberOfDay(ngaydau, ngaycuoi, out calForm);
        }

        private decimal GetRateAndNumberOfDay(DateTime ngaydau, DateTime ngaycuoi, out string calString)
        {
            decimal result = 0M;
            decimal prevRate = 0.0006M;
            DateTime prevDate = ngaydau;
            calString = string.Empty;
            foreach (KeyValuePair<DateTime, decimal> d in dayAndRates)
            {
                if (ngaydau >= d.Key)
                {
                    prevRate = d.Value;
                    continue;
                }

                if (ngaycuoi < d.Key)
                {
                    calString += string.Format(" + {0}*{1}", (int)(ngaycuoi - prevDate).TotalDays, prevRate);
                    result += prevRate * (int)(ngaycuoi - prevDate).TotalDays;
                    break;
                }
                else
                {
                    calString += string.Format(" + {0}*{1}", (int)(d.Key - prevDate).TotalDays, prevRate);
                    result += prevRate * (int)(d.Key - prevDate).TotalDays;
                    prevDate = d.Key;
                    prevRate = d.Value;
                }
            }
            return result;
        }

        private DateTime GetEndDate(DateTime ngayChotLai, DateTime ngayquahan, DateTime ngayNo)
        {
            DateTime date = Util.LoginUser.BranchCode == "100" ? ngayNo : ngayquahan;
            if (ngayChotLai > date)
                return ngayChotLai;
            return date;
        }

        #endregion

        private void inBangChitietMenuItem_Click(object sender, EventArgs e)
        {
            ShowWaiting("Xử lý dữ liệu trước khi load ...");

            VRMDataSet.InterestCalcDataTable data = new VRMDataSet.InterestCalcDataTable();
            if (showMode == ShowMode.ShowForCriteria)
            {
                foreach (VRMDataSet.InterestCalcRow r in dataReport.Rows)
                {
                    if (payableCustomers.Contains(r.customerid))
                        data.ImportRow(r);
                }
            }
            else
                data = dataReport;

            BangChiTietTinhLai rp = new BangChiTietTinhLai();

            rp.SetDataSource(data as DataTable);
            rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
            rp.SetParameterValue(rp.Parameter_UserIssued.ParameterFieldName, GUIUtil.UserAsString(Util.LoginUser));
            rp.SetParameterValue(rp.Parameter_ReportTitle.ParameterFieldName, "BẢNG CHI TIẾT PHÍ TRẢ CHẬM NGÀY T");
            rp.SetParameterValue(rp.Parameter_TranDate.ParameterFieldName, GUIUtil.FormatDate(interestDate.Value));
            rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

            ReportViewerForm.LoadReport(rp, this);
        }

        private void inBangNoMenuItem_Click(object sender, EventArgs e)
        {
            ShowWaiting("Xử lý dữ liệu trước khi load ...");

            VRMDataSet.InterestCalcDataTable data = new VRMDataSet.InterestCalcDataTable();
            foreach (VRMDataSet.InterestCalcRow r in dataReport.Rows)
            {
                if (paidCustomers.Contains(r.customerid))
                    continue;
                data.ImportRow(r);
            }

            BangChiTietTinhLai rp = new BangChiTietTinhLai();

            rp.SetDataSource(data as DataTable);
            rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
            rp.SetParameterValue(rp.Parameter_UserIssued.ParameterFieldName, GUIUtil.UserAsString(Util.LoginUser));
            rp.SetParameterValue(rp.Parameter_ReportTitle.ParameterFieldName, "BẢNG CHI TIẾT KHÁCH HÀNG NỢ PHÍ TRẢ CHẬM NGÀY T");
            rp.SetParameterValue(rp.Parameter_TranDate.ParameterFieldName, GUIUtil.FormatDate(interestDate.Value));
            rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

            ReportViewerForm.LoadReport(rp, this);
        }

        private void bảngTínhPhíTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWaiting("Xử lý dữ liệu trước khi load ...");

            VRMDataSet.InterestCalcDataTable data = new VRMDataSet.InterestCalcDataTable();
            if (showMode == ShowMode.ShowForCriteria)
            {
                foreach (VRMDataSet.InterestCalcRow r in dataReport.Rows)
                {
                    if (payableCustomers.Contains(r.customerid))
                        data.ImportRow(r);
                }
            }
            else
                data = dataReport;

            BangTongHopTinhLai rp = new BangTongHopTinhLai();

            rp.SetDataSource(data as DataTable);
            rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
            rp.SetParameterValue(rp.Parameter_UserIssued.ParameterFieldName, GUIUtil.UserAsString(Util.LoginUser));
            rp.SetParameterValue(rp.Parameter_ReportTitle.ParameterFieldName, "BẢNG TỔNG HỢP TÍNH PHÍ TRẢ CHẬM NGÀY T");
            rp.SetParameterValue(rp.Parameter_TranDate.ParameterFieldName, GUIUtil.FormatDate(interestDate.Value));
            rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

            ReportViewerForm.LoadReport(rp, this);
        }

        private void danhSáchTổngHợpKháchHàngNợPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWaiting("Xử lý dữ liệu trước khi load ...");

            VRMDataSet.InterestCalcDataTable data = new VRMDataSet.InterestCalcDataTable();
            foreach (VRMDataSet.InterestCalcRow r in dataReport.Rows)
            {
                if (paidCustomers.Contains(r.customerid))
                    continue;
                data.ImportRow(r);
            }

            BangTongHopTinhLai rp = new BangTongHopTinhLai();

            rp.SetDataSource(data as DataTable);
            rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
            rp.SetParameterValue(rp.Parameter_UserIssued.ParameterFieldName, GUIUtil.UserAsString(Util.LoginUser));
            rp.SetParameterValue(rp.Parameter_ReportTitle.ParameterFieldName, "BẢNG TỔNG HỢP KHÁCH HÀNG NỢ PHÍ TRẢ CHẬM NGÀY T");
            rp.SetParameterValue(rp.Parameter_TranDate.ParameterFieldName, GUIUtil.FormatDate(interestDate.Value));
            rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

            ReportViewerForm.LoadReport(rp, this);
        }

        private void treeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || treeGridView.CurrentCell == null || treeGridView.CurrentCell.ReadOnly)
                return;

            bool check = bool.Parse(treeGridView.CurrentCell.Value.ToString());
            treeGridView.CurrentCell.Value = !check;
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_TinhLaiTraCham);
        }

        private void treeGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = string.Format("tip for row {0}, col {1}",
   e.RowIndex, e.ColumnIndex);
        }
    }
}
