using Scanner.ChainOfResponsibility;
using Scanner.Emulator;
using Scanner.Strategy;
using Scanner.Strategy.Interfaces;
using Scanner.Strategy.OutputStrategies;
using Scanner.Visitor;

//IScannerDevice device = new ScannerDevice();

//IScanOutputStrategy strategy = new TxtScanOutputStrategy();

//ScannerContext context = new(device);
//context.SetupOutputScanStrategy(strategy);

//context.Execute("test.txt");

IMonitorData monitorData = new MonitorData();

IMonitoringSystemDevice monitoringSystemDevice = new MonitoringSystemDevice(monitorData);

MonitorDeviceContext deviceContext = new(monitoringSystemDevice);

deviceContext.RunMonitorProcess();

//DeviceVisitor visitor = new();

//IDeviceInfo deviceInfo = new ScannerDeviceInfo();
//visitor.VisitScanner(deviceInfo);