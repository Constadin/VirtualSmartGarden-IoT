using VirtualSmartGarden.ConsoleSimulator.Dtos;

namespace VirtualSmartGarden.ConsoleSimulator.Interfaces
{
    public interface ISensorDataSender
    {
        Task SendSensorDataAsync(SensorDataGroupDto groupedData);
    }
}
