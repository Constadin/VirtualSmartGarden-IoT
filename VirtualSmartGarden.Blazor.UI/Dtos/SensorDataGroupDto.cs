namespace VirtualSmartGarden.Blazor.UI.Dtos
{
    public class SensorDataGroupDto
    {
        public Guid GroupId { get; set; }
        public int Group { get; set; }
        public List<SensorDataDto> SensorData { get; set; } = new();
    }

}
