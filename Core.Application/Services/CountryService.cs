using AutoMapper;
using Core.Application.DTOs.CountryDtos;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Domain;

namespace Core.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            return country == null ? null : _mapper.Map<CountryDto>(country);
        }

        public async Task<int> CreateAsync(CreateCountryDto dto)
        {
            var country = _mapper.Map<Country>(dto);
            await _repository.AddAsync(country);
            return country.Id;
        }

        public async Task UpdateAsync(UpdateCountryDto dto)
        {
            var country = await _repository.GetByIdAsync(dto.Id);
            if (country == null)
                throw new Exception("Country not found");

            _mapper.Map(dto, country);
            await _repository.UpdateAsync(country);
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country == null)
                throw new Exception("Country not found");

            await _repository.DeleteAsync(country);
        }
    }
}
