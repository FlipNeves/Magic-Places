using MagicPlaces_API.Data;
using MagicPlaces_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicPlaces_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            var placesLoaded = await LoadEntity(filter);

            return await placesLoaded.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            var placesLoaded = await LoadEntity(filter);

            if (!tracked)
            {
                placesLoaded = placesLoaded.AsNoTracking();
            }

            return await placesLoaded.FirstOrDefaultAsync();
        }

        public Task RemoveAsync(T entity)
        {
            if (entity == null)
            {
                return Task.CompletedTask;
            }

            dbSet.Remove(entity);
            return SaveAsync();
        }

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        private async Task<IQueryable<T>> LoadEntity(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

    }
}
