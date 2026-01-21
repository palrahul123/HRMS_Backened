using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Data
{
    public static class ServiceCollectionExtensio
    {
        public static IServiceCollection AddPersistenceData(this IServiceCollection services)
        {
            return services;
        }
    }
}
