using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicPlaces_API.Models
{
    public class PlacesNumber2
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaceNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
