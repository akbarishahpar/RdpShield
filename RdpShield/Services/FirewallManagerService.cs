using System.Diagnostics;

namespace RdpShield.Services;

public static class FirewallManagerService
{
    public static void Block(string ip) => Execute(
        $"netsh advfirewall firewall add rule name=\"{GenerateRuleName(ip)}\" dir=in interface=any action=block remoteip={ip}"
    );

    public static void UnBlock(string ip) => Execute(
        $"netsh advfirewall firewall delete rule name=\"{GenerateRuleName(ip)}\""
    );
    
    public static bool IsBlocked(string ip)
    {
        // Configuring the process
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = $"advfirewall firewall show rule name=\"{GenerateRuleName(ip)}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        // Executing the process
        process.Start();

        // Reading the output
        var output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return !output.Contains("No rules match the specified criteria");
    }

    private static string GenerateRuleName(string ip) => $"RdpShield_Block_{ip}";

    private static void Execute(string cmd) => Process.Start(new ProcessStartInfo("cmd.exe", "/c " + cmd)
    {
        CreateNoWindow = true,
        UseShellExecute = false
    })?.WaitForExit();
}