using VirtualSmartGarden.ConsoleSimulator.Enums;

namespace VirtualSmartGarden.ConsoleSimulator.Extensions{
 

    public static class SensorTypeExtensions
    {
        public static string ToShortCode(this SensorType type) => type switch
        {
            SensorType.Temperature => "TEMP",
            SensorType.Humidity => "HUM",
            SensorType.Light => "LIGHT",
            SensorType.CO2 => "CO2",
            SensorType.SoilMoisture => "SOIL",
            SensorType.pH => "PH",
            SensorType.Pressure => "PRES",
            SensorType.WindSpeed => "WIND",
            SensorType.RainLevel => "RAIN",
            SensorType.UVIndex => "UV",
            SensorType.VOC => "VOC",
            SensorType.Smoke => "SMOKE",
            SensorType.BatteryLevel => "BATT",
            _ => "UNKNOWN"
        };

        public static string ToUnit(this SensorType type) => type switch
        {
            SensorType.Temperature => "°C",
            SensorType.Humidity => "%",
            SensorType.Light => "lx",
            SensorType.CO2 => "ppm",
            SensorType.SoilMoisture => "%",
            SensorType.pH => "ph",
            SensorType.Pressure => "hPa",
            SensorType.WindSpeed => "Km/h",
            SensorType.RainLevel => "mm",
            SensorType.UVIndex => "uv ",
            SensorType.VOC => "ppb",
            SensorType.Smoke => "ppm",
            SensorType.BatteryLevel => "%",
            _ => ""
        };

        public static string ToLabel(this SensorType type) =>
            type.ToString().Replace("Level", " Level").Replace("Speed", " Speed");
    }

}
