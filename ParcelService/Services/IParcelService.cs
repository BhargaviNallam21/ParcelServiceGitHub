using ParcelService.DTO;

namespace ParcelService.Services
{
    public interface IParcelService
    {
        Task<IEnumerable<ParcelDTO>> GetAllParcels(int pagenumber, int pagesize);
        Task<ParcelDTO> GetParcelBYID(int id);
        Task<ParcelDTO> createparcel(CreateParcelDTO dto);
        Task updateparcel(string trackingnumber, UpdateParcelDTO dTO);
        Task deleteparcel(int id);


    }
}
