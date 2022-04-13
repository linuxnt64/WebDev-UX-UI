

namespace ConsoleApps
{
    public  class Program
    {
    
        public static void Main(string[] args)
    {
            ConsDevClass IotDevice2 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=");
            ConsDevClass IoTDevice3 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice3;SharedAccessKey=qas4TdCVtd5iYJqwPOXBfiFnDNaZGluCnxpCJp9eT7w=");
            ConsDevClass IoTDevice4 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice4;SharedAccessKey=3IMZb4P2IaF4q8AFhcDf5ySMU/yfWp1uAgaUbV6BzQ4=");
            Console.WriteLine("Console device progress screen:\n");
 
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