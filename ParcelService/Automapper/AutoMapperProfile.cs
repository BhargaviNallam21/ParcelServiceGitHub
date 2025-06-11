using AutoMapper;
using ParcelService.DTO;
using ParcelService.Models;

namespace ParcelService.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Parcel, ParcelDTO>();
            CreateMap<CreateParcelDTO, Parcel>();
            CreateMap<UpdateParcelDTO, Parcel>();
        }
    }
}
