using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlarmService.Data
{
    public class AlarmDbContextFactory
            : IDesignTimeDbContextFactory<AlarmDbContext>
    {
        public AlarmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<AlarmDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AlarmDB;Trusted_Connection=True;");

            return new AlarmDbContext(
                optionsBuilder.Options);
        }
    }
}
