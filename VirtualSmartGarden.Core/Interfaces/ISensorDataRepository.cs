using VirtualSmartGarden.Core.Entities;

namespace VirtualSmartGarden.Core.Interfaces
{
    public interface ISensorDataRepository
    {
        Task<IEnumerable<SensorData>> GetLatestSensorDataAsync();
        Task AddRangeAsync(IEnumerable<SensorData> data);
    }
}
