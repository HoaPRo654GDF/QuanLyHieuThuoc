using System;
using System.Windows.Forms;
using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven;
using QuanLyHieuThuoc.EventDriven.Channels;
using QuanLyHieuThuoc.EventDriven.Processors;
//using QuanLyHieuThuoc.EventDriven.Interfaces;

namespace QuanLyHieuThuoc
{
    internal static class Program
    {
        public static EventQueue EventQueue { get; private set; }
        public static EventMediator EventMediator { get; private set; }
        public static Database Database { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kh?i t?o các thành ph?n event-driven
            InitializeComponents();

            // Kh?i ch?y form chính
            Application.Run(new QuanLyHoaDonBanHang());

            // D?ng x? lý s? ki?n khi thoát ?ng d?ng
            EventQueue.StopProcessing();
        }

        private static void InitializeComponents()
        {
            // Thi?t l?p chu?i k?t n?i tr?c ti?p
            string connectionString = @"Data Source=DESKTOP-AKO065P;Initial Catalog=QuanLyHieuThuocLongChau;Integrated Security=True;TrustServerCertificate=True";
            Database = new Database(connectionString);

            // Kh?i t?o event queue và mediator
            EventQueue = new EventQueue();
            EventMediator = new EventMediator();

            // ??ng ký các channel và processor
            var invoiceChannel = new InvoiceChannel();
            var paymentChannel = new PaymentChannel();
            var createInvoiceProcessor = new CreateInvoiceProcessor(Database);
            var paymentProcessor = new PaymentProcessor(Database);

            
            EventMediator.RegisterChannel("CreateInvoice", invoiceChannel);
            EventMediator.RegisterProcessor("CreateInvoice", createInvoiceProcessor);
           
            EventMediator.RegisterChannel("Payment", paymentChannel);
            EventMediator.RegisterProcessor("Payment", paymentProcessor);

            // Đăng kí processor cho Xem chi tiết hóa đơn
            var viewInvoiceDetailsChannel = new ViewInvoiceDetailsChannel(); // Có thể dùng chung InvoiceChannel
            var viewInvoiceDetailsProcessor = new ViewInvoiceDetailsProcessor(Database);

            EventMediator.RegisterChannel("ViewInvoiceDetails", viewInvoiceDetailsChannel);
            EventMediator.RegisterProcessor("ViewInvoiceDetails", viewInvoiceDetailsProcessor);

            // Đăng ký processor cho tìm kiếm hóa đơn
            var searchInvoiceChannel = new SearchInvoiceChannel();
            var searchInvoiceProcessor = new SearchInvoiceProcessor(Database);

            EventMediator.RegisterChannel("SearchInvoice", searchInvoiceChannel);
            EventMediator.RegisterProcessor("SearchInvoice", searchInvoiceProcessor);

            // B?t ??u x? lý s? ki?n
            EventQueue.StartProcessing(EventMediator);
        }
    }
}