using VirtualSmartGarden.Application.ServiceCollectionRegistrationDI;
using VirtualSmartGarden.Infrastructure.ServiceCollectionRegistrationDI;

namespace VirtualSmartGarden.ConsoleSimulator.ServiceCollectionRegistrationDI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegistrationServicesApi(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Background service
            services.RegistrationServicesInfrastructure(configuration);
            services.RegistrationServicesApplication();

            // Register Services

            // Register Classes

            return services;
        }
    }
}
