using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Sensors
{
    public class HumiditySensor : ISensor
    {
        public SensorType Type => SensorType.Humidity;

        private readonly ISensorDataGenerator _generator;

        public HumiditySensor(ISensorDataGenerator generator)
        {
            _generator = generator;
        }
        public async Task<double> ReadSensorValueAsync()
        {
            return await _generator.GenerateNextValueAsync(Type);
        }
    }
}
