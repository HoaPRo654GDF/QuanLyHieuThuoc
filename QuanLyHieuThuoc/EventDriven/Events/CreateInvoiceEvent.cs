using QuanLyHieuThuoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Events
{
    public class CreateInvoiceEvent
    {
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public List<ChiTietHoaDon> DanhSachThuoc { get; set; }
        public Action<string, string> Callback { get; set; }
    }
}
