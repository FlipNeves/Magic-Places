using MagicPlaces_API.Models.DTO;

namespace MagicPlaces_API.Data
{
    public class PlaceStore
    {
        public static List<PlacesDTO> PlacesList = new List<PlacesDTO>
        {
            new PlacesDTO { Id = 1, Name = "Tavernna", Value = 180.00, Comment = "Muito bom, medieval."},
            new PlacesDTO { Id = 2, Name = "Hambuguer de praça", Value = 80.30, Comment = "Ambiente fresco e muito gostoso." }
        };
    }
}
