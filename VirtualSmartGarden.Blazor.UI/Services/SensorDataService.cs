using System.Net.Http.Json;
using VirtualSmartGarden.Blazor.UI.Dtos;
using VirtualSmartGarden.Blazor.UI.Interfaces;

namespace VirtualSmartGarden.Blazor.UI.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly HttpClient _http;

        public SensorDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<SensorDataDto>> GetAllSensorDataAsync()
        {
            var result = await _http.GetFromJsonAsync<List<SensorDataDto>>("api/sensors/all");
            return result ?? new();
        }
        public async Task<IEnumerable<SensorDataDto>> GetLatestSensorDataAsync(int take)
        {
            var result = await _http.GetFromJsonAsync<List<SensorDataDto>>("api/sensors/latest");
            return result ?? new();
        }

    }
}
