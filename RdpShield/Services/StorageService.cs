using Dinja.ServiceTypes;
using LiteDB;
using RdpShield.Models;

namespace RdpShield.Services;

[Singleton]
public class StorageService : IDisposable
{
    private readonly LiteDatabase _db;
    private readonly ILiteCollection<Suspect> _suspects;

    public StorageService()
    {
        _db = new LiteDatabase("Jail.db");
        _suspects = _db.GetCollection<Suspect>("Suspects");
    }

    public void Report(string ip)
    {
        // Looking up related prisoner
        var prisoner = _suspects.Query()
            .Where(x => x.Ip == ip)
            .SingleOrDefault();

        if (prisoner == null) // Insert a new prisoner if the ip was a new one
        {
            _suspects.Insert(new Suspect
            {
                Ip = ip,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Failures = 1
            });
        }
        else // Update failures count if it has a history
        {
            prisoner.Failures++;
            prisoner.ModifiedOn = DateTime.Now;
            _suspects.Update(prisoner.Ip, prisoner);
        }
    }

    public List<string> GetIpsToUnblock(int threshold)
    {
        // Fetching expired ips
        var to = DateTime.Now.AddSeconds(-threshold);
        var expiredIps = _suspects.Query()
            .Where(x => x.ModifiedOn < to)
            .Select(x => x.Ip)
            .ToList();

        // Removing duplicate ips
        expiredIps = expiredIps.Distinct().ToList();

        // Deleting expired ips
        _suspects.DeleteMany(x => expiredIps.Contains(x.Ip));

        return expiredIps;
    }

    public List<string> GetIpsToBlock(int threshold)
    {
        var ipsToBlock = _suspects.Query()
            .Where(x => x.Failures >= threshold)
            .Select(x => x.Ip)
            .ToList();

        return ipsToBlock.Distinct().ToList();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}