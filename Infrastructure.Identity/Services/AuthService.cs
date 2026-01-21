using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Identity;
using Infrastructure.Identity.Extensions;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> SignInAsync(SignInRequest request)
        {
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
            return signInResult.Succeeded;

        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResponse> SignUpAsync(SignUpRequest request, int entryBy)
        {
            var user = _mapper.Map<ApplicationUser>(request);

            user.IsActive = true;
            user.EntryBy = entryBy;
            user.UpdateBy = entryBy;
            user.EntryDate = DateTime.UtcNow;
            user.UpdateDate = DateTime.UtcNow;

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result.ToAuthenticationResult();
        }
    }
}
