using Core.Application.DTOs.DesignationDtos;
using Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _service;

        public DesignationController(IDesignationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var designation = await _service.GetByIdAsync(id);
            return designation == null ? NotFound() : Ok(designation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDesignationDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { Id = id, Message = "Designation created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDesignationDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("Designation updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Designation deleted");
        }
    }
}
