using Core.Application.Interfaces.Identity;
using Infrastructure.Identity.Data;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppIdentityDBContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
