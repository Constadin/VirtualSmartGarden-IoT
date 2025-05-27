using Microsoft.Extensions.Logging;
using VirtualSmartGarden.ConsoleSimulator.Dtos;
using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Extensions;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Services
{
    public class VirtualEdgeDevicesService : IVirtualEdgeDevicesService
    {
        private readonly IEnumerable<ISensor> _sensors;
        private readonly ISensorDataSender _dataSender;
        private readonly ILogger<VirtualEdgeDevicesService> _logger;

        public VirtualEdgeDevicesService(IEnumerable<ISensor> sensors,
            ISensorDataSender dataSender,
            ILogger<VirtualEdgeDevicesService> logger)
        {
            _sensors = sensors;
            _dataSender = dataSender;
            _logger = logger;
        }

        public async Task<SensorDataGroupDto> GetSensorDataGroupAsync(SensorArea group)
        {
            var sensorDataList = new List<SensorDataDto>();

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

            return new SensorDataGroupDto
            {
                GroupId = Guid.NewGuid(),
                Group = (int)group,
                SensorData = sensorDataList
            };
        }
    }
}
