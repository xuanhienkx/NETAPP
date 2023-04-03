using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRM.Controls.DataGridColumnExtend;
using VRM.Controls.ExpandableGridView;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;

namespace VRMApp.Accountant
{
    public partial class SecurityFeeForm : FormBase
    {

        public enum ShowMode
        {
            ShowAll,
            ShowForSellT3
        }
        public ShowMode showMode = ShowMode.ShowAll;

        DateTimePicker fromDate, interestDate;
        private ToolStripLabel t3Label;
        private List<SecurityFeeLog> dataSource;
        CheckBoxDataGridViewColumn headerCheckbox;
        public SecurityFeeForm(ShowMode mode)
        {
            InitializeComponent();
            showMode = mode;
            headerCheckbox = new CheckBoxDataGridViewColumn();
            t3Label = new ToolStripLabel();
            headerCheckbox.Style.BackColor = System.Drawing.SystemColors.Control;
            headerCheckbox.Value = string.Empty;
            headerCheckbox.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeGridView.Columns[0].HeaderCell = headerCheckbox;
            checkBoxColumn.Visible = true;
            inBangNoMenuItem.Enabled = danhSáchTổngHợpKháchHàngNợPhíToolStripMenuItem.Enabled = false;

            interestDate = new DateTimePicker();
            fromDate = new DateTimePicker();
            interestDate.Format = DateTimePickerFormat.Custom;
            fromDate.Format = DateTimePickerFormat.Custom;
            interestDate.CustomFormat = "dd/MM/yyyy";
            fromDate.CustomFormat = "dd/MM/yyyy";
            var transactionDate = Util.CurrentTransactionDate;
            try
            {
                GUIUtil.FormatDatePicker(interestDate);
                this.toolStrip1.Items.Insert(4, new ToolStripControlHost(interestDate));
                if (showMode == ShowMode.ShowForSellT3)
                {
                    interestDate.Value = transactionDate.AddDays(-1);
                    this.toolStrip1.Items[4].Enabled = false;
                    this.Text = "Tính phí lưu ký chứng khoán bán ngày T-n";
                }
                else
                {
                    this.Text = "Tính phí lưu ký chứng khoán";
                }
                interestDate.MaxDate = transactionDate.AddDays(-1);
            }
            catch (Exception ex)
            {

                ShowError(ex.Message);
            }

            GUIUtil.FormatGridView(treeGridView);
            treeGridView.Columns[5].ReadOnly = false;
            treeGridView.Columns[0].Resizable = DataGridViewTriState.False;
            // initialize day to change rate

        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btnTinhFee_Click(object sender, EventArgs e)
        {
            if (interestDate.Value >= Util.CurrentTransactionDate)
            {
                ShowError("Ngày hạch toán phải nhỏ hơn ngày hiện tại");
            }
            else if (!string.IsNullOrEmpty(txtCustomerId.Text) && txtCustomerId.Text.Trim().Length != 10)
            {
                ShowError("Phải nhập tài khoản đúng định dạnh 10 ký tự");
            }
            else if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            {
                ShowWaiting("Đang lấy dữ liệu ...");
                btnTinhFee.Enabled = false;
                DateTime callDate = interestDate.Value;
                backgroundWorker1.RunWorkerAsync(new object[] { txtCustomerId.Text, callDate });
            }
        }
        public override bool CheckAccess()
        {
            var check = Util.CheckAccess(AccessPermission.LuuKy_Tinhphiluuky);
            return check;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                btnTinhFee.Enabled = true;
                ShowError(e.Error.Message);
                return;
            }
            ShowWaiting("Đang tính phí ....");

            try
            {
                dataSource = (List<SecurityFeeLog>)e.Result;
                CalculatingInterest();

                if (headerCheckbox != null)
                {
                    toolStripButton1.Enabled = treeGridView.Rows.Count > 0 && Util.CheckAccess(AccessPermission.KeToan_HachToanTinhLaiTraCham);
                    headerCheckbox.CheckAll = toolStripButton1.Enabled;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            interestDate.Enabled = btnTinhFee.Enabled = true;

            CloseWaiting();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            bool isT3 = showMode == ShowMode.ShowForSellT3;
            var list = Util.VRMService.GetDataForCallFeeCustory(Util.TokenKey, (string) args[0], (DateTime) args[1],
                (double) Util.Parameters.CustodyFeeRate, isT3);
            e.Result = list.ToList();
        }

        private void CalculatingInterest()
        {
            treeGridView.Nodes.Clear();
            if (dataSource == null || !dataSource.Any())
                return;
            decimal totalCusFee, totalBglFee, totalFee;
            long totalCusQty, totalBglQty, totalQty;
            totalCusFee = totalBglFee = totalFee = 0M;
            totalCusQty = totalBglQty = totalQty = 0L;

            var customers = dataSource.GroupBy(x => new
            {
                CustomerId = x.CustomerId,
                Name = x.CustomerName,
                Balance = x.CurrentBalance
            });
            TreeGridNode customerNode, stockNode;
            customerNode = stockNode = null;
            int rowindex = 0;
            foreach (var cus in customers)
            {
                var customer = cus.Key;
                totalCusQty = cus.Sum(x => x.Quantity);
                totalCusFee = cus.Sum(x => x.FeeAmount);
                var stockCodes = cus.GroupBy(x => x.StockCode);
                if (totalCusFee < 1)
                    continue;

                totalQty += totalCusQty;
                totalFee += totalCusFee;
                customerNode = InsertCustomerTitle(customer.CustomerId, customer.Name, totalCusQty,
                    totalCusFee, customer.Balance);

                foreach (var st in stockCodes)
                {
                    var stockCode = st.Key;
                    totalBglQty = st.Sum(x => x.Quantity);
                    totalBglFee = st.Sum(x => x.FeeAmount);
                    stockNode = InsertStockGridNode(customerNode, stockCode, totalBglQty, totalBglFee, rowindex);
                    foreach (var it in st.OrderBy(x => x.BeginDate).ThenBy(x => x.EndDate))
                        InsertItem(stockNode, it.BeginDate, it.EndDate, it.DayCount, it.Quantity, it.FeeAmount, rowindex);
                }
                rowindex++;
            }


            lblTongKH.Text = treeGridView.Rows.Count.ToString("N0");
            lblTongLai.Text = GUIUtil.MoneyAsString(totalFee);
            toolStripButton1.Enabled = (showMode == ShowMode.ShowForSellT3 && Util.CheckAccess(AccessPermission.LuuKy_Tinhphiluuky));
            btnPrint.Enabled = treeGridView.RowCount > 0;
        }
        private TreeGridNode InsertCustomerTitle(string custId, string custName, long qty, decimal amount, decimal currentBalance)
        {
            bool isChecked = amount < currentBalance && amount > 1;
            TreeGridNode node = treeGridView.Nodes.Add(isChecked, string.Format("{0} - {1}", custId, custName),
               string.Empty, string.Empty, string.Empty, string.Empty, qty, amount, currentBalance);
            node.DefaultCellStyle.Font = new Font(treeGridView.DefaultCellStyle.Font, FontStyle.Bold);
            node.Cells[0].ReadOnly = false;
            if (!isChecked)
            {
                node.Cells[0].ReadOnly = true;
                node.DefaultCellStyle.BackColor = Color.Yellow;
            }
            return node;
        }
        private TreeGridNode InsertStockGridNode(TreeGridNode node, string stockCode, long qty, decimal amount, int rowIndex)
        {
            TreeGridNode child = node.Nodes.Add(true, string.Empty, stockCode, string.Empty, string.Empty,
              string.Empty, qty, amount, string.Empty, rowIndex);
            node.DefaultCellStyle.Font = new Font(treeGridView.DefaultCellStyle.Font, FontStyle.Bold);
            node.Cells[0].ReadOnly = false;
            child.Cells[0].ReadOnly = false;

            return child;
        }

        private void InsertItem(TreeGridNode node, DateTime beginDate, DateTime endDate, int daycount, long qty, decimal amount, int rowIndex)
        {
            node.Nodes.Add(true, string.Empty, string.Empty, string.Format("{0:dd/MM/yyyy}", beginDate), string.Format("{0:dd/MM/yyyy}", endDate),
            daycount, qty, amount, string.Empty, rowIndex);
            node.DefaultCellStyle.Font = new Font(treeGridView.DefaultCellStyle.Font, FontStyle.Bold);
            node.Cells[0].ReadOnly = false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (interestDate.Value > Util.CurrentTransactionDate)
            {
                ShowError("Ngày hạch toán không được lớn hơn ngày giao dịch hiện tại");
            }
            else if (!backgroundWorker2.IsBusy && !backgroundWorker2.CancellationPending)
            {
                interestDate.Enabled = btnTinhFee.Enabled = toolStripButton1.Enabled = false;
                backgroundWorker2.RunWorkerAsync(new object[] { treeGridView.Nodes });
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            TreeGridNodeCollection nodes = args[0] as TreeGridNodeCollection;
            string customerid;
            decimal feeAmount, balance;
            bool isChecked;
            foreach (TreeGridNode n in nodes)
            {
                isChecked = bool.Parse(n.Cells[0].Value.ToString());
                if (!isChecked)
                    continue;
                feeAmount = (decimal)n.Cells[7].Value;
                balance = (decimal)n.Cells[8].Value;
                if (feeAmount > balance)
                    continue;
                customerid = n.Cells[1].Value.ToString().Split('-')[0].Trim();
                bool isExists = Util.VRMService.IsAccountingCustody(Util.TokenKey, customerid, interestDate.Value.Date);
                if (feeAmount > balance || isExists || feeAmount < 1)
                    continue;

                customerid = n.Cells[1].Value.ToString().Split('-')[0].Trim();
                var listCustody = dataSource.Where(x => x.CustomerId == customerid).ToArray();
                ShowWaiting("Hạch toán phí lưu ký khách hàng " + customerid);

                // hach toan tinh phi 
                var callResult = Util.VRMService.InsertTransactionFeeCustody(Util.TokenKey, customerid, feeAmount, interestDate.Value.Date);
                Util.VRMService.UpdateSecurityLog(Util.TokenKey, listCustody, callResult);
            }
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseWaiting();
            interestDate.Enabled = btnTinhFee.Enabled = true;
            if (e.Error != null)
            {
                ShowError(e.Error.Message);
                toolStripButton1.Enabled = showMode == ShowMode.ShowForSellT3 && Util.CheckAccess(AccessPermission.LuuKy_Tinhphiluuky);
                return;
            }
            ShowNotice("Hạch toán tính phí lưu ký hoàn tất.");
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
            catch
            {

            }
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


    }
}
