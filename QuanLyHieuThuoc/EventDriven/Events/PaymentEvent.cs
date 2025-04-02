using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Events
{
    public class PaymentEvent
    {
        public string MaHoaDon { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public Action<string, string> Callback { get; set; }
    }
}
