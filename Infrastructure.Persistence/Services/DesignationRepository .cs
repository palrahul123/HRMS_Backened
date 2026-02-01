using Core.Application.Interface.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services;

public class DesignationRepository : IDesignationRepository
{
    private readonly ApplicationDBContext _context;

    public DesignationRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Designation>> GetAllAsync()
    {
        return await _context.Designations
            .Include(x => x.Department)
            .ToListAsync();
    }

    public async Task<Designation?> GetByIdAsync(int id)
    {
        return await _context.Designations
            .Include(x => x.Department)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Designation designation)
    {
        await _context.Designations.AddAsync(designation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Designation designation)
    {
        _context.Designations.Update(designation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Designation designation)
    {
        _context.Designations.Remove(designation);
        await _context.SaveChangesAsync();
    }
}

