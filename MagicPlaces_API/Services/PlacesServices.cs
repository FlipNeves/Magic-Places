using AutoMapper;
using MagicPlaces_API.Models.DTO;
using MagicPlaces_API.Repository.IRepository;

namespace MagicPlaces_API.Services
{
    public class PlacesServices : IPlaces
    {
        private readonly IPlacesRepository _dbPlaces;
        private readonly IMapper _mapper;

        public PlacesServices(IPlacesRepository db, IMapper mapper)
        {
            _dbPlaces = db;
            _mapper = mapper;
        }
        public List<PlacesDTO> GetBestPlaces()
        {

            var bestPlaces = _dbPlaces.Search(x => x.Rate >= 8);
            if(bestPlaces.Count() >= 5)
                bestPlaces = bestPlaces.Take(5);

            return _mapper.Map<List<PlacesDTO>>(bestPlaces.ToList());
        }
    }
}
