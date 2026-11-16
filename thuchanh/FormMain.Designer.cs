using thuchanh.Helpers;

namespace thuchanh;

partial class FormMain
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        panel1 = new Panel();
        labelTenKhachSan = new Label();
        pictureBox1 = new PictureBox();
        panelLeft = new Panel();
        panel2 = new Panel();
        lblTenNguoiDung = new Label();
        pictureBox2 = new PictureBox();
        linkLabel1 = new LinkLabel();
        panelMain = new Panel();
        panel4 = new Panel();
        button13 = new Button();
        btnTrangChu = new Button();
        button5 = new Button();
        button4 = new Button();
        button7 = new Button();
        button6 = new Button();
        btnQuanLyPhong = new Button();
        button12 = new Button();
        button11 = new Button();
        btnSoDoPhong = new Button();
        button9 = new Button();
        button10 = new Button();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        panelLeft.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        panel4.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = Color.SeaGreen;
        panel1.Controls.Add(labelTenKhachSan);
        panel1.Controls.Add(pictureBox1);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1366, 72);
        panel1.TabIndex = 0;
        // 
        // labelTenKhachSan
        // 
        labelTenKhachSan.AutoSize = true;
        labelTenKhachSan.BackColor = Color.Transparent;
        labelTenKhachSan.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelTenKhachSan.ForeColor = Color.LightSalmon;
        labelTenKhachSan.Location = new Point(55, 14);
        labelTenKhachSan.Name = "labelTenKhachSan";
        labelTenKhachSan.Size = new Size(250, 37);
        labelTenKhachSan.TabIndex = 3;
        labelTenKhachSan.Text = "Hotel Management";
        // 
        // pictureBox1
        // 
        pictureBox1.Image = AppResources.Logo;
        pictureBox1.Location = new Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(38, 62);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // panelLeft
        // 
        panelLeft.BackColor = Color.DarkCyan;
        panelLeft.Controls.Add(panel4);
        panelLeft.Controls.Add(panel2);
        panelLeft.Dock = DockStyle.Left;
        panelLeft.Location = new Point(0, 72);
        panelLeft.Name = "panelLeft";
        panelLeft.Size = new Size(240, 728);
        panelLeft.TabIndex = 5;
        // 
        // panel2
        // 
        panel2.BackColor = Color.MediumSeaGreen;
        panel2.Controls.Add(lblTenNguoiDung);
        panel2.Controls.Add(pictureBox2);
        panel2.Controls.Add(linkLabel1);
        panel2.Dock = DockStyle.Top;
        panel2.Location = new Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(240, 170);
        panel2.TabIndex = 1;
        // 
        // lblTenNguoiDung
        // 
        lblTenNguoiDung.AutoSize = true;
        lblTenNguoiDung.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTenNguoiDung.Location = new Point(20, 118);
        lblTenNguoiDung.Name = "lblTenNguoiDung";
        lblTenNguoiDung.MaximumSize = new Size(200, 0);
        lblTenNguoiDung.Size = new Size(60, 20);
        lblTenNguoiDung.TabIndex = 2;
        lblTenNguoiDung.Text = "label1";
        lblTenNguoiDung.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pictureBox2
        // 
        pictureBox2.BackgroundImageLayout = ImageLayout.None;
        pictureBox2.Image = AppResources.NguoiDungAnh;
        pictureBox2.Location = new Point(78, 32);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(68, 85);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 1;
        pictureBox2.TabStop = false;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        linkLabel1.ForeColor = Color.MidnightBlue;
        linkLabel1.Location = new Point(4, 6);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(86, 20);
        linkLabel1.TabIndex = 0;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Đăng xuất";
        linkLabel1.LinkClicked += linkLabel1_LinkClicked;
        // 
        // panelMain
        // 
        panelMain.AutoScroll = true;
        panelMain.BackColor = Color.Honeydew;
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new Point(240, 227);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(1126, 573);
        panelMain.TabIndex = 2;
        // 
        // panel4
        // 
        panel4.AutoScroll = true;
        panel4.BackColor = Color.DarkCyan;
        panel4.Controls.Add(button13);
        panel4.Controls.Add(btnTrangChu);
        panel4.Controls.Add(button5);
        panel4.Controls.Add(button4);
        panel4.Controls.Add(button7);
        panel4.Controls.Add(button6);
        panel4.Controls.Add(btnQuanLyPhong);
        panel4.Controls.Add(button12);
        panel4.Controls.Add(button11);
        panel4.Controls.Add(btnSoDoPhong);
        panel4.Controls.Add(button9);
        panel4.Controls.Add(button10);
        panel4.Dock = DockStyle.Fill;
        panel4.Location = new Point(0, 170);
        panel4.Name = "panel4";
        panel4.Size = new Size(240, 558);
        panel4.TabIndex = 4;
        // 
        // button13
        // 
        button13.BackColor = Color.DarkCyan;
        button13.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button13.ForeColor = SystemColors.ButtonHighlight;
        button13.Image = AppResources.ThongKe;
        button13.ImageAlign = ContentAlignment.MiddleLeft;
        button13.Location = new Point(0, 506);
        button13.Name = "button13";
        button13.Padding = new Padding(12, 0, 0, 0);
        button13.Size = new Size(240, 46);
        button13.TabIndex = 16;
        button13.Text = "Thống kê";
        button13.TextAlign = ContentAlignment.MiddleLeft;
        button13.TextImageRelation = TextImageRelation.ImageBeforeText;
        button13.UseVisualStyleBackColor = false;
        button13.Click += button13_Click;
        // 
        // btnTrangChu
        // 
        btnTrangChu.BackColor = Color.DarkCyan;
        btnTrangChu.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnTrangChu.ForeColor = SystemColors.ButtonHighlight;
        btnTrangChu.Image = AppResources.TrangChu;
        btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
        btnTrangChu.Location = new Point(0, 0);
        btnTrangChu.Name = "btnTrangChu";
        btnTrangChu.Padding = new Padding(12, 0, 0, 0);
        btnTrangChu.Size = new Size(240, 46);
        btnTrangChu.TabIndex = 3;
        btnTrangChu.Text = "Trang chủ";
        btnTrangChu.TextAlign = ContentAlignment.MiddleLeft;
        btnTrangChu.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnTrangChu.UseVisualStyleBackColor = false;
        btnTrangChu.Click += btnTrangChu_Click;
        // 
        // button5
        // 
        button5.BackColor = Color.DarkCyan;
        button5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button5.ForeColor = SystemColors.ButtonHighlight;
        button5.Image = AppResources.TaiKhoan;
        button5.ImageAlign = ContentAlignment.MiddleLeft;
        button5.Location = new Point(0, 460);
        button5.Name = "button5";
        button5.Padding = new Padding(12, 0, 0, 0);
        button5.Size = new Size(240, 46);
        button5.TabIndex = 8;
        button5.Text = "Danh sách tài khoản";
        button5.TextAlign = ContentAlignment.MiddleLeft;
        button5.TextImageRelation = TextImageRelation.ImageBeforeText;
        button5.UseVisualStyleBackColor = false;
        button5.Click += button5_Click;
        // 
        // button4
        // 
        button4.BackColor = Color.DarkCyan;
        button4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button4.ForeColor = SystemColors.ButtonHighlight;
        button4.Image = AppResources.LoaiPhong;
        button4.ImageAlign = ContentAlignment.MiddleLeft;
        button4.Location = new Point(0, 138);
        button4.Name = "button4";
        button4.Padding = new Padding(12, 0, 0, 0);
        button4.Size = new Size(240, 46);
        button4.TabIndex = 7;
        button4.Text = "Loại phòng";
        button4.TextAlign = ContentAlignment.MiddleLeft;
        button4.TextImageRelation = TextImageRelation.ImageBeforeText;
        button4.UseVisualStyleBackColor = false;
        button4.Click += button4_Click;
        // 
        // button7
        // 
        button7.BackColor = Color.DarkCyan;
        button7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button7.ForeColor = SystemColors.ButtonHighlight;
        button7.Image = AppResources.NhanVien;
        button7.ImageAlign = ContentAlignment.MiddleLeft;
        button7.Location = new Point(0, 414);
        button7.Name = "button7";
        button7.Padding = new Padding(12, 0, 0, 0);
        button7.Size = new Size(240, 46);
        button7.TabIndex = 10;
        button7.Text = "Danh sách nhân viên";
        button7.TextAlign = ContentAlignment.MiddleLeft;
        button7.TextImageRelation = TextImageRelation.ImageBeforeText;
        button7.UseVisualStyleBackColor = false;
        button7.Click += button7_Click;
        // 
        // button6
        // 
        button6.BackColor = Color.DarkCyan;
        button6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button6.ForeColor = SystemColors.ButtonHighlight;
        button6.Image = AppResources.KhachHang;
        button6.ImageAlign = ContentAlignment.MiddleLeft;
        button6.Location = new Point(0, 368);
        button6.Name = "button6";
        button6.Padding = new Padding(12, 0, 0, 0);
        button6.Size = new Size(240, 46);
        button6.TabIndex = 9;
        button6.Text = "Danh sách khách hàng";
        button6.TextAlign = ContentAlignment.MiddleLeft;
        button6.TextImageRelation = TextImageRelation.ImageBeforeText;
        button6.UseVisualStyleBackColor = false;
        button6.Click += button6_Click;
        // 
        // btnQuanLyPhong
        // 
        btnQuanLyPhong.BackColor = Color.DarkCyan;
        btnQuanLyPhong.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnQuanLyPhong.ForeColor = SystemColors.ButtonHighlight;
        btnQuanLyPhong.Image = AppResources.QuanLyPhong;
        btnQuanLyPhong.ImageAlign = ContentAlignment.MiddleLeft;
        btnQuanLyPhong.Location = new Point(0, 92);
        btnQuanLyPhong.Name = "btnQuanLyPhong";
        btnQuanLyPhong.Padding = new Padding(12, 0, 0, 0);
        btnQuanLyPhong.Size = new Size(240, 46);
        btnQuanLyPhong.TabIndex = 6;
        btnQuanLyPhong.Text = "Phòng";
        btnQuanLyPhong.TextAlign = ContentAlignment.MiddleLeft;
        btnQuanLyPhong.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnQuanLyPhong.UseVisualStyleBackColor = false;
        btnQuanLyPhong.Click += btnQuanLyPhong_Click;
        // 
        // button12
        // 
        button12.BackColor = Color.DarkCyan;
        button12.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button12.ForeColor = SystemColors.ButtonHighlight;
        button12.Image = AppResources.TienNghi;
        button12.ImageAlign = ContentAlignment.MiddleLeft;
        button12.Location = new Point(0, 322);
        button12.Name = "button12";
        button12.Padding = new Padding(12, 0, 0, 0);
        button12.Size = new Size(240, 46);
        button12.TabIndex = 15;
        button12.Text = "Danh sách tiện nghi";
        button12.TextAlign = ContentAlignment.MiddleLeft;
        button12.TextImageRelation = TextImageRelation.ImageBeforeText;
        button12.UseVisualStyleBackColor = false;
        button12.Click += button12_Click;
        // 
        // button11
        // 
        button11.BackColor = Color.DarkCyan;
        button11.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button11.ForeColor = SystemColors.ButtonHighlight;
        button11.Image = AppResources.DichVu;
        button11.ImageAlign = ContentAlignment.MiddleLeft;
        button11.Location = new Point(0, 276);
        button11.Name = "button11";
        button11.Padding = new Padding(12, 0, 0, 0);
        button11.Size = new Size(240, 46);
        button11.TabIndex = 14;
        button11.Text = "Danh sách dịch vụ";
        button11.TextAlign = ContentAlignment.MiddleLeft;
        button11.TextImageRelation = TextImageRelation.ImageBeforeText;
        button11.UseVisualStyleBackColor = false;
        button11.Click += button11_Click;
        // 
        // btnSoDoPhong
        // 
        btnSoDoPhong.AllowDrop = true;
        btnSoDoPhong.BackColor = Color.DarkCyan;
        btnSoDoPhong.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnSoDoPhong.ForeColor = SystemColors.ButtonHighlight;
        btnSoDoPhong.Image = AppResources.SoDoPhong;
        btnSoDoPhong.ImageAlign = ContentAlignment.MiddleLeft;
        btnSoDoPhong.Location = new Point(0, 46);
        btnSoDoPhong.Name = "btnSoDoPhong";
        btnSoDoPhong.Padding = new Padding(12, 0, 0, 0);
        btnSoDoPhong.Size = new Size(240, 46);
        btnSoDoPhong.TabIndex = 5;
        btnSoDoPhong.Text = "Sơ đồ phòng";
        btnSoDoPhong.TextAlign = ContentAlignment.MiddleLeft;
        btnSoDoPhong.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnSoDoPhong.UseVisualStyleBackColor = false;
        btnSoDoPhong.Click += btnSoDoPhong_Click;
        // 
        // button9
        // 
        button9.BackColor = Color.DarkCyan;
        button9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button9.ForeColor = SystemColors.ButtonHighlight;
        button9.Image = AppResources.DatPhong;
        button9.ImageAlign = ContentAlignment.MiddleLeft;
        button9.Location = new Point(0, 184);
        button9.Name = "button9";
        button9.Padding = new Padding(12, 0, 0, 0);
        button9.Size = new Size(240, 46);
        button9.TabIndex = 12;
        button9.Text = "Danh sách đặt phòng";
        button9.TextAlign = ContentAlignment.MiddleLeft;
        button9.TextImageRelation = TextImageRelation.ImageBeforeText;
        button9.UseVisualStyleBackColor = false;
        button9.Click += button9_Click;
        // 
        // button10
        // 
        button10.BackColor = Color.DarkCyan;
        button10.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button10.ForeColor = SystemColors.ButtonHighlight;
        button10.Image = AppResources.HoaDon;
        button10.ImageAlign = ContentAlignment.MiddleLeft;
        button10.Location = new Point(0, 230);
        button10.Name = "button10";
        button10.Padding = new Padding(12, 0, 0, 0);
        button10.Size = new Size(240, 46);
        button10.TabIndex = 13;
        button10.Text = "Danh sách hóa đơn";
        button10.TextAlign = ContentAlignment.MiddleLeft;
        button10.TextImageRelation = TextImageRelation.ImageBeforeText;
        button10.UseVisualStyleBackColor = false;
        button10.Click += button10_Click;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        BackgroundImageLayout = ImageLayout.None;
        ClientSize = new Size(1366, 800);
        Controls.Add(panelMain);
        Controls.Add(panelLeft);
        Controls.Add(panel1);
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Hotel Management";
        WindowState = FormWindowState.Maximized;
        Load += FormMain_Load;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        panelLeft.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        panel4.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private PictureBox pictureBox1;
    private Label labelTenKhachSan;
    private Panel panelLeft;
    private Panel panel2;
    private PictureBox pictureBox2;
    private LinkLabel linkLabel1;
    private Label lblTenNguoiDung;
    private Panel panelMain;
    private Panel panel4;
    private Button btnTrangChu;
    private Button btnSoDoPhong;
    private Button btnQuanLyPhong;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button9;
    private Button button10;
    private Button button11;
    private Button button12;
    private Button button13;
}
