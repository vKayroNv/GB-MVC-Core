using Autofac;
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

//IMonitorData monitorData = new MonitorData();

//IMonitoringSystemDevice monitoringSystemDevice = new MonitoringSystemDevice(monitorData);

//MonitorDeviceContext monitorDeviceContext = new(monitoringSystemDevice);

//monitorDeviceContext.RunMonitorProcess();

//DeviceVisitor deviceVisitor = new();

//IDeviceInfo deviceInfo = new ScannerDeviceInfo(monitorData);
//deviceInfo.Accept(deviceVisitor);


var builder = new ContainerBuilder();

builder.RegisterType<ScannerDevice>().As<IScannerDevice>().SingleInstance();
builder.RegisterType<ConsoleScanOutputStrategy>().As<IScanOutputStrategy>();
builder.RegisterType<ScannerContext>();

builder.RegisterType<MonitorData>().As<IMonitorData>();
builder.RegisterType<MonitoringSystemDevice>().As<IMonitoringSystemDevice>();
builder.RegisterType<MonitorDeviceContext>();

builder.RegisterType<DeviceVisitor>();
builder.RegisterType<ScannerDeviceInfo>().As<IDeviceInfo>();

IContainer container = builder.Build();


var strategy = container.Resolve<IScanOutputStrategy>();
var scannerContext = container.Resolve<ScannerContext>();
scannerContext.SetupOutputScanStrategy(strategy);
scannerContext.Execute();

Console.WriteLine();

container.Resolve<MonitorDeviceContext>().RunMonitorProcess();

Console.WriteLine();

var deviceVisitor = container.Resolve<DeviceVisitor>();
container.Resolve<IDeviceInfo>().Accept(deviceVisitor);