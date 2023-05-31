using MagicPlaces_WEB.Models.DTO;

namespace MagicPlaces_WEB.Services.IServices
{
    public interface IPlacesService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PlacesCreateDTO dtoPlaces);
        Task<T> UpdateAsync<T>(PlacesUpdateDTO dtoPlaces);
        Task<T> DeleteAsync<T>(int id);
    }
}
