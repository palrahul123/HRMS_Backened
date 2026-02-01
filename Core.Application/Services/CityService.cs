using AutoMapper;
using Core.Application.DTOs.CityDtos;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Domain;

namespace Core.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var cities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }

        public async Task<CityDto?> GetByIdAsync(int id)
        {
            var city = await _repository.GetByIdAsync(id);
            return city == null ? null : _mapper.Map<CityDto>(city);
        }

        public async Task<int> CreateAsync(CreateCityDto dto)
        {
            var city = _mapper.Map<City>(dto);
            await _repository.AddAsync(city);
            return city.Id;
        }

        public async Task UpdateAsync(UpdateCityDto dto)
        {
            var city = await _repository.GetByIdAsync(dto.Id);
            if (city == null)
                throw new Exception("City not found");

            _mapper.Map(dto, city);
            await _repository.UpdateAsync(city);
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _repository.GetByIdAsync(id);
            if (city == null)
                throw new Exception("City not found");

            await _repository.DeleteAsync(city);
        }
    }
}
