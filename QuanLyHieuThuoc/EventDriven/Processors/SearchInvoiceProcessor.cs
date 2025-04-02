using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven.Events;

namespace QuanLyHieuThuoc.EventDriven.Processors
{
    public class SearchInvoiceProcessor : EventProcessor
    {
        private readonly Database _database;

        public SearchInvoiceProcessor(Database database)
        {
            _database = database;
        }

        public override void ProcessEvent(object eventData)
        {
            if (eventData is SearchInvoiceEvent searchEvent)
            {
                try
                {
                    // Thực hiện tìm kiếm hóa đơn
                    DataTable searchResult = _database.SearchInvoices(
                        searchEvent.MaHoaDon,
                        searchEvent.TuNgay,
                        searchEvent.DenNgay,
                        searchEvent.TrangThai);

                    // Gọi callback với kết quả
                    searchEvent.Callback?.Invoke(searchResult, "Success");
                }
                catch (Exception ex)
                {
                    // Tạo DataTable trống để báo lỗi
                    DataTable errorTable = new DataTable();
                    errorTable.Columns.Add("Error", typeof(string));
                    errorTable.Rows.Add(ex.Message);

                    // Gọi callback với thông báo lỗi
                    searchEvent.Callback?.Invoke(errorTable, ex.Message);
                }
            }
        }
    }
}
