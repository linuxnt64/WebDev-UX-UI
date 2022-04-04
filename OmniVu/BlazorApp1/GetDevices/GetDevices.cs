using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using AzureFunctions.Models;

namespace GetDevices
{
    public static class GetDevices
    {
        [FunctionName("GetDevices")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var list = new List<DeviceItem>()
            {
                new DeviceItem()
                {
                    DeviceId = "36d5e179-cb7b-Udfb-a10c-25b1925a1404",
                    Status = "connected",
                    Placement="Fridge 1",
                    SensorType="Temperature Sensor",
                    LastUpdated=DateTime.Now.ToString(),
                    Temperature="10",
                    Humidity="21",
                    Alert="Overtemp!"
                }
            };
            return new OkObjectResult(list);
        }
    }
}
