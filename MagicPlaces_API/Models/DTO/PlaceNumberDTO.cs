using System.ComponentModel.DataAnnotations;

namespace MagicPlaces_API.Models.DTO
{
    public class PlacesNumberDTO
    {
        [Required]
        public int PlaceNo { get; set; }
        [Required]
        public int PlaceId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
