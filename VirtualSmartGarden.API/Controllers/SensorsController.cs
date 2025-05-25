using Microsoft.AspNetCore.Mvc;
using VirtualSmartGarden.Application.Dtos;
using VirtualSmartGarden.Application.DTOs;
using VirtualSmartGarden.Application.Enums;
using VirtualSmartGarden.Application.Interfaces;

namespace VirtualSmartGarden.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ILogger<SensorsController> _logger;
        private readonly ISensorDataService _sensorDataService;
        public SensorsController(ILogger<SensorsController> logger,
            ISensorDataService sensorDataService)
        {
            _logger = logger;
            _sensorDataService = sensorDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDataDto>>> GetAllSensorData()
        {
            var sensorData = await _sensorDataService.GetAllSensorDataAsync();

            // Αν θες, πρόσθεσε έλεγχο για κενά αποτελέσματα:
            if (sensorData == null)
                return NotFound();

            return Ok(sensorData);
        }

        [HttpPost]
        public async Task<IActionResult> PostSensorData([FromBody] SensorDataGroupDto data)
        {
            Console.WriteLine($"\n\nSensors Group: {Enum.GetName(typeof(SensorArea), data.Group)}");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            if (data == null)
            {
                _logger.LogWarning("Received null sensor data list.");
                return BadRequest("Empty or null sensor data list.");
            }

            if (data.SensorData == null || !data.SensorData.Any())
            {
                _logger.LogWarning("Received empty sensor data list.");
                return BadRequest("Sensor data list is empty.");
            }

            foreach (var item in data.SensorData)
            {
                Console.WriteLine($"Sensor: {item.SensorType,-18}" +
                    $" | Value: {item.Value,8:F2} {item.Unit,-5} " +
                    $"| Timestamp: {item.Timestamp:MM/dd/yyyy h:mm:ss tt}");

                // _logger.LogInformation($"Sensor: {item.SensorType} | Value: {item.Value} {item.Unit} | Timestamp: {item.Timestamp}");
                //_logger.LogInformation("Received {Count} sensor values from group {Group}", data.SensorData.Count, data.Group);

            }
            await _sensorDataService.SaveSensorDataBatchAsync(data);

            return Ok(new { Message = $"Received {data.SensorData.Count} sensor data items from group {data.Group}." });
        }
    }
} 
    

