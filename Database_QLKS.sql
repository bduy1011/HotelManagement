CREATE DATABASE QL_KS
GO
USE QL_KS
GO


CREATE TABLE THONGKE (
	MaThongKe NVARCHAR(10) PRIMARY KEY,
    MaLoaiPhong NVARCHAR(10),
    NgayLap DATETIME,
	DoanhThu FLOAT,
    TiLe FLOAT,
)
GO

CREATE TABLE HOADON (
    MaHoaDon NVARCHAR(10) PRIMARY KEY,
    MaNhanVien NVARCHAR(10),
	MaKhachHang NVARCHAR(10),
    TriGia INTEGER,
    NgayLap DATETIME,
	TrangThai NVARCHAR(30),
)

GO
CREATE TABLE KHACHHANG (
    MaKhachHang NVARCHAR(10) PRIMARY KEY,
    TenKhachHang NVARCHAR(70),
    CCCD NVARCHAR(20),
    GioiTinh NVARCHAR(5),
    NgaySinh DATETIME,
    SoDienThoai NVARCHAR(10),
    LoaiKhachHang NVARCHAR(20),
	TrangThai NVARCHAR(30),
)

GO
CREATE TABLE NHANVIEN (
    MaNhanVien NVARCHAR(10) PRIMARY KEY,
    TenNhanVien NVARCHAR(50),
    CCCD NVARCHAR(12),
    GioiTinh NVARCHAR(5),
    SoDienThoai NVARCHAR(20),
	Email NVARCHAR(50),
    BoPhan NVARCHAR(20),
	ChucVu NVARCHAR(20),
	TinhTrang NVARCHAR(30),
    NgaySinh DATETIME,
    TenTaiKhoan NVARCHAR(20),
    MatKhau NVARCHAR(10),
)

GO
CREATE TABLE CT_HOADON (
	MaHoaDon NVARCHAR(10),
	MaPhieuDatPhong NVARCHAR(10),
	ThanhTien INTEGER,
	PRIMARY KEY (MaHoaDon, MaPhieuDatPhong)
)

GO
CREATE TABLE PHIEUDATPHONG (
	MaPhieuDatPhong NVARCHAR(10) PRIMARY KEY,
	MaPhieuSuDung NVARCHAR(10),
	MaPhong NVARCHAR(10),
	NgayDen DATETIME,
	NgayDi DATETIME,
	DonGia INTEGER,
	TienCoc INTEGER,
	SoNguoi SMALLINT,
	NgayLap DATETIME,
	TrangThai NVARCHAR(30),
)

GO
CREATE TABLE CT_PHIEUDATPHONG (
	MaPhieuDatPhong NVARCHAR(10),
	MaKhachHang NVARCHAR(10),
	PRIMARY KEY (MaPhieuDatPhong, MaKhachHang)
)

GO
CREATE TABLE PHIEUSUDUNG (
	MaPhieuSuDung NVARCHAR(10) PRIMARY KEY,
	TriGia INTEGER,
	NgayLap DATETIME,
	TrangThai NVARCHAR(30),
)

GO 
CREATE TABLE CT_PHIEUDICHVU (
	MaPhieuSuDung NVARCHAR(10),
	MaDichVu NVARCHAR(10),
	SoLuong SMALLINT,
	DonGia INTEGER,
	ThanhTien INTEGER,
	TrangThai NVARCHAR(30),
	PRIMARY KEY (MaPhieuSuDung, MaDichVu) 
) 

GO
CREATE TABLE DICHVU (
	MaDichVu NVARCHAR(10) PRIMARY KEY,
	TenDichVu NVARCHAR(50),
	DonViTinh NVARCHAR(20),
	DonGia INTEGER,
	TrangThai NVARCHAR(30),
)

GO
CREATE TABLE CT_PHIEUHANGHOA (
	MaPhieuSuDung NVARCHAR(10),
	MaHangHoa NVARCHAR(10),
	SoLuong SMALLINT,
	DonGia INTEGER,
	ThanhTien INTEGER,
	TrangThai NVARCHAR(30),
	PRIMARY KEY (MaPhieuSuDung, MaHangHoa) 
)

GO
CREATE TABLE PHIEUNHAPHANG (
	MaPhieuNhapHang NVARCHAR(10) PRIMARY KEY,
	MaNhanVien NVARCHAR(10),
	NgayLap DATETIME,
	TriGia INTEGER
)

GO 
CREATE TABLE CT_PHIEUNHAPHANG (
	MaPhieuNhapHang NVARCHAR(10),
	MaHangHoa NVARCHAR(10),
	SoLuong SMALLINT,
	DonGia INTEGER,
	ThanhTien INTEGER,
	PRIMARY KEY (MaPhieuNhapHang, MaHangHoa) 
)

GO 
CREATE TABLE HANGHOA (
	MaHangHoa NVARCHAR(10) PRIMARY KEY,
	TenHangHoa NVARCHAR(50),
	TonKho SMALLINT, 
	DonViTinh NVARCHAR(20),
	DonGiaNhap INTEGER,
	DonGiaBan INTEGER,
	TrangThai NVARCHAR(30),
)

GO 
CREATE TABLE PHONG (
	MaPhong NVARCHAR(10) PRIMARY KEY,
	MaLoaiPhong NVARCHAR(10),
	TrangThai NVARCHAR (30),
	GhiChu NVARCHAR(50),
)

GO 
CREATE TABLE LOAIPHONG (
	MaLoaiPhong NVARCHAR(10) PRIMARY KEY,
	TenLoaiPhong NVARCHAR(50),
	DonGia INTEGER,
	TrangThai NVARCHAR(30),
)

GO
ALTER TABLE HOADON ADD CONSTRAINT FK_HD_KH FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang)
ALTER TABLE HOADON ADD CONSTRAINT FK_HD_NV FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)
ALTER TABLE CT_HOADON ADD CONSTRAINT FK_CTHD_HD FOREIGN KEY (MaHoaDon) REFERENCES HOADON (MaHoaDon)
ALTER TABLE CT_HOADON ADD CONSTRAINT FK_CTHD_PDP FOREIGN KEY (MaPhieuDatPhong) REFERENCES PHIEUDATPHONG (MaPhieuDatPhong)
ALTER TABLE PHIEUDATPHONG ADD CONSTRAINT FK_PDP_P FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
ALTER TABLE PHIEUDATPHONG ADD CONSTRAINT FK_PDP_PSD FOREIGN KEY (MaPhieuSuDung) REFERENCES PHIEUSUDUNG(MaPhieuSuDung)
ALTER TABLE CT_PHIEUNHAPHANG ADD CONSTRAINT FK_CTPNH_HH FOREIGN KEY (MaHangHoa) REFERENCES HANGHOA(MaHangHoa)
ALTER TABLE CT_PHIEUNHAPHANG ADD CONSTRAINT FK_CTPNH_PNH FOREIGN KEY (MaPhieuNhapHang) REFERENCES PHIEUNHAPHANG(MaPhieuNhapHang)
ALTER TABLE PHONG ADD CONSTRAINT FK_P_LP FOREIGN KEY (MaLoaiPhong) REFERENCES LOAIPHONG (MaLoaiPhong)
ALTER TABLE PHIEUNHAPHANG ADD CONSTRAINT FK_PNH_NV FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)
ALTER TABLE CT_PHIEUHANGHOA ADD CONSTRAINT FK_CTPHH_PSD FOREIGN KEY (MaPhieuSuDung) REFERENCES PHIEUSUDUNG(MaPhieuSuDung)
ALTER TABLE CT_PHIEUHANGHOA ADD CONSTRAINT FK_CTPHH_HH FOREIGN KEY (MaHangHoa) REFERENCES HANGHOA(MaHangHoa)
ALTER TABLE CT_PHIEUDICHVU ADD CONSTRAINT FK_CTPDV_PSD FOREIGN KEY (MaPhieuSuDung) REFERENCES PHIEUSUDUNG(MaPhieuSuDung)
ALTER TABLE CT_PHIEUDICHVU ADD CONSTRAINT FK_CTPDV_DV FOREIGN KEY (MaDichVu) REFERENCES DICHVU(MaDichVu)
ALTER TABLE THONGKE ADD CONSTRAINT FK_TK_LP FOREIGN KEY (MaLoaiPhong) REFERENCES LOAIPHONG(MaLoaiPhong)
ALTER TABLE CT_PHIEUDATPHONG ADD CONSTRAINT FK_CTPDP_PDP FOREIGN KEY (MaPhieuDatPhong) REFERENCES PHIEUDATPHONG(MaPhieuDatPhong)
ALTER TABLE CT_PHIEUDATPHONG ADD CONSTRAINT FK_CTPDP_KH FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang)

DELETE PHONG
delete LOAIPHONG

GO
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP101', N'Phòng Đơn', 100000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP102', N'Phòng Đôi', 150000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP103', N'Phòng Gia Đình', 200000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP104', N'Phòng Superior', 280000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP105', N'Phòng VIP', 300000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP106', N'Phòng Cao Cấp', 400000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP107', N'Phòng Deluxe', 250000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP108', N'Phòng Studio', 180000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP109', N'Phòng Executive', 350000, N'Hoạt động');
INSERT INTO LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, TrangThai) VALUES ('LP110', N'Phòng Suite', 500000, N'Hoạt động');
GO
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P101', 'LP101', N'Trống', N'Phòng có cửa sổ thoáng mát');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P102', 'LP101', N'Trống', N'Phòng góc, view đẹp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P103', 'LP102', N'Trống', N'Phòng không cửa sổ, tiện nghi');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P104', 'LP102', N'Trống', N'Phòng ở tầng cao, view panoroma');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P105', 'LP103', N'Trống', N'Phòng có ban công, hướng biển');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P106', 'LP103', N'Trống', N'Phòng hướng biển, tiện nghi cao cấp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P107', 'LP104', N'Trống', N'Phòng thoáng mát, không gian rộng rãi');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P108', 'LP104', N'Trống', N'Phòng ở tầng trệt, tiện nghi đẳng cấp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P109', 'LP105', N'Trống', N'Phòng mới nâng cấp, không gian sang trọng');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P110', 'LP105', N'Trống', N'Phòng gần hồ bơi, view đẹp, tiện nghi hiện đại');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P111', 'LP106', N'Trống', N'Phòng có cửa sổ thoáng mát');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P112', 'LP106', N'Trống', N'Phòng góc, view đẹp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P113', 'LP107', N'Trống', N'Phòng không cửa sổ, tiện nghi');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P114', 'LP107', N'Trống', N'Phòng ở tầng cao, view panoroma');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P115', 'LP108', N'Trống', N'Phòng có ban công, hướng biển');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P116', 'LP108', N'Trống', N'Phòng hướng biển, tiện nghi cao cấp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P117', 'LP109', N'Trống', N'Phòng thoáng mát, không gian rộng rãi');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P118', 'LP109', N'Trống', N'Phòng ở tầng trệt, tiện nghi đẳng cấp');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P119', 'LP110', N'Trống', N'Phòng mới nâng cấp, không gian sang trọng');
INSERT INTO PHONG (MaPhong, MaLoaiPhong, TrangThai, GhiChu) VALUES ('P120', 'LP110', N'Trống', N'Phòng gần hồ bơi, view đẹp, tiện nghi hiện đại');
GO
INSERT [dbo].[DICHVU] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [TrangThai]) VALUES (N'DV101', N'Dịch vụ massage', N'Giờ', 150000, N'Ðang kinh doanh')
INSERT [dbo].[DICHVU] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [TrangThai]) VALUES (N'DV102', N'Dịch vụ tắm trắng', N'Lần', 500000, N'Ðang kinh doanh')
INSERT [dbo].[DICHVU] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [TrangThai]) VALUES (N'DV103', N'Đặt xe du lịch', N'Giờ', 500000, N'Ðang kinh doanh')
INSERT [dbo].[DICHVU] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [TrangThai]) VALUES (N'DV104', N'Dịch vụ bar', N'Lần', 500000, N'Ðang kinh doanh')
GO
INSERT [dbo].[HANGHOA] ([MaHangHoa], [TenHangHoa], [TonKho], [DonViTinh], [DonGiaNhap], [DonGiaBan], [TrangThai]) VALUES (N'HH101', N'Cocacola', 37, N'Chai', 7000, 10000, N'Đang kinh doanh')
INSERT [dbo].[HANGHOA] ([MaHangHoa], [TenHangHoa], [TonKho], [DonViTinh], [DonGiaNhap], [DonGiaBan], [TrangThai]) VALUES (N'HH102', N'Nước suối', 20, N'Chai', 3000, 5000, N'Đang kinh doanh')
INSERT [dbo].[HANGHOA] ([MaHangHoa], [TenHangHoa], [TonKho], [DonViTinh], [DonGiaNhap], [DonGiaBan], [TrangThai]) VALUES (N'HH103', N'Pepsi', 50, N'Chai', 7000, 10000, N'Đang kinh doanh')
INSERT [dbo].[HANGHOA] ([MaHangHoa], [TenHangHoa], [TonKho], [DonViTinh], [DonGiaNhap], [DonGiaBan], [TrangThai]) VALUES (N'HH104', N'Bánh ngọt', 20, N'Cái', 40000, 50000, N'Đang kinh doanh')
GO

INSERT INTO NHANVIEN VALUES (N'NV10000', N'Huỳnh Tiến Phát', N'030201086999', N'Nam', N'0362123456', N'2409huynhphat@gmail.com', N'Quản lý', N'Quản lý', N'Tại chức', '2000/9/24', N'user', N'123')
INSERT INTO NHANVIEN VALUES (N'NV10001', N'Trần Ngọc', N'030201086888', N'Nữ', N'0362123524', N'tranngoc2405@gmail.com', N'Lễ tân', N'Trưởng phòng', N'Tại chức', '2000/5/24', N'user1', N'pass1')
INSERT INTO NHANVIEN VALUES (N'NV10002', N'Trần Văn C', N'0369852147', N'Nam', N'0912345678', N'tranvanc1231@gmail.com', N'Lễ tân', N'Phó phòng', N'Tại chức', '1998/12/31', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10003', N'Nguyễn Văn A', N'0123456789', N'Nam', N'0909123456', N'nguyenvana11@gmail.com', N'Lễ tân', N'Lễ tân', N'Tại chức', '1990/1/1', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10004', N'Nguyễn Thị B', N'0987654321', N'Nữ', N'0909988776', N'nguyenthib5595@gmail.com', N'Lễ tân', N'Lễ tân', N'Tại chức', '1995/5/5', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10005', N'Nguyễn Văn G', N'010101123456', N'Nam', N'0362123123', N'tranvang1193@gmail.com', N'Lễ tân', N'Lễ tân', N'Tại chức', '1993/1/1', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10006', N'Pham Van C1', N'290929874532', N'Nam', N'0369258147', N'phamvanc1@gmail.com', N'Lễ tân', N'Lễ tân', N'Tại chức', '1990/9/29', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10007', N'Ngo Thi B1', N'280827539621', N'Nữ', N'0367539621', N'ngothib1@gmail.com', N'Lễ tân', N'Lễ tân', N'Tại chức', '1991/8/28', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10008', N'Trần Thị V', N'020202199999', N'Nữ', N'0362212121', N'nguyenthiv0220@gmail.com', N'Kế toán', N'Trưởng phòng', N'Tại chức', '1990/2/20', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10009', N'Lê Thị D', N'040410054321', N'Nữ', N'0362244444', N'lethid410@gmail.com', N'Kế toán', N'Phó phòng', N'Tại chức', '1995/4/10', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10010', N'Phạm Xuân C', N'030303012345', N'Nam', N'0362232323', N'phamxuanc0303@gmail.com', N'Kế toán', N'Nhân viên', N'Tại chức', '2000/3/3', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10011', N'Lương Văn E', N'050505056789', N'Nam', N'0364565656', N'luongvane55@gmail.com', N'Kế toán', N'Nhân viên', N'Tại chức', '1990/5/5', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10012', N'Nguyen Van Y', N'251225874123', N'Nam', N'0366258369', N'nguyenvany1225@gmail.com', N'Kinh doanh', N'Trưởng phòng', N'Tại chức', '1985/12/25', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10013', N'Hoang Thi Z', N'260126852147', N'Nữ', N'0367258147', N'hoangthiz126@gmail.com', N'Kinh doanh', N'Nhân viên', N'Tại chức', '1995/1/26', null, null)
INSERT INTO NHANVIEN VALUES (N'NV10014', N'Dang Van A1', N'271027123648', N'Nam', N'0367123648', N'nguyenvana1@gmail.com', N'Kinh doanh', N'Nhân viên', N'Đã nghỉ', '1992/10/27', null, null)

INSERT INTO KHACHHANG VALUES (N'KH10000', N'Huỳnh Thịnh Phát', N'030201086990', N'Nam', '2003/9/24', N'0362123457', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10001', N'Nguyễn Văn X', N'0123456780', N'Nam', '1990/1/1', N'0909123457', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10002', N'Nguyễn Thị O', N'0987654320', N'Nữ', '1995/5/5', N'0909988777', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10003', N'Trần Văn Y', N'0369852140', N'Nam', '1998/12/31', N'0912345677', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10004', N'Nguyễn Văn R', N'010101123450', N'Nam', '1980/1/1', N'0362123177', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10005', N'Trần Thị G', N'020202199990', N'Nữ', '1990/2/20', N'0362212177', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10006', N'Phạm Xuân I', N'030303012340', N'Nam', '2000/3/3', N'0362232377', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10007', N'Lê Thị L', N'040410054320', N'Nữ', '1995/4/10', N'0362244444', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10009', N'Lương Văn P', N'050505056780', N'Nam', '1970/5/5', N'0364565656', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10010', N'Nguyen Van W', N'251225874120', N'Nam', '1974/12/25', N'0366258369', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10011', N'Hoang Thi Q', N'260126852140', N'Nữ', '1972/1/26', N'0367258147',N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10012', N'Dang Van T', N'271027123640', N'Nam', '1978/10/27', N'0367123648', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10013', N'Ngo Thi E', N'280827539620', N'Nữ', '1975/8/28', N'0367539621', N'>= 15 tuổi', null)
INSERT INTO KHACHHANG VALUES (N'KH10014', N'Pham Van D', N'290929874530', N'Nam', '1972/9/29', N'0369258147', N'>= 15 tuổi', null)

INSERT INTO PHIEUSUDUNG (MaPhieuSuDung, TriGia, NgayLap, TrangThai)
VALUES ('PSD10001', 1330000, '2023-06-10', null)

INSERT INTO CT_PHIEUDICHVU (MaPhieuSuDung, MaDichVu, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10001', 'DV101', 2, 150000, 300000, null)

INSERT INTO CT_PHIEUDICHVU (MaPhieuSuDung, MaDichVu, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10001', 'DV102', 2, 500000, 1000000, null)

INSERT INTO CT_PHIEUHANGHOA (MaPhieuSuDung, MaHangHoa, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10001', 'HH101', 3, 10000, 30000, null)

INSERT INTO PHIEUDATPHONG (MaPhieuDatPhong, MaPhieuSuDung, MaPhong, NgayDen, NgayDi, DonGia, TienCoc, SoNguoi, NgayLap, TrangThai)
VALUES ('PDP10001', 'PSD10001', 'P101', '2023-06-05', '2023-06-10', 500000, 20000, 2, '2023-06-01', N'Được thuê')

INSERT INTO CT_PHIEUDATPHONG (MaPhieuDatPhong, MaKhachHang)
VALUES ('PDP10001', 'KH10001')
INSERT INTO CT_PHIEUDATPHONG (MaPhieuDatPhong, MaKhachHang)
VALUES ('PDP10001', 'KH10002')



INSERT INTO PHIEUSUDUNG (MaPhieuSuDung, TriGia, NgayLap, TrangThai)
VALUES ('PSD10002', 680000, '2023-06-10', null)

INSERT INTO CT_PHIEUDICHVU (MaPhieuSuDung, MaDichVu, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10002', 'DV101', 1, 150000, 150000, null)

INSERT INTO CT_PHIEUDICHVU (MaPhieuSuDung, MaDichVu, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10002', 'DV102', 1, 500000, 500000, null)

INSERT INTO CT_PHIEUHANGHOA (MaPhieuSuDung, MaHangHoa, SoLuong, DonGia, ThanhTien, TrangThai)
VALUES ('PSD10002', 'HH101', 3, 10000, 30000, null)

INSERT INTO PHIEUDATPHONG (MaPhieuDatPhong, MaPhieuSuDung, MaPhong, NgayDen, NgayDi, DonGia, TienCoc, SoNguoi, NgayLap, TrangThai)
VALUES ('PDP10002', 'PSD10002', 'P103', '2023-06-10', '2023-06-11', 700000, 20000, 2, '2023-06-10', null)

INSERT INTO CT_PHIEUDATPHONG (MaPhieuDatPhong, MaKhachHang)
VALUES ('PDP10002', 'KH10006')


