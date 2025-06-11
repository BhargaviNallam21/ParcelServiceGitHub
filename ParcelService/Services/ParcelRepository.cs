using Microsoft.EntityFrameworkCore;
using ParcelService.Data;
using ParcelService.Models;

namespace ParcelService.Services
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly ParcelDbContext _context;

        public ParcelRepository(ParcelDbContext context)
        {
            _context = context;
        }

        public async Task<Parcel> GetByIdAsync(int id) =>
            await _context.Parcels.FindAsync(id);

        public async Task<Parcel> GetByTrackingNumberAsync(string trackingNumber) =>
            await _context.Parcels.FirstOrDefaultAsync(p => p.TrackingNumber == trackingNumber);

        public async Task<IEnumerable<Parcel>> GetAllAsync(int pageNumber, int pageSize) =>
            await _context.Parcels
                .OrderByDescending(p => p.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        public async Task<bool> ExistsByTrackingNumberAsync(string trackingNumber) =>
            await _context.Parcels.AnyAsync(p => p.TrackingNumber == trackingNumber);

        public async Task<Parcel> CreateAsync(Parcel parcel)
        {
            await _context.Parcels.AddAsync(parcel);
            await _context.SaveChangesAsync();
            return parcel;
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _context.Parcels.Remove(parcel);
            await _context.SaveChangesAsync();
        }
    }
}

