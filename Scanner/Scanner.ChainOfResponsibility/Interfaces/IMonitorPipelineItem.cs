namespace Scanner.ChainOfResponsibility
{
    public interface IMonitorPipelineItem
    {
        void SetNextItem(IMonitorPipelineItem pipelineItem);
        void ProcessData(IMonitorData data);
    }
}