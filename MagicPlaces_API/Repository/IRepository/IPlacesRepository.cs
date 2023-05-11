using MagicPlaces_API.Models;
using System.Linq.Expressions;

namespace MagicPlaces_API.Repository.IRepository
{
    public interface IPlacesRepository : IRepository<Places>
    {
        Task<Places> UpdateAsync(Places places);
    }
}
