using Core.Application.Common;
using Core.Application.DTOs.UserProfile;
using Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(new APIResponse(true, "Users retrieved successfully", users));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new APIResponse(false, "User not found"));

            return Ok(new APIResponse(true, "User retrieved successfully", user));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            if (dto == null)
                return BadRequest(new APIResponse(false, "Invalid user data"));

            await _userService.AddAsync(dto);
            return Ok(new APIResponse(true, "User created successfully"));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            if (dto == null || dto.Id != id)
                return BadRequest(new APIResponse(false, "Invalid user data"));

            await _userService.Update(dto);
            return Ok(new APIResponse(true, "User updated successfully"));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok(new APIResponse(true, "User deleted successfully"));
        }
    }
}
