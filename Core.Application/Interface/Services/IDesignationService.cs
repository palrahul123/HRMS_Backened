using Core.Application.DTOs.DesignationDtos;

namespace Core.Application.Interface.Services;

public interface IDesignationService
{
    Task<IEnumerable<DesignationDto>> GetAllAsync();
    Task<DesignationDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateDesignationDto dto);
    Task UpdateAsync(UpdateDesignationDto dto);
    Task DeleteAsync(int id);
}

