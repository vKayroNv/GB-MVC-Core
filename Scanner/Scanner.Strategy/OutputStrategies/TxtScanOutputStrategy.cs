using Scanner.Strategy.Interfaces;
using System.Reflection.Metadata;

namespace Scanner.Strategy.OutputStrategies
{
    public sealed class TxtScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            using StreamReader sr = new(scannerDevice.Scan());
            using StreamWriter sw =new(outputFileName);
            sw.Write(sr.ReadToEnd());
        }
    }
}