using thuchanh.Helpers;
using thuchanh.Models;
using Microsoft.EntityFrameworkCore;

namespace thuchanh.SoDoPhong;

public partial class FormSoDoPhong : Form
{
    private bool _dangKhoiTao;

    public FormSoDoPhong()
    {
        InitializeComponent();
    }

    private void FormSoDoPhong_Load(object? sender, EventArgs e)
    {
        Ui.StyleGrid(dataGridViewPhong);
        dataGridViewPhong.AutoGenerateColumns = true;
        dataGridViewPhong.DataBindingComplete += (_, _) => DatTieuDeCot();

        _dangKhoiTao = true;
        rdbTatCaTrangThaiPhong.Checked = true;
        rdbTatCaLoaiPhong.Checked = true;
        rdbTatCaPhong.Checked = true;
        dtNgayChon.Checked = false;
        _dangKhoiTao = false;

        TaiLaiDanhSach();
    }

    private void Radio_CheckedChanged(object? sender, EventArgs e)
    {
        if (_dangKhoiTao) return;
        if (sender is RadioButton rdb && !rdb.Checked) return;
        TaiLaiDanhSach();
    }

    private void txtSearchMaPhong_TextChanged(object? sender, EventArgs e)
    {
        if (_dangKhoiTao) return;
        TaiLaiDanhSach();
    }

    private void dtNgayChon_ValueChanged(object? sender, EventArgs e)
    {
        if (_dangKhoiTao) return;
        TaiLaiDanhSach();
    }

    private void btnDatPhong_Click(object? sender, EventArgs e)
    {
        string? maPhong = dataGridViewPhong.CurrentRow?.Cells["MaPH"].Value?.ToString();
        MessageBox.Show(
            "Chức năng đặt phòng đang được xây dựng."
            + (maPhong != null ? Environment.NewLine + "Phòng đang chọn: " + maPhong : ""),
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private string? TrangThaiPhongDangChon()
    {
        if (rdbPhongTrong.Checked) return "Bình thường";
        if (rdbPhongDaDat.Checked) return "Đã đặt";
        if (rdbPhongDangThue.Checked) return "Đang thuê";
        if (rdbPhongDangSuaChua.Checked) return "Đang sửa chữa";
        return null;
    }

    private string? MaLoaiPhongDangChon()
    {
        if (rdbPhongThuongDon.Checked) return "NOR01";
        if (rdbPhongThuongDoi.Checked) return "NOR02";
        if (rdbPhongVipDon.Checked) return "VIP01";
        if (rdbPhongVipDoi.Checked) return "VIP02";
        return null;
    }

    private string? TinhTrangDonDepDangChon()
    {
        if (rdbPhongDaDonDep.Checked) return "Đã dọn dẹp";
        if (rdbPhongChuaDon.Checked) return "Chưa dọn dẹp";
        return null;
    }

    private void TaiLaiDanhSach()
    {
        try
        {
            string? ttph = TrangThaiPhongDangChon();
            string? maLph = MaLoaiPhongDangChon();
            string? ttdd = TinhTrangDonDepDangChon();
            string maPhong = txtSearchMaPhong.Text.Trim();

            using var db = new HotelManagementContext();
            var query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);

            if (ttph != null) query = query.Where(p => p.Ttph == ttph);
            if (maLph != null) query = query.Where(p => p.MaLph == maLph);
            if (ttdd != null) query = query.Where(p => p.Ttdd == ttdd);
            if (maPhong.Length > 0) query = query.Where(p => p.MaPh.Contains(maPhong));

            if (dtNgayChon.Checked)
            {
                DateTime ngayChon = dtNgayChon.Value.Date;
                query = query.Where(p => p.Ttph == "Bình thường"
                    && !p.Ctdps.Any(c => c.DaXoa != true
                        && ngayChon >= c.CheckIn.Date
                        && ngayChon < c.CheckOut.Date));
            }

            var dsPhong = query
                .OrderBy(p => p.MaPh)
                .Select(p => new
                {
                    p.MaPh,
                    TenLph = p.MaLphNavigation.TenLph,
                    p.Ttph,
                    p.Ttdd,
                    p.GhiChu
                })
                .ToList();

            dataGridViewPhong.DataSource = dsPhong
                .Select(p => new
                {
                    MaPH = p.MaPh,
                    TenLPH = p.TenLph,
                    TTPH = p.Ttph,
                    TTDD = p.Ttdd,
                    GhiChu = p.GhiChu
                })
                .ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DatTieuDeCot()
    {
        DatTieuDe("MaPH", "Mã phòng");
        DatTieuDe("TenLPH", "Loại phòng");
        DatTieuDe("TTPH", "Trạng thái phòng");
        DatTieuDe("TTDD", "Tình trạng dọn dẹp");
        DatTieuDe("GhiChu", "Ghi chú");
    }

    private void DatTieuDe(string tenCot, string tieuDe)
    {
        if (dataGridViewPhong.Columns.Contains(tenCot))
            dataGridViewPhong.Columns[tenCot].HeaderText = tieuDe;
    }

    private void dataGridViewPhong_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.Value == null) return;
        if (dataGridViewPhong.Columns[e.ColumnIndex].Name != "TTPH") return;

        e.CellStyle.ForeColor = e.Value.ToString() switch
        {
            "Bình thường" => Color.FromArgb(22, 163, 74),
            "Đang thuê" => Color.FromArgb(234, 88, 12),
            "Đã đặt" => Color.FromArgb(147, 51, 234),
            "Đang sửa chữa" => Color.FromArgb(220, 38, 38),
            _ => Ui.TextDark
        };
    }
}
