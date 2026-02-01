using AutoMapper;
using Core.Application.DTOs.DepartmentDtos;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Domain;

namespace Core.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            return department == null ? null : _mapper.Map<DepartmentDto>(department);
        }

        public async Task<int> CreateAsync(CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            await _repository.AddAsync(department);
            return department.Id;
        }

        public async Task UpdateAsync(UpdateDepartmentDto dto)
        {
            var department = await _repository.GetByIdAsync(dto.Id);
            if (department == null)
                throw new Exception("Department not found");

            _mapper.Map(dto, department);
            await _repository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department == null)
                throw new Exception("Department not found");

            await _repository.DeleteAsync(department);
        }
    }
}
