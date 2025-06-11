using Microsoft.EntityFrameworkCore;
using ParcelService.Models;

namespace ParcelService.Data
{
    public class ParcelDbContext : DbContext
    {
        public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
        {

        }
        public DbSet<Parcel> Parcels { get; set; }
    }
}
