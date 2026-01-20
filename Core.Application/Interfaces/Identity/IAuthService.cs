using Core.Application.DTOs;

namespace Core.Application.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(SignInRequest signInRequest);
        Task SignOutAsync();
        Task<AuthenticationResponse> SignUpAsync(SignUpRequest signUpRequest);
    }
}
