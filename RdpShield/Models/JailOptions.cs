using Dinja.ServiceTypes;

namespace RdpShield.Models;

[Configuration(nameof(JailOptions))]
public class JailOptions
{
    public int FailedAttemptsToBlockSuspects { get; set; }
    public int KeepSuspectsInJailInSeconds { get; set; }
}