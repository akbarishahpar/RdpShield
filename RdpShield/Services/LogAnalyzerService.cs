using System.Diagnostics;
using RdpShield.Models;
using Serilog;

namespace RdpShield.Services;

public class LogAnalyzerService
{
    private readonly StorageService _storageService;
    private readonly JailOptions _jailOptions;
    private readonly EventLog _eventLog;

    public LogAnalyzerService(StorageService storageService, JailOptions jailOptions)
    {
        _storageService = storageService;
        _jailOptions = jailOptions;
        _eventLog = new EventLog("Security");
        _eventLog.EntryWritten += OnEventWritten;
        _eventLog.EnableRaisingEvents = true;
    }

    public async Task Run()
    {
        Log.Information("Started monitoring RDP service.");

        while (true)
        {
            foreach (var ip in _storageService.GetIpsToUnblock(_jailOptions.KeepSuspectsInJailInSeconds))
            {
                Log.Information("Unblocked `{@ip}`.", ip);
                FirewallManagerService.UnBlock(ip);
            }

            foreach (var ip in _storageService
                         .GetIpsToBlock(_jailOptions.FailedAttemptsToBlockSuspects)
                         .Where(ip => !FirewallManagerService.IsBlocked(ip)))
            {
                Log.Error("Blocked `{@ip}` for {@blockDuration} seconds.", ip, _jailOptions.KeepSuspectsInJailInSeconds);
                FirewallManagerService.Block(ip);
            }

            await Task.Delay(1);
        }
    }

    private void OnEventWritten(object sender, EntryWrittenEventArgs e)
    {
        if (e.Entry.InstanceId != 4625)
            return;

        var ip = LogParserService.ExtractIp(e.Entry.Message);
        if (string.IsNullOrEmpty(ip))
            return;

        Log.Warning("Detected a failed RDP login attempt from `{@ip}`.", ip);

        _storageService.Report(ip);
    }
}