using QuanLyHieuThuoc.DataAccess;
using QuanLyHieuThuoc.EventDriven;
using QuanLyHieuThuoc.EventDriven.Events;
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
    public partial class TaoMoiHoaDon : Form
    {
        private List<ChiTietHoaDon> _danhSachThuoc = new List<ChiTietHoaDon>();
        private DataTable _thuocDataTable;
        private TextBox txtTenKhachHang;

        public TaoMoiHoaDon()
        {
            InitializeComponent();
            btnThemthuocvaoHD.Click += btnThemthuocvaoHD_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;

        }

        private void TaoMoiHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SetupDataGridView();
            tbTongTien.Text = "0";
        }
        private void LoadComboBoxes()
        {
            try
            {
                // Load danh sách thuốc
                _thuocDataTable = Program.Database.GetMedicines();
                cbTenThuocMaThuoc.DataSource = _thuocDataTable;
                cbTenThuocMaThuoc.DisplayMember = "TenThuoc";
                cbTenThuocMaThuoc.ValueMember = "MaThuoc";

                // Load danh sách khách hàng
                DataTable dtKhachHang = Program.Database.GetCustomers();
                cbTenKH.DataSource = dtKhachHang;
                cbTenKH.DisplayMember = "HoTen";
                cbTenKH.ValueMember = "MaKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupDataGridView()
        {
            // Thiết lập cấu trúc DataGridView
            dgvDsThuocTrongHD.AutoGenerateColumns = false;

            // Thêm các cột
            if (dgvDsThuocTrongHD.Columns.Count == 0)
            {
                dgvDsThuocTrongHD.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaThuoc",
                    HeaderText = "Mã thuốc",
                    DataPropertyName = "MaThuoc"
                });

                dgvDsThuocTrongHD.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenThuoc",
                    HeaderText = "Tên thuốc",
                    DataPropertyName = "TenThuoc",
                    Width = 200
                });

                dgvDsThuocTrongHD.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoLuong",
                    HeaderText = "Số lượng",
                    DataPropertyName = "SoLuong"
                });

                dgvDsThuocTrongHD.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "DonGia",
                    HeaderText = "Đơn giá",
                    DataPropertyName = "DonGia",
                    DefaultCellStyle = { Format = "N0" }
                });

                dgvDsThuocTrongHD.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThanhTien",
                    HeaderText = "Thành tiền",
                    DataPropertyName = "ThanhTien",
                    DefaultCellStyle = { Format = "N0" }
                });

                // Thêm nút xóa
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn
                {
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    Name = "btnXoa",
                    UseColumnTextForButtonValue = true
                };
                dgvDsThuocTrongHD.Columns.Add(btnXoa);
            }

            // Đăng ký sự kiện click cho DataGridView
            dgvDsThuocTrongHD.CellClick -= DgvDsThuocTrongHD_CellClick;
            dgvDsThuocTrongHD.CellClick += DgvDsThuocTrongHD_CellClick;
        }
        private void DgvDsThuocTrongHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi nhấn nút xóa trong DataGridView
            if (e.ColumnIndex == dgvDsThuocTrongHD.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                // Xóa thuốc khỏi danh sách
                _danhSachThuoc.RemoveAt(e.RowIndex);
                RefreshDataGridView();
                CalculateTotal();
            }
        }
        private void RefreshDataGridView()
        {
            // Cập nhật DataGridView
            dgvDsThuocTrongHD.DataSource = null;
            dgvDsThuocTrongHD.DataSource = _danhSachThuoc.ToList();
        }

        private void CalculateTotal()
        {
            // Tính tổng tiền
            decimal tongTien = _danhSachThuoc.Sum(t => t.ThanhTien);
            tbTongTien.Text = tongTien.ToString("N0");
        }
        private void btnThemthuocvaoHD_Click(object sender, EventArgs e)
        {
            if (cbTenThuocMaThuoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong;
            if (!int.TryParse(tbSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin thuốc từ DataTable
            string maThuoc = cbTenThuocMaThuoc.SelectedValue.ToString();
            DataRow[] rows = _thuocDataTable.Select($"MaThuoc = '{maThuoc}'");

            if (rows.Length == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow thuocRow = rows[0];

            // Kiểm tra số lượng tồn
            int soLuongTon = Convert.ToInt32(thuocRow["SoLuongTon"]);
            if (soLuong > soLuongTon)
            {
                MessageBox.Show($"Số lượng tồn không đủ. Hiện có {soLuongTon} sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thuốc đã có trong danh sách chưa
            ChiTietHoaDon existingItem = _danhSachThuoc.FirstOrDefault(t => t.MaThuoc == maThuoc);
            if (existingItem != null)
            {
                // Cập nhật số lượng
                existingItem.SoLuong += soLuong;
            }
            else
            {
                // Thêm thuốc mới vào danh sách
                ChiTietHoaDon chiTiet = new ChiTietHoaDon
                {
                    MaThuoc = maThuoc,
                    TenThuoc = thuocRow["TenThuoc"].ToString(),
                    SoLuong = soLuong,
                    DonGia = Convert.ToDecimal(thuocRow["GiaBan"])
                };

                _danhSachThuoc.Add(chiTiet);
            }

            // Cập nhật giao diện
            RefreshDataGridView();
            CalculateTotal();

            // Reset form nhập
            tbSoLuong.Text = "";
            cbTenThuocMaThuoc.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện nút "Lưu" (tạo hóa đơn)
            if (_danhSachThuoc.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTenKH.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ form
            string maKhachHang = cbTenKH.SelectedValue.ToString();
            string maNhanVien = "NV001"; // Mã nhân viên mặc định, trong thực tế lấy từ thông tin đăng nhập

            // Tạo sự kiện tạo hóa đơn
            CreateInvoiceEvent createInvoiceEvent = new CreateInvoiceEvent
            {
                MaNhanVien = maNhanVien,
                MaKhachHang = maKhachHang,
                DanhSachThuoc = _danhSachThuoc,
                Callback = (maHoaDon, result) =>
                {
                    // Đảm bảo callback được gọi trên UI thread
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action<string, string>((mhd, res) =>
                        {
                            HandleCreateInvoiceCallback(mhd, res);
                        }), maHoaDon, result);
                    }
                    else
                    {
                        HandleCreateInvoiceCallback(maHoaDon, result);
                    }
                }
            };

            // Đưa sự kiện vào hàng đợi
            Program.EventQueue.Enqueue("CreateInvoice", createInvoiceEvent);

            // Hiển thị thông báo đang xử lý
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
        }

        private void HandleCreateInvoiceCallback(string maHoaDon, string result)
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;

            if (result == "Success")
            {
                MessageBox.Show($"Tạo hóa đơn thành công. Mã hóa đơn: {maHoaDon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                _danhSachThuoc.Clear();
                RefreshDataGridView();
                tbTongTien.Text = "0";

                // Đóng form và trở về màn hình chính
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hủy tạo hóa đơn và trở về màn hình chính
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này sẽ mở form Quản lý khách hàng.\nChức năng đang được phát triển.",
        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
