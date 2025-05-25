using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualSmartGarden.Application.Interfaces;
using VirtualSmartGarden.Core.Interfaces;
using VirtualSmartGarden.Infrastructure.Data;
using VirtualSmartGarden.Infrastructure.Repositories;

namespace VirtualSmartGarden.Infrastructure.ServiceCollectionRegistrationDI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegistrationServicesInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Background service
            var connString = configuration.GetConnectionString("DefaultConnection");

            //services.AddSqlite<AppDbContext>(connString);
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connString));

            // Register Services
            services.AddScoped<ISensorDataRepository, SensorDataRepository>();
            services.AddScoped<ISensorDataRepositoryApp, SensorDataRepository>();

            //Register Classes


            return services;
        }
    }
}
