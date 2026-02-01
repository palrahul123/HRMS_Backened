using Core.Application.Common;
using Core.Application.Interface.Services;
using Core.Application.Service;
using Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(action =>
            {
                action.Issuer = configuration["JwtSettings:Issuer"];
                action.Audience = configuration["JwtSettings:Audience"];
                action.SecretKey = configuration["JwtSettings:SecretKey"];
                action.ExpiryMinutes = Convert.ToInt32(configuration["JwtSettings:ExpirationInMinutes"]);
            });
            services.AddSingleton<JwtService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            return services;
        }
    }
}


