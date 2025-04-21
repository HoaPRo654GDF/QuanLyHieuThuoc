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

namespace QuanLyHieuThuoc.Forms
{
    public partial class QuanLyThuocForm : Form
    {
        private DataTable _thuocDataTable;
        private DataTable _nhaCungCapDataTable;

        public QuanLyThuocForm()
        {
            InitializeComponent();
            this.Load += QuanLyThuocForm_Load;

            // Đăng ký các sự kiện button
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
            btnThoat.Click += BtnThoat_Click;

            // Đăng ký sự kiện cho DataGridView
            dgvDsThuoc.CellClick += DgvDsThuoc_CellClick;
        }

        private void QuanLyThuocForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _thuocDataTable = Program.Database.GetMedicines();
                dgvDsThuoc.DataSource = _thuocDataTable;

                // Cấu hình hiển thị các cột
                if (dgvDsThuoc.Columns.Count > 0)
                {
                    dgvDsThuoc.Columns["MaThuoc"].HeaderText = "Mã thuốc";
                    dgvDsThuoc.Columns["TenThuoc"].HeaderText = "Tên thuốc";
                    dgvDsThuoc.Columns["GiaBan"].HeaderText = "Giá bán";
                    dgvDsThuoc.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                    dgvDsThuoc.Columns["HanSuDung"].HeaderText = "Hạn sử dụng";
                    dgvDsThuoc.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
                    dgvDsThuoc.Columns["MoTa"].HeaderText = "Mô tả";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load danh sách thuốc vào combobox mã thuốc để tìm kiếm
                _thuocDataTable = Program.Database.GetMedicines();
                cbMaThuoc.Items.Clear();
                cbMaThuoc.Items.Add("Tất cả");
                foreach (DataRow row in _thuocDataTable.Rows)
                {
                    cbMaThuoc.Items.Add(row["MaThuoc"].ToString());
                }
                cbMaThuoc.SelectedIndex = 0;

                // Load danh sách nhà cung cấp
                _nhaCungCapDataTable = Program.Database.GetSuppliers();

                // Cấu hình combobox nhà cung cấp cho lọc
                cbMaNhaCungCap.Items.Clear();
                cbMaNhaCungCap.Items.Add("Tất cả");
                foreach (DataRow row in _nhaCungCapDataTable.Rows)
                {
                    cbMaNhaCungCap.Items.Add(row["TenNhaCungCap"].ToString());
                }
                cbMaNhaCungCap.SelectedIndex = 0;

                // Cấu hình CheckedListBox nhà cung cấp
                clbNhaCungCap.Items.Clear();
                foreach (DataRow row in _nhaCungCapDataTable.Rows)
                {
                    string display = $"{row["TenNhaCungCap"]} ({row["MaNhaCungCap"]})";
                    clbNhaCungCap.Items.Add(display, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvDsThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDsThuoc.Rows[e.RowIndex];

                    // Lấy thông tin thuốc từ hàng được chọn
                    txtMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                    txtTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                    txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                    txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
                    dtHSD.Value = Convert.ToDateTime(row.Cells["HanSuDung"].Value);

                    // Bỏ chọn tất cả nhà cung cấp
                    for (int i = 0; i < clbNhaCungCap.Items.Count; i++)
                    {
                        clbNhaCungCap.SetItemChecked(i, false);
                    }

                    // Lấy danh sách nhà cung cấp của thuốc và check vào CheckedListBox
                    string maThuoc = txtMaThuoc.Text;
                    DataTable dtNCC = Program.Database.GetSuppliersForMedicine(maThuoc);

                    foreach (DataRow nccRow in dtNCC.Rows)
                    {
                        string maNCC = nccRow["MaNhaCungCap"].ToString();

                        // Tìm và check item tương ứng trong CheckedListBox
                        for (int i = 0; i < clbNhaCungCap.Items.Count; i++)
                        {
                            string item = clbNhaCungCap.Items[i].ToString();
                            if (item.Contains($"({maNCC})"))
                            {
                                clbNhaCungCap.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }

                    // Vô hiệu hóa textbox Mã thuốc khi chọn thuốc để sửa
                    txtMaThuoc.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string maThuoc = txtMaThuoc.Text.Trim();
                string tenThuoc = txtTenThuoc.Text.Trim();
                string moTa = txtMoTa.Text.Trim();
                decimal giaBan;
                int soLuongTon;
                DateTime hanSuDung = dtHSD.Value;

                // Lấy danh sách nhà cung cấp được chọn
                List<string> danhSachMaNCC = new List<string>();
                for (int i = 0; i < clbNhaCungCap.CheckedItems.Count; i++)
                {
                    string item = clbNhaCungCap.CheckedItems[i].ToString();
                    // Lấy mã NCC từ chuỗi hiển thị, giả sử định dạng "TenNCC (MaNCC)"
                    string maNCC = item.Substring(item.LastIndexOf('(') + 1).Replace(")", "");
                    danhSachMaNCC.Add(maNCC);
                }

                // Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(maThuoc))
                {
                    MessageBox.Show("Vui lòng nhập mã thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaThuoc.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tenThuoc))
                {
                    MessageBox.Show("Vui lòng nhập tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenThuoc.Focus();
                    return;
                }

                if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || giaBan <= 0)
                {
                    MessageBox.Show("Giá bán phải là số dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaBan.Focus();
                    return;
                }

                if (!int.TryParse(txtSoLuongTon.Text, out soLuongTon) || soLuongTon < 0)
                {
                    MessageBox.Show("Số lượng tồn phải là số nguyên không âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongTon.Focus();
                    return;
                }

                // Tạo AddMedicineEvent
                var addMedicineEvent = new AddMedicineEvent
                {
                    MaThuoc = maThuoc,
                    TenThuoc = tenThuoc,
                    MoTa = moTa,
                    GiaBan = giaBan,
                    HanSuDung = hanSuDung,
                    SoLuongTon = soLuongTon,
                    DanhSachMaNCC = danhSachMaNCC,
                    Callback = (id, result) =>
                    {
                        // Đảm bảo callback được gọi trên UI thread
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action<string, string>((i, r) =>
                            {
                                HandleAddMedicineCallback(i, r);
                            }), id, result);
                        }
                        else
                        {
                            HandleAddMedicineCallback(id, result);
                        }
                    }
                };

                // Đưa sự kiện vào hàng đợi
                Program.EventQueue.Enqueue("AddMedicine", addMedicineEvent);

                // Hiển thị thông báo đang xử lý
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleAddMedicineCallback(string maThuoc, string result)
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;

            if (result == "Success")
            {
                MessageBox.Show($"Thêm thuốc thành công. Mã thuốc: {maThuoc}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới form
                ClearForm();
                LoadData();
            }
            else
            {
                MessageBox.Show($"Lỗi khi thêm thuốc: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      




        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaThuoc.Enabled = true;
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtMaThuoc.Text = "";
            txtTenThuoc.Text = "";
            txtMoTa.Text = "";
            txtGiaBan.Text = "";
            txtSoLuongTon.Text = "";
            dtHSD.Value = DateTime.Now.AddYears(1);

            // Bỏ chọn tất cả nhà cung cấp
            for (int i = 0; i < clbNhaCungCap.Items.Count; i++)
            {
                clbNhaCungCap.SetItemChecked(i, false);
            }

            txtMaThuoc.Enabled = true;
            txtMaThuoc.Focus();
        }

        private void QuanLyThuocForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}