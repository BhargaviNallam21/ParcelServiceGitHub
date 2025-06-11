using AutoMapper;
using ParcelService.CutomErrorHandler;
using ParcelService.DTO;
using ParcelService.Models;

namespace ParcelService.Services
{
    public class ParcelServicecls : IParcelService
    {
        private readonly IParcelRepository _repository;
        private readonly IMapper _mapper;

        //  private readonly ILogger<ParcelServicecls> _logger;

        public ParcelServicecls(IParcelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ParcelDTO> GetParcelBYID(int id)
        {
            var parcels = await _repository.GetByIdAsync(id);
            if (parcels == null)
                throw new NotFoundException($"Parcel with ID {id} not found");
            return _mapper.Map<ParcelDTO>(parcels);



        }
        public async Task<IEnumerable<ParcelDTO>> GetAllParcels(int pagenumber, int pagesize)
        {
            var parcels = await _repository.GetAllAsync(pagenumber, pagesize);

            return _mapper.Map<List<ParcelDTO>>(parcels);
        }
        public async Task<ParcelDTO> createparcel(CreateParcelDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.TrackingNumber))
                throw new BadRequestException("Tracking Number is required");

            bool exists = await _repository.ExistsByTrackingNumberAsync(dto.TrackingNumber);
            if (exists)
            {
                throw new BadRequestException("Tracking Number already exists");
            }
            var parcel = _mapper.Map<Parcel>(dto);
            parcel.CreatedDate = DateTime.UtcNow;
            var result = await _repository.CreateAsync(parcel);
            return _mapper.Map<ParcelDTO>(result);

        }


        public async Task updateparcel(string trackingnumber, UpdateParcelDTO dto)
        {
            var data = await _repository.GetByTrackingNumberAsync(trackingnumber);
            if (data == null)
                throw new NotFoundException($"cannot update. Parcel with ID {trackingnumber} doesnot exist");

            _mapper.Map(dto, data);

            await _repository.UpdateAsync(data);
        }
        public async Task deleteparcel(int id)
        {
            var parcel = await _repository.GetByIdAsync(id);

            if (parcel == null)
            {
                // Optionally log this
                throw new NotFoundException("Parcel not found");
            }

            await _repository.DeleteAsync(parcel);

            Console.WriteLine("successfully deleted");

        }




    }
}
