using System.Collections.Generic;

namespace CloudflareIntegration.Models
{
    public class DomainModel
    {
        public string Name { get; set; }

        public IEnumerable<DNSRecord> DNSRecords { get; set; }

        public class DNSRecord
        {
            public string Type { get; set; }

            public string Content { get; set; }

            public bool Proxied { get; set; }
        }
    }
}
