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

        public DataTable GetSuppliersForMedicine(string maThuoc)
        {
            // Giả sử bạn đang sử dụng ADO.NET để truy vấn cơ sở dữ liệu
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Suppliers WHERE MaThuoc = @MaThuoc";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaThuoc", maThuoc);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public string AddMedicine(string maThuoc, string tenThuoc, string moTa, decimal giaBan,
                          DateTime hanSuDung, int soLuongTon, List<string> danhSachMaNCC)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = new SqlConnection(_connectionString);
                conn.Open();

                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                transaction = conn.BeginTransaction();

                // Kiểm tra xem thuốc đã tồn tại chưa
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Thuoc WHERE MaThuoc = @MaThuoc", conn, transaction);
                checkCmd.Parameters.AddWithValue("@MaThuoc", maThuoc);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    transaction.Rollback();
                    return "Thuốc với mã này đã tồn tại";
                }

                // Thêm thuốc mới
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO Thuoc (MaThuoc, TenThuoc, MoTa, GiaBan, HanSuDung, SoLuongTon) " +
                    "VALUES (@MaThuoc, @TenThuoc, @MoTa, @GiaBan, @HanSuDung, @SoLuongTon)", conn, transaction);

                insertCmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                insertCmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                insertCmd.Parameters.AddWithValue("@MoTa", moTa ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@GiaBan", giaBan);
                insertCmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);
                insertCmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);

                int result = insertCmd.ExecuteNonQuery();

                if (result <= 0)
                {
                    transaction.Rollback();
                    return "Không thể thêm thuốc mới";
                }

                // Thêm liên kết với nhà cung cấp
                if (danhSachMaNCC != null && danhSachMaNCC.Count > 0)
                {
                    foreach (string maNCC in danhSachMaNCC)
                    {
                        SqlCommand linkCmd = new SqlCommand(
                            "INSERT INTO Thuoc_NhaCungCap (MaThuoc, MaNhaCungCap) VALUES (@MaThuoc, @MaNhaCungCap)",
                            conn, transaction);

                        linkCmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                        linkCmd.Parameters.AddWithValue("@MaNhaCungCap", maNCC);

                        linkCmd.ExecuteNonQuery();
                    }
                }

                // Commit transaction nếu tất cả thành công
                transaction.Commit();
                return "Success";
            }
            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi
                transaction?.Rollback();
                return "Error: " + ex.Message;
            }
            finally
            {
                // Đảm bảo đóng kết nối
                conn?.Close();
            }
        }

        // Thêm phương thức để lấy danh sách nhà cung cấp
        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, Email FROM NhaCungCap", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhà cung cấp: {ex.Message}");
            }
            return dt;
        }
    }
}
