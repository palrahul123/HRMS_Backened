using Core.Domain;

namespace Core.Application.Interface.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllAsync();
        Task<State?> GetByIdAsync(int id);
        Task AddAsync(State state);
        Task UpdateAsync(State state);
        Task DeleteAsync(State state);
    }
}
