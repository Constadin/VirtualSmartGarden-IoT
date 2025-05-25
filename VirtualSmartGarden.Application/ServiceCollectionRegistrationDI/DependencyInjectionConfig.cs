using Microsoft.Extensions.DependencyInjection;
using VirtualSmartGarden.Application.Interfaces;
using VirtualSmartGarden.Application.Services;

namespace VirtualSmartGarden.Application.ServiceCollectionRegistrationDI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegistrationServicesApplication(this IServiceCollection services)
        {
            // Background service

            // Register Services
            services.AddScoped<ISensorDataService, SensorDataService>();

            //Register Classes

            return services;
        }
    }
}
