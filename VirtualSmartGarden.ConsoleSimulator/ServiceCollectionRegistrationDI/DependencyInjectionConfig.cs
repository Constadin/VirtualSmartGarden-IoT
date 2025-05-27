using Microsoft.Extensions.DependencyInjection;
using VirtualSmartGarden.ConsoleSimulator.AppConfig;
using VirtualSmartGarden.ConsoleSimulator.GeneratorMockData;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;
using VirtualSmartGarden.ConsoleSimulator.Sensors;
using VirtualSmartGarden.ConsoleSimulator.Services;

namespace VirtualSmartGarden.ConsoleSimulator.ServiceCollectionRegistrationDI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegistrationServicesSimulator(this IServiceCollection services)
        {
            // Background service
            services.AddHostedService<SensorHostedService>();


            // Register Services
            
            services.AddSingleton<ISensorDataGenerator, MockSensorDataGenerator>();
            services.AddSingleton<ISensorDataSender, SensorDataSender>();
            services.AddSingleton<IVirtualEdgeDevicesService, VirtualEdgeDevicesService>();
            services.AddTransient<ISensor, TemperatureSensor>();
            services.AddTransient<ISensor, HumiditySensor>();
            services.AddTransient<ISensor, SoilMoistureSensor>();
            services.AddTransient<ISensor, Light>();
            services.AddTransient<ISensor, UVIndex>();
            services.AddTransient<ISensor, WindSpeed>();
            services.AddTransient<ISensor, RainLevel>();
            services.AddTransient<ISensor, CO2>();
            services.AddTransient<ISensor, Ph>();


            //Register Classes
            services.AddSingleton<AppStartUp>();         

            return services;
        }
    }
}
