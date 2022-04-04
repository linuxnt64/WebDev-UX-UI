using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Models
{
    public class DeviceItem
    {
        public string DeviceId { get { return "DummyDeviceId"; } set { } }
        public string Status { get { return "DummyStatus"; } set { } }
        public string Placement { get; set; }
        public string SensorType { get; set; }
        public string LastUpdated { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Alert { get; set; }

    }
}
