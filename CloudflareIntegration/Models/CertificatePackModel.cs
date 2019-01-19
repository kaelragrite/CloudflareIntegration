using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CloudflareIntegration.Models
{
    public class CertificatePackModel
    {
        public string id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CertificateType type { get; set; }

        public string[] hosts { get; set; }

        public Certificate[] certificates { get; set; }

        public string primary_certificate { get; set; }

        public enum CertificateType
        {
            cloudflare,
            custom,
            keyless,
            dedicated,
            dedicated_custom
        }

        public class Certificate
        {
            public string id { get; set; }

            public string[] hosts { get; set; }

            public string issuer { get; set; }

            public string signature { get; set; }

            public string status { get; set; }

            public string bundle_method { get; set; }

            public Restriction[] geo_restrictions { get; set; }

            public string zone_id { get; set; }

            public DateTime uploaded_on { get; set; }

            public DateTime? modified_on { get; set; }

            public DateTime? expires_on { get; set; }

            public int priority { get; set; }

            public class Restriction
            {
                public string label { get; set; }
            }
        }
    }
}
