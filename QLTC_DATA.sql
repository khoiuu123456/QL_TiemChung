/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 12                       */
/* Created on:     10/23/2021 4:20:26 PM                        */
/*==============================================================*/
create Database QLTC
go
use QLTC
go
/*==============================================================*/
/* Table: CHITIETKHANGNGUYEN                                    */
/*==============================================================*/
create table CHITIETKHANGNGUYEN 
(
   MAKHANGNGUYEN            char(5)                        not null,
   MAVACCINE			    char(9)                        not null,
   constraint PK_CHITIETKHANGNGUYEN primary key clustered (MAKHANGNGUYEN, MAVACCINE)
);

/*==============================================================*/
/* Table: CHITIETPHIEUNHAP                                      */
/*==============================================================*/
create table CHITIETPHIEUNHAP 
(
   MAPHIEUNHAP          char(5)                        not null,
   SOLO                 char(10)                       not null,
   DVT                  nvarchar(20)                   null,
   SOLUONG              int                            null,
   LUONGNGUOITIEM       int                            null,
   CHITHINHIETDO        nvarchar(200)                  null,
   CHITHIDONGBANG       nvarchar(200)                  null,
   DUNGTICH             nvarchar(100)                  null,
   constraint PK_CHITIETPHIEUNHAP primary key clustered (SOLO, MAPHIEUNHAP)
);

/*==============================================================*/
/* Table: CHITIETPHIEUNHAPLAI                                   */
/*==============================================================*/
create table CHITIETPHIEUNHAPLAI 
(
   MAPNL                char(6)                        not null,
   SOLO                 char(10)                       not null,
   SOLUONGNHAPLAI       int                            null,
   SOLIEUNHAPLAI        int                            null,
   constraint PK_CHITIETPHIEUNHAPLAI primary key clustered (MAPNL, SOLO)
);

/*==============================================================*/
/* Table: CHITIETPHIEUXUAT                                      */
/*==============================================================*/
create table CHITIETPHIEUXUAT 
(
   MAPHIEUXUAT          char(5)                        not null,
   SOLO                 char(10)                       not null,
   SOLUONGXUAT          int                            null,
   SOLIEUXUAT           int                            null,
   constraint PK_CHITIETPHIEUXUAT primary key clustered (MAPHIEUXUAT, SOLO)
);

/*==============================================================*/
/* Table: CHITIETSOTIEMCHUNG                                    */
/*==============================================================*/
create table CHITIETSOTIEMCHUNG 
(
   MASO                 char(5)                        not null,
   SOLO                 char(10)                       not null,
   MAPHIEUXUAT          char(5)                        not null,
   SOMUITIEM            int                            null,
   MUITIEM              nvarchar(50)                   null,
   DIADIEM              nvarchar(100)                  null,
   NGAYTIEM             date                           null,
   GHICHU               nvarchar(200)                  null,
   constraint PK_CHITIETSOTIEMCHUNG primary key clustered (MASO, SOLO, MAPHIEUXUAT)
);
go
/*==============================================================*/
/* Table: CHUCVU                                                */
/*==============================================================*/
CREATE FUNCTION AUTO_IDCV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MACHUCVU) FROM CHUCVU) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MACHUCVU, 3)) FROM CHUCVU
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'CV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'CV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table CHUCVU 
(
   MACHUCVU             char(5)                        PRIMARY KEY CONSTRAINT IDCV DEFAULT DBO.AUTO_IDCV(),
   TENCHUCVU            nvarchar(50)                   null,
   --constraint PK_CHUCVU primary key clustered (MACHUCVU)
);
GO
/*==============================================================*/
/* Table: KEHOACHTIEM                                           */
/*==============================================================*/
CREATE FUNCTION AUTO_IDKHT()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MAKHT) FROM KEHOACHTIEM) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKHT, 3)) FROM KEHOACHTIEM
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KHT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KHT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table KEHOACHTIEM 
(
   MAKHT                char(6)                        PRIMARY KEY CONSTRAINT IDKHT DEFAULT DBO.AUTO_IDKHT(),
   NGAYBATDAU           date                           null,
   SONGAY               int                            null,
   NGAYKETTHUC          date                           null,
   MANV                 char(5)                        null,
   --constraint PK_KEHOACHTIEM primary key clustered (MAKHT)
);
go
/*==============================================================*/
/* Table: KHANGNGUYEN                                           */
/*==============================================================*/
CREATE FUNCTION AUTO_IDKN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAKHANGNGUYEN) FROM KHANGNGUYEN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKHANGNGUYEN, 3)) FROM KHANGNGUYEN
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table KHANGNGUYEN 
(
   MAKHANGNGUYEN        char(5)                        PRIMARY KEY CONSTRAINT IDKN DEFAULT DBO.AUTO_IDKN(),
   LOAIBENH             nvarchar(100)                  null,
   --constraint PK_KHANGNGUYEN primary key clustered (MAKHANGNGUYEN)
);
go
/*==============================================================*/
/* Table: LOVACCINE                                             */
/*==============================================================*/
create table LOVACCINE 
(
   SOLO                 char(10)                       not null,
   SOLUONGTON           int                            CHECK(SOLUONGTON>=0),
   SOLIEUTON            int                            CHECK(SOLIEUTON>=0),
   HANSUDUNG            date                           null,
   MAVACCINE            char(9)                        null,
   DVT                  nvarchar(50)                   null,
   LOAIVACCINE          nvarchar(50)                   null,
   constraint PK_LOVACCINE primary key clustered (SOLO)
);
go
/*==============================================================*/
/* Table: NGUOICHAMSOC                                          */
/*==============================================================*/
CREATE FUNCTION AUTO_IDNCS()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MANCS) FROM NGUOICHAMSOC) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANCS, 3)) FROM NGUOICHAMSOC
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NCS00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NCS0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table NGUOICHAMSOC 
(
   MANCS                char(6)                        PRIMARY KEY CONSTRAINT IDNCS DEFAULT DBO.AUTO_IDNCS(),
   HOTEN                nvarchar(50)                   null,
   NGAYSINH             date                           null,
   SDT                  char(13)                       null,
   CMND                 char(50)                       null,
   DIACHI               nvarchar(100)                  null,
   --constraint PK_NGUOICHAMSOC primary key clustered (MANCS)
);
go
/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
CREATE FUNCTION AUTO_IDNCC()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MANCC) FROM NHACUNGCAP) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANCC, 3)) FROM NHACUNGCAP
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NCC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NCC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table NHACUNGCAP 
(
   MANCC                char(6)                        PRIMARY KEY CONSTRAINT IDNCC DEFAULT DBO.AUTO_IDNCC(),
   TENNCC               nvarchar(50)                   null,
   --constraint PK_NHACUNGCAP primary key clustered (MANCC)
);
go
/*==============================================================*/
/* Table: NHANVIEN                                              */
/*==============================================================*/
CREATE FUNCTION AUTO_IDNV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MANV) FROM NHANVIEN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANV, 3)) FROM NHANVIEN
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table NHANVIEN 
(
   MANV                 char(5)                        PRIMARY KEY CONSTRAINT IDNV DEFAULT DBO.AUTO_IDNV(),
   TENNV                nvarchar(50)                   null,
   NGAYSINH             date                           null,
   GIOITINH             nvarchar(3)                    null,
   CMND                 char(50)                       null,
   SDT                  char(13)                       null,
   DIACHI               nvarchar(100)                  null,
   NGAYVAOLAM           date                           null,
   MACHUCVU             char(5)                        null,
   --constraint PK_NHANVIEN primary key clustered (MANV)
);
go
/*==============================================================*/
/* Table: PHIEUHEN                                              */
/*==============================================================*/
create table PHIEUHEN 
(
   MABE                 char(5)                        not null,
   MAKHT                char(6)                        not null,
   MAPHIEUHEN           char(5)                        not null,
   MUITIEM              nvarchar(50)                   null,
   NGAYBD               date                           null,
   NGAYKT               date                           null,
   TINHTRANG            int                            null,
   constraint PK_PHIEUHEN primary key clustered (MABE, MAKHT, MAPHIEUHEN)
);
go
/*==============================================================*/
/* Table: PHIEUNHAC                                             */
/*==============================================================*/
CREATE FUNCTION AUTO_IDPH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAPHIEUHEN) FROM PHIEUNHAC) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAPHIEUHEN, 3)) FROM PHIEUNHAC
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table PHIEUNHAC 
(
   MAPHIEUHEN           char(5)                        PRIMARY KEY CONSTRAINT IDPH DEFAULT DBO.AUTO_IDPH(),
   NGAYHEN              date                           null,
   BUOIHEN              nvarchar(20)                   null,
   --constraint PK_PHIEUNHAC primary key clustered (MAPHIEUHEN)
);
go
/*==============================================================*/
/* Table: PHIEUNHAP                                             */
/*==============================================================*/
CREATE FUNCTION AUTO_IDPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAPHIEUNHAP) FROM PHIEUNHAP) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAPHIEUNHAP, 3)) FROM PHIEUNHAP
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table PHIEUNHAP 
(
   MAPHIEUNHAP          char(5)                        PRIMARY KEY CONSTRAINT IDPN DEFAULT DBO.AUTO_IDPN(),
   MANV                 char(5)                        null,
   MANCC                char(6)                        not null,
   NGAYNHAP             date                           null,
   GHICHU               nvarchar(200)                  null,
   --constraint PK_PHIEUNHAP primary key clustered (MAPHIEUNHAP)
);
go
/*==============================================================*/
/* Table: PHIEUNHAPLAI                                          */
/*==============================================================*/
CREATE FUNCTION AUTO_IDPNL()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MAPNL) FROM PHIEUNHAPLAI) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAPNL, 3)) FROM PHIEUNHAPLAI
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PNL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PNL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table PHIEUNHAPLAI 
(
   MAPNL                char(6)                        PRIMARY KEY CONSTRAINT IDPNL DEFAULT DBO.AUTO_IDPNL(),
   MANV                 char(5)                        null,
   MAKHT                char(6)                        null,
   --constraint PK_PHIEUNHAPLAI primary key clustered (MAPNL)
);
go
/*==============================================================*/
/* Table: PHIEUXUAT                                             */
/*==============================================================*/
CREATE FUNCTION AUTO_IDPX()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAPHIEUXUAT) FROM PHIEUXUAT) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAPHIEUXUAT, 3)) FROM PHIEUXUAT
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PX00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PX0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table PHIEUXUAT 
(
   MAPHIEUXUAT          char(5)                        PRIMARY KEY CONSTRAINT IDPX DEFAULT DBO.AUTO_IDPX(),
   NGAYXUAT             date                           null,
   GHICHU               nvarchar(200)                  null,
   MANV                 char(5)                        null,
   MAKHT                char(6)                        null,
   --constraint PK_PHIEUXUAT primary key clustered (MAPHIEUXUAT)
);
go
/*==============================================================*/
/* Table: SOTIEMCHUNG                                           */
/*==============================================================*/
CREATE FUNCTION AUTO_IDST()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MASO) FROM SOTIEMCHUNG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MASO, 3)) FROM SOTIEMCHUNG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'ST00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'ST0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table SOTIEMCHUNG 
(
   MASO                 char(5)                        PRIMARY KEY CONSTRAINT IDST DEFAULT DBO.AUTO_IDST(),
   NGAYLAP              date                           null,
   MABE                 char(5)                        null,
   --constraint PK_SOTIEMCHUNG primary key clustered (MASO)
);
go
/*==============================================================*/
/* Table: TAIKHOAN                                              */
/*==============================================================*/
create table TAIKHOAN 
(
   TENTAIKHOAN          char(50)                       null,
   MATKHAU              char(50)                       null,
   TINHTRANG            int                            null,
   MANV                 char(5)                        null
);
go
/*==============================================================*/
/* Table: THONGTINBE                                            */
/*==============================================================*/
CREATE FUNCTION AUTO_IDBE()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MABE) FROM THONGTINBE) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MABE, 3)) FROM THONGTINBE
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'BE00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'BE0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table THONGTINBE 
(
   MABE                 char(5)                        PRIMARY KEY CONSTRAINT IDBE DEFAULT DBO.AUTO_IDBE(),
   TENBE                nvarchar(50)                   null,
   NGAYSINH             date                           null,
   GIOITINH             nvarchar(3)                    null,
   DIACHI               nvarchar(100)                  null,
   MANCS                char(6)                        null,
   --constraint PK_THONGTINBE primary key clustered (MABE)
);
go
/*==============================================================*/
/* Table: VACCINE                                               */
/*==============================================================*/
CREATE FUNCTION AUTO_IDVC()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAVACCINE) FROM VACCINE) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAVACCINE, 3)) FROM VACCINE
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'VC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'VC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table VACCINE 
(
   MAVACCINE            char(9)                        PRIMARY KEY CONSTRAINT IDVC DEFAULT DBO.AUTO_IDVC(),
   TENVACCINE           nvarchar(100)                  null,
   CHONGCHIDINH         nvarchar(1000)                 null,
   TACDUNGPHU           nvarchar(1000)                 null,
   CACHDUNG             nvarchar(1000)                 null,
   LIEULUONG            nvarchar(100)                  null,
   DUNGMOI              nvarchar(100)                  null,
   XUATXU               nvarchar(100)                  null,
   CHIDINHTIEM          nvarchar(1000)                 null,
   --constraint PK_VACCINE primary key clustered (MAVACCINE)
);

alter table CHITIETKHANGNGUYEN
   add constraint FK_CHITIETK_REFERENCE_VACCINE foreign key (MAVACCINE)
      references VACCINE (MAVACCINE);

alter table CHITIETKHANGNGUYEN
   add constraint FK_CHITIETK_REFERENCE_KHANGNGU foreign key (MAKHANGNGUYEN)
      references KHANGNGUYEN (MAKHANGNGUYEN);

alter table CHITIETPHIEUNHAP
   add constraint FK_CHITIETPN_REFERENCE_PHIEUNHA foreign key (MAPHIEUNHAP)
      references PHIEUNHAP (MAPHIEUNHAP);

alter table CHITIETPHIEUNHAP
   add constraint FK_CHITIETPN_REFERENCE_LOVACCIN foreign key (SOLO)
      references LOVACCINE (SOLO);

alter table CHITIETPHIEUNHAPLAI
   add constraint FK_CHITIETPNL_REFERENCE_LOVACCIN foreign key (SOLO)
      references LOVACCINE (SOLO);

alter table CHITIETPHIEUNHAPLAI
   add constraint FK_CHITIETPNL_REFERENCE_PHIEUNHA foreign key (MAPNL)
      references PHIEUNHAPLAI (MAPNL);

alter table CHITIETPHIEUXUAT
   add constraint FK_CHITIETPX_REFERENCE_PHIEUXUA foreign key (MAPHIEUXUAT)
      references PHIEUXUAT (MAPHIEUXUAT);

alter table CHITIETPHIEUXUAT
   add constraint FK_CHITIETPX_REFERENCE_LOVACCIN foreign key (SOLO)
      references LOVACCINE (SOLO);

alter table CHITIETSOTIEMCHUNG
   add constraint FK_CHITIETS_REFERENCE_SOTIEMCH foreign key (MASO)
      references SOTIEMCHUNG (MASO);

alter table CHITIETSOTIEMCHUNG
   add constraint FK_CHITIETS_REFERENCE_CHITIETP foreign key (MAPHIEUXUAT, SOLO)
      references CHITIETPHIEUXUAT (MAPHIEUXUAT, SOLO);

alter table KEHOACHTIEM
   add constraint FK_KEHOACHT_REFERENCE_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV);

alter table LOVACCINE
   add constraint FK_LOVACCIN_REFERENCE_VACCINE foreign key (MAVACCINE)
      references VACCINE (MAVACCINE);

alter table NHANVIEN
   add constraint FK_NHANVIEN_REFERENCE_CHUCVU foreign key (MACHUCVU)
      references CHUCVU (MACHUCVU);

alter table PHIEUHEN
   add constraint FK_PHIEUHEN_REFERENCE_KEHOACHT foreign key (MAKHT)
      references KEHOACHTIEM (MAKHT);

alter table PHIEUHEN
   add constraint FK_PHIEUHEN_REFERENCE_THONGTIN foreign key (MABE)
      references THONGTINBE (MABE);

alter table PHIEUHEN
   add constraint FK_PHIEUHEN_REFERENCE_PHIEUNHA foreign key (MAPHIEUHEN)
      references PHIEUNHAC (MAPHIEUHEN);

alter table PHIEUNHAP
   add constraint FK_PHIEUNHAP_REFERENCE_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV);

alter table PHIEUNHAP
   add constraint FK_PHIEUNHAP_REFERENCE_NHACUNGC foreign key (MANCC)
      references NHACUNGCAP (MANCC);

alter table PHIEUNHAPLAI
   add constraint FK_PHIEUNHAPL_REFERENCE_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV);

alter table PHIEUNHAPLAI
   add constraint FK_PHIEUNHAPL_REFERENCE_KEHOACHT foreign key (MAKHT)
      references KEHOACHTIEM (MAKHT);

alter table PHIEUXUAT
   add constraint FK_PHIEUXUA_REFERENCE_KEHOACHT foreign key (MAKHT)
      references KEHOACHTIEM (MAKHT);

alter table PHIEUXUAT
   add constraint FK_PHIEUXUA_REFERENCE_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV);

alter table SOTIEMCHUNG
   add constraint FK_SOTIEMCH_REFERENCE_THONGTIN foreign key (MABE)
      references THONGTINBE (MABE);

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_REFERENCE_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV);

alter table THONGTINBE
   add constraint FK_THONGTIN_REFERENCE_NGUOICHA foreign key (MANCS)
      references NGUOICHAMSOC (MANCS);

/*===============================INSERT INTO===============================*/

SET DATEFORMAT DMY
INSERT INTO NGUOICHAMSOC
VALUES
(DBO.AUTO_IDNCS(),N'Nguyễn Ngọc Quỳnh','12/10/1992','0818281193','0211114774',N'TÂN PHÚ'),
(DBO.AUTO_IDNCS(),N'Nguyễn Ngọc Tú','12/11/1991','0983919221','0221180331',N'TÂN BÌNH'),
(DBO.AUTO_IDNCS(),N'Nguyễn Như Ý','22/11/1982','0919293121','0321291121',N'TÂN PHÚ'),
(DBO.AUTO_IDNCS(),N'Văn Ngọc Trinh','12/03/1981','0987838181','0129891212',N'BÌNH TÂN'),
(DBO.AUTO_IDNCS(),N'Trần Tú Sương','1/12/1993','0982819921','0312193113',N'TÂN BÌNH');

INSERT INTO CHUCVU
VALUES
(DBO.AUTO_IDCV(),N'Trưởng trạm'),
(DBO.AUTO_IDCV(),N'Điều dưỡng'),
(DBO.AUTO_IDCV(),N'Điều dưỡng TC'),
(DBO.AUTO_IDCV(),N'Y sĩ đa khoa'),
(DBO.AUTO_IDCV(),N'Cử nhân điều dưỡng'),
(DBO.AUTO_IDCV(),N'Bác sĩ');

INSERT INTO THONGTINBE
VALUES
(DBO.AUTO_IDBE(),N'Nguyễn Tú Xuân','20/01/2021',N'Nam',N'Tân Bình','NCS001'),
(DBO.AUTO_IDBE(),N'Nguyễn Ngọc Gia Nghi','20/10/2020',N'Nữ',N'Tân Bình','NCS002'),
(DBO.AUTO_IDBE(),N'Vũ Ánh Ngọc','12/01/2020',N'Nữ',N'Tân Bình','NCS003'),
(DBO.AUTO_IDBE(),N'Trần Ánh Hồng','11/01/2021',N'Nữ',N'Bình Tân','NCS004'),
(DBO.AUTO_IDBE(),N'Nguyễn Thế Ngọc','11/11/2021',N'Nam',N'Tân Bình','NCS005'),
(DBO.AUTO_IDBE(),N'Nguyễn Văn Ngoan','21/08/2020',N'Nam',N'Tân Bình','NCS001');

INSERT INTO SOTIEMCHUNG
VALUES
(DBO.AUTO_IDST(),'20/04/2020','BE001'),
(DBO.AUTO_IDST(),'12/01/2019','BE002'),
(DBO.AUTO_IDST(),'11/02/2019','BE003'),
(DBO.AUTO_IDST(),'10/03/2020','BE004'),
(DBO.AUTO_IDST(),'23/05/2020','BE005'),
(DBO.AUTO_IDST(),'12/01/2019','BE006');


INSERT INTO NHANVIEN
VALUES
(DBO.AUTO_IDNV(),N'Nguyễn Thành An','12/02/1982',N'Nam','0291929987','0987879998',N'BÌNH TÂN','12/12/2012','CV001'),
(DBO.AUTO_IDNV(),N'Văn Ngọc Châu','12/02/1989',N'Nữ','0121929927','0987865454',N'BÌNH TÂN','12/02/2013','CV002'),
(DBO.AUTO_IDNV(),N'Nguyễn Hoàng Bảo Uyên','12/02/1988',N'Nữ','0291229911','0987897654',N'BÌNH TÂN','22/12/2013','CV003'),
(DBO.AUTO_IDNV(),N'Trần Ngọc Bình','12/02/1990',N'Nữ','0291923221','0909890987',N'BÌNH TÂN','12/12/2015','CV004'),
(DBO.AUTO_IDNV(),N'Nguyễn Trung Trực','12/02/1987',N'Nam','0391929124','0908765676',N'BÌNH TÂN','12/11/2014','CV005'),
(DBO.AUTO_IDNV(),N'Nguyễn Thanh Cao','12/02/1989',N'Nam','0241929135','0989897878',N'BÌNH TÂN','12/10/2016','CV006');

INSERT INTO NHACUNGCAP
VALUES
(DBO.AUTO_IDNCC(),N'Trung tâm y tế thành phố HCM'),
(DBO.AUTO_IDNCC(),N'Trung tâm y tế quận 2');

INSERT INTO KHANGNGUYEN
VALUES 
(DBO.AUTO_IDKN(),N'Bệnh bại liệt'),
(DBO.AUTO_IDKN(),N'Bệnh sởi'),
(DBO.AUTO_IDKN(),N'Bệnh quai bị'),
(DBO.AUTO_IDKN(),N'Bệnh rubella'),
(DBO.AUTO_IDKN(),N'Bệnh Bạch hầu'),
(DBO.AUTO_IDKN(),N'Bệnh uốn ván'),
(DBO.AUTO_IDKN(),N'Bệnh Ho gà'),
(DBO.AUTO_IDKN(),N'Bệnh viêm não Nhật Bản B'),
(DBO.AUTO_IDKN(),N'Bệnh tả'),
(DBO.AUTO_IDKN(),N'Bệnh thương hàn'),
(DBO.AUTO_IDKN(),N'Bệnh thủy đậu'),
(DBO.AUTO_IDKN(),N'Bệnh viêm ban AB');

INSERT INTO VACCINE
VALUES
('OPV-'+DBO.AUTO_IDVC(),N'OPV',N'Trẻ có sự suy giảm miễn dịch. Trong trường hợp trẻ bị tiêu chảy,vẫn cho uống nhưng phải uống nhắc lại 1 liều sau khi khỏi bệnh.'
,N'Sốt, quấy khóc sau khi uống.',N'Vaccin phải cho uống. Lịch cho uống có thể thay đổi, nhưng khoảng cách giữa 2 lần ít nhất phải 30 ngày.',N'0.1 ml',N'',N'Việt Nam',N'Trẻ em 2,3,4 tháng tuổi'),
('IPV-'+DBO.AUTO_IDVC(),N'IPV',N'Có bệnh trung bình hoặc nặng có hoặc không có sốt (tiêm vắc xin được trì hoãn lại cho đến khi khỏi bệnh). Phản ứng dị ứng trầm trọng (ví dụ, chứng quá mẫn) sau khi chủng ngừa trước đó hoặc cho một thành phần vắc xin.'
,N'Cảm giác rát bỏng hoặc đau nhói tại vùng tiêm. 
Ít gặp: sốt (từ 38oC trở lên, trên da có vùng ban đỏ nhưng thường nhẹ. 
Hiếm gặp: Phản ứng nhẹ tại chỗ, như ban đỏ, chai hoặc căng cứng, đau họng, khó chịu, sởi không điển hình, ngất, dễ bị kích thích. Viêm tuyến mang tai, buồn nôn, nôn và tiêu chảy. 
Các phản ứng quá mẫn trên da như nổi mày đay, co thắt khí phế quản có thể xảy ra ngay cả ở những người không có tiền sử dị ứng.
Đau cơ, khớp: thường thoáng qua và không bị mạn tính. Hay xảy ra ở phụ nữ ở lứa tuổi trưởng thành.'
,N'Tiêm bắp hoặc dưới da.',N'0.5 ml',N'',N'Việt Nam',N'Trẻ 5 tháng tuổi'),
('MMR-'+DBO.AUTO_IDVC(),N'MMR II',N'Đang có bệnh lý sốt hoặc viêm đường hô hấp.',N'Cảm giác rát bỏng hoặc đau nhói tại vùng tiêm. 
Ít gặp: sốt (từ 38oC trở lên, trên da có vùng ban đỏ nhưng thường nhẹ.
Hiếm gặp: Phản ứng nhẹ tại chỗ, như ban đỏ, chai hoặc căng cứng, đau họng, khó chịu, sởi không điển hình, ngất, dễ bị kích thích. Viêm tuyến mang tai, buồn nôn, nôn và tiêu chảy. 
Các phản ứng quá mẫn trên da như nổi mày đay, co thắt khí phế quản có thể xảy ra ngay cả ở những người không có tiền sử dị ứng. 
Đau cơ, khớp: thường thoáng qua và không bị mạn tính. Hay xảy ra ở phụ nữ ở lứa tuổi trưởng thành.'
,N'Tiêm dưới da, không được tiêm tĩnh mạch.',N'0.5 ml',N'',N'Việt Nam'
,N'Chỉ định để tạo miễn dịch phòng 3 bệnh: sởi, quai bị, rubella cho trẻ từ 12 tháng tuổi trở lên.'),
('DPT-'+DBO.AUTO_IDVC(),N'DPT',N'Nhiễm trùng cấp tính, sốt chưa rõ nguyên nhân.
 Các bệnh cấp tính và mãn tính đang trong thời kỳ tiến triển.
Có rối loạn thần kinh (co giật, viêm não và các bệnh về não)
Có bệnh tim mạch (bẩm sinh hay mắc phải)
Suy dinh dưỡng, nhiễm HIV. 
Giảm tiểu cầu hay có rối loạn đông máu.',N'Sốt: khoảng nửa số trẻ em sau tiêm DPT bị sốt vào buổi tối và có thể hết sau 1 ngày. 
Đau nhức: có khoảng một nửa số trẻ có thể bị đau, nổi ban, sưng tại chỗ tiêm.
Quấy khóc: có thể gặp trên 1% số trẻ, nguyên nhân thường do đau.
Những phản ứng nghiêm trọng hơn như: co giật và giảm trương lực cơ.',N'Tiêm bắp sâu ở mặt trước bắp đùi hoặc cơ delta của cánh tay'
,N'0.5 ml',N'',N'Việt Nam',N'Trẻ từ 2 tháng tuổi trở lên'),
('JEV-'+DBO.AUTO_IDVC(),N'Jevax',N'Người nhạy cảm với bất kỳ thành phần nào trong vắc xin.
 Người bị bệnh tim, gan, thận.
 Mệt mỏi, sốt cao hoặc nhiễm trùng tiến triển.'
 ,N'Thường gặp là sưng, đau và nổi ban đỏ tại nơi tiêm. Những phản ứng này thường sẽ tự hết sau 1-2 ngày.
Phản ứng toàn thân thường gặp như sốt, đau đầu, buồn nôn, chóng mặt có thể xảy ra với một số người.',N'Tiêm dưới da',N'0.5 ml',N'',N'Việt Nam'
,N'Chỉ định để phòng viêm não Nhật bản cho mọi
đối tượng và cho trẻ em từ 12 tháng tuổi trở lên. Trẻ em dưới 36 tháng: Dùng liều 0.5ml, Trẻ em ≥36 tháng và người lớn: Dùng liều 1ml.'),
('MOR-'+DBO.AUTO_IDVC(),N'MORCVA',N'Không dùng vắc xin mORCVAX cho trẻ đã quá mẫn cảm ở 
lần uống đầu tiên hoặc với bất kỳ thành phần nào của vắc xin.',N'Thường gặp: Sau khi uống vắc xin có thể có cảm giác buồn nôn hoặc nôn ói…
Hiếm gặp: Đau đầu, đau bụng, tiêu chảy, sốt, tuy nhiên những triệu chứng này sẽ tự khỏi mà không cần điều trị.'
,N'Chỉ dùng đường uống',N'1.5 ml',N'',N'Việt Nam',N'Chỉ định để phòng bệnh tả cho trẻ em trên 2 tuổi
và người lớn sống trong vùng dịch tả lưu hành.'),
('TYP-'+DBO.AUTO_IDVC(),N'TyPhoid',N'Không sử dụng Typhoid Vi cho trường hợp có tiền sử dị ứng với một trong các thành phần của vắc xin.',N'Phản ứng thường nhẹ, nhanh chóng biến mất. 
Khi tiêm vắc xin, tại chỗ tiêm có thể sưng đỏ. Có triệu chứng sốt nhẹ và sẽ hết sau 24h kể từ khi tiêm vắc xin.
Hiếm gặp phản ứng phản vệ.',N'Tiêm dưới da hoặc tiêm bắp',N'0.5 ml',N'',N'Việt Nam',N'Tạo miễn dịch chủ động phòng bệnh thương hàn
cho người lớn và trẻ em từ 2 tuổi trở lên. Cho người thường xuyên đi đến vùng có dịch bệnh thương hàn, người sống trong môi trường tập thể, người thường đi du lịch, người hay tiếp xúc với thực phẩm không đảm bảo vệ sinh an toàn thực phẩm hoặc di chuyển đến vùng vệ sinh kém…'),
('VAT-'+DBO.AUTO_IDVC(),N'VAT',N'Không tiêm cho người dị ứng, quá mẫn với bất kỳ thành phần nào của vắc xin. 
Không tiêm cho đối tượng có các biểu hiện dị ứng ở lần tiêm vắc xin trước.
Không dùng cho người có các dấu hiệu, triệu chứng thần kinh sau khi tiêm các liều trước đó.
Hoãn tiêm với các trường hợp sốt cao hoặc đang mắc các bệnh cấp tính.',N'Sốt; Đau, sưng, đỏ chỗ tiêm. Tuy nhiên các triệu chứng này thường nhẹ và tự mất đi
Sưng hạch bạch huyết gần nơi tiêm.
Có thể có các phản ứng toàn thân: Dị ứng; đau đầu; đổ mồ hôi; ớn lạnh; đau cơ, đau khớp.
Hiếm gặp: Rối loạn chức năng thần kinh cánh tay, bả vai.
Phải thông báo ngay cho bác sĩ những tác dụng không mong muốn gặp phải sau khi tiêm vắc xin.',N'Tiêm bắp sâu, 
Không tiêm tĩnh mạch trong bất cứ trường hợp nào. 
Lắc tan đều trước khi tiêm.',N'0.5 ml',N'',N'Việt Nam',N'Tạo miễn dịch chủ động phòng bệnh uốn ván cho người lớn và trẻ em. Đặc biệt là các đối tượng có nguy cơ cao như:
Phụ nữ có thai.
Công nhân vệ sinh môi trường, cống rãnh, nước thải.
Người thường xuyên làm việc tại chuồng trại chăn nuôi gia súc, gia cầm.
Người làm vườn, người làm việc ở các trang trại, nông trường.
Công nhân xây dựng các công trình.
Bộ đội và thanh niên xung phong.'),
('VAR-'+DBO.AUTO_IDVC(),N'VARIVAX',N'Mẫn cảm với bất kỳ thành phần nào của vắc xin, bao gồm cả: gelatin, neomycin.',N'Phản ứng tại chỗ tiêm: sưng, đau, khối tụ máu…
Có thể sốt cao.
Phát ban dạng thủy đậu tại vết tiêm hay toàn thân.',N'Tiêm dưới da',N'0.5 ml',N'',N'Việt Nam',N'Chỉ định phòng ngừa bệnh thủy đậu cho trẻ > 12'),
('TWI-'+DBO.AUTO_IDVC(),N'TWINRIX',N'Người nhạy cảm với bất kỳ thành phần nào trong vắc xin hoặc có biểu hiện quá mẫn với vắc xin phòng viêm gan B và viêm gan A đơn lẻ.'
,N'Phản ứng tại chỗ tiêm: sưng, đau, đỏ da.',N'Tiêm dưới da',N'0.5 ml',N'',N'Việt Nam',N'Phòng hai bệnh viêm gan A và viêm gan B ở trẻ em
trên 1 tuổi và người lớn chưa có miễn dịch.')

INSERT INTO CHITIETKHANGNGUYEN
VALUES
('KN001','OPV-VC001'),
('KN001','IPV-VC002'),
('KN002','MMR-VC003'),
('KN003','MMR-VC003'),
('KN004','MMR-VC003'),
('KN005','DPT-VC004'),
('KN006','DPT-VC004'),
('KN007','DPT-VC004'),
('KN008','JEV-VC005'),
('KN009','MOR-VC006'),
('KN010','TYP-VC007'),
('KN006','VAT-VC008'),
('KN011','VAR-VC009'),
('KN012','TWI-VC010');

INSERT INTO LOVACCINE
VALUES
('LV001',50,50,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều'),
('LV002',100,50,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều'),
('LV003',200,200,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều'),
('LV004',80,40,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều'),
('LV005',100,100,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều'),
('LV006',50,50,'20/11/2022','OPV-VC001',N'Lọ',N'Nhiều liều');

INSERT INTO KEHOACHTIEM
VALUES
(DBO.AUTO_IDKHT(),'24/11/2021',2,'26/10/2021','NV001'),
(DBO.AUTO_IDKHT(),'24/12/2021',2,'26/10/2021','NV001');

INSERT INTO PHIEUXUAT
VALUES
(DBO.AUTO_IDPX(),'24/11/2020','NONE','NV001','KHT001'),
(DBO.AUTO_IDPX(),'24/12/2020','NONE','NV001','KHT002'),
(DBO.AUTO_IDPX(),'24/11/2020','NONE','NV001','KHT001'),
(DBO.AUTO_IDPX(),'24/12/2020','NONE','NV001','KHT002');

INSERT INTO CHITIETPHIEUXUAT
VALUES
('PX001','LV001',40,20),
('PX001','LV005',20,20),
('PX002','LV006',20,10),
('PX002','LV002',40,20),
('PX003','LV004',10,10),
('PX004','LV003',10,5),
('PX004','LV002',40,20);

INSERT INTO CHITIETSOTIEMCHUNG
VALUES
('ST001','LV001','PX001',2,'MŨI 1',N'TÂN BÌNH','19/10/2021','NONE')

INSERT INTO PHIEUNHAPLAI
VALUES
(DBO.AUTO_IDPNL(),'NV001','KHT001')

INSERT INTO PHIEUNHAP
VALUES
(DBO.AUTO_IDPN(),'NV001','NCC001','20/11/2021','NONE'),
(DBO.AUTO_IDPN(),'NV001','NCC001','20/11/2021','NONE'),
(DBO.AUTO_IDPN(),'NV001','NCC001','20/11/2021','NONE'),
(DBO.AUTO_IDPN(),'NV001','NCC001','20/11/2021','NONE');

INSERT INTO CHITIETPHIEUNHAP
VALUES
('PN001','LV001',N'Lọ',200,100,'0','3','0.5 ml'),
('PN002','LV001',N'Lọ',100,100,'0','3','0.5 ml'),
('PN003','LV002',N'Lọ',80,40,'0','3','0.5 ml'),
('PN004','LV005',N'Lọ',100,100,'0','3','0.5 ml'),
('PN002','LV006',N'Lọ',100,50,'0','3','0.5 ml'),
('PN003','LV004',N'Lọ',50,50,'0','3','0.5 ml'),
('PN004','LV003',N'Lọ',40,40,'0','3','0.5 ml');

INSERT INTO KEHOACHTIEM
VALUES
(DBO.AUTO_IDKHT(),'12/11/2021',11,'','NV001')

INSERT INTO PHIEUNHAC
VALUES
(DBO.AUTO_IDPH(),'14/11/2021','SANG')

INSERT INTO PHIEUHEN
VALUES
('BE001','KHT001','PH001','BCG','20/11/2021','30/11/2021',0)

INSERT INTO TAIKHOAN
VALUES
('TRUONGTRAM','123',1,'NV001'),
('NV01','123',1,'NV002'),
('NV02','123',1,'NV003'),
('NV02','123',1,'NV004');

INSERT INTO CHITIETPHIEUNHAPLAI
VALUES
('PNL001','LV001',12,6)
GO
------------------------------------------------------------------------------CÁC THỦ TỤC------------------------------------------------------------------------------
--Thủ tục kiểm tra đăng nhập
CREATE PROC sp_KiemTraDangNhap @tenTaiKhoan NVARCHAR(100), @matKhau NVARCHAR(100), @Kq INT OUTPUT
AS
	BEGIN
	DECLARE @count INT
	SET @count = (SELECT COUNT(*) FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = @tenTaiKhoan AND MATKHAU = @matKhau AND TINHTRANG = 1)
	IF @count > 0
		SET @Kq = 1
	ELSE
		SET @Kq = 0
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA NGƯỜI CHĂM SÓC----------------------------------------------------------------------
--Thủ tục thêm người chăm sóc
CREATE PROC sp_ThemNguoiChamSoc @hoTen nvarchar(50),@ngaySinh date, @sdt char(13),@cmnd char(50),@diaChi nvarchar(100)
AS
	BEGIN
	SET DATEFORMAT DMY
	INSERT INTO dbo.NGUOICHAMSOC
	        ( MANCS ,
	          HOTEN ,
	          NGAYSINH ,
	          SDT ,
	          CMND ,
	          DIACHI
	        )
	VALUES  (DBO.AUTO_IDNCS(),
			@hoTen,
			@ngaySinh,
			@sdt,
			@cmnd,
			@diaChi
	        ) 
	END
GO
--Thủ tục kiểm tra người chăm sóc có bé nào hay không
CREATE PROC sp_KiemRangBuocNguoiChamSoc @mancs CHAR(6),@Kq INT OUTPUT
AS
	BEGIN
	DECLARE @count INT
	SET @count = (SELECT COUNT(*) FROM dbo.THONGTINBE WHERE MANCS = @mancs)
	IF @count > 0
		SET @Kq = 1
	ELSE
		SET @Kq = 0
	END
GO
--Thủ tục kiểm tra sự tồn tại người chăm sóc có hay không
CREATE PROC sp_KiemRangNguoiChamSocTonTai @mancs CHAR(6),@Kq INT OUTPUT
AS
	BEGIN
	DECLARE @count INT
	SET @count = (SELECT COUNT(*) FROM dbo.NGUOICHAMSOC WHERE MANCS = @mancs)
	IF @count > 0
		SET @Kq = 1
	ELSE
		SET @Kq = 0
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA BÉ----------------------------------------------------------------------   
--Thủ tục thêm thông tin bé
CREATE PROC sp_ThemThongTinBe @hotenBe nvarchar(50),@ngaySinh date, @gioiTinh nvarchar(3),@diaChibe nvarchar(100),@maNCS char(6)
AS
	BEGIN
	SET DATEFORMAT DMY
	INSERT INTO dbo.THONGTINBE
	        ( MABE ,
	          TENBE ,
	          NGAYSINH ,
	          GIOITINH ,
	          DIACHI ,
	          MANCS
	        )
	VALUES  (DBO.AUTO_IDBE(),
			@hotenBe,
			@ngaySinh,
			@gioiTinh,
			@diaChibe,
			@maNCS
	        ) 
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA LÔ VACCINE----------------------------------------------------------------------
--Thủ tục thêm người chăm sóc
CREATE PROC sp_ThemLoVaccine @SOLO CHAR(10), @SOLUONGTON int, @SOLIEUTON int, @HANSUDUNG date, @MAVACCINE char(9),@DVT nvarchar(100),@LOAIVACCINE nvarchar(100)
AS
	BEGIN
	SET DATEFORMAT DMY
	INSERT INTO dbo.LOVACCINE
	        ( SOLO ,
	          SOLUONGTON ,
	          SOLIEUTON ,
	          HANSUDUNG ,
	          MAVACCINE ,
	          DVT,
			  LOAIVACCINE
	        )
	VALUES  (@SOLO,
			@SOLUONGTON,
			@SOLIEUTON,
			@HANSUDUNG,
			@MAVACCINE,
			@DVT,
			@LOAIVACCINE
	        ) 
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA Kháng Nguyên----------------------------------------------------------------------   
--Thủ tục thêm thông tin khángnguyen
CREATE PROC sp_ThemKhangNguyen @LOAIBENH nvarchar(1000)
AS
	BEGIN
	INSERT INTO dbo.KHANGNGUYEN
	        ( MAKHANGNGUYEN ,
	          LOAIBENH 
	        )
	VALUES  (DBO.AUTO_IDKN(),
			@LOAIBENH
			) 
	END
GO
--Thủ tục thêm thông tin chi tiet khang nguyen
CREATE PROC sp_ThemCTKN @MAKHANGNGUYEN nvarchar(5),@MAVACCINE nvarchar(5)
AS
	BEGIN
	INSERT INTO dbo.CHITIETKHANGNGUYEN
	        ( MAKHANGNGUYEN ,
	          MAVACCINE 
	        )
	VALUES  (@MAKHANGNGUYEN,
			@MAVACCINE
			) 
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA Phiếu Nhập----------------------------------------------------------------------   
--Thủ tục thêm thông tin PhieuNhap
CREATE PROC sp_ThemPhieuNhap @MANV nvarchar(5), @MANCC nvarchar(6), @NGAYNHAP date, @GHICHU nvarchar(1000)
AS
	BEGIN
	INSERT INTO dbo.PHIEUNHAP
	        ( MAPHIEUNHAP ,
	          MANV,
			  MANCC,
			  NGAYNHAP,
			  GHICHU 
	        )
	VALUES  (DBO.AUTO_IDPN(),
			@MANV,
			@MANCC,
			@NGAYNHAP,
			@GHICHU
			) 
	END
GO
--Thủ tục thêm thông tin ChiTietPhieuNhap
CREATE PROC sp_ThemCTNhap @MAPHIEUNHAP nvarchar(5), @SOLO nvarchar(10), @DVT nvarchar(20), @SOLUONG INT, @LUONGNGUOITIEM INT, 
@CHITHINHIETDO nvarchar(200), @CHITHIDONGBANG nvarchar(200), @DUNGTICH nvarchar(100)
AS
	BEGIN
	INSERT INTO dbo.CHITIETPHIEUNHAP
	        ( MAPHIEUNHAP,
			  SOLO,
	          DVT,
			  SOLUONG,
			  LUONGNGUOITIEM,
			  CHITHINHIETDO,
			  CHITHIDONGBANG,
			  DUNGTICH
	        )
	VALUES  (@MAPHIEUNHAP,
			@SOLO,
			@DVT,
			@SOLUONG,
			@LUONGNGUOITIEM,
			@CHITHINHIETDO,
			@CHITHIDONGBANG,
			@DUNGTICH
			) 
	END
GO
--Trigger cập nhật số lượng hàng trong kho sau khi nhập hàng 
CREATE TRIGGER TRIGGER_NHAPHANG_SLUONG
ON CHITIETPHIEUNHAP
FOR INSERT
AS
	UPDATE LOVACCINE
	SET SOLUONGTON = LOVACCINE.SOLUONGTON + (SELECT SOLUONG FROM inserted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN inserted ON LOVACCINE.SOLO = inserted.SOLO
GO
CREATE TRIGGER TRIGGER_NHAPHANG_SLIEU
ON CHITIETPHIEUNHAP
FOR INSERT
AS
	UPDATE LOVACCINE
	SET SOLIEUTON = LOVACCINE.SOLIEUTON + (SELECT LUONGNGUOITIEM FROM inserted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN inserted ON LOVACCINE.SOLO = inserted.SOLO
GO
--Trigger cập nhật hàng trong kho sau khi xóa nhập hàng
CREATE TRIGGER trigger_TRAHANG_SLUONG
ON CHITIETPHIEUNHAP
FOR DELETE 
AS
	UPDATE LOVACCINE
	SET SOLUONGTON = LOVACCINE.SOLUONGTON - (SELECT SOLUONG FROM deleted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN deleted ON LOVACCINE.SOLO = deleted.SOLO
GO
CREATE TRIGGER trigger_TRAHANG_SLIEU
ON CHITIETPHIEUNHAP
FOR DELETE 
AS
	UPDATE LOVACCINE
	SET SOLIEUTON = LOVACCINE.SOLIEUTON - (SELECT LUONGNGUOITIEM FROM deleted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN deleted ON LOVACCINE.SOLO = deleted.SOLO
GO
----------------------------------------------------------------------THỦ TỤC CỦA NHÀ CUNG CẤP----------------------------------------------------------------------   
--Thủ tục thêm thông tin nhà cung cấp
CREATE PROC sp_ThemNCC @TENNCC nvarchar(50)
AS
	BEGIN
	SET DATEFORMAT DMY
	INSERT INTO dbo.NHACUNGCAP
	        ( MANCC ,
	          TENNCC 
	        )
	VALUES  (DBO.AUTO_IDNCC(),
			@TENNCC
	        ) 
	END
GO
----------------------------------------------------------------------THỦ TỤC CỦA Phiếu Xuất----------------------------------------------------------------------   
--Thủ tục thêm thông tin Phiếu xuất
CREATE PROC sp_ThemPhieuXuat @NGAYXUAT date, @GHICHU nvarchar(1000), @MANV nvarchar(5), @MAKHT nvarchar(6)
AS
	BEGIN
	INSERT INTO dbo.PHIEUXUAT
	        ( MAPHIEUXUAT,
			  NGAYXUAT,
	          GHICHU,
			  MANV,
			  MAKHT
	        )
	VALUES  (DBO.AUTO_IDPX(),
			@NGAYXUAT,
			@GHICHU,
			@MANV,
			@MAKHT
			) 
	END
GO
--Thủ tục thêm thông tin ChiTietPhieuXuat
CREATE PROC sp_ThemCTXuat @MAPHIEUXUAT nvarchar(5), @SOLO nvarchar(10), @SOLUONGXUAT INT, @SOLIEUXUAT INT
AS
	BEGIN
	INSERT INTO dbo.CHITIETPHIEUXUAT
	        ( MAPHIEUXUAT,
			  SOLO,
	          SOLUONGXUAT,
			  SOLIEUXUAT
	        )
	VALUES  (@MAPHIEUXUAT,
			@SOLO,
			@SOLUONGXUAT,
			@SOLIEUXUAT
			) 
	END
GO
--Trigger cập nhật số lượng hàng trong kho sau khi xuất hàng 
CREATE TRIGGER TRIGGER_XUATHANG_SLUONG
ON CHITIETPHIEUXUAT
FOR INSERT
AS
	UPDATE LOVACCINE
	SET SOLUONGTON = LOVACCINE.SOLUONGTON - (SELECT SOLUONGXUAT FROM inserted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN inserted ON LOVACCINE.SOLO = inserted.SOLO
GO
CREATE TRIGGER TRIGGER_XUATHANG_SLIEU
ON CHITIETPHIEUXUAT
FOR INSERT
AS
	UPDATE LOVACCINE
	SET SOLIEUTON = LOVACCINE.SOLIEUTON - (SELECT SOLIEUXUAT FROM inserted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN inserted ON LOVACCINE.SOLO = inserted.SOLO
GO
--Trigger cập nhật hàng trong kho sau khi xóa xuất hàng
CREATE TRIGGER trigger_TRAHANGXUAT_SLUONG
ON CHITIETPHIEUXUAT
FOR DELETE 
AS
	UPDATE LOVACCINE
	SET SOLUONGTON = LOVACCINE.SOLUONGTON + (SELECT SOLUONGXUAT FROM deleted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN deleted ON LOVACCINE.SOLO = deleted.SOLO
GO
CREATE TRIGGER trigger_TRAHANGXUAT_SLIEU
ON CHITIETPHIEUXUAT
FOR DELETE 
AS
	UPDATE LOVACCINE
	SET SOLIEUTON = LOVACCINE.SOLIEUTON + (SELECT SOLIEUXUAT FROM deleted WHERE SOLO = LOVACCINE.SOLO)
	FROM LOVACCINE 
	JOIN deleted ON LOVACCINE.SOLO = deleted.SOLO
GO
