using VirtualSmartGarden.ConsoleSimulator.Enums;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.GeneratorMockData
{
    public class MockSensorDataGenerator : ISensorDataGenerator
    {
        private readonly Random _random = new();

        private readonly Dictionary<SensorType, double> _lastValues = new();

        /// <summary>
        /// Returns the next value based on the last one and the sensor type.
        /// </summary>
        public async Task<double> GenerateNextValueAsync(SensorType type)
        {
            await SimulateLatency();

            var lastValue = _lastValues.ContainsKey(type) ? _lastValues[type] : GetInitialValue(type);
            var nextValue = GetSmoothNextValue(type, lastValue);

            // 5% probability of error/noise
            if (_random.NextDouble() < 0.05)
            {
                nextValue += _random.NextDouble() * 50 - 25; // +-25 outlier
            }

            // clamp at realistic prices
            nextValue = ClampValue(type, nextValue);

            var rounded = Math.Round(nextValue, 2);
            return _lastValues[type] = rounded;
        }

        /// <summary>
        /// Sensor latency simulation
        /// </summary>
        private async Task SimulateLatency()
        {

            await Task.Delay(_random.Next(100, 300));
        }

        /// <summary>
        /// Returns the initial realistic value of each sensor.
        /// </summary>
        private double GetInitialValue(SensorType type) => type switch
        {
            SensorType.Temperature => 22,
            SensorType.Humidity => 60,
            SensorType.Light => GetLightBasedOnTime(),
            SensorType.CO2 => 400,
            SensorType.SoilMoisture => 50,
            SensorType.pH => 6.5,
            SensorType.Pressure => 1013,
            SensorType.WindSpeed => 5,
            SensorType.RainLevel => 0,
            SensorType.UVIndex => 3,
            SensorType.VOC => 0.2,
            SensorType.Smoke => 0,
            SensorType.BatteryLevel => 100,
            _ => 0
        };

        /// <summary>
        /// Simulates light intensity depending on the time.
        /// </summary>
        private double GetLightBasedOnTime()
        {
            var hour = DateTime.Now.Hour;

            return hour switch
            {
                >= 6 and < 12 => _random.Next(5000, 35000),
                >= 12 and < 15 => _random.Next(60000, 90000),
                >= 15 and < 18 => _random.Next(30000, 60000),
                >= 18 and < 20 => _random.Next(5000, 25000),
                _ => _random.Next(0, 1000)
            };
        }


        /// <summary>
        /// Returns a new value with a small change (for smooth changes).
        /// </summary>
        private double GetSmoothNextValue(SensorType type, double last)
        {
            double delta = type switch
            {
                SensorType.Temperature => _random.NextDouble() * 0.5 - 0.25,
                SensorType.Humidity => _random.NextDouble() * 2 - 1,
                SensorType.Light => _random.NextDouble() * 5000 - 2500,
                SensorType.CO2 => _random.NextDouble() * 20 - 10,
                SensorType.SoilMoisture => _random.NextDouble() * 2 - 1,
                SensorType.pH => _random.NextDouble() * 0.05 - 0.025,
                SensorType.Pressure => _random.NextDouble() * 1.5 - 0.75,
                SensorType.WindSpeed => _random.NextDouble() * 1 - 0.5,
                SensorType.RainLevel => _random.NextDouble() * 0.2,
                SensorType.UVIndex => _random.NextDouble() * 0.2 - 0.1,
                SensorType.VOC => _random.NextDouble() * 0.02 - 0.01,
                SensorType.Smoke => _random.NextDouble() * 0.05,
                SensorType.BatteryLevel => -_random.NextDouble() * 0.1, // αργή πτώση
                _ => 0
            };

            return last + delta;
        }

        /// <summary>
        /// It limits the value to realistic limits for each sensor.
        /// </summary>
        private double ClampValue(SensorType type, double value) => type switch
        {
            SensorType.Temperature => Math.Clamp(value, -10, 45),
            SensorType.Humidity => Math.Clamp(value, 0, 100),
            SensorType.Light => Math.Clamp(value, 0, 100000),
            SensorType.CO2 => Math.Clamp(value, 300, 10000),
            SensorType.SoilMoisture => Math.Clamp(value, 0, 100),
            SensorType.pH => Math.Clamp(value, 0, 14),
            SensorType.Pressure => Math.Clamp(value, 950, 1050),
            SensorType.WindSpeed => Math.Clamp(value, 0, 30),
            SensorType.RainLevel => Math.Clamp(value, 0, 50),
            SensorType.UVIndex => Math.Clamp(value, 0, 11),
            SensorType.VOC => Math.Clamp(value, 0, 1),
            SensorType.Smoke => Math.Clamp(value, 0, 10),
            SensorType.BatteryLevel => Math.Clamp(value, 0, 100),
            _ => value
        };
    }
}
