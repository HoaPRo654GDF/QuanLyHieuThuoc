using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.Models
{
    public class Thuoc
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string MoTa { get; set; }
        public DateTime? HanSuDung { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
    }
}
