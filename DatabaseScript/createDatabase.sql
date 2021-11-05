USE [master]
GO

/****** Object:  Database [Quanlynhansu]    Script Date: 11/5/2021 10:00:42 PM ******/
CREATE DATABASE [Quanlynhansu]

GO

USE [Quanlynhansu]
GO

/****** Object:  Table [dbo].[tblnhanvien]    Script Date: 11/5/2021 10:01:30 PM ******/
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

USE [Quanlynhansu]
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