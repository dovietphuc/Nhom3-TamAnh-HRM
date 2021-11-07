
CREATE DATABASE Quanlynhansu;

USE Quanlynhansu;

-- 1
CREATE TABLE tblbophan(
	PK_BoPhan_iMaBoPhan INT IDENTITY(1,1) PRIMARY KEY,
	BoPhan_sTenBoPhan NVARCHAR(50),
	
);
-- 2
CREATE TABLE tblvitricongviec(
	PK_VCCV_iMaVCCV INT IDENTITY(1,1) PRIMARY KEY,
	VCCV_sTenVCCV NVARCHAR(100), -- chuyen tu int sang nvarchar
	VCCV_sMoTaVCCV NVARCHAR(100), --chuyen tu datetime sang nvarchar
	
	FK_BoPhan_MaBP int not null,
	
	FOREIGN KEY (FK_BoPhan_MaBP) REFERENCES tblbophan(PK_BoPhan_iMaBoPhan),
);

-- 3
CREATE TABLE tblnhanvien(
	PK_iIdNhanVien INT IDENTITY(1,1) PRIMARY KEY,	
	NhanVien_sHoVaTen NVARCHAR(50) ,
	NhanVien_sNgaySinh DATE NOT NULL, -- chuyen tu datetime ve date
	NhanVien_sGioiTinh NVARCHAR(50),
	NhanVien_sDiaChi NVARCHAR(50),
	NhanVien_sDienThoai NVARCHAR(50),
	NhanVien_sBangCap NVARCHAR(50),
	NhanVien_sCMT NVARCHAR(50),
	
	FK_VCCV_iMaVCCV int NOT NULL,
	
	FOREIGN KEY (FK_VCCV_iMaVCCV) REFERENCES tblvitricongviec(PK_VCCV_iMaVCCV),
);

-- 4
CREATE TABLE tblquyen(
	PK_Quyen_iId INT IDENTITY(1,1) PRIMARY KEY,
	Quyen_sTen nvarchar(50),
);
--5
CREATE TABLE tbltaikhoan(
	PK_TaiKhoan_iId INT IDENTITY(1,1) PRIMARY KEY,
	TaiKhoan_sTen varchar(50), -- chuyen tu nvarchar ve varchar
	TaiKhoan_sMatKhau varchar(50), -- chuyen tu nvarchar ve varchar
	TaiKhoan_sTrangThai nvarchar(50),
	TaiKhoan_sThoiGianCap date, -- chuyen datetime thanh date
	FK_NhanVien_iId int,
	FK_Quyen_iId int,
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_Quyen_iId) REFERENCES tblquyen(PK_Quyen_iId),
);

-- Login
INSERT INTO tblbophan VALUES (N'Bộ phận 1');

INSERT INTO tblvitricongviec VALUES (N'Vị trí công việc 1', N'Mô tả 1', 1)

INSERT INTO tblnhanvien VALUES (N'Nguyễn Minh Cường', '1998-06-04', N'Nam', 'TT-HN', '0961846350', 'Bằng cấp', '0123456789', 1);
INSERT INTO tblnhanvien VALUES (N'Nguyễn Trung Kiên', '2000-09-03', N'Nam', 'TT-HN', '01673984434', 'Bằng cấp', '987654321', 1);

INSERT INTO tblquyen VALUES (N'Nhân viên'), (N'Giám đốc');

INSERT INTO tbltaikhoan VALUES (N'mcvp9x', '123', 'Active', '2021-11-07', 1, 1)

-- 11 --
CREATE TABLE tblkhenthuong_kyluat(
	PK_KTKL_iId INT IDENTITY(1,1) PRIMARY KEY,
	KTKL_sTieuDe NVARCHAR(50),
	KTKL_dThoiGianLap date, -- chuyen datetime thanh date
	KTKL_dThoiGianDuyet date, -- chuyen datetime thanh date
	KTKL_iKinhPhi INT,-- chuyen money thanh int, KTKL_mKinhPhi thanh KTKL_iKinhPhi
	KTKL_sGhiChu NVARCHAR(50),
);

-- 12 --
CREATE TABLE tblnhanvien_khenthuong_kyluat(
	PK_NV_KTKL_iId INT IDENTITY(1,1) PRIMARY KEY,
	FK_NhanVien_iId int not null, -- thay PK_NhanVien_iId thanh FK_NhanVien_iId
	FK_KTKL_iId int not null, -- thay PK_KTKL_iId thanh FK_KTKL_iId
	NVKTKL_sNoiDung NVARCHAR(50), -- thay NVKTKL_NoiDung thanh NVKTKL_sNoiDung
	FOREIGN KEY (FK_NhanVien_iId) REFERENCES tblnhanvien(PK_iIdNhanVien),
	FOREIGN KEY (FK_KTKL_iId) REFERENCES tblkhenthuong_kyluat(PK_KTKL_iId),
);

------------------

CREATE TABLE tblchungchi(
	PK_ChungChi_iMaCC INT IDENTITY(1,1) PRIMARY KEY,
	ChungChi_sTenChungChi NVARCHAR(50),
	ChungChi_dNgayBD date,  -- chuyen datetime thanh date
	ChungChi_dNgayKT date,  -- chuyen datetime thanh date
	ChungChi_sTepDinhKem NVARCHAR(50),	
	FK_NhanVien_iIDNhanVien int not null,
	FOREIGN KEY (FK_NhanVien_iIDNhanVien) REFERENCES tblnhanvien(PK_iIdNhanVien),
);