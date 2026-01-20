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
        }
    }
}
