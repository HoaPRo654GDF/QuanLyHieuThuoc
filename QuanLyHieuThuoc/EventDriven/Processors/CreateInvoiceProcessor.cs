using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven.Events;
using QuanLyHieuThuoc.EventDriven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Processors
{
    public class CreateInvoiceProcessor : EventProcessor
    {
        private readonly Database _database;

        public CreateInvoiceProcessor(Database database)
        {
            _database = database;
        }

        public override void ProcessEvent(object eventData)
        {
            if (eventData is CreateInvoiceEvent createInvoiceEvent)
            {
                try
                {
                    // Tạo mã hóa đơn mới
                    string maHoaDon = GenerateInvoiceCode();

                    // Thêm hóa đơn mới vào database
                    string result = _database.AddInvoice(maHoaDon, createInvoiceEvent.MaNhanVien, createInvoiceEvent.MaKhachHang);

                    if (result == "Success")
                    {
                        // Thêm chi tiết hóa đơn
                        bool success = true;
                        string errorMessage = string.Empty;

                        foreach (var chiTiet in createInvoiceEvent.DanhSachThuoc)
                        {
                            chiTiet.MaHoaDon = maHoaDon;
                            string detailResult = _database.AddInvoiceDetail(chiTiet);

                            if (detailResult != "Success")
                            {
                                success = false;
                                errorMessage = detailResult;
                                break;
                            }
                        }

                        if (success)
                        {
                            // Gọi callback thông báo thành công
                            createInvoiceEvent.Callback?.Invoke(maHoaDon, "Success");
                        }
                        else
                        {
                            // Gọi callback thông báo lỗi
                            createInvoiceEvent.Callback?.Invoke("", errorMessage);
                        }
                    }
                    else
                    {
                        // Gọi callback thông báo lỗi
                        createInvoiceEvent.Callback?.Invoke("", result);
                    }
                }
                catch (Exception ex)
                {
                    // Gọi callback thông báo lỗi
                    createInvoiceEvent.Callback?.Invoke("", ex.Message);
                }
            }
        }

        private string GenerateInvoiceCode()
        {
            // Tạo mã hóa đơn mới dạng HDxxxxx với x là số
            return "HD" + DateTime.Now.ToString("yyMMdd") + new Random().Next(100, 999).ToString();
        }
    }
}
