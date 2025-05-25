using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Sensors
{
    public class TemperatureSensor : ISensor
    {
        public SensorType Type => SensorType.Temperature;

        private readonly ISensorDataGenerator _generator;

        public TemperatureSensor(ISensorDataGenerator generator)
        {
            _generator = generator;
        }
        public async Task<double> ReadSensorValueAsync()
        {
            return await _generator.GenerateNextValueAsync(Type);
        }
    }
}
