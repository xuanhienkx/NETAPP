using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using VRMApp.Accountant;
using VRMApp.Brokerage;
using VRMApp.Depository;
using VRMApp.Framework;
using VRMApp.ControlBase;
using System.Deployment.Application;

namespace VRMApp
{
    public partial class MDI : Form
    {
        public MDI()
        {

            InitializeComponent();

            string v = string.Empty;
            // clickone version
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                v = string.Format("Published v{0}.{1}:build {2}.{3}", myVersion.Major, myVersion.Minor, myVersion.Build, myVersion.Revision);
            }
            else
            {
                Version version = Util.VRMVersion();
                v = string.Format("Assembly v{0}.{1} build {2}.{3}", version.Major, version.Minor, version.Build,version.Revision);

            }

            // assemply version

            lblVersion.Text = v;
        }

        public void ShowNotification(string messageFormat, params object[] args)
        {
            notifyIcon.ShowBalloonTip(0, "Thông báo", string.Format(messageFormat, args), ToolTipIcon.Info);
        }

        public void InvisibleMenuItem()
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
                VisibleMenuItem(item);
        }

        private void VisibleMenuItem(ToolStripMenuItem item)
        {
            if (item.DropDownItems.Count == 0 && item.AccessibleName != null)
                item.Visible = Util.CheckAccess(item.AccessibleName);
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
                Version version = Util.VRMVersion();
                string vics = Util.VRMService.HelloVics();
                if (vics != string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build))
                {
                    MessageBox.Show("Hiện đã có phiên bản cập nhật mới. \n Vui lòng đóng chương trình để bạn được sử dụng phiên bản cập nhật nhất.",
                       "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
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
                InputDiaglogBox.Result r = InputDiaglogBox.Show("Thông số kết nối hệ thống:", Util.VRMService.Url, "Thiết lập tham số");
                if (!r.IsOK)
                    break;

                Util.VRMService.Url = r.InputMessage;
                try
                {
                    Util.VRMService.HelloVics();
                    VRMApp.Properties.Settings.Default.VRMApp_VRMGateway_VRMService = r.InputMessage;
                    VRMApp.Properties.Settings.Default.Save();
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
            Security.Login.Show<Security.Login>(new VRMApp.ControlBase.CreateForm(delegate() { return new Security.Login(); }));
        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Util.VRMService.ClearTokenKey(Util.TokenKey);
                WaitingForm.HideMe();
            }
            catch { }
        }

        private void MDI_Shown(object sender, EventArgs e)
        {
            if (!Util.IsAuthenticated())
                Security.Login.Show<Security.Login>(new VRMApp.ControlBase.CreateForm(delegate() { return new Security.Login(); }));
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
                    Util.VRMService.ChangeUserPassword(Util.TokenKey, Util.LoginUser.UserId, Util.LoginUser.Password);
                    MessageBox.Show(this, "Password mới đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Util.SetCurrentTime(Session.OneSecond);
            serverTimeLable.Text = Util.CurrentTransactionDate.ToString("HH:mm:ss");
        }

        private void thamSoKetNoiMenuItem_Click(object sender, EventArgs e)
        {
            ShowWebServiceConfig();
        }

        private void thamSoHeThongMenuItem_Click(object sender, EventArgs e)
        {
            Security.Settings.Show<Security.Settings>(new CreateForm(delegate() { return new Security.Settings(); }));
        }

        private void vanTinMenuItem_Click(object sender, EventArgs e)
        {
            RiskMan.CustomerInfoForm.Show<RiskMan.CustomerInfoForm>(new CreateForm(delegate() { return new RiskMan.CustomerInfoForm(); }));
        }

        private void dangKyMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.CustomerListForm.Show<Brokerage.CustomerListForm>(new CreateForm(delegate() { return new Brokerage.CustomerListForm(); }));
        }

        private void hopdonghoptacMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.ContractListForm.Show<Brokerage.ContractListForm>(
               new CreateForm(delegate() { return new Brokerage.ContractListForm(); }),
               new Predicate<VRMApp.Brokerage.ContractListForm>(delegate(Brokerage.ContractListForm f) { return f.ShowAsAction == VRMApp.Brokerage.ContractListAction.All; }));
        }

        private void thiếtLậpTỉLệHợpTácChoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.CustomerForm.Show<Brokerage.CustomerForm>(new CreateForm(delegate() { return new Brokerage.CustomerForm(); }));
        }

        private void danhSáchChứngKhoánCầmCốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskMan.StockListForm.Show<RiskMan.StockListForm>(new CreateForm(delegate() { return new RiskMan.StockListForm(); }));
        }

        private void tínhLãiTrảChậmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.DefInterestCalcForm.Show<Accountant.DefInterestCalcForm>(
               new CreateForm(delegate() { return new Accountant.DefInterestCalcForm(VRMApp.Accountant.DefInterestCalcForm.ShowMode.ShowForCriteria); }),
               new Predicate<Accountant.DefInterestCalcForm>(delegate(Accountant.DefInterestCalcForm f) { return f.showMode == Accountant.DefInterestCalcForm.ShowMode.ShowForCriteria; }));
        }

        private void thuTiềnThiếuNgàyTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.DeferredCalcForm.Show<Accountant.DeferredCalcForm>(new CreateForm(delegate() { return new Accountant.DeferredCalcForm(); }));
        }

        private void giảiNgânHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.ContractListForm.Show<Brokerage.ContractListForm>(
               new CreateForm(delegate() { return new Brokerage.ContractListForm(VRMApp.Brokerage.ContractListAction.Disburse); }),
               new Predicate<VRMApp.Brokerage.ContractListForm>(delegate(Brokerage.ContractListForm f) { return f.ShowAsAction == VRMApp.Brokerage.ContractListAction.Disburse; }));
        }

        private void thanhLýHĐCóKỳHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.ContractListForm.Show<Brokerage.ContractListForm>(
               new CreateForm(delegate() { return new Brokerage.ContractListForm(VRMApp.Brokerage.ContractListAction.Withdraw); }),
               new Predicate<VRMApp.Brokerage.ContractListForm>(delegate(Brokerage.ContractListForm f) { return f.ShowAsAction == VRMApp.Brokerage.ContractListAction.Withdraw; }));
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskMan.CustomerInfoForm.Show<RiskMan.CustomerInfoForm>(new CreateForm(delegate() { return new RiskMan.CustomerInfoForm(); }));
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Security.RightAccess.Show<Security.RightAccess>(new CreateForm(delegate() { return new Security.RightAccess(); }));
        }

        private void xemDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.DefInterestCalcForm.Show<Accountant.DefInterestCalcForm>(
               new CreateForm(delegate() { return new Accountant.DefInterestCalcForm(Accountant.DefInterestCalcForm.ShowMode.ShowAll); }),
               new Predicate<Accountant.DefInterestCalcForm>(delegate(Accountant.DefInterestCalcForm f) { return f.showMode == Accountant.DefInterestCalcForm.ShowMode.ShowAll; }));
        }

        private void capHanMucDauNgayMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.DebitLimitOnCustomerListForm.Show<Brokerage.DebitLimitOnCustomerListForm>(new CreateForm(delegate() { return new Brokerage.DebitLimitOnCustomerListForm(); }));
        }

        private void chiTiếtHĐHTKDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowHĐHTKD();
        }

        private void tổngCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTongCongNo();
        }

        private void danhSáchĐốiChiếuCKNiêmYếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depository.MissingStockForm.Show<Depository.MissingStockForm>(new CreateForm(delegate() { return new Depository.MissingStockForm(); }));
        }

        private void thôngTinTàiKhoảnKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowBaoCaoTongHopTKKH();
        }

        private void cổTứcBằngTiềnCổPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depository.ExecRightForm.Show<Depository.ExecRightForm>(new CreateForm(delegate() { return new Depository.ExecRightForm(); }));
        }

        private void quyềnMuaCổTứcTiềnHoặcCổPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depository.ExecRightRegisterForm.Show<Depository.ExecRightRegisterForm>(new CreateForm(delegate() { return new Depository.ExecRightRegisterForm(); }));
        }

        private void báoCáoViPhạmTỷLệĐảmBảoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTinhHinhTaiSanCongNo(true, false, VRMApp.VRMGateway.ContractType.Both);
        }

        private void xemLaijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.IssuedAccountForm.Show<Accountant.IssuedAccountForm>(new CreateForm(delegate() { return new Accountant.IssuedAccountForm(); }));
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Brokerage.DeferredListForm.Show<Brokerage.DeferredListForm>(new CreateForm(delegate() { return new Brokerage.DeferredListForm(); }));
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            RiskMan.CustomerInfoListForm.Show<RiskMan.CustomerInfoListForm>(new CreateForm(delegate() { return new RiskMan.CustomerInfoListForm(); }));
        }

        private void báoCáoTìnhHìnhTàiSảnCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTinhHinhTaiSanCongNo(false, false, VRMApp.VRMGateway.ContractType.Both);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Accountant.ReleaseBlockedBalanceForm.Show<Accountant.ReleaseBlockedBalanceForm>(new CreateForm(delegate() { return new Accountant.ReleaseBlockedBalanceForm(); }));
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTinhHinhTaiSanCongNo(false, true, VRMApp.VRMGateway.ContractType.Both);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Accountant.ShowBalanceAccountForm.Show<Accountant.ShowBalanceAccountForm>(new CreateForm(delegate() { return new Accountant.ShowBalanceAccountForm(); }));
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Accountant.InterestCalcDateList.Show<Accountant.InterestCalcDateList>(new CreateForm(delegate() { return new Accountant.InterestCalcDateList(); }));
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Accountant.BankTransactionForm.Show<Accountant.BankTransactionForm>(new CreateForm(delegate() { return new Accountant.BankTransactionForm(); }));
        }

        private void yêuCâuƯngTrươcInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.BuyCashContractListForm.Show<Accountant.BuyCashContractListForm>(new CreateForm(delegate() { return new Accountant.BuyCashContractListForm(); }));
        }

        private void dSHơpĐôngMuaQuyênĐaPhatVayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.ContractReportForm.Show<Accountant.ContractReportForm>(
               new CreateForm(delegate() { return new Accountant.ContractReportForm(Accountant.ContractReportForm.ContractFormType.BuyCash); }),
               new Predicate<VRMApp.Accountant.ContractReportForm>(delegate(VRMApp.Accountant.ContractReportForm f)
            {
                return f.GetFormType() == VRMApp.Accountant.ContractReportForm.ContractFormType.BuyCash;
            }));
        }

        private void danhSachHĐƯTVơiNHAnBinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.ContractReportForm.Show<Accountant.ContractReportForm>(
               new CreateForm(delegate() { return new Accountant.ContractReportForm(Accountant.ContractReportForm.ContractFormType.Advance); }),
               new Predicate<VRMApp.Accountant.ContractReportForm>(delegate(VRMApp.Accountant.ContractReportForm f)
            {
                return f.GetFormType() == VRMApp.Accountant.ContractReportForm.ContractFormType.Advance;
            }));
        }

        private void baoCaoTinhHinhTiênNơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.ContractStatusCriteriaForm.Show<Accountant.ContractStatusCriteriaForm>(
               new CreateForm(delegate() { return new Accountant.ContractStatusCriteriaForm(VRMApp.VRMGateway.ContractType.KhongThoiHan); }),
               new Predicate<VRMApp.Accountant.ContractStatusCriteriaForm>(delegate(VRMApp.Accountant.ContractStatusCriteriaForm f)
               {
                   return f.ContractType == VRMApp.VRMGateway.ContractType.KhongThoiHan;
               }));
        }

        private void báoCáoCôngNợTàiSảnCủaHĐCóKỳHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTinhHinhTaiSanCongNo(false, false, VRMApp.VRMGateway.ContractType.CoThoiHan);
        }

        private void báoCáoTìnhHìnhCôngNợTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportUtil.ShowTinhHinhTaiSanCongNo(false, false, VRMApp.VRMGateway.ContractType.KhongThoiHan);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Accountant.IntermIntCalcForm.Show<Accountant.IntermIntCalcForm>(
               new CreateForm(delegate() { return new Accountant.IntermIntCalcForm(); }));
        }

        private void danhSáchNợTiềnNgàyTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.DeferredTDayListForm.Show<Accountant.DeferredTDayListForm>(new CreateForm(delegate() { return new Accountant.DeferredTDayListForm(); }));

        }

        private void danhSáchNgânHàngChuyểnTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.BankListForm.Show<Accountant.BankListForm>(new CreateForm(delegate() { return new Accountant.BankListForm(); }),
              new Predicate<VRMApp.Accountant.BankListForm>(delegate(Accountant.BankListForm f) { return true; }));
        }

        private void đăngKýDịchVụChuyểnTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.OnlineRegistedListForm.Show<Accountant.OnlineRegistedListForm>(new CreateForm(delegate() { return new Accountant.OnlineRegistedListForm(); }),
                  new Predicate<VRMApp.Accountant.OnlineRegistedListForm>(delegate(Accountant.OnlineRegistedListForm f) { return true; }));

        }

        private void duyệtGiaoDịchChuyểnTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.OnlineTransferListForm.Show<Accountant.OnlineTransferListForm>(new CreateForm(delegate() { return new Accountant.OnlineTransferListForm(); }));
        }

        private void lịchSửChuyểnTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.OnlineTransferHistForm.Show<Accountant.OnlineTransferHistForm>(new CreateForm(delegate() { return new Accountant.OnlineTransferHistForm(); }));
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Accountant.BankTransactionForm.Show<Accountant.BankTransactionForm>(new CreateForm(delegate() { return new Accountant.BankTransactionForm(true); }),
               new Predicate<VRMApp.Accountant.BankTransactionForm>(delegate(Accountant.BankTransactionForm f) { return !f.isAnBinhBank; }));
        }

        private void importTTNCNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountant.CustomerIncomeTax.Show<Accountant.CustomerIncomeTax>(new CreateForm(delegate() { return new Accountant.CustomerIncomeTax(); }));
        }

        private void binhquangiavonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskMan.PriceAveragecsForm.Show<RiskMan.PriceAveragecsForm>(new CreateForm(delegate() { return new RiskMan.PriceAveragecsForm(); }));
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            SecurityFeeForm.Show<SecurityFeeForm>(
               new CreateForm(delegate() { return new SecurityFeeForm(SecurityFeeForm.ShowMode.ShowAll); }),
              new Predicate<SecurityFeeForm>(delegate(SecurityFeeForm f) { return f.showMode == SecurityFeeForm.ShowMode.ShowAll; })
               );
        }

        private void tooltonghopphiluuky_Click(object sender, EventArgs e)
        {
            SummaryCustodyForm.Show<SummaryCustodyForm>(
                new CreateForm(delegate() { return new SummaryCustodyForm(); }));
        }

        private void ngayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brokerage.DaySummaryTradingresultForm.Show<Brokerage.DaySummaryTradingresultForm>(
                new CreateForm(delegate() { return new Brokerage.DaySummaryTradingresultForm(); }));
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {

            SecurityFeeForm.Show<SecurityFeeForm>(
               new CreateForm(delegate() { return new SecurityFeeForm(SecurityFeeForm.ShowMode.ShowForSellT3); }),
              new Predicate<SecurityFeeForm>(delegate(SecurityFeeForm f) { return f.showMode == SecurityFeeForm.ShowMode.ShowForSellT3; })
               );
        }

    }
}
