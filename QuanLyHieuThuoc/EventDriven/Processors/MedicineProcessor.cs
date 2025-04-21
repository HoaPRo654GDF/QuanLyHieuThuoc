using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven;
using QuanLyHieuThuoc.EventDriven.Events;
using System;

namespace QuanLyHieuThuoc.EventDriven.Processors
{
    public class MedicineProcessor : EventProcessor
    {
        private readonly Database _database;

        public MedicineProcessor(Database database)
        {
            _database = database;
        }

        public override void ProcessEvent(object eventData)
        {
            if (eventData is AddMedicineEvent addEvent)
            {
                ProcessAddMedicineEvent(addEvent);
            }
            else
            {
                Console.WriteLine("Unsupported event type");
            }
        }
        private void ProcessAddMedicineEvent(AddMedicineEvent addEvent)
        {
            try
            {
                // Gọi phương thức AddMedicine từ Database
                string result = _database.AddMedicine(
                    addEvent.MaThuoc,
                    addEvent.TenThuoc,
                    addEvent.MoTa,
                    addEvent.GiaBan,
                    addEvent.HanSuDung,
                    addEvent.SoLuongTon,
                    addEvent.DanhSachMaNCC);

                // Gọi callback để thông báo kết quả
                addEvent.Callback?.Invoke(addEvent.MaThuoc, result);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và gọi callback
                addEvent.Callback?.Invoke(addEvent.MaThuoc, "Error: " + ex.Message);
            }
        }
    }
}