using Scanner.ChainOfResponsibility;

namespace Scanner.Emulator
{
    public class MonitoringSystemDevice : IMonitoringSystemDevice
    {
        private readonly IMonitorData _data;

        public MonitoringSystemDevice(IMonitorData data)
        {
            _data = data;
        }

        public IEnumerator<IMonitorData> GetEnumerator()
        {
            return new List<IMonitorData>() { _data }.GetEnumerator();
        }
    }
}
