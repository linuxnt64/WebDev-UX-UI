namespace BlazorApp1.Models
{
    public class DeviceItem
    {
        public string DeviceId { get; set; } = "";
        public string Status { get; set; } = "";
        public string Placement { get; set; } = "";
        public string SensorType { get; set; } = "";
        public DateTime? LastUpdated { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public bool Alert { get; set; }
    }
}
