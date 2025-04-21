namespace QuanLyHieuThuoc.Forms
{
    partial class QuanLyThuocForm
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
            groupBoxThongTin = new GroupBox();
            clbNhaCungCap = new CheckedListBox();
            lblNhaCungCap = new Label();
            dtHSD = new DateTimePicker();
            txtSoLuongTon = new TextBox();
            txtGiaBan = new TextBox();
            txtMoTa = new TextBox();
            txtTenThuoc = new TextBox();
            txtMaThuoc = new TextBox();
            lblSoLuongTon = new Label();
            lblHanSuDung = new Label();
            lblGiaBan = new Label();
            lblMoTa = new Label();
            lblTenThuoc = new Label();
            lblMaThuoc = new Label();
            groupBoxTimKiem = new GroupBox();
            cbMaNhaCungCap = new ComboBox();
            cbMaThuoc = new ComboBox();
            lblMaNhaCungCap = new Label();
            lblMaThuocTimKiem = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnHuy = new Button();
            btnTimKiem = new Button();
            btnLoc = new Button();
            btnThoat = new Button();
            dgvDsThuoc = new DataGridView();
            lblDanhSachThuoc = new Label();
            lblTitle = new Label();
            groupBoxThongTin.SuspendLayout();
            groupBoxTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsThuoc).BeginInit();
            SuspendLayout();
            // 
            // groupBoxThongTin
            // 
            groupBoxThongTin.Controls.Add(clbNhaCungCap);
            groupBoxThongTin.Controls.Add(lblNhaCungCap);
            groupBoxThongTin.Controls.Add(dtHSD);
            groupBoxThongTin.Controls.Add(txtSoLuongTon);
            groupBoxThongTin.Controls.Add(txtGiaBan);
            groupBoxThongTin.Controls.Add(txtMoTa);
            groupBoxThongTin.Controls.Add(txtTenThuoc);
            groupBoxThongTin.Controls.Add(txtMaThuoc);
            groupBoxThongTin.Controls.Add(lblSoLuongTon);
            groupBoxThongTin.Controls.Add(lblHanSuDung);
            groupBoxThongTin.Controls.Add(lblGiaBan);
            groupBoxThongTin.Controls.Add(lblMoTa);
            groupBoxThongTin.Controls.Add(lblTenThuoc);
            groupBoxThongTin.Controls.Add(lblMaThuoc);
            groupBoxThongTin.Location = new Point(12, 62);
            groupBoxThongTin.Margin = new Padding(3, 4, 3, 4);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Padding = new Padding(3, 4, 3, 4);
            groupBoxThongTin.Size = new Size(460, 430);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông Tin Thuốc";
            // 
            // clbNhaCungCap
            // 
            clbNhaCungCap.CheckOnClick = true;
            clbNhaCungCap.FormattingEnabled = true;
            clbNhaCungCap.Location = new Point(120, 312);
            clbNhaCungCap.Margin = new Padding(3, 4, 3, 4);
            clbNhaCungCap.Name = "clbNhaCungCap";
            clbNhaCungCap.Size = new Size(325, 92);
            clbNhaCungCap.TabIndex = 6;
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.AutoSize = true;
            lblNhaCungCap.Location = new Point(15, 312);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(103, 20);
            lblNhaCungCap.TabIndex = 13;
            lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // dtHSD
            // 
            dtHSD.Format = DateTimePickerFormat.Short;
            dtHSD.Location = new Point(120, 225);
            dtHSD.Margin = new Padding(3, 4, 3, 4);
            dtHSD.Name = "dtHSD";
            dtHSD.Size = new Size(200, 27);
            dtHSD.TabIndex = 4;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(120, 269);
            txtSoLuongTon.Margin = new Padding(3, 4, 3, 4);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(200, 27);
            txtSoLuongTon.TabIndex = 5;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(120, 181);
            txtGiaBan.Margin = new Padding(3, 4, 3, 4);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(200, 27);
            txtGiaBan.TabIndex = 3;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(120, 106);
            txtMoTa.Margin = new Padding(3, 4, 3, 4);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(325, 62);
            txtMoTa.TabIndex = 2;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(120, 62);
            txtTenThuoc.Margin = new Padding(3, 4, 3, 4);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.Size = new Size(325, 27);
            txtTenThuoc.TabIndex = 1;
            // 
            // txtMaThuoc
            // 
            txtMaThuoc.Location = new Point(120, 25);
            txtMaThuoc.Margin = new Padding(3, 4, 3, 4);
            txtMaThuoc.Name = "txtMaThuoc";
            txtMaThuoc.Size = new Size(200, 27);
            txtMaThuoc.TabIndex = 0;
            // 
            // lblSoLuongTon
            // 
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Location = new Point(15, 272);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new Size(98, 20);
            lblSoLuongTon.TabIndex = 8;
            lblSoLuongTon.Text = "Số lượng tồn:";
            // 
            // lblHanSuDung
            // 
            lblHanSuDung.AutoSize = true;
            lblHanSuDung.Location = new Point(15, 231);
            lblHanSuDung.Name = "lblHanSuDung";
            lblHanSuDung.Size = new Size(96, 20);
            lblHanSuDung.TabIndex = 7;
            lblHanSuDung.Text = "Hạn sử dụng:";
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(15, 185);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(63, 20);
            lblGiaBan.TabIndex = 6;
            lblGiaBan.Text = "Giá bán:";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(15, 110);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(51, 20);
            lblMoTa.TabIndex = 5;
            lblMoTa.Text = "Mô tả:";
            // 
            // lblTenThuoc
            // 
            lblTenThuoc.AutoSize = true;
            lblTenThuoc.Location = new Point(15, 66);
            lblTenThuoc.Name = "lblTenThuoc";
            lblTenThuoc.Size = new Size(76, 20);
            lblTenThuoc.TabIndex = 4;
            lblTenThuoc.Text = "Tên thuốc:";
            // 
            // lblMaThuoc
            // 
            lblMaThuoc.AutoSize = true;
            lblMaThuoc.Location = new Point(15, 29);
            lblMaThuoc.Name = "lblMaThuoc";
            lblMaThuoc.Size = new Size(74, 20);
            lblMaThuoc.TabIndex = 3;
            lblMaThuoc.Text = "Mã thuốc:";
            // 
            // groupBoxTimKiem
            // 
            groupBoxTimKiem.Controls.Add(cbMaNhaCungCap);
            groupBoxTimKiem.Controls.Add(cbMaThuoc);
            groupBoxTimKiem.Controls.Add(lblMaNhaCungCap);
            groupBoxTimKiem.Controls.Add(lblMaThuocTimKiem);
            groupBoxTimKiem.Location = new Point(478, 62);
            groupBoxTimKiem.Margin = new Padding(3, 4, 3, 4);
            groupBoxTimKiem.Name = "groupBoxTimKiem";
            groupBoxTimKiem.Padding = new Padding(3, 4, 3, 4);
            groupBoxTimKiem.Size = new Size(380, 125);
            groupBoxTimKiem.TabIndex = 1;
            groupBoxTimKiem.TabStop = false;
            groupBoxTimKiem.Text = "Tìm Kiếm";
            // 
            // cbMaNhaCungCap
            // 
            cbMaNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaNhaCungCap.FormattingEnabled = true;
            cbMaNhaCungCap.Location = new Point(120, 75);
            cbMaNhaCungCap.Margin = new Padding(3, 4, 3, 4);
            cbMaNhaCungCap.Name = "cbMaNhaCungCap";
            cbMaNhaCungCap.Size = new Size(240, 28);
            cbMaNhaCungCap.TabIndex = 1;
            // 
            // cbMaThuoc
            // 
            cbMaThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaThuoc.FormattingEnabled = true;
            cbMaThuoc.Location = new Point(120, 31);
            cbMaThuoc.Margin = new Padding(3, 4, 3, 4);
            cbMaThuoc.Name = "cbMaThuoc";
            cbMaThuoc.Size = new Size(240, 28);
            cbMaThuoc.TabIndex = 0;
            // 
            // lblMaNhaCungCap
            // 
            lblMaNhaCungCap.AutoSize = true;
            lblMaNhaCungCap.Location = new Point(15, 79);
            lblMaNhaCungCap.Name = "lblMaNhaCungCap";
            lblMaNhaCungCap.Size = new Size(103, 20);
            lblMaNhaCungCap.TabIndex = 3;
            lblMaNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // lblMaThuocTimKiem
            // 
            lblMaThuocTimKiem.AutoSize = true;
            lblMaThuocTimKiem.Location = new Point(15, 35);
            lblMaThuocTimKiem.Name = "lblMaThuocTimKiem";
            lblMaThuocTimKiem.Size = new Size(74, 20);
            lblMaThuocTimKiem.TabIndex = 2;
            lblMaThuocTimKiem.Text = "Mã thuốc:";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 512);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 38);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(118, 512);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 38);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(224, 512);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 38);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(330, 512);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 38);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(478, 195);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 38);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            btnLoc.Location = new Point(584, 195);
            btnLoc.Margin = new Padding(3, 4, 3, 4);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(100, 38);
            btnLoc.TabIndex = 8;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(758, 512);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(100, 38);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // dgvDsThuoc
            // 
            dgvDsThuoc.AllowUserToAddRows = false;
            dgvDsThuoc.AllowUserToDeleteRows = false;
            dgvDsThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDsThuoc.Location = new Point(12, 600);
            dgvDsThuoc.Margin = new Padding(3, 4, 3, 4);
            dgvDsThuoc.MultiSelect = false;
            dgvDsThuoc.Name = "dgvDsThuoc";
            dgvDsThuoc.ReadOnly = true;
            dgvDsThuoc.RowHeadersWidth = 51;
            dgvDsThuoc.RowTemplate.Height = 24;
            dgvDsThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDsThuoc.Size = new Size(846, 275);
            dgvDsThuoc.TabIndex = 10;
            // 
            // lblDanhSachThuoc
            // 
            lblDanhSachThuoc.AutoSize = true;
            lblDanhSachThuoc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDanhSachThuoc.Location = new Point(12, 569);
            lblDanhSachThuoc.Name = "lblDanhSachThuoc";
            lblDanhSachThuoc.Size = new Size(158, 20);
            lblDanhSachThuoc.TabIndex = 11;
            lblDanhSachThuoc.Text = "Danh Sách Thuốc";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.Blue;
            lblTitle.Location = new Point(350, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(212, 31);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "Quản Lý Thuốc";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuanLyThuocForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 890);
            Controls.Add(lblTitle);
            Controls.Add(lblDanhSachThuoc);
            Controls.Add(dgvDsThuoc);
            Controls.Add(btnThoat);
            Controls.Add(btnLoc);
            Controls.Add(btnTimKiem);
            Controls.Add(btnHuy);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBoxTimKiem);
            Controls.Add(groupBoxThongTin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "QuanLyThuocForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Thuốc";
            Load += QuanLyThuocForm_Load_1;
            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            groupBoxTimKiem.ResumeLayout(false);
            groupBoxTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsThuoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.Label lblMaThuoc;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblHanSuDung;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.TextBox txtMaThuoc;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.DateTimePicker dtHSD;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.CheckedListBox clbNhaCungCap;
        private System.Windows.Forms.GroupBox groupBoxTimKiem;
        private System.Windows.Forms.Label lblMaThuocTimKiem;
        private System.Windows.Forms.Label lblMaNhaCungCap;
        private System.Windows.Forms.ComboBox cbMaThuoc;
        private System.Windows.Forms.ComboBox cbMaNhaCungCap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvDsThuoc;
        private System.Windows.Forms.Label lblDanhSachThuoc;
        private System.Windows.Forms.Label lblTitle;
    }
}