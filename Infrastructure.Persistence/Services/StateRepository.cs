using Core.Application.Interface.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDBContext _context;

        public StateRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States
                .Include(s => s.Country)
                .ToListAsync();
        }

        public async Task<State?> GetByIdAsync(int id)
        {
            return await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }
    }
}
