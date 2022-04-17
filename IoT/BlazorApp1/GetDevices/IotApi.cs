using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;
using AzureFunctions.Models;
using System.Collections.Generic;

namespace AzureFunction
{
    public static class IotApi
    {
        private static readonly RegistryManager registryManager = RegistryManager.CreateFromConnectionString("HostName=embedcontrol-IotHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=IPfcPbynOPwxU3JV/e+JUU6Zrk1vuFwFzY67bhvASrY=");

        [FunctionName("IotApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",  Route = "iotapi")] HttpRequest req,
            ILogger log)
        {
            var list = new List<DeviceItem>();
            var result = registryManager.CreateQuery("SELECT * FROM devices");
            if (result.HasMoreResults)
            {
                foreach(var twin in await result.GetNextAsTwinAsync())
                {
                    var device = new DeviceItem
                    {
                        DeviceId = twin.DeviceId,
                        Status = twin.ConnectionState.ToString(),
                        LastUpdated = twin.Properties.Reported.GetLastUpdated()
                    };

                    try { device.Placement = twin.Properties.Reported["placement"]; }
                    catch { device.Placement = "";}

                    try { device.SensorType = twin.Properties.Reported["sensorType"]; }
                    catch { device.SensorType = ""; }

                    try { device.Alert = twin.Properties.Reported["temperatureAlert".ToString()]; }
                    catch { device.Alert = false; }

                    try { device.Temperature = twin.Properties.Reported["temperature"]; }
                    catch { device.Temperature = 0; }

                    try { device.Humidity = twin.Properties.Reported["humidity"]; }
                    catch { device.Humidity = 0; }

                    list.Add(device);
                }
            }
            return new OkObjectResult(list);
        }
    }
}
