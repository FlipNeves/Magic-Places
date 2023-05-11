using System.ComponentModel.DataAnnotations;

namespace MagicPlaces_API.Models.DTO
{
    public class PlacesUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime LastDate { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
