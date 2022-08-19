using System.ComponentModel.DataAnnotations;

namespace MagicPlaces_API.Models.DTO
{
    public class PlacesDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string Name { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }
    }
}
