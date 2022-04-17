using Microsoft.Azure.Devices.Client;
using System.Text;

namespace  IOTDevices 
{ 
    public static class Program
    {
        private static List<string> _iotdevices = new List<string>()
        {
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=",
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice3;SharedAccessKey=qas4TdCVtd5iYJqwPOXBfiFnDNaZGluCnxpCJp9eT7w=",
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice4;SharedAccessKey=3IMZb4P2IaF4q8AFhcDf5ySMU/yfWp1uAgaUbV6BzQ4="
        };

        public static void Main()
        {
            foreach (var device in _iotdevices)
            {
                Task.Run(async () => await InitializeDevice(device));
                Thread.Sleep(10 * 1000);
            }
            Console.ReadKey();
        }
        public static async Task InitializeDevice(string connectionString)
        {
            var deviceId = connectionString.Split(";")[1].Split("=")[1];
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(30));
            var deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);
            Console.WriteLine($"{deviceId} initialized ");

            while(await timer.WaitForNextTickAsync())
            {
                var message = $"{deviceId} sent a message at: {DateTime.Now}";

                await deviceClient.SendEventAsync(new Message(Encoding.UTF8.GetBytes(message)));
                Console.WriteLine(message);
            }        
        }

    }
}
