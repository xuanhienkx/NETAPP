--53
--93
--108
--79
--63
--73
--75
--90
--66
--54
--57
--59
--68
--65
--98

--SELECT * FROM dbo.Customers WHERE CustomerId ='076C006228'
--SELECT * FROM dbo.Users WHERE UserId ='192'

DECLARE @groupId INT
SET @groupId = 1
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_PhanQuyen')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_PhanQuyen')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_PhanQuyen_CapNhat')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_PhanQuyen_CapNhat')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_QuanLyNhom')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_QuanLyNhom')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_QuanLyNhom_CapNhat')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_QuanLyNhom_CapNhat')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_QuanLyNguoiDung')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_QuanLyNguoiDung')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_QuanLyNguoiDung_CapNhat')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_QuanLyNguoiDung_CapNhat')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_CapNhatPhiDaiLy')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_CapNhatPhiDaiLy')
      
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_VanTin')      
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_VanTin')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_VanTinChiTiet')      
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_VanTinChiTiet')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_DatLenh')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_DatLenh')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhHOSE')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhHOSE')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhGiaoDichHOSE')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhGiaoDichHOSE')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhHNX')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhHNX')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhGiaoDichHNX')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhGiaoDichHNX')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhUPCOM')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhUPCOM')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_HuyLenhGiaoDichUPCOM')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_HuyLenhGiaoDichUPCOM')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_XemLenh')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_XemLenh')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_XemLenhGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_XemLenhGiaoDich')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_DuyetLenh')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_DuyetLenh')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_DuyetLenhGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_DuyetLenhGiaoDich')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_DangKyGiaoDichChoKhachHang')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_DangKyGiaoDichChoKhachHang')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_BaoCaoXacNhanGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_BaoCaoXacNhanGiaoDich')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_LietKeGiaoDichTien')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_LietKeGiaoDichTien')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_LietKeGiaoDichChungKhoan')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_LietKeGiaoDichChungKhoan')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_LietKeLichSuLenh')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_LietKeLichSuLenh')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_BaoCaoTongHopTaiKhoan')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_BaoCaoTongHopTaiKhoan')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_BaoCaoLoLaiDuKien')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_BaoCaoLoLaiDuKien')

IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_Daily_SoLenhGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_Daily_SoLenhGiaoDich')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_Daily_KetQuaKhopLenhTrongNgay')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_Daily_KetQuaKhopLenhTrongNgay')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_Daily_BaoCaoGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_Daily_BaoCaoGiaoDich')
IF NOT EXISTS(SELECT * FROM dbo.AgencyPermission WHERE GroupId = @groupId AND Permission = 'VICS_Daily_BaoCaoPhiGiaoDich')
INSERT INTO dbo.AgencyPermission( GroupId, Permission ) VALUES  ( @groupId, 'VICS_Daily_BaoCaoPhiGiaoDich')
          
