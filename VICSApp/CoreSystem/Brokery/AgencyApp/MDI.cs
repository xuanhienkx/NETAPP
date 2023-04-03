using System;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using Brokery.Operation;
using Brokery.Report.Agency;
using Brokery.Report.CustomerReport;

namespace Brokery
{
   public partial class MDI : Form
   {
      public MDI()
      {
         InitializeComponent();

         
      }

      public void InvisibleMenuItem()
      {
         foreach (ToolStripMenuItem item in menuStrip.Items)
            VisibleMenuItem(item);
      }

      private void VisibleMenuItem(ToolStripMenuItem item)
      {
         if (item.DropDownItems.Count == 0 && item.AccessibleName != null)
            item.Enabled = Util.CheckAccess(item.AccessibleName);
         else
         {
            foreach (ToolStripItem i in item.DropDownItems)
            {
               if (i is ToolStripMenuItem)
                  VisibleMenuItem(i as ToolStripMenuItem);
            }
         }
      }

      internal void UpdateStatus()
      {
         if (!Util.IsAuthenticated())
         {
            tranDateStatusLabel.Text = loggedUserStatusLabel.Text = placeStatusLabel.Text = string.Empty;
            timer1.Stop();
         }
         else
         {
            tranDateStatusLabel.Text = Util.CurrentTransactionDate.ToString("dd/MM/yyyy");
            loggedUserStatusLabel.Text = string.Format("{0} ({1})", Util.LoginUser.FullName, Util.LoginUser.UserName);
            placeStatusLabel.Text = Util.LoginUser.AgencyName;
            timer1.Interval = 1000;
            timer1.Start();
         }
      }

      private void quitMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void MDI_Load(object sender, EventArgs e)
      {
         try
         {
            Util.AgencyGateway.HelloVics();
         }
         catch
         {
            ShowWebServiceConfig();
         }
      }

      private void ShowWebServiceConfig()
      {
         while (true)
         {
            InputDiaglogBox.Result r = InputDiaglogBox.Show("Thông số kết nối hệ thống:", Util.AgencyGateway.Url, "Thiết lập tham số");
            if (!r.IsOK)
               break;

            Util.AgencyGateway.Url = r.InputMessage;
            try
            {
               Util.AgencyGateway.HelloVics();
               Brokery.Properties.Settings.Default.AgencyApp_AgencyWebService_GateWay = r.InputMessage;
               Brokery.Properties.Settings.Default.Save();
               break;
            }
            catch
            {
               MessageBox.Show("Tham số kết nối chưa chính xác hoặc máy chủ không hoạt động. \n Vui lòng kiểm tra lại hoặc liên lạc với IT của VICS để được hướng dẫn.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
      }

      private void loginMenuItem_Click(object sender, EventArgs e)
      {
         foreach (Form f in Util.MainMDI.MdiChildren)
            f.Close();
         Security.Login.ShowDialog<Security.Login>(() => new Security.Login());
      }

      private void MDI_FormClosed(object sender, FormClosedEventArgs e)
      {
         try
         {
            Util.AgencyGateway.ClearTokenKey(Util.TokenKey);
         }
         catch { }
      }

      private void bigOrderMenuItem_Click(object sender, EventArgs e)
      {
         Operation.SubmitOrder.Show<Operation.SubmitOrder>(new CreateForm(delegate() { return new Operation.SubmitOrder(); }));
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
         Util.SetCurrentTime(TradingSession.OneSecond);
         serverTimeLable.Text = Util.CurrentTransactionDate.ToString("HH:mm:ss");
      }

      private void vanTinMenuItem_Click(object sender, EventArgs e)
      {
         Operation.CustomerInfo.Show<Operation.CustomerInfo>(new CreateForm(delegate() { return new Operation.CustomerInfo(); }));
      }

      private void xemLenhMenuItem_Click(object sender, EventArgs e)
      {
          Operation.OrderList.Show<Operation.OrderList>(new CreateForm(delegate() { return new Operation.OrderList(); }));
      }

      private void duyetlenhMenuItem_Click(object sender, EventArgs e)
      {
          Operation.ApproveOrder.Show<Operation.ApproveOrder>(new CreateForm(delegate() { return new Operation.ApproveOrder(); }));
      }


      private void huyLenhHOSEMenuItem_Click(object sender, EventArgs e)
      {
         Operation.OrderManager.Show<Operation.OrderManager>(
            new CreateForm(delegate() { return new Operation.OrderManager(Util.HOSEBoard); }),
            new Predicate<OrderManager>(delegate(Operation.OrderManager hose) { return hose.GetBoardType() == Util.HOSEBoard; })
            );
      }

      private void yeuCauSuaLenhHNXMenuItem_Click(object sender, EventArgs e)
      {
         Operation.OrderManager.Show<Operation.OrderManager>(
            new CreateForm(delegate() { return new Operation.OrderManager(Util.HNXBoard); }),
            new Predicate<OrderManager>(delegate(Operation.OrderManager han) { return han.GetBoardType() == Util.HNXBoard; })
            );
      }

      private void guiyeucauhuysuaUPCOMToolStripMenuItem_Click(object sender, EventArgs e)
      {
          Operation.OrderManager.Show<Operation.OrderManager>(
            new CreateForm(delegate() { return new Operation.OrderManager(Util.UPCOMBoard); }),
            new Predicate<OrderManager>(delegate(Operation.OrderManager han) { return han.GetBoardType() == Util.UPCOMBoard; })
          );
      }


      private void phanQuyenMenuItem_Click(object sender, EventArgs e)
      {
         Security.AgencyPermission.Show<Security.AgencyPermission>(new CreateForm(delegate() { return new Security.AgencyPermission(); }));
      }

      private void quanLyNhomMenuItem_Click(object sender, EventArgs e)
      {
         Security.GroupManager.Show<Security.GroupManager>(new CreateForm(delegate() { return new Security.GroupManager(); }));
      }

      private void quanLyNguoiDungMenuItem_Click(object sender, EventArgs e)
      {
         Security.UserManager.Show<Security.UserManager>(new CreateForm(delegate() { return new Security.UserManager(); }));
      }

      private void MDI_Shown(object sender, EventArgs e)
      {
         if (!Util.IsAuthenticated())
            Security.Login.ShowDialog<Security.Login>(() => new Security.Login());
      }

      private void doiMatKhauMenuItem_Click(object sender, EventArgs e)
      {
         while (true)
         {
            InputDiaglogBox.Result result = InputDiaglogBox.Show("Nhập password mới:", string.Empty, "Đổi password", true);
            if (!result.IsOK)
               break;

            if (string.IsNullOrEmpty(result.InputMessage))
            {
               if (MessageBox.Show("Password mới không được để trống. Bạn có muốn đổi tiếp không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                  break;
            }
            try
            {
               Util.LoginUser.Password = Util.Encrypt(result.InputMessage);
               Util.AgencyGateway.ChangeUserPassword(Util.TokenKey, Util.LoginUser.UserId, Util.LoginUser.Password);
               MessageBox.Show(this, "Password mới đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               break;
            }
            catch (Exception ex)
            {
               MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void dangKyMenuItem_Click(object sender, EventArgs e)
      {
          Operation.RegisterCustomer.Show<Operation.RegisterCustomer>(new CreateForm(delegate() { return new Operation.RegisterCustomer(); }));
      }

      private void soLenhGDMenuItem_Click(object sender, EventArgs e)
      {
         StockOrderListReportCriteria.Show<StockOrderListReportCriteria>(new CreateForm(delegate() { return new StockOrderListReportCriteria(); }));
      }

      private void xacNhanGDMenuItem_Click(object sender, EventArgs e)
      {
         CustomerTradingResultReportCriteria.Show<CustomerTradingResultReportCriteria>(new CreateForm(delegate() { return new CustomerTradingResultReportCriteria(); }));
      }

      private void gdTienMenuItem_Click(object sender, EventArgs e)
      {
         TransactionReportCriteria.Show<TransactionReportCriteria>(
            new CreateForm(delegate() { return new TransactionReportCriteria(AccountType.Balance, true); }),
            new Predicate<TransactionReportCriteria>(delegate(TransactionReportCriteria f)
            {
               return f.AccountType == AccountType.Balance && f.IsForCustomer;
            }));
      }

      private void gdCKMenuItem_Click(object sender, EventArgs e)
      {
         TransactionReportCriteria.Show<TransactionReportCriteria>(
                     new CreateForm(delegate() { return new TransactionReportCriteria(AccountType.Contigen, true); }),
                     new Predicate<TransactionReportCriteria>(delegate(TransactionReportCriteria f)
                     {
                         return f.AccountType == AccountType.Contigen && f.IsForCustomer;
                     }));
      }

      private void bcTongHopMenuItem_Click(object sender, EventArgs e)
      {
          CustomerGeneralReportCriteria.Show<CustomerGeneralReportCriteria>(new CreateForm(delegate() { return new CustomerGeneralReportCriteria(); }));
      }

      private void lichSuLenhMenuItem_Click(object sender, EventArgs e)
      {
         OrderHistoryReportCriteria.Show<OrderHistoryReportCriteria>(new CreateForm(delegate() { return new OrderHistoryReportCriteria(); }));
      }

      private void kqKhopLenhNgayMenuItem_Click(object sender, EventArgs e)
      {
          MatchedOrderReportCriteria.Show<MatchedOrderReportCriteria>(new CreateForm(delegate() { return new MatchedOrderReportCriteria(); }));
      }

      private void baoCaoQuyMenuItem_Click(object sender, EventArgs e)
      {
          MonthlyTradingResultReportCriteria.Show<MonthlyTradingResultReportCriteria>(new CreateForm(delegate() { return new MonthlyTradingResultReportCriteria(); }));
      }

      private void baoCaoPhiMenuItem_Click(object sender, EventArgs e)
      {
          AgencyTransferFeeReportCriteria.Show<AgencyTransferFeeReportCriteria>(new CreateForm(delegate() { return new AgencyTransferFeeReportCriteria(); }));
      }

      private void thamSoHeThongMenuItem_Click(object sender, EventArgs e)
      {
         Security.Settings.Show<Security.Settings>(new CreateForm(delegate() { return new Security.Settings(); }));
      }

      private void thamSoKetNoiMenuItem_Click(object sender, EventArgs e)
      {
         ShowWebServiceConfig();
      }

      private void baoCaoLoLaiMenuItem_Click(object sender, EventArgs e)
      {
         LostAndProfitReportCriteria.Show<LostAndProfitReportCriteria>(new CreateForm(delegate() { return new LostAndProfitReportCriteria(); }));
      }

      private void MDI_FormClosing(object sender, FormClosingEventArgs e)
      {
         e.Cancel = (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
      }

      private void capNhatPhiDaiLyToolStripMenuItem_Click(object sender, EventArgs e)
      {
          Operation.AgencyFee.Show<Operation.AgencyFee>(new CreateForm(delegate() { return new Operation.AgencyFee(); }));
      }

      private void xemSổLệnhGiaoDịchToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Operation.AgencyFee.Show<Operation.MatchedOrderList>(new CreateForm(delegate() { return new Operation.MatchedOrderList(); }));
      }

      private void cấpHạnMứcTínDụngToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormBase.Show<Operation.DebitLimitListForm>(() => new Operation.DebitLimitListForm());
      }

      private void theoGiõiLịchSửCấpTínDụngToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormBase.Show<Operation.DebitLimitLogForm>(() => new Operation.DebitLimitLogForm());
      }

      private void thiếtLậpHạnMứcTínDụngChoChiNhánhđạiLýToolStripMenuItem_Click(object sender, EventArgs e)
      { 
         FormBase.Show<Operation.UnitDebitLimitListForm>(() => new Operation.UnitDebitLimitListForm());
      }

      private void baoCaoTienMenuItem_Click(object sender, EventArgs e)
      {
          TransactionReportCriteria.Show<TransactionReportCriteria>(
            new CreateForm(delegate() { return new TransactionReportCriteria(AccountType.Balance, false); }),
            new Predicate<TransactionReportCriteria>(delegate(TransactionReportCriteria f)
            {
                return f.AccountType == AccountType.Balance && !f.IsForCustomer;
            }));
         
      }
   }
}
