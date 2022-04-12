using Scanner.ChainOfResponsibility.PipelineItems;
using System.Diagnostics;

namespace Scanner.ChainOfResponsibility
{
    public sealed class RamMonitorPipelineItem : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }
            if (data.Ram == 0)
            {
                return false;
            }

            Console.WriteLine($"RAM: {data.Ram} %");

            return true;
        }
    }
}