using System;

namespace Winform_SQLite.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
