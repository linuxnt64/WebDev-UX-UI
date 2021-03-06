using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System.Text;

namespace ConsoleApps
{
    public class ConsDevClass
    {
        public string connectionString = "";
        public string instance = "";
        private readonly DeviceClient deviceClient;
        private Random rnd = new Random();
        private int sleepTime;

        public ConsDevClass(string connectionString)
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
            instance = connectionString.Substring(56, 10);
        }
        public void Init(int _sleepTime)
        {
            {
                sleepTime = _sleepTime;
                SendMessage();
                Thread.Sleep(sleepTime * 1000);
            }
        }
        public async Task SendMessage()
        {
            bool dryRun = false;
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(3 * sleepTime));
            if (!dryRun) System.Console.WriteLine($"{instance} has started on thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
            int lastTemp = 25, temperature = 25;

            do
            {
                int highlow = rnd.Next(0, 100);
                lastTemp = temperature;
                temperature = rnd.Next(20, 30);
                if (temperature > lastTemp) temperature = ++lastTemp;
                else if (temperature < lastTemp) temperature = --lastTemp;
                if (highlow > 97 & temperature <= 30) { temperature = (temperature + 12); Console.Write("rnd High : "); }
                if (highlow < 3 & temperature >= 20) { temperature = temperature - 12; Console.Write("rnd Low : "); }
                int humidity = rnd.Next(30, 40);
                bool temperatureAlert = (temperature >= 27);

                var data = new { temperature = temperature, humiditiy = humidity };
                var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
                if (!dryRun) await deviceClient.SendEventAsync(message);

                TwinCollection reportedProperties = new TwinCollection();
                reportedProperties["temperature"] = temperature;
                reportedProperties["humidity"] = humidity;
                reportedProperties["temperatureAlert"] = temperatureAlert;
                reportedProperties["sensorType"] = "Console app device simulator";
                reportedProperties["placement"] = "Local PC";
                if (!dryRun) await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
                System.Console.WriteLine($"{instance} sent a message to Azure IOT Hub at {DateTime.Now}: {temperature}'C , {humidity}% , Alert:{temperatureAlert}");
            } while (await timer.WaitForNextTickAsync());
        }
    }
}

