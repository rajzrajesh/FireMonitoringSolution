using AlarmService.Models;
using Microsoft.EntityFrameworkCore;

namespace AlarmService.Data
{
    public class AlarmDbContext : DbContext
    {
        public AlarmDbContext(
            DbContextOptions<AlarmDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alarm> Alarms { get; set; }
    }
}
