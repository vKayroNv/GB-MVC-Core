namespace Scanner.ChainOfResponsibility
{
    public interface IMonitoringSystemDevice
    {
        IEnumerator<IMonitorData> GetEnumerator();
    }
}