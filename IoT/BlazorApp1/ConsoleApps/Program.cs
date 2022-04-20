namespace ConsoleApps
{
    public class Program
    {
        private static List<string> _iotdevices = new List<string>()
        {
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=",
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice3;SharedAccessKey=qas4TdCVtd5iYJqwPOXBfiFnDNaZGluCnxpCJp9eT7w=",
            "HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice4;SharedAccessKey=3IMZb4P2IaF4q8AFhcDf5ySMU/yfWp1uAgaUbV6BzQ4="
        };

        public static void Main(string[] Args)
        {
            int _sleepTime;

            try
            {
                _sleepTime = Convert.ToInt32(Args[0]);
            }
            catch
            {
                _sleepTime = 10;
            }

            foreach (var device in _iotdevices)
            {
                ConsDevClass IotDevice = new ConsDevClass(device);
                IotDevice.Init(_sleepTime);
            }
            Console.WriteLine("Init has finished, Any key to shut down ...");
            Console.ReadKey();
        }
    }
}









/*        {
            ConsDevClass IotDevice2 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=");
            ConsDevClass IoTDevice3 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice3;SharedAccessKey=qas4TdCVtd5iYJqwPOXBfiFnDNaZGluCnxpCJp9eT7w=");
            ConsDevClass IoTDevice4 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice4;SharedAccessKey=3IMZb4P2IaF4q8AFhcDf5ySMU/yfWp1uAgaUbV6BzQ4=");
            Console.WriteLine("Console device progress screen:\nPress a Key to continue\n");
            Console.ReadKey();
            
            Thread thread2 = new Thread(IotDevice2.Loop);
            thread2.Start();
            Thread.Sleep(10 * 1000);
            Thread thread3 = new Thread(IoTDevice3.Loop);
            thread3.Start();
            Thread.Sleep(10 * 1000);
            IoTDevice4.Loop();
        }
    }
}

            */