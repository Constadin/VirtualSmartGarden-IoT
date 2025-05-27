using System.ComponentModel;

namespace VirtualSmartGarden.Blazor.UI.Enums
{
    public enum SearchType
    {
        [Description("Sensor Type")]
        SensorType,

        [Description("Unit")]
        Unit,

        [Description("Area Code")]
        AreaCode,

        [Description("Timestamp")]
        Timestamp,

        [Description("Value Range (min-max)")]
        ValueRange
    }
}
