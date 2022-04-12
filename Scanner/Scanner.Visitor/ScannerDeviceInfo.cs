namespace Scanner.Visitor
{
    public sealed class ScannerDeviceInfo : IDeviceInfo
    {
        public ICpuData Cpu { get; set; }
        public IRamMemory Ram { get; set; }

        public void Accept(IMonitorVisitor visitor)
        {
            if (visitor is null)
            {
                return;
            }
            visitor.VisitScanner(this);
        }
    }
}