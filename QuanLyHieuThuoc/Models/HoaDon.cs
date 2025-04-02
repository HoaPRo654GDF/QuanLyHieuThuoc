using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.Models
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }

        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string PhuongThucThanhToan { get; set; }
    }
}
