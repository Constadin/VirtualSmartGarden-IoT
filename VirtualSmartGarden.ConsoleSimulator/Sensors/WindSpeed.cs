using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Sensors
{
    public class WindSpeed : ISensor
    {
        public SensorType Type => SensorType.WindSpeed;

        private readonly ISensorDataGenerator _generator;

        public WindSpeed(ISensorDataGenerator generator)
        {
            _generator = generator;
        }
        public async Task<double> ReadSensorValueAsync()
        {
            return await _generator.GenerateNextValueAsync(Type);
        }
    }
}
