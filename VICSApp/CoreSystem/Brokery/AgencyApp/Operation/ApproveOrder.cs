using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Operation
{
   public partial class ApproveOrder : FormBase
   {
      public ApproveOrder()
      {
         InitializeComponent();
         //GUIUtil.FormatGridView(gridOrder,false,false);
         BindingDropDownListDetail();
      }

      private void BindingDropDownListDetail()
      {
         // board type
         List<DropDownObject> items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(Util.HOSEBoard, "Sàn HOSE"));
         items.Add(new DropDownObject(Util.HNXBoard, "Sàn HNX"));
         items.Add(new DropDownObject(Util.UPCOMBoard, "Sàn OTC"));
         boardTypeBox.ComboBox.DataSource = items;
         boardTypeBox.ComboBox.DisplayMember = "Description";
         boardTypeBox.ComboBox.ValueMember = "Code";

         // order side
         items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(OrderSide.B.ToString(), "Mua"));
         items.Add(new DropDownObject(OrderSide.S.ToString(), "Bán"));
         orderSideBox.ComboBox.DataSource = items;
         orderSideBox.ComboBox.DisplayMember = "Description";
         orderSideBox.ComboBox.ValueMember = "Code";

         // order status
         items = new List<DropDownObject>();
         items.Add(new DropDownObject("A", "<Tất cả>"));
         items.Add(new DropDownObject("P", "(P) Lệnh chờ duyệt"));
         items.Add(new DropDownObject("S", "(S) Lệnh đã duyệt tại công ty"));
         items.Add(new DropDownObject("X", "(X) Lệnh không được duyệt"));
         items.Add(new DropDownObject("E", "(E) Lệnh đã nhập lệnh vào hệ thống"));
         items.Add(new DropDownObject("O", "(O) Lệnh chờ khớp (có thể đã khớp được một phần)"));
         items.Add(new DropDownObject("C", "(C) Lệnh đã bị hủy (có thể đã khớp được một phần)"));
         items.Add(new DropDownObject("M", "(M) Lệnh đã khớp hết"));
         items.Add(new DropDownObject("D", "(D) Lệnh được hủy bởi hệ thống truyền lệnh"));
         items.Add(new DropDownObject("F", "(F) Lệnh hủy bởi kết thúc giao dịch"));
         orderStatusBox.ComboBox.DataSource = items;
         orderStatusBox.ComboBox.DisplayMember = "Description";
         orderStatusBox.ComboBox.ValueMember = "Code";
         orderStatusBox.SelectedIndex = 1;
          //

      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_DuyetLenh; }
      }

      private void approveOrderButton_Click(object sender, EventArgs e)
      {
          int orderSeq = 0;
          string boardType = "";
          foreach (DataGridViewRow dgv in gridOrder.Rows) 
              if (dgv.Cells[0].Value != null)
                  if (dgv.Cells[0].Value.ToString()=="True")
                      if (!string.IsNullOrEmpty(dgv.Cells[1].Value.ToString()))
                      {
                          orderSeq = Convert.ToInt32(dgv.Cells[1].Value.ToString());
                          boardType = dgv.Cells[4].Value.ToString();
                          try
                          {
                              Util.AgencyGateway.ApproveOrder(Util.TokenKey, Util.CurrentTransactionDate, boardType, orderSeq);
                          }
                          catch (Exception ex) {
                              ShowError(ex.Message);
                          }
                      }

          this.findOrder();
      }

      private void deleteOrderButton_Click(object sender, EventArgs e)
      {
          int orderSeq = 0;
          foreach (DataGridViewRow dgv in gridOrder.Rows)
              if (dgv.Cells[0].Value != null)
                  if (dgv.Cells[0].Value.ToString() == "True")
                      if (!string.IsNullOrEmpty(dgv.Cells[1].Value.ToString()))
                      {
                          orderSeq = Convert.ToInt32(dgv.Cells[1].Value.ToString());
                          try
                          {
                              Util.AgencyGateway.DeleteOrder(Util.TokenKey, Util.CurrentTransactionDate,orderSeq);
                          }
                          catch (Exception ex)
                          {
                              ShowError(ex.Message);
                          }
                      }
          this.findOrder();
      }


      private void gridOrder_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
      {
          gridOrder.EndEdit();
      }

      private void refreshOrderButton_Click(object sender, EventArgs e)
      {
          this.findOrder();
      }
      private void findOrder() {

          ShowWaiting("Đang tìm kiếm ...");
          bindingSource.DataSource = Util.AgencyGateway.GetOrderList(
             Util.TokenKey,
             Util.CurrentTransactionDate,
             this.CustomerIDBox.Text.Trim(),
             this.StockCodeBox.Text.Trim(),
             this.orderStatusBox.ComboBox.SelectedValue.ToString(),
             string.Empty,
             this.orderSideBox.ComboBox.SelectedValue.ToString(),
             0,
             this.boardTypeBox.ComboBox.SelectedValue.ToString());
          sumOfRecordLabel.Text = string.Format("Tổng số có {0} bản ghi.", gridOrder.Rows.Count.ToString());

          CloseWaiting();
      }


   }
}
