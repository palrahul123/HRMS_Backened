using AutoMapper;
using Core.Application.DTOs.CountryDtos;
using Core.Domain;

namespace Core.Application.Mappings
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>();
            CreateMap<Country, CountryDto>();
        }
    }
}
