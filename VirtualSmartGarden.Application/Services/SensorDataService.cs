using VirtualSmartGarden.Application.Dtos;
using VirtualSmartGarden.Application.DTOs;
using VirtualSmartGarden.Application.Interfaces;
using VirtualSmartGarden.Core.Entities;
using VirtualSmartGarden.Core.Interfaces;

namespace VirtualSmartGarden.Application.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _sensorDataRepository;
        private readonly ISensorDataRepositoryApp _repositoryApp;

        public SensorDataService(ISensorDataRepository sensorDataRepository,
            ISensorDataRepositoryApp repositoryApp)
        {
            _sensorDataRepository = sensorDataRepository;
            _repositoryApp = repositoryApp;
        }

        public async Task SaveSensorDataBatchAsync(SensorDataGroupDto data)
        {
            var entities = data.SensorData.Select(dto => new SensorData
            {   
                GroupId = data.GroupId,
                Id = Guid.NewGuid(),
                SensorType = dto.SensorType,
                Value = dto.Value,
                Unit = dto.Unit,
                Timestamp = dto.Timestamp,
                Group = data.Group
            }).ToList();

            await _sensorDataRepository.AddRangeAsync(entities);
        }
        public async Task<IEnumerable<SensorDataDto>> GetAllSensorDataAsync()
        {
            var entities = await _repositoryApp.GetAllAsync();

            return entities.Select(sd => new SensorDataDto
            {
                SensorType = sd.SensorType,
                Value = sd.Value,
                Unit = sd.Unit,
                Timestamp = sd.Timestamp,
                GroupId = sd.GroupId,
                Group = sd.Group
            });
        }


    }
}
