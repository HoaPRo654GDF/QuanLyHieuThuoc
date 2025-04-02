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
    public class PaymentProcessor : EventProcessor
    {
        private readonly Database _database;

        public PaymentProcessor(Database database)
        {
            _database = database;
        }

        public override void ProcessEvent(object eventData)
        {
            if (eventData is PaymentEvent paymentEvent)
            {
                try
                {
                    // Cập nhật trạng thái thanh toán
                    string result = _database.UpdatePaymentStatus(
                        paymentEvent.MaHoaDon,
                        paymentEvent.PhuongThucThanhToan,
                        paymentEvent.SoTienThanhToan);

                    // Gọi callback với kết quả
                    paymentEvent.Callback?.Invoke(paymentEvent.MaHoaDon, result);
                }
                catch (Exception ex)
                {
                    // Gọi callback thông báo lỗi
                    paymentEvent.Callback?.Invoke(paymentEvent.MaHoaDon, ex.Message);
                }
            }
        }
    }
}
