using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Sensors
{
    public class SoilMoistureSensor : ISensor
    {
        public SensorType Type => SensorType.SoilMoisture;

        private readonly ISensorDataGenerator _generator;

        public SoilMoistureSensor(ISensorDataGenerator generator)
        {
            _generator = generator;
        }
        public async Task<double> ReadSensorValueAsync()
        {
            return await _generator.GenerateNextValueAsync(Type);
        }
    }
}
