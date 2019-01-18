using CloudflareIntegration.Models;
using System.Linq;

namespace CloudflareIntegration
{
    public class CloudflareManager
    {
        private readonly CloudflareClient _client;

        // გადაწყობისას დასამატებელია DI
        public CloudflareManager() => _client = new CloudflareClient();

        public (bool success, string message) AddDomainWithOperations(DomainModel domain)
        {
            var createZoneResponse = _client.CreateZone(new ZoneObjectModel { name = domain.Name }).Result;
            if (!createZoneResponse.Success) return (false, $"Failed to create zone: {createZoneResponse.Errors.ToString()}");

            var dnsList = _client.DNSRecordsList(createZoneResponse.Result.id).Result;
            if (!dnsList.Success) return (false, $"Failed to query DNS records: {dnsList.Errors.ToString()}");

            foreach (var dns in dnsList.Result.Where(x => x.type == "A"))
            {
                var deleteResult = _client.DeleteDNSRecord(createZoneResponse.Result.id, dns.id).Result;
                if (!deleteResult.Success) return (false, $"Failed to delete DNS records: {deleteResult.Errors.ToString()}");
            }

            if (dnsList.Result.All(x => x.type != "CNAME"))
            {
                var createDNSResult = _client.CreateDNSRecord(createZoneResponse.Result.id, new DNSRecordObjectModel
                {
                    type = "CNAME",
                    name = "www",
                    content = domain.Name,
                    proxied = true
                }).Result;

                if (!createDNSResult.Success) return (false, $"Failed to create DNS record: {createDNSResult.Errors.ToString()}");
            }

            foreach (var dns in domain.DNSRecords)
            {
                var createDNSResult = _client.CreateDNSRecord(createZoneResponse.Result.id, new DNSRecordObjectModel
                {
                    type = dns.Type,
                    name = domain.Name,
                    content = dns.Content,
                    proxied = dns.Proxied
                }).Result;

                if (!createDNSResult.Success) return (false, $"Failed to create DNS record: {createDNSResult.Errors.ToString()}");
            }

            return (false, "");
        }
    }
}
