using AutoMapper;
using Core.Application.DTOs.StateDtos;
using Core.Domain;

namespace Core.Application.Mappings
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<CreateStateDto, State>();
            CreateMap<UpdateStateDto, State>();
            CreateMap<State, StateDto>()
                .ForMember(d => d.CountryName, o => o.MapFrom(s => s.Country.Name));
        }
    }
}
