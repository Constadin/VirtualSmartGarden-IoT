using VirtualSmartGarden.Core.Entities;

namespace VirtualSmartGarden.Core.Interfaces
{
    public interface ISensorDataRepository
    {
        Task<IEnumerable<SensorData>> GetLatestGroupsAsync(int take);
        Task AddRangeAsync(IEnumerable<SensorData> data);
        Task<IEnumerable<SensorData>> GetAllAsync();
    }
}
