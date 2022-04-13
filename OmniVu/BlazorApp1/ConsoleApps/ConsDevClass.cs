using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ConsoleApps
{
    public class ConsDevClass
    {

        public string connectionString = "";
        private int temperature, humidity;
        private bool temperatureAlert;
        private readonly DeviceClient deviceClient;
        private Random rnd = new Random();

        public ConsDevClass(string connectionString)
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }
        public void Loop()
        {
            while (true)
            {
                SendMessage();
                System.Console.WriteLine($"Message sent to Azure IOT Hub at {DateTime.Now}: {temperature}'C , {humidity}% , Alert:{temperatureAlert}");
                Thread.Sleep(10 * 1000);
            }
        }

        public async Task SendMessage()
        {
            temperature = rnd.Next(20, 30);
            humidity = rnd.Next(30, 40);
            temperatureAlert = (temperature >= 25);

            var data = new { temperature = temperature, humiditiy = humidity };
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            await deviceClient.SendEventAsync(message);

            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["sensorType"] = "Console app device simulator";
            reportedProperties["placement"] = "Local PC";
            reportedProperties["temperature"] = temperature;
            reportedProperties["humidity"] = humidity;
            reportedProperties["temperatureAlert"] = temperatureAlert;
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
        }
    }
}

