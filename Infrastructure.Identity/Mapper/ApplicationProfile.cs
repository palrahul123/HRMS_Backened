using AutoMapper;
using Core.Application.DTOs;
using Infrastructure.Identity.Models;

namespace Infrastructure.Identity.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<SignUpRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
                .ForMember(dest => dest.EntryDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.EntryBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore()).ReverseMap();
        }
    }
}
