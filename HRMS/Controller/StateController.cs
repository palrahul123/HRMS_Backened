using Core.Application.DTOs.StateDtos;
using Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _service;

        public StateController(IStateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var state = await _service.GetByIdAsync(id);
            return state == null ? NotFound() : Ok(state);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { Id = id, Message = "State created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStateDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("State updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("State deleted");
        }
    }
}
