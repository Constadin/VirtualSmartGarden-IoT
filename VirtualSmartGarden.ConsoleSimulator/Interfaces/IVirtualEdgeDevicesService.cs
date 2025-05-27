using VirtualSmartGarden.ConsoleSimulator.Dtos;
using VirtualSmartGarden.ConsoleSimulator.Enums;

namespace VirtualSmartGarden.ConsoleSimulator.Interfaces
{
    public interface IVirtualEdgeDevicesService
    {
        Task<SensorDataGroupDto> GetSensorDataGroupAsync(SensorArea group);
    }

}
