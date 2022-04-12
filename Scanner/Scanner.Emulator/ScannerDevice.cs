using Scanner.Strategy.Interfaces;

namespace Scanner.Emulator
{
    public class ScannerDevice : IScannerDevice
    {
        private const string _testFileName = "file.txt";

        public Stream Scan()
        {
            return new StreamReader(_testFileName).BaseStream;
        }
    }
}