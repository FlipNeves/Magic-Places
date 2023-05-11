using System.ComponentModel.DataAnnotations;

namespace MagicPlaces_API.Models.DTO
{
    public class PlaceNumberUpdateDTO
    {
        [Required]
        public int PlaceNo { get; set; }
        [Required]
        public int PlaceId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
