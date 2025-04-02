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
    public partial class ChiTietHoaDonForm : Form
    {
        private string _maHoaDon;
        private DataTable _invoiceInfo;
        private DataTable _invoiceDetails;

        public ChiTietHoaDonForm()
        {
            InitializeComponent();
        }
        public void SetData(string maHoaDon, DataTable invoiceInfo, DataTable invoiceDetails)
        {
            _maHoaDon = maHoaDon;
            _invoiceInfo = invoiceInfo;
            _invoiceDetails = invoiceDetails;

            // Load dữ liệu lên form
            DisplayInvoiceInfo();
            DisplayInvoiceDetails();
        }
        private void DisplayInvoiceInfo()
        {
            try
            {
                if (_invoiceInfo.Rows.Count > 0)
                {
                    DataRow row = _invoiceInfo.Rows[0];

                    // Hiển thị thông tin hóa đơn
                    lblMaHoaDon.Text = _maHoaDon;
                    lblNgayLap.Text = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy HH:mm");
                    lblNhanVien.Text = row["TenNhanVien"].ToString();
                    lblKhachHang.Text = row["TenKhachHang"].ToString();
                    lblTrangThai.Text = row["TrangThai"].ToString();
                    lblTongTien.Text = Convert.ToDecimal(row["TongTien"]).ToString("N0") + " VNĐ";

                    if (row["TrangThai"].ToString() == "DaThanhToan")
                    {
                        lblPTThanhToan.Text = row["PhuongThucThanhToan"].ToString();
                        lblNgayThanhToan.Text = row["NgayThanhToan"] != DBNull.Value
                            ? Convert.ToDateTime(row["NgayThanhToan"]).ToString("dd/MM/yyyy HH:mm")
                            : "";
                    }
                    else
                    {
                        lblPTThanhToan.Text = "Chưa thanh toán";
                        lblNgayThanhToan.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayInvoiceDetails()
        {
            try
            {
                // Hiển thị chi tiết hóa đơn
                dgvChiTietHoaDon.DataSource = _invoiceDetails;

                // Định dạng hiển thị các cột
                if (dgvChiTietHoaDon.Columns.Count > 0)
                {
                    dgvChiTietHoaDon.Columns["MaThuoc"].HeaderText = "Mã thuốc";
                    dgvChiTietHoaDon.Columns["TenThuoc"].HeaderText = "Tên thuốc";
                    dgvChiTietHoaDon.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvChiTietHoaDon.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dgvChiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

