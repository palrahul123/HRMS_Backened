using AutoMapper;
using Core.Application.DTOs.StateDtos;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Domain;

namespace Core.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _repository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StateDto>> GetAllAsync()
        {
            var states = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StateDto>>(states);
        }

        public async Task<StateDto?> GetByIdAsync(int id)
        {
            var state = await _repository.GetByIdAsync(id);
            return state == null ? null : _mapper.Map<StateDto>(state);
        }

        public async Task<int> CreateAsync(CreateStateDto dto)
        {
            var state = _mapper.Map<State>(dto);
            await _repository.AddAsync(state);
            return state.Id;
        }

        public async Task UpdateAsync(UpdateStateDto dto)
        {
            var state = await _repository.GetByIdAsync(dto.Id);
            if (state == null)
                throw new Exception("State not found");

            _mapper.Map(dto, state);
            await _repository.UpdateAsync(state);
        }

        public async Task DeleteAsync(int id)
        {
            var state = await _repository.GetByIdAsync(id);
            if (state == null)
                throw new Exception("State not found");

            await _repository.DeleteAsync(state);
        }
    }
}
