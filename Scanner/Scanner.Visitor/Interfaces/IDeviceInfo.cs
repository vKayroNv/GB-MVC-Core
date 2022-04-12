namespace Scanner.Visitor
{
    public interface IDeviceInfo
    {
        int Cpu { get; }
        int Ram { get; }

        void Accept(IMonitorVisitor visitor);
    }
}