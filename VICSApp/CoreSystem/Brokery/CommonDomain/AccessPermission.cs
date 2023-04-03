namespace CommonDomain
{
   public enum AccessPermission
   {
      // Lưu ý: Tất cả các key ở đây đều bắt đầu bằng VICS_
      None,
      VICS_PhanQuyen,
      VICS_PhanQuyen_CapNhat,
      VICS_QuanLyNhom,
      VICS_QuanLyNhom_CapNhat,
      VICS_QuanLyNguoiDung,
      VICS_QuanLyNguoiDung_CapNhat,
      VICS_ThietLapThamSo,
      VICS_CapNhatPhiDaiLy,

      VICS_VanTin,
      VICS_VanTinChiTiet,
      VICS_DatLenh,
      VICS_DatLenhUPCOM,
      VICS_HuyLenhHOSE,
      VICS_HuyLenhGiaoDichHOSE,
      VICS_HuyLenhHNX,
      VICS_HuyLenhGiaoDichHNX,
      VICS_HuyLenhUPCOM,
      VICS_HuyLenhGiaoDichUPCOM,
      VICS_XemLenh,
      VICS_XemLenhGiaoDich,
      VICS_DuyetLenh,
      VICS_DuyetLenhGiaoDich,
      VICS_DangKyGiaoDichChoKhachHang,

      VICS_BaoCaoXacNhanGiaoDich,
      VICS_LietKeGiaoDichTien,
      VICS_LietKeGiaoDichChungKhoan,
      VICS_LietKeLichSuLenh,
      VICS_BaoCaoTongHopTaiKhoan,
      VICS_BaoCaoLoLaiDuKien,

      VICS_Daily_SoLenhGiaoDich,
      VICS_Daily_KetQuaKhopLenhTrongNgay,
      VICS_Daily_BaoCaoGiaoDich,
      VICS_Daily_BaoCaoPhiGiaoDich,
      VICS_Daily_BaoCaoGiaoDichTaiKhoan,

      VICS_DebitLimit_CapHanMucTinDungDauNgay,
      VICS_Debitlimit_XemHanMucTinDungDauNgay,
      VICS_Debitlimit_CapHanMucTinDungChoKhachHang,
      VICS_Debitlimit_XemHanMucTinDungChoKhachHang,
   }
}
