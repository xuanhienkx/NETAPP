using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.Framework;
using System.Data.SqlClient;
using VRMApp.ControlBase;
using VRMApp.VRMGateway;
using VRMApp.Reports;

namespace VRMApp.RiskMan
{
   public partial class CustomerInfoForm : FormBase
   {
      CustAssetInfo cData;
      public CustomerInfoForm()
         : this(string.Empty)
      { }

      public CustomerInfoForm(string customerID)
      {
         InitializeComponent();
         if (!string.IsNullOrEmpty(customerID))
         {
            txtCustomerId.Text = customerID;
            backgroundWorker1.RunWorkerAsync(customerID);
            button1.Visible = false;
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(txtCustomerId.Text.Trim()))
         {
            ShowError("Bạn phải nhập vài ký tự sau cùng của mã khách hàng vào.");
            txtCustomerId.Focus();
            return;
         }
         if (!backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending)
            backgroundWorker1.RunWorkerAsync(txtCustomerId.Text.Trim());
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
         ShowWaiting("Đang tìm thông tin khách hàng ...");
         string customerID = (string)e.Argument;

         CustAssetInfo cData = Util.VRMService.GetCustomerAssetInfo(Util.TokenKey, Util.CurrentTransactionDate, customerID, true);
         Customer customer = Util.GetCustomer(cData.CustomerID);
         e.Result = new object[] { customer, cData };
      }

      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(string.Format("Không tìm thấy khách hàng \nLỗi: {0}", e.Error.Message));
            txtCustomerId.Focus();
            return;
         }
         object[] args = e.Result as object[];
         Customer customer = args[0] as Customer;
         cData = args[1] as CustAssetInfo;

         if (customer == null)
         {
            txtCustomerId.Focus();
            ShowError("Không tìm thấy khách hàng");
            return;
         }

         //customer
         txtCustomerId.Text = customer.CustomerId;
         lblCustName.Text = customer.CustomerName;
         lblIntroduceUser.Text = customer.TakeCareUserName;
         lblTel.Text = customer.Telephone;
         lblMobile1.Text = customer.MobilePhone1;
         lblMobile2.Text = customer.MobilePhone2;

         // asset information
         if (cData != null)
         {
            // contract
            if (string.IsNullOrEmpty(cData.SoHD))
               lblNgayHD.Text = labelLoaiHopDong.Text = string.Empty;
            else
            {
               labelLoaiHopDong.Text = cData.LoaiHopHong == ContractType.CoThoiHan ? "CÓ KỲ HẠN" : "KHÔNG KỲ HẠN";
               lblNgayHD.Text = string.Format("(ngày HĐ {0:dd/MM/yyyy} - ngày hết hạn {1:dd/MM/yyyy})", cData.NgayHD, cData.NgayKetThucHD);
            }

            rTienBanCK.Text = lblBanCKChoVe.Text = GUIUtil.MoneyAsString(cData.TienBanCKChoVe);
            rTienKhaDung.Text = lblTienKhaDung.Text = GUIUtil.MoneyAsString(cData.SoDuHienTai);
            rTienBanUT.Text = lblTienUngTruoc.Text = string.Format("-{0}", GUIUtil.MoneyAsString(cData.TienBanUngTruoc));

            lblGiaTriCKTrongTK.Text = GUIUtil.MoneyAsString(cData.CKHienTai);
            lblGiaTriCKChoVe.Text = GUIUtil.MoneyAsString(cData.CKMuaChoVe);
            lblNoQuaHanHD.Text = GUIUtil.MoneyAsString(cData.NoQuaHanHD);
            lblNoTrongHanHD.Text = GUIUtil.MoneyAsString(cData.NoTrongHanHD);
            lblNoQuaHan.Text = GUIUtil.MoneyAsString(cData.NoQuaHan);
            lblNoTrongHan.Text = GUIUtil.MoneyAsString(cData.NoTrongHan);
            lblPhaiTraTrongNgay.Text = GUIUtil.MoneyAsString(cData.PhaiTraTrongNgay);
            lblMuaChuaHT.Text = GUIUtil.MoneyAsString(cData.TienMuaCKChuaHachToan);

             //GD T2 no tu T0 nen khong co no trong han va no qua han
            //lblTongNoTraCham.Text = GUIUtil.MoneyAsString(cData.NoTrongHan + cData.NoQuaHan);
            lblTongNoTraCham.Text = GUIUtil.MoneyAsString(cData.NoQuaHan);
            lblTongCo.Text = GUIUtil.MoneyAsString(cData.TongTS);
            lblTongNo.Text = GUIUtil.MoneyAsString(cData.TongNo);

            lblF1.Text = GUIUtil.FormatRate(cData.TyLeF1 / 100M, true);
            lblF2.Text = GUIUtil.FormatRate(cData.TyLeF2 / 100M, true);
            if (cData.TongTS + cData.QuyenMuaChungKhoan + cData.CoTucBangChungKhoan - cData.TienMuaQuyen != 0)
               f3label1.Text = GUIUtil.FormatRate(cData.TongNo / (cData.TongTS + cData.QuyenMuaChungKhoan + cData.CoTucBangChungKhoan - cData.TienMuaQuyen), true);
            else
               f3label1.Text = GUIUtil.FormatRate(0M, true);
            lblDebtRate.Text = GUIUtil.FormatRate(cData.TyLeNo / 100M, true);
            lblWarningRate.Text = GUIUtil.FormatRate(cData.TyLeHopTac / 100M, true);
            lblSoTienDuocRut.Text = GUIUtil.MoneyAsString(cData.SoTienDuocRut);

            coTucLabel.Text = GUIUtil.MoneyAsString(cData.CoTucBangChungKhoan + cData.CoTucBangTien + cData.QuyenMuaChungKhoan);
            rTienMuaQuyen.Text = tienMuaQuyenLabel.Text = string.Format("-{0}", GUIUtil.MoneyAsString(cData.TienMuaQuyen));

            rGiaTriCKTrongTK.Text = GUIUtil.MoneyAsString(cData.RCKHienTai);
            rGiaTriCKVe.Text = GUIUtil.MoneyAsString(cData.RCKMuaChoVe);
            rCoTucVaQuyen.Text = GUIUtil.MoneyAsString(cData.RCoTucBangChungKhoan + cData.CoTucBangTien + cData.RQuyenMuaChungKhoan);

            rTongTS.Text = GUIUtil.MoneyAsString(cData.RTongTS);
            rTiLeNo.Text = cData.RTongTS == 0M ?
                  GUIUtil.FormatRate(0M, true) :
                  GUIUtil.FormatRate(cData.TongNo / cData.RTongTS, true);
         }

         CloseWaiting();
      }

      private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            button1.PerformClick();
      }

      private void button3_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void button2_Click(object sender, EventArgs e)
      {
         if (cData == null)
            return;

         DebtJusticeForm dj = new DebtJusticeForm(cData);
         dj.ShowDialog();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.MoiGioi_ThongTinKhachHang);
      }
   }
}
