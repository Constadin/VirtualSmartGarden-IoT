using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Sensors
{
    public class Ph : ISensor
    {
        public SensorType Type => SensorType.pH;

        private readonly ISensorDataGenerator _generator;

        public Ph(ISensorDataGenerator generator)
        {
            _generator = generator;
        }
        public async Task<double> ReadSensorValueAsync()
        {
            return await _generator.GenerateNextValueAsync(Type);
        }
    }
}
