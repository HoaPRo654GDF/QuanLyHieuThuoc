using QuanLyHieuThuoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccess
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetInvoices()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_get_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SearchInvoices(string maHoaDon, DateTime? tuNgay, DateTime? denNgay, string trangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoaDon", string.IsNullOrEmpty(maHoaDon) ? (object)DBNull.Value : maHoaDon);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(trangThai) ? (object)DBNull.Value : trangThai);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetMedicines()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_get_Thuoc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetCustomers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaKhachHang, HoTen FROM KhachHang", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public string AddInvoice(string maHoaDon, string maNhanVien, string maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_add_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                cmd.Parameters.AddWithValue("@MaKhachHang", string.IsNullOrEmpty(maKhachHang) ? (object)DBNull.Value : maKhachHang);

                return cmd.ExecuteScalar().ToString();
            }
        }

        public string AddInvoiceDetail(ChiTietHoaDon chiTiet)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_add_ChiTietHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoaDon", chiTiet.MaHoaDon);
                cmd.Parameters.AddWithValue("@MaThuoc", chiTiet.MaThuoc);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", chiTiet.DonGia);

                return cmd.ExecuteScalar().ToString();
            }
        }

        public string UpdatePaymentStatus(string maHoaDon, string phuongThucThanhToan, decimal soTienThanhToan)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_update_TrangThaiThanhToan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThucThanhToan);
                cmd.Parameters.AddWithValue("@SoTienThanhToan", soTienThanhToan);

                return cmd.ExecuteScalar().ToString();
            }
        }

        public decimal GetInvoiceTotal(string maHoaDon)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TongTien FROM HoaDon WHERE MaHoaDon = @MaHoaDon", conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                return 0;
            }
        }
        public DataTable GetInvoiceById(string maHoaDon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                hd.MaHoaDon, 
                hd.NgayLap, 
                nv.HoTen AS TenNhanVien, 
                kh.HoTen AS TenKhachHang,
                hd.TongTien, 
                hd.TrangThai,
                hd.PhuongThucThanhToan,
                hd.NgayThanhToan
            FROM HoaDon hd
            LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
            LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
            WHERE hd.MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetInvoiceDetails(string maHoaDon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                ct.MaThuoc,
                t.TenThuoc,
                ct.SoLuong,
                ct.DonGia,
                ct.ThanhTien
            FROM ChiTietHoaDon ct
            INNER JOIN Thuoc t ON ct.MaThuoc = t.MaThuoc
            WHERE ct.MaHoaDon = @MaHoaDon
            ORDER BY t.TenThuoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetInvoiceCodes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaHoaDon FROM HoaDon ORDER BY NgayLap DESC", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
