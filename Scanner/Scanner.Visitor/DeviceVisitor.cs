using Scanner.ChainOfResponsibility;

namespace Scanner.Visitor
{
    public sealed class DeviceVisitor : IMonitorVisitor
    {
        public void VisitScanner(IDeviceInfo info)
        {
            Console.WriteLine($"CPU: {info.Cpu} %");
            Console.WriteLine($"RAM: {info.Ram} %");
        }
    }
}