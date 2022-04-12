using Scanner.Strategy.Interfaces;

namespace Scanner.Strategy.OutputStrategies
{
    public sealed class ConsoleScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            using StreamReader sr = new(scannerDevice.Scan());

            while (!sr.EndOfStream)
                Console.WriteLine(sr.ReadLine());
        }
    }
}