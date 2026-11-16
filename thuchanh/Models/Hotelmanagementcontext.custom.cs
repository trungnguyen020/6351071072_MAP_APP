using Microsoft.EntityFrameworkCore;

namespace thuchanh.Models;

// File riêng (partial) để khi scaffold lại DB, EF Core Power Tools không ghi đè cấu hình kết nối.
public partial class HotelManagementContext
{
    private const string ConnectionString =
        "Server=DESKTOP-A0JADBQ;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;";

    public HotelManagementContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(ConnectionString);
    }
}
