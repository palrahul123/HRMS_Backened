using Core.Application.DTOs.CityDtos;

namespace Core.Application.Interface.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateCityDto dto);
        Task UpdateAsync(UpdateCityDto dto);
        Task DeleteAsync(int id);
    }
}
