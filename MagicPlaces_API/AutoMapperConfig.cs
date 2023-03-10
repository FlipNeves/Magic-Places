using AutoMapper;
using MagicPlaces_API.Models;
using MagicPlaces_API.Models.DTO;

namespace MagicPlaces_API
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Places, PlacesDTO>().ReverseMap();
            CreateMap<Places, PlacesCreateDTO>().ReverseMap();  
            CreateMap<Places, PlacesUpdateDTO>().ReverseMap();
        }
    }
}
