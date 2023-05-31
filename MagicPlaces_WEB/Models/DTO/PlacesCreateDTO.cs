using MagicPlaces_WEB.Models.DTO.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MagicPlaces_WEB.Models.DTO
{
    public class PlacesCreateDTO : IPlaceDetails
    {
        [Required]
        public string Name { get; set; }
        public string? Details { get; set; }
        public double Rate { get; set; }
        public string? Location { get; set; }
        public DateTime LastDate { get; set; }
        public string? Comment { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
