using System.Net.Http.Json;
using VirtualSmartGarden.ConsoleSimulator.Dtos;
using VirtualSmartGarden.ConsoleSimulator.Interfaces;

namespace VirtualSmartGarden.ConsoleSimulator.Services
{
    public class SensorDataSender : ISensorDataSender
    {
        private readonly HttpClient _httpClient;

        public SensorDataSender(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SensorApiClient");
        }

        public async Task SendSensorDataAsync(SensorDataGroupDto groupedData)
        {
            var response = await _httpClient.PostAsJsonAsync("sensors", groupedData);
            response.EnsureSuccessStatusCode();
        }
    }
}
