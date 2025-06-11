using ParcelService.Models;

namespace ParcelService.Services
{
    public interface IParcelRepository
    {

        Task<Parcel> GetByIdAsync(int id);
        Task<IEnumerable<Parcel>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> ExistsByTrackingNumberAsync(string trackingNumber);
        Task<Parcel> CreateAsync(Parcel parcel);
        Task UpdateAsync(Parcel parcel);
        Task DeleteAsync(Parcel parcel);
        Task<Parcel> GetByTrackingNumberAsync(string trackingNumber);
        //Task<ParcelDTO> GetParcelBYID(int id);
        //Task<IEnumerable<ParcelDTO>> GetAllParcels(int pagenumber, int pagesize);
        ////  Task<bool> ExistsByTrackingNumberAsync(string trackingNumber);
        //Task<ParcelDTO> createparcel(CreateParcelDTO dto);
        //Task updateparcel(string trackingnumber, UpdateParcelDTO dTO);
        //Task DeleteAsync(Parcel parcel);
        //  Task<Parcel> GetByTrackingNumberAsync(string trackingNumber);

        //Task deleteparcel(int id);

    }
}
