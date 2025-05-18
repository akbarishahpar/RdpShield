using System.Text.RegularExpressions;

namespace RdpShield.Services;

public static class LogParserService
{
    public static string ExtractIp(string message)
    {
        var match = Regex.Match(message, @"Source Network Address:\s+(\d+\.\d+\.\d+\.\d+)");
        if (match.Success && match.Groups[1].Value != "127.0.0.1")
            return match.Groups[1].Value;
        return string.Empty;
    }
}