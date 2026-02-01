using AutoMapper;
using Core.Application.DTOs.DepartmentDtos;
using Core.Domain;

namespace Core.Application.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(d => d.BranchName, o => o.MapFrom(s => s.Branch.BranchName))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.CompanyName));
            //.ForMember(d => d., o => o.MapFrom(s => s.Designations.Select(x => x.DesignationName)));
        }
    }
}
