namespace QuanLyHieuThuoc.Forms
{
    partial class ChiTietHoaDonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblNgayThanhToan = new Label();
            label9 = new Label();
            lblPTThanhToan = new Label();
            label7 = new Label();
            lblTongTien = new Label();
            lblTrangThai = new Label();
            lblKhachHang = new Label();
            lblNhanVien = new Label();
            lblNgayLap = new Label();
            lblMaHoaDon = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvChiTietHoaDon = new DataGridView();
            btnDong = new Button();
            label10 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblNgayThanhToan);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblPTThanhToan);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblTongTien);
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(lblKhachHang);
            groupBox1.Controls.Add(lblNhanVien);
            groupBox1.Controls.Add(lblNgayLap);
            groupBox1.Controls.Add(lblMaHoaDon);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 51);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(773, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblNgayThanhToan
            // 
            lblNgayThanhToan.AutoSize = true;
            lblNgayThanhToan.Location = new Point(520, 136);
            lblNgayThanhToan.Name = "lblNgayThanhToan";
            lblNgayThanhToan.Size = new Size(0, 20);
            lblNgayThanhToan.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(370, 136);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 14;
            label9.Text = "Ngày thanh toán:";
            // 
            // lblPTThanhToan
            // 
            lblPTThanhToan.AutoSize = true;
            lblPTThanhToan.Location = new Point(520, 91);
            lblPTThanhToan.Name = "lblPTThanhToan";
            lblPTThanhToan.Size = new Size(0, 20);
            lblPTThanhToan.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(370, 91);
            label7.Name = "label7";
            label7.Size = new Size(171, 20);
            label7.TabIndex = 12;
            label7.Text = "Phương thức thanh toán:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(520, 45);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(0, 20);
            lblTongTien.TabIndex = 11;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(155, 225);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 20);
            lblTrangThai.TabIndex = 10;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(155, 180);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(0, 20);
            lblKhachHang.TabIndex = 9;
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(155, 136);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(0, 20);
            lblNhanVien.TabIndex = 8;
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            lblNgayLap.Location = new Point(155, 91);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(0, 20);
            lblNgayLap.TabIndex = 7;
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new Point(155, 45);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(0, 20);
            lblMaHoaDon.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(370, 45);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 5;
            label6.Text = "Tổng tiền:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 225);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 4;
            label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 180);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Khách hàng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 136);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 2;
            label3.Text = "Nhân viên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 91);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "Ngày lập:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 45);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã hóa đơn:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvChiTietHoaDon);
            groupBox2.Location = new Point(15, 314);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(773, 324);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết hóa đơn";
            // 
            // dgvChiTietHoaDon
            // 
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHoaDon.Location = new Point(19, 40);
            dgvChiTietHoaDon.Margin = new Padding(3, 4, 3, 4);
            dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            dgvChiTietHoaDon.ReadOnly = true;
            dgvChiTietHoaDon.RowHeadersWidth = 51;
            dgvChiTietHoaDon.RowTemplate.Height = 24;
            dgvChiTietHoaDon.Size = new Size(735, 260);
            dgvChiTietHoaDon.TabIndex = 0;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(694, 645);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(94, 39);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(290, 11);
            label10.Name = "label10";
            label10.Size = new Size(209, 25);
            label10.TabIndex = 3;
            label10.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // ChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 702);
            Controls.Add(label10);
            Controls.Add(btnDong);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChiTietHoaDonForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn";
            Load += ChiTietHoaDon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        //#endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNgayThanhToan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPTThanhToan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label10;
    }
}