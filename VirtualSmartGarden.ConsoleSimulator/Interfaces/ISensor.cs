using VirtualSmartGarden.ConsoleSimulator.Enums;

namespace VirtualSmartGarden.ConsoleSimulator.Interfaces
{
    public interface ISensor
    {
        SensorType Type { get; }
        Task<double> ReadSensorValueAsync();
    }
}
