using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CloudflareIntegration.Models
{
    public class AlwaysUseHTTPSSetting
    {
        public string id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AlwaysUseHTTPSSettingValue value { get; set; }

        public bool? editable { get; set; }

        public DateTime? modified_on { get; set; }

        public enum AlwaysUseHTTPSSettingValue
        {
            on,
            off
        }
    }
}
