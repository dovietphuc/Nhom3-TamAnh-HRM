USE [master]
GO

/****** Object:  Database [Quanlynhansu]    Script Date: 11/5/2021 10:00:42 PM ******/
CREATE DATABASE [Quanlynhansu]

GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tblbophan]    Script Date: 11/6/2021 1:17:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblbophan](
	[PK_BoPhan_iMaBoPhan] [int] IDENTITY(1,1) NOT NULL,
	[BoPhan_sTenBoPhan] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblbophan] PRIMARY KEY CLUSTERED 
(
	[PK_BoPhan_iMaBoPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Quanlynhansu]
GO

INSERT INTO [dbo].[tblbophan] ([BoPhan_sTenBoPhan]) VALUES (N'Bộ phận kế toán')
INSERT INTO [dbo].[tblbophan] ([BoPhan_sTenBoPhan]) VALUES (N'Bộ phận tài chính')
INSERT INTO [dbo].[tblbophan] ([BoPhan_sTenBoPhan]) VALUES (N'Bộ phận marketing')

GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tblvitricongviec]    Script Date: 11/6/2021 1:18:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblvitricongviec](
	[PK_VCCV_iMaVCCV] [int] IDENTITY(1,1) NOT NULL,
	[VCCV_sTenVCCV] [nvarchar](50) NULL,
	[VCCV_sMoTaVCCV] [nvarchar](50) NULL,
	[FK_BoPhan_MaBP] [int] NOT NULL,
 CONSTRAINT [PK_tblvitricongviec] PRIMARY KEY CLUSTERED 
(
	[PK_VCCV_iMaVCCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblvitricongviec]  WITH CHECK ADD  CONSTRAINT [FK_tblvitricongviec_tblbophan] FOREIGN KEY([FK_BoPhan_MaBP])
REFERENCES [dbo].[tblbophan] ([PK_BoPhan_iMaBoPhan])
GO

ALTER TABLE [dbo].[tblvitricongviec] CHECK CONSTRAINT [FK_tblvitricongviec_tblbophan]
GO

USE [Quanlynhansu]
GO

INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Trưởng phòng' ,N'Trưởng phòng bộ phận kế toán',1)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Phó phòng' ,N'Phó phòng bộ phận kế toán',1)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Nhân viên' ,N'Nhân viên bộ phận kế toán',1)

INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Trưởng phòng' ,N'Trưởng phòng bộ phận tài chính',2)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Phó phòng' ,N'Phó phòng bộ phận tài chính',2)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Nhân viên' ,N'Nhân viên bộ phận tài chính',2)

INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Trưởng phòng' ,N'Trưởng phòng bộ phận marketing',3)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Phó phòng' ,N'Phó phòng bộ phận marketing',3)
INSERT INTO [dbo].[tblvitricongviec] ([VCCV_sTenVCCV] ,[VCCV_sMoTaVCCV] ,[FK_BoPhan_MaBP]) 
VALUES (N'Nhân viên' ,N'Nhân viên bộ phận marketing',3)

GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tblnhanvien]    Script Date: 11/6/2021 1:18:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblnhanvien](
	[PK_iIdNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[NhanVien_sHoVaTen] [nvarchar](50) NULL,
	[NhanVien_sNgaySinh] [datetime] NULL,
	[NhanVien_sGioiTinh] [bit] NULL,
	[NhanVien_sDiaChi] [nvarchar](50) NULL,
	[NhanVien_sDienThoai] [nvarchar](50) NULL,
	[NhanVien_sBangCap] [nvarchar](50) NULL,
	[NhanVien_sCMT] [nvarchar](50) NULL,
	[FK_VCCV_iMaVCCV] [int] NOT NULL,
 CONSTRAINT [PK_tblnhanvien] PRIMARY KEY CLUSTERED 
(
	[PK_iIdNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblnhanvien]  WITH CHECK ADD  CONSTRAINT [FK_tblnhanvien_tblvitricongviec] FOREIGN KEY([FK_VCCV_iMaVCCV])
REFERENCES [dbo].[tblvitricongviec] ([PK_VCCV_iMaVCCV])
GO

ALTER TABLE [dbo].[tblnhanvien] CHECK CONSTRAINT [FK_tblnhanvien_tblvitricongviec]
GO



/****** Object:  Table [dbo].[tblhopdonglaodong]    Script Date: 11/5/2021 10:01:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblhopdonglaodong](
	[PK_HDLD_iMaHD] [int] IDENTITY(1,1) NOT NULL,
	[HDLD_iSoHopDong] [int] NULL,
	[HDLD_dNgayKy] [datetime] NULL,
	[HDLD_dNgayCoHieuLuc] [datetime] NULL,
	[HDLD_dNgayHetHan] [datetime] NULL,
	[HDLD_iLuongCoBan] [int] NULL,
	[HDLD_iLuongDongBH] [int] NULL,
	[HDLD_sGhiChu] [nvarchar](50) NULL,
	[HDLD_sTepDinhKem] [nvarchar](50) NULL,
	[FK_NhanVien_iIDNhanVien] [int] NOT NULL,
 CONSTRAINT [PK_tblhopdonglaodong] PRIMARY KEY CLUSTERED 
(
	[PK_HDLD_iMaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblhopdonglaodong]  WITH CHECK ADD  CONSTRAINT [FK_tblhopdonglaodong_tblnhanvien] FOREIGN KEY([FK_NhanVien_iIDNhanVien])
REFERENCES [dbo].[tblnhanvien] ([PK_iIdNhanVien])
GO

ALTER TABLE [dbo].[tblhopdonglaodong] CHECK CONSTRAINT [FK_tblhopdonglaodong_tblnhanvien]
GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tbl_chungchi]    Script Date: 11/5/2021 10:02:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_chungchi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[sTenchungchi] [nvarchar](100) NULL,
	[dNgaybatdau] [char](10) NULL,
	[dNgayketthuc] [char](10) NULL,
	[sLinkdinhkem] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tbl_khenthuongkyluat]    Script Date: 11/5/2021 10:02:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_khenthuongkyluat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[sTieude] [nvarchar](200) NULL,
	[dThoigianlap] [char](10) NULL,
	[dThoigianduyet] [char](10) NULL,
	[iKinhphi] [int] NULL,
	[sGhichu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tblquyetdinhchuyen_vtcongviec]    Script Date: 11/6/2021 11:02:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblquyetdinhchuyen_vtcongviec](
	[PK_QĐCVTCV_iId] [int] IDENTITY(1,1) NOT NULL,
	[QĐCVTCV_dThoigianlap] [datetime] NULL,
	[QĐCVTCV_dThoigianduyet] [datetime] NULL,
	[FK_NhanVien_iMaNhanVien] [int] NOT NULL,
	[FK_NhanVien_iMaNhanVienDuyet] [int] NOT NULL,
	[FK_VTCV_iIdcu] [int] NOT NULL,
	[FK_VTCV_iIdmoi] [int] NOT NULL,
	[QĐCVTCV_sLyDo] [nvarchar](200) NULL,
	[QĐCVTCV_dTrangThai] [int] NULL,
 CONSTRAINT [PK_tblquyetdinhchuyen_vtcongviec] PRIMARY KEY CLUSTERED 
(
	[PK_QĐCVTCV_iId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec]  WITH CHECK ADD  CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblnhanvien_lap] FOREIGN KEY([FK_NhanVien_iMaNhanVien])
REFERENCES [dbo].[tblnhanvien] ([PK_iIdNhanVien])
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec] CHECK CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblnhanvien_lap]
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec]  WITH CHECK ADD  CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblvitricongviec] FOREIGN KEY([FK_VTCV_iIdcu])
REFERENCES [dbo].[tblvitricongviec] ([PK_VCCV_iMaVCCV])
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec] CHECK CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblvitricongviec]
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec]  WITH CHECK ADD  CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblvitricongviec1] FOREIGN KEY([FK_VTCV_iIdmoi])
REFERENCES [dbo].[tblvitricongviec] ([PK_VCCV_iMaVCCV])
GO

ALTER TABLE [dbo].[tblquyetdinhchuyen_vtcongviec] CHECK CONSTRAINT [FK_tblquyetdinhchuyen_vtcongviec_tblvitricongviec1]
GO

