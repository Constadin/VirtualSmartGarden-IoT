using VirtualSmartGarden.Core.Entities;

namespace VirtualSmartGarden.Application.Interfaces
{
    public interface ISensorDataRepositoryApp
    {
        Task<IEnumerable<SensorData>> GetAllAsync();
        Task<IEnumerable<SensorData>> GetLatestGroupsAsync(int take);
    }

}
