using VirtualSmartGarden.ConsoleSimulator.Enums;

namespace VirtualSmartGarden.ConsoleSimulator.SensorsConfig
{
    public class SensorSettings
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(8);
        public SensorArea Group { get; set; }
    }

}
