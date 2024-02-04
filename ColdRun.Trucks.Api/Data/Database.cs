using ColdRun.Trucks.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ColdRun.Trucks.Api.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Truck> Trucks => Set<Truck>();

    }
}