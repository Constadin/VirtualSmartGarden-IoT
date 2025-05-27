using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VirtualSmartGarden.ConsoleSimulator.Dtos;
using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Extensions;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;
using VirtualSmartGarden.ConsoleSimulator.SensorsConfig;

namespace VirtualSmartGarden.ConsoleSimulator.AppConfig
{
    public class AppStartUp
    {
        private readonly ILogger<AppStartUp> _logger;
        private readonly TimeSpan _interval;
        private readonly ISensorDataSender _dataSender;
        private readonly IVirtualEdgeDevicesService _virtualEdgeDevicesService;
        private readonly SensorArea[] _allGroups =
                         Enum.GetValues(typeof(SensorArea)).Cast<SensorArea>().ToArray();
        private int _groupIndex = 0;

        public AppStartUp(ILogger<AppStartUp> logger,
            IEnumerable<ISensor> sensors,
            IOptions<SensorSettings> options,
            ISensorDataSender dataSender,
            IVirtualEdgeDevicesService virtualEdgeDevicesService)
        {
            _logger = logger;
            _interval = options.Value.Interval;
            _dataSender = dataSender;
            _virtualEdgeDevicesService = virtualEdgeDevicesService;
        }
        public async Task RunAsync()
        {
            var cts = new CancellationTokenSource();

            _logger.LogInformation("Simulator started.");
            Console.WriteLine("\nCtrl+C exit\n\n");

            Console.CancelKeyPress += (s, e) =>
            {

                cts.Cancel();
                e.Cancel = true;
            };

            while (!cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("\n------------------------------------------");

                var currentGroup = _allGroups[_groupIndex];
;
                try
                {
                    var groupedData = await _virtualEdgeDevicesService.GetSensorDataGroupAsync(currentGroup);

                    if (groupedData.SensorData.Any())
                    {

                        await _dataSender.SendSensorDataAsync(groupedData);
                    }
                    else
                    {
                        _logger.LogWarning("Sensor data list is empty. Nothing to send.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending sensor data batch.");
                }

                try
                {
                    await Task.Delay(_interval, cts.Token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                Console.WriteLine("------------------------------------------");
                _groupIndex = (_groupIndex + 1) % _allGroups.Length;
            }

            Console.WriteLine("\n\n");
            _logger.LogInformation("Simulator finished.");
            Console.ReadKey();

        }
    }
}
