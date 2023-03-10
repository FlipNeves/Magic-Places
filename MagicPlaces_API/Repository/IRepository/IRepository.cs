using System.Linq.Expressions;

namespace MagicPlaces_API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T places);
        Task RemoveAsync(T places);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task SaveAsync();
    }
}
