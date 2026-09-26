using DeviceService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceService.Data;

public class DeviceDbContext : DbContext
{
    public DeviceDbContext(
        DbContextOptions<DeviceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
}