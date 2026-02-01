using AutoMapper;
using Core.Application.DTOs.DesignationDtos;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Domain;

namespace Core.Application.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _repository;
        private readonly IMapper _mapper;

        public DesignationService(IDesignationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DesignationDto>> GetAllAsync()
        {
            var designations = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DesignationDto>>(designations);
        }

        public async Task<DesignationDto?> GetByIdAsync(int id)
        {
            var designation = await _repository.GetByIdAsync(id);
            return designation == null ? null : _mapper.Map<DesignationDto>(designation);
        }

        public async Task<int> CreateAsync(CreateDesignationDto dto)
        {
            var designation = _mapper.Map<Designation>(dto);
            await _repository.AddAsync(designation);
            return designation.Id;
        }

        public async Task UpdateAsync(UpdateDesignationDto dto)
        {
            var designation = await _repository.GetByIdAsync(dto.Id);
            if (designation == null)
                throw new Exception("Designation not found");

            _mapper.Map(dto, designation);
            await _repository.UpdateAsync(designation);
        }

        public async Task DeleteAsync(int id)
        {
            var designation = await _repository.GetByIdAsync(id);
            if (designation == null)
                throw new Exception("Designation not found");

            await _repository.DeleteAsync(designation);
        }
    }
}
