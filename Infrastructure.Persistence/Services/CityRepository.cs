using Core.Application.Interface.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDBContext _context;

        public CityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.State)
                .ThenInclude(s => s.Country)
                .ToListAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.Cities
                .Include(c => c.State)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
    }
}
