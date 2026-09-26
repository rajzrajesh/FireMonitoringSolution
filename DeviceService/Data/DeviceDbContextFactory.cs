using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DeviceService.Data
{
    namespace DeviceService.Data
    {
        public class DeviceDbContextFactory
            : IDesignTimeDbContextFactory<DeviceDbContext>
        {
            public DeviceDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder =
                    new DbContextOptionsBuilder<DeviceDbContext>();

                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=DeviceDB;Trusted_Connection=True;");

                return new DeviceDbContext(
                    optionsBuilder.Options);
            }
        }
    }
}
