using thuchanh.Helpers;

namespace thuchanh.LoaiPhong;

partial class FormDanhSachLoaiPhong
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
        dtgDanhSachLoaiPhong = new DataGridView();
        btnXuatExcel = new Button();
        txtTimKiem = new TextBox();
        pictureBox1 = new PictureBox();
        btnThemMoi = new Button();
        ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // dtgDanhSachLoaiPhong
        // 
        dtgDanhSachLoaiPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dtgDanhSachLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dtgDanhSachLoaiPhong.Location = new Point(12, 66);
        dtgDanhSachLoaiPhong.Name = "dtgDanhSachLoaiPhong";
        dtgDanhSachLoaiPhong.RowHeadersWidth = 51;
        dtgDanhSachLoaiPhong.RowTemplate.Height = 24;
        dtgDanhSachLoaiPhong.Size = new Size(924, 605);
        dtgDanhSachLoaiPhong.TabIndex = 9;
        dtgDanhSachLoaiPhong.CellClick += dtgDanhSachLoaiPhong_CellClick;
        // 
        // btnXuatExcel
        // 
        btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnXuatExcel.BackColor = Color.DarkTurquoise;
        btnXuatExcel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnXuatExcel.Location = new Point(546, 12);
        btnXuatExcel.Name = "btnXuatExcel";
        btnXuatExcel.Size = new Size(167, 37);
        btnXuatExcel.TabIndex = 7;
        btnXuatExcel.Text = "Xuất file Excel";
        btnXuatExcel.UseVisualStyleBackColor = false;
        btnXuatExcel.Click += btnXuatExcel_Click;
        // 
        // txtTimKiem
        // 
        txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtTimKiem.Location = new Point(105, 17);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Tìm mã hoặc tên loại...";
        txtTimKiem.Size = new Size(187, 32);
        txtTimKiem.TabIndex = 5;
        txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        pictureBox1.Image = AppResources.TimKiem2;
        pictureBox1.Location = new Point(60, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(39, 37);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 6;
        pictureBox1.TabStop = false;
        // 
        // btnThemMoi
        // 
        btnThemMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemMoi.BackColor = Color.LightPink;
        btnThemMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnThemMoi.Location = new Point(747, 12);
        btnThemMoi.Name = "btnThemMoi";
        btnThemMoi.Size = new Size(167, 37);
        btnThemMoi.TabIndex = 10;
        btnThemMoi.Text = "Thêm mới";
        btnThemMoi.UseVisualStyleBackColor = false;
        btnThemMoi.Click += btnThemMoi_Click;
        // 
        // FormDanhSachLoaiPhong
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(948, 683);
        Controls.Add(btnThemMoi);
        Controls.Add(dtgDanhSachLoaiPhong);
        Controls.Add(btnXuatExcel);
        Controls.Add(pictureBox1);
        Controls.Add(txtTimKiem);
        Name = "FormDanhSachLoaiPhong";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý thông tin loại phòng";
        Load += FormDanhSachLoaiPhong_Load;
        ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dtgDanhSachLoaiPhong;
    private Button btnXuatExcel;
    private PictureBox pictureBox1;
    private TextBox txtTimKiem;
    private Button btnThemMoi;
}
