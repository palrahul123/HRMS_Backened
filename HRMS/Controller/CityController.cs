using Core.Application.DTOs.CityDtos;
using Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _service.GetByIdAsync(id);
            return city == null ? NotFound() : Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { Id = id, Message = "City created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCityDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("City updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("City deleted");
        }
    }
}
