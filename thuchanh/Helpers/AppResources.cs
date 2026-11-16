using System.Drawing;

namespace thuchanh.Helpers;

// Nạp hình ảnh trong thư mục Resources (được copy ra thư mục chạy) thay cho Properties.Resources.
public static class AppResources
{
    private static readonly Dictionary<string, Image?> Cache = new();

    public static Image? Get(string ten)
    {
        if (Cache.TryGetValue(ten, out var cached))
            return cached;

        Image? image = null;
        string path = Path.Combine(AppContext.BaseDirectory, "Resources", ten + ".png");
        if (File.Exists(path))
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            image = Image.FromStream(stream);
        }

        Cache[ten] = image;
        return image;
    }

    public static Image? DangNhap => Get("DangNhap");
    public static Image? PictureIcon => Get("pictureIcon");
    public static Image? Logo => Get("Menu");
    public static Image? NguoiDungAnh => Get("user");
    public static Image? TimKiem2 => Get("search");
    public static Image? Phong => Get("Phong");
    public static Image? Sua => Get("edit");
    public static Image? Xoa => Get("delete");
    public static Image? Giuong => Get("Giuong");
    public static Image? ChiTiet => Get("details");
    public static Image? TimKiem => Get("search");
    public static Image? Them => Get("Add");
    public static Image? Excel => Get("database");
    public static Image? TrangChu => Get("MenuTrangChu");
    public static Image? SoDoPhong => Get("MenuSoDoPhong");
    public static Image? QuanLyPhong => Get("MenuPhong");
    public static Image? LoaiPhong => Get("MenuLoaiPhong");
    public static Image? DichVu => Get("MenuQuanLyDichVu");
    public static Image? TienNghi => Get("MenuTienNghi");
    public static Image? KhachHang => Get("MenuQuanLyKhachHang");
    public static Image? NhanVien => Get("MenuQuanLyNhanVien");
    public static Image? TaiKhoan => Get("MenuQuanLyTaiKhoan");
    public static Image? DatPhong => Get("MenuDatPhong");
    public static Image? HoaDon => Get("MenuDanhSachHoaDon");
    public static Image? ThongKe => Get("MenuThongKe");
    public static Image? NguoiDung => Get("admin");
}
