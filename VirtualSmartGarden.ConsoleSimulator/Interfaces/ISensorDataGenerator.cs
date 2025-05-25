using VirtualSmartGarden.ConsoleSimulator.Enums;

namespace VirtualSmartGarden.ConsoleSimulator.Interfaces
{
    public interface ISensorDataGenerator
    {
        Task<double> GenerateNextValueAsync(SensorType type);
    }
}
