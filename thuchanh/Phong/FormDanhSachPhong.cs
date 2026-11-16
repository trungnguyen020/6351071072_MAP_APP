using ClosedXML.Excel;
using thuchanh.Helpers;
using thuchanh.Models;
using Microsoft.EntityFrameworkCore;

namespace thuchanh.Phong;

public partial class FormDanhSachPhong : Form
{
    public FormDanhSachPhong()
    {
        InitializeComponent();
    }

    private void FormDanhSachPhong_Load(object? sender, EventArgs e)
    {
        Ui.StyleGrid(dtgDanhSachPhong);
        CauHinhLuoi();
        LoadDanhSachPhong();
    }

    private void CauHinhLuoi()
    {
        if (dtgDanhSachPhong.Columns.Count > 0)
            return;

        dtgDanhSachPhong.Columns.Add(Ui.ImageColumn("colIcon", "", AppResources.Phong));
        dtgDanhSachPhong.Columns.Add("MaPH", "Mã phòng");
        dtgDanhSachPhong.Columns.Add("TTPH", "Tình trạng phòng");
        dtgDanhSachPhong.Columns.Add("TTDD", "Dọn dẹp");
        dtgDanhSachPhong.Columns.Add("TenLPH", "Loại phòng");
        dtgDanhSachPhong.Columns.Add(Ui.ImageColumn("colSua", "Sửa", AppResources.Sua));
        dtgDanhSachPhong.Columns.Add(Ui.ImageColumn("colXoa", "Xóa", AppResources.Xoa));

        if (dtgDanhSachPhong.Columns.Contains("MaPH"))
            dtgDanhSachPhong.Columns["MaPH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

    private void LoadDanhSachPhong()
    {
        try
        {
            using var db = new HotelManagementContext();
            var dsPhong = db.Phongs
                .AsNoTracking()
                .Where(p => p.DaXoa != true)
                .OrderBy(p => p.MaPh)
                .Select(p => new
                {
                    p.MaPh,
                    p.Ttph,
                    p.Ttdd,
                    TenLph = p.MaLphNavigation.TenLph
                })
                .ToList();

            dtgDanhSachPhong.Rows.Clear();
            foreach (var p in dsPhong)
            {
                dtgDanhSachPhong.Rows.Add(
                    AppResources.Phong,
                    p.MaPh,
                    p.Ttph,
                    p.Ttdd,
                    p.TenLph,
                    AppResources.Sua,
                    AppResources.Xoa);
            }

            LocTheoTuKhoa();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LocTheoTuKhoa()
    {
        string keyword = txtTimKiem.Text.Trim();
        dtgDanhSachPhong.CurrentCell = null;

        foreach (DataGridViewRow row in dtgDanhSachPhong.Rows)
        {
            string maPhong = row.Cells["MaPH"].Value?.ToString() ?? "";
            row.Visible = keyword.Length == 0
                || maPhong.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }
    }

    private void txtTimKiem_TextChanged(object? sender, EventArgs e)
    {
        LocTheoTuKhoa();
    }

    private void btnThemMoiPhong_Click(object? sender, EventArgs e)
    {
        using (var form = new FormThemPhong())
        {
            form.ShowDialog(this);
        }

        LoadDanhSachPhong();
    }

    private void dtgDanhSachPhong_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        string? maPhong = dtgDanhSachPhong.Rows[e.RowIndex].Cells["MaPH"].Value?.ToString();
        if (string.IsNullOrEmpty(maPhong))
            return;

        string tenCot = dtgDanhSachPhong.Columns[e.ColumnIndex].Name;

        if (tenCot == "colSua")
        {
            using (var formSua = new FormSuaPhong(maPhong))
            {
                formSua.ShowDialog(this);
            }
            LoadDanhSachPhong();
        }
        else if (tenCot == "colXoa")
        {
            if (MessageBox.Show($"Bạn có chắc muốn xóa phòng {maPhong} không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            XoaPhong(maPhong);
            LoadDanhSachPhong();
        }
    }

    private void XoaPhong(string maPhong)
    {
        try
        {
            using var db = new HotelManagementContext();
            var phong = db.Phongs.FirstOrDefault(p => p.MaPh == maPhong && p.DaXoa != true);
            if (phong == null)
            {
                MessageBox.Show("Không tìm thấy phòng để xóa.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (phong.Ttph == "Đang thuê" || phong.Ttph == "Đã đặt")
            {
                MessageBox.Show($"Phòng {maPhong} đang ở trạng thái \"{phong.Ttph}\" nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            phong.DaXoa = true;
            db.SaveChanges();

            MessageBox.Show("Đã xóa phòng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXuatExcel_Click(object? sender, EventArgs e)
    {
        var cacDong = dtgDanhSachPhong.Rows.Cast<DataGridViewRow>()
            .Where(r => r.Visible && !r.IsNewRow)
            .ToList();

        if (cacDong.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var hopLuu = new SaveFileDialog
        {
            Title = "Xuất danh sách phòng",
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachPhong_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };

        if (hopLuu.ShowDialog() != DialogResult.OK)
            return;

        try
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Danh sách phòng");
                string[] tenCot = { "MaPH", "TTPH", "TTDD", "TenLPH" };
                string[] tieuDe = { "Mã phòng", "Tình trạng phòng", "Dọn dẹp", "Loại phòng" };

                for (int c = 0; c < tenCot.Length; c++)
                    ws.Cell(1, c + 1).Value = tieuDe[c];
                ws.Row(1).Style.Font.Bold = true;

                for (int i = 0; i < cacDong.Count; i++)
                {
                    for (int c = 0; c < tenCot.Length; c++)
                        ws.Cell(i + 2, c + 1).Value = cacDong[i].Cells[tenCot[c]].Value?.ToString() ?? "";
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(hopLuu.FileName);
            }

            if (MessageBox.Show("Xuất dữ liệu thành công!\nBạn có muốn mở file ngay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(hopLuu.FileName)
                {
                    UseShellExecute = true
                });
            }
        }
        catch (IOException)
        {
            MessageBox.Show("Không ghi được file. Có thể file đang mở trong Excel, hãy đóng lại rồi thử lần nữa.",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dtgDanhSachPhong_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        string tenCot = dtgDanhSachPhong.Columns[e.ColumnIndex].Name;
        if ((tenCot != "TTPH" && tenCot != "TTDD") || e.Value == null)
            return;

        e.CellStyle.ForeColor = e.Value.ToString() switch
        {
            "Bình thường" => Color.FromArgb(22, 163, 74),
            "Đã dọn dẹp" => Color.FromArgb(22, 163, 74),
            "Đang thuê" => Color.FromArgb(234, 88, 12),
            "Đã đặt" => Color.FromArgb(147, 51, 234),
            "Đang sửa chữa" => Color.FromArgb(220, 38, 38),
            "Chưa dọn dẹp" => Color.FromArgb(217, 119, 6),
            _ => Ui.TextDark
        };
    }
}
