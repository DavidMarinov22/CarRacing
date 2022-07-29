using Microsoft.EntityFrameworkCore;
using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> option) : base(option)
        {
        }

        public DbSet<PilotVM> Pilots { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Race> Races { get; set; }

    }
}
