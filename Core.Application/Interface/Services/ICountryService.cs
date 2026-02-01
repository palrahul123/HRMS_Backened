using Core.Application.DTOs.CountryDtos;

namespace Core.Application.Interface.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateCountryDto dto);
        Task UpdateAsync(UpdateCountryDto dto);
        Task DeleteAsync(int id);
    }
}
