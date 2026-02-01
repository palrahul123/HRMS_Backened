using AutoMapper;
using Core.Application.DTOs.DesignationDtos;
using Core.Domain;

namespace Core.Application.Mappings
{
    public class DesignationProfile : Profile
    {
        public DesignationProfile()
        {
            CreateMap<CreateDesignationDto, Designation>();
            CreateMap<UpdateDesignationDto, Designation>();

            CreateMap<Designation, DesignationDto>()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.DepartmentName));
        }
    }
}
