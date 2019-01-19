using System;

namespace CloudflareIntegration.Models
{
    public class DNSRecordModel
    {
        public string id { get; set; }

        public string type { get; set; }

        public string name { get; set; }

        public string content { get; set; }

        public bool proxiable { get; set; }

        public bool proxied { get; set; }

        public int ttl { get; set; } = 1;

        public bool locked { get; set; }

        public string zone_id { get; set; }

        public string zone_name { get; set; }

        public DateTime created_on { get; set; }

        public DateTime modified_on { get; set; }

        public object data { get; set; }

        public Meta meta { get; set; }

        public class Meta
        {
            public bool auto_added { get; set; }
        }
    }
}
