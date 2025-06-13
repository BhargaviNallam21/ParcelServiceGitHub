using Microsoft.EntityFrameworkCore;
using ParcelService.Models;

namespace ParcelService.Data
{
    public class ParcelDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>().ToTable("Parcels");
        }
        public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
        {

        }
        public DbSet<Parcel> Parcels { get; set; }

    }
}
