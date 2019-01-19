using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CloudflareIntegration.Models
{
    public class SSLSettingModel
    {
        public string id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SSLSettingValue value { get; set; }

        public bool? editable { get; set; }

        public DateTime? modified_on { get; set; }

        public enum SSLSettingValue
        {
            off,
            flexible,
            full,
            strict
        }
    }
}
