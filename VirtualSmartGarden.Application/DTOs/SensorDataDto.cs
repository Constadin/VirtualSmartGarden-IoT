namespace VirtualSmartGarden.Application.DTOs
{
    public class SensorDataDto
    {
        public string SensorType { get; set; } = string.Empty;
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public Guid GroupId { get; set; }
        public int Group { get; set; }
    }
}
