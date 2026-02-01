using AutoMapper;
using Core.Application.DTOs.CityDtos;
using Core.Domain;

namespace Core.Application.Mappings
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();

            CreateMap<City, CityDto>()
                .ForMember(d => d.StateName, o => o.MapFrom(s => s.State.Name))
                .ForMember(d => d.CountryName, o => o.MapFrom(s => s.State.Country.Name));
        }
    }
}
