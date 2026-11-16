using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using thuchanh.Helpers;
using thuchanh.Models;

namespace thuchanh.LoaiPhong;

public partial class FormDanhSachLoaiPhong : Form
{
    public FormDanhSachLoaiPhong()
    {
        InitializeComponent();
    }

    private void FormDanhSachLoaiPhong_Load(object? sender, EventArgs e)
    {
        Ui.StyleGrid(dtgDanhSachLoaiPhong);
        CauHinhLuoi();
        LoadLoaiPhong();
    }

    private void CauHinhLuoi()
    {
        if (dtgDanhSachLoaiPhong.Columns.Count > 0)
            return;

        dtgDanhSachLoaiPhong.Columns.Add(Ui.ImageColumn("colIcon", "", AppResources.Giuong));
        dtgDanhSachLoaiPhong.Columns.Add("MaLPH", "Mã loại");
        dtgDanhSachLoaiPhong.Columns.Add("TenLPH", "Tên loại");
        dtgDanhSachLoaiPhong.Columns.Add("SoGiuong", "Số giường");
        dtgDanhSachLoaiPhong.Columns.Add("SoNguoiToiDa", "Số người tối đa");
        dtgDanhSachLoaiPhong.Columns.Add("GiaNgay", "Giá ngày");
        dtgDanhSachLoaiPhong.Columns.Add("GiaGio", "Giá giờ");

        dtgDanhSachLoaiPhong.Columns["GiaNgay"].DefaultCellStyle.Format = "N0";
        dtgDanhSachLoaiPhong.Columns["GiaGio"].DefaultCellStyle.Format = "N0";
        dtgDanhSachLoaiPhong.Columns["GiaNgay"].DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight;
        dtgDanhSachLoaiPhong.Columns["GiaGio"].DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight;
        dtgDanhSachLoaiPhong.Columns["TenLPH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        dtgDanhSachLoaiPhong.Columns.Add(Ui.ImageColumn("colTienNghi", "Tiện nghi", AppResources.ChiTiet, 70));
        dtgDanhSachLoaiPhong.Columns.Add(Ui.ImageColumn("colSua", "Cập nhật", AppResources.Sua, 80));
    }

    private void LoadLoaiPhong()
    {
        try
        {
            using var db = new HotelManagementContext();
            var dsLoaiPhong = db.LoaiPhongs
                .AsNoTracking()
                .OrderBy(l => l.MaLph)
                .Select(l => new
                {
                    l.MaLph,
                    l.TenLph,
                    l.SoGiuong,
                    l.SoNguoiToiDa,
                    l.GiaNgay,
                    l.GiaGio
                })
                .ToList();

            dtgDanhSachLoaiPhong.Rows.Clear();
            foreach (var l in dsLoaiPhong)
            {
                dtgDanhSachLoaiPhong.Rows.Add(
                    AppResources.Giuong,
                    l.MaLph,
                    l.TenLph,
                    l.SoGiuong,
                    l.SoNguoiToiDa,
                    l.GiaNgay,
                    l.GiaGio,
                    AppResources.ChiTiet,
                    AppResources.Sua);
            }

            LocTheoTuKhoa();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải loại phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LocTheoTuKhoa()
    {
        string keyword = txtTimKiem.Text.Trim();
        dtgDanhSachLoaiPhong.CurrentCell = null;

        foreach (DataGridViewRow row in dtgDanhSachLoaiPhong.Rows)
        {
            string ma = row.Cells["MaLPH"].Value?.ToString() ?? "";
            string ten = row.Cells["TenLPH"].Value?.ToString() ?? "";
            row.Visible = keyword.Length == 0
                || ma.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || ten.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }
    }

    private void txtTimKiem_TextChanged(object? sender, EventArgs e)
    {
        LocTheoTuKhoa();
    }

    private void btnThemMoi_Click(object? sender, EventArgs e)
    {
        using (var formThemLoaiPhong = new FormThemLoaiPhong())
        {
            formThemLoaiPhong.ShowDialog(this);
        }

        LoadLoaiPhong();
    }

    private void dtgDanhSachLoaiPhong_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        var dong = dtgDanhSachLoaiPhong.Rows[e.RowIndex];
        string? maLPH = dong.Cells["MaLPH"].Value?.ToString();
        string? tenLPH = dong.Cells["TenLPH"].Value?.ToString();
        if (string.IsNullOrEmpty(maLPH))
            return;

        string tenCot = dtgDanhSachLoaiPhong.Columns[e.ColumnIndex].Name;

        if (tenCot == "colSua")
        {
            using (var formSua = new FormSuaLoaiPhong())
            {
                formSua.MaLoaiPhong = maLPH;
                formSua.ShowDialog(this);
            }

            LoadLoaiPhong();
        }
        else if (tenCot == "colTienNghi")
        {
            MessageBox.Show(
                $"Chức năng chi tiết tiện nghi của loại phòng {tenLPH} ({maLPH}) đang được xây dựng.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnXuatExcel_Click(object? sender, EventArgs e)
    {
        var cacDong = dtgDanhSachLoaiPhong.Rows.Cast<DataGridViewRow>()
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
            Title = "Xuất danh sách loại phòng",
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachLoaiPhong_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };

        if (hopLuu.ShowDialog() != DialogResult.OK)
            return;

        try
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Danh sách loại phòng");
                string[] tenCot = { "MaLPH", "TenLPH", "SoGiuong", "SoNguoiToiDa", "GiaNgay", "GiaGio" };

                for (int c = 0; c < tenCot.Length; c++)
                    ws.Cell(1, c + 1).Value = dtgDanhSachLoaiPhong.Columns[tenCot[c]].HeaderText;
                ws.Row(1).Style.Font.Bold = true;

                for (int i = 0; i < cacDong.Count; i++)
                {
                    for (int c = 0; c < tenCot.Length; c++)
                    {
                        var o = ws.Cell(i + 2, c + 1);
                        object? giaTri = cacDong[i].Cells[tenCot[c]].Value;

                        switch (giaTri)
                        {
                            case decimal d:
                                o.Value = d;
                                o.Style.NumberFormat.Format = "#,##0";
                                break;
                            case int n:
                                o.Value = n;
                                break;
                            default:
                                o.Value = giaTri?.ToString() ?? "";
                                break;
                        }
                    }
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
}
