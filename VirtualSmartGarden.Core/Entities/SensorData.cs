namespace VirtualSmartGarden.Core.Entities
{
    public class SensorData
    {

        public Guid Id { get; set; }
        public string SensorType { get; set; } = string.Empty;
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int Group { get; set; }
        public Guid GroupId { get; set; }
        public SensorData()
        {
            
            Id = Guid.NewGuid();
        }
    }
}
