using Scanner.ChainOfResponsibility;

namespace Scanner.Visitor
{
    public sealed class ScannerDeviceInfo : IDeviceInfo
    {
        public int Cpu { get; set; }
        public int Ram { get; set; }

        private IMonitorData _monitorData = null!;

        public ScannerDeviceInfo(IMonitorData monitorData)
        {
            _monitorData = monitorData;
        }

        public void Accept(IMonitorVisitor visitor)
        {
            if (visitor is null)
            {
                return;
            }

            Cpu = _monitorData.Cpu;
            Ram = _monitorData.Ram;

            visitor.VisitScanner(this);
        }
    }
}