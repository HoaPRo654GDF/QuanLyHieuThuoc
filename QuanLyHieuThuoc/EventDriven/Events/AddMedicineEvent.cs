using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Events
{
    public class AddMedicineEvent
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; }
        public DateTime HanSuDung { get; set; }
        public int SoLuongTon { get; set; }
        public List<string> DanhSachMaNCC { get; set; } // Danh sách mã nhà cung cấp
        public Action<string, string> Callback { get; set; }
    }
}
