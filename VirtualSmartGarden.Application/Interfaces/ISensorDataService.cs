using VirtualSmartGarden.Application.Dtos;
using VirtualSmartGarden.Application.DTOs;

namespace VirtualSmartGarden.Application.Interfaces
{
    public interface ISensorDataService
    {
        Task SaveSensorDataBatchAsync(SensorDataGroupDto data);
        Task<IEnumerable<SensorDataDto>> GetAllSensorDataAsync();
    }

}
