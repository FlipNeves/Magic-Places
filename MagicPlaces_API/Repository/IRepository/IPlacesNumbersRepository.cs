using MagicPlaces_API.Models;
using System.Linq.Expressions;

namespace MagicPlaces_API.Repository.IRepository
{
    public interface IPlacesNumbersRepository : IRepository<PlacesNumber>
    {
        Task<PlacesNumber> UpdateAsync(PlacesNumber placesNumber);
    }
}
