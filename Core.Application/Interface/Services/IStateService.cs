using Core.Application.DTOs.StateDtos;

namespace Core.Application.Interface.Services
{
    public interface IStateService
    {
        Task<IEnumerable<StateDto>> GetAllAsync();
        Task<StateDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateStateDto dto);
        Task UpdateAsync(UpdateStateDto dto);
        Task DeleteAsync(int id);
    }
}
