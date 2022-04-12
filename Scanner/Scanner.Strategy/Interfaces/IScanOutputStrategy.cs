namespace Scanner.Strategy.Interfaces
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }

}