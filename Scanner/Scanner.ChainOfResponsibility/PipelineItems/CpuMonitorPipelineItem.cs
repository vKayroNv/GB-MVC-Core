using Scanner.ChainOfResponsibility.PipelineItems;
using System.Diagnostics;

namespace Scanner.ChainOfResponsibility
{
    public sealed class CpuMonitorPipelineItem : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }
            if (data.Cpu == 0)
            {
                return false;
            }

            Console.WriteLine($"CPU: {data.Cpu} %");

            return true;
        }
    }
}