using LiteDB;

namespace RdpShield.Models;

public class Suspect
{
    [BsonId] public string Ip { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int Failures { get; set; }
}