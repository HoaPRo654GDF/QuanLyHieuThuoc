namespace QuanLyHieuThuoc
{
    partial class QuanLyHoaDonBanHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            cbMaHD = new ComboBox();
            label6 = new Label();
            txTienThua = new TextBox();
            tbTienKhachTra = new TextBox();
            label4 = new Label();
            label7 = new Label();
            label9 = new Label();
            cbPay = new ComboBox();
            btnThanhToan = new Button();
            dsHoaDon = new GroupBox();
            dgvHoaDon = new DataGridView();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnHuy = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            label1 = new Label();
            groupBoxTimKiem = new GroupBox();
            dateTimeEnd = new DateTimePicker();
            dateTỉmeStart = new DateTimePicker();
            cbTT = new ComboBox();
            lbTT = new Label();
            lbTimeEnd = new Label();
            lbTimeStart = new Label();
            lbTKma = new Label();
            tbTKma = new ComboBox();
            groupBox2.SuspendLayout();
            dsHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            groupBoxTimKiem.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbMaHD);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txTienThua);
            groupBox2.Controls.Add(tbTienKhachTra);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cbPay);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(694, 125);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(420, 308);
            groupBox2.TabIndex = 68;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thanh toán";
            // 
            // cbMaHD
            // 
            cbMaHD.FormattingEnabled = true;
            cbMaHD.Location = new Point(193, 50);
            cbMaHD.Margin = new Padding(3, 4, 3, 4);
            cbMaHD.Name = "cbMaHD";
            cbMaHD.Size = new Size(200, 26);
            cbMaHD.TabIndex = 61;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 50);
            label6.Name = "label6";
            label6.Size = new Size(87, 18);
            label6.TabIndex = 60;
            label6.Text = "Mã hóa đơn";
            // 
            // txTienThua
            // 
            txTienThua.Location = new Point(193, 231);
            txTienThua.Margin = new Padding(3, 4, 3, 4);
            txTienThua.Name = "txTienThua";
            txTienThua.Size = new Size(200, 24);
            txTienThua.TabIndex = 59;
            // 
            // tbTienKhachTra
            // 
            tbTienKhachTra.Location = new Point(193, 170);
            tbTienKhachTra.Margin = new Padding(3, 4, 3, 4);
            tbTienKhachTra.Name = "tbTienKhachTra";
            tbTienKhachTra.Size = new Size(200, 24);
            tbTienKhachTra.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 231);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 15;
            label4.Text = "Tiền thừa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 178);
            label7.Name = "label7";
            label7.Size = new Size(119, 18);
            label7.TabIndex = 7;
            label7.Text = "Số tiền khách trả";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 114);
            label9.Name = "label9";
            label9.Size = new Size(164, 18);
            label9.TabIndex = 6;
            label9.Text = "Phương thức thanh toán";
            // 
            // cbPay
            // 
            cbPay.FormattingEnabled = true;
            cbPay.Location = new Point(193, 110);
            cbPay.Margin = new Padding(3, 4, 3, 4);
            cbPay.Name = "cbPay";
            cbPay.Size = new Size(200, 26);
            cbPay.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(203, 461);
            btnThanhToan.Margin = new Padding(3, 4, 3, 4);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(145, 29);
            btnThanhToan.TabIndex = 67;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // dsHoaDon
            // 
            dsHoaDon.Controls.Add(dgvHoaDon);
            dsHoaDon.Location = new Point(324, 498);
            dsHoaDon.Margin = new Padding(3, 4, 3, 4);
            dsHoaDon.Name = "dsHoaDon";
            dsHoaDon.Padding = new Padding(3, 4, 3, 4);
            dsHoaDon.Size = new Size(790, 388);
            dsHoaDon.TabIndex = 66;
            dsHoaDon.TabStop = false;
            dsHoaDon.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(18, 26);
            dgvHoaDon.Margin = new Padding(3, 4, 3, 4);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.RowTemplate.Height = 24;
            dgvHoaDon.Size = new Size(745, 354);
            dgvHoaDon.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(887, 461);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(145, 29);
            btnTimKiem.TabIndex = 65;
            btnTimKiem.Text = "Tìm KIếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1056, 461);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(145, 29);
            btnThoat.TabIndex = 64;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(723, 461);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(145, 29);
            btnHuy.TabIndex = 63;
            btnHuy.Text = "Hủy hóa đơn";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(545, 461);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(145, 29);
            btnXoa.TabIndex = 62;
            btnXoa.Text = "Xem tất cả";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(379, 461);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(145, 29);
            btnThem.TabIndex = 61;
            btnThem.Text = "Tạo hóa đơn mới";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(606, 42);
            label1.Name = "label1";
            label1.Size = new Size(245, 31);
            label1.TabIndex = 60;
            label1.Text = "Quản Lý Hóa Dơn";
            // 
            // groupBoxTimKiem
            // 
            groupBoxTimKiem.Controls.Add(dateTimeEnd);
            groupBoxTimKiem.Controls.Add(dateTỉmeStart);
            groupBoxTimKiem.Controls.Add(cbTT);
            groupBoxTimKiem.Controls.Add(lbTT);
            groupBoxTimKiem.Controls.Add(lbTimeEnd);
            groupBoxTimKiem.Controls.Add(lbTimeStart);
            groupBoxTimKiem.Controls.Add(lbTKma);
            groupBoxTimKiem.Controls.Add(tbTKma);
            groupBoxTimKiem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxTimKiem.Location = new Point(249, 114);
            groupBoxTimKiem.Margin = new Padding(3, 4, 3, 4);
            groupBoxTimKiem.Name = "groupBoxTimKiem";
            groupBoxTimKiem.Padding = new Padding(3, 4, 3, 4);
            groupBoxTimKiem.Size = new Size(420, 319);
            groupBoxTimKiem.TabIndex = 59;
            groupBoxTimKiem.TabStop = false;
            groupBoxTimKiem.Text = "Tìm Kiếm";
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.Location = new Point(159, 189);
            dateTimeEnd.Margin = new Padding(3, 4, 3, 4);
            dateTimeEnd.Name = "dateTimeEnd";
            dateTimeEnd.Size = new Size(200, 24);
            dateTimeEnd.TabIndex = 57;
            // 
            // dateTỉmeStart
            // 
            dateTỉmeStart.Location = new Point(159, 118);
            dateTỉmeStart.Margin = new Padding(3, 4, 3, 4);
            dateTỉmeStart.Name = "dateTỉmeStart";
            dateTỉmeStart.Size = new Size(200, 24);
            dateTỉmeStart.TabIndex = 56;
            // 
            // cbTT
            // 
            cbTT.FormattingEnabled = true;
            cbTT.Location = new Point(159, 250);
            cbTT.Margin = new Padding(3, 4, 3, 4);
            cbTT.Name = "cbTT";
            cbTT.Size = new Size(200, 26);
            cbTT.TabIndex = 21;
            // 
            // lbTT
            // 
            lbTT.AutoSize = true;
            lbTT.Location = new Point(26, 250);
            lbTT.Name = "lbTT";
            lbTT.Size = new Size(73, 18);
            lbTT.TabIndex = 15;
            lbTT.Text = "Trạng thái";
            // 
            // lbTimeEnd
            // 
            lbTimeEnd.AutoSize = true;
            lbTimeEnd.Location = new Point(26, 189);
            lbTimeEnd.Name = "lbTimeEnd";
            lbTimeEnd.Size = new Size(70, 18);
            lbTimeEnd.TabIndex = 9;
            lbTimeEnd.Text = "Đến ngày";
            // 
            // lbTimeStart
            // 
            lbTimeStart.AutoSize = true;
            lbTimeStart.Location = new Point(26, 118);
            lbTimeStart.Name = "lbTimeStart";
            lbTimeStart.Size = new Size(60, 18);
            lbTimeStart.TabIndex = 7;
            lbTimeStart.Text = "Từ ngày";
            // 
            // lbTKma
            // 
            lbTKma.AutoSize = true;
            lbTKma.Location = new Point(26, 55);
            lbTKma.Name = "lbTKma";
            lbTKma.Size = new Size(127, 18);
            lbTKma.TabIndex = 6;
            lbTKma.Text = "Tìm kiếm theo mã";
            // 
            // tbTKma
            // 
            tbTKma.FormattingEnabled = true;
            tbTKma.Location = new Point(159, 51);
            tbTKma.Margin = new Padding(3, 4, 3, 4);
            tbTKma.Name = "tbTKma";
            tbTKma.Size = new Size(200, 26);
            tbTKma.TabIndex = 0;
            // 
            // QuanLyHoaDonBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 928);
            Controls.Add(groupBox2);
            Controls.Add(btnThanhToan);
            Controls.Add(dsHoaDon);
            Controls.Add(btnTimKiem);
            Controls.Add(btnThoat);
            Controls.Add(btnHuy);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(label1);
            Controls.Add(groupBoxTimKiem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLyHoaDonBanHang";
            Text = "QuanLyHoaDonBanHang";
            Load += QuanLyHoaDonBanHang_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            dsHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            groupBoxTimKiem.ResumeLayout(false);
            groupBoxTimKiem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbMaHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txTienThua;
        private System.Windows.Forms.TextBox tbTienKhachTra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPay;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.GroupBox dsHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTimKiem;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTỉmeStart;
        private System.Windows.Forms.ComboBox cbTT;
        private System.Windows.Forms.Label lbTT;
        private System.Windows.Forms.Label lbTimeEnd;
        private System.Windows.Forms.Label lbTimeStart;
        private System.Windows.Forms.Label lbTKma;
        private System.Windows.Forms.ComboBox tbTKma;
    }
}