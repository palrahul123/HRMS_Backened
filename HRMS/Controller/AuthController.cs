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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AuthenticationResponse response = await _userService.GetDetailByEmailandPassword(loginRequest);
            return Ok(response);
        }
    }
}
