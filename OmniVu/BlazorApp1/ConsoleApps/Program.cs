

namespace ConsoleApps
{
    public  class Program
    {
    
        public static void Main(string[] args)
    {
            ConsDevClass IoTDevice2 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IotDevice2;SharedAccessKey=3rhl7My1MohGNH+jUl6bxZQ/PPF2hEiOsBRkJnbKplo=");
            ConsDevClass IoTDevice3 = new ConsDevClass("HostName=embedcontrol-IotHub.azure-devices.net;DeviceId=IoTDevice3;SharedAccessKey=qas4TdCVtd5iYJqwPOXBfiFnDNaZGluCnxpCJp9eT7w=");
            Console.WriteLine("Fungerar detta?");
            Thread.IoTDevice2.Loop();
            Thread.IoTDevice3.Loop();
        }
    }

}