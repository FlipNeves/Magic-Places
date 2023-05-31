namespace MagicPlaces_WEB.Models.DTO.Interfaces
{
    public interface IPlaceDetails
    {
        public string Name { get; set; }
        public string? Details { get; set; }
        public double Rate { get; set; }
        public string? Location { get; set; }
        public DateTime LastDate { get; set; }
        public string? Comment { get; set; }
    }
}
