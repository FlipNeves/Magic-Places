using MagicPlaces_API.Data;
using MagicPlaces_API.Models;
using MagicPlaces_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicPlaces_API.Repository
{
    public class PlacesNumbersRepository : Repository<PlacesNumber>, IPlacesNumbersRepository
    {
        private readonly ApplicationDbContext _db;

        public PlacesNumbersRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<PlacesNumber> UpdateAsync(PlacesNumber placesNumber)
        {
            placesNumber.UpdatedDate = DateTime.Now;
            _db.PlacesNumbers.Update(placesNumber);
            await _db.SaveChangesAsync();
            return placesNumber;
        }
    }
}
