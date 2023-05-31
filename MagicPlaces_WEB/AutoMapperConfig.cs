using AutoMapper;
using MagicPlaces_WEB.Models;
using MagicPlaces_WEB.Models.DTO;

namespace MagicPlaces_WEB
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PlacesCreateDTO, PlacesDTO>().ReverseMap();
            CreateMap<PlacesUpdateDTO, PlacesDTO>().ReverseMap();
            CreateMap<PlacesCreateDTO, PlacesNumberDTO>().ReverseMap();
            CreateMap<PlacesUpdateDTO, PlacesNumberDTO>().ReverseMap();
        }
    }
}
