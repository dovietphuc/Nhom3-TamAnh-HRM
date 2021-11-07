use master
GO
CREATE DATABASE db_QLNS_TamAnh
GO
use Quanlynhansu
GO
-- T?o b?ng --
-- 4 --
CREATE TABLE tblbophan(
	PK_BoPhan_iMaBoPhan INT IDENTITY(1,1) PRIMARY KEY,
	BoPhan_sTenBoPhan NVARCHAR(50),
	
);
-- 5 --
CREATE TABLE tblvitricongviec(
	PK_VCCV_iMaVCCV INT IDENTITY(1,1) PRIMARY KEY,
	VCCV_sTenVCCV int,
	VCCV_sMoTaVCCV datetime,
	
	FK_BoPhan_MaBP int not null,
	
	FOREIGN KEY (FK_BoPhan_MaBP) REFERENCES tblbophan(PK_BoPhan_iMaBoPhan),
);
-- 1 --
CREATE TABLE tblnhanvien(
	PK_iIdNhanVien INT IDENTITY(1,1) PRIMARY KEY,	
	NhanVien_sHoVaTen NVARCHAR(50) ,
	NhanVien_sNgaySinh DATETIME NOT NULL,
	NhanVien_sGioiTinh NVARCHAR(50),
	NhanVien_sDiaChi NVARCHAR(50),
	NhanVien_sDienThoai NVARCHAR(50),
	NhanVien_sBangCap NVARCHAR(50),
	NhanVien_sCMT NVARCHAR(50),
	
	
	
	FK_VCCV_iMaVCCV int NOT NULL,
	
	
	FOREIGN KEY (FK_VCCV_iMaVCCV) REFERENCES tblvitricongviec(PK_VCCV_iMaVCCV),
	
);
-- 2 --
CREATE TABLE tblhopdonglaodong(
	PK_HDLD_iMaHD INT IDENTITY(1,1) PRIMARY KEY,
	HDLD_iSoHopDong int,
	HDLD_dNgayKy datetime,
	HDLD_dNgayCoHieuLuc datetime,
	HDLD_dNgayHetHan datetime,	
	HDLD_iLuongCoBan int,
	HDLD_iLuongDongBH int,
	HDLD_sGhiChu NVARCHAR(50),
	HDLD_sTepDinhKem NVARCHAR(50),
	FK_NhanVien_iIDNhanVien int NOT NULL,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 3 --
CREATE TABLE tblchungchi(
	PK_ChungChi_iMaCC INT IDENTITY(1,1) PRIMARY KEY,
	ChungChi_sTenChungChi NVARCHAR(50),
	ChungChi_dNgayBD datetime,
	ChungChi_dNgayKT datetime,
	ChungChi_sTepDinhKem NVARCHAR(50),	
	FK_NhanVien_iIDNhanVien int not null,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 7 --
CREATE TABLE tblkehoachtuyendung(
	PK_KHTD_MaKHTD INT IDENTITY(1,1) PRIMARY KEY,
	KHTD_TieuDe NVARCHAR(50),
	KHTD_NoiDung NVARCHAR(50),
	KHTD_ThoiGianDuyetKH datetime,
	KHTD_LyDoLapKH NVARCHAR(20),
	KHTD_TrangThaiCuaKH NVARCHAR(50),
	KHTD_HinhThucUT  NVARCHAR(50),	
	FK_NhanVien_iIDNhanVien_Lap int not null,
	FK_NhanVien_iIDNhanVien_Duyet int not null,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien_Lap) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_NhanVien_iIDNhanVien_Duyet) REFERENCES tblnhanvien(PK_iIdNhanVien),
	
);

-- 6 --
CREATE TABLE tblhosotuyendung(
	PK_HSTD_iMaHSTD INT IDENTITY(1,1) PRIMARY KEY,
	HSTD_sHoTenUngVien NVARCHAR(50),
	HSTD_sEmailUngVien NVARCHAR(50),
	HSTD_DienThoai NVARCHAR(20),
	HSTD_sGioiTinh NVARCHAR(50),
	HSTD_dNgaySinh datetime,
	HSTD_sTrangThaiHS nvarchar(50),
	FK_NhanVien_iIDNhanVien int not null,
	FK_VTCV_iMaVTCV int not null,
	FK_KHTD_iMaKHTD int not null,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_VTCV_iMaVTCV) REFERENCES tblvitricongviec(PK_VCCV_iMaVCCV),
	FOREIGN KEY (FK_KHTD_iMaKHTD) REFERENCES tblkehoachtuyendung(PK_KHTD_MaKHTD),
);

-- 8 --
CREATE TABLE tblquyetdinhtuyendung(
	PK_QDTD_MaQDTD INT IDENTITY(1,1) PRIMARY KEY,
	QDTD_TieuDe NVARCHAR(50),
	QDTD_ThoiGianLap datetime,
	QDTD_ThoiGianDuyet datetime,
	QDTD_GhiChu NVARCHAR(50),
	QDTD_TrangThaiQD NVARCHAR(50),
	FK_NhanVien_iIDNhanVien_Lap int not null,
	FK_NhanVien_iIDNhanVien_Duyet int not null,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien_Lap) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_NhanVien_iIDNhanVien_Duyet) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 9 --
CREATE TABLE tblcongviec(
	PK_CongViec_iId INT IDENTITY(1,1) PRIMARY KEY,
	CongViec_sTenCV NVARCHAR(50),
	CongViec_sNoiDung NVARCHAR(50),
	CongViec_dThoiGianThemCongViec datetime,
	CongViec_dThoiGianBatDau datetime,
	CongViec_dThoiGianDuKien datetime,
	CongViec_TrangThai NVARCHAR(50),
	FK_NhanVien_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 10 --
CREATE TABLE tblbangchamcong(
	PK_ChamCong_iId INT IDENTITY(1,1) PRIMARY KEY,
	ChamCong_dTGVaoLamSang datetime,
	ChamCong_dTGNghiSang datetime,
	ChamCong_dTGLamChieu datetime,
	ChamCong_dTGNghiChieu datetime,
	ChamCong_dTGLamToi datetime,
	ChamCong_dTGNghiToi datetime,
	ChamCong_dNgayLam datetime,
	FK_NhanVien_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 11 --
CREATE TABLE tblkhenthuong_kyluat(
	PK_KTKL_iId INT IDENTITY(1,1) PRIMARY KEY,
	KTKL_sTieuDe NVARCHAR(50),
	KTKL_dThoiGianLap datetime,
	KTKL_dThoiGianDuyet datetime,
	KTKL_mKinhPhi money,
	KTKL_sGhiChu NVARCHAR(50),
);
-- 12 --
CREATE TABLE tbldonxinnghiphep(
	PK_NghiPhep_iId INT IDENTITY(1,1) PRIMARY KEY,
	NghiPhep_sLyDoNghi NVARCHAR(50),
	NghiPhep_dThoiGianTao datetime,
	NghiPhep_dThoiGianDuyet datetime,
	NghiPhep_sGhiChu nvarchar(50),
	NghiPhep_sTrangThai nvarchar(50),
	FK_NhanVien_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 13 --
CREATE TABLE tblbangluong(
	PK_Luong_iId INT IDENTITY(1,1) PRIMARY KEY,
	Luong_dThoiGianLap datetime,
	Luong_iNam int,
	Luong_iThang int,
	Luong_sPhanHoi nvarchar(50),
	Luong_mTongLuong money,
	FK_NhanVien_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
);
-- 15 --
CREATE TABLE tblquyen(
	PK_Quyen_iId INT IDENTITY(1,1) PRIMARY KEY,
	Quyen_sTen nvarchar(50),
);
-- 14 --
CREATE TABLE tbltaikhoan(
	PK_TaiKhoan_iId INT IDENTITY(1,1) PRIMARY KEY,
	TaiKhoan_sTen nvarchar(50),
	TaiKhoan_sMatKhau nvarchar(50),
	TaiKhoan_sTrangThai nvarchar(50),
	TaiKhoan_sThoiGianCap datetime,
	FK_NhanVien_iId int,
	FK_Quyen_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_Quyen_iId) REFERENCES tblquyen(PK_Quyen_iId),
);

-- 16 --
CREATE TABLE tblnhanvien_khenthuong_kyluat(
	PK_NhanVien_iId int not null,
	PK_KTKL_iId int not null,
	NVKTKL_NoiDung nvarchar(50),
	PRIMARY KEY (PK_NhanVien_iId, PK_KTKL_iId),
	FOREIGN KEY (PK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (PK_KTKL_iId) REFERENCES tblkhenthuong_kyluat(PK_KTKL_iId),
);

-- 17 --
CREATE TABLE tblkehoachtuyendung_vitricongviec(
	PK_KHTD_iId int not null,
	PK_VTCV_iId int not null,
	SoLuongTuyen int,
	PRIMARY KEY (PK_KHTD_iId, PK_VTCV_iId),
	FOREIGN KEY (PK_KHTD_iId) REFERENCES tblkehoachtuyendung(PK_KHTD_MaKHTD),
	FOREIGN KEY (PK_VTCV_iId) REFERENCES tblvitricongviec(PK_VCCV_iMaVCCV),
);
