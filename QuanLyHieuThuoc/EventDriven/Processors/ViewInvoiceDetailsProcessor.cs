using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven.Events;
using QuanLyHieuThuoc.EventDriven;
using QuanLyHieuThuoc.EventDriven;

namespace QuanLyHieuThuoc.EventDriven.Processors
{
    public class ViewInvoiceDetailsProcessor : EventProcessor
    {
        private readonly Database _database;

        public ViewInvoiceDetailsProcessor(Database database)
        {
            _database = database;
        }

        public override void ProcessEvent(object eventData)
        {
            if (eventData is ViewInvoiceDetailsEvent viewDetailsEvent)
            {
                try
                {
                    // Lấy thông tin hóa đơn
                    DataTable invoiceInfo = _database.GetInvoiceById(viewDetailsEvent.MaHoaDon);

                    // Lấy chi tiết hóa đơn
                    DataTable invoiceDetails = _database.GetInvoiceDetails(viewDetailsEvent.MaHoaDon);

                    // Gọi callback với kết quả
                    viewDetailsEvent.Callback?.Invoke(viewDetailsEvent.MaHoaDon, invoiceInfo, invoiceDetails);
                }
                catch (Exception ex)
                {
                    // Tạo DataTable trống để báo lỗi
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("Error", typeof(string));
                    emptyTable.Rows.Add(ex.Message);

                    // Gọi callback với thông báo lỗi
                    viewDetailsEvent.Callback?.Invoke(viewDetailsEvent.MaHoaDon, emptyTable, emptyTable);
                }
            }
        }
    }
}
