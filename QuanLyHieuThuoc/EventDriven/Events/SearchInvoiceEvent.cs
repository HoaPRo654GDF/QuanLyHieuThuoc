using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Events
{
    public class SearchInvoiceEvent
    {
        public string MaHoaDon { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string TrangThai { get; set; }
        public Action<DataTable, string> Callback { get; set; }
    }
}
