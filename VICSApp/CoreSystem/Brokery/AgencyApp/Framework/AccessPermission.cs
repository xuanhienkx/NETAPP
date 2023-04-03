using System.Windows.Forms;
using CommonDomain;

namespace Brokery.Framework
{
   public static class AccessBuilding
   {
      public static void BindingAllPermission(TreeView rootTreeNode)
      {
         TreeNode node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "Quản trị hệ thống");

         if (Util.CheckAccess(AccessPermission.VICS_PhanQuyen))
            node.Nodes.Add(AccessPermission.VICS_PhanQuyen.ToString(), "Xem quyền theo nhóm");
         if (Util.CheckAccess(AccessPermission.VICS_PhanQuyen_CapNhat))
            node.Nodes.Add(AccessPermission.VICS_PhanQuyen_CapNhat.ToString(), "Cập nhật quyền theo nhóm");

         if (Util.CheckAccess(AccessPermission.VICS_QuanLyNhom))
            node.Nodes.Add(AccessPermission.VICS_QuanLyNhom.ToString(), "Xem danh sách nhóm");
         if (Util.CheckAccess(AccessPermission.VICS_QuanLyNhom_CapNhat))
            node.Nodes.Add(AccessPermission.VICS_QuanLyNhom_CapNhat.ToString(), "Cập nhật danh sách nhóm");

         if (Util.CheckAccess(AccessPermission.VICS_QuanLyNguoiDung))
            node.Nodes.Add(AccessPermission.VICS_QuanLyNguoiDung.ToString(), "Xem danh sách người dùng");
         if (Util.CheckAccess(AccessPermission.VICS_QuanLyNguoiDung_CapNhat))
            node.Nodes.Add(AccessPermission.VICS_QuanLyNguoiDung_CapNhat.ToString(), "Cập nhật danh sách người dùng");
         if (Util.CheckAccess(AccessPermission.VICS_ThietLapThamSo))
             node.Nodes.Add(AccessPermission.VICS_ThietLapThamSo.ToString(), "Thiết lập tham số hệ thống");
         if (Util.CheckAccess(AccessPermission.VICS_CapNhatPhiDaiLy))
             node.Nodes.Add(AccessPermission.VICS_CapNhatPhiDaiLy.ToString(), "Cập nhật phí đại lý");
         
         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "Giao dịch khối môi giới");
         if (Util.CheckAccess(AccessPermission.VICS_VanTin))
            node.Nodes.Add(AccessPermission.VICS_VanTin.ToString(), "Vấn tin thông tin khách hàng");
         if (Util.CheckAccess(AccessPermission.VICS_VanTinChiTiet))
             node.Nodes.Add(AccessPermission.VICS_VanTinChiTiet.ToString(), "Xem thông tin chi tiết khách hàng");
         if (Util.CheckAccess(AccessPermission.VICS_DatLenh))
            node.Nodes.Add(AccessPermission.VICS_DatLenh.ToString(), "Đặt lệnh giao dịch");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhHOSE))
            node.Nodes.Add(AccessPermission.VICS_HuyLenhHOSE.ToString(), "Hủy lệnh sàn HOSE");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhGiaoDichHOSE))
             node.Nodes.Add(AccessPermission.VICS_HuyLenhGiaoDichHOSE.ToString(), "Hủy lệnh giao dịch sàn HOSE");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhHNX))
            node.Nodes.Add(AccessPermission.VICS_HuyLenhHNX.ToString(), "Hủy lệnh sàn HNX");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhGiaoDichHNX))
             node.Nodes.Add(AccessPermission.VICS_HuyLenhGiaoDichHNX.ToString(), "Hủy lệnh giao dịch sàn HNX");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhUPCOM))
             node.Nodes.Add(AccessPermission.VICS_HuyLenhUPCOM.ToString(), "Hủy sửa lệnh UPCOM");
         if (Util.CheckAccess(AccessPermission.VICS_HuyLenhGiaoDichUPCOM))
             node.Nodes.Add(AccessPermission.VICS_HuyLenhGiaoDichUPCOM.ToString(), "Hủy sửa lệnh giao dịch UPCOM");
         if (Util.CheckAccess(AccessPermission.VICS_XemLenh))
            node.Nodes.Add(AccessPermission.VICS_XemLenh.ToString(), "Xem danh sách lệnh giao dịch");
         if (Util.CheckAccess(AccessPermission.VICS_XemLenhGiaoDich))
             node.Nodes.Add(AccessPermission.VICS_XemLenhGiaoDich.ToString(), "Xem danh sách lệnh giao dịch-Dành cho nhân viên môi giới");
         if (Util.CheckAccess(AccessPermission.VICS_DuyetLenh))
             node.Nodes.Add(AccessPermission.VICS_DuyetLenh.ToString(), "Duyệt lệnh");
         if (Util.CheckAccess(AccessPermission.VICS_DuyetLenhGiaoDich))
             node.Nodes.Add(AccessPermission.VICS_DuyetLenhGiaoDich.ToString(), "Duyệt lệnh giao dịch");

          if (Util.CheckAccess(AccessPermission.VICS_DangKyGiaoDichChoKhachHang))
            node.Nodes.Add(AccessPermission.VICS_DangKyGiaoDichChoKhachHang.ToString(), "Đăng ký giao dịch khách hàng");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "Báo cáo nhà đầu tư");
         if (Util.CheckAccess(AccessPermission.VICS_BaoCaoXacNhanGiaoDich))
            node.Nodes.Add(AccessPermission.VICS_BaoCaoXacNhanGiaoDich.ToString(), "Báo cáo xác nhận giao dịch");
         if (Util.CheckAccess(AccessPermission.VICS_LietKeGiaoDichTien))
            node.Nodes.Add(AccessPermission.VICS_LietKeGiaoDichTien.ToString(), "Liệt kê giao dịch tiền nhà đầu tư");
         if (Util.CheckAccess(AccessPermission.VICS_LietKeGiaoDichChungKhoan))
            node.Nodes.Add(AccessPermission.VICS_LietKeGiaoDichChungKhoan.ToString(), "Liệt kê giao dịch chứng khoán nhà đầu tư");
         if (Util.CheckAccess(AccessPermission.VICS_LietKeLichSuLenh))
            node.Nodes.Add(AccessPermission.VICS_LietKeLichSuLenh.ToString(), "Liệt kê lịch sử lệnh giao dịch");
         if (Util.CheckAccess(AccessPermission.VICS_BaoCaoTongHopTaiKhoan))
            node.Nodes.Add(AccessPermission.VICS_BaoCaoTongHopTaiKhoan.ToString(), "Báo cáo tổng hợp tài khoản");
         if (Util.CheckAccess(AccessPermission.VICS_BaoCaoLoLaiDuKien))
            node.Nodes.Add(AccessPermission.VICS_BaoCaoLoLaiDuKien.ToString(), "Báo cáo lỗ lãi dự kiến cho khách hàng");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "Báo dành cho đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Daily_SoLenhGiaoDich))
            node.Nodes.Add(AccessPermission.VICS_Daily_SoLenhGiaoDich.ToString(), "Xem sổ lệnh giao dịch của đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Daily_KetQuaKhopLenhTrongNgay))
            node.Nodes.Add(AccessPermission.VICS_Daily_KetQuaKhopLenhTrongNgay.ToString(), "Xem kết quả khớp lệnh trong ngày của đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Daily_BaoCaoGiaoDich))
            node.Nodes.Add(AccessPermission.VICS_Daily_BaoCaoGiaoDich.ToString(), "Xem kết quả khớp lệnh trong tháng/quý của đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Daily_BaoCaoPhiGiaoDich))
            node.Nodes.Add(AccessPermission.VICS_Daily_BaoCaoPhiGiaoDich.ToString(), "Báo cáo phí giao dịch của đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Daily_BaoCaoPhiGiaoDich))
             node.Nodes.Add(AccessPermission.VICS_Daily_BaoCaoGiaoDichTaiKhoan.ToString(), "Báo cáo giao dịch tài khoản");

         node = rootTreeNode.Nodes.Add(AccessPermission.None.ToString(), "Quản lý tín dụng");
         if (Util.CheckAccess(AccessPermission.VICS_DebitLimit_CapHanMucTinDungDauNgay))
            node.Nodes.Add(AccessPermission.VICS_DebitLimit_CapHanMucTinDungDauNgay.ToString(), "Cấp hạn mức tín dụng đầu ngày cho hội sở/chi nhánh/đại lý");
         if (Util.CheckAccess(AccessPermission.VICS_Debitlimit_XemHanMucTinDungDauNgay))
            node.Nodes.Add(AccessPermission.VICS_Debitlimit_XemHanMucTinDungDauNgay.ToString(), "Xem hạn mức tín dụng đầu ngày");
         if (Util.CheckAccess(AccessPermission.VICS_Debitlimit_CapHanMucTinDungChoKhachHang))
            node.Nodes.Add(AccessPermission.VICS_Debitlimit_CapHanMucTinDungChoKhachHang.ToString(), "Cấp hạn mức tín dụng cho khách hàng");
         if (Util.CheckAccess(AccessPermission.VICS_Debitlimit_XemHanMucTinDungChoKhachHang))
            node.Nodes.Add(AccessPermission.VICS_Debitlimit_XemHanMucTinDungChoKhachHang.ToString(), "Xem hạn mức tín dụng được cấp cho khách hàng");
      }
   }
}
