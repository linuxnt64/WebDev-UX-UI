using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctHubAPI
{
    public class IoTDevice1
    {
 //       private readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(Environment.GetEnvironmentVariable("IotDevice1"));
        private readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=080973bc-e458-4eb9-a0a4-9cc408648903;SharedAccessKey=fM8sdnp4DC3ygGYGU2rK4XmTK8WTvIcskJGSu3rPz2M=");
        private Random rnd = new Random();

        [FunctionName("IotDevice1")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            await SendMessageAsync();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
        public async Task SendMessageAsync()
        {
            var temperature = rnd.Next(20, 30);
            var humidity = rnd.Next(30, 40);
            var temperatureAlert = false;
            if(temperature >= 25) { temperatureAlert = true; }
            var data = new { temperature = temperature, humidity = humidity };
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            await deviceClient.SendEventAsync(message);

            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["sensorType"] = "Console app device simulator";
            reportedProperties["placement"] = "Azure";
            reportedProperties["temperature"] = temperature;
            reportedProperties["humidity"] = humidity;
            reportedProperties["temperatureAlert"] = temperatureAlert;
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
        }
    }
}
