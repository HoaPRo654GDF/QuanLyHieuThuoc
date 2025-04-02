CREATE DATABASE QuanLyHieuThuocLongChau;
GO

USE QuanLyHieuThuocLongChau;
GO

-- B?ng Thu?c
CREATE TABLE Thuoc (
    MaThuoc VARCHAR(10) PRIMARY KEY,
    TenThuoc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500),
    HanSuDung DATE,
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongTon INT NOT NULL,
    CONSTRAINT CK_SoLuongTon CHECK (SoLuongTon >= 0)
);
CREATE TABLE Thuoc_NhaCungCap (
    MaThuoc VARCHAR(10) NOT NULL,
    MaNhaCungCap VARCHAR(10) NOT NULL,
    PRIMARY KEY (MaThuoc, MaNhaCungCap),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

-- B?ng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    DiaChi NVARCHAR(200),
    NgaySinh DATE
);

-- B?ng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    ChucVu NVARCHAR(50)
);

-- B?ng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon VARCHAR(10) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNhanVien VARCHAR(10) NOT NULL,
    MaKhachHang VARCHAR(10),
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai NVARCHAR(20) DEFAULT N'ChuaThanhToan',
    PhuongThucThanhToan NVARCHAR(50),
    SoTienThanhToan DECIMAL(18,2),
    NgayThanhToan DATETIME,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

CREATE TABLE NhaCungCap (
    MaNhaCungCap VARCHAR(10) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    DiaChi NVARCHAR(200)
);
CREATE TABLE NhapHang (
    MaPhieuNhap VARCHAR(10) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNhanVien VARCHAR(10) NOT NULL,
    MaNhaCungCap VARCHAR(10) NOT NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);
CREATE TABLE ChiTietNhapHang (
    MaPhieuNhap VARCHAR(10),
    MaThuoc VARCHAR(10),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaPhieuNhap, MaThuoc),
    FOREIGN KEY (MaPhieuNhap) REFERENCES NhapHang(MaPhieuNhap),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);
CREATE TABLE Quyen (
    MaQuyen VARCHAR(10) PRIMARY KEY,
    TenQuyen NVARCHAR(50) NOT NULL
);

CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL,
    MaNhanVien VARCHAR(10) NOT NULL,
    MaQuyen VARCHAR(10) NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen)
);


-- B?ng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHoaDon VARCHAR(10),
    MaThuoc VARCHAR(10),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaHoaDon, MaThuoc),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc),
    CONSTRAINT CK_SoLuong CHECK (SoLuong > 0)
);

-- Stored Procedures
GO
CREATE PROCEDURE sp_get_HoaDon
AS
BEGIN
    SELECT 
        hd.MaHoaDon, 
        hd.NgayLap, 
        nv.HoTen AS TenNhanVien,
        kh.HoTen AS TenKhachHang,
        hd.TongTien, 
        hd.TrangThai,
        hd.PhuongThucThanhToan
    FROM HoaDon hd
    LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
    LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    ORDER BY hd.NgayLap DESC
END;
GO

CREATE PROCEDURE sp_search_HoaDon
    @MaHoaDon VARCHAR(10) = NULL,
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @TrangThai NVARCHAR(20) = NULL
AS
BEGIN
    SELECT 
        hd.MaHoaDon, 
        hd.NgayLap, 
        nv.HoTen AS TenNhanVien,
        kh.HoTen AS TenKhachHang,
        hd.TongTien, 
        hd.TrangThai,
        hd.PhuongThucThanhToan
    FROM HoaDon hd
    LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
    LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
    WHERE (@MaHoaDon IS NULL OR hd.MaHoaDon LIKE '%' + @MaHoaDon + '%')
      AND (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
      AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
      AND (@TrangThai IS NULL OR @TrangThai = N'T?t c?' OR hd.TrangThai = @TrangThai)
    ORDER BY hd.NgayLap DESC
END;
GO

CREATE PROCEDURE sp_get_Thuoc
AS
BEGIN
    SELECT 
        MaThuoc,
        TenThuoc,
        MoTa,
        HanSuDung,
        GiaBan,
        SoLuongTon
    FROM Thuoc
    ORDER BY TenThuoc
END;
GO

CREATE PROCEDURE sp_add_HoaDon
    @MaHoaDon VARCHAR(10),
    @MaNhanVien VARCHAR(10),
    @MaKhachHang VARCHAR(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            INSERT INTO HoaDon (MaHoaDon, NgayLap, MaNhanVien, MaKhachHang, TrangThai)
            VALUES (@MaHoaDon, GETDATE(), @MaNhanVien, @MaKhachHang, N'ChuaThanhToan')
        COMMIT TRANSACTION
        
        SELECT 'Success' AS Result
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SELECT ERROR_MESSAGE() AS Result
    END CATCH
END;
GO

CREATE PROCEDURE sp_add_ChiTietHoaDon
    @MaHoaDon VARCHAR(10),
    @MaThuoc VARCHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            -- Ki?m tra s? l??ng t?n c?a thu?c
            DECLARE @SoLuongTon INT
            SELECT @SoLuongTon = SoLuongTon FROM Thuoc WHERE MaThuoc = @MaThuoc
            
            IF @SoLuongTon < @SoLuong
            BEGIN
                ROLLBACK TRANSACTION
                SELECT N'S? l??ng thu?c không ??' AS Result
                RETURN
            END
            
            -- Ki?m tra thu?c ?ã có trong hóa ??n ch?a
            IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaThuoc = @MaThuoc)
            BEGIN
                -- C?p nh?t s? l??ng
                UPDATE ChiTietHoaDon 
                SET SoLuong = SoLuong + @SoLuong
                WHERE MaHoaDon = @MaHoaDon AND MaThuoc = @MaThuoc
            END
            ELSE
            BEGIN
                -- Thêm m?i chi ti?t hóa ??n
                INSERT INTO ChiTietHoaDon (MaHoaDon, MaThuoc, SoLuong, DonGia)
                VALUES (@MaHoaDon, @MaThuoc, @SoLuong, @DonGia)
            END
            
            -- C?p nh?t s? l??ng t?n c?a thu?c
            UPDATE Thuoc SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaThuoc = @MaThuoc
            
            -- C?p nh?t t?ng ti?n hóa ??n
            UPDATE HoaDon
            SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon)
            WHERE MaHoaDon = @MaHoaDon
            
        COMMIT TRANSACTION
        
        SELECT 'Success' AS Result
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SELECT ERROR_MESSAGE() AS Result
    END CATCH
END;
GO

CREATE PROCEDURE sp_update_TrangThaiThanhToan
    @MaHoaDon VARCHAR(10),
    @PhuongThucThanhToan NVARCHAR(50),
    @SoTienThanhToan DECIMAL(18,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            -- Ki?m tra hóa ??n có t?n t?i không
            IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHoaDon = @MaHoaDon)
            BEGIN
                ROLLBACK TRANSACTION
                SELECT N'Hóa ??n không t?n t?i' AS Result
                RETURN
            END
            
            -- Ki?m tra tr?ng thái hóa ??n
            DECLARE @TrangThai NVARCHAR(20)
            SELECT @TrangThai = TrangThai FROM HoaDon WHERE MaHoaDon = @MaHoaDon
            
            IF @TrangThai = N'DaThanhToan'
            BEGIN
                ROLLBACK TRANSACTION
                SELECT N'Hóa ??n ?ã ???c thanh toán' AS Result
                RETURN
            END
            
            -- Ki?m tra s? ti?n thanh toán
            DECLARE @TongTien DECIMAL(18,2)
            SELECT @TongTien = TongTien FROM HoaDon WHERE MaHoaDon = @MaHoaDon
            
            IF @SoTienThanhToan < @TongTien
            BEGIN
                ROLLBACK TRANSACTION
                SELECT N'S? ti?n thanh toán không ??' AS Result
                RETURN
            END
            
            -- C?p nh?t tr?ng thái thanh toán
            UPDATE HoaDon
            SET TrangThai = N'DaThanhToan',
                PhuongThucThanhToan = @PhuongThucThanhToan,
                SoTienThanhToan = @SoTienThanhToan,
                NgayThanhToan = GETDATE()
            WHERE MaHoaDon = @MaHoaDon
            
        COMMIT TRANSACTION
        
        SELECT 'Success' AS Result
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SELECT ERROR_MESSAGE() AS Result
    END CATCH
END;
GO
        
-- Thêm d? li?u vào b?ng Thuoc
INSERT INTO Thuoc (MaThuoc, TenThuoc, MoTa, HanSuDung, GiaBan, SoLuongTon)
VALUES
    ('T001', N'Paracetamol', N'Gi?m ?au, h? s?t', '2025-12-31', 15000, 100),
    ('T002', N'Amoxicillin', N'Kháng sinh ph? r?ng', '2026-06-15', 50000, 50),
    ('T003', N'Aspirin', N'Gi?m ?au, ch?ng viêm', '2025-09-20', 20000, 75);

-- Thêm d? li?u vào b?ng KhachHang
INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, DiaChi, NgaySinh)
VALUES
    ('KH001', N'Nguy?n V?n A', '0987654321', 'nguyenvana@gmail.com', N'123 ???ng ABC, TP.HCM', '1990-05-21'),
    ('KH002', N'Tr?n Th? B', '0912345678', 'tranthib@yahoo.com', N'456 ???ng DEF, Hà N?i', '1985-08-15');

-- Thêm d? li?u vào b?ng NhanVien
INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, ChucVu)
VALUES
    ('NV001', N'Lê Minh C', '1988-07-10', N'Nam', '0933333333', 'leminhc@hieuthuoc.com', N'Qu?n lý'),
    ('NV002', N'Hoàng Th? D', '1995-04-25', N'N?', '0977777777', 'hoangthid@hieuthuoc.com', N'Nhân viên bán hàng');

-- Thêm d? li?u vào b?ng HoaDon
INSERT INTO HoaDon (MaHoaDon, NgayLap, MaNhanVien, MaKhachHang, TongTien, TrangThai, PhuongThucThanhToan, SoTienThanhToan, NgayThanhToan)
VALUES
    ('HD001', GETDATE(), 'NV002', 'KH001', 0, N'ChuaThanhToan', NULL, NULL, NULL),
    ('HD002', GETDATE(), 'NV001', 'KH002', 0, N'ChuaThanhToan', NULL, NULL, NULL);

-- Thêm d? li?u vào b?ng ChiTietHoaDon
INSERT INTO ChiTietHoaDon (MaHoaDon, MaThuoc, SoLuong, DonGia)
VALUES
    ('HD001', 'T001', 2, 15000),
    ('HD001', 'T003', 1, 20000),
    ('HD002', 'T002', 3, 50000);

INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, SoDienThoai, Email, DiaChi)
VALUES 
    ('NCC001', N'Nhà thuốc Bình An', '0987654321', 'binhan@gmail.com', N'Hà Nội'),
    ('NCC002', N'Nhà thuốc Tâm Đức', '0977123456', 'tamduc@gmail.com', N'TP. Hồ Chí Minh'),
    ('NCC003', N'Nhà thuốc Minh Khang', '0909998888', 'minhkhang@gmail.com', N'Đà Nẵng');
INSERT INTO NhapHang (MaPhieuNhap, NgayNhap, MaNhanVien, MaNhaCungCap, TongTien)
VALUES 
    ('PN001', '2024-03-01', 'NV001', 'NCC001', 500000),
    ('PN002', '2024-03-02', 'NV002', 'NCC002', 750000);
    
INSERT INTO ChiTietNhapHang (MaPhieuNhap, MaThuoc, SoLuong, DonGia)
VALUES 
    ('PN001', 'T001', 10, 50000),
    ('PN001', 'T002', 5, 70000),
    ('PN002', 'T003', 15, 40000);
DELETE FROM ChiTietNhapHang;

INSERT INTO Thuoc_NhaCungCap (MaThuoc, MaNhaCungCap)
VALUES 
('T001', 'NCC001'),
('T002', 'NCC002'),
('T001', 'NCC002');

DELETE FROM Thuoc;
DELETE FROM NhaCungCap;
DELETE FROM NhapHang;
DELETE FROM Thuoc_NhaCungCap;
Select*from Thuoc;
Select*From NhaCungCap;
Select*From ChiTietHoaDon;
DELETE FROM ChiTietHoaDon;
INSERT INTO Quyen (MaQuyen, TenQuyen)
VALUES 
    ('Q001', N'Quản lý'),
    ('Q002', N'Nhân viên bán hàng');


INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien, MaQuyen)
VALUES 
    ('admin', 'admin123', 'NV001', 'Q001'),
    ('nhanvien1', 'nv123456', 'NV002', 'Q002');

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'ChiTietHoaDon';

Select*From NhanVien