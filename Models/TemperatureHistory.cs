using System;

namespace Winform_SQLite.Models
{
    public class TemperatureHistory
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public double Temperature { get; set; }
        public DateTime CollectTime { get; set; }
        public int QualityStamp { get; set; }
    }
}
