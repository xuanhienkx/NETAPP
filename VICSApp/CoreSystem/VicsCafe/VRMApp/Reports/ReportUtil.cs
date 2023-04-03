using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VRMApp.Reports.Accountant;
using VRMApp.Reports.RiskMan;
using VRMApp.Reports;
using VRMApp.Framework;
using VRMApp.ControlBase;
using VRMApp.VRMGateway;
using System.Windows.Forms;

namespace VRMApp.Reports
{
   public static class ReportUtil
   {
      const decimal DEBT_RATE_LIMIT = 0.01M;
      private const string MSG_TITTLE = "Thông báo";
      private static void ShowError()
      {
         ShowError("Bạn không có quyền được xem báo cáo này");
      }
      private static void ShowError(string message)
      {
         WaitingForm.HideMe();
         MessageBox.Show(Util.MainMDI, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      internal static void ShowHĐHTKD()
      {
         int userTakeCare = Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach) ? 0 : Util.LoginUser.UserId;
         HDHTKDCoKyHan rp = new HDHTKDCoKyHan();
         rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

         ReportViewerForm.LoadReport(rp, null);
      }

      internal static void ShowTongCongNo()
      {
         int userTakeCare = Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach) ? 0 : Util.LoginUser.UserId;
         List<CustAssetInfo> data = new List<CustAssetInfo>(Util.VRMService.GetCustomerAssetInfoList(Util.TokenKey, Util.CurrentTransactionDate, string.Empty, userTakeCare, false, DEBT_RATE_LIMIT, false, ContractType.Both));
         if (DataNotValidated(data.Count))
            return;

         Reports.Accountant.TongCongNo tcn = new Reports.Accountant.TongCongNo();
         tcn.SetDataSource(data);
         tcn.SetParameterValue(tcn.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         tcn.SetParameterValue(tcn.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));
         tcn.SetParameterValue(tcn.Parameter_UserIssued.ParameterFieldName, GUIUtil.UserAsString(Util.LoginUser));
         
         Reports.ReportViewerForm.LoadReport(tcn, null);
      }

      internal static void ShowBaoCaoTongHopTKKH()
      {
         int userTakeCare = Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach) ? 0 : Util.LoginUser.UserId;
         List<CustAssetInfo> data = new List<CustAssetInfo>(Util.VRMService.GetCustomerAssetInfoList(Util.TokenKey, Util.CurrentTransactionDate, string.Empty, userTakeCare, false, 0, false, ContractType.Both));
         if (DataNotValidated(data.Count))
            return;

         Reports.Accountant.BaoCaoTongHopTKKH rp = new Reports.Accountant.BaoCaoTongHopTKKH();
         rp.SetDataSource(data);
         rp.SetParameterValue(rp.Parameter_Branch.ParameterFieldName, GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));
         rp.SetParameterValue(rp.Parameter_DateTitle.ParameterFieldName, GUIUtil.DateAndPlaceAsString(DateTime.Now, Util.LoginUser.BranchCode));

         Reports.ReportViewerForm.LoadReport(rp, null);
      }

      internal static void ShowHopDongKD(Contract contract)
      {
         if (!Util.CheckAccess(AccessPermission.BaoCao_ViPhamTyLeTaiSanDamBao))
         {
            ShowError();
            return;
         }

         WaitingForm.ShowMe("Đang lấy dữ liệu");
         Customer customer = Util.VRMService.GetCustomer(Util.TokenKey, contract.CustomerID);

         HopdongKD reportDocument = new HopdongKD();
         reportDocument.SetParameterValue("PrintDate", GUIUtil.DateAsString(DateTime.Today));
         reportDocument.SetParameterValue("ContractNumber", contract.ContractID);
         reportDocument.SetParameterValue("CustomerNameViet", customer.CustomerName.ToUpper());
         reportDocument.SetParameterValue("CardIssuer", customer.CardIssuer);
         reportDocument.SetParameterValue("CardDate", customer.CardDate);
         reportDocument.SetParameterValue("CardIdentity", customer.CardIdentity);
         reportDocument.SetParameterValue("AddressViet", customer.AddressViet);
         reportDocument.SetParameterValue("CustomerID", customer.CustomerId);
         reportDocument.SetParameterValue("MobilePhone1", customer.MobilePhone1);
         reportDocument.SetParameterValue("Telephone", customer.Telephone);
         reportDocument.SetParameterValue("Amount", contract.ApprovalAmount);
         reportDocument.SetParameterValue("AmountByString", "");
         Reports.ReportViewerForm.LoadReport(reportDocument, null);
      }

      internal static void ShowTinhHinhTaiSanCongNo(bool lietKeViPham, bool coTuc, ContractType contractType)
      {
         if ((lietKeViPham && !Util.CheckAccess(AccessPermission.BaoCao_ViPhamTyLeTaiSanDamBao)) ||
            (!lietKeViPham && !Util.CheckAccess(AccessPermission.BaoCao_LietKeThongTinChiTietKH)) ||
            (coTuc && !Util.CheckAccess(AccessPermission.BaoCao_TinhHinhTaiSanCongNoVoiCoTuc)))
         {
            ShowError();
            return;
         }
         WaitingForm.ShowMe("Đang lấy dữ liệu");

         int userTakeCare = Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach) ? 0 : Util.LoginUser.UserId;
         List<CustAssetInfo> data = new List<CustAssetInfo>(Util.VRMService.GetCustomerAssetInfoList(Util.TokenKey, Util.CurrentTransactionDate, string.Empty, userTakeCare, false, 0M, lietKeViPham, contractType));
         if (DataNotValidated(data.Count))
            return;

         CrystalDecisions.CrystalReports.Engine.ReportClass rp;
         if (coTuc)
            rp = new Reports.RiskMan.TaiSanVaCongNoVoiCoTuc();
         else
            rp = new Reports.RiskMan.TaiSanVaCongNo();
         rp.SetDataSource(data);
         rp.SetParameterValue("Branch", GUIUtil.BranchCodeAsString(Util.LoginUser.BranchCode));

         string title;
         if (coTuc)
            title = lietKeViPham ? "BÁO CÁO VI PHẠM TỶ LỆ HỢP TÁC CÓ CỔ TỨC" : "BÁO CÁO TÌNH HÌNH TÀI SẢN VÀ CÔNG NỢ CÓ CỔ TỨC";
         else
            title = lietKeViPham ? "BÁO CÁO VI PHẠM TỶ LỆ HỢP TÁC" : "BÁO CÁO TÌNH HÌNH TÀI SẢN VÀ CÔNG NỢ";
         if (contractType == ContractType.CoThoiHan)
            title += " HĐ CÓ KỲ HẠN";
         else if (contractType == ContractType.KhongThoiHan)
            title += " HĐ KHÔNG KỲ HẠN";

         rp.SetParameterValue("Title", title);
         rp.SetParameterValue("UserTakeCare", userTakeCare == 0 ? "<Tất cả>" : GUIUtil.UserAsString(Util.LoginUser));
         rp.SetParameterValue("printdate", Util.CurrentTransactionDate.ToString("dd/MM/yyyy"));

         Reports.ReportViewerForm.LoadReport(rp, null);
      }

      internal static void ShowGiaoDichNH(DateTime date, string bankGl, string sectionGl, string accountId, string bankSignName)
      {
         DataSet datSet = Util.VRMService.ShowBalanceAccountTransaction(Util.TokenKey, bankGl, sectionGl, accountId, date, date, true);
         if (DataNotValidated(datSet.Tables[1].Rows.Count))
            return;

         LietKeGDTien rp = new LietKeGDTien();
         rp.SetDataSource(datSet.Tables[1]);
         rp.SetParameterValue("printdate", date.ToString("dd/MM/yyyy"));
         rp.SetParameterValue("maCN", Util.LoginUser.BranchCode);
         rp.SetParameterValue("TKchitiet", string.Format("{0}.{1}.{2}", bankGl, sectionGl, accountId));
         rp.SetParameterValue("tenTK", (string)datSet.Tables[0].Rows[0]["accountname"]);
         rp.SetParameterValue("BankName", bankSignName);
         rp.SetParameterValue("Staff", string.IsNullOrEmpty(bankSignName) ? "Thủ quỹ" : "Kế toán ngân hàng");
         rp.SetParameterValue("location", GUIUtil.DateAndPlaceAsString(Util.CurrentTransactionDate, Util.LoginUser.BranchCode));

         Reports.ReportViewerForm.LoadReport(rp, null);
      }

      internal static bool DataNotValidated(int rowCount)
      {
         if (rowCount == 0)
         {
            ShowError("Dữ liệu mà bạn muốn xem báo cáo không có. Điều này có thể do: \n\t- Dữ liệu không có, hoặc\n\t- Bạn không có quyền truy xuất dữ liệu. \n\nNếu điều này gây phiền toái cho bạn, xin vui lòng liên hệ cấp quản lý hoặc IT. ");
            return true; ;
         }
         return false;
      }
   }
}
