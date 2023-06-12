using MagicPlaces_API.Models.DTO;

namespace MagicPlaces_API.Services
{
    public interface IPlaces
    {
        List<PlacesDTO> GetBestPlaces();
    }
}