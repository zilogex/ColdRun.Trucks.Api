using ColdRun.Trucks.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColdRun.Trucks.Infrastructure
{


    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
          
        }

        public DbSet<Truck> Trucks { get; set; }

    }
}