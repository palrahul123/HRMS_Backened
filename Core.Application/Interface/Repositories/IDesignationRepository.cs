using Core.Domain;

namespace Core.Application.Interface.Repositories;

public interface IDesignationRepository
{
    Task<IEnumerable<Designation>> GetAllAsync();
    Task<Designation?> GetByIdAsync(int id);
    Task AddAsync(Designation designation);
    Task UpdateAsync(Designation designation);
    Task DeleteAsync(Designation designation);
}

