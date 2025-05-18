using System.Reflection;
using Dinja;
using RdpShield.Services;
using Serilog;

//Configuring the logger
Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs.txt")
    .CreateLogger();

var registry = new Registry("appsettings.json")
    .AddContainer(Assembly.GetExecutingAssembly());

await registry.AddEntryPointAsync<LogAnalyzerService>(async app => await app.Run());