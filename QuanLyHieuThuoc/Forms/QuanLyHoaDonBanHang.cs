using QuanLyHieuThuoc.EventDriven.Events;
using QuanLyHieuThuoc.Forms;
using QuanLyHieuThuoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHieuThuoc
{
    public partial class QuanLyHoaDonBanHang : Form
    {
        private DataTable _hoaDonDataTable;

        public QuanLyHoaDonBanHang()
        {
            InitializeComponent();
            this.Load += QuanLyHoaDonBanHang_Load;
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnHuy.Click += BtnHuy_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnThoat.Click += BtnThoat_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;
            cbMaHD.SelectedIndexChanged += CbMaHD_SelectedIndexChanged;
            tbTienKhachTra.TextChanged += TbTienKhachTra_TextChanged;
        }

        private void QuanLyHoaDonBanHang_Load(object sender, EventArgs e)
        {
            // Khởi tạo các combobox
            LoadComboboxes();

            // Load danh sách hóa đơn
            LoadInvoices();

            
        }
        private void LoadComboboxes()
        {
            // Combobox tìm kiếm theo mã
            tbTKma.Items.Clear();
            tbTKma.Items.Add("Tất cả");

            // Lấy danh sách mã hóa đơn từ database
            DataTable dtInvoiceCodes = Program.Database.GetInvoiceCodes();

            // Thêm các mã hóa đơn vào combobox tìm kiếm
            foreach (DataRow row in dtInvoiceCodes.Rows)
            {
                tbTKma.Items.Add(row["MaHoaDon"].ToString());
            }

            tbTKma.SelectedIndex = 0;
            // Combobox trạng thái
            cbTT.Items.Clear();
            cbTT.Items.Add("Tất cả");
            cbTT.Items.Add("ChuaThanhToan");
            cbTT.Items.Add("DaThanhToan");
            cbTT.SelectedIndex = 0;

            // Combobox phương thức thanh toán
            cbPay.Items.Clear();
            cbPay.Items.Add("Tiền mặt");
            cbPay.Items.Add("Chuyển khoản");
            cbPay.Items.Add("Thẻ tín dụng");
            cbPay.Items.Add("Ví điện tử");
            cbPay.SelectedIndex = 0;

            // Load danh sách hóa đơn vào combobox mã hóa đơn
            LoadInvoicesToCombobox();
        }

        private void LoadInvoicesToCombobox()
        {
            try
            {
                // Lấy danh sách hóa đơn chưa thanh toán
                DataTable dt = Program.Database.SearchInvoices(null, null, null, "ChuaThanhToan");

                cbMaHD.DataSource = dt;
                cbMaHD.DisplayMember = "MaHoaDon";
                cbMaHD.ValueMember = "MaHoaDon";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoices()
        {
            try
            {
                // Lấy tất cả hóa đơn
                _hoaDonDataTable = Program.Database.GetInvoices();
                if (!dgvHoaDon.Columns.Contains("btnChiTiet"))
                {
                    DataGridViewButtonColumn btnChiTiet = new DataGridViewButtonColumn
                    {
                        HeaderText = "Chi tiết",
                        Text = "Xem chi tiết",
                        Name = "btnChiTiet",
                        UseColumnTextForButtonValue = true
                    };
                    dgvHoaDon.Columns.Add(btnChiTiet);
                }
                dgvHoaDon.DataSource = _hoaDonDataTable;

                // Cấu hình hiển thị các cột
                if (dgvHoaDon.Columns.Count > 0)
                {
                    dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã hóa đơn";
                    dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                    dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                    dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                    dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương thức thanh toán";
                }

                // Tạo sự kiện tìm kiếm hóa đơn không có điều kiện (load tất cả)
                SearchInvoiceEvent searchEvent = new SearchInvoiceEvent
                {
                    MaHoaDon = null,
                    TuNgay = null,
                    DenNgay = null,
                    TrangThai = null,
                    Callback = (result, message) =>
                    {
                        // Đảm bảo callback được thực hiện trên UI thread
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action<DataTable, string>((res, msg) =>
                            {
                                HandleSearchCallback(res, msg);
                            }), result, message);
                        }
                        else
                        {
                            HandleSearchCallback(result, message);
                        }
                    }
                };

                // Hiển thị cursor loading
                this.Cursor = Cursors.WaitCursor;

                // Đưa sự kiện vào hàng đợi
                Program.EventQueue.Enqueue("SearchInvoice", searchEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Mở form tạo mới hóa đơn
            using (TaoMoiHoaDon formTaoHD = new TaoMoiHoaDon())
            {
                if (formTaoHD.ShowDialog() == DialogResult.OK)
                {
                    // Reload danh sách hóa đơn khi tạo mới thành công
                    LoadInvoices();
                    LoadInvoicesToCombobox();
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // Xem tất cả hóa đơn
            LoadInvoices();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            // Hủy hóa đơn (thực tế cần thêm xác nhận và xử lý)
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDon = dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();
            string trangThai = dgvHoaDon.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            if (trangThai == "DaThanhToan")
            {
                MessageBox.Show("Không thể hủy hóa đơn đã thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn hủy hóa đơn {maHoaDon}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thực hiện hủy hóa đơn (cần bổ sung chức năng này vào database)
                MessageBox.Show("Chức năng hủy hóa đơn chưa được triển khai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin tìm kiếm
                string maHoaDon = tbTKma.SelectedIndex == 0 ? null : tbTKma.Text;
                DateTime? tuNgay = dateTỉmeStart.Value;
                DateTime? denNgay = dateTimeEnd.Value;
                string trangThai = cbTT.SelectedIndex == 0 ? null : cbTT.Text;

                // Tạo sự kiện tìm kiếm hóa đơn
                SearchInvoiceEvent searchEvent = new SearchInvoiceEvent
                {
                    MaHoaDon = maHoaDon,
                    TuNgay = tuNgay,
                    DenNgay = denNgay,
                    TrangThai = trangThai,
                    Callback = (result, message) =>
                    {
                        // Đảm bảo callback được thực hiện trên UI thread
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action<DataTable, string>((res, msg) =>
                            {
                                HandleSearchCallback(res, msg);
                            }), result, message);
                        }
                        else
                        {
                            HandleSearchCallback(result, message);
                        }
                    }
                };

                // Hiển thị cursor loading
                this.Cursor = Cursors.WaitCursor;

                // Đưa sự kiện vào hàng đợi
                Program.EventQueue.Enqueue("SearchInvoice", searchEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soTienKhachTra;
            if (!decimal.TryParse(tbTienKhachTra.Text, out soTienKhachTra) || soTienKhachTra <= 0)
            {
                MessageBox.Show("Số tiền khách trả không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDon = cbMaHD.SelectedValue.ToString();
            string phuongThucThanhToan = cbPay.Text;

            // Kiểm tra số tiền thanh toán
            decimal tongTien = 0;
            try
            {
                tongTien = Program.Database.GetInvoiceTotal(maHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soTienKhachTra < tongTien)
            {
                MessageBox.Show("Số tiền khách trả không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo sự kiện thanh toán
            PaymentEvent paymentEvent = new PaymentEvent
            {
                MaHoaDon = maHoaDon,
                PhuongThucThanhToan = phuongThucThanhToan,
                SoTienThanhToan = soTienKhachTra,
                Callback = (mhd, result) =>
                {
                    // Đảm bảo callback được gọi trên UI thread
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action<string, string>((m, r) =>
                        {
                            HandlePaymentCallback(m, r);
                        }), mhd, result);
                    }
                    else
                    {
                        HandlePaymentCallback(mhd, result);
                    }
                }
            };

            // Đưa sự kiện vào hàng đợi
            Program.EventQueue.Enqueue("Payment", paymentEvent);

            // Hiển thị thông báo đang xử lý
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
        }

        private void HandlePaymentCallback(string maHoaDon, string result)
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;

            if (result == "Success")
            {
                MessageBox.Show($"Thanh toán hóa đơn {maHoaDon} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form thanh toán
                tbTienKhachTra.Text = "";
                txTienThua.Text = "";

                // Reload danh sách hóa đơn và combobox
                LoadInvoices();
                LoadInvoicesToCombobox();
            }
            else
            {
                MessageBox.Show($"Lỗi khi thanh toán hóa đơn: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HandleSearchCallback(DataTable result, string message)
        {
            this.Cursor = Cursors.Default;

            // Kiểm tra dữ liệu có lỗi không
            if (result.Columns.Contains("Error"))
            {
                MessageBox.Show($"Lỗi khi tìm kiếm hóa đơn: {result.Rows[0]["Error"]}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị kết quả tìm kiếm
            dgvHoaDon.DataSource = result;

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp với điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cấu hình hiển thị các cột
                ConfigureDataGridViewColumns();
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dgvHoaDon.Columns.Count > 0)
            {
                dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương thức thanh toán";
            }
        }
        //private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        // Hiển thị thông tin hóa đơn được chọn
        //        string maHoaDon = dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value.ToString();
        //        cbMaHD.Text = maHoaDon;
        //    }
        //}

        private void CbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue != null)
            {
                string maHoaDon = cbMaHD.SelectedValue.ToString();

                try
                {
                    // Lấy tổng tiền hóa đơn
                    decimal tongTien = Program.Database.GetInvoiceTotal(maHoaDon);

                    // Hiển thị tổng tiền cần thanh toán
                    tbTienKhachTra.Text = tongTien.ToString("N0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy thông tin hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TbTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue != null)
            {
                decimal soTienKhachTra;
                if (decimal.TryParse(tbTienKhachTra.Text.Replace(",", ""), out soTienKhachTra))
                {
                    try
                    {
                        // Lấy tổng tiền hóa đơn
                        string maHoaDon = cbMaHD.SelectedValue.ToString();
                        decimal tongTien = Program.Database.GetInvoiceTotal(maHoaDon);

                        // Tính tiền thừa
                        decimal tienThua = soTienKhachTra - tongTien;
                        txTienThua.Text = tienThua > 0 ? tienThua.ToString("N0") : "0";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tính tiền thừa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txTienThua.Text = "0";
                }
            }
        }

        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Nếu nhấp vào cột nút "Chi tiết"
                if (dgvHoaDon.Columns["btnChiTiet"] != null && e.ColumnIndex == dgvHoaDon.Columns["btnChiTiet"].Index)
                {
                    string maHoaDon = dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value.ToString();
                    ShowInvoiceDetails(maHoaDon);
                }
                else
                {
                    // Hiển thị thông tin hóa đơn được chọn
                    string maHoaDon = dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value.ToString();
                    cbMaHD.Text = maHoaDon;
                }
            }
        }

        private void ShowInvoiceDetails(string maHoaDon)
        {
            // Tạo form Chi tiết hóa đơn (không hiển thị ngay)
            ChiTietHoaDonForm chiTietForm = new ChiTietHoaDonForm();

            // Tạo sự kiện xem chi tiết hóa đơn
            ViewInvoiceDetailsEvent viewDetailsEvent = new ViewInvoiceDetailsEvent
            {
                MaHoaDon = maHoaDon,
                Callback = (mhd, invoiceInfo, invoiceDetails) =>
                {
                    // Đảm bảo callback được thực hiện trên UI thread
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action<string, DataTable, DataTable>((m, info, details) =>
                        {
                            HandleViewDetailsCallback(chiTietForm, m, info, details);
                        }), mhd, invoiceInfo, invoiceDetails);
                    }
                    else
                    {
                        HandleViewDetailsCallback(chiTietForm, mhd, invoiceInfo, invoiceDetails);
                    }
                }
            };

            // Hiển thị cursor loading
            this.Cursor = Cursors.WaitCursor;

            // Đưa sự kiện vào hàng đợi
            Program.EventQueue.Enqueue("ViewInvoiceDetails", viewDetailsEvent);
        }

        private void HandleViewDetailsCallback(ChiTietHoaDonForm form, string maHoaDon, DataTable invoiceInfo, DataTable invoiceDetails)
        {
            this.Cursor = Cursors.Default;

            // Kiểm tra dữ liệu có lỗi không
            if (invoiceInfo.Columns.Contains("Error"))
            {
                MessageBox.Show($"Lỗi khi tải thông tin hóa đơn: {invoiceInfo.Rows[0]["Error"]}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Dispose();
                return;
            }

            // Đặt dữ liệu cho form
            form.SetData(maHoaDon, invoiceInfo, invoiceDetails);

            // Hiển thị form
            form.ShowDialog();

            // Form sẽ tự động gọi Dispose() khi đóng nếu bạn đã tạo nó bằng 'new'
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
