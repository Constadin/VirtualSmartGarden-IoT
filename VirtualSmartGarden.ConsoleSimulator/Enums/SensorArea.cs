using System.Text.Json.Serialization;

namespace VirtualSmartGarden.ConsoleSimulator.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SensorArea
    {
        Greenhouse_Α32 = 1,
        Εstate_Α44 = 2,
        Greenhouse_ΑΚ55 = 3,
        Εstate_Β74 = 4,
    }
}
