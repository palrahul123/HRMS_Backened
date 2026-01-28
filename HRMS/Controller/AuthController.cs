using Core.Application.Common;
using Core.Application.DTOs.UserProfile;
using Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest(new APIResponse(false, "Email and password are required."));
            }

            var authResponse = await _userService.GetDetailByEmailandPassword(loginDto);

            if (authResponse == null)
            {
                return Unauthorized(new APIResponse(false, "Invalid email or password."));
            }

            return Ok(new APIResponse(true, "Login successful", authResponse));
        }
    }
}
