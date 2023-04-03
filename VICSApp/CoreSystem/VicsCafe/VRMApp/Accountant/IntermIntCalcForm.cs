using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRM.Controls.DataGridColumnExtend;
using VRM.Controls.ExpandableGridView;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.Reports;
using VRMApp.Reports.Accountant;

namespace VRMApp.Accountant
{
   public partial class IntermIntCalcForm : FormBase
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

      public IntermIntCalcForm()
      {
         InitializeComponent();
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {

      }

      private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
      {

      }

      private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {

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
        
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
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
               headerCheckbox.CheckAll = toolStripButton1.Enabled;
            }
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
         interestDate.Enabled = btnTinhPhi.Enabled = true;

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
         decimal laisuat, tonglai, tonglaichokh, tonglaichogd;
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
                  songayno = CalculatingInterestDays(ngaytinhlai, Util.CurrentTransactionDate, ngaychotlai, ngayno, ngayquahan);
                  decimal laitienthieu = CalculatingInterest(nohientai, songayno, ngayno);
                  InsertRemainDeferred(debitNode, nohientai, laitienthieu, songayno, rowIndex);
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
               songayno = CalculatingInterestDays(ngaytinhlai, ngaytrano, ngaychotlai, ngayno, ngayquahan);
               laisuat = CalculatingInterest(sotientra, songayno, ngayno);

               InsertDeferedPaying(debitNode, songayno, sotientra, 0, ngaytrano, laisuat, rowIndex);
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
               songayno = CalculatingInterestDays(ngaytinhlai, Util.CurrentTransactionDate, ngaychotlai, ngayno, ngayquahan);
               decimal laitienthieu = CalculatingInterest(nohientai, songayno, ngayno);
               InsertRemainDeferred(debitNode, nohientai, laitienthieu, songayno, --rowIndex);
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

      private void InsertDeferedPaying(TreeGridNode node, int numberOfDay, decimal payAmount, decimal remain, DateTime payDate, decimal interestAmount, int rowIndex)
      {
         node.Nodes.Add(true, string.Empty, string.Empty, string.Empty, string.Empty,
           payDate, payAmount, remain, numberOfDay, interestAmount, string.Empty, rowIndex);
         node.Cells[0].ReadOnly = true;
      }

      private void InsertRemainDeferred(TreeGridNode node, decimal defAmount, decimal interestAmount, int numberOfDay, int rowIndex)
      {
         node.Nodes.Add(true, string.Empty, string.Empty, string.Empty, string.Empty,
            null, string.Empty, defAmount, numberOfDay, interestAmount, string.Empty, rowIndex);

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

      private decimal CalculatingInterest(decimal amount, int numOfDay, DateTime ngayNo)
      {
         if (ngayNo < new DateTime(2012, 1, 1))
         {
            //if (Util.LoginUser.BranchCode == "200")
            //   return numOfDay * 0.0006M * amount;
            // 100 & 300
            return numOfDay * 0.0006M * amount;
         }
         else // new interest calulation method is affected
         {
            if (numOfDay > 30)
               return (decimal)(30M * 0.0006M + (numOfDay - 30M) * 0.00078M) * amount;
            return numOfDay * 0.0006M * amount;
         }
      }

      private int CalculatingInterestDays(DateTime ngayTinhLai, DateTime ngayTraNo, DateTime ngayChotLai, DateTime ngayNo, DateTime ngayquahan)
      {
         if (ngayTinhLai <= ngayChotLai)
            return 0;
         int days = 0;

         if (ngayNo < new DateTime(2012, 1, 1))
         {
            if (ngayTraNo > ngayquahan && ngayTraNo > ngayChotLai && Util.CurrentTransactionDate > ngayquahan) //tinh lai
            {
               DateTime ngaytinh = ngayTinhLai < ngayTraNo ? ngayTinhLai : ngayTraNo; //min:(ngaytrano, ngaytinhlai)

               if (Util.LoginUser.BranchCode == "200")
               {
                  if (ngayChotLai > ngayquahan)
                     days = (int)(ngaytinh - ngayChotLai).TotalDays;
                  else if (ngaytinh > ngayquahan)
                     days = (int)(ngaytinh - ngayquahan).TotalDays;
                  else
                     days = 0;
               }
               else
               {
                  if (ngayChotLai > ngayNo)
                     days = (int)(ngaytinh - ngayChotLai).TotalDays;
                  else
                     days = (int)(ngaytinh - ngayNo).TotalDays;
               }
            }
         }
         else
         {
            DateTime ngaytinh = ngayTraNo != DateTime.MinValue && ngayTraNo != DateTime.MaxValue ? ngayTraNo : ngayTinhLai;
            if (ngayChotLai > ngayNo)
               days = (int)(ngaytinh - ngayChotLai).TotalDays;
            else
               days = (int)(ngaytinh - ngayNo).TotalDays;
         }
         return days;
      }

      #endregion

      private void inBangChitietMenuItem_Click(object sender, EventArgs e)
      {

      }

      private void bảngTínhPhíTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
      {

      }

      private void danhSáchTổngHợpKháchHàngNợPhíToolStripMenuItem_Click(object sender, EventArgs e)
      {

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

   }
}
