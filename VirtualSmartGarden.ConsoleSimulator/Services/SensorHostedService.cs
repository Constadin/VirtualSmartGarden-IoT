using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;
using VirtualSmartGarden.ConsoleSimulator.SensorsConfig;

namespace VirtualSmartGarden.ConsoleSimulator.Services
{
    public class SensorHostedService : BackgroundService
    {
        private readonly IEnumerable<ISensor> _sensors;
        private readonly ILogger<SensorHostedService> _logger;
        private readonly SensorSettings _settings;
        private readonly TimeSpan _interval;


        public SensorHostedService(IEnumerable<ISensor> sensors,
            ILogger<SensorHostedService> logger,
            IOptions<SensorSettings> options)
        {
            _sensors = sensors;
            _logger = logger;
            _interval = options.Value.Interval;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var sensor in _sensors)
                {
                    var value = await sensor.ReadSensorValueAsync();

                    _logger.LogInformation("[{0}] Value: {1}", sensor.Type, value);
                }

                await Task.Delay(_interval, stoppingToken);

            }
        }
    }
}
