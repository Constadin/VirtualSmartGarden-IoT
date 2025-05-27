using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VirtualSmartGarden.ConsoleSimulator.AppConfig;
using VirtualSmartGarden.ConsoleSimulator.SensorsConfig;
using VirtualSmartGarden.ConsoleSimulator.ServiceCollectionRegistrationDI;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var config = builder.Build();

Console.WriteLine("Manual Log Level: " + config["Logging:LogLevel:System.Net.Http.HttpClient.SensorApiClient"]);

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configBuilder) =>
    {
        configBuilder.AddConfiguration(config); // Ενσωμάτωσε το config που διαβάσαμε
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();

        //logging.AddFilter("System.Net.Http.HttpClient.SensorApiClient", LogLevel.Warning);
        //logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<SensorSettings>(hostContext.Configuration.GetSection("SensorSettings"));

        services.RegistrationServicesSimulator();

        services.AddHttpClient("SensorApiClient", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5134/api/");
            client.Timeout = TimeSpan.FromSeconds(25);
        });
    })
    .Build();

var app = host.Services.GetRequiredService<AppStartUp>();
await app.RunAsync();
