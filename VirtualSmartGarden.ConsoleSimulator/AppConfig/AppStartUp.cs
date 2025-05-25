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
        private readonly IEnumerable<ISensor> _sensors;
        private readonly TimeSpan _interval;
        private readonly ISensorDataSender _dataSender;
        private readonly SensorArea[] _allGroups =
            Enum.GetValues(typeof(SensorArea)).Cast<SensorArea>().ToArray();
        private int _groupIndex = 0;

        public AppStartUp(ILogger<AppStartUp> logger,
            IEnumerable<ISensor> sensors,
            IOptions<SensorSettings> options,
            ISensorDataSender dataSender)
        {
            _logger = logger;
            _sensors = sensors;
            _interval = options.Value.Interval;
            _dataSender = dataSender;
        }
        public async Task RunAsync()
        {
            var cts = new CancellationTokenSource();

            _logger.LogInformation("Simulator started.");
            Console.WriteLine("\nCtrl+C exit");

            Console.CancelKeyPress += (s, e) =>
            {

                cts.Cancel();
                e.Cancel = true;
            };

            while (!cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("\n------------------------------------------");

                var sensorDataList = new List<SensorDataDto>();
                var currentGroup = _allGroups[_groupIndex];

                foreach (var sensor in _sensors)
                {
                    var value = await sensor.ReadSensorValueAsync();
                    var unit = sensor.Type.ToUnit();
                    var code = sensor.Type.ToShortCode();
                    var time = DateTime.Now;

                    Console.WriteLine($"[{code,-5}] {time:T} - {value,9:F2} {unit,-5}");

                    sensorDataList.Add(new SensorDataDto
                    {
                        SensorType = sensor.Type.ToString(),
                        Value = value,
                        Unit = unit,
                        Timestamp = time,
                    });
                }
                Console.WriteLine("\n");
                try
                {
                    if (sensorDataList.Any())
                    {
                        var groupedData = new SensorDataGroupDto
                        {
                            GroupId = Guid.NewGuid(),
                            Group = (int)currentGroup,
                            SensorData = sensorDataList
                        };

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
