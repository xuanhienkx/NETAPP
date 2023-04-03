using System;
using System.Collections.Generic;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Order = Brokery.AgencyWebService.Order;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Operation
{
   public partial class OrderList : FormBase
   {
      public OrderList()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(gridOrder);
         GUIUtil.AddVisibilityContextMenuOnColumns(gridOrder);
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
      }

      private void findBtn_Click(object sender, EventArgs e)
      {
         ShowWaiting("Đang tìm kiếm ...");

          var data = Util.AgencyGateway.GetOrderList(
            Util.TokenKey,
            Util.CurrentTransactionDate,
            this.CustomerIDBox.Text.Trim(),
            this.StockCodeBox.Text.Trim(),
            this.orderStatusBox.ComboBox.SelectedValue.ToString(),
            string.Empty,
            this.orderSideBox.ComboBox.SelectedValue.ToString(),
            0,
            this.boardTypeBox.ComboBox.SelectedValue.ToString());

         bindingSource.DataSource = new SortableBindingList<Order>(new List<Order>(data)); 
         CloseWaiting();
         sumOfRecodeLabel.Text = string.Format("Tổng số có {0} bản ghi.", gridOrder.Rows.Count.ToString());
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_XemLenh; }
      }
   }
}