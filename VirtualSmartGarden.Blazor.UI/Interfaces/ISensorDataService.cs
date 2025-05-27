using VirtualSmartGarden.Blazor.UI.Dtos;

namespace VirtualSmartGarden.Blazor.UI.Interfaces
{
    public interface ISensorDataService
    {
        Task<IEnumerable<SensorDataDto>> GetAllSensorDataAsync();
        Task<IEnumerable<SensorDataDto>> GetLatestSensorDataAsync(int take);
    }
}
