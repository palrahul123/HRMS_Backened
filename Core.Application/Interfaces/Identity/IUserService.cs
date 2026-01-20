using Core.Application.DTOs;

namespace Core.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<ApplicationUserDto> FindByIdAsync(string userId);
        Task<ApplicationUserDto> FindByEmailAsync(string email);
    }
}
