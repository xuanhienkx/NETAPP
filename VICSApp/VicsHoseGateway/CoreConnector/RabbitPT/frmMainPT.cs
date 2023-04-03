using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Threading;
using OrderChecker;
using InterStock;
using HOGW_PT_Dealer.HosePTConnector;

namespace HOGW_PT_Dealer
{

   public partial class frmMainPT : Form
   {
      private bool bLogin;
      static Log log = new Log();
      //private Database db;
      public enum ErrorStatus
      {
         Critical,
         Medium,
         Low,
         Help,
         OK,
         Info
      }
      public frm2FirmBuyerApprove formBuyerApprove { get; set; }
      public frm2FirmBuyerApproveSellerCancelDeal formBuyerApproveCancel { get; set; }
      //private List<Thread> lstThreadPTSender = new List<Thread>();
      //private List<Thread> lstThreadPTReceiver = new List<Thread>();
      private PTMasterThread threadMasterSender = new PTMasterThread();
      private PTMasterThread threadMasterReceiver = new PTMasterThread();
      private int BuyerApproveRefreshInterval;
      public frmMainPT()
      {
         InitializeComponent();
      }
      public static void writeLog(string text)
      {
         lock (log)
         {
            log.writeLog(text);
         }
      }

      private void frmMain_Load(object sender, EventArgs e)
      {
         try
         {
            bLogin = false;
            ttipSystem.Text = "";
            EnableFunctionInterface(false);
            //get Log file path
            lock (log)
            {
               int i = Application.ExecutablePath.LastIndexOf("\\");
               string appName;
               if (i >= 0)
               {
                  appName = Application.ExecutablePath.Substring(i);
                  appName = appName.Remove(appName.LastIndexOf("."));
               }
               else
                  appName = "\\" + CommonSettings.AppName;
               log.LogFilePath = System.IO.Directory.GetCurrentDirectory() + appName + DateTime.Now.ToString("yyyyMMdd") + ".log";

            }
            writeLog("APPLICATION STARTED!");
            writeLogScreen("Chương trình bắt đầu xử lý dữ liệu!", ErrorStatus.Help);
            ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            timerSystem.Enabled = true;
            //market status
            ttipMarketStatus.Text = "Trạng thái TT: " + Util.HoseGW.GetMarketStatusWithDate();
            //Last stock info date from SU message
            writeLogScreen("Ngày cuối từ HOSE_SU: " + Util.HoseGW.GetLastTradingDaySU(), ErrorStatus.OK);

            //Hien thi form login
            loginToolStripMenuItem_Click(sender, e);

            //Set interval cho timer hien thi form buyer duyet deal                
            BuyerApproveRefreshInterval = Convert.ToInt32(ConfigurationManager.AppSettings["BuyerApproveRefreshInterval"]);
            timerBuyerTasks.Interval = BuyerApproveRefreshInterval * 1000;
            timerBuyerTasks.Enabled = true;

            rd1.Checked = true;
            //-------- TEST ---------
            //ProcessPTSender();
            //ProcessPTReceiver();
            //frmSettings frm = new frmSettings();
            //frm.ShowDialog();                
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
            return;
         }
      }
      private void StopThreads()
      {
         try
         {
            writeLogScreen("Xin vui lòng chờ đến khi các tiến trình dừng hẳn...", ErrorStatus.Help);
            //writeLog("All threads have just been stopped!");
            threadMasterSender.StopThreads();
            threadMasterReceiver.StopThreads();
         }
         catch (ThreadAbortException ex)
         {
            string err = ex.Message + "; Inner Exception: " + ex.InnerException.Message;
            writeLog(err);
         }
      }
      private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
      {
         StopThreads();
         writeLog("APPLICATION STOPPED! CloseReason: " + e.CloseReason.ToString());
      }


      private void btnClose_Click(object sender, EventArgs e)
      {
         //MessageBox.Show("All threads are about to be stopped...");
         Close();
      }
      private void writeLogScreen(string text, ErrorStatus status)
      {
         ListViewItem item = new ListViewItem(DateTime.Now.ToString("yyyy/MM/dd"));
         item.SubItems.Add(DateTime.Now.ToString("HH:mm:ss"));
         item.SubItems.Add(text);
         switch (status)
         {
            case ErrorStatus.Critical: item.ImageIndex = 3; break;
            case ErrorStatus.Medium: item.ImageIndex = 0; break;
            case ErrorStatus.Low: item.ImageIndex = 2; break;
            case ErrorStatus.OK: item.ImageIndex = 1; break;
            case ErrorStatus.Help: item.ImageIndex = 4; break;
            case ErrorStatus.Info: item.ImageIndex = 6; break;
            default: break;
         }
         lvLog.Items.Add(item);
      }

      private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
      {
         lvLog.Items.Clear();
      }

      private void makeANew2ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmMakeNewPTDeal frm = new frmMakeNewPTDeal();
         frm.Show();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void EnableFunctionInterface(bool enable)
      {
         tabControlFunctions.Enabled = enable;
         grbAdmin.Enabled = enable;
      }
      private void EnableFunctionInterface(bool enable, ArrayList lstControlNames)
      {
         if (lstControlNames.Count <= 0) return; //nothing to activate
         if (this.Controls == null || this.Controls.Count <= 0) return;
         foreach (string controlName in lstControlNames)
         {
            Control con = FindControlsRecursive(this, controlName);
            if (con != null) con.Enabled = enable;
         }
      }
      private static Control FindControlsRecursive(Control root, string name)
      {
         if (root.IsDisposed != null && root.Name == name) return root;
         if (root.Controls.Count != 0)
         {
            foreach (Control c in root.Controls)
            {
               Control rc = FindControlsRecursive(c, name);
               if (rc != null)
                  return rc;
            }
         }
         return null;
      }

      private void loginToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (bLogin) //da login, logout
         {
            loginToolStripMenuItem.Text = "Đăng &nhập";
            ttipSystem.Text = "";
            EnableFunctionInterface(false);
            timerMarketStatus.Enabled = false;
            bLogin = false;
            writeLog("Logout successfully!");
            writeLogScreen("Username " + Util.LoginResult.UserName + " đăng xuất thành công!", ErrorStatus.OK);
         }
         else
         {
            ShowLoginForm(sender, e);
         }
      }
      private void ShowLoginForm(object sender, EventArgs e)
      {
         ArrayList arr1 = new ArrayList();
         ArrayList arr2 = new ArrayList();
         arr1.Add("tabControlFunctions");
         arr1.Add("grbAdmin");
         arr2.Add("tabControlFunctions");
         frmLoginPT loginFormPT = new frmLoginPT();
         if (loginFormPT.ShowDialog() == DialogResult.OK)
         {
            LoginResult loginResult = Util.HosePTGW.Login(loginFormPT.Username, loginFormPT.Password);
            if (loginResult != null && loginResult.Result > 0) //success
            {
               Util.LoginResult = loginResult;
               
               loginToolStripMenuItem.Text = "Đăng &xuất";
               ttipSystem.Text = Util.LoginResult.UserName;
               //Enable controls according to user's roles

               if (loginResult.RoleID == 1) //admin
                  EnableFunctionInterface(true, arr1);
               else
                  EnableFunctionInterface(true, arr2);
               bLogin = true;
               writeLog("Login successfully!");
               writeLogScreen("Username " + Util.LoginResult.UserName + " đăng nhập thành công!", ErrorStatus.OK);
               timerMarketStatus.Enabled = true;
               timerMarketStatus_Tick(sender, e);
            }
            else
            {
               if (loginResult != null && loginResult.Result == 0)
               {
                  writeLog("Login un-successfully! Wrong password!");
                  writeLogScreen("Lỗi đăng nhập! Sai mật khẩu!", ErrorStatus.Critical);
                  MessageBox.Show("Lỗi đăng nhập! Sai mật khẩu!");
                  ShowLoginForm(sender, e);
                  return;
               }
               else if (loginResult != null)
               {
                  writeLog("Login un-successfully! Username " + loginFormPT.Username + " does not exist!");
                  writeLogScreen("Lỗi đăng nhập! Tên người dùng " + loginFormPT.Username + " không tồn tại!", ErrorStatus.Critical);
                  MessageBox.Show("Lỗi đăng nhập! Tên người dùng " + loginFormPT.Username + " không tồn tại!");
                  ShowLoginForm(sender, e);
                  return;
               }
               else
               {
                  writeLog("Login un-successfully! System error!");
                  writeLogScreen("Lỗi hệ thống đăng nhập!", ErrorStatus.Critical);
                  MessageBox.Show("Lỗi hệ thống đăng nhập!");
               }
               timerMarketStatus.Enabled = false;
               bLogin = false;
               EnableFunctionInterface(false);
               Util.LoginResult = null;
            }
         }
      }
      private void approve2FirmDealsBrokerToolStripMenuItem_Click_1(object sender, EventArgs e)
      {
         //Duyet lenh 2 firm deal cua seller
         frm2FirmSellerApprove frm = new frm2FirmSellerApprove();
         frm.Show();
      }

      private void dsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Broker Duyet lenh tu ben seller day sang (day la phia buyer)
         frm2FirmBuyerApprove frm = new frm2FirmBuyerApprove();
         frm.Show();
      }

      private void sdToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Kiem soat Duyet lenh tu ben seller day sang (day la phia buyer)
         frm2FirmBuyerApproveSuper frm = new frm2FirmBuyerApproveSuper();
         frm.Show();
      }

      private void cancelA2FirmSellerDealBrokerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Huy lenh 2 firm deal (phia seller, broker thuc hien)
         frm2FirmSellerCancel frm = new frm2FirmSellerCancel();
         frm.Show();
      }

      private void approveCancelling2FirmSellerDealSupervisorToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         //Duyet Huy lenh 2 firm deal (phia seller, Kiem soat thuc hien)
         frm2FirmSellerCancelSuper frm = new frm2FirmSellerCancelSuper();
         frm.Show();
      }

      private void makeANew2FirmDealsellerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //tao lenh 2 firm deal tu phia seller 
         frmMakeNewPTDeal frm = new frmMakeNewPTDeal();
         frm.Show();
      }

      private void approveORDisapproveCancelDealsFromSellerBrokerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frm2FirmBuyerBrowseDeals frm = new frm2FirmBuyerBrowseDeals();
         frm.Show();
      }

      private void approveORDisapproveCancelDealsFromSellerSupervisorToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frm2FirmBuyerApproveSellerCancelDealSuper frm = new frm2FirmBuyerApproveSellerCancelDealSuper();
         frm.Show();
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void approveADealFromSellerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frm1FirmDealApprove frm = new frm1FirmDealApprove();
         frm.Show();
      }

      private void dayActionForPTToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chắc chắn reset các bảng lệnh thỏa thuận (Các bảng này sẽ được backup trước khi xóa)", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            return;
         try
         {
            Util.HosePTGW.ResetPTDealTables();
            writeLog("Reset Put Through tables successfully!");
            writeLogScreen("Reset các bảng lệnh thỏa thuận thành công!", ErrorStatus.OK);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
            return;
         }
      }

      private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (MessageBox.Show("Chắc chắn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            e.Cancel = false;
         }
         else
         {
            e.Cancel = true;
         }
      }


      private void cancel1FirmDealssellerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frm1FirmDealCancel frm = new frm1FirmDealCancel();
         frm.Show();
      }

      private void cancel1FirmDealsSuppervisorToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frm1FirmDealCancelSupper frm = new frm1FirmDealCancelSupper();
         frm.Show();
      }

      private void makeANew1FirmDealToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmMakeNewPT1FirmDeal frm = new frmMakeNewPT1FirmDeal();
         frm.Show();
      }

      private void approveADealFromSellerToolStripMenuItem_Click_1(object sender, EventArgs e)
      {
         frm1FirmDealApprove frm = new frm1FirmDealApprove();
         frm.Show();
      }

      private void makeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmMakeNewAdv frm = new frmMakeNewAdv();
         frm.Show();
      }

      private void approveAdvertisementToolStripMenuItem_Click(object sender, EventArgs e)
      {
         frmAdvApprove frm = new frmAdvApprove();
         frm.Show();
      }

      private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         frmSettings frm = new frmSettings();
         frm.ShowDialog();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         frmAdvAnnounce frm = new frmAdvAnnounce();
         frm.Show();
      }

      private void btnMake1FirmDeal_Click(object sender, EventArgs e)
      {
         frmMakeNewPT1FirmDeal frm = new frmMakeNewPT1FirmDeal();
         frm.Show();
      }

      private void btnApprove1FirmDeal_Click(object sender, EventArgs e)
      {
         frm1FirmDealApprove frm = new frm1FirmDealApprove();
         frm.Show();
      }

      private void btnCancel1FirmDeal_Click(object sender, EventArgs e)
      {
         frm1FirmDealCancel frm = new frm1FirmDealCancel();
         frm.Show();
      }

      private void btnMake2FirmDeal_Click(object sender, EventArgs e)
      {
         frmMakeNewPTDeal frm = new frmMakeNewPTDeal();
         frm.Show();
      }

      private void btnApprove2FirmDeal_Click(object sender, EventArgs e)
      {
         frm2FirmSellerApprove frm = new frm2FirmSellerApprove();
         frm.Show();
      }

      private void btnCancel2FirmDeal_Click(object sender, EventArgs e)
      {
         frm2FirmSellerCancel frm = new frm2FirmSellerCancel();
         frm.Show();
      }

      private void btnBuyerApproveSeller_Click(object sender, EventArgs e)
      {
         //frm2FirmBuyerApprove frm = new frm2FirmBuyerApprove();
         if (formBuyerApprove == null || formBuyerApprove.IsDisposed)
         {
            formBuyerApprove = new frm2FirmBuyerApprove();
            formBuyerApprove.Show();
         }
         else if (!formBuyerApprove.IsDisposed)
         {
            if (formBuyerApprove.Visible == false)
               formBuyerApprove.Show();
         }
      }

      private void btnBuyerApproveSellerCancel_Click(object sender, EventArgs e)
      {
         //frm2FirmBuyerApproveSellerCancelDeal frm = new frm2FirmBuyerApproveSellerCancelDeal();
         if (formBuyerApproveCancel == null || formBuyerApproveCancel.IsDisposed)
         {
            formBuyerApproveCancel = new frm2FirmBuyerApproveSellerCancelDeal();
            formBuyerApproveCancel.Show();
         }
         else if (!formBuyerApproveCancel.IsDisposed)
         {
            if (formBuyerApproveCancel.Visible == false)
               formBuyerApproveCancel.Show();
         }
      }

      private void btnMakeNewAdv_Click(object sender, EventArgs e)
      {
         frmMakeNewAdv frm = new frmMakeNewAdv();
         frm.Show();
      }

      private void timerSystem_Tick(object sender, EventArgs e)
      {
         ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
      }

      private void timerMarketStatus_Tick(object sender, EventArgs e)
      {
         //Get market status
         ttipMarketStatus.Text = "Trạng thái TT: " + Util.HoseGW.GetMarketStatusWithDate();
      }

      private void frmMain_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyCode)
         {
            case Keys.F1: tabControlFunctions.SelectedIndex = 0;
               break;
            case Keys.F2: tabControlFunctions.SelectedIndex = 1;
               break;
            case Keys.F3: tabControlFunctions.SelectedIndex = 2;
               break;
            case Keys.D1:
               if (e.Control)
               {
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnMake1FirmDeal_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 1)
                     btnBuyerApproveSeller_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 2)
                     btnMakeNewAdv_Click(sender, e);
               }
               break;
            case Keys.D2:
               if (e.Control)
               {
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnApprove1FirmDeal_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 1)
                     btnBuyerApproveSellerCancel_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 2)
                     btnApproveAdv_Click(sender, e);
               }
               break;
            case Keys.D3:
               if (e.Control)
               {
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnCancel1FirmDeal_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 1)
                     btnBuyerBrowseDeals_Click(sender, e);
                  else if (tabControlFunctions.SelectedIndex == 2)
                     btnCancelAdv_Click(sender, e);
               }
               break;
            case Keys.D4:
               if (e.Control)
               {
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnView1FirmDeals_Click(sender, e);
                  if (tabControlFunctions.SelectedIndex == 2) //adv view
                     btnViewAdv_Click(sender, e);
               }
               break;
            case Keys.D5:
               if (e.Control)
               {
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnMake2FirmDeal_Click(sender, e);
                  if (tabControlFunctions.SelectedIndex == 2)
                     btnAdvAnnounce_Click(sender, e);
               }
               break;
            case Keys.D6:
               if (e.Control)
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnApprove2FirmDeal_Click(sender, e);
               break;
            case Keys.D7:
               if (e.Control)
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnCancel2FirmDeal_Click(sender, e);
               break;
            case Keys.D8:
               if (e.Control)
                  if (tabControlFunctions.SelectedIndex == 0)
                     btnView2FirmSellerDeals_Click(sender, e);
               break;
            case Keys.F8: //hien thi form LiveBoard de test
               frmAdvAnnounce frm = new frmAdvAnnounce();
               frm.Show();
               break;
         }
      }

      private void btnApproveAdv_Click(object sender, EventArgs e)
      {
         frmAdvApprove frm = new frmAdvApprove();
         frm.Show();
      }

      private void timerBuyerTasks_Tick(object sender, EventArgs e)
      {
         //1s lan quet bang BUYER de lay cac message co status:
         //RP:   neu chuyen thanh SP -> approve cho seller
         //      chuyen thanh SC -> disapprove seller deal
         string s = "";
         if (!bLogin) return;
         int traderID = Util.HosePTGW.GetTraderIdByUser(Util.LoginResult.UserName);
         if (traderID <= 0)
         {
            s = "AUTO-APPROVE task: Cannot retrieve TraderID from PT database for this username.";
            writeLog(s);
            writeLogScreen("Tự động lấy lệnh thỏa thuận để duyệt: không lấy được mã Trader cho người dùng này.", ErrorStatus.Critical);
            return;
         }
         int BuyerCount_RP = Util.HosePTGW.GetBuyerOrdersCountByTrader(CommonSettings.PT_BUYER_BEFORE_PENDING, traderID); //RP buyer deal count            
         if (BuyerCount_RP > 0)
         {
            //show approve form
            btnBuyerApproveSeller_Click(sender, e);
            formBuyerApprove.RefreshData();
         }

         //  MX (cho huy tu seller):
         //      neu chuyen thanh MXS: approve cho seller huy lenh
         //      chuyen thanh MXCS: disapprove seller cancel
         int BuyerCount_MX = Util.HosePTGW.GetBuyerOrdersCountByTrader(CommonSettings.PT_BUYER_CANCEL_WAITING, traderID); //MX buyer deal count            
         if (BuyerCount_MX > 0)
         {
            //show approve form
            btnBuyerApproveSellerCancel_Click(sender, e);
            formBuyerApproveCancel.RefreshData();
         }
      }

      private void btnResetDealTables_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Chỉ thực hiện sau khi kết thúc ngày giao dịch. Phải chắc chắn đã chọn đúng tùy chọn reset. Tiếp tục thực hiện?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            return;
         string s = "";
         string s2 = "";
         if (rd1.Checked)
         {
             try
             {
                 Util.HosePTGW.ResetIdentityPTDealTables();
                 s = "Reset deal tables and their identities successfully!";
                 s2 = "Sao lưu các bảng lệnh và reset ID về 0 thành công!";
             }
             catch (Exception ex)
             {

                 writeLog(ex.Message);
                 writeLogScreen(ex.Message, ErrorStatus.Critical);
             }
         }
         else if (rd2.Checked)
         {
            Util.HosePTGW.ResetPTDealTables();
            s = "Reset deal tables without resetting identities successfully!";
            s2 = "Sao lưu các bảng lệnh thành công, giữ nguyên ID của lệnh (ID tiếp tục tăng)!";
         }
         writeLog(s);
         writeLogScreen(s2, ErrorStatus.OK);
      }

      private void btnBuyerBrowseDeals_Click(object sender, EventArgs e)
      {
         frm2FirmBuyerBrowseDeals frm = new frm2FirmBuyerBrowseDeals();
         frm.Show();
      }

      private void btnView1FirmDeals_Click(object sender, EventArgs e)
      {
         frm1FirmDeals frm = new frm1FirmDeals();
         frm.Show();
      }

      private void btnView2FirmSellerDeals_Click(object sender, EventArgs e)
      {
         frm2FirmSellerDeals frm = new frm2FirmSellerDeals();
         frm.Show();
      }

      private void btnCancelAdv_Click(object sender, EventArgs e)
      {
         frmAdvCancel frm = new frmAdvCancel();
         frm.Show();
      }

      private void btnViewAdv_Click(object sender, EventArgs e)
      {
         frmAdvDeals frm = new frmAdvDeals();
         frm.Show();
      }

      private void btnAdvAnnounce_Click(object sender, EventArgs e)
      {
         frmAdvAnnounce frm = new frmAdvAnnounce();
         frm.Show();
      }
   }

}