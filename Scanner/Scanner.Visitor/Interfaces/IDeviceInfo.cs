namespace Scanner.Visitor
{
    public interface IDeviceInfo
    {
        ICpuData Cpu { get; }
        IRamMemory Ram { get; }
        void Accept(IMonitorVisitor visitor);
    }
}