using MagicPlaces_API.Data;
using MagicPlaces_API.Models;
using MagicPlaces_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicPlaces_API.Repository
{
    public class PlacesRepository : Repository<Places>, IPlacesRepository
    {
        private readonly ApplicationDbContext _db;

        public PlacesRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Places> UpdateAsync(Places places)
        {
            places.LastDate = DateTime.Now;
            _db.Places.Update(places);
            await _db.SaveChangesAsync();
            return places;
        }
    }
}
