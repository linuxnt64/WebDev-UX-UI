
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System.Text;

public class Program
{
    private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=");
    private static Random rnd = new Random();

    public static async Task Main(string[] args)
    {
        while (true)
        {
            await SendMessageAsync();
            System.Console.WriteLine($"Message sent to Azure IOT Hub at: {DateTime.Now}");
            await Task.Delay(30 * 1000);
        }
    }

    public static async Task SendMessageAsync()
    {
        var temperature = rnd.Next(20, 30);
        var humidity = rnd.Next(30, 40);
        var temperatureAlert = false;

        if (temperature >= 25)
            temperatureAlert = true;

        var data = new { temperature = temperature, humiditiy = humidity };
        var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        await deviceClient.SendEventAsync(message);

        TwinCollection reportedProperties = new TwinCollection();
        reportedProperties["sensorType"] = "Console Device";
        reportedProperties["temperature"] = temperature;
        reportedProperties["humidity"] = humidity;
        reportedProperties["temperatureAlert"] = temperatureAlert;
        await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
    }
}