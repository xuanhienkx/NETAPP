using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VRMApp.Framework
{
   public enum AccessPermission
   {
      None,
      /////// Special right do not show in the menu /////////
      AdminBranch,         // nguoi co quyen lon nhat theo branchcode
      AdminLocal,          // nguoi co quyen lon nhat theo branchcode va tradecode
      ///////////////////////////////////////////////////////

      Quantri_PhanQuyen,

      MoiGioi_ThongTinKhachHang,
      MoiGioi_DanhSachKhachHang,
      MoiGioi_CapHanMucTinDung,
      MoiGioi_CapHanMucTinDungTatCa,
      MoiGioi_HopDongHTKD,
      MoiGioi_DuyetHopDong,
      MoiGioi_XemDSKhachHangThieuTien,

      KeToan_GiaiNganHopDong,
      KeToan_ThanhLyHopHong,
      KeToan_HachToanChoNoChamTienNgayT,
      KeToan_HachToanTinhLaiTraCham,
      KeToan_ThuTienNoHDKhongKyHan,
      KeToan_TinhLaiTraCham,
      KeToan_XemCacButToanHachToan,
      KeToan_XoaButToan,
      KeToan_DuyetButToan,
      KeToan_GiaiToaTien,
      KeToan_BaoCaoTongHopTaiKhoan,
      KeToan_TuDongGiaiToaTien,
      KeToan_LietKeGiaoDichTienNH,
      KetToan_UngTruocInternet,
      KeToan_InDSHDMuaQuyen,
      KeToan_InDSHDUTVoiNH,
      KeToan_BaoCaoTinhHinhHDKhongKH,
      KeToan_ChonDSHDUngTruocVoiNH,

      KeToan_DSNganHangChuyenTien,
      KeToan_DSChiNhanhChuyenTien,
      KeToan_DangKyChuyenTien,
      KeToan_DuyetGiaoDichChuyenTien,
      KeToan_LichSuChuyenTien,
      KeToan_ImprotThuethunhapcanhan,

      LuuKy_XemDanhSachChungKhoanBiThieu,
      LuuKy_TheoGioiCoTucChuaVe,
      LuuKy_HuyGiaoDichDaChot,
      LuuKy_Tinhphiluuky,

      QTRR_XemDanhSachCKCamCo,
      QTRR_ThietLapDSCKCamCo,
      QTRR_ThietLapTiLeHopTac,
      QTRR_XuLyKhachHangViPham,
      QTRR_DuocXemHetDanhSach,
      QTRR_TheoGioiKhachHangDacBiet,
      QTRR_GiaVonBinhQuan,

      BaoCao_ChiTietHDHTKD,
      BaoCao_TienLaiHTKDChuaThu,
      BaoCao_TienLaiHTKDDaThu,
      BaoCao_ViPhamTyLeTaiSanDamBao,
      BaoCao_LietKeThongTinChiTietKH,
      BaoCao_TinhHinhTaiSanCongNoVoiCoTuc,

   }

   public static class AccessUtil
   {
      public static void BindingAllPermission(TreeView rootTreeNode)
      {
         TreeNode node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "CHỨC NĂNG CHUNG");

         if (Util.CheckAccess(AccessPermission.Quantri_PhanQuyen))
            node.Nodes.Add(AccessPermission.Quantri_PhanQuyen.ToString(), "Phân quyền người dùng");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "MÔI GIỚI");
         if (Util.CheckAccess(AccessPermission.MoiGioi_ThongTinKhachHang))
            node.Nodes.Add(AccessPermission.MoiGioi_ThongTinKhachHang.ToString(), "Xem thông tin nhà đầu tư");
         if (Util.CheckAccess(AccessPermission.MoiGioi_DanhSachKhachHang))
            node.Nodes.Add(AccessPermission.MoiGioi_DanhSachKhachHang.ToString(), "Xem danh sách khách hàng");
         if (Util.CheckAccess(AccessPermission.MoiGioi_CapHanMucTinDung))
            node.Nodes.Add(AccessPermission.MoiGioi_CapHanMucTinDung.ToString(), "Cấp hạn mức tính dụng đầu ngày");
         if (Util.CheckAccess(AccessPermission.MoiGioi_CapHanMucTinDungTatCa))
            node.Nodes.Add(AccessPermission.MoiGioi_CapHanMucTinDungTatCa.ToString(), "Cấp hạn mức tính dụng đầu ngày cho tất cả khách hàng");
         if (Util.CheckAccess(AccessPermission.MoiGioi_HopDongHTKD))
            node.Nodes.Add(AccessPermission.MoiGioi_HopDongHTKD.ToString(), "Tạo hợp đồng HTKD");
         if (Util.CheckAccess(AccessPermission.MoiGioi_DuyetHopDong))
            node.Nodes.Add(AccessPermission.MoiGioi_DuyetHopDong.ToString(), "Duyệt hợp đồng hợp tác kinh doanh");
         if (Util.CheckAccess(AccessPermission.MoiGioi_XemDSKhachHangThieuTien))
            node.Nodes.Add(AccessPermission.MoiGioi_XemDSKhachHangThieuTien.ToString(), "Xem danh sách khách hàng nợ tiền ngày T");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "KẾ TOÁN");
         if (Util.CheckAccess(AccessPermission.KeToan_GiaiNganHopDong))
            node.Nodes.Add(AccessPermission.KeToan_GiaiNganHopDong.ToString(), "Giải ngân HĐ HTKD có kỳ hạn");
         if (Util.CheckAccess(AccessPermission.KeToan_ThanhLyHopHong))
            node.Nodes.Add(AccessPermission.KeToan_ThanhLyHopHong.ToString(), "Thanh lý HĐ HTKD có kỳ hạn");
         if (Util.CheckAccess(AccessPermission.KeToan_HachToanChoNoChamTienNgayT))
            node.Nodes.Add(AccessPermission.KeToan_HachToanChoNoChamTienNgayT.ToString(), "Hạch toán cho nợ chậm tiền HĐ HTKD không thời hạn");
         if (Util.CheckAccess(AccessPermission.KeToan_HachToanTinhLaiTraCham))
            node.Nodes.Add(AccessPermission.KeToan_HachToanTinhLaiTraCham.ToString(), "Hạch toán tính phí trả chậm (khách hàng đủ tiền trả phí");
         if (Util.CheckAccess(AccessPermission.KeToan_ThuTienNoHDKhongKyHan))
            node.Nodes.Add(AccessPermission.KeToan_ThuTienNoHDKhongKyHan.ToString(), "Hạch toán thu nợ chậm tiền HĐ HTKD không thời hạn");
         if (Util.CheckAccess(AccessPermission.KeToan_TinhLaiTraCham))
            node.Nodes.Add(AccessPermission.KeToan_TinhLaiTraCham.ToString(), "Tính lãi trả chậm");
         if (Util.CheckAccess(AccessPermission.KeToan_XemCacButToanHachToan))
            node.Nodes.Add(AccessPermission.KeToan_XemCacButToanHachToan.ToString(), "Xem lại các bút toán đã hạch toán");
         if (Util.CheckAccess(AccessPermission.KeToan_DuyetButToan))
            node.Nodes.Add(AccessPermission.KeToan_DuyetButToan.ToString(), "Duyệt các bút toán nội bảng");
         if (Util.CheckAccess(AccessPermission.KeToan_XoaButToan))
            node.Nodes.Add(AccessPermission.KeToan_XoaButToan.ToString(), "Xóa các bút toán nội bảng hình thành từ VICS cafe");
         if (Util.CheckAccess(AccessPermission.KeToan_GiaiToaTien))
            node.Nodes.Add(AccessPermission.KeToan_GiaiToaTien.ToString(), "Giải tỏa tiền bằng tay (nội bộ và ngân hàng)");
         if (Util.CheckAccess(AccessPermission.KeToan_BaoCaoTongHopTaiKhoan))
            node.Nodes.Add(AccessPermission.KeToan_BaoCaoTongHopTaiKhoan.ToString(), "Báo cáo tổng hợp tài khoản nội bảng");
         if (Util.CheckAccess(AccessPermission.KeToan_TuDongGiaiToaTien))
            node.Nodes.Add(AccessPermission.KeToan_TuDongGiaiToaTien.ToString(), "Tự động giải tỏa tiền khi duyệt bút toán");
         if (Util.CheckAccess(AccessPermission.KeToan_LietKeGiaoDichTienNH))
            node.Nodes.Add(AccessPermission.KeToan_LietKeGiaoDichTienNH.ToString(), "Liệt kê nộp rút tiền gửi của nhà đầu tư tại ngân hàng");
         if (Util.CheckAccess(AccessPermission.KetToan_UngTruocInternet))
            node.Nodes.Add(AccessPermission.KetToan_UngTruocInternet.ToString(), "Xem danh sách ứng trước internet");
         if (Util.CheckAccess(AccessPermission.KeToan_InDSHDMuaQuyen))
            node.Nodes.Add(AccessPermission.KeToan_InDSHDMuaQuyen.ToString(), "In danh sách hợp đồng mua quyền đã phát vay");
         if (Util.CheckAccess(AccessPermission.KeToan_InDSHDUTVoiNH))
            node.Nodes.Add(AccessPermission.KeToan_InDSHDUTVoiNH.ToString(), "In danh sách hợp đồng ứng trước với ngân hàng");
         if (Util.CheckAccess(AccessPermission.KeToan_ChonDSHDUngTruocVoiNH))
            node.Nodes.Add(AccessPermission.KeToan_ChonDSHDUngTruocVoiNH.ToString(), "Cho phép chọn khách hàng theo đơn vị khi in HĐ ứng trước với ngân hàng");
         if (Util.CheckAccess(AccessPermission.KeToan_BaoCaoTinhHinhHDKhongKH))
            node.Nodes.Add(AccessPermission.KeToan_BaoCaoTinhHinhHDKhongKH.ToString(), "Xem báo cáo tình hình nợ tiền hợp đồng không kỳ hạn");

         if (Util.CheckAccess(AccessPermission.KeToan_DSNganHangChuyenTien))
            node.Nodes.Add(AccessPermission.KeToan_DSNganHangChuyenTien.ToString(), "Cập nhật ngân hàng chuyển tiền");
         if (Util.CheckAccess(AccessPermission.KeToan_DSChiNhanhChuyenTien))
            node.Nodes.Add(AccessPermission.KeToan_DSChiNhanhChuyenTien.ToString(), "Cập nhật chi nhánh chuyển tiền");
         if (Util.CheckAccess(AccessPermission.KeToan_DangKyChuyenTien))
            node.Nodes.Add(AccessPermission.KeToan_DangKyChuyenTien.ToString(), "Đăng ký chuyển tiền");
         if (Util.CheckAccess(AccessPermission.KeToan_DuyetGiaoDichChuyenTien))
            node.Nodes.Add(AccessPermission.KeToan_DuyetGiaoDichChuyenTien.ToString(), "Duyệt giao dịch chuyển tiền");
         if (Util.CheckAccess(AccessPermission.KeToan_LichSuChuyenTien))
            node.Nodes.Add(AccessPermission.KeToan_LichSuChuyenTien.ToString(), "Xem lịch sử chuyển tiền");

         if (Util.CheckAccess(AccessPermission.KeToan_ImprotThuethunhapcanhan))
             node.Nodes.Add(AccessPermission.KeToan_ImprotThuethunhapcanhan.ToString(), "Imprt thuế thu nhập cá nhân vào phần mềm kế toán");
  

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "LƯU KÝ");
         if (Util.CheckAccess(AccessPermission.LuuKy_XemDanhSachChungKhoanBiThieu))
            node.Nodes.Add(AccessPermission.LuuKy_XemDanhSachChungKhoanBiThieu.ToString(), "Xem danh sách CK niêm yết không có trong SBS");
         if (Util.CheckAccess(AccessPermission.LuuKy_TheoGioiCoTucChuaVe))
            node.Nodes.Add(AccessPermission.LuuKy_TheoGioiCoTucChuaVe.ToString(), "Theo giõi cổ tức chưa về");
         if (Util.CheckAccess(AccessPermission.LuuKy_HuyGiaoDichDaChot))
            node.Nodes.Add(AccessPermission.LuuKy_HuyGiaoDichDaChot.ToString(), "Cho phép hủy giao dịch trả cổ tức hoặc quyền mua khi đã chốt danh sách");
         if (Util.CheckAccess(AccessPermission.LuuKy_Tinhphiluuky))
             node.Nodes.Add(AccessPermission.LuuKy_Tinhphiluuky.ToString(), "Cho phép tính phí lưu ký");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "QUẢN TRỊ RỦI RO");
         if (Util.CheckAccess(AccessPermission.QTRR_XemDanhSachCKCamCo))
            node.Nodes.Add(AccessPermission.QTRR_XemDanhSachCKCamCo.ToString(), "Xem danh sách CK được cầm cố");
         if (Util.CheckAccess(AccessPermission.QTRR_ThietLapDSCKCamCo))
            node.Nodes.Add(AccessPermission.QTRR_ThietLapDSCKCamCo.ToString(), "Thiết lập chi tiết CK cầm cố");
         if (Util.CheckAccess(AccessPermission.QTRR_ThietLapTiLeHopTac))
            node.Nodes.Add(AccessPermission.QTRR_ThietLapTiLeHopTac.ToString(), "Thiết lập tỉ lệ hợp tác cho khách hàng");
         if (Util.CheckAccess(AccessPermission.QTRR_XuLyKhachHangViPham))
            node.Nodes.Add(AccessPermission.QTRR_XuLyKhachHangViPham.ToString(), "Xem thông tin chi tiết và xử lý vi phạm tỉ lệ cho khách hàng");
         if (Util.CheckAccess(AccessPermission.QTRR_DuocXemHetDanhSach))
            node.Nodes.Add(AccessPermission.QTRR_DuocXemHetDanhSach.ToString(), "Được xem hết thông tin khách hàng khác mà mình không quản lý");
         if (Util.CheckAccess(AccessPermission.QTRR_TheoGioiKhachHangDacBiet))
            node.Nodes.Add(AccessPermission.QTRR_TheoGioiKhachHangDacBiet.ToString(), "Được phép theo giõi thông tin của khách hàng đặc biệt");
         if (Util.CheckAccess(AccessPermission.QTRR_GiaVonBinhQuan))
             node.Nodes.Add(AccessPermission.QTRR_GiaVonBinhQuan.ToString(), "Được phép thiết lập giá vốn bình quân");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "BÁO CÁO");
         if (Util.CheckAccess(AccessPermission.BaoCao_ViPhamTyLeTaiSanDamBao))
            node.Nodes.Add(AccessPermission.BaoCao_ViPhamTyLeTaiSanDamBao.ToString(), "Xem báo cáo vi phạm tỷ lệ đảm bảo");
         if (Util.CheckAccess(AccessPermission.BaoCao_LietKeThongTinChiTietKH))
            node.Nodes.Add(AccessPermission.BaoCao_LietKeThongTinChiTietKH.ToString(), "Xem thông tin chi tiết tài sản và công nợ của tất cả các khách hàng");
         if (Util.CheckAccess(AccessPermission.BaoCao_TinhHinhTaiSanCongNoVoiCoTuc))
            node.Nodes.Add(AccessPermission.BaoCao_TinhHinhTaiSanCongNoVoiCoTuc.ToString(), "Xem thông tin chi tiết tài sản có tính cổ tức và công nợ của tất cả các khách hàng");
       


         //BaoCao_ChiTietHDHTKD,
         //BaoCao_TienLaiHTKDChuaThu,
         //BaoCao_TienLaiHTKDDaThu,
      }
   }
}
