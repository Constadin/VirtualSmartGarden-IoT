using VirtualSmartGarden.Blazor.UI.Interfaces;
using VirtualSmartGarden.Blazor.UI.Services;

namespace VirtualSmartGarden.Blazor.UI.ServiceCollectionRegistrationDI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterBlazorUIServices(this IServiceCollection services)
        {
            
            services.AddScoped<ISensorDataService, SensorDataService>();

            return services;
        }
    }
}
