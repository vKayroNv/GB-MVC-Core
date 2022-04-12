namespace Scanner.Visitor
{
    public interface IMonitorVisitor
    {
        void VisitScanner(IDeviceInfo info);
    }
}