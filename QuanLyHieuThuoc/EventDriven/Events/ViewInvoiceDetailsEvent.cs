using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Events
{
    public class ViewInvoiceDetailsEvent
    {
        public string MaHoaDon { get; set; }
        public Action<string, DataTable, DataTable> Callback { get; set; }
    }
}
